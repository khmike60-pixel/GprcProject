namespace GrpcWinForms.Objects.Contragents.Forms
{
    partial class EntityControl
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
            labelName = new Label();
            textBoxName = new TextBox();
            labelNameFull = new Label();
            textBoxNameFull = new TextBox();
            labelTaxNo = new Label();
            textBoxTaxno = new TextBox();
            labelCountry = new Label();
            c1DropDownControlCountry = new C1.Win.Input.C1DropDownControl();
            labelPrefix = new Label();
            textBoxPrefix = new TextBox();
            labelId = new Label();
            textBoxId = new TextBox();
            labelDate = new Label();
            dateTimePickerDateActualized = new DateTimePicker();
            labelVatCode = new Label();
            textBoxVatCode = new TextBox();
            label1 = new Label();
            textBoxNameLat = new TextBox();
            groupBoxMain = new GroupBox();
            groupBoxAddresses = new GroupBox();
            textBoxContactorPhone = new TextBox();
            labelContactorPhone = new Label();
            textBoxContactorPosition = new TextBox();
            labelContactPosition = new Label();
            labelContactor = new Label();
            textBoxContactor = new TextBox();
            textBoxSite = new TextBox();
            textBoxEmail = new TextBox();
            textBoxEntityPhone = new TextBox();
            labelSite = new Label();
            labelEmail = new Label();
            labelPhone = new Label();
            labelAddressFact = new Label();
            labelAddressLat = new Label();
            textBoxAddressFact = new TextBox();
            textBoxAddressLat = new TextBox();
            textBoxAddress = new TextBox();
            labelAddress = new Label();
            labelComment = new Label();
            textBoxComment = new TextBox();
            ((System.ComponentModel.ISupportInitialize)c1DropDownControlCountry).BeginInit();
            groupBoxMain.SuspendLayout();
            groupBoxAddresses.SuspendLayout();
            SuspendLayout();
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Location = new Point(8, 22);
            labelName.Name = "labelName";
            labelName.Size = new Size(138, 15);
            labelName.TabIndex = 0;
            labelName.Text = "Краткое наименование:";
            // 
            // textBoxName
            // 
            textBoxName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxName.Location = new Point(156, 18);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(184, 23);
            textBoxName.TabIndex = 1;
            // 
            // labelNameFull
            // 
            labelNameFull.AutoSize = true;
            labelNameFull.Location = new Point(8, 79);
            labelNameFull.Name = "labelNameFull";
            labelNameFull.Size = new Size(137, 15);
            labelNameFull.TabIndex = 8;
            labelNameFull.Text = "Полное наименование:";
            // 
            // textBoxNameFull
            // 
            textBoxNameFull.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxNameFull.Location = new Point(156, 76);
            textBoxNameFull.Name = "textBoxNameFull";
            textBoxNameFull.Size = new Size(324, 23);
            textBoxNameFull.TabIndex = 9;
            // 
            // labelTaxNo
            // 
            labelTaxNo.AutoSize = true;
            labelTaxNo.Location = new Point(107, 51);
            labelTaxNo.Name = "labelTaxNo";
            labelTaxNo.Size = new Size(37, 15);
            labelTaxNo.TabIndex = 4;
            labelTaxNo.Text = "ИНН:";
            // 
            // textBoxTaxno
            // 
            textBoxTaxno.Location = new Point(156, 47);
            textBoxTaxno.Name = "textBoxTaxno";
            textBoxTaxno.Size = new Size(107, 23);
            textBoxTaxno.TabIndex = 5;
            // 
            // labelCountry
            // 
            labelCountry.AutoSize = true;
            labelCountry.Location = new Point(24, 167);
            labelCountry.Name = "labelCountry";
            labelCountry.Size = new Size(122, 15);
            labelCountry.TabIndex = 16;
            labelCountry.Text = "Страна регистрации:";
            // 
            // c1DropDownControlCountry
            // 
            c1DropDownControlCountry.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            c1DropDownControlCountry.ButtonsSettings.ModalButton.Visible = true;
            c1DropDownControlCountry.ButtonsSettings.ModalButton.Width = 20;
            c1DropDownControlCountry.Location = new Point(156, 163);
            c1DropDownControlCountry.Name = "c1DropDownControlCountry";
            c1DropDownControlCountry.Size = new Size(160, 23);
            c1DropDownControlCountry.TabIndex = 17;
            // 
            // labelPrefix
            // 
            labelPrefix.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelPrefix.AutoSize = true;
            labelPrefix.Location = new Point(359, 138);
            labelPrefix.Name = "labelPrefix";
            labelPrefix.Size = new Size(60, 15);
            labelPrefix.TabIndex = 14;
            labelPrefix.Text = "Префикс:";
            labelPrefix.Click += labelPrefix_Click;
            // 
            // textBoxPrefix
            // 
            textBoxPrefix.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            textBoxPrefix.Location = new Point(425, 134);
            textBoxPrefix.Name = "textBoxPrefix";
            textBoxPrefix.Size = new Size(55, 23);
            textBoxPrefix.TabIndex = 15;
            // 
            // labelId
            // 
            labelId.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelId.AutoSize = true;
            labelId.Location = new Point(375, 22);
            labelId.Name = "labelId";
            labelId.Size = new Size(20, 15);
            labelId.TabIndex = 2;
            labelId.Text = "Id:";
            // 
            // textBoxId
            // 
            textBoxId.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            textBoxId.Location = new Point(401, 18);
            textBoxId.Name = "textBoxId";
            textBoxId.ReadOnly = true;
            textBoxId.Size = new Size(79, 23);
            textBoxId.TabIndex = 3;
            textBoxId.TextAlign = HorizontalAlignment.Right;
            // 
            // labelDate
            // 
            labelDate.AutoSize = true;
            labelDate.Location = new Point(24, 138);
            labelDate.Name = "labelDate";
            labelDate.Size = new Size(122, 15);
            labelDate.TabIndex = 12;
            labelDate.Text = "Данные действуют c:";
            // 
            // dateTimePickerDateActualized
            // 
            dateTimePickerDateActualized.Format = DateTimePickerFormat.Short;
            dateTimePickerDateActualized.Location = new Point(156, 134);
            dateTimePickerDateActualized.Name = "dateTimePickerDateActualized";
            dateTimePickerDateActualized.Size = new Size(87, 23);
            dateTimePickerDateActualized.TabIndex = 13;
            dateTimePickerDateActualized.Value = new DateTime(2000, 1, 1, 0, 0, 0, 0);
            // 
            // labelVatCode
            // 
            labelVatCode.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelVatCode.AutoSize = true;
            labelVatCode.Location = new Point(266, 51);
            labelVatCode.Name = "labelVatCode";
            labelVatCode.Size = new Size(95, 15);
            labelVatCode.TabIndex = 6;
            labelVatCode.Text = "Рег.номер НДС:";
            // 
            // textBoxVatCode
            // 
            textBoxVatCode.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            textBoxVatCode.Location = new Point(367, 47);
            textBoxVatCode.Name = "textBoxVatCode";
            textBoxVatCode.Size = new Size(113, 23);
            textBoxVatCode.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 108);
            label1.Name = "label1";
            label1.Size = new Size(131, 15);
            label1.TabIndex = 10;
            label1.Text = "Наименование латин.:";
            // 
            // textBoxNameLat
            // 
            textBoxNameLat.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxNameLat.Location = new Point(156, 105);
            textBoxNameLat.Name = "textBoxNameLat";
            textBoxNameLat.Size = new Size(324, 23);
            textBoxNameLat.TabIndex = 11;
            // 
            // groupBoxMain
            // 
            groupBoxMain.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxMain.BackgroundImageLayout = ImageLayout.None;
            groupBoxMain.Controls.Add(dateTimePickerDateActualized);
            groupBoxMain.Controls.Add(textBoxNameLat);
            groupBoxMain.Controls.Add(labelName);
            groupBoxMain.Controls.Add(label1);
            groupBoxMain.Controls.Add(textBoxName);
            groupBoxMain.Controls.Add(labelVatCode);
            groupBoxMain.Controls.Add(labelNameFull);
            groupBoxMain.Controls.Add(textBoxNameFull);
            groupBoxMain.Controls.Add(labelDate);
            groupBoxMain.Controls.Add(labelTaxNo);
            groupBoxMain.Controls.Add(textBoxId);
            groupBoxMain.Controls.Add(textBoxTaxno);
            groupBoxMain.Controls.Add(labelId);
            groupBoxMain.Controls.Add(textBoxVatCode);
            groupBoxMain.Controls.Add(textBoxPrefix);
            groupBoxMain.Controls.Add(labelCountry);
            groupBoxMain.Controls.Add(labelPrefix);
            groupBoxMain.Controls.Add(c1DropDownControlCountry);
            groupBoxMain.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            groupBoxMain.ForeColor = SystemColors.ControlText;
            groupBoxMain.Location = new Point(3, 3);
            groupBoxMain.MinimumSize = new Size(488, 194);
            groupBoxMain.Name = "groupBoxMain";
            groupBoxMain.Size = new Size(488, 194);
            groupBoxMain.TabIndex = 0;
            groupBoxMain.TabStop = false;
            groupBoxMain.Text = "Основные реквизиты";
            // 
            // groupBoxAddresses
            // 
            groupBoxAddresses.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxAddresses.Controls.Add(textBoxContactorPhone);
            groupBoxAddresses.Controls.Add(labelContactorPhone);
            groupBoxAddresses.Controls.Add(textBoxContactorPosition);
            groupBoxAddresses.Controls.Add(labelContactPosition);
            groupBoxAddresses.Controls.Add(labelContactor);
            groupBoxAddresses.Controls.Add(textBoxContactor);
            groupBoxAddresses.Controls.Add(textBoxSite);
            groupBoxAddresses.Controls.Add(textBoxEmail);
            groupBoxAddresses.Controls.Add(textBoxEntityPhone);
            groupBoxAddresses.Controls.Add(labelSite);
            groupBoxAddresses.Controls.Add(labelEmail);
            groupBoxAddresses.Controls.Add(labelPhone);
            groupBoxAddresses.Controls.Add(labelAddressFact);
            groupBoxAddresses.Controls.Add(labelAddressLat);
            groupBoxAddresses.Controls.Add(textBoxAddressFact);
            groupBoxAddresses.Controls.Add(textBoxAddressLat);
            groupBoxAddresses.Controls.Add(textBoxAddress);
            groupBoxAddresses.Controls.Add(labelAddress);
            groupBoxAddresses.Location = new Point(3, 203);
            groupBoxAddresses.Name = "groupBoxAddresses";
            groupBoxAddresses.Size = new Size(488, 218);
            groupBoxAddresses.TabIndex = 1;
            groupBoxAddresses.TabStop = false;
            groupBoxAddresses.Text = "Адреса и контакты";
            // 
            // textBoxContactorPhone
            // 
            textBoxContactorPhone.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            textBoxContactorPhone.Location = new Point(367, 189);
            textBoxContactorPhone.Name = "textBoxContactorPhone";
            textBoxContactorPhone.Size = new Size(113, 23);
            textBoxContactorPhone.TabIndex = 18;
            // 
            // labelContactorPhone
            // 
            labelContactorPhone.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelContactorPhone.AutoSize = true;
            labelContactorPhone.Location = new Point(303, 193);
            labelContactorPhone.Name = "labelContactorPhone";
            labelContactorPhone.Size = new Size(58, 15);
            labelContactorPhone.TabIndex = 17;
            labelContactorPhone.Text = "Телефон:";
            // 
            // textBoxContactorPosition
            // 
            textBoxContactorPosition.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxContactorPosition.Location = new Point(156, 189);
            textBoxContactorPosition.Name = "textBoxContactorPosition";
            textBoxContactorPosition.Size = new Size(141, 23);
            textBoxContactorPosition.TabIndex = 16;
            // 
            // labelContactPosition
            // 
            labelContactPosition.AutoSize = true;
            labelContactPosition.Location = new Point(22, 193);
            labelContactPosition.Name = "labelContactPosition";
            labelContactPosition.Size = new Size(123, 15);
            labelContactPosition.TabIndex = 15;
            labelContactPosition.Text = "Должность контакта:";
            // 
            // labelContactor
            // 
            labelContactor.AutoSize = true;
            labelContactor.Location = new Point(39, 164);
            labelContactor.Name = "labelContactor";
            labelContactor.Size = new Size(104, 15);
            labelContactor.TabIndex = 13;
            labelContactor.Text = "Контактное лицо:";
            // 
            // textBoxContactor
            // 
            textBoxContactor.Location = new Point(156, 161);
            textBoxContactor.Name = "textBoxContactor";
            textBoxContactor.Size = new Size(324, 23);
            textBoxContactor.TabIndex = 14;
            // 
            // textBoxSite
            // 
            textBoxSite.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxSite.Location = new Point(156, 132);
            textBoxSite.Name = "textBoxSite";
            textBoxSite.Size = new Size(324, 23);
            textBoxSite.TabIndex = 11;
            // 
            // textBoxEmail
            // 
            textBoxEmail.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            textBoxEmail.Location = new Point(332, 103);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(148, 23);
            textBoxEmail.TabIndex = 9;
            // 
            // textBoxEntityPhone
            // 
            textBoxEntityPhone.Location = new Point(156, 103);
            textBoxEntityPhone.Name = "textBoxEntityPhone";
            textBoxEntityPhone.Size = new Size(120, 23);
            textBoxEntityPhone.TabIndex = 7;
            // 
            // labelSite
            // 
            labelSite.AutoSize = true;
            labelSite.Location = new Point(107, 135);
            labelSite.Name = "labelSite";
            labelSite.Size = new Size(36, 15);
            labelSite.TabIndex = 10;
            labelSite.Text = "Сайт:";
            // 
            // labelEmail
            // 
            labelEmail.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelEmail.AutoSize = true;
            labelEmail.Location = new Point(282, 106);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new Size(44, 15);
            labelEmail.TabIndex = 8;
            labelEmail.Text = "E-Mail:";
            // 
            // labelPhone
            // 
            labelPhone.AutoSize = true;
            labelPhone.Location = new Point(88, 106);
            labelPhone.Name = "labelPhone";
            labelPhone.Size = new Size(58, 15);
            labelPhone.TabIndex = 6;
            labelPhone.Text = "Телефон:";
            // 
            // labelAddressFact
            // 
            labelAddressFact.AutoSize = true;
            labelAddressFact.Location = new Point(28, 77);
            labelAddressFact.Name = "labelAddressFact";
            labelAddressFact.Size = new Size(116, 15);
            labelAddressFact.TabIndex = 4;
            labelAddressFact.Text = "Фактический адрес:";
            // 
            // labelAddressLat
            // 
            labelAddressLat.AutoSize = true;
            labelAddressLat.Location = new Point(39, 49);
            labelAddressLat.Name = "labelAddressLat";
            labelAddressLat.Size = new Size(105, 15);
            labelAddressLat.TabIndex = 2;
            labelAddressLat.Text = "Адрес латиницей:";
            // 
            // textBoxAddressFact
            // 
            textBoxAddressFact.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxAddressFact.Location = new Point(156, 74);
            textBoxAddressFact.Name = "textBoxAddressFact";
            textBoxAddressFact.Size = new Size(324, 23);
            textBoxAddressFact.TabIndex = 5;
            // 
            // textBoxAddressLat
            // 
            textBoxAddressLat.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxAddressLat.Location = new Point(156, 45);
            textBoxAddressLat.Name = "textBoxAddressLat";
            textBoxAddressLat.Size = new Size(324, 23);
            textBoxAddressLat.TabIndex = 3;
            // 
            // textBoxAddress
            // 
            textBoxAddress.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxAddress.Location = new Point(156, 16);
            textBoxAddress.Name = "textBoxAddress";
            textBoxAddress.Size = new Size(324, 23);
            textBoxAddress.TabIndex = 1;
            // 
            // labelAddress
            // 
            labelAddress.AutoSize = true;
            labelAddress.Location = new Point(22, 19);
            labelAddress.Name = "labelAddress";
            labelAddress.Size = new Size(122, 15);
            labelAddress.TabIndex = 0;
            labelAddress.Text = "Юридический адрес:";
            // 
            // labelComment
            // 
            labelComment.AutoSize = true;
            labelComment.Location = new Point(59, 436);
            labelComment.Name = "labelComment";
            labelComment.Size = new Size(87, 15);
            labelComment.TabIndex = 2;
            labelComment.Text = "Комментарий:";
            // 
            // textBoxComment
            // 
            textBoxComment.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxComment.Location = new Point(159, 432);
            textBoxComment.Name = "textBoxComment";
            textBoxComment.Size = new Size(324, 23);
            textBoxComment.TabIndex = 3;
            // 
            // EntityControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(textBoxComment);
            Controls.Add(labelComment);
            Controls.Add(groupBoxAddresses);
            Controls.Add(groupBoxMain);
            MinimumSize = new Size(494, 461);
            Name = "EntityControl";
            Size = new Size(494, 461);
            ((System.ComponentModel.ISupportInitialize)c1DropDownControlCountry).EndInit();
            groupBoxMain.ResumeLayout(false);
            groupBoxMain.PerformLayout();
            groupBoxAddresses.ResumeLayout(false);
            groupBoxAddresses.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelName;
        private Label labelNameFull;
        private Label labelTaxNo;
        private Label labelCountry;
        private Label labelPrefix;
        private Label labelId;
        public TextBox textBoxName;
        public TextBox textBoxNameFull;
        public TextBox textBoxTaxno;
        public C1.Win.Input.C1DropDownControl c1DropDownControlCountry;
        public TextBox textBoxPrefix;
        public TextBox textBoxId;
        private Label labelDate;
        public DateTimePicker dateTimePickerDateActualized;
        private Label labelVatCode;
        public TextBox textBox1;
        private Label label1;
        public TextBox textBoxNameLat;
        private GroupBox groupBoxMain;
        private GroupBox groupBoxAddresses;
        private Label labelAddressLat;
        private Label labelAddress;
        private Label labelPhone;
        private Label labelAddressFact;
        private Label labelSite;
        private Label labelEmail;
        private Label labelContactor;
        private Label labelContactorPhone;
        private Label labelContactPosition;
        private Label labelComment;
        public TextBox textBoxAddress;
        public TextBox textBoxAddressFact;
        public TextBox textBox2;
        public TextBox textBoxEmail;
        public TextBox textBox3;
        public TextBox textBoxContactor;
        public TextBox textBoxSite;
        public TextBox textBox5;
        public TextBox textBoxContactorPosition;
        public TextBox textBoxComment;
        public TextBox textBoxVatCode;
        public TextBox textBoxContactorPhone;
        public TextBox textBoxEntityPhone;
        public TextBox textBoxAddressLat;
    }
}
