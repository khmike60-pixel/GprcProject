using GrpcCommonNet.Library.Common;
using System.Windows.Forms;

namespace GrpcWinForms.Objects.Currencies.Views
{
    public interface ICurrencyView
    {
        Currency Currency { get; set; }
        bool IsNew { get; }

        // Поля формы (представление предоставляет доступ к значениям)
        string IdText { get; set; }
        string Code { get; set; }
        string Name { get; set; }
        string Abbrev { get; set; }
        bool IsVisible { get; set; }

        // Утилиты отображения ошибок/сообщений
        void ShowMessage(string text, string caption = "");
    }
}