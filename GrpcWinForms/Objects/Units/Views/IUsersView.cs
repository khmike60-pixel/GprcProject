using System.ComponentModel;
using GrpcCommonNet.Library.Common;

namespace GrpcWinForms.Objects.Units.Views
{
    public interface IUnitsView
    {
        string FilterName { get; }
        bool ShowAll { get; }

        BindingList<Unit> Units { get; set; }

        // Методы для обновления UI, которые Presenter может вызвать
        void SetUnitsSource(BindingList<Unit> units);
        void ShowMessage(string message);
        int GetCurrentRowSelRaw(); // raw smartGrid.RowSel
        int GetRowsFixed();
        IList<int> GetSelectedRows();
        void BeginGridUpdate();
        void EndGridUpdate();
        void SetSelectedRows(IList<int> rows);
        void RemoveAt(int index);
        void InsertAt(int index, Unit unit);
        void UpdateAt(int index, Unit unit);
    }
}