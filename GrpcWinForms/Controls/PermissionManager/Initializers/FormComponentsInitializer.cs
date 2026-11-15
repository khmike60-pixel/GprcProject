using C1.Win.Command;
using C1.Win.FlexGrid;
using GrpcCommonNet.Library.Common;
using GrpcWinForms.Controls.PermissionManager.Models;
using GrpcWinForms.Controls.PermissionManager.PermissionHandler;
using GrpcWinForms.Controls.PermissionManager.Services;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcWinForms.Controls.PermissionManager.Initializers
{
    internal class FormComponentsInitializer : IFormComponentsInitializer
    {
        private readonly Dictionary<string, Permission> _permissions;
        private readonly ComponentPermissionHandlerFactory _permissionHandlerFactory;
        public IPermissionService PermissionService { get; set; }

        public FormComponentsInitializer(IPermissionService permissionService)
        {
            PermissionService = permissionService;
            _permissions = new Dictionary<string, Permission>();
            _permissionHandlerFactory = new ComponentPermissionHandlerFactory();
        }

        /// <summary> Инициализация списка компонентов и их потомков. </summary>
        /// <remarks> В случае какой-либо ошибки, форма будет закрыта </remarks>
        /// <param name="form"> Ссылка на форму для инициализации. </param>
        public void InitializeComponents(Form form)
        {
            if (!GlobalConfig.Enabled)
                return;

            _permissions.Clear();

            IterateOverElements(form.Controls, (Control control, Queue<Control.ControlCollection> controlsQueue) =>
            {
                SetupComponent(control, control.Tag?.ToString());

                if (control.Enabled)
                {
                    if (control is C1ToolBar toolbar)
                        IterateOverElements<C1CommandLink, C1CommandLinks>(toolbar.CommandLinks, IterateCommandLinks);
                }

                controlsQueue.Enqueue(control.Controls);
            });
        }

        /// <summary> Коллбек-обработчик ссылок компонента C1CommandLink. </summary>
        /// <param name="commandLink"> Текущая ссылка для обработки </param>
        /// <param name="commandLinksQueue"> Очередь ссылок. </param>
        private void IterateCommandLinks(C1CommandLink commandLink, Queue<C1CommandLinks> commandLinksQueue)
        {
            SetupComponent(commandLink, commandLink.Command.UserData?.ToString());

            if (commandLink.Command is C1CommandMenu commandMenu)
                commandLinksQueue.Enqueue(commandMenu.CommandLinks);
        }

        /// <summary> Инициализация прав на конкретный компонент. </summary>
        /// <param name="component"> Ссылка на компонент. </param>
        /// <param name="componentKeyName"> Тег или какое-то имя идентифицирущее компонент. </param>
        private void SetupComponent(object component, string componentKeyName)
        {
            if (string.IsNullOrEmpty(componentKeyName)) return;

            Permission GetOrFetch(string name)
            {
                if (_permissions.TryGetValue(name, out var cached)) return cached;
                var p = PermissionService.GetPermission(name);
                _permissions[name] = p ?? GetDefaultPermission();
                return p;
            }

            if (component is C1FlexGrid)
            {
                PermissionTagsRoot root;
                try { root = JsonConvert.DeserializeObject<PermissionTagsRoot>(componentKeyName); }
                catch (JsonException) { return; }

                if (root?.Tags == null) return;

                var handler = _permissionHandlerFactory.GetHandler(component) as C1FlexGridPermissionHandler;
                foreach (var meta in root.Tags)
                {
                    if (string.IsNullOrEmpty(meta.Name)) continue;
                    if (meta.Columns == null || meta.Columns.Count == 0) continue;
                    var permission = GetOrFetch(meta.Name);
                    if (permission == null) continue;
                    handler?.SetupGridColumnPermission(component, permission, meta);
                }
            }
            else
            {
                PermissionMetaData meta;
                Permission permission;
                try
                {
                    meta = JsonConvert.DeserializeObject<PermissionMetaData>(componentKeyName);
                    if (string.IsNullOrEmpty(meta?.Name)) return;
                    permission = GetOrFetch(meta.Name) ?? GetDefaultPermission();
                }
                catch (JsonSerializationException)
                {
                    meta = GetDefaultPermissionMetaData();
                    permission = GetDefaultPermission();
                }
                _permissionHandlerFactory.GetHandler(component)
                                         .SetupComponentPermission(component, permission, meta);
            }
        }

        private void IterateOverElements<TConcrete, TCollection>(TCollection elements, Action<TConcrete, Queue<TCollection>> processElement)
            where TConcrete : class
            where TCollection : class, ICollection
        {
            var elementsQueue = new Queue<TCollection>();
            elementsQueue.Enqueue(elements);

            while (elementsQueue.Count > 0)
            {
                var currentElements = elementsQueue.Dequeue();

                foreach (TConcrete currentElement in currentElements)
                    processElement(currentElement, elementsQueue);
            }
        }

        private static Permission GetDefaultPermission() => new Permission
        {
            Value = PermissionValue.None,
            CanCheck = false,
            CanApprove = false
        };

        private static PermissionMetaData GetDefaultPermissionMetaData() => new PermissionMetaData
        {
            Name = string.Empty,
        };

    }
}
