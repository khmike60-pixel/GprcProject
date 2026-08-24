using GrpcCommonNet.Library.Contract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrpcWinForms.Objects.Contracts.Models
{
    public partial class ContractFormClass : Form
    {
        //private int _contractId;

        private Contract contract;

        public Contract Contract { get => contract; set => contract = value; }

        // Событие для передачи изменённого контракта
        public event EventHandler<Contract> ContractChanged;

        //public int ContractId
        //{
        //    get => _contractId;
        //    set => _contractId = value;
        //}

        public ContractFormClass()
        {
            InitializeComponent();
        }

        // Шаблон для безопасного поднятия события в производных классах
        protected virtual void OnContractChanged(Contract contract)
        {
            ContractChanged?.Invoke(this, contract);
        }
    }
}
