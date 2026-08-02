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
        private int _contractId;
        public int ContractId
        {
            get => _contractId;
            set => _contractId = value;
        }

        public ContractFormClass()
        {
            InitializeComponent();

        }

    }

}
