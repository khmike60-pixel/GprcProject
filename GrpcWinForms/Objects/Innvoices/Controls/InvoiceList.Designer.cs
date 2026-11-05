namespace GrpcWinForms.Objects.Innvoices.Controls
{
    partial class InvoiceList
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvoiceList));
            GrpcCommonNet.Library.Common.Contragent contragent1 = new GrpcCommonNet.Library.Common.Contragent();
            GrpcCommonNet.Library.Common.Contragent contragent2 = new GrpcCommonNet.Library.Common.Contragent();
            C1.Win.FlexGrid.FooterDescription footerDescription1 = new C1.Win.FlexGrid.FooterDescription();
            C1.Win.FlexGrid.AggregateDefinition aggregateDefinition1 = new C1.Win.FlexGrid.AggregateDefinition();
            C1.Win.FlexGrid.AggregateDefinition aggregateDefinition2 = new C1.Win.FlexGrid.AggregateDefinition();
            C1.Win.FlexGrid.AggregateDefinition aggregateDefinition3 = new C1.Win.FlexGrid.AggregateDefinition();
            C1.Win.FlexGrid.AggregateDefinition aggregateDefinition4 = new C1.Win.FlexGrid.AggregateDefinition();
            toolStrip1 = new ToolStrip();
            btnNew = new ToolStripButton();
            btnDouble = new ToolStripButton();
            btnEdit = new ToolStripButton();
            btnDelete = new ToolStripButton();
            btnRefresh = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            btnStatus = new ToolStripButton();
            panel1 = new Panel();
            txtContract = new C1.Win.Input.C1TextBox();
            smartBox2 = new SmartLib.Base.SmartBox.SmartBox(components);
            smartBox1 = new SmartLib.Base.SmartBox.SmartBox(components);
            cddBuyer = new GrpcWinForms.Objects.Contragents.Components.CompanyDropDown(components);
            cddSeller = new GrpcWinForms.Objects.Contragents.Components.CompanyDropDown(components);
            periodBox = new SmartLib.PeriodBox(components);
            c1Label1 = new C1.Win.Input.C1Label();
            lDepartment = new C1.Win.Input.C1Label();
            lConntract = new C1.Win.Input.C1Label();
            lBuyer = new C1.Win.Input.C1Label();
            lSeller = new C1.Win.Input.C1Label();
            lPeriod = new C1.Win.Input.C1Label();
            grid = new SmartLib.SmartGrid(components);
            toolStrip1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtContract).BeginInit();
            ((System.ComponentModel.ISupportInitialize)smartBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)smartBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cddBuyer).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cddSeller).BeginInit();
            ((System.ComponentModel.ISupportInitialize)periodBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)c1Label1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lDepartment).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lConntract).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lBuyer).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lSeller).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lPeriod).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grid).BeginInit();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(24, 24);
            toolStrip1.Items.AddRange(new ToolStripItem[] { btnNew, btnDouble, btnEdit, btnDelete, btnRefresh, toolStripSeparator1, btnStatus });
            toolStrip1.Location = new Point(0, 90);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1138, 31);
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
            // 
            // btnNew
            // 
            btnNew.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnNew.Image = Properties.Resources.icons8_документ_50;
            btnNew.ImageTransparentColor = Color.Magenta;
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(28, 28);
            btnNew.Text = "Новый";
            // 
            // btnDouble
            // 
            btnDouble.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnDouble.Image = Properties.Resources.icons8_скопировать_50;
            btnDouble.ImageTransparentColor = Color.Magenta;
            btnDouble.Name = "btnDouble";
            btnDouble.Size = new Size(28, 28);
            btnDouble.Text = "Дублировать";
            // 
            // btnEdit
            // 
            btnEdit.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnEdit.Image = Properties.Resources.icons8_редактирование_файла_50;
            btnEdit.ImageTransparentColor = Color.Magenta;
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(28, 28);
            btnEdit.Text = "Редактировать";
            // 
            // btnDelete
            // 
            btnDelete.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnDelete.Image = Properties.Resources.icons8_удалить_файл_50;
            btnDelete.ImageTransparentColor = Color.Magenta;
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(28, 28);
            btnDelete.Text = "Удалить";
            // 
            // btnRefresh
            // 
            btnRefresh.Alignment = ToolStripItemAlignment.Right;
            btnRefresh.Image = Properties.Resources.icons8_refresh_50;
            btnRefresh.ImageTransparentColor = Color.Magenta;
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(89, 28);
            btnRefresh.Text = "Обновить";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 31);
            // 
            // btnStatus
            // 
            btnStatus.Image = Properties.Resources.icons8_checklist_50_2;
            btnStatus.ImageTransparentColor = Color.Magenta;
            btnStatus.Name = "btnStatus";
            btnStatus.Size = new Size(187, 28);
            btnStatus.Text = "Изменить статус документа";
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(txtContract);
            panel1.Controls.Add(smartBox2);
            panel1.Controls.Add(smartBox1);
            panel1.Controls.Add(cddBuyer);
            panel1.Controls.Add(cddSeller);
            panel1.Controls.Add(periodBox);
            panel1.Controls.Add(c1Label1);
            panel1.Controls.Add(lDepartment);
            panel1.Controls.Add(lConntract);
            panel1.Controls.Add(lBuyer);
            panel1.Controls.Add(lSeller);
            panel1.Controls.Add(lPeriod);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1138, 90);
            panel1.TabIndex = 2;
            // 
            // txtContract
            // 
            txtContract.Location = new Point(401, 3);
            txtContract.Name = "txtContract";
            txtContract.Placeholder = "Номер";
            txtContract.Size = new Size(100, 23);
            txtContract.TabIndex = 13;
            txtContract.Value = "";
            // 
            // smartBox2
            // 
            smartBox2.Location = new Point(401, 60);
            smartBox2.Name = "smartBox2";
            smartBox2.Placeholder = "Менеджер";
            smartBox2.Size = new Size(100, 23);
            smartBox2.TabIndex = 12;
            smartBox2.Value = "";
            // 
            // smartBox1
            // 
            smartBox1.Location = new Point(401, 33);
            smartBox1.Name = "smartBox1";
            smartBox1.Placeholder = "Отдел";
            smartBox1.Size = new Size(100, 23);
            smartBox1.TabIndex = 10;
            smartBox1.Value = "";
            // 
            // cddBuyer
            // 
            cddBuyer.ButtonsSettings.CustomButton.Icon = new C1.Framework.C1BitmapIcon(null, new Size(16, 16), Color.Transparent, (Image)resources.GetObject("cddBuyer.ButtonsSettings.CustomButton.Icon"));
            cddBuyer.ButtonsSettings.CustomButton.Visible = true;
            cddBuyer.DropDownAlign = C1.Framework.DropDownAlignment.Left;
            cddBuyer.DropDownWidth = 300;
            cddBuyer.GetDataSourceFunc = null;
            cddBuyer.Location = new Point(90, 60);
            cddBuyer.Name = "cddBuyer";
            cddBuyer.Placeholder = "Контрагент";
            contragent1.CountryId = 0;
            contragent1.CountrySymbol = "";
            contragent1.Entity = null;
            contragent1.Id = 0;
            contragent1.Name = "";
            contragent1.Person = null;
            contragent1.Prefix = "";
            contragent1.Taxno = "";
            contragent1.Type = GrpcCommonNet.Library.Common.ContragentType.Entity;
            cddBuyer.SelectedCompany = contragent1;
            cddBuyer.Size = new Size(208, 23);
            cddBuyer.TabIndex = 6;
            cddBuyer.Value = "";
            // 
            // cddSeller
            // 
            cddSeller.ButtonsSettings.CustomButton.Icon = new C1.Framework.C1BitmapIcon(null, new Size(16, 16), Color.Transparent, (Image)resources.GetObject("cddSeller.ButtonsSettings.CustomButton.Icon"));
            cddSeller.ButtonsSettings.CustomButton.Visible = true;
            cddSeller.DropDownAlign = C1.Framework.DropDownAlignment.Left;
            cddSeller.DropDownWidth = 300;
            cddSeller.GetDataSourceFunc = null;
            cddSeller.Location = new Point(90, 33);
            cddSeller.Name = "cddSeller";
            cddSeller.Placeholder = "Наша организация";
            contragent2.CountryId = 0;
            contragent2.CountrySymbol = "";
            contragent2.Entity = null;
            contragent2.Id = 0;
            contragent2.Name = "";
            contragent2.Person = null;
            contragent2.Prefix = "";
            contragent2.Taxno = "";
            contragent2.Type = GrpcCommonNet.Library.Common.ContragentType.Entity;
            cddSeller.SelectedCompany = contragent2;
            cddSeller.Size = new Size(208, 23);
            cddSeller.TabIndex = 4;
            cddSeller.Value = "";
            // 
            // periodBox
            // 
            periodBox.Location = new Point(90, 4);
            periodBox.Name = "periodBox";
            periodBox.Period.From = new DateTime(2026, 1, 1, 0, 0, 0, 0);
            periodBox.Period.To = new DateTime(2026, 12, 31, 23, 59, 59, 0);
            periodBox.TabIndex = 2;
            // 
            // c1Label1
            // 
            c1Label1.AutoSize = true;
            c1Label1.Location = new Point(321, 62);
            c1Label1.Name = "c1Label1";
            c1Label1.Size = new Size(74, 21);
            c1Label1.TabIndex = 11;
            c1Label1.Text = "Менеджер:";
            // 
            // lDepartment
            // 
            lDepartment.AutoSize = true;
            lDepartment.Location = new Point(346, 33);
            lDepartment.Name = "lDepartment";
            lDepartment.Size = new Size(49, 21);
            lDepartment.TabIndex = 9;
            lDepartment.Text = "Отдел:";
            // 
            // lConntract
            // 
            lConntract.AutoSize = true;
            lConntract.Location = new Point(329, 4);
            lConntract.Name = "lConntract";
            lConntract.Size = new Size(66, 21);
            lConntract.TabIndex = 7;
            lConntract.Text = "Контракт:";
            // 
            // lBuyer
            // 
            lBuyer.AutoSize = true;
            lBuyer.Location = new Point(3, 62);
            lBuyer.Name = "lBuyer";
            lBuyer.Size = new Size(81, 21);
            lBuyer.TabIndex = 5;
            lBuyer.Text = "Покупатель:";
            // 
            // lSeller
            // 
            lSeller.AutoSize = true;
            lSeller.Location = new Point(14, 33);
            lSeller.Name = "lSeller";
            lSeller.Size = new Size(70, 21);
            lSeller.TabIndex = 3;
            lSeller.Text = "Продавец:";
            // 
            // lPeriod
            // 
            lPeriod.AutoSize = true;
            lPeriod.Location = new Point(26, 4);
            lPeriod.Name = "lPeriod";
            lPeriod.Size = new Size(58, 21);
            lPeriod.TabIndex = 1;
            lPeriod.Text = "Период:";
            // 
            // grid
            // 
            grid.AllowMerging = C1.Win.FlexGrid.AllowMergingEnum.FixedOnly;
            grid.AllowMergingFixed = C1.Win.FlexGrid.AllowMergingEnum.FixedOnly;
            grid.AllowNodeMove = false;
            grid.ColumnInfo = resources.GetString("grid.ColumnInfo");
            grid.Dock = DockStyle.Fill;
            grid.DrawMode = C1.Win.FlexGrid.DrawModeEnum.OwnerDraw;
            aggregateDefinition1.Aggregate = C1.Win.FlexGrid.AggregateEnum.Count;
            aggregateDefinition1.Caption = "Всего: ";
            aggregateDefinition1.Column = 3;
            aggregateDefinition2.Aggregate = C1.Win.FlexGrid.AggregateEnum.Sum;
            aggregateDefinition2.Column = 8;
            aggregateDefinition3.Aggregate = C1.Win.FlexGrid.AggregateEnum.Sum;
            aggregateDefinition3.Column = 9;
            aggregateDefinition4.Aggregate = C1.Win.FlexGrid.AggregateEnum.Sum;
            aggregateDefinition4.Column = 10;
            footerDescription1.Aggregates.Add(aggregateDefinition1);
            footerDescription1.Aggregates.Add(aggregateDefinition2);
            footerDescription1.Aggregates.Add(aggregateDefinition3);
            footerDescription1.Aggregates.Add(aggregateDefinition4);
            grid.Footers.Descriptions.Add(footerDescription1);
            grid.Footers.Fixed = true;
            grid.IdName = null;
            grid.Location = new Point(0, 121);
            grid.Name = "grid";
            grid.Rows.Count = 5;
            grid.Rows.Fixed = 2;
            grid.SelectedRows = (List<int>)resources.GetObject("grid.SelectedRows");
            grid.SelectionMode = C1.Win.FlexGrid.SelectionModeEnum.Row;
            grid.Size = new Size(1138, 209);
            grid.SortingType = SmartLib.SortingType.Descending;
            grid.StyleInfo = resources.GetString("grid.StyleInfo");
            grid.TabIndex = 3;
            // 
            // InvoiceList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(grid);
            Controls.Add(toolStrip1);
            Controls.Add(panel1);
            Name = "InvoiceList";
            Size = new Size(1138, 330);
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)txtContract).EndInit();
            ((System.ComponentModel.ISupportInitialize)smartBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)smartBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)cddBuyer).EndInit();
            ((System.ComponentModel.ISupportInitialize)cddSeller).EndInit();
            ((System.ComponentModel.ISupportInitialize)periodBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)c1Label1).EndInit();
            ((System.ComponentModel.ISupportInitialize)lDepartment).EndInit();
            ((System.ComponentModel.ISupportInitialize)lConntract).EndInit();
            ((System.ComponentModel.ISupportInitialize)lBuyer).EndInit();
            ((System.ComponentModel.ISupportInitialize)lSeller).EndInit();
            ((System.ComponentModel.ISupportInitialize)lPeriod).EndInit();
            ((System.ComponentModel.ISupportInitialize)grid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripButton btnNew;
        private ToolStripButton btnDouble;
        private ToolStripButton btnEdit;
        private ToolStripButton btnDelete;
        private ToolStripButton btnRefresh;
        private ToolStripSeparator toolStripSeparator1;
        private Panel panel1;
        private C1.Win.Input.C1Label lBuyer;
        private C1.Win.Input.C1Label lSeller;
        private C1.Win.Input.C1Label lPeriod;
        private C1.Win.Input.C1Label lConntract;
        private ToolStripButton btnStatus;
        private C1.Win.Input.C1Label lDepartment;
        private C1.Win.Input.C1Label c1Label1;
        public SmartLib.PeriodBox periodBox;
        public Contragents.Components.CompanyDropDown cddSeller;
        public Contragents.Components.CompanyDropDown cddBuyer;
        public SmartLib.Base.SmartBox.SmartBox smartBox1;
        public SmartLib.Base.SmartBox.SmartBox smartBox2;
        public C1.Win.Input.C1TextBox txtContract;
        public SmartLib.SmartGrid grid;
    }
}
