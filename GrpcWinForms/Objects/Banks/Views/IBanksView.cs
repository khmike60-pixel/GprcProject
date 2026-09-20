using GrpcCommonNet.Library.Bank;
using GrpcCommonNet.Library.Common;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace GrpcWinForms.Objects.Banks.Views
{
    public interface IBanksView
    {
        // Фильтр
        string ShortFilter { get; }

        // Коллекция, привязанная к гриду
        BindingList<Bank> Banks { get; set; }

        // Текущее положение/фиксированные строки грида (формат как в форме)
        int RowSel { get; }
        int RowsFixed { get; }

        // Выбранные строки (индексы)
        IList<int> SelectedRows { get; }

        // Доступ к объекту/данным в строке
        Bank GetBankAtRow(int row);
        int GetIdAtRow(int row);

        // Управление обновлением UI
        void BeginUpdate();
        void EndUpdate();

        // Диалог редактирования/создания
        DialogResult ShowBankDialog(Forms.BankForm form);

        // Операции с данными в представлении (Presenter вызывает эти методы)
        void SetRow(int row);
        void InsertBankAt(int index, Bank bank);
        void ReplaceBankAt(int index, Bank bank);
        void RemoveAt(int index);
        void RemoveBanksByIds(IList<int> ids);

        // Утилиты отображения
        void ShowMessage(string text, string caption = "");
    }
}