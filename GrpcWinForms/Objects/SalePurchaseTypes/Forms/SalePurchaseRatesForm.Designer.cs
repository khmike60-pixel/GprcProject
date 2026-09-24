namespace GrpcWinForms.Objects.SalePurchaseTypes.Forms
{
    partial class SalePurchaseRatesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SalePurchaseRatesForm));
            C1.Win.FlexGrid.FooterDescription footerDescription2 = new C1.Win.FlexGrid.FooterDescription();
            C1.Win.FlexGrid.AggregateDefinition aggregateDefinition2 = new C1.Win.FlexGrid.AggregateDefinition();
            SmartLib.StringItem stringItem4 = new SmartLib.StringItem();
            SmartLib.StringItem stringItem5 = new SmartLib.StringItem();
            SmartLib.StringItem stringItem6 = new SmartLib.StringItem();
            panel2 = new Panel();
            gridRates = new SmartLib.SmartGrid(components);
            toolStrip1 = new ToolStrip();
            btnNew = new ToolStripButton();
            btnDouble = new ToolStripButton();
            btnEdit = new ToolStripButton();
            btnDelete = new ToolStripButton();
            btnRefresh = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            btnView = new ToolStripDropDownButton();
            btnRates = new ToolStripMenuItem();
            btnCoefficients = new ToolStripMenuItem();
            panel1 = new Panel();
            lblPeriod = new C1.Win.Input.C1Label();
            periodBox = new SmartLib.PeriodBox(components);
            lblCurrency = new C1.Win.Input.C1Label();
            txtCurrency = new C1.Win.Input.C1TextBox();
            txtCountryCode = new C1.Win.Input.C1TextBox();
            cbName = new GrpcWinForms.Controls.SmartBox.SmartBox(components);
            lblName = new C1.Win.Input.C1Label();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridRates).BeginInit();
            toolStrip1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)lblPeriod).BeginInit();
            ((System.ComponentModel.ISupportInitialize)periodBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lblCurrency).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtCurrency).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtCountryCode).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cbName).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lblName).BeginInit();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.Controls.Add(gridRates);
            panel2.Controls.Add(toolStrip1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 65);
            panel2.Name = "panel2";
            panel2.Size = new Size(959, 385);
            panel2.TabIndex = 3;
            // 
            // gridRates
            // 
            gridRates.AllowEditing = false;
            gridRates.AllowMerging = C1.Win.FlexGrid.AllowMergingEnum.FixedOnly;
            gridRates.AllowMergingFixed = C1.Win.FlexGrid.AllowMergingEnum.FixedOnly;
            gridRates.AllowNodeMove = false;
            gridRates.AutoGenerateColumns = false;
            gridRates.ColumnInfo = resources.GetString("gridRates.ColumnInfo");
            gridRates.Dock = DockStyle.Fill;
            gridRates.DrawMode = C1.Win.FlexGrid.DrawModeEnum.OwnerDraw;
            aggregateDefinition2.Aggregate = C1.Win.FlexGrid.AggregateEnum.Count;
            aggregateDefinition2.Caption = "Всего: ";
            aggregateDefinition2.Column = 4;
            footerDescription2.Aggregates.Add(aggregateDefinition2);
            gridRates.Footers.Descriptions.Add(footerDescription2);
            gridRates.Footers.Fixed = true;
            stringItem4.Name = "Заголовок 1";
            stringItem4.Value = resources.GetString("stringItem4.Value");
            stringItem5.Name = "Заголовок 2";
            stringItem5.Value = "...;Статус;Дата;Курс ЦБ;Прайс-лист;Конверт.;Курс выдачи;БН -> Нал;БН -> Нал;Нал -> БН;НДС (%);Накладные расходы (%);Рентаб. (%);ФИО;Дата;ФИО;Дата;Комментарий";
            stringItem6.Name = "Заголовок 3";
            stringItem6.Value = "...;Статус;Дата;Курс ЦБ;Прайс-лист;Конверт.;Курс выдачи;Резидент;Нерезидент;Нал -> БН;НДС (%);Накладные расходы (%);Рентаб. (%);ФИО;Дата;ФИО;Дата;Комментарий";
            gridRates.Headers.Add(stringItem4);
            gridRates.Headers.Add(stringItem5);
            gridRates.Headers.Add(stringItem6);
            gridRates.IdName = null;
            gridRates.Location = new Point(0, 31);
            gridRates.Name = "gridRates";
            gridRates.Rows.Count = 10;
            gridRates.Rows.Fixed = 3;
            gridRates.SelectedRows = (List<int>)resources.GetObject("gridRates.SelectedRows");
            gridRates.SelectionMode = C1.Win.FlexGrid.SelectionModeEnum.Row;
            gridRates.Size = new Size(959, 354);
            gridRates.SortingType = SmartLib.SortingType.Descending;
            gridRates.StyleInfo = resources.GetString("gridRates.StyleInfo");
            gridRates.TabIndex = 3;
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(24, 24);
            toolStrip1.Items.AddRange(new ToolStripItem[] { btnNew, btnDouble, btnEdit, btnDelete, btnRefresh, toolStripSeparator1, btnView });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(959, 31);
            toolStrip1.TabIndex = 0;
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
            btnDouble.Enabled = false;
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
            // btnView
            // 
            btnView.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnView.DropDownItems.AddRange(new ToolStripItem[] { btnRates, btnCoefficients });
            btnView.Image = (Image)resources.GetObject("btnView.Image");
            btnView.ImageTransparentColor = Color.Magenta;
            btnView.Name = "btnView";
            btnView.Size = new Size(122, 28);
            btnView.Text = "Режим просмотра";
            // 
            // btnRates
            // 
            btnRates.Name = "btnRates";
            btnRates.Size = new Size(160, 22);
            btnRates.Text = "Курсы";
            // 
            // btnCoefficients
            // 
            btnCoefficients.Name = "btnCoefficients";
            btnCoefficients.Size = new Size(160, 22);
            btnCoefficients.Text = "Коэффициенты";
            // 
            // panel1
            // 
            panel1.Controls.Add(lblPeriod);
            panel1.Controls.Add(periodBox);
            panel1.Controls.Add(lblCurrency);
            panel1.Controls.Add(txtCurrency);
            panel1.Controls.Add(txtCountryCode);
            panel1.Controls.Add(cbName);
            panel1.Controls.Add(lblName);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(959, 65);
            panel1.TabIndex = 2;
            // 
            // lblPeriod
            // 
            lblPeriod.AutoSize = true;
            lblPeriod.Location = new Point(142, 6);
            lblPeriod.Name = "lblPeriod";
            lblPeriod.Size = new Size(58, 21);
            lblPeriod.TabIndex = 13;
            lblPeriod.Text = "Период:";
            // 
            // periodBox
            // 
            periodBox.Location = new Point(206, 4);
            periodBox.Name = "periodBox";
            periodBox.Period.From = new DateTime(2026, 6, 25, 13, 40, 0, 543);
            periodBox.Period.To = new DateTime(2026, 9, 23, 13, 40, 0, 543);
            // 
            // lblCurrency
            // 
            lblCurrency.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblCurrency.AutoSize = true;
            lblCurrency.Location = new Point(529, 34);
            lblCurrency.Name = "lblCurrency";
            lblCurrency.Size = new Size(100, 21);
            lblCurrency.TabIndex = 11;
            lblCurrency.Text = "Валюта страны:";
            // 
            // txtCurrency
            // 
            txtCurrency.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtCurrency.Location = new Point(635, 33);
            txtCurrency.Name = "txtCurrency";
            txtCurrency.ReadOnly = true;
            txtCurrency.Size = new Size(69, 23);
            txtCurrency.TabIndex = 10;
            txtCurrency.TextAlign = HorizontalAlignment.Center;
            txtCurrency.Value = "UZS";
            // 
            // txtCountryCode
            // 
            txtCountryCode.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtCountryCode.Location = new Point(490, 33);
            txtCountryCode.Name = "txtCountryCode";
            txtCountryCode.ReadOnly = true;
            txtCountryCode.Size = new Size(28, 23);
            txtCountryCode.TabIndex = 9;
            txtCountryCode.TextAlign = HorizontalAlignment.Center;
            txtCountryCode.Value = "UZ";
            // 
            // cbName
            // 
            cbName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cbName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbName.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbName.AutoSuggestMode = C1.Win.Input.AutoSuggestMode.Contains;
            cbName.ButtonsSettings.CustomButton.Icon = new C1.Framework.C1BitmapIcon(null, new Size(16, 16), Color.Transparent, (Image)resources.GetObject("cbName.ButtonsSettings.CustomButton.Icon"));
            cbName.ButtonsSettings.CustomButton.Visible = true;
            cbName.ButtonsSettings.ModalButton.Visible = true;
            cbName.Location = new Point(206, 33);
            cbName.ModalForm = null;
            cbName.Name = "cbName";
            cbName.NullEnable = true;
            cbName.Size = new Size(276, 23);
            cbName.TabIndex = 8;
            cbName.Value = "";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(18, 34);
            lblName.Name = "lblName";
            lblName.Size = new Size(182, 21);
            lblName.TabIndex = 0;
            lblName.Text = "Тип продажи/покупки, страна:";
            // 
            // SalePurchaseRatesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(959, 450);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "SalePurchaseRatesForm";
            Text = "Курсы используемых валют";
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridRates).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)lblPeriod).EndInit();
            ((System.ComponentModel.ISupportInitialize)periodBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)lblCurrency).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtCurrency).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtCountryCode).EndInit();
            ((System.ComponentModel.ISupportInitialize)cbName).EndInit();
            ((System.ComponentModel.ISupportInitialize)lblName).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel2;
        private SmartLib.SmartGrid gridRates;
        private ToolStrip toolStrip1;
        private ToolStripButton btnNew;
        private ToolStripButton btnDouble;
        private ToolStripButton btnEdit;
        private ToolStripButton btnDelete;
        private ToolStripButton btnRefresh;
        private ToolStripSeparator toolStripSeparator1;
        private Panel panel1;
        private C1.Win.Input.C1Label lblName;
        private C1.Win.Input.C1Label lblCurrency;
        private C1.Win.Input.C1TextBox txtCurrency;
        private C1.Win.Input.C1TextBox txtCountryCode;
        private Controls.SmartBox.SmartBox cbName;
        private ToolStripDropDownButton btnView;
        private ToolStripMenuItem btnRates;
        private ToolStripMenuItem btnCoefficients;
        private C1.Win.Input.C1Label lblPeriod;
        private SmartLib.PeriodBox periodBox;
    }
}