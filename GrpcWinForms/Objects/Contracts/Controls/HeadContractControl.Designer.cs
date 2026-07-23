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
            dateTimePickerStart = new DateTimePicker();
            labelDateStop = new Label();
            dateTimePickerStop = new DateTimePicker();
            groupBoxMain = new GroupBox();
            companySeller = new GrpcWinForms.Objects.Contragents.Components.CompanyDropDown(components);
            companyBuyer = new GrpcWinForms.Objects.Contragents.Components.CompanyDropDown(components);
            labelCurrency = new Label();
            comboBoxCurrency = new C1.Win.Input.C1ComboBox();
            c1FlexGrid1 = new C1.Win.FlexGrid.C1FlexGrid();
            control1 = new Control();
            control2 = new Control();
            ((System.ComponentModel.ISupportInitialize)comboBoxContractType).BeginInit();
            groupBoxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)companySeller).BeginInit();
            ((System.ComponentModel.ISupportInitialize)companyBuyer).BeginInit();
            ((System.ComponentModel.ISupportInitialize)comboBoxCurrency).BeginInit();
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
            labelTaxNoBuyer.Location = new Point(366, 17);
            labelTaxNoBuyer.Name = "labelTaxNoBuyer";
            labelTaxNoBuyer.Size = new Size(95, 15);
            labelTaxNoBuyer.TabIndex = 2;
            labelTaxNoBuyer.Text = "ИНН / ПИН ФЛ:";
            labelTaxNoBuyer.TextAlign = ContentAlignment.MiddleRight;
            // 
            // textBoxTaxnoBuyer
            // 
            textBoxTaxnoBuyer.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            textBoxTaxnoBuyer.Location = new Point(467, 13);
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
            labelTaxnoSeller.Location = new Point(366, 46);
            labelTaxnoSeller.Name = "labelTaxnoSeller";
            labelTaxnoSeller.Size = new Size(95, 15);
            labelTaxnoSeller.TabIndex = 6;
            labelTaxnoSeller.Text = "ИНН / ПИН ФЛ:";
            labelTaxnoSeller.TextAlign = ContentAlignment.MiddleRight;
            // 
            // textBoxTaxnoSeller
            // 
            textBoxTaxnoSeller.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            textBoxTaxnoSeller.Location = new Point(467, 42);
            textBoxTaxnoSeller.Name = "textBoxTaxnoSeller";
            textBoxTaxnoSeller.ReadOnly = true;
            textBoxTaxnoSeller.Size = new Size(94, 23);
            textBoxTaxnoSeller.TabIndex = 7;
            // 
            // ContractType
            // 
            ContractType.AutoSize = true;
            ContractType.Location = new Point(10, 75);
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
            comboBoxContractType.Location = new Point(125, 71);
            comboBoxContractType.Name = "comboBoxContractType";
            comboBoxContractType.Size = new Size(113, 23);
            comboBoxContractType.TabIndex = 9;
            // 
            // labelNumber
            // 
            labelNumber.AutoSize = true;
            labelNumber.Location = new Point(10, 104);
            labelNumber.Name = "labelNumber";
            labelNumber.Size = new Size(106, 15);
            labelNumber.TabIndex = 10;
            labelNumber.Text = "Номер контракта:";
            labelNumber.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBoxNumber
            // 
            textBoxNumber.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxNumber.Location = new Point(125, 100);
            textBoxNumber.Name = "textBoxNumber";
            textBoxNumber.Size = new Size(113, 23);
            textBoxNumber.TabIndex = 13;
            // 
            // labelDateStart
            // 
            labelDateStart.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelDateStart.AutoSize = true;
            labelDateStart.Location = new Point(238, 104);
            labelDateStart.Name = "labelDateStart";
            labelDateStart.Size = new Size(22, 15);
            labelDateStart.TabIndex = 12;
            labelDateStart.Text = "от:";
            labelDateStart.TextAlign = ContentAlignment.MiddleRight;
            // 
            // dateTimePickerStart
            // 
            dateTimePickerStart.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dateTimePickerStart.Format = DateTimePickerFormat.Short;
            dateTimePickerStart.Location = new Point(266, 100);
            dateTimePickerStart.Name = "dateTimePickerStart";
            dateTimePickerStart.Size = new Size(94, 23);
            dateTimePickerStart.TabIndex = 15;
            // 
            // labelDateStop
            // 
            labelDateStop.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelDateStop.AutoSize = true;
            labelDateStop.Location = new Point(371, 104);
            labelDateStop.Name = "labelDateStop";
            labelDateStop.Size = new Size(90, 15);
            labelDateStop.TabIndex = 14;
            labelDateStop.Text = "Срок действия:";
            labelDateStop.TextAlign = ContentAlignment.MiddleRight;
            // 
            // dateTimePickerStop
            // 
            dateTimePickerStop.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dateTimePickerStop.Format = DateTimePickerFormat.Short;
            dateTimePickerStop.Location = new Point(467, 100);
            dateTimePickerStop.Name = "dateTimePickerStop";
            dateTimePickerStop.Size = new Size(94, 23);
            dateTimePickerStop.TabIndex = 16;
            // 
            // groupBoxMain
            // 
            groupBoxMain.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxMain.Controls.Add(companySeller);
            groupBoxMain.Controls.Add(companyBuyer);
            groupBoxMain.Controls.Add(dateTimePickerStop);
            groupBoxMain.Controls.Add(labelDateStop);
            groupBoxMain.Controls.Add(dateTimePickerStart);
            groupBoxMain.Controls.Add(labelDateStart);
            groupBoxMain.Controls.Add(textBoxNumber);
            groupBoxMain.Controls.Add(comboBoxContractType);
            groupBoxMain.Controls.Add(labelNumber);
            groupBoxMain.Controls.Add(labelBuyer);
            groupBoxMain.Controls.Add(labelCurrency);
            groupBoxMain.Controls.Add(comboBoxCurrency);
            groupBoxMain.Controls.Add(textBoxTaxnoBuyer);
            groupBoxMain.Controls.Add(ContractType);
            groupBoxMain.Controls.Add(textBoxTaxnoSeller);
            groupBoxMain.Controls.Add(labelTaxnoSeller);
            groupBoxMain.Controls.Add(labelTaxNoBuyer);
            groupBoxMain.Controls.Add(labelSeller);
            groupBoxMain.Location = new Point(3, 0);
            groupBoxMain.Name = "groupBoxMain";
            groupBoxMain.Size = new Size(569, 133);
            groupBoxMain.TabIndex = 16;
            groupBoxMain.TabStop = false;
            // 
            // companySeller
            // 
            companySeller.ButtonsSettings.CustomButton.Icon = new C1.Framework.C1BitmapIcon(null, new Size(16, 16), Color.Transparent, (Image)resources.GetObject("companySeller.ButtonsSettings.CustomButton.Icon"));
            companySeller.ButtonsSettings.CustomButton.Visible = true;
            companySeller.GetDataSourceFunc = null;
            companySeller.Location = new Point(125, 42);
            companySeller.Name = "companySeller";
            companySeller.ReadOnly = true;
            companySeller.Size = new Size(235, 23);
            companySeller.TabIndex = 18;
            companySeller.Value = "";
            // 
            // companyBuyer
            // 
            companyBuyer.ButtonsSettings.CustomButton.Icon = new C1.Framework.C1BitmapIcon(null, new Size(16, 16), Color.Transparent, (Image)resources.GetObject("companyBuyer.ButtonsSettings.CustomButton.Icon"));
            companyBuyer.ButtonsSettings.CustomButton.Visible = true;
            companyBuyer.GetDataSourceFunc = null;
            companyBuyer.Location = new Point(125, 13);
            companyBuyer.Name = "companyBuyer";
            companyBuyer.Size = new Size(235, 23);
            companyBuyer.TabIndex = 17;
            companyBuyer.Value = "";
            // 
            // labelCurrency
            // 
            labelCurrency.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelCurrency.AutoSize = true;
            labelCurrency.Location = new Point(247, 75);
            labelCurrency.Name = "labelCurrency";
            labelCurrency.Size = new Size(51, 15);
            labelCurrency.TabIndex = 16;
            labelCurrency.Text = "Валюта:";
            labelCurrency.TextAlign = ContentAlignment.MiddleRight;
            // 
            // comboBoxCurrency
            // 
            comboBoxCurrency.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            comboBoxCurrency.Location = new Point(304, 71);
            comboBoxCurrency.Name = "comboBoxCurrency";
            comboBoxCurrency.Size = new Size(56, 23);
            comboBoxCurrency.TabIndex = 11;
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
            MinimumSize = new Size(575, 136);
            Name = "HeadContractControl";
            Size = new Size(575, 136);
            ((System.ComponentModel.ISupportInitialize)comboBoxContractType).EndInit();
            groupBoxMain.ResumeLayout(false);
            groupBoxMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)companySeller).EndInit();
            ((System.ComponentModel.ISupportInitialize)companyBuyer).EndInit();
            ((System.ComponentModel.ISupportInitialize)comboBoxCurrency).EndInit();
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
        public DateTimePicker dateTimePickerStart;
        public DateTimePicker dateTimePickerStop;
        public C1.Win.Input.C1ComboBox comboBoxCurrency;
        public Contragents.Components.CompanyDropDown companySeller;
        public Contragents.Components.CompanyDropDown companyBuyer;
    }
}
