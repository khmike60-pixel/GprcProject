using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Library.Department;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace GrpcWinForms.Objects.Departaments.Views
{
    public interface IDepartamentsView
    {
        // События (нюанс: форма может напрямую вызывать методы презентера,
        // но оставляем события для гибкости)
        event EventHandler LoadView;

        // Свойства для доступа к данным/фильтрам
        string ShortFilter { get; }

        // Режим диалога (выбор элемента)
        bool DialogMode { get; set; }

        // Коллекция, отображаемая в гриде
        BindingList<Department> Departments { set; }

        // Получение/установка выбранного элемента
        Department SelectedItem { get; set; }

        // Индексы/выбранные строки грида
        int RowSel { get; }
        IList<int> SelectedRows { get; }

        // Методы для управления UI из презентера
        void InsertDepartmentAt(int index, Department department);
        void RemoveDepartmentAt(int index);
        void ReplaceDepartmentAt(int index, Department department);
        void BeginUpdate();
        void EndUpdate();
        void ShowMessage(string message);
        void CloseWithOk();
    }
}