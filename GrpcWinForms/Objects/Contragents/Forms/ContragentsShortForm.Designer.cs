namespace GrpcWinForms.Objects.Contragents.Forms
{
    partial class ContragentsShortForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContragentsShortForm));
            C1.Win.FlexGrid.FooterDescription footerDescription2 = new C1.Win.FlexGrid.FooterDescription();
            C1.Win.FlexGrid.AggregateDefinition aggregateDefinition2 = new C1.Win.FlexGrid.AggregateDefinition();
            panel1 = new Panel();
            chkPrefix = new C1.Win.Input.C1CheckBox();
            textBoxPrefix = new TextBox();
            labelPrefix = new Label();
            comboBoxType = new ComboBox();
            labelType = new Label();
            textBoxTaxno = new TextBox();
            labelTaxno = new C1.Win.Input.C1Label();
            labelName = new Label();
            textBoxName = new TextBox();
            panel2 = new Panel();
            smartGrid1 = new SmartLib.SmartGrid(components);
            toolStrip1 = new ToolStrip();
            toolStripButtonNew = new ToolStripButton();
            toolStripButtonDouble = new ToolStripButton();
            toolStripButtonEdit = new ToolStripButton();
            toolStripButtonDelete = new ToolStripButton();
            toolStripButtonRefresh = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chkPrefix).BeginInit();
            ((System.ComponentModel.ISupportInitialize)labelTaxno).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)smartGrid1).BeginInit();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(chkPrefix);
            panel1.Controls.Add(textBoxPrefix);
            panel1.Controls.Add(labelPrefix);
            panel1.Controls.Add(comboBoxType);
            panel1.Controls.Add(labelType);
            panel1.Controls.Add(textBoxTaxno);
            panel1.Controls.Add(labelTaxno);
            panel1.Controls.Add(labelName);
            panel1.Controls.Add(textBoxName);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(663, 68);
            panel1.TabIndex = 5;
            // 
            // chkPrefix
            // 
            chkPrefix.AutoSize = true;
            chkPrefix.Location = new Point(495, 7);
            chkPrefix.Name = "chkPrefix";
            chkPrefix.Size = new Size(121, 19);
            chkPrefix.TabIndex = 11;
            chkPrefix.Text = "Префикс не пуст";
            // 
            // textBoxPrefix
            // 
            textBoxPrefix.Location = new Point(439, 5);
            textBoxPrefix.Name = "textBoxPrefix";
            textBoxPrefix.Size = new Size(50, 23);
            textBoxPrefix.TabIndex = 10;
            // 
            // labelPrefix
            // 
            labelPrefix.AutoSize = true;
            labelPrefix.Location = new Point(373, 9);
            labelPrefix.Name = "labelPrefix";
            labelPrefix.Size = new Size(60, 15);
            labelPrefix.TabIndex = 9;
            labelPrefix.Text = "Префикс:";
            // 
            // comboBoxType
            // 
            comboBoxType.FormattingEnabled = true;
            comboBoxType.Items.AddRange(new object[] { "Все", "ЮЛ", "ФЛ", "Неизв." });
            comboBoxType.Location = new Point(277, 5);
            comboBoxType.Name = "comboBoxType";
            comboBoxType.Size = new Size(90, 23);
            comboBoxType.TabIndex = 6;
            // 
            // labelType
            // 
            labelType.AutoSize = true;
            labelType.Location = new Point(222, 9);
            labelType.Name = "labelType";
            labelType.Size = new Size(30, 15);
            labelType.TabIndex = 5;
            labelType.Text = "Тип:";
            // 
            // textBoxTaxno
            // 
            textBoxTaxno.Location = new Point(116, 35);
            textBoxTaxno.Name = "textBoxTaxno";
            textBoxTaxno.Size = new Size(100, 23);
            textBoxTaxno.TabIndex = 4;
            // 
            // labelTaxno
            // 
            labelTaxno.AutoSize = true;
            labelTaxno.Location = new Point(31, 39);
            labelTaxno.Name = "labelTaxno";
            labelTaxno.Size = new Size(75, 21);
            labelTaxno.TabIndex = 3;
            labelTaxno.Text = "ИНН/ПИН:";
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Location = new Point(20, 9);
            labelName.Name = "labelName";
            labelName.Size = new Size(93, 15);
            labelName.TabIndex = 1;
            labelName.Text = "Наименование:";
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(116, 5);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(100, 23);
            textBoxName.TabIndex = 2;
            // 
            // panel2
            // 
            panel2.Controls.Add(smartGrid1);
            panel2.Controls.Add(toolStrip1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 68);
            panel2.Name = "panel2";
            panel2.Size = new Size(663, 382);
            panel2.TabIndex = 6;
            // 
            // smartGrid1
            // 
            smartGrid1.AllowEditing = false;
            smartGrid1.AllowMerging = C1.Win.FlexGrid.AllowMergingEnum.FixedOnly;
            smartGrid1.AllowMergingFixed = C1.Win.FlexGrid.AllowMergingEnum.FixedOnly;
            smartGrid1.AllowNodeMove = false;
            smartGrid1.AutoGenerateColumns = false;
            smartGrid1.ColumnInfo = resources.GetString("smartGrid1.ColumnInfo");
            smartGrid1.Dock = DockStyle.Fill;
            smartGrid1.DrawMode = C1.Win.FlexGrid.DrawModeEnum.OwnerDraw;
            aggregateDefinition2.Aggregate = C1.Win.FlexGrid.AggregateEnum.Count;
            aggregateDefinition2.Caption = "Всего: ";
            aggregateDefinition2.Column = 3;
            footerDescription2.Aggregates.Add(aggregateDefinition2);
            smartGrid1.Footers.Descriptions.Add(footerDescription2);
            smartGrid1.Footers.Fixed = true;
            smartGrid1.IdName = null;
            smartGrid1.Location = new Point(0, 31);
            smartGrid1.Name = "smartGrid1";
            smartGrid1.Rows.Count = 51;
            smartGrid1.SelectedRows = (List<int>)resources.GetObject("smartGrid1.SelectedRows");
            smartGrid1.SelectionMode = C1.Win.FlexGrid.SelectionModeEnum.Row;
            smartGrid1.Size = new Size(663, 351);
            smartGrid1.SortingType = SmartLib.SortingType.Descending;
            smartGrid1.StyleInfo = resources.GetString("smartGrid1.StyleInfo");
            smartGrid1.TabIndex = 7;
            smartGrid1.DoubleClick += smartGrid1_DoubleClick;
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(24, 24);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripButtonNew, toolStripButtonDouble, toolStripButtonEdit, toolStripButtonDelete, toolStripButtonRefresh, toolStripSeparator1 });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(663, 31);
            toolStrip1.TabIndex = 4;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonNew
            // 
            toolStripButtonNew.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButtonNew.Enabled = false;
            toolStripButtonNew.Image = Properties.Resources.icons8_документ_50;
            toolStripButtonNew.ImageTransparentColor = Color.Magenta;
            toolStripButtonNew.Name = "toolStripButtonNew";
            toolStripButtonNew.Size = new Size(28, 28);
            toolStripButtonNew.Text = "Новый";
            // 
            // toolStripButtonDouble
            // 
            toolStripButtonDouble.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButtonDouble.Enabled = false;
            toolStripButtonDouble.Image = Properties.Resources.icons8_скопировать_50;
            toolStripButtonDouble.ImageTransparentColor = Color.Magenta;
            toolStripButtonDouble.Name = "toolStripButtonDouble";
            toolStripButtonDouble.Size = new Size(28, 28);
            toolStripButtonDouble.Text = "Дублировать";
            // 
            // toolStripButtonEdit
            // 
            toolStripButtonEdit.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButtonEdit.Enabled = false;
            toolStripButtonEdit.Image = Properties.Resources.icons8_редактирование_файла_50;
            toolStripButtonEdit.ImageTransparentColor = Color.Magenta;
            toolStripButtonEdit.Name = "toolStripButtonEdit";
            toolStripButtonEdit.Size = new Size(28, 28);
            toolStripButtonEdit.Text = "Редактировать";
            // 
            // toolStripButtonDelete
            // 
            toolStripButtonDelete.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButtonDelete.Enabled = false;
            toolStripButtonDelete.Image = Properties.Resources.icons8_удалить_файл_50;
            toolStripButtonDelete.ImageTransparentColor = Color.Magenta;
            toolStripButtonDelete.Name = "toolStripButtonDelete";
            toolStripButtonDelete.Size = new Size(28, 28);
            toolStripButtonDelete.Text = "Удалить";
            // 
            // toolStripButtonRefresh
            // 
            toolStripButtonRefresh.Alignment = ToolStripItemAlignment.Right;
            toolStripButtonRefresh.Image = Properties.Resources.icons8_refresh_50;
            toolStripButtonRefresh.ImageTransparentColor = Color.Magenta;
            toolStripButtonRefresh.Name = "toolStripButtonRefresh";
            toolStripButtonRefresh.Size = new Size(89, 28);
            toolStripButtonRefresh.Text = "Обновить";
            toolStripButtonRefresh.Click += ContragentsShortForm_Load;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 31);
            // 
            // ContragentsShortForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(663, 450);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "ContragentsShortForm";
            Text = "Контрагенты (краткая форма)";
            Load += ContragentsShortForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)chkPrefix).EndInit();
            ((System.ComponentModel.ISupportInitialize)labelTaxno).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)smartGrid1).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TextBox textBoxPrefix;
        private Label labelPrefix;
        private ComboBox comboBoxType;
        private Label labelType;
        private TextBox textBoxTaxno;
        private C1.Win.Input.C1Label labelTaxno;
        private Label labelName;
        private TextBox textBoxName;
        private Panel panel2;
        private ToolStrip toolStrip1;
        private ToolStripButton toolStripButtonNew;
        private ToolStripButton toolStripButtonDouble;
        private ToolStripButton toolStripButtonEdit;
        private ToolStripButton toolStripButtonDelete;
        private ToolStripButton toolStripButtonRefresh;
        private ToolStripSeparator toolStripSeparator1;
        private SmartLib.SmartGrid smartGrid1;
        private C1.Win.Input.C1CheckBox chkPrefix;
    }
}