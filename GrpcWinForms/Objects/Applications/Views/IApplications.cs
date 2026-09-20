using GrpcCommonNet.Library.Common;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Application = GrpcCommonNet.Library.Common.Application;

namespace GrpcWinForms.Objects.Applications.Views
{
    public interface IApplicationsView
    {
        // Фильтр
        string NameFilter { get; }

        // Коллекция, привязанная к гриду
        BindingList<Application> Applications { get; set; }

        // Положение/фиксированные строки грида
        int RowSel { get; }
        int RowsFixed { get; }

        // Выбранные строки (индексы)
        IList<int> SelectedRows { get; }

        // Доступ к объекту/данным в строке
        Application GetApplicationAtRow(int row);
        int GetIdAtRow(int row);

        // Управление обновлением UI
        void BeginUpdate();
        void EndUpdate();

        // Диалог редактирования/создания
        DialogResult ShowApplicationDialog(Forms.ApplicationForm form);

        // Операции с данными в представлении (Presenter вызывает эти методы)
        void SetRow(int row);
        void InsertApplicationAt(int index, Application app);
        void ReplaceApplicationAt(int index, Application app);
        void RemoveAt(int index);
        void RemoveApplicationsByIds(IList<int> ids);

        // Утилиты отображения
        void ShowMessage(string text, string caption = "");
    }
}