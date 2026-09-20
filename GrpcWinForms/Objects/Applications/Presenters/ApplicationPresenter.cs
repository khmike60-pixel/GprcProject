using GrpcWinForms.Objects.Applications.Views;
using System;

namespace GrpcWinForms.Objects.Applications.Presenters
{
    public class ApplicationPresenter
    {
        private readonly IApplicationView _view;

        public ApplicationPresenter(IApplicationView view)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
        }

        // Инициализация формы — заполнить поля из модели
        public void OnLoad()
        {
            if (_view.Application == null)
                _view.Application = new GrpcCommonNet.Library.Common.Application();

            _view.IdText = _view.Application.Id.ToString();
            _view.AppName = _view.Application.Name ?? string.Empty;
            _view.Db = _view.Application.Db ?? string.Empty;
            _view.Product = _view.Application.Product ?? string.Empty;
        }

        // Возвращает true, если данные корректны и можно закрывать диалог как OK
        public bool OnOk()
        {
            // Валидация (простая): обязательно имя
            if (string.IsNullOrWhiteSpace(_view.AppName))
            {
                _view.ShowMessage("Введите наименование приложения.", "Валидация");
                return false;
            }

            // Сохранение значений в модель
            if (!_view.IsNew)
            {
                if (int.TryParse(_view.IdText, out int id))
                    _view.Application.Id = id;
                else
                    _view.Application.Id = 0;
            }
            else
            {
                _view.Application.Id = 0;
            }

            _view.Application.Name = _view.AppName ?? string.Empty;
            _view.Application.Db = _view.Db ?? string.Empty;
            _view.Application.Product = _view.Product ?? string.Empty;

            return true;
        }
    }
}