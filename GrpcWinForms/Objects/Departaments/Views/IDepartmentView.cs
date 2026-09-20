using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Library.Department;
using System;

namespace GrpcWinForms.Objects.Departaments.Views
{
    public interface IDepartmentView
    {
        event EventHandler LoadView;
        event EventHandler OkClicked;
        event EventHandler CancelClicked;

        // Доступ к полям формы
        string IdText { get; set; }
        string NameText { get; set; }
        string ShortText { get; set; }
        string CodeText { get; set; }

        Department Department { get; set; }

        void ShowMessage(string message);
        void CloseWithOk();
    }
}