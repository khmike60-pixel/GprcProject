using GrpcCommonNet.Library.Common;
using GrpcWinForms.Objects.Currencies.Views;
using System;

namespace GrpcWinForms.Objects.Currencies.Presenters
{
    public class CurrencyPresenter
    {
        private readonly ICurrencyView _view;

        public CurrencyPresenter(ICurrencyView view)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
        }

        // Инициализация формы — заполнить поля из модели
        public void OnLoad()
        {
            if (_view.Currency == null)
                _view.Currency = new Currency();

            _view.IdText = _view.Currency.Id.ToString();
            _view.Code = _view.Currency.Code ?? string.Empty;
            _view.CurrencyName = _view.Currency.Name ?? string.Empty;
            _view.Abbrev = _view.Currency.Abbrev ?? string.Empty;
            _view.IsVisible = _view.Currency.IsVisible;
        }

        // Возвращает true, если данные корректны и можно закрывать диалог как OK
        public bool OnOk()
        {
            // Валидация (простая): обязательно имя
            if (string.IsNullOrWhiteSpace(_view.CurrencyName))
            {
                _view.ShowMessage("Введите наименование валюты.", "Валидация");
                return false;
            }

            // Сохранение значений в модель
            if (!_view.IsNew)
            {
                if (int.TryParse(_view.IdText, out int id))
                    _view.Currency.Id = id;
                else
                    _view.Currency.Id = 0;
            }
            else
            {
                _view.Currency.Id = 0;
            }

            _view.Currency.Abbrev = _view.Abbrev ?? string.Empty;
            _view.Currency.Code = _view.Code ?? string.Empty;
            _view.Currency.Name = _view.CurrencyName ?? string.Empty;
            _view.Currency.IsVisible = _view.IsVisible;

            return true;
        }
    }
}