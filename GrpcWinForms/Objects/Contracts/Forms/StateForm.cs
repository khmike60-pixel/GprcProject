using C1.Win.Input;
using GrpcCommonNet.Library.Contract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrpcWinForms.Objects.Contracts.Forms
{
    public partial class StateForm : Form
    {
        private Contract contract = new Contract();
        public Contract Contract { get => contract; set => contract = value; }
        
        public StateForm()
        {
            InitializeComponent();
        }

        private void chkBox_CheckedChanged(object sender, EventArgs e)
        {
            C1CheckBox checkBox = sender as C1CheckBox;

            switch (checkBox.Name)
            {
                case "chkComplited":
                    if (chkComplited.Checked)
                    {
                        chkSentToClient.Checked = true;
                        chkSigned.Checked = true;
                        chkActived.Checked = true;

                        contract.State = ContractState.Complited;
                    }
                    else
                        contract.State = ContractState.Active;
                    break;
                case "chkActived":
                    if (chkActived.Checked)
                    {
                        chkSentToClient.Checked = true;
                        chkSigned.Checked = true;

                        if (chkComplited.Checked) contract.State = ContractState.Complited;
                        else
                            contract.State = ContractState.Active;
                    }
                    else
                    {
                        chkComplited.Checked = false;

                        contract.State = ContractState.Signed;
                    }
                    break;
                case "chkSigned":
                    if (chkSigned.Checked)
                    {
                        chkSentToClient.Checked = true;

                        if (chkComplited.Checked) contract.State = ContractState.Complited;
                        else if (chkActived.Checked) contract.State = ContractState.Active;
                        else
                            contract.State = ContractState.Signed;


                    }
                    else
                    {

                        chkSigned.Checked = false;
                        chkActived.Checked = false;
                        contract.State = ContractState.SentToClient;
                    }
                    break;
                case "chkSentToClient":
                    if (chkSentToClient.Checked)
                    {
                        if (chkComplited.Checked) contract.State = ContractState.Complited;
                        else if (chkActived.Checked) contract.State = ContractState.Active;
                        else if (chkSigned.Checked) contract.State = ContractState.Signed;
                        else
                            contract.State = ContractState.SentToClient;
                    }
                    else
                    {
                        chkSentToClient.Checked = false;
                        chkSigned.Checked = false;
                        chkActived.Checked = false;

                        contract.State = ContractState.Draft;
                    }
                    break;
                default:
                    contract.State = ContractState.Draft;
                    break;
            }

        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Статус документа: {contract.State}");
        }

        private void StateForm_Load(object sender, EventArgs e)
        {
            txDocName.Text = contract.DocName.ToString();
            tbNumber.Text = contract.Number.ToString();
            cdtDate.Value = contract.Date;
        }
    }
}
