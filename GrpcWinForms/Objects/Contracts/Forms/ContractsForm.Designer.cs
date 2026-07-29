namespace GrpcWinForms.Objects.Contracts.Forms
{
    partial class ContractsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContractsForm));
            C1.Win.FlexGrid.FooterDescription footerDescription1 = new C1.Win.FlexGrid.FooterDescription();
            C1.Win.FlexGrid.AggregateDefinition aggregateDefinition1 = new C1.Win.FlexGrid.AggregateDefinition();
            C1.Win.FlexGrid.AggregateDefinition aggregateDefinition2 = new C1.Win.FlexGrid.AggregateDefinition();
            C1.Win.FlexGrid.AggregateDefinition aggregateDefinition3 = new C1.Win.FlexGrid.AggregateDefinition();
            C1.Win.FlexGrid.AggregateDefinition aggregateDefinition4 = new C1.Win.FlexGrid.AggregateDefinition();
            C1.Win.FlexGrid.FooterDescription footerDescription2 = new C1.Win.FlexGrid.FooterDescription();
            C1.Win.FlexGrid.AggregateDefinition aggregateDefinition5 = new C1.Win.FlexGrid.AggregateDefinition();
            C1.Win.FlexGrid.AggregateDefinition aggregateDefinition6 = new C1.Win.FlexGrid.AggregateDefinition();
            C1.Win.FlexGrid.AggregateDefinition aggregateDefinition7 = new C1.Win.FlexGrid.AggregateDefinition();
            panel1 = new Panel();
            labelBuyer = new Label();
            companySeller = new GrpcWinForms.Objects.Contragents.Components.CompanyDropDown(components);
            companyBuyer = new GrpcWinForms.Objects.Contragents.Components.CompanyDropDown(components);
            c1ComboBox2 = new C1.Win.Input.C1ComboBox();
            labelCurrency = new Label();
            c1ComboBox1 = new C1.Win.Input.C1ComboBox();
            labelContractType = new Label();
            checkBoxAll = new CheckBox();
            periodContract = new C1.Win.Input.C1DropDownControl();
            labelPeriod = new Label();
            labelSeller = new Label();
            c1SplitContainer1 = new C1.Win.SplitContainer.C1SplitContainer();
            c1SplitterPanelContractLinesList = new C1.Win.SplitContainer.C1SplitterPanel();
            smartGridLines = new SmartGrid.SmartGrid();
            c1SplitterPanelContractList = new C1.Win.SplitContainer.C1SplitterPanel();
            smartGridContracts = new SmartGrid.SmartGrid();
            toolStrip1 = new ToolStrip();
            toolStripButtonNew = new ToolStripButton();
            toolStripButtonDouble = new ToolStripButton();
            toolStripButtonEdit = new ToolStripButton();
            toolStripButtonDelete = new ToolStripButton();
            toolStripButtonRefresh = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripButtonHistory = new ToolStripButton();
            toolStripButton1 = new ToolStripButton();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)companySeller).BeginInit();
            ((System.ComponentModel.ISupportInitialize)companyBuyer).BeginInit();
            ((System.ComponentModel.ISupportInitialize)c1ComboBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)c1ComboBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)periodContract).BeginInit();
            ((System.ComponentModel.ISupportInitialize)c1SplitContainer1).BeginInit();
            c1SplitContainer1.SuspendLayout();
            c1SplitterPanelContractLinesList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)smartGridLines).BeginInit();
            c1SplitterPanelContractList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)smartGridContracts).BeginInit();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(labelBuyer);
            panel1.Controls.Add(companySeller);
            panel1.Controls.Add(companyBuyer);
            panel1.Controls.Add(c1ComboBox2);
            panel1.Controls.Add(labelCurrency);
            panel1.Controls.Add(c1ComboBox1);
            panel1.Controls.Add(labelContractType);
            panel1.Controls.Add(checkBoxAll);
            panel1.Controls.Add(periodContract);
            panel1.Controls.Add(labelPeriod);
            panel1.Controls.Add(labelSeller);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1085, 93);
            panel1.TabIndex = 5;
            // 
            // labelBuyer
            // 
            labelBuyer.AutoSize = true;
            labelBuyer.Location = new Point(18, 10);
            labelBuyer.Name = "labelBuyer";
            labelBuyer.Size = new Size(75, 15);
            labelBuyer.TabIndex = 18;
            labelBuyer.Text = "Покупатель:";
            // 
            // companySeller
            // 
            companySeller.ButtonsSettings.CustomButton.Icon = new C1.Framework.C1BitmapIcon(null, new Size(16, 16), Color.Transparent, (Image)resources.GetObject("companySeller.ButtonsSettings.CustomButton.Icon"));
            companySeller.ButtonsSettings.CustomButton.Visible = true;
            companySeller.DropDownAlign = C1.Framework.DropDownAlignment.Left;
            companySeller.DropDownWidth = 300;
            companySeller.GetDataSourceFunc = null;
            companySeller.Location = new Point(99, 35);
            companySeller.Name = "companySeller";
            companySeller.Size = new Size(207, 23);
            companySeller.TabIndex = 17;
            companySeller.Value = "";
            // 
            // companyBuyer
            // 
            companyBuyer.ButtonsSettings.CustomButton.Icon = new C1.Framework.C1BitmapIcon(null, new Size(16, 16), Color.Transparent, (Image)resources.GetObject("companyBuyer.ButtonsSettings.CustomButton.Icon"));
            companyBuyer.ButtonsSettings.CustomButton.Visible = true;
            companyBuyer.DropDownAlign = C1.Framework.DropDownAlignment.Left;
            companyBuyer.DropDownWidth = 300;
            companyBuyer.GetDataSourceFunc = null;
            companyBuyer.Location = new Point(99, 6);
            companyBuyer.Name = "companyBuyer";
            companyBuyer.Size = new Size(207, 23);
            companyBuyer.TabIndex = 16;
            companyBuyer.Value = "";
            // 
            // c1ComboBox2
            // 
            c1ComboBox2.Location = new Point(406, 35);
            c1ComboBox2.Name = "c1ComboBox2";
            c1ComboBox2.Size = new Size(71, 23);
            c1ComboBox2.TabIndex = 15;
            // 
            // labelCurrency
            // 
            labelCurrency.AutoSize = true;
            labelCurrency.Location = new Point(349, 39);
            labelCurrency.Name = "labelCurrency";
            labelCurrency.Size = new Size(51, 15);
            labelCurrency.TabIndex = 14;
            labelCurrency.Text = "Валюта:";
            // 
            // c1ComboBox1
            // 
            c1ComboBox1.Location = new Point(406, 6);
            c1ComboBox1.Name = "c1ComboBox1";
            c1ComboBox1.Size = new Size(71, 23);
            c1ComboBox1.TabIndex = 13;
            // 
            // labelContractType
            // 
            labelContractType.AutoSize = true;
            labelContractType.Location = new Point(312, 10);
            labelContractType.Name = "labelContractType";
            labelContractType.Size = new Size(88, 15);
            labelContractType.TabIndex = 12;
            labelContractType.Text = "Тип контракта:";
            // 
            // checkBoxAll
            // 
            checkBoxAll.AutoSize = true;
            checkBoxAll.Location = new Point(274, 66);
            checkBoxAll.Name = "checkBoxAll";
            checkBoxAll.Size = new Size(45, 19);
            checkBoxAll.TabIndex = 7;
            checkBoxAll.Text = "Все";
            checkBoxAll.UseVisualStyleBackColor = true;
            // 
            // periodContract
            // 
            periodContract.Location = new Point(99, 64);
            periodContract.Name = "periodContract";
            periodContract.Size = new Size(169, 23);
            periodContract.TabIndex = 6;
            // 
            // labelPeriod
            // 
            labelPeriod.AutoSize = true;
            labelPeriod.Location = new Point(41, 68);
            labelPeriod.Name = "labelPeriod";
            labelPeriod.Size = new Size(52, 15);
            labelPeriod.TabIndex = 5;
            labelPeriod.Text = "Период:";
            // 
            // labelSeller
            // 
            labelSeller.AutoSize = true;
            labelSeller.Location = new Point(29, 39);
            labelSeller.Name = "labelSeller";
            labelSeller.Size = new Size(64, 15);
            labelSeller.TabIndex = 3;
            labelSeller.Text = "Продавец:";
            // 
            // c1SplitContainer1
            // 
            c1SplitContainer1.AutoSizeElement = C1.Framework.AutoSizeElement.Both;
            c1SplitContainer1.Dock = DockStyle.Fill;
            c1SplitContainer1.HeaderButtonBackColor = Color.Transparent;
            c1SplitContainer1.Location = new Point(0, 93);
            c1SplitContainer1.Name = "c1SplitContainer1";
            c1SplitContainer1.Panels.Add(c1SplitterPanelContractLinesList);
            c1SplitContainer1.Panels.Add(c1SplitterPanelContractList);
            c1SplitContainer1.Size = new Size(1085, 443);
            c1SplitContainer1.TabIndex = 6;
            // 
            // c1SplitterPanelContractLinesList
            // 
            c1SplitterPanelContractLinesList.Collapsible = true;
            c1SplitterPanelContractLinesList.Controls.Add(smartGridLines);
            c1SplitterPanelContractLinesList.Dock = C1.Win.SplitContainer.PanelDockStyle.Bottom;
            c1SplitterPanelContractLinesList.Height = 168;
            c1SplitterPanelContractLinesList.Location = new Point(0, 282);
            c1SplitterPanelContractLinesList.Name = "c1SplitterPanelContractLinesList";
            c1SplitterPanelContractLinesList.Size = new Size(1085, 161);
            c1SplitterPanelContractLinesList.SizeRatio = 38.363D;
            c1SplitterPanelContractLinesList.TabIndex = 0;
            // 
            // smartGridLines
            // 
            smartGridLines.AllowEditing = false;
            smartGridLines.AllowMergingFixed = C1.Win.FlexGrid.AllowMergingEnum.FixedOnly;
            smartGridLines.AllowNodeMove = false;
            smartGridLines.AutoGenerateColumns = false;
            smartGridLines.ColumnInfo = resources.GetString("smartGridLines.ColumnInfo");
            smartGridLines.Dock = DockStyle.Fill;
            smartGridLines.DrawMode = C1.Win.FlexGrid.DrawModeEnum.OwnerDraw;
            aggregateDefinition1.Aggregate = C1.Win.FlexGrid.AggregateEnum.Count;
            aggregateDefinition1.Caption = "Всего: ";
            aggregateDefinition1.Column = 2;
            aggregateDefinition2.Aggregate = C1.Win.FlexGrid.AggregateEnum.Sum;
            aggregateDefinition2.Column = 7;
            aggregateDefinition3.Aggregate = C1.Win.FlexGrid.AggregateEnum.Sum;
            aggregateDefinition3.Column = 9;
            aggregateDefinition4.Aggregate = C1.Win.FlexGrid.AggregateEnum.Sum;
            aggregateDefinition4.Column = 10;
            footerDescription1.Aggregates.Add(aggregateDefinition1);
            footerDescription1.Aggregates.Add(aggregateDefinition2);
            footerDescription1.Aggregates.Add(aggregateDefinition3);
            footerDescription1.Aggregates.Add(aggregateDefinition4);
            smartGridLines.Footers.Descriptions.Add(footerDescription1);
            smartGridLines.Footers.Fixed = true;
            smartGridLines.Headers = new string[]
    {
    "...\t№\tНаименование\tИКПУ\tЕд.изм.\tКол-во\tРеализация\tРеализация\tНДС\tНДС\tСумма с НДС",
    "...\t№\tНаименование\tИКПУ\tЕд.изм.\tКол-во\tЦена\tСумма\t%\tСумма\tСумма с НДС"
    };
            smartGridLines.IdName = null;
            smartGridLines.IsEditing = false;
            smartGridLines.Location = new Point(0, 0);
            smartGridLines.Name = "smartGridLines";
            smartGridLines.Rows.Count = 18;
            smartGridLines.Rows.Fixed = 2;
            smartGridLines.SelectedRows = (List<int>)resources.GetObject("smartGridLines.SelectedRows");
            smartGridLines.SelectionMode = C1.Win.FlexGrid.SelectionModeEnum.Row;
            smartGridLines.Size = new Size(1085, 161);
            smartGridLines.SortingType = SmartGrid.SortingType.Descending;
            smartGridLines.StyleInfo = resources.GetString("smartGridLines.StyleInfo");
            smartGridLines.TabIndex = 0;
            smartGridLines.GetUnboundValue += smartGridLines_GetUnboundValue;
            // 
            // c1SplitterPanelContractList
            // 
            c1SplitterPanelContractList.Controls.Add(smartGridContracts);
            c1SplitterPanelContractList.Controls.Add(toolStrip1);
            c1SplitterPanelContractList.Height = 271;
            c1SplitterPanelContractList.Location = new Point(0, 0);
            c1SplitterPanelContractList.Name = "c1SplitterPanelContractList";
            c1SplitterPanelContractList.Size = new Size(1085, 271);
            c1SplitterPanelContractList.TabIndex = 1;
            // 
            // smartGridContracts
            // 
            smartGridContracts.AllowEditing = false;
            smartGridContracts.AllowMergingFixed = C1.Win.FlexGrid.AllowMergingEnum.FixedOnly;
            smartGridContracts.AllowNodeMove = false;
            smartGridContracts.AllowSorting = C1.Win.FlexGrid.AllowSortingEnum.SingleColumn;
            smartGridContracts.AutoGenerateColumns = false;
            smartGridContracts.ColumnInfo = resources.GetString("smartGridContracts.ColumnInfo");
            smartGridContracts.Dock = DockStyle.Fill;
            smartGridContracts.DrawMode = C1.Win.FlexGrid.DrawModeEnum.OwnerDraw;
            aggregateDefinition5.Aggregate = C1.Win.FlexGrid.AggregateEnum.Count;
            aggregateDefinition5.Caption = "Всего: ";
            aggregateDefinition5.Column = 3;
            aggregateDefinition6.Aggregate = C1.Win.FlexGrid.AggregateEnum.Sum;
            aggregateDefinition6.Column = 9;
            aggregateDefinition7.Aggregate = C1.Win.FlexGrid.AggregateEnum.Sum;
            aggregateDefinition7.Column = 10;
            footerDescription2.Aggregates.Add(aggregateDefinition5);
            footerDescription2.Aggregates.Add(aggregateDefinition6);
            footerDescription2.Aggregates.Add(aggregateDefinition7);
            smartGridContracts.Footers.Descriptions.Add(footerDescription2);
            smartGridContracts.Footers.Fixed = true;
            smartGridContracts.Headers = new string[]
    {
    "...\tId\tКонтракт\tКонтракт\tКонтракт\tКонтракт\tКонтрагенты\tКонтрагенты\tТип\tОперации\tОперации\tДействует до",
    "...\tId\tДата\tНомер\tСумма\tСумма\tПокупатель\tПродавец\tТип\tОплачено\tОтгружено\tДействует до"
    };
            smartGridContracts.IdName = null;
            smartGridContracts.IsEditing = false;
            smartGridContracts.Location = new Point(0, 31);
            smartGridContracts.Name = "smartGridContracts";
            smartGridContracts.Rows.Count = 18;
            smartGridContracts.Rows.Fixed = 2;
            smartGridContracts.SelectedRows = (List<int>)resources.GetObject("smartGridContracts.SelectedRows");
            smartGridContracts.SelectionMode = C1.Win.FlexGrid.SelectionModeEnum.Row;
            smartGridContracts.Size = new Size(1085, 240);
            smartGridContracts.SortingType = SmartGrid.SortingType.Descending;
            smartGridContracts.StyleInfo = resources.GetString("smartGridContracts.StyleInfo");
            smartGridContracts.TabIndex = 5;
            smartGridContracts.UseCompatibleTextRendering = true;
            smartGridContracts.AfterSelChange += smartGridContracts_AfterSelChange;
            smartGridContracts.GetUnboundValue += smartGridContracts_GetUnboundValue;
            smartGridContracts.DoubleClick += smartGridContracts_DoubleClick;
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(24, 24);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripButtonNew, toolStripButtonDouble, toolStripButtonEdit, toolStripButtonDelete, toolStripButtonRefresh, toolStripSeparator1, toolStripButtonHistory, toolStripButton1 });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1085, 31);
            toolStrip1.TabIndex = 4;
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
            toolStripButtonNew.Click += toolStripButtonNew_Click;
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
            toolStripButtonEdit.Click += toolStripButtonEdit_Click;
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
            // toolStripButtonHistory
            // 
            toolStripButtonHistory.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButtonHistory.Image = Properties.Resources.icons8_order_history_32;
            toolStripButtonHistory.ImageTransparentColor = Color.Magenta;
            toolStripButtonHistory.Name = "toolStripButtonHistory";
            toolStripButtonHistory.Size = new Size(28, 28);
            toolStripButtonHistory.Text = "История";
            // 
            // toolStripButton1
            // 
            toolStripButton1.Checked = true;
            toolStripButton1.CheckOnClick = true;
            toolStripButton1.CheckState = CheckState.Checked;
            toolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton1.Image = Properties.Resources.icons8_add_column_32;
            toolStripButton1.ImageTransparentColor = Color.Magenta;
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Size = new Size(28, 28);
            toolStripButton1.Text = "toolStripButton1";
            // 
            // ContractsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1085, 536);
            Controls.Add(c1SplitContainer1);
            Controls.Add(panel1);
            MinimumSize = new Size(1015, 575);
            Name = "ContractsForm";
            Text = "Контракты";
            Load += ContractsForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)companySeller).EndInit();
            ((System.ComponentModel.ISupportInitialize)companyBuyer).EndInit();
            ((System.ComponentModel.ISupportInitialize)c1ComboBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)c1ComboBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)periodContract).EndInit();
            ((System.ComponentModel.ISupportInitialize)c1SplitContainer1).EndInit();
            c1SplitContainer1.ResumeLayout(false);
            c1SplitterPanelContractLinesList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)smartGridLines).EndInit();
            c1SplitterPanelContractList.ResumeLayout(false);
            c1SplitterPanelContractList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)smartGridContracts).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label labelSeller;
        private C1.Win.SplitContainer.C1SplitContainer c1SplitContainer1;
        private C1.Win.SplitContainer.C1SplitterPanel c1SplitterPanelContractLinesList;
        private C1.Win.SplitContainer.C1SplitterPanel c1SplitterPanelContractList;
        private SmartGrid.SmartGrid smartGridContracts;
        private ToolStrip toolStrip1;
        private ToolStripButton toolStripButtonNew;
        private ToolStripButton toolStripButtonDouble;
        private ToolStripButton toolStripButtonEdit;
        private ToolStripButton toolStripButtonDelete;
        private ToolStripButton toolStripButtonRefresh;
        private ToolStripSeparator toolStripSeparator1;
        private SmartGrid.SmartGrid smartGridLines;
        private CheckBox checkBoxAll;
        private C1.Win.Input.C1DropDownControl periodContract;
        private Label labelPeriod;
        private C1.Win.Input.C1ComboBox c1ComboBox1;
        private Label labelContractType;
        private C1.Win.Input.C1ComboBox c1ComboBox2;
        private Label labelCurrency;
        private ToolStripButton toolStripButtonHistory;
        private ToolStripButton toolStripButton1;
        private Label labelBuyer;
        private Contragents.Components.CompanyDropDown companySeller;
        private Contragents.Components.CompanyDropDown companyBuyer;
    }
}