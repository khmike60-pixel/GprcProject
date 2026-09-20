using GrpcCommonNet.Library.Common;
using System.Windows.Forms;

namespace GrpcWinForms.Objects.DocumentTypes.Views
{
    public interface IDocumentTypeView
    {
        DocumentType DocumentType { get; set; }
        bool EditMode { get; set; }

        // Поля формы
        string NameText { get; set; }
        string CodeText { get; set; }
        string FormText { get; set; }
        string ViewDetailText { get; set; }
        string ViewMasterText { get; set; }

        // Значение типа валюты — целое, соответствует Value в ComboBoxItem
        int CurrencyTypeValue { get; set; }

        // Индекс выбранной валюты страны в ComboBox (0-based)
        int CountryCurrencyIndex { get; set; }

        bool IsDefault { get; set; }
        bool IsContract { get; set; }

        // UI-операции
        DialogResult ShowDocumentTypeDialog(Form form);
        void ShowMessage(string text, string caption = "", MessageBoxButtons buttons = MessageBoxButtons.OK);
    }
}