using C1.Win.Input;
using GrpcCommonNet.Library.Common;
using GrpcWinForms.Objects.Test;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcWinForms.Objects.Contragents.Components
{
    public partial class CompanyDropDown : C1DropDownControl
    {
        private Company selectedItem = new Company();
        public Company SelectedItem {  get { return selectedItem; } }

        // Делегат: принимает string (вход), возвращает BindingList<Company> (выход)
        private Func<string, BindingList<Company>>? _getDataSourceFunc;
        public Func<string, BindingList<Company>>? GetDataSourceFunc
        {
            get => _getDataSourceFunc;
            set
            {
                _getDataSourceFunc = value;
                // Если делегат установлен и Control инициализирован — обновляем данные
                if (_getDataSourceFunc != null && this.Control != null)
                {
                    try
                    {
                        SmartGrid.SmartGrid grid = ((CompanyDropDownForm)Control).smart;

                        grid.DataSource = UpdateGridData(this.Text ?? string.Empty);
                    }
                    catch
                    {
                        // Игнорируем ошибки инициализации Control в редких сценариях
                    }
                }
            }
        }

        // Метод внутри компонента, который запрашивает данные
        private BindingList<Company> UpdateGridData(string filterText)
        {
            BindingList<Company> result = new BindingList<Company>();
            SmartGrid.SmartGrid grid = ((CompanyDropDownForm)Control).smart;
            CompanyDropDownForm userControl = ((CompanyDropDownForm)Control);

            if (GetDataSourceFunc != null)
            {
                // Вызываем метод в форме и сразу получаем результат
                result = GetDataSourceFunc.Invoke(filterText);
                userControl.Contragents = result;
                // Передаем полученный список в ваш DropDownForm
                // grid.DataSource = result;
            }
            return result;
        }

        public CompanyDropDown()
        {
            InitializeComponent();
            UpdateGridData("");
        }

        public CompanyDropDown(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            UpdateGridData("");
        }


        private void CompanyDropDown_TextChanged(object sender, EventArgs e)
        {
            SmartGrid.SmartGrid grid = ((CompanyDropDownForm)Control).smart;
            grid.DataSource = UpdateGridData(Text);
        }


        private void CompanyDropDown_CustomButtonClick(object sender, EventArgs e)
        {
            Text = "";
            selectedItem = new Company();
        }

        private void CompanyDropDown_Leave(object sender, EventArgs e)
        {
            CompanyDropDownForm userControl = ((CompanyDropDownForm)Control);
            
            if (Text == "") return;
            if (userControl.ContragentSelected == null || userControl.ContragentSelected.Id != 0)
            {
                BindingList<Company> _contragents = UpdateGridData(Text);
                if (_contragents.Count == 1)
                {
                    userControl.ContragentSelected = _contragents[0];
                    selectedItem = _contragents[0];
                    Text = selectedItem.Name;
                    return;
                }
            }
            MessageBox.Show(this, "Такой контрагент не найден!");
            Focus();
        }

        private void CompanyDropDown_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Если нажата клавиша Enter
            if (e.KeyChar == (char)Keys.Enter)
            {
                Control parent = this.Parent;
                bool isForm = false;
                while (parent.GetType().BaseType.Name.ToString() != "Form")
                    parent = parent.Parent;

                Form form = (Form)parent;
                this.SelectNextControl(form.ActiveControl, forward: true,
                       tabStopOnly: true, nested: true, wrap: true);

            }

        }

    }

}
