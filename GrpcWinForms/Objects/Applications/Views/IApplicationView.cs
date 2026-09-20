using GrpcCommonNet.Library.Common;
using System.Windows.Forms;

namespace GrpcWinForms.Objects.Applications.Views
{
    public interface IApplicationView
    {
        GrpcCommonNet.Library.Common.Application Application { get; set; }
        bool IsNew { get; }

        // Поля формы
        string IdText { get; set; }
        string AppName { get; set; }
        string Db { get; set; }
        string Product { get; set; }

        // Утилиты отображения ошибок/сообщений
        void ShowMessage(string text, string caption = "");
    }
}