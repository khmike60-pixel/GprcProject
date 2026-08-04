using GrpcCommonNet.Library.Contract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrpcWinForms.Objects.Contracts.Forms.Controls
{
    public partial class ManagerControl : UserControl
    {
        private Contract _contract;
        public Contract Contract { get => _contract; set => _contract = value; }

        public ManagerControl()
        {
            InitializeComponent();
        }
        public ManagerControl(Contract contract)
        {
            InitializeComponent();
            _contract = contract;
        }

        public void SetControl(Contract cntr)
        {
            _contract = cntr;

            // Исполнитель
            empExecutor.Text = _contract.Executor == null? "" : _contract.Executor.Name;
            empExecutor.Value = _contract.Executor == null? 0 : _contract.Executor.Id;

            // Инициатор
            empInittiator.Text = _contract.Initiator == null? "" : _contract.Initiator.Name;
            empInittiator.Value = _contract.Initiator == null? 0 : _contract.Initiator.Id;

            // Менеджерский тип
            string[] projectTypes = new string[] { "стандарт", "проект", "распродажа" };
            cbProjectType.Items.Clear();
            cbProjectType.Items.AddRange(projectTypes);
            for (int i = 0; i < projectTypes.Length; i++)
            {
                if (projectTypes[i] == Contract.ManagerType)
                {
                    cbProjectType.SelectedIndex = i; break;
                }
            }

            // Описание
            tbComment.Text = Contract.Comment;



        }
    }
}
