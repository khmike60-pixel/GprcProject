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
            C1.Win.FlexGrid.AggregateDefinition aggregateDefinition2 = new C1.Win.FlexGrid.AggregateDefinition();
            C1.Win.FlexGrid.AggregateDefinition aggregateDefinition3 = new C1.Win.FlexGrid.AggregateDefinition();
            SmartLib.StringItem stringItem1 = new SmartLib.StringItem();
            SmartLib.StringItem stringItem2 = new SmartLib.StringItem();
            GrpcCommonNet.Library.Common.Contragent contragent2 = new GrpcCommonNet.Library.Common.Contragent();
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
            periodBox = new SmartLib.PeriodBox(components);
            c1Label1 = new C1.Win.Input.C1Label();
            cddContragentTo = new GrpcWinForms.Objects.Contragents.Components.CompanyDropDown(components);
            lContragentTo = new C1.Win.Input.C1Label();
            label1 = new Label();
            sbStock = new SmartLib.Base.SmartBox.SmartBox(components);
            lContragentFrom = new C1.Win.Input.C1Label();
            cddContragentFrom = new GrpcWinForms.Objects.Contragents.Components.CompanyDropDown(components);
            lType = new C1.Win.Input.C1Label();
            sbType = new SmartLib.Base.SmartBox.SmartBox(components);
            lNumber = new C1.Win.Input.C1Label();
            c1TextBox1 = new C1.Win.Input.C1TextBox();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridStockOperation).BeginInit();
            toolStrip1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)periodBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)c1Label1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cddContragentTo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lContragentTo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)sbStock).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lContragentFrom).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cddContragentFrom).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lType).BeginInit();
            ((System.ComponentModel.ISupportInitialize)sbType).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lNumber).BeginInit();
            ((System.ComponentModel.ISupportInitialize)c1TextBox1).BeginInit();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.Controls.Add(gridStockOperation);
            panel2.Controls.Add(toolStrip1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 104);
            panel2.Name = "panel2";
            panel2.Size = new Size(1045, 399);
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
            aggregateDefinition1.Aggregate = C1.Win.FlexGrid.AggregateEnum.Count;
            aggregateDefinition1.Caption = "Всего: ";
            aggregateDefinition1.Column = 3;
            aggregateDefinition2.Aggregate = C1.Win.FlexGrid.AggregateEnum.Sum;
            aggregateDefinition2.Column = 10;
            aggregateDefinition3.Aggregate = C1.Win.FlexGrid.AggregateEnum.Sum;
            aggregateDefinition3.Column = 11;
            footerDescription1.Aggregates.Add(aggregateDefinition1);
            footerDescription1.Aggregates.Add(aggregateDefinition2);
            footerDescription1.Aggregates.Add(aggregateDefinition3);
            gridStockOperation.Footers.Descriptions.Add(footerDescription1);
            gridStockOperation.Footers.Fixed = true;
            stringItem1.Name = "Head2";
            stringItem1.Value = "...;Id;Статус;Номер;Дата;Тип;Грузоотправитель;Грузоотправитель;Грузополучатель;Грузополучатель;Сумма по документу;Сумма по документу;";
            stringItem2.Name = "Head1";
            stringItem2.Value = "...;Id;Статус;Номер;Дата;Тип;Контрагент;Склад;Контрагент;Склад;Приход;Расход;";
            gridStockOperation.Headers.Add(stringItem1);
            gridStockOperation.Headers.Add(stringItem2);
            gridStockOperation.IdName = null;
            gridStockOperation.Location = new Point(0, 31);
            gridStockOperation.Name = "gridStockOperation";
            gridStockOperation.Rows.Count = 5;
            gridStockOperation.Rows.Fixed = 2;
            gridStockOperation.SelectedRows = (List<int>)resources.GetObject("gridStockOperation.SelectedRows");
            gridStockOperation.SelectionMode = C1.Win.FlexGrid.SelectionModeEnum.Row;
            gridStockOperation.Size = new Size(1045, 368);
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
            toolStrip1.Size = new Size(1045, 31);
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
            panel1.Controls.Add(c1TextBox1);
            panel1.Controls.Add(lNumber);
            panel1.Controls.Add(sbType);
            panel1.Controls.Add(lType);
            panel1.Controls.Add(cddContragentFrom);
            panel1.Controls.Add(lContragentFrom);
            panel1.Controls.Add(sbStock);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(lContragentTo);
            panel1.Controls.Add(cddContragentTo);
            panel1.Controls.Add(periodBox);
            panel1.Controls.Add(c1Label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1045, 104);
            panel1.TabIndex = 2;
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
            // cddContragentTo
            // 
            cddContragentTo.ButtonsSettings.CustomButton.Icon = new C1.Framework.C1BitmapIcon(null, new Size(16, 16), Color.Transparent, (Image)resources.GetObject("companyDropDown1.ButtonsSettings.CustomButton.Icon1"));
            cddContragentTo.ButtonsSettings.CustomButton.Visible = true;
            cddContragentTo.DropDownAlign = C1.Framework.DropDownAlignment.Left;
            cddContragentTo.DropDownWidth = 300;
            cddContragentTo.GetDataSourceFunc = null;
            cddContragentTo.Location = new Point(134, 40);
            cddContragentTo.Name = "cddContragentTo";
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
            cddContragentTo.TabIndex = 3;
            cddContragentTo.Value = "";
            // 
            // lContragentTo
            // 
            lContragentTo.AutoSize = true;
            lContragentTo.Location = new Point(17, 41);
            lContragentTo.Name = "lContragentTo";
            lContragentTo.Size = new Size(111, 21);
            lContragentTo.TabIndex = 2;
            lContragentTo.Text = "Грузополучатель:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(376, 14);
            label1.Name = "label1";
            label1.Size = new Size(43, 15);
            label1.TabIndex = 6;
            label1.Text = "Склад:";
            // 
            // sbStock
            // 
            sbStock.ButtonsSettings.ModalButton.Visible = true;
            sbStock.Location = new Point(426, 9);
            sbStock.Name = "sbStock";
            sbStock.Size = new Size(160, 23);
            sbStock.TabIndex = 7;
            sbStock.Value = "";
            // 
            // lContragentFrom
            // 
            lContragentFrom.AutoSize = true;
            lContragentFrom.Location = new Point(12, 72);
            lContragentFrom.Name = "lContragentFrom";
            lContragentFrom.Size = new Size(116, 21);
            lContragentFrom.TabIndex = 4;
            lContragentFrom.Text = "Грузоотправитель:";
            // 
            // cddContragentFrom
            // 
            cddContragentFrom.ButtonsSettings.CustomButton.Icon = new C1.Framework.C1BitmapIcon(null, new Size(16, 16), Color.Transparent, (Image)resources.GetObject("companyDropDown1.ButtonsSettings.CustomButton.Icon"));
            cddContragentFrom.ButtonsSettings.CustomButton.Visible = true;
            cddContragentFrom.DropDownAlign = C1.Framework.DropDownAlignment.Left;
            cddContragentFrom.DropDownWidth = 300;
            cddContragentFrom.GetDataSourceFunc = null;
            cddContragentFrom.Location = new Point(134, 71);
            cddContragentFrom.Name = "cddContragentFrom";
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
            cddContragentFrom.TabIndex = 5;
            cddContragentFrom.Value = "";
            // 
            // lType
            // 
            lType.AutoSize = true;
            lType.Location = new Point(358, 41);
            lType.Name = "lType";
            lType.Size = new Size(61, 21);
            lType.TabIndex = 9;
            lType.Text = "Тип док.:";
            // 
            // sbType
            // 
            sbType.ButtonsSettings.ModalButton.Visible = true;
            sbType.Location = new Point(426, 40);
            sbType.Name = "sbType";
            sbType.Size = new Size(160, 23);
            sbType.TabIndex = 10;
            sbType.Value = "";
            // 
            // lNumber
            // 
            lNumber.AutoSize = true;
            lNumber.Location = new Point(341, 72);
            lNumber.Name = "lNumber";
            lNumber.Size = new Size(79, 21);
            lNumber.TabIndex = 11;
            lNumber.Text = "Номер док.:";
            // 
            // c1TextBox1
            // 
            c1TextBox1.Location = new Point(426, 71);
            c1TextBox1.Name = "c1TextBox1";
            c1TextBox1.Size = new Size(160, 23);
            c1TextBox1.TabIndex = 12;
            c1TextBox1.Value = "";
            // 
            // StockDocumentsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1045, 503);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "StockDocumentsForm";
            Text = "Складские  документы";
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridStockOperation).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)periodBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)c1Label1).EndInit();
            ((System.ComponentModel.ISupportInitialize)cddContragentTo).EndInit();
            ((System.ComponentModel.ISupportInitialize)lContragentTo).EndInit();
            ((System.ComponentModel.ISupportInitialize)sbStock).EndInit();
            ((System.ComponentModel.ISupportInitialize)lContragentFrom).EndInit();
            ((System.ComponentModel.ISupportInitialize)cddContragentFrom).EndInit();
            ((System.ComponentModel.ISupportInitialize)lType).EndInit();
            ((System.ComponentModel.ISupportInitialize)sbType).EndInit();
            ((System.ComponentModel.ISupportInitialize)lNumber).EndInit();
            ((System.ComponentModel.ISupportInitialize)c1TextBox1).EndInit();
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
        private SmartLib.Base.SmartBox.SmartBox sbStock;
        private Label label1;
        private C1.Win.Input.C1Label lContragentTo;
        private Contragents.Components.CompanyDropDown cddContragentTo;
        private Contragents.Components.CompanyDropDown cddContragentFrom;
        private C1.Win.Input.C1Label lContragentFrom;
        private SmartLib.Base.SmartBox.SmartBox sbType;
        private C1.Win.Input.C1Label lType;
        private C1.Win.Input.C1TextBox c1TextBox1;
        private C1.Win.Input.C1Label lNumber;
    }
}