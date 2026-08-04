namespace GrpcWinForms.Objects.Contragents.Forms
{
    partial class ContragentsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContragentsForm));
            C1.Win.FlexGrid.FooterDescription footerDescription1 = new C1.Win.FlexGrid.FooterDescription();
            C1.Win.FlexGrid.AggregateDefinition aggregateDefinition1 = new C1.Win.FlexGrid.AggregateDefinition();
            contragentBindingSource = new BindingSource(components);
            toolStrip1 = new ToolStrip();
            toolStripButtonNew = new ToolStripButton();
            toolStripButtonDouble = new ToolStripButton();
            toolStripButtonEdit = new ToolStripButton();
            toolStripButtonDelete = new ToolStripButton();
            toolStripButtonRefresh = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            panel1 = new Panel();
            textBox1 = new TextBox();
            labelPrefix = new Label();
            comboBoxCountry = new ComboBox();
            label1Country = new Label();
            comboBoxType = new ComboBox();
            labelType = new Label();
            textBoxTaxno = new TextBox();
            labelTaxno = new C1.Win.Input.C1Label();
            labelName = new Label();
            textBoxName = new TextBox();
            smartGrid = new SmartGrid.SmartGrid();
            c1SplitContainer1 = new C1.Win.SplitContainer.C1SplitContainer();
            c1SplitterPanel2 = new C1.Win.SplitContainer.C1SplitterPanel();
            c1DockingTab1 = new C1.Win.Command.C1DockingTab();
            c1DockingTabPageEntity = new C1.Win.Command.C1DockingTabPage();
            entityControlMain = new EntityControl();
            c1DockingTabPagePerson = new C1.Win.Command.C1DockingTabPage();
            personControlMain = new PersonControl();
            c1DockingTabPageUnknow = new C1.Win.Command.C1DockingTabPage();
            unknowControl = new UnknowControl();
            c1SplitterPanel1 = new C1.Win.SplitContainer.C1SplitterPanel();
            ((System.ComponentModel.ISupportInitialize)contragentBindingSource).BeginInit();
            toolStrip1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)labelTaxno).BeginInit();
            ((System.ComponentModel.ISupportInitialize)smartGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)c1SplitContainer1).BeginInit();
            c1SplitContainer1.SuspendLayout();
            c1SplitterPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)c1DockingTab1).BeginInit();
            c1DockingTab1.SuspendLayout();
            c1DockingTabPageEntity.SuspendLayout();
            c1DockingTabPagePerson.SuspendLayout();
            c1DockingTabPageUnknow.SuspendLayout();
            c1SplitterPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // contragentBindingSource
            // 
            contragentBindingSource.DataSource = typeof(GrpcCommonNet.Library.Common.Contragent);
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(24, 24);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripButtonNew, toolStripButtonDouble, toolStripButtonEdit, toolStripButtonDelete, toolStripButtonRefresh, toolStripSeparator1 });
            toolStrip1.Location = new Point(0, 68);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1055, 31);
            toolStrip1.TabIndex = 3;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonNew
            // 
            toolStripButtonNew.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButtonNew.Image = Properties.Resources.icons8_документ_50;
            toolStripButtonNew.ImageTransparentColor = Color.Magenta;
            toolStripButtonNew.Name = "toolStripButtonNew";
            toolStripButtonNew.Size = new Size(28, 28);
            toolStripButtonNew.Text = "Новый";
            // 
            // toolStripButtonDouble
            // 
            toolStripButtonDouble.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButtonDouble.Image = Properties.Resources.icons8_скопировать_50;
            toolStripButtonDouble.ImageTransparentColor = Color.Magenta;
            toolStripButtonDouble.Name = "toolStripButtonDouble";
            toolStripButtonDouble.Size = new Size(28, 28);
            toolStripButtonDouble.Text = "Дублировать";
            // 
            // toolStripButtonEdit
            // 
            toolStripButtonEdit.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButtonEdit.Image = Properties.Resources.icons8_редактирование_файла_50;
            toolStripButtonEdit.ImageTransparentColor = Color.Magenta;
            toolStripButtonEdit.Name = "toolStripButtonEdit";
            toolStripButtonEdit.Size = new Size(28, 28);
            toolStripButtonEdit.Text = "Редактировать";
            // 
            // toolStripButtonDelete
            // 
            toolStripButtonDelete.DisplayStyle = ToolStripItemDisplayStyle.Image;
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
            toolStripButtonRefresh.Click += toolStripButtonRefresh_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 31);
            // 
            // panel1
            // 
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(labelPrefix);
            panel1.Controls.Add(comboBoxCountry);
            panel1.Controls.Add(label1Country);
            panel1.Controls.Add(comboBoxType);
            panel1.Controls.Add(labelType);
            panel1.Controls.Add(textBoxTaxno);
            panel1.Controls.Add(labelTaxno);
            panel1.Controls.Add(labelName);
            panel1.Controls.Add(textBoxName);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1055, 68);
            panel1.TabIndex = 4;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(439, 5);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(50, 23);
            textBox1.TabIndex = 10;
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
            // comboBoxCountry
            // 
            comboBoxCountry.FormattingEnabled = true;
            comboBoxCountry.Location = new Point(277, 35);
            comboBoxCountry.Name = "comboBoxCountry";
            comboBoxCountry.Size = new Size(90, 23);
            comboBoxCountry.TabIndex = 8;
            // 
            // label1Country
            // 
            label1Country.AutoSize = true;
            label1Country.Location = new Point(222, 39);
            label1Country.Name = "label1Country";
            label1Country.Size = new Size(49, 15);
            label1Country.TabIndex = 7;
            label1Country.Text = "Страна:";
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
            // smartGrid
            // 
            smartGrid.AllowMergingFixed = C1.Win.FlexGrid.AllowMergingEnum.FixedOnly;
            smartGrid.AllowNodeMove = false;
            smartGrid.AutoGenerateColumns = false;
            smartGrid.ColumnInfo = resources.GetString("smartGrid.ColumnInfo");
            smartGrid.DataSource = contragentBindingSource;
            smartGrid.Dock = DockStyle.Fill;
            smartGrid.DrawMode = C1.Win.FlexGrid.DrawModeEnum.OwnerDraw;
            aggregateDefinition1.Aggregate = C1.Win.FlexGrid.AggregateEnum.Count;
            aggregateDefinition1.Caption = "Всего: ";
            aggregateDefinition1.Column = 2;
            footerDescription1.Aggregates.Add(aggregateDefinition1);
            smartGrid.Footers.Descriptions.Add(footerDescription1);
            smartGrid.Footers.Fixed = true;
            smartGrid.Headers = new string[]
    {
    "...\tId\tНаименование\tИНН / ПИНФЛ\tТип\t?\tСтрана"
    };
            smartGrid.IdName = null;
            smartGrid.IsEditing = false;
            smartGrid.Location = new Point(0, 0);
            smartGrid.Name = "smartGrid";
            smartGrid.Rows.Count = 2;
            smartGrid.SelectedRows = (List<int>)resources.GetObject("smartGrid.SelectedRows");
            smartGrid.SelectionMode = C1.Win.FlexGrid.SelectionModeEnum.Row;
            smartGrid.Size = new Size(525, 493);
            smartGrid.SortingType = SmartGrid.SortingType.Descending;
            smartGrid.StyleInfo = resources.GetString("smartGrid.StyleInfo");
            smartGrid.TabIndex = 5;
            smartGrid.AfterResizeColumn += smartGrid_AfterResizeColumn;
            smartGrid.AfterSelChange += smartGrid_AfterSelChange;
            smartGrid.GetUnboundValue += smartGrid_GetUnboundValue;
            // 
            // c1SplitContainer1
            // 
            c1SplitContainer1.AutoSizeElement = C1.Framework.AutoSizeElement.Both;
            c1SplitContainer1.Dock = DockStyle.Fill;
            c1SplitContainer1.EnlargeCollapsingHandle = true;
            c1SplitContainer1.HeaderButtonBackColor = Color.Transparent;
            c1SplitContainer1.Location = new Point(0, 99);
            c1SplitContainer1.Name = "c1SplitContainer1";
            c1SplitContainer1.Panels.Add(c1SplitterPanel2);
            c1SplitContainer1.Panels.Add(c1SplitterPanel1);
            c1SplitContainer1.Size = new Size(1055, 493);
            c1SplitContainer1.TabIndex = 6;
            // 
            // c1SplitterPanel2
            // 
            c1SplitterPanel2.Collapsible = true;
            c1SplitterPanel2.Controls.Add(c1DockingTab1);
            c1SplitterPanel2.Dock = C1.Win.SplitContainer.PanelDockStyle.Right;
            c1SplitterPanel2.Height = 493;
            c1SplitterPanel2.Location = new Point(540, 0);
            c1SplitterPanel2.MinHeight = 493;
            c1SplitterPanel2.MinWidth = 524;
            c1SplitterPanel2.Name = "c1SplitterPanel2";
            c1SplitterPanel2.Size = new Size(515, 493);
            c1SplitterPanel2.TabIndex = 1;
            c1SplitterPanel2.Width = 526;
            // 
            // c1DockingTab1
            // 
            c1DockingTab1.Controls.Add(c1DockingTabPageEntity);
            c1DockingTab1.Controls.Add(c1DockingTabPagePerson);
            c1DockingTab1.Controls.Add(c1DockingTabPageUnknow);
            c1DockingTab1.Dock = DockStyle.Fill;
            c1DockingTab1.Location = new Point(0, 0);
            c1DockingTab1.MinimumSize = new Size(513, 493);
            c1DockingTab1.Name = "c1DockingTab1";
            c1DockingTab1.SelectedIndex = 2;
            c1DockingTab1.Size = new Size(515, 493);
            c1DockingTab1.TabIndex = 1;
            // 
            // c1DockingTabPageEntity
            // 
            c1DockingTabPageEntity.CaptionText = "Данные ЮЛ";
            c1DockingTabPageEntity.Controls.Add(entityControlMain);
            c1DockingTabPageEntity.Location = new Point(1, 27);
            c1DockingTabPageEntity.MinimumSize = new Size(511, 465);
            c1DockingTabPageEntity.Name = "c1DockingTabPageEntity";
            c1DockingTabPageEntity.Size = new Size(513, 465);
            c1DockingTabPageEntity.TabIndex = 0;
            c1DockingTabPageEntity.Text = "Данные ЮЛ";
            // 
            // entityControlMain
            // 
            entityControlMain.Dock = DockStyle.Top;
            entityControlMain.Location = new Point(0, 0);
            entityControlMain.MinimumSize = new Size(494, 461);
            entityControlMain.Name = "entityControlMain";
            entityControlMain.Size = new Size(513, 465);
            entityControlMain.TabIndex = 1;
            // 
            // c1DockingTabPagePerson
            // 
            c1DockingTabPagePerson.Controls.Add(personControlMain);
            c1DockingTabPagePerson.Location = new Point(1, 27);
            c1DockingTabPagePerson.Name = "c1DockingTabPagePerson";
            c1DockingTabPagePerson.Size = new Size(513, 465);
            c1DockingTabPagePerson.TabIndex = 1;
            c1DockingTabPagePerson.Text = "Данные ФЛ";
            // 
            // personControlMain
            // 
            personControlMain.Dock = DockStyle.Top;
            personControlMain.Location = new Point(0, 0);
            personControlMain.Name = "personControlMain";
            personControlMain.Size = new Size(513, 324);
            personControlMain.TabIndex = 0;
            // 
            // c1DockingTabPageUnknow
            // 
            c1DockingTabPageUnknow.Controls.Add(unknowControl);
            c1DockingTabPageUnknow.Location = new Point(1, 27);
            c1DockingTabPageUnknow.Name = "c1DockingTabPageUnknow";
            c1DockingTabPageUnknow.Size = new Size(513, 465);
            c1DockingTabPageUnknow.TabIndex = 2;
            c1DockingTabPageUnknow.Text = "Неизвестный контрагент";
            // 
            // unknowControl
            // 
            unknowControl.Dock = DockStyle.Top;
            unknowControl.Location = new Point(0, 0);
            unknowControl.Name = "unknowControl";
            unknowControl.Size = new Size(513, 324);
            unknowControl.TabIndex = 0;
            // 
            // c1SplitterPanel1
            // 
            c1SplitterPanel1.Collapsible = true;
            c1SplitterPanel1.Controls.Add(smartGrid);
            c1SplitterPanel1.Dock = C1.Win.SplitContainer.PanelDockStyle.Left;
            c1SplitterPanel1.Location = new Point(0, 0);
            c1SplitterPanel1.Name = "c1SplitterPanel1";
            c1SplitterPanel1.Size = new Size(525, 493);
            c1SplitterPanel1.TabIndex = 0;
            c1SplitterPanel1.Width = 525;
            // 
            // ContragentsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1055, 592);
            Controls.Add(c1SplitContainer1);
            Controls.Add(toolStrip1);
            Controls.Add(panel1);
            Name = "ContragentsForm";
            Text = "Контрагенты";
            Load += ContragentsForm_Load;
            ((System.ComponentModel.ISupportInitialize)contragentBindingSource).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)labelTaxno).EndInit();
            ((System.ComponentModel.ISupportInitialize)smartGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)c1SplitContainer1).EndInit();
            c1SplitContainer1.ResumeLayout(false);
            c1SplitterPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)c1DockingTab1).EndInit();
            c1DockingTab1.ResumeLayout(false);
            c1DockingTabPageEntity.ResumeLayout(false);
            c1DockingTabPagePerson.ResumeLayout(false);
            c1DockingTabPageUnknow.ResumeLayout(false);
            c1SplitterPanel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ToolStrip toolStrip1;
        private ToolStripButton toolStripButtonNew;
        private ToolStripButton toolStripButtonDouble;
        private ToolStripButton toolStripButtonEdit;
        private ToolStripButton toolStripButtonDelete;
        private ToolStripButton toolStripButtonRefresh;
        private ToolStripSeparator toolStripSeparator1;
        private Panel panel1;
        private C1.Win.Input.C1Label labelTaxno;
        private Label labelName;
        private TextBox textBoxName;
        private Label labelType;
        private TextBox textBoxTaxno;
        private ComboBox comboBoxType;
        private TextBox textBox1;
        private Label labelPrefix;
        private ComboBox comboBoxCountry;
        private Label label1Country;
        private BindingSource contragentBindingSource;
        private SmartGrid.SmartGrid smartGrid;
        private C1.Win.SplitContainer.C1SplitContainer c1SplitContainer1;
        private C1.Win.SplitContainer.C1SplitterPanel c1SplitterPanel1;
        private C1.Win.SplitContainer.C1SplitterPanel c1SplitterPanel2;
        private C1.Win.Command.C1DockingTab c1DockingTab1;
        private C1.Win.Command.C1DockingTabPage c1DockingTabPageEntity;
        private C1.Win.Command.C1DockingTabPage c1DockingTabPagePerson;
        private EntityControl entityControlMain;
        private PersonControl personControlMain;
        private C1.Win.Command.C1DockingTabPage c1DockingTabPageUnknow;
        private UnknowControl unknowControl;
    }
}