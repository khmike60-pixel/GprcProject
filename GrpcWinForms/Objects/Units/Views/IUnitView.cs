using GrpcCommonNet.Library.Common;

namespace GrpcWinForms.Objects.Units.Views
{
    public interface IUnitView
    {
        bool IsTypeInsert { get; set; }
        Unit EditUnit { get; set; }

        // Геттеры/сеттеры полей формы — презентер использует их для чтения/записи
        string IdText { get; }
        string ShortText { get; }
        string RemText { get; }
        string RwsCodeText { get; }
        string RwsMcodeText { get; }
        string CommentText { get; }
        string CodeText { get; }
        bool IsArchiveChecked { get; }

        void SetFieldsFromUnit(Unit unit);
        void CloseWithResult(DialogResult result);
        void AppendTitle(string suffix);
    }
}