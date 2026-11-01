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
            C1.Win.FlexGrid.FooterDescription footerDescription2 = new C1.Win.FlexGrid.FooterDescription();
            C1.Win.FlexGrid.AggregateDefinition aggregateDefinition4 = new C1.Win.FlexGrid.AggregateDefinition();
            C1.Win.FlexGrid.AggregateDefinition aggregateDefinition5 = new C1.Win.FlexGrid.AggregateDefinition();
            C1.Win.FlexGrid.AggregateDefinition aggregateDefinition6 = new C1.Win.FlexGrid.AggregateDefinition();
            SmartLib.StringItem stringItem3 = new SmartLib.StringItem();
            SmartLib.StringItem stringItem4 = new SmartLib.StringItem();
            GrpcCommonNet.Library.Common.Contragent contragent3 = new GrpcCommonNet.Library.Common.Contragent();
            GrpcCommonNet.Library.Common.Contragent contragent1 = new GrpcCommonNet.Library.Common.Contragent();
            panel2 = new Panel();
            gridStockOperation = new SmartLib.SmartGrid(components);
            toolStrip1 = new ToolStrip();
            NewToolStripButton = new ToolStripButton();
            DoubleToolStripButton = new ToolStripButton();
            EditToolStripButton = new ToolStripButton();
            DeleteToolStripButton = new ToolStripButton();
            RefreshToolStripButton = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            panel1 = new Panel();
            lStockFrom = new C1.Win.Input.C1Label();
            tbPlaceTo = new TreeBox(components);
            tbPlaceFrom = new TreeBox(components);
            c1TextBox1 = new C1.Win.Input.C1TextBox();
            lNumber = new C1.Win.Input.C1Label();
            sbType = new SmartLib.Base.SmartBox.SmartBox(components);
            lType = new C1.Win.Input.C1Label();
            cddContragentFrom = new GrpcWinForms.Objects.Contragents.Components.CompanyDropDown(components);
            lContragentFrom = new C1.Win.Input.C1Label();
            lPlaceFrom = new Label();
            lContragentTo = new C1.Win.Input.C1Label();
            cddContragentTo = new GrpcWinForms.Objects.Contragents.Components.CompanyDropDown(components);
            periodBox = new SmartLib.PeriodBox(components);
            c1Label1 = new C1.Win.Input.C1Label();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridStockOperation).BeginInit();
            toolStrip1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)lStockFrom).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbPlaceTo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbPlaceFrom).BeginInit();
            ((System.ComponentModel.ISupportInitialize)c1TextBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lNumber).BeginInit();
            ((System.ComponentModel.ISupportInitialize)sbType).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lType).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cddContragentFrom).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lContragentFrom).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lContragentTo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cddContragentTo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)periodBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)c1Label1).BeginInit();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.Controls.Add(gridStockOperation);
            panel2.Controls.Add(toolStrip1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 104);
            panel2.Name = "panel2";
            panel2.Size = new Size(1111, 219);
            panel2.TabIndex = 3;
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
            aggregateDefinition4.Aggregate = C1.Win.FlexGrid.AggregateEnum.Count;
            aggregateDefinition4.Caption = "Всего: ";
            aggregateDefinition4.Column = 3;
            aggregateDefinition5.Aggregate = C1.Win.FlexGrid.AggregateEnum.Sum;
            aggregateDefinition5.Column = 10;
            aggregateDefinition6.Aggregate = C1.Win.FlexGrid.AggregateEnum.Sum;
            aggregateDefinition6.Column = 11;
            footerDescription2.Aggregates.Add(aggregateDefinition4);
            footerDescription2.Aggregates.Add(aggregateDefinition5);
            footerDescription2.Aggregates.Add(aggregateDefinition6);
            gridStockOperation.Footers.Descriptions.Add(footerDescription2);
            gridStockOperation.Footers.Fixed = true;
            stringItem3.Name = "Head2";
            stringItem3.Value = "...;Id;Статус;Номер;Дата;Тип;Грузоотправитель;Грузоотправитель;Грузополучатель;Грузополучатель;Сумма по документу;Сумма по документу;";
            stringItem4.Name = "Head1";
            stringItem4.Value = "...;Id;Статус;Номер;Дата;Тип;Контрагент;Склад;Контрагент;Склад;Приход;Расход;";
            gridStockOperation.Headers.Add(stringItem3);
            gridStockOperation.Headers.Add(stringItem4);
            gridStockOperation.IdName = null;
            gridStockOperation.Location = new Point(0, 31);
            gridStockOperation.Name = "gridStockOperation";
            gridStockOperation.Rows.Count = 5;
            gridStockOperation.Rows.Fixed = 2;
            gridStockOperation.SelectedRows = (List<int>)resources.GetObject("gridStockOperation.SelectedRows");
            gridStockOperation.SelectionMode = C1.Win.FlexGrid.SelectionModeEnum.Row;
            gridStockOperation.Size = new Size(1111, 188);
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
            toolStrip1.Size = new Size(1111, 31);
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
            panel1.Controls.Add(lStockFrom);
            panel1.Controls.Add(tbPlaceTo);
            panel1.Controls.Add(tbPlaceFrom);
            panel1.Controls.Add(c1TextBox1);
            panel1.Controls.Add(lNumber);
            panel1.Controls.Add(sbType);
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
            panel1.Size = new Size(1111, 104);
            panel1.TabIndex = 2;
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
            // sbType
            // 
            sbType.ButtonsSettings.ModalButton.Visible = true;
            sbType.Location = new Point(671, 10);
            sbType.Name = "sbType";
            sbType.Placeholder = "Тип  документа";
            sbType.Size = new Size(160, 23);
            sbType.TabIndex = 14;
            sbType.Value = "";
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
            contragent3.CountryId = 0;
            contragent3.CountrySymbol = "";
            contragent3.Entity = null;
            contragent3.Id = 0;
            contragent3.Name = "";
            contragent3.Person = null;
            contragent3.Prefix = "";
            contragent3.Taxno = "";
            contragent3.Type = GrpcCommonNet.Library.Common.ContragentType.Entity;
            cddContragentFrom.SelectedCompany = contragent3;
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
            contragent1.CountryId = 0;
            contragent1.CountrySymbol = "";
            contragent1.Entity = null;
            contragent1.Id = 0;
            contragent1.Name = "";
            contragent1.Person = null;
            contragent1.Prefix = "";
            contragent1.Taxno = "";
            contragent1.Type = GrpcCommonNet.Library.Common.ContragentType.Entity;
            cddContragentTo.SelectedCompany = contragent1;
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
            // StockDocumentsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1111, 323);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "StockDocumentsForm";
            Text = "Складские  документы";
            Load += StockDocumentsForm_Load;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridStockOperation).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)lStockFrom).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbPlaceTo).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbPlaceFrom).EndInit();
            ((System.ComponentModel.ISupportInitialize)c1TextBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)lNumber).EndInit();
            ((System.ComponentModel.ISupportInitialize)sbType).EndInit();
            ((System.ComponentModel.ISupportInitialize)lType).EndInit();
            ((System.ComponentModel.ISupportInitialize)cddContragentFrom).EndInit();
            ((System.ComponentModel.ISupportInitialize)lContragentFrom).EndInit();
            ((System.ComponentModel.ISupportInitialize)lContragentTo).EndInit();
            ((System.ComponentModel.ISupportInitialize)cddContragentTo).EndInit();
            ((System.ComponentModel.ISupportInitialize)periodBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)c1Label1).EndInit();
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
        private SmartLib.Base.SmartBox.SmartBox sbType;
        private C1.Win.Input.C1Label lType;
        private C1.Win.Input.C1TextBox c1TextBox1;
        private C1.Win.Input.C1Label lNumber;
        private TreeBox tbPlaceFrom;
        private C1.Win.Input.C1Label lStockFrom;
        private TreeBox tbPlaceTo;
    }
}