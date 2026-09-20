using GrpcCommonNet.Library.Common;
using GrpcWinForms.Objects.Units.Presenters;
using GrpcWinForms.Objects.Units.Views;
using System;
using System.Windows.Forms;

namespace GrpcWinForms.Objects.Units.Forms
{
    public partial class UnitForm : Form, IUnitView
    {
        private readonly UnitPresenter _presenter;

        public bool IsTypeInsert { get; set; } = true;
        public Unit EditUnit { get; set; } = new Unit();

        public UnitForm()
        {
            InitializeComponent();
            _presenter = new UnitPresenter(this);
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            _presenter.OnOk();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            _presenter.OnCancel();
        }

        private void UnitForm_Load(object sender, EventArgs e)
        {
            _presenter.OnLoad();
        }

        // IUnitView реализация — основана на существующих полях формы (textBoxId, textBoxShort, ...)
        public string IdText => textBoxId.Text;
        public string ShortText => textBoxShort.Text;
        public string RemText => textBoxRem.Text;
        public string RwsCodeText => textBoxRwsCode.Text;
        public string RwsMcodeText => textBoxRwsMcode.Text;
        public string CommentText => textBoxComment.Text;
        public string CodeText => textBoxCode.Text;
        public bool IsArchiveChecked => checkBoxIsArchive.Checked;

        public void SetFieldsFromUnit(Unit unit)
        {
            if (unit == null) unit = new Unit();
            textBoxId.Text = unit.Id.ToString();
            textBoxShort.Text = unit.Short;
            textBoxRem.Text = unit.Rem;
            textBoxRwsCode.Text = unit.RwsCode;
            textBoxRwsMcode.Text = unit.RwsMcode;
            textBoxComment.Text = unit.Comment;
            textBoxCode.Text = unit.Code;
            checkBoxIsArchive.Checked = unit.IsArchive;
        }

        public void CloseWithResult(DialogResult result)
        {
            this.DialogResult = result;
            if (result == DialogResult.Cancel) this.Close();
            // для OK хозяин формы (UnitsForm) может прочитать EditUnit
        }

        public void AppendTitle(string suffix)
        {
            this.Text += suffix;
        }
    }
}