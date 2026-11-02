using GrpcWinForms.Controls.TreeBox;

namespace GrpcWinForms.Objects.StockDocuments.Views
{
    partial class StockDocumentsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StockDocumentsForm));
            C1.Win.FlexGrid.FooterDescription footerDescription1 = new C1.Win.FlexGrid.FooterDescription();
            C1.Win.FlexGrid.AggregateDefinition aggregateDefinition1 = new C1.Win.FlexGrid.AggregateDefinition();
            SmartLib.StringItem stringItem1 = new SmartLib.StringItem();
            SmartLib.StringItem stringItem2 = new SmartLib.StringItem();
            C1.Win.FlexGrid.FooterDescription footerDescription2 = new C1.Win.FlexGrid.FooterDescription();
            C1.Win.FlexGrid.AggregateDefinition aggregateDefinition2 = new C1.Win.FlexGrid.AggregateDefinition();
            C1.Win.FlexGrid.AggregateDefinition aggregateDefinition3 = new C1.Win.FlexGrid.AggregateDefinition();
            C1.Win.FlexGrid.AggregateDefinition aggregateDefinition4 = new C1.Win.FlexGrid.AggregateDefinition();
            SmartLib.StringItem stringItem3 = new SmartLib.StringItem();
            SmartLib.StringItem stringItem4 = new SmartLib.StringItem();
            GrpcCommonNet.Library.Common.Contragent contragent1 = new GrpcCommonNet.Library.Common.Contragent();
            GrpcCommonNet.Library.Common.Contragent contragent2 = new GrpcCommonNet.Library.Common.Contragent();
            panel2 = new Panel();
            c1SplitContainer1 = new C1.Win.SplitContainer.C1SplitContainer();
            c1SplitterPanel2 = new C1.Win.SplitContainer.C1SplitterPanel();
            smartGrid1 = new SmartLib.SmartGrid(components);
            toolStrip2 = new ToolStrip();
            c1SplitterPanel1 = new C1.Win.SplitContainer.C1SplitterPanel();
            gridStockOperation = new SmartLib.SmartGrid(components);
            toolStrip1 = new ToolStrip();
            NewToolStripButton = new ToolStripButton();
            DoubleToolStripButton = new ToolStripButton();
            EditToolStripButton = new ToolStripButton();
            DeleteToolStripButton = new ToolStripButton();
            RefreshToolStripButton = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            panel1 = new Panel();
            tbType = new TreeBox(components);
            lStockFrom = new C1.Win.Input.C1Label();
            tbPlaceTo = new TreeBox(components);
            tbPlaceFrom = new TreeBox(components);
            c1TextBox1 = new C1.Win.Input.C1TextBox();
            lNumber = new C1.Win.Input.C1Label();
            lType = new C1.Win.Input.C1Label();
            cddContragentFrom = new GrpcWinForms.Objects.Contragents.Components.CompanyDropDown(components);
            lContragentFrom = new C1.Win.Input.C1Label();
            lPlaceFrom = new Label();
            lContragentTo = new C1.Win.Input.C1Label();
            cddContragentTo = new GrpcWinForms.Objects.Contragents.Components.CompanyDropDown(components);
            periodBox = new SmartLib.PeriodBox(components);
            c1Label1 = new C1.Win.Input.C1Label();
            c1CommandHolder1 = new C1.Win.Command.C1CommandHolder();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)c1SplitContainer1).BeginInit();
            c1SplitContainer1.SuspendLayout();
            c1SplitterPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)smartGrid1).BeginInit();
            c1SplitterPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridStockOperation).BeginInit();
            toolStrip1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tbType).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lStockFrom).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbPlaceTo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbPlaceFrom).BeginInit();
            ((System.ComponentModel.ISupportInitialize)c1TextBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lNumber).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lType).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cddContragentFrom).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lContragentFrom).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lContragentTo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cddContragentTo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)periodBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)c1Label1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)c1CommandHolder1).BeginInit();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.Controls.Add(c1SplitContainer1);
            panel2.Controls.Add(toolStrip1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 104);
            panel2.Name = "panel2";
            panel2.Size = new Size(1101, 632);
            panel2.TabIndex = 3;
            // 
            // c1SplitContainer1
            // 
            c1SplitContainer1.AutoSizeElement = C1.Framework.AutoSizeElement.Both;
            c1SplitContainer1.Dock = DockStyle.Fill;
            c1SplitContainer1.HeaderButtonBackColor = Color.Transparent;
            c1SplitContainer1.Location = new Point(0, 31);
            c1SplitContainer1.Name = "c1SplitContainer1";
            c1SplitContainer1.Panels.Add(c1SplitterPanel2);
            c1SplitContainer1.Panels.Add(c1SplitterPanel1);
            c1SplitContainer1.Size = new Size(1101, 601);
            c1SplitContainer1.TabIndex = 4;
            // 
            // c1SplitterPanel2
            // 
            c1SplitterPanel2.Collapsible = true;
            c1SplitterPanel2.Controls.Add(smartGrid1);
            c1SplitterPanel2.Controls.Add(toolStrip2);
            c1SplitterPanel2.Dock = C1.Win.SplitContainer.PanelDockStyle.Bottom;
            c1SplitterPanel2.Height = 298;
            c1SplitterPanel2.Location = new Point(0, 331);
            c1SplitterPanel2.Name = "c1SplitterPanel2";
            c1SplitterPanel2.Size = new Size(1101, 270);
            c1SplitterPanel2.TabIndex = 1;
            c1SplitterPanel2.Text = "Товары";
            // 
            // smartGrid1
            // 
            smartGrid1.AllowMerging = C1.Win.FlexGrid.AllowMergingEnum.FixedOnly;
            smartGrid1.AllowMergingFixed = C1.Win.FlexGrid.AllowMergingEnum.FixedOnly;
            smartGrid1.AllowNodeMove = false;
            smartGrid1.AutoGenerateColumns = false;
            smartGrid1.ColumnInfo = resources.GetString("smartGrid1.ColumnInfo");
            smartGrid1.Dock = DockStyle.Fill;
            smartGrid1.DrawMode = C1.Win.FlexGrid.DrawModeEnum.OwnerDraw;
            aggregateDefinition1.Aggregate = C1.Win.FlexGrid.AggregateEnum.Count;
            aggregateDefinition1.Caption = "Всего: ";
            aggregateDefinition1.Column = 2;
            footerDescription1.Aggregates.Add(aggregateDefinition1);
            smartGrid1.Footers.Descriptions.Add(footerDescription1);
            smartGrid1.Footers.Fixed = true;
            stringItem1.Name = "Head1";
            stringItem1.Value = "....; Наименование; ИКПУ; Ед.изм.; Кол-во; Цена; Сумма; НДС; НДС; Сумма с НДС;";
            stringItem2.Name = "Head2";
            stringItem2.Value = "....; Наименование; ИКПУ; Ед.изм.; Кол-во; Цена; Сумма; %; Сумма; Сумма с НДС;";
            smartGrid1.Headers.Add(stringItem1);
            smartGrid1.Headers.Add(stringItem2);
            smartGrid1.IdName = null;
            smartGrid1.Location = new Point(0, 25);
            smartGrid1.Name = "smartGrid1";
            smartGrid1.Rows.Count = 5;
            smartGrid1.Rows.Fixed = 2;
            smartGrid1.SelectedRows = (List<int>)resources.GetObject("smartGrid1.SelectedRows");
            smartGrid1.SelectionMode = C1.Win.FlexGrid.SelectionModeEnum.Row;
            smartGrid1.Size = new Size(1101, 245);
            smartGrid1.SortingType = SmartLib.SortingType.Descending;
            smartGrid1.StyleInfo = resources.GetString("smartGrid1.StyleInfo");
            smartGrid1.TabIndex = 1;
            // 
            // toolStrip2
            // 
            toolStrip2.Location = new Point(0, 0);
            toolStrip2.Name = "toolStrip2";
            toolStrip2.Size = new Size(1101, 25);
            toolStrip2.TabIndex = 0;
            toolStrip2.Text = "toolStrip2";
            // 
            // c1SplitterPanel1
            // 
            c1SplitterPanel1.Controls.Add(gridStockOperation);
            c1SplitterPanel1.Dock = C1.Win.SplitContainer.PanelDockStyle.Bottom;
            c1SplitterPanel1.Height = 299;
            c1SplitterPanel1.Location = new Point(0, 21);
            c1SplitterPanel1.Name = "c1SplitterPanel1";
            c1SplitterPanel1.Size = new Size(1101, 278);
            c1SplitterPanel1.TabIndex = 0;
            c1SplitterPanel1.Text = "Складские документы";
            // 
            // gridStockOperation
            // 
            gridStockOperation.AllowEditing = false;
            gridStockOperation.AllowMerging = C1.Win.FlexGrid.AllowMergingEnum.FixedOnly;
            gridStockOperation.AllowMergingFixed = C1.Win.FlexGrid.AllowMergingEnum.FixedOnly;
            gridStockOperation.AllowNodeMove = false;
            gridStockOperation.AutoGenerateColumns = false;
            gridStockOperation.ColumnInfo = resources.GetString("gridStockOperation.ColumnInfo");
            gridStockOperation.Dock = DockStyle.Fill;
            gridStockOperation.DrawMode = C1.Win.FlexGrid.DrawModeEnum.OwnerDraw;
            aggregateDefinition2.Aggregate = C1.Win.FlexGrid.AggregateEnum.Count;
            aggregateDefinition2.Caption = "Всего: ";
            aggregateDefinition2.Column = 3;
            aggregateDefinition3.Aggregate = C1.Win.FlexGrid.AggregateEnum.Sum;
            aggregateDefinition3.Column = 10;
            aggregateDefinition4.Aggregate = C1.Win.FlexGrid.AggregateEnum.Sum;
            aggregateDefinition4.Column = 11;
            footerDescription2.Aggregates.Add(aggregateDefinition2);
            footerDescription2.Aggregates.Add(aggregateDefinition3);
            footerDescription2.Aggregates.Add(aggregateDefinition4);
            gridStockOperation.Footers.Descriptions.Add(footerDescription2);
            gridStockOperation.Footers.Fixed = true;
            stringItem3.Name = "Head2";
            stringItem3.Value = "...;Id;Статус;Номер;Дата;Тип;Грузоотправитель;Грузоотправитель;Грузополучатель;Грузополучатель;Сумма по документу;Сумма по документу;";
            stringItem4.Name = "Head1";
            stringItem4.Value = "...;Id;Статус;Номер;Дата;Тип;Контрагент;Склад;Контрагент;Склад;Приход;Расход;";
            gridStockOperation.Headers.Add(stringItem3);
            gridStockOperation.Headers.Add(stringItem4);
            gridStockOperation.IdName = null;
            gridStockOperation.Location = new Point(0, 0);
            gridStockOperation.Name = "gridStockOperation";
            gridStockOperation.Rows.Count = 5;
            gridStockOperation.Rows.Fixed = 2;
            gridStockOperation.SelectedRows = (List<int>)resources.GetObject("gridStockOperation.SelectedRows");
            gridStockOperation.SelectionMode = C1.Win.FlexGrid.SelectionModeEnum.Row;
            gridStockOperation.Size = new Size(1101, 278);
            gridStockOperation.SortingType = SmartLib.SortingType.Descending;
            gridStockOperation.StyleInfo = resources.GetString("gridStockOperation.StyleInfo");
            gridStockOperation.TabIndex = 3;
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(24, 24);
            toolStrip1.Items.AddRange(new ToolStripItem[] { NewToolStripButton, DoubleToolStripButton, EditToolStripButton, DeleteToolStripButton, RefreshToolStripButton, toolStripSeparator1 });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1101, 31);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // NewToolStripButton
            // 
            NewToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            NewToolStripButton.Image = Properties.Resources.icons8_документ_50;
            NewToolStripButton.ImageTransparentColor = Color.Magenta;
            NewToolStripButton.Name = "NewToolStripButton";
            NewToolStripButton.Size = new Size(28, 28);
            NewToolStripButton.Text = "Новый";
            // 
            // DoubleToolStripButton
            // 
            DoubleToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            DoubleToolStripButton.Enabled = false;
            DoubleToolStripButton.Image = Properties.Resources.icons8_скопировать_50;
            DoubleToolStripButton.ImageTransparentColor = Color.Magenta;
            DoubleToolStripButton.Name = "DoubleToolStripButton";
            DoubleToolStripButton.Size = new Size(28, 28);
            DoubleToolStripButton.Text = "Дублировать";
            // 
            // EditToolStripButton
            // 
            EditToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            EditToolStripButton.Image = Properties.Resources.icons8_редактирование_файла_50;
            EditToolStripButton.ImageTransparentColor = Color.Magenta;
            EditToolStripButton.Name = "EditToolStripButton";
            EditToolStripButton.Size = new Size(28, 28);
            EditToolStripButton.Text = "Редактировать";
            // 
            // DeleteToolStripButton
            // 
            DeleteToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            DeleteToolStripButton.Image = Properties.Resources.icons8_удалить_файл_50;
            DeleteToolStripButton.ImageTransparentColor = Color.Magenta;
            DeleteToolStripButton.Name = "DeleteToolStripButton";
            DeleteToolStripButton.Size = new Size(28, 28);
            DeleteToolStripButton.Text = "Удалить";
            // 
            // RefreshToolStripButton
            // 
            RefreshToolStripButton.Alignment = ToolStripItemAlignment.Right;
            RefreshToolStripButton.Image = Properties.Resources.icons8_refresh_50;
            RefreshToolStripButton.ImageTransparentColor = Color.Magenta;
            RefreshToolStripButton.Name = "RefreshToolStripButton";
            RefreshToolStripButton.Size = new Size(89, 28);
            RefreshToolStripButton.Text = "Обновить";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 31);
            // 
            // panel1
            // 
            panel1.Controls.Add(tbType);
            panel1.Controls.Add(lStockFrom);
            panel1.Controls.Add(tbPlaceTo);
            panel1.Controls.Add(tbPlaceFrom);
            panel1.Controls.Add(c1TextBox1);
            panel1.Controls.Add(lNumber);
            panel1.Controls.Add(lType);
            panel1.Controls.Add(cddContragentFrom);
            panel1.Controls.Add(lContragentFrom);
            panel1.Controls.Add(lPlaceFrom);
            panel1.Controls.Add(lContragentTo);
            panel1.Controls.Add(cddContragentTo);
            panel1.Controls.Add(periodBox);
            panel1.Controls.Add(c1Label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1101, 104);
            panel1.TabIndex = 2;
            // 
            // tbType
            // 
            tbType.Location = new Point(671, 9);
            tbType.Name = "tbType";
            tbType.Placeholder = "Тип складского документа";
            tbType.Size = new Size(200, 23);
            tbType.TabIndex = 15;
            tbType.Value = "";
            // 
            // lStockFrom
            // 
            lStockFrom.AutoSize = true;
            lStockFrom.Location = new Point(355, 72);
            lStockFrom.Name = "lStockFrom";
            lStockFrom.Size = new Size(65, 21);
            lStockFrom.TabIndex = 11;
            lStockFrom.Text = "На склад:";
            // 
            // tbPlaceTo
            // 
            tbPlaceTo.Location = new Point(427, 71);
            tbPlaceTo.Name = "tbPlaceTo";
            tbPlaceTo.Placeholder = "Склад / Место хранения";
            tbPlaceTo.Size = new Size(160, 23);
            tbPlaceTo.TabIndex = 12;
            tbPlaceTo.Value = "";
            // 
            // tbPlaceFrom
            // 
            tbPlaceFrom.Location = new Point(427, 40);
            tbPlaceFrom.Name = "tbPlaceFrom";
            tbPlaceFrom.Placeholder = "Склад / Место хранения";
            tbPlaceFrom.Size = new Size(160, 23);
            tbPlaceFrom.TabIndex = 10;
            tbPlaceFrom.Value = "";
            // 
            // c1TextBox1
            // 
            c1TextBox1.Location = new Point(427, 10);
            c1TextBox1.Name = "c1TextBox1";
            c1TextBox1.Placeholder = "Номер документа";
            c1TextBox1.Size = new Size(160, 23);
            c1TextBox1.TabIndex = 8;
            c1TextBox1.Value = "";
            // 
            // lNumber
            // 
            lNumber.AutoSize = true;
            lNumber.Location = new Point(341, 11);
            lNumber.Name = "lNumber";
            lNumber.Size = new Size(79, 21);
            lNumber.TabIndex = 7;
            lNumber.Text = "Номер док.:";
            // 
            // lType
            // 
            lType.AutoSize = true;
            lType.Location = new Point(604, 11);
            lType.Name = "lType";
            lType.Size = new Size(61, 21);
            lType.TabIndex = 13;
            lType.Text = "Тип док.:";
            // 
            // cddContragentFrom
            // 
            cddContragentFrom.ButtonsSettings.CustomButton.Icon = new C1.Framework.C1BitmapIcon(null, new Size(16, 16), Color.Transparent, (Image)resources.GetObject("cddContragentFrom.ButtonsSettings.CustomButton.Icon"));
            cddContragentFrom.ButtonsSettings.CustomButton.Visible = true;
            cddContragentFrom.DropDownAlign = C1.Framework.DropDownAlignment.Left;
            cddContragentFrom.DropDownWidth = 300;
            cddContragentFrom.GetDataSourceFunc = null;
            cddContragentFrom.Location = new Point(134, 40);
            cddContragentFrom.Name = "cddContragentFrom";
            cddContragentFrom.Placeholder = "Грузоотправитель";
            contragent1.CountryId = 0;
            contragent1.CountrySymbol = "";
            contragent1.Entity = null;
            contragent1.Id = 0;
            contragent1.Name = "";
            contragent1.Person = null;
            contragent1.Prefix = "";
            contragent1.Taxno = "";
            contragent1.Type = GrpcCommonNet.Library.Common.ContragentType.Entity;
            cddContragentFrom.SelectedCompany = contragent1;
            cddContragentFrom.Size = new Size(201, 23);
            cddContragentFrom.TabIndex = 4;
            cddContragentFrom.Value = "";
            // 
            // lContragentFrom
            // 
            lContragentFrom.AutoSize = true;
            lContragentFrom.Location = new Point(12, 41);
            lContragentFrom.Name = "lContragentFrom";
            lContragentFrom.Size = new Size(116, 21);
            lContragentFrom.TabIndex = 3;
            lContragentFrom.Text = "Грузоотправитель:";
            // 
            // lPlaceFrom
            // 
            lPlaceFrom.AutoSize = true;
            lPlaceFrom.Location = new Point(355, 44);
            lPlaceFrom.Name = "lPlaceFrom";
            lPlaceFrom.Size = new Size(65, 15);
            lPlaceFrom.TabIndex = 9;
            lPlaceFrom.Text = "Со cклада:";
            // 
            // lContragentTo
            // 
            lContragentTo.AutoSize = true;
            lContragentTo.Location = new Point(17, 72);
            lContragentTo.Name = "lContragentTo";
            lContragentTo.Size = new Size(111, 21);
            lContragentTo.TabIndex = 5;
            lContragentTo.Text = "Грузополучатель:";
            // 
            // cddContragentTo
            // 
            cddContragentTo.ButtonsSettings.CustomButton.Icon = new C1.Framework.C1BitmapIcon(null, new Size(16, 16), Color.Transparent, (Image)resources.GetObject("cddContragentTo.ButtonsSettings.CustomButton.Icon"));
            cddContragentTo.ButtonsSettings.CustomButton.Visible = true;
            cddContragentTo.DropDownAlign = C1.Framework.DropDownAlignment.Left;
            cddContragentTo.DropDownWidth = 300;
            cddContragentTo.GetDataSourceFunc = null;
            cddContragentTo.Location = new Point(134, 71);
            cddContragentTo.Name = "cddContragentTo";
            cddContragentTo.Placeholder = "Грузополучатель";
            contragent2.CountryId = 0;
            contragent2.CountrySymbol = "";
            contragent2.Entity = null;
            contragent2.Id = 0;
            contragent2.Name = "";
            contragent2.Person = null;
            contragent2.Prefix = "";
            contragent2.Taxno = "";
            contragent2.Type = GrpcCommonNet.Library.Common.ContragentType.Entity;
            cddContragentTo.SelectedCompany = contragent2;
            cddContragentTo.Size = new Size(201, 23);
            cddContragentTo.TabIndex = 6;
            cddContragentTo.Value = "";
            // 
            // periodBox
            // 
            periodBox.Location = new Point(134, 9);
            periodBox.Name = "periodBox";
            periodBox.Period.From = new DateTime(2026, 1, 1, 0, 0, 0, 0);
            periodBox.Period.To = new DateTime(2026, 12, 31, 23, 59, 59, 0);
            periodBox.TabIndex = 16;
            // 
            // c1Label1
            // 
            c1Label1.AutoSize = true;
            c1Label1.Location = new Point(70, 11);
            c1Label1.Name = "c1Label1";
            c1Label1.Size = new Size(58, 21);
            c1Label1.TabIndex = 1;
            c1Label1.Text = "Период:";
            // 
            // c1CommandHolder1
            // 
            c1CommandHolder1.Owner = this;
            // 
            // StockDocumentsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1101, 736);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "StockDocumentsForm";
            Text = "Складские  документы";
            Load += StockDocumentsForm_Load;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)c1SplitContainer1).EndInit();
            c1SplitContainer1.ResumeLayout(false);
            c1SplitterPanel2.ResumeLayout(false);
            c1SplitterPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)smartGrid1).EndInit();
            c1SplitterPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridStockOperation).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tbType).EndInit();
            ((System.ComponentModel.ISupportInitialize)lStockFrom).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbPlaceTo).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbPlaceFrom).EndInit();
            ((System.ComponentModel.ISupportInitialize)c1TextBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)lNumber).EndInit();
            ((System.ComponentModel.ISupportInitialize)lType).EndInit();
            ((System.ComponentModel.ISupportInitialize)cddContragentFrom).EndInit();
            ((System.ComponentModel.ISupportInitialize)lContragentFrom).EndInit();
            ((System.ComponentModel.ISupportInitialize)lContragentTo).EndInit();
            ((System.ComponentModel.ISupportInitialize)cddContragentTo).EndInit();
            ((System.ComponentModel.ISupportInitialize)periodBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)c1Label1).EndInit();
            ((System.ComponentModel.ISupportInitialize)c1CommandHolder1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel2;
        private SmartLib.SmartGrid gridStockOperation;
        private ToolStrip toolStrip1;
        private ToolStripButton NewToolStripButton;
        private ToolStripButton DoubleToolStripButton;
        private ToolStripButton EditToolStripButton;
        private ToolStripButton DeleteToolStripButton;
        private ToolStripButton RefreshToolStripButton;
        private ToolStripSeparator toolStripSeparator1;
        private Panel panel1;
        private C1.Win.Input.C1Label c1Label1;
        private SmartLib.PeriodBox periodBox;
        private Label lPlaceFrom;
        private C1.Win.Input.C1Label lContragentTo;
        private Contragents.Components.CompanyDropDown cddContragentTo;
        private Contragents.Components.CompanyDropDown cddContragentFrom;
        private C1.Win.Input.C1Label lContragentFrom;
        private C1.Win.Input.C1Label lType;
        private C1.Win.Input.C1TextBox c1TextBox1;
        private C1.Win.Input.C1Label lNumber;
        private TreeBox tbPlaceFrom;
        private C1.Win.Input.C1Label lStockFrom;
        private TreeBox tbPlaceTo;
        private TreeBox tbType;
        private C1.Win.SplitContainer.C1SplitContainer c1SplitContainer1;
        private C1.Win.SplitContainer.C1SplitterPanel c1SplitterPanel1;
        private C1.Win.SplitContainer.C1SplitterPanel c1SplitterPanel2;
        private SmartLib.SmartGrid smartGrid1;
        private ToolStrip toolStrip2;
        private C1.Win.Command.C1CommandHolder c1CommandHolder1;
    }
}