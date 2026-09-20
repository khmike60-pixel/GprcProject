using GrpcWinForms.Objects.DocumentTypes.Views;
using GrpcCommonNet.Library.Common;
using System;
using System.Windows.Forms;

namespace GrpcWinForms.Objects.DocumentTypes.Presenters
{
    public class DocumentTypePresenter
    {
        private readonly IDocumentTypeView _view;

        public DocumentTypePresenter(IDocumentTypeView view)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
        }

        // Заполнить поля формы из модели
        public void Initialize()
        {
            if (_view.DocumentType == null)
                _view.DocumentType = new DocumentType();

            // Дефолт для CountryCurrencyId как в оригинале
            if (_view.DocumentType.CountryCurrencyId == 0)
                _view.DocumentType.CountryCurrencyId = 1;

            _view.NameText = _view.DocumentType.Name ?? string.Empty;
            _view.CodeText = _view.DocumentType.Code ?? string.Empty;
            _view.FormText = _view.DocumentType.Form ?? string.Empty;
            _view.ViewDetailText = _view.DocumentType.ViewDetail ?? string.Empty;
            _view.ViewMasterText = _view.DocumentType.ViewMaster ?? string.Empty;

            // В прежнем коде выбор CurrencyType использовал Items[CurrencyType] и SelectedItem.Value.
            // Здесь мы выставляем value в предусмотренном интерфейсе (presenter не управляет элементами ComboBox напрямую).
            _view.CurrencyTypeValue = _view.DocumentType.CurrencyType;
            _view.CountryCurrencyIndex = Math.Max(0, _view.DocumentType.CountryCurrencyId - 1);

            _view.IsDefault = _view.DocumentType.IsDefault;
            _view.IsContract = _view.DocumentType.IsContract;
        }

        // Считать значения из формы в модель; вернуть true, если всё ок
        public bool ApplyChanges()
        {
            try
            {
                // Простейшая валидация
                if (string.IsNullOrWhiteSpace(_view.NameText))
                {
                    _view.ShowMessage("Наименование не может быть пустым.", "Валидация");
                    return false;
                }

                var doc = _view.DocumentType ?? new DocumentType();

                doc.Name = _view.NameText ?? string.Empty;
                doc.Code = _view.CodeText ?? string.Empty;
                doc.Form = _view.FormText ?? string.Empty;
                doc.ViewDetail = _view.ViewDetailText ?? string.Empty;
                doc.ViewMaster = _view.ViewMasterText ?? string.Empty;

                // CurrencyTypeValue — ожидается корректное целое значение
                doc.CurrencyType = _view.CurrencyTypeValue;
                doc.CountryCurrencyId = Math.Max(1, _view.CountryCurrencyIndex + 1);

                doc.IsDefault = _view.IsDefault;
                doc.IsContract = _view.IsContract;

                _view.DocumentType = doc;
                return true;
            }
            catch (Exception ex)
            {
                _view.ShowMessage("Ошибка при сохранении данных: " + ex.Message, "Ошибка");
                return false;
            }
        }
    }
}