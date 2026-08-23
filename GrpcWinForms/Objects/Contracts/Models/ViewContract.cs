using GrpcCommonNet.Library.Contract;
using GrpcWinForms.Forms;
using GrpcWinForms.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contract = GrpcCommonNet.Library.Contract.Contract;

namespace GrpcWinForms.Objects.Contracts.Models
{
    public class ViewContract
    {
        private Contract contract;
        private Form mainForm = new Form();
        private bool currentMode = false;
        
        public ViewContract() { }
        
        public ViewContract(Contract _contract, bool CurrentMode = false) 
        { 
            contract = _contract;
            currentMode = CurrentMode;
            foreach(Form form in Application.OpenForms)
            {
                if (form.Name == "MainForm")
                {
                    mainForm = form;
                    break;
                }
            }
        }

        public void Show()
        {
            string nameSpace = "GrpcWinForms.Objects.Contracts.Forms.ContractViews";
            string nameForm = "ContractSaleStandartForm";
            string fullTypeContract = $"{nameSpace}.{nameForm}";
            try
            {
                int contractId = contract.Id;
                var contractType_Name = contract.TypeContract?.Name;
                var contractType_Code = contract.TypeContract?.Code;
                var contractType_Form = contract.TypeContract?.Form;
                fullTypeContract = $"{nameSpace}.{contractType_Form}";
                string contractType = fullTypeContract;

                // Попытка получить Type по строке имени
                System.Type formType = System.Type.GetType(contractType);

                // Локальная функция: читать ContractId с РЕАЛЬНОГО типа через рефлексию, fallback на базовое свойство
                int? GetContractIdFrom(Form f)
                {
                    var prop = f.GetType().GetProperty("ContractId", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
                    if (prop != null && prop.PropertyType == typeof(int))
                    {
                        try
                        {
                            return (int)prop.GetValue(f);
                        }
                        catch
                        {
                            return null;
                        }
                    }

                    if (f is ContractFormClass baseForm)
                        return baseForm.ContractId;

                    return null;
                }

                // Если Type найден — проверим, есть ли уже открыт экземпляр того же типа с таким ContractId,
                // читая значение ContractId именно с реального типа экземпляра.
                if (formType != null)
                {
                    foreach (var child in mainForm.MdiChildren)
                    {
                        if (child.GetType() != formType) continue;

                        int? existingId = GetContractIdFrom(child);
                        if (existingId.HasValue && existingId.Value == contractId)
                        {
                            child.Activate();
                            return;
                        }
                    }
                }

                // Создаём форму и передаём contractId фабрике
                var form = Utils.CreateForm(contractType, contractId);
                if (form == null) return;

                // Ещё одна проверка — на случай, если Type не резолвился ранее; читаем ContractId с реального типа
                foreach (Form child in mainForm.MdiChildren)
                {
                    if (child.GetType() != form.GetType()) continue;

                    int? existingId = GetContractIdFrom(child);
                    if (existingId.HasValue && existingId.Value == contractId)
                    {
                        child.Activate();
                        form.Dispose();
                        return;
                    }
                }

                form.MdiParent = mainForm;
                if (currentMode)
                {
                    form.Text = $"Контракт № {contract.Number} от {contract.Date.ToDateTime().ToShortDateString() + " текущее состояние"} (Id={contract.Id})";
                }
                else
                    if (contract.RootId == 0)
                    form.Text = $"Первичный контракт № {contract.Number} от {contract.Date.ToDateTime().ToShortDateString()} (Id={contract.Id})";
                else
                    form.Text = $"Допсоглашение № {contract.Number} от {contract.Date.ToDateTime().ToShortDateString()} (Id={contract.Id})";

                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
