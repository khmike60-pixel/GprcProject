using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Library.Unit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrpcWinForms.Objects.Units.Forms
{
    public partial class UnitForm : Form
    {
        public bool IsTypeInsert { get; set; } = true;
        public Unit EditUnit { get; set; } = new Unit();

        public UnitForm()
        {
            InitializeComponent();

        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            EditUnit.Id = textBoxId.Text.Equals(String.Empty) ? 0 : Convert.ToInt32(textBoxId.Text);
            EditUnit.Short = textBoxShort.Text;
            EditUnit.Rem = textBoxRem.Text;
            EditUnit.RwsCode = textBoxRwsCode.Text;
            EditUnit.RwsMcode = textBoxRwsMcode.Text;
            EditUnit.Comment = textBoxComment.Text;
            EditUnit.Code = textBoxCode.Text;
            EditUnit.IsArchive = checkBoxIsArchive.Checked;

            this.DialogResult = DialogResult.OK;

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void UnitForm_Load(object sender, EventArgs e)
        {
            textBoxId.Text = EditUnit.Id.ToString();
            textBoxShort.Text = EditUnit.Short;
            textBoxRem.Text = EditUnit.Rem;
            textBoxRwsCode.Text = EditUnit.RwsCode;
            textBoxRwsMcode.Text = EditUnit.RwsMcode;
            textBoxComment.Text = EditUnit.Comment;
            textBoxCode.Text = EditUnit.Code;
            checkBoxIsArchive.Checked = EditUnit.IsArchive;
            this.Text += IsTypeInsert ? " (Добавление)" : " (Редактирование)";

        }
    }
}
