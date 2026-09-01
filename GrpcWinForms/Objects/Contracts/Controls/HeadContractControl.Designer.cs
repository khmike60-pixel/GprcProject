namespace GrpcWinForms.Objects.Contracts.Forms.Controls
{
    partial class HeadContractControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HeadContractControl));
            labelBuyer = new Label();
            labelTaxNoBuyer = new Label();
            textBoxTaxnoBuyer = new TextBox();
            labelSeller = new Label();
            labelTaxnoSeller = new Label();
            textBoxTaxnoSeller = new TextBox();
            ContractType = new Label();
            comboBoxContractType = new C1.Win.Input.C1ComboBox();
            labelNumber = new Label();
            textBoxNumber = new TextBox();
            labelDateStart = new Label();
            labelDateStop = new Label();
            groupBoxMain = new GroupBox();
            smartBoxCurrency = new GrpcWinForms.Controls.SmartBox.SmartBox(components);
            dateEditStart = new C1.Win.Calendar.C1DateEdit();
            dateEditStop = new C1.Win.Calendar.C1DateEdit();
            companySeller = new GrpcWinForms.Objects.Contragents.Components.CompanyDropDown(components);
            companyBuyer = new GrpcWinForms.Objects.Contragents.Components.CompanyDropDown(components);
            labelCurrency = new Label();
            c1FlexGrid1 = new C1.Win.FlexGrid.C1FlexGrid();
            control1 = new Control();
            control2 = new Control();
            ((System.ComponentModel.ISupportInitialize)comboBoxContractType).BeginInit();
            groupBoxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)smartBoxCurrency).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dateEditStart).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dateEditStop).BeginInit();
            ((System.ComponentModel.ISupportInitialize)companySeller).BeginInit();
            ((System.ComponentModel.ISupportInitialize)companyBuyer).BeginInit();
            ((System.ComponentModel.ISupportInitialize)c1FlexGrid1).BeginInit();
            SuspendLayout();
            // 
            // labelBuyer
            // 
            labelBuyer.AutoSize = true;
            labelBuyer.Location = new Point(10, 17);
            labelBuyer.Name = "labelBuyer";
            labelBuyer.Size = new Size(75, 15);
            labelBuyer.TabIndex = 0;
            labelBuyer.Text = "Покупатель:";
            labelBuyer.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelTaxNoBuyer
            // 
            labelTaxNoBuyer.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelTaxNoBuyer.AutoSize = true;
            labelTaxNoBuyer.Location = new Point(538, 17);
            labelTaxNoBuyer.Name = "labelTaxNoBuyer";
            labelTaxNoBuyer.Size = new Size(95, 15);
            labelTaxNoBuyer.TabIndex = 2;
            labelTaxNoBuyer.Text = "ИНН / ПИН ФЛ:";
            labelTaxNoBuyer.TextAlign = ContentAlignment.MiddleRight;
            // 
            // textBoxTaxnoBuyer
            // 
            textBoxTaxnoBuyer.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            textBoxTaxnoBuyer.Location = new Point(639, 13);
            textBoxTaxnoBuyer.Name = "textBoxTaxnoBuyer";
            textBoxTaxnoBuyer.ReadOnly = true;
            textBoxTaxnoBuyer.Size = new Size(94, 23);
            textBoxTaxnoBuyer.TabIndex = 3;
            textBoxTaxnoBuyer.Text = "12345678901234";
            // 
            // labelSeller
            // 
            labelSeller.AutoSize = true;
            labelSeller.Location = new Point(10, 45);
            labelSeller.Name = "labelSeller";
            labelSeller.Size = new Size(64, 15);
            labelSeller.TabIndex = 4;
            labelSeller.Text = "Продавец:";
            labelSeller.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelTaxnoSeller
            // 
            labelTaxnoSeller.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelTaxnoSeller.AutoSize = true;
            labelTaxnoSeller.Location = new Point(538, 46);
            labelTaxnoSeller.Name = "labelTaxnoSeller";
            labelTaxnoSeller.Size = new Size(95, 15);
            labelTaxnoSeller.TabIndex = 6;
            labelTaxnoSeller.Text = "ИНН / ПИН ФЛ:";
            labelTaxnoSeller.TextAlign = ContentAlignment.MiddleRight;
            // 
            // textBoxTaxnoSeller
            // 
            textBoxTaxnoSeller.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            textBoxTaxnoSeller.Location = new Point(639, 42);
            textBoxTaxnoSeller.Name = "textBoxTaxnoSeller";
            textBoxTaxnoSeller.ReadOnly = true;
            textBoxTaxnoSeller.Size = new Size(94, 23);
            textBoxTaxnoSeller.TabIndex = 7;
            // 
            // ContractType
            // 
            ContractType.AutoSize = true;
            ContractType.Location = new Point(28, 104);
            ContractType.Name = "ContractType";
            ContractType.Size = new Size(88, 15);
            ContractType.TabIndex = 8;
            ContractType.Text = "Тип контракта:";
            ContractType.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // comboBoxContractType
            // 
            comboBoxContractType.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBoxContractType.AutoSize = false;
            comboBoxContractType.Location = new Point(121, 100);
            comboBoxContractType.Name = "comboBoxContractType";
            comboBoxContractType.ReadOnly = true;
            comboBoxContractType.Size = new Size(278, 23);
            comboBoxContractType.TabIndex = 7;
            // 
            // labelNumber
            // 
            labelNumber.AutoSize = true;
            labelNumber.Location = new Point(10, 75);
            labelNumber.Name = "labelNumber";
            labelNumber.Size = new Size(106, 15);
            labelNumber.TabIndex = 10;
            labelNumber.Text = "Номер контракта:";
            labelNumber.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBoxNumber
            // 
            textBoxNumber.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxNumber.Location = new Point(121, 71);
            textBoxNumber.Name = "textBoxNumber";
            textBoxNumber.Size = new Size(146, 23);
            textBoxNumber.TabIndex = 3;
            // 
            // labelDateStart
            // 
            labelDateStart.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelDateStart.AutoSize = true;
            labelDateStart.Location = new Point(276, 74);
            labelDateStart.Name = "labelDateStart";
            labelDateStart.Size = new Size(22, 15);
            labelDateStart.TabIndex = 12;
            labelDateStart.Text = "от:";
            labelDateStart.TextAlign = ContentAlignment.MiddleRight;
            // 
            // labelDateStop
            // 
            labelDateStop.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelDateStop.AutoSize = true;
            labelDateStop.Location = new Point(404, 75);
            labelDateStop.Name = "labelDateStop";
            labelDateStop.Size = new Size(24, 15);
            labelDateStop.TabIndex = 14;
            labelDateStop.Text = "по:";
            labelDateStop.TextAlign = ContentAlignment.MiddleRight;
            // 
            // groupBoxMain
            // 
            groupBoxMain.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxMain.Controls.Add(smartBoxCurrency);
            groupBoxMain.Controls.Add(dateEditStart);
            groupBoxMain.Controls.Add(dateEditStop);
            groupBoxMain.Controls.Add(companySeller);
            groupBoxMain.Controls.Add(companyBuyer);
            groupBoxMain.Controls.Add(labelDateStop);
            groupBoxMain.Controls.Add(labelDateStart);
            groupBoxMain.Controls.Add(textBoxNumber);
            groupBoxMain.Controls.Add(comboBoxContractType);
            groupBoxMain.Controls.Add(labelNumber);
            groupBoxMain.Controls.Add(labelBuyer);
            groupBoxMain.Controls.Add(labelCurrency);
            groupBoxMain.Controls.Add(textBoxTaxnoBuyer);
            groupBoxMain.Controls.Add(ContractType);
            groupBoxMain.Controls.Add(textBoxTaxnoSeller);
            groupBoxMain.Controls.Add(labelTaxnoSeller);
            groupBoxMain.Controls.Add(labelTaxNoBuyer);
            groupBoxMain.Controls.Add(labelSeller);
            groupBoxMain.Location = new Point(3, 0);
            groupBoxMain.MinimumSize = new Size(740, 133);
            groupBoxMain.Name = "groupBoxMain";
            groupBoxMain.Size = new Size(740, 133);
            groupBoxMain.TabIndex = 16;
            groupBoxMain.TabStop = false;
            // 
            // smartBoxCurrency
            // 
            smartBoxCurrency.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            smartBoxCurrency.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            smartBoxCurrency.AutoCompleteSource = AutoCompleteSource.ListItems;
            smartBoxCurrency.AutoSuggestMode = C1.Win.Input.AutoSuggestMode.Contains;
            smartBoxCurrency.ButtonsSettings.CustomButton.Icon = new C1.Framework.C1BitmapIcon(null, new Size(16, 16), Color.Transparent, (Image)resources.GetObject("smartBoxCurrency.ButtonsSettings.CustomButton.Icon"));
            smartBoxCurrency.ButtonsSettings.CustomButton.Visible = true;
            smartBoxCurrency.ButtonsSettings.ModalButton.Visible = true;
            smartBoxCurrency.Location = new Point(639, 71);
            smartBoxCurrency.ModalForm = null;
            smartBoxCurrency.Name = "smartBoxCurrency";
            smartBoxCurrency.NullEnable = true;
            smartBoxCurrency.Size = new Size(94, 23);
            smartBoxCurrency.TabIndex = 6;
            smartBoxCurrency.Value = "";
            // 
            // dateEditStart
            // 
            dateEditStart.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dateEditStart.ButtonsSettings.UpDownButton.Visible = false;
            dateEditStart.EmptyAsNull = true;
            dateEditStart.FormatType = C1.Win.Input.FormatType.ShortDate;
            dateEditStart.Location = new Point(304, 70);
            dateEditStart.Name = "dateEditStart";
            dateEditStart.Size = new Size(94, 23);
            dateEditStart.TabIndex = 4;
            dateEditStart.Value = new DateTime(2026, 1, 1, 0, 0, 0, 0);
            // 
            // dateEditStop
            // 
            dateEditStop.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dateEditStop.ButtonsSettings.UpDownButton.Visible = false;
            dateEditStop.EmptyAsNull = true;
            dateEditStop.FormatType = C1.Win.Input.FormatType.ShortDate;
            dateEditStop.Location = new Point(435, 71);
            dateEditStop.Name = "dateEditStop";
            dateEditStop.Size = new Size(94, 23);
            dateEditStop.TabIndex = 5;
            dateEditStop.Value = new DateTime(2026, 8, 31, 0, 0, 0, 0);
            // 
            // companySeller
            // 
            companySeller.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            companySeller.ButtonsSettings.CustomButton.Icon = new C1.Framework.C1BitmapIcon(null, new Size(16, 16), Color.Transparent, (Image)resources.GetObject("companySeller.ButtonsSettings.CustomButton.Icon"));
            companySeller.ButtonsSettings.CustomButton.Visible = true;
            companySeller.ButtonsSettings.ModalButton.Visible = true;
            companySeller.DropDownAlign = C1.Framework.DropDownAlignment.Left;
            companySeller.DropDownWidth = 300;
            companySeller.GetDataSourceFunc = null;
            companySeller.Location = new Point(121, 42);
            companySeller.Name = "companySeller";
            companySeller.Size = new Size(408, 23);
            companySeller.TabIndex = 2;
            companySeller.Value = "";
            companySeller.ModalButtonClick += companySeller_ModalButtonClick;
            // 
            // companyBuyer
            // 
            companyBuyer.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            companyBuyer.ButtonsSettings.CustomButton.Icon = new C1.Framework.C1BitmapIcon(null, new Size(16, 16), Color.Transparent, (Image)resources.GetObject("companyBuyer.ButtonsSettings.CustomButton.Icon"));
            companyBuyer.ButtonsSettings.CustomButton.Visible = true;
            companyBuyer.ButtonsSettings.ModalButton.Visible = true;
            companyBuyer.DropDownAlign = C1.Framework.DropDownAlignment.Left;
            companyBuyer.DropDownWidth = 300;
            companyBuyer.GetDataSourceFunc = null;
            companyBuyer.Location = new Point(121, 13);
            companyBuyer.Name = "companyBuyer";
            companyBuyer.Size = new Size(408, 23);
            companyBuyer.TabIndex = 1;
            companyBuyer.Value = "";
            companyBuyer.ModalButtonClick += companyBuyer_ModalButtonClick;
            // 
            // labelCurrency
            // 
            labelCurrency.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelCurrency.AutoSize = true;
            labelCurrency.Location = new Point(604, 75);
            labelCurrency.Name = "labelCurrency";
            labelCurrency.Size = new Size(29, 15);
            labelCurrency.TabIndex = 16;
            labelCurrency.Text = "Влт:";
            labelCurrency.TextAlign = ContentAlignment.MiddleRight;
            // 
            // c1FlexGrid1
            // 
            c1FlexGrid1.ColumnInfo = "10,1,0,0,0,-1,Columns:";
            c1FlexGrid1.Location = new Point(13, 13);
            c1FlexGrid1.Name = "c1FlexGrid1";
            c1FlexGrid1.Size = new Size(240, 159);
            c1FlexGrid1.TabIndex = 1;
            // 
            // control1
            // 
            control1.Location = new Point(0, 0);
            control1.Name = "control1";
            control1.Size = new Size(0, 0);
            control1.TabIndex = 0;
            control1.Text = "control1";
            // 
            // control2
            // 
            control2.Location = new Point(0, 0);
            control2.Name = "control2";
            control2.Size = new Size(0, 0);
            control2.TabIndex = 0;
            control2.Text = "control2";
            // 
            // HeadContractControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBoxMain);
            MinimumSize = new Size(746, 136);
            Name = "HeadContractControl";
            Size = new Size(746, 136);
            Load += HeadContractControl_Load;
            ((System.ComponentModel.ISupportInitialize)comboBoxContractType).EndInit();
            groupBoxMain.ResumeLayout(false);
            groupBoxMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)smartBoxCurrency).EndInit();
            ((System.ComponentModel.ISupportInitialize)dateEditStart).EndInit();
            ((System.ComponentModel.ISupportInitialize)dateEditStop).EndInit();
            ((System.ComponentModel.ISupportInitialize)companySeller).EndInit();
            ((System.ComponentModel.ISupportInitialize)companyBuyer).EndInit();
            ((System.ComponentModel.ISupportInitialize)c1FlexGrid1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label labelBuyer;
        private Label labelTaxNoBuyer;
        private TextBox textBoxTaxnoBuyer;
        private Label labelSeller;
        private Label labelTaxnoSeller;
        private TextBox textBoxTaxnoSeller;
        private Label ContractType;
        private Label labelNumber;
        private Label labelDateStart;
        private Label labelDateStop;
        private GroupBox groupBoxMain;
        private Control control1;
        private Control control2;
        private C1.Win.FlexGrid.C1FlexGrid c1FlexGrid1;
        private Label labelCurrency;
        public C1.Win.Input.C1ComboBox comboBoxContractType;
        public TextBox textBoxNumber;
        public Contragents.Components.CompanyDropDown companySeller;
        public Contragents.Components.CompanyDropDown companyBuyer;
        public C1.Win.Calendar.C1DateEdit dateEditStop;
        public C1.Win.Calendar.C1DateEdit dateEditStart;
        public GrpcWinForms.Controls.SmartBox.SmartBox smartBoxCurrency;
    }
}
