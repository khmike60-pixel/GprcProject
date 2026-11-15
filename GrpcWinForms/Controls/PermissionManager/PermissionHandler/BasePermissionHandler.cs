using GrpcCommonNet.Library.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GrpcWinForms.Controls.PermissionManager.PermissionHandler
{
    internal abstract class BasePermissionHandler
    {
        // Хранилище подписчиков, чтобы можно было удалять их при необходимости
        private readonly Dictionary<object, Dictionary<string, Delegate>> _eventHandlers = new Dictionary<object, Dictionary<string, Delegate>>();

        /// <summary> Инциализация прав на указанный компонент. </summary>
        /// <param name="component"> Компонент для инициализации. </param>
        /// <param name="permission"> Права. </param>
        /// <param name="permissionMetaData"> Мета-данные прав компонента. </param>
        public abstract void SetupComponentPermission(object component, Permission permission, PermissionMetaData permissionMetaData);

        /// <summary>
        /// Добавляет подписчиков на события компонента ReadOnlyChanged и EnabledChanged, которые запрещают изменять состояние Enabled и ReadOnly.
        /// </summary>
        /// <param name="component"> Ссылка на комопонент для обработки. </param>
        protected void AddDisableEvents(object component)
        {
            if (component.GetType().GetEvent("ReadOnlyChanged") is EventInfo readOnlyChangedEvent)
                AddDisableEvent(component, readOnlyChangedEvent, component.GetType().GetProperty("ReadOnly"), false);

            if (component.GetType().GetEvent("EnabledChanged") is EventInfo enabledChangedEvent)
                AddDisableEvent(component, enabledChangedEvent, component.GetType().GetProperty("Enabled"), false);
        }

        /// <summary>
        /// Удаляет всеъ подписчиков на события компонента ReadOnlyChanged и EnabledChanged, которые запрещают изменять состояние Enabled и ReadOnly.
        /// </summary>
        /// <param name="component"> Ссылка на комопонент для обработки. </param>
        protected void RemoveAllDisableEvents(object component)
        {
            RemoveAllEventHandlers(component, "ReadOnlyChanged");
            RemoveAllEventHandlers(component, "EnabledChanged");
        }

        private void AddDisableEvent(object component, EventInfo componentEvent, PropertyInfo componentProperty, object propertyValue)
        {
            EventHandler handler = (sender, e) => componentProperty.SetValue(component, propertyValue);

            // Сохраняем обработчик, чтобы его можно было удалить позже. 
            if (!_eventHandlers.TryGetValue(component, out var handlers))
            {
                handlers = new Dictionary<string, Delegate>();
                _eventHandlers[component] = handlers;
            }

            handlers[componentEvent.Name] = handler;
            componentEvent.AddEventHandler(component, handler);
        }

        private void RemoveAllEventHandlers(object component, string eventName)
        {
            if (_eventHandlers.TryGetValue(component, out var handlers) && handlers.TryGetValue(eventName, out var handler))
            {
                var componentEvent = component.GetType().GetEvent(eventName);
                if (componentEvent != null)
                {
                    componentEvent.RemoveEventHandler(component, handler);
                    handlers.Remove(eventName);

                    // Если больше нет обработчиков для компонента, удаляем его.
                    if (handlers.Count == 0)
                        _eventHandlers.Remove(component);
                }
            }
        }

    }
}
