namespace GrpcWinForms.Objects.Contragents.Forms
{
    partial class PersonControl
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
            groupBoxMain = new GroupBox();
            textBoxInps = new TextBox();
            labelINPS = new Label();
            textBoxTaxno = new TextBox();
            labelTaxNo = new Label();
            textBoxPrefix = new TextBox();
            labelPrefix = new Label();
            textBoxNameShort = new TextBox();
            labelNameShort = new Label();
            textBoxNameLat = new TextBox();
            c1LabelNameLat = new C1.Win.Input.C1Label();
            textBoxName = new TextBox();
            labelName = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            labelFirstName = new Label();
            textBoxPatronymic = new TextBox();
            textBoxSurName = new TextBox();
            labelpatronymic = new Label();
            textBoxFirstName = new TextBox();
            labelSurName = new Label();
            groupBoxPassport = new GroupBox();
            textBoxAddressResidence = new TextBox();
            labelAddressResidence = new Label();
            textBoxAddress = new TextBox();
            labelAddress = new Label();
            textBoxIssuedBy = new TextBox();
            labelIssuedBy = new Label();
            dateTimePickerExpiredDate = new DateTimePicker();
            labelExpiredDate = new Label();
            dateTimePickerPassportDate = new DateTimePicker();
            labelPassportDate = new Label();
            textBoxPassportNumber = new TextBox();
            labelPassportNumber = new Label();
            c1ContextMenu1 = new C1.Win.Command.C1ContextMenu();
            c1CommandLink1 = new C1.Win.Command.C1CommandLink();
            c1CommandHolder1 = new C1.Win.Command.C1CommandHolder();
            c1ContextMenu2 = new C1.Win.Command.C1ContextMenu();
            c1CommandLink2 = new C1.Win.Command.C1CommandLink();
            groupBoxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)c1LabelNameLat).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            groupBoxPassport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)c1CommandHolder1).BeginInit();
            SuspendLayout();
            // 
            // groupBoxMain
            // 
            groupBoxMain.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxMain.Controls.Add(textBoxInps);
            groupBoxMain.Controls.Add(labelINPS);
            groupBoxMain.Controls.Add(textBoxTaxno);
            groupBoxMain.Controls.Add(labelTaxNo);
            groupBoxMain.Controls.Add(textBoxPrefix);
            groupBoxMain.Controls.Add(labelPrefix);
            groupBoxMain.Controls.Add(textBoxNameShort);
            groupBoxMain.Controls.Add(labelNameShort);
            groupBoxMain.Controls.Add(textBoxNameLat);
            groupBoxMain.Controls.Add(c1LabelNameLat);
            groupBoxMain.Controls.Add(textBoxName);
            groupBoxMain.Controls.Add(labelName);
            groupBoxMain.Controls.Add(tableLayoutPanel1);
            groupBoxMain.Location = new Point(3, 3);
            groupBoxMain.Name = "groupBoxMain";
            groupBoxMain.Size = new Size(488, 173);
            groupBoxMain.TabIndex = 0;
            groupBoxMain.TabStop = false;
            groupBoxMain.Text = "Основные сведения";
            // 
            // textBoxInps
            // 
            textBoxInps.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            textBoxInps.Location = new Point(384, 141);
            textBoxInps.Name = "textBoxInps";
            textBoxInps.Size = new Size(100, 23);
            textBoxInps.TabIndex = 18;
            // 
            // labelINPS
            // 
            labelINPS.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelINPS.AutoSize = true;
            labelINPS.Location = new Point(333, 144);
            labelINPS.Name = "labelINPS";
            labelINPS.Size = new Size(45, 15);
            labelINPS.TabIndex = 17;
            labelINPS.Text = "ИНПС:";
            // 
            // textBoxTaxno
            // 
            textBoxTaxno.Location = new Point(156, 141);
            textBoxTaxno.Name = "textBoxTaxno";
            textBoxTaxno.Size = new Size(100, 23);
            textBoxTaxno.TabIndex = 16;
            // 
            // labelTaxNo
            // 
            labelTaxNo.AutoSize = true;
            labelTaxNo.Location = new Point(6, 144);
            labelTaxNo.Name = "labelTaxNo";
            labelTaxNo.Size = new Size(144, 15);
            labelTaxNo.TabIndex = 1;
            labelTaxNo.Text = "Налог. номер (ПИН ФЛ):";
            // 
            // textBoxPrefix
            // 
            textBoxPrefix.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            textBoxPrefix.Location = new Point(431, 112);
            textBoxPrefix.Name = "textBoxPrefix";
            textBoxPrefix.Size = new Size(53, 23);
            textBoxPrefix.TabIndex = 15;
            // 
            // labelPrefix
            // 
            labelPrefix.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelPrefix.AutoSize = true;
            labelPrefix.Location = new Point(363, 115);
            labelPrefix.Name = "labelPrefix";
            labelPrefix.Size = new Size(60, 15);
            labelPrefix.TabIndex = 14;
            labelPrefix.Text = "Префикс:";
            // 
            // textBoxNameShort
            // 
            textBoxNameShort.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxNameShort.Location = new Point(156, 112);
            textBoxNameShort.Name = "textBoxNameShort";
            textBoxNameShort.Size = new Size(157, 23);
            textBoxNameShort.TabIndex = 13;
            // 
            // labelNameShort
            // 
            labelNameShort.AutoSize = true;
            labelNameShort.Location = new Point(55, 115);
            labelNameShort.Name = "labelNameShort";
            labelNameShort.Size = new Size(93, 15);
            labelNameShort.TabIndex = 12;
            labelNameShort.Text = "Краткие Ф.И.О.:";
            // 
            // textBoxNameLat
            // 
            textBoxNameLat.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxNameLat.Location = new Point(156, 83);
            textBoxNameLat.Name = "textBoxNameLat";
            textBoxNameLat.Size = new Size(329, 23);
            textBoxNameLat.TabIndex = 11;
            // 
            // c1LabelNameLat
            // 
            c1LabelNameLat.AutoSize = true;
            c1LabelNameLat.Location = new Point(7, 87);
            c1LabelNameLat.Name = "c1LabelNameLat";
            c1LabelNameLat.Size = new Size(143, 15);
            c1LabelNameLat.TabIndex = 10;
            c1LabelNameLat.Text = "Фамилия И.О. латиницей:";
            // 
            // textBoxName
            // 
            textBoxName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxName.Location = new Point(156, 54);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(329, 23);
            textBoxName.TabIndex = 9;
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Location = new Point(6, 57);
            labelName.Name = "labelName";
            labelName.Size = new Size(142, 15);
            labelName.TabIndex = 8;
            labelName.Text = "Фамилия Имя Отчество:";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 6;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 65F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 65F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.Controls.Add(labelFirstName, 2, 0);
            tableLayoutPanel1.Controls.Add(textBoxPatronymic, 5, 0);
            tableLayoutPanel1.Controls.Add(textBoxSurName, 1, 0);
            tableLayoutPanel1.Controls.Add(labelpatronymic, 4, 0);
            tableLayoutPanel1.Controls.Add(textBoxFirstName, 3, 0);
            tableLayoutPanel1.Controls.Add(labelSurName, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(3, 19);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(482, 29);
            tableLayoutPanel1.TabIndex = 7;
            // 
            // labelFirstName
            // 
            labelFirstName.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            labelFirstName.AutoSize = true;
            labelFirstName.Location = new Point(172, 7);
            labelFirstName.Name = "labelFirstName";
            labelFirstName.Size = new Size(34, 15);
            labelFirstName.TabIndex = 2;
            labelFirstName.Text = "Имя";
            // 
            // textBoxPatronymic
            // 
            textBoxPatronymic.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxPatronymic.Location = new Point(381, 3);
            textBoxPatronymic.Name = "textBoxPatronymic";
            textBoxPatronymic.Size = new Size(98, 23);
            textBoxPatronymic.TabIndex = 5;
            // 
            // textBoxSurName
            // 
            textBoxSurName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxSurName.Location = new Point(68, 3);
            textBoxSurName.Name = "textBoxSurName";
            textBoxSurName.Size = new Size(98, 23);
            textBoxSurName.TabIndex = 1;
            // 
            // labelpatronymic
            // 
            labelpatronymic.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            labelpatronymic.AutoSize = true;
            labelpatronymic.Location = new Point(316, 7);
            labelpatronymic.Name = "labelpatronymic";
            labelpatronymic.Size = new Size(59, 15);
            labelpatronymic.TabIndex = 4;
            labelpatronymic.Text = "Отчество";
            // 
            // textBoxFirstName
            // 
            textBoxFirstName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxFirstName.Location = new Point(212, 3);
            textBoxFirstName.Name = "textBoxFirstName";
            textBoxFirstName.Size = new Size(98, 23);
            textBoxFirstName.TabIndex = 3;
            // 
            // labelSurName
            // 
            labelSurName.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            labelSurName.AutoSize = true;
            labelSurName.Location = new Point(3, 7);
            labelSurName.Name = "labelSurName";
            labelSurName.Size = new Size(59, 15);
            labelSurName.TabIndex = 0;
            labelSurName.Text = "Фамилия";
            labelSurName.Click += label1_Click;
            // 
            // groupBoxPassport
            // 
            groupBoxPassport.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxPassport.Controls.Add(textBoxAddressResidence);
            groupBoxPassport.Controls.Add(labelAddressResidence);
            groupBoxPassport.Controls.Add(textBoxAddress);
            groupBoxPassport.Controls.Add(labelAddress);
            groupBoxPassport.Controls.Add(textBoxIssuedBy);
            groupBoxPassport.Controls.Add(labelIssuedBy);
            groupBoxPassport.Controls.Add(dateTimePickerExpiredDate);
            groupBoxPassport.Controls.Add(labelExpiredDate);
            groupBoxPassport.Controls.Add(dateTimePickerPassportDate);
            groupBoxPassport.Controls.Add(labelPassportDate);
            groupBoxPassport.Controls.Add(textBoxPassportNumber);
            groupBoxPassport.Controls.Add(labelPassportNumber);
            groupBoxPassport.Location = new Point(3, 182);
            groupBoxPassport.Name = "groupBoxPassport";
            groupBoxPassport.Size = new Size(488, 140);
            groupBoxPassport.TabIndex = 1;
            groupBoxPassport.TabStop = false;
            groupBoxPassport.Text = "Паспортные данные";
            // 
            // textBoxAddressResidence
            // 
            textBoxAddressResidence.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxAddressResidence.Location = new Point(87, 104);
            textBoxAddressResidence.Name = "textBoxAddressResidence";
            textBoxAddressResidence.Size = new Size(398, 23);
            textBoxAddressResidence.TabIndex = 11;
            // 
            // labelAddressResidence
            // 
            labelAddressResidence.AutoSize = true;
            labelAddressResidence.Location = new Point(7, 107);
            labelAddressResidence.Name = "labelAddressResidence";
            labelAddressResidence.Size = new Size(72, 15);
            labelAddressResidence.TabIndex = 10;
            labelAddressResidence.Text = "Проживает:";
            // 
            // textBoxAddress
            // 
            textBoxAddress.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxAddress.Location = new Point(87, 75);
            textBoxAddress.Name = "textBoxAddress";
            textBoxAddress.Size = new Size(398, 23);
            textBoxAddress.TabIndex = 9;
            // 
            // labelAddress
            // 
            labelAddress.AutoSize = true;
            labelAddress.Location = new Point(7, 78);
            labelAddress.Name = "labelAddress";
            labelAddress.Size = new Size(43, 15);
            labelAddress.TabIndex = 8;
            labelAddress.Text = "Адрес:";
            // 
            // textBoxIssuedBy
            // 
            textBoxIssuedBy.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxIssuedBy.Location = new Point(87, 46);
            textBoxIssuedBy.Name = "textBoxIssuedBy";
            textBoxIssuedBy.Size = new Size(398, 23);
            textBoxIssuedBy.TabIndex = 7;
            // 
            // labelIssuedBy
            // 
            labelIssuedBy.AutoSize = true;
            labelIssuedBy.Location = new Point(7, 49);
            labelIssuedBy.Name = "labelIssuedBy";
            labelIssuedBy.Size = new Size(45, 15);
            labelIssuedBy.TabIndex = 6;
            labelIssuedBy.Text = "Выдан:";
            // 
            // dateTimePickerExpiredDate
            // 
            dateTimePickerExpiredDate.Format = DateTimePickerFormat.Short;
            dateTimePickerExpiredDate.Location = new Point(400, 17);
            dateTimePickerExpiredDate.Name = "dateTimePickerExpiredDate";
            dateTimePickerExpiredDate.Size = new Size(85, 23);
            dateTimePickerExpiredDate.TabIndex = 5;
            dateTimePickerExpiredDate.Value = new DateTime(2099, 1, 1, 0, 0, 0, 0);
            // 
            // labelExpiredDate
            // 
            labelExpiredDate.AutoSize = true;
            labelExpiredDate.Location = new Point(334, 21);
            labelExpiredDate.Name = "labelExpiredDate";
            labelExpiredDate.Size = new Size(60, 15);
            labelExpiredDate.TabIndex = 4;
            labelExpiredDate.Text = "Деств. до:";
            // 
            // dateTimePickerPassportDate
            // 
            dateTimePickerPassportDate.Format = DateTimePickerFormat.Short;
            dateTimePickerPassportDate.Location = new Point(243, 17);
            dateTimePickerPassportDate.Name = "dateTimePickerPassportDate";
            dateTimePickerPassportDate.Size = new Size(85, 23);
            dateTimePickerPassportDate.TabIndex = 3;
            dateTimePickerPassportDate.Value = new DateTime(2000, 1, 1, 0, 0, 0, 0);
            // 
            // labelPassportDate
            // 
            labelPassportDate.AutoSize = true;
            labelPassportDate.Location = new Point(161, 20);
            labelPassportDate.Name = "labelPassportDate";
            labelPassportDate.Size = new Size(76, 15);
            labelPassportDate.TabIndex = 2;
            labelPassportDate.Text = "Дата выдачи";
            // 
            // textBoxPassportNumber
            // 
            textBoxPassportNumber.Location = new Point(87, 17);
            textBoxPassportNumber.Name = "textBoxPassportNumber";
            textBoxPassportNumber.Size = new Size(68, 23);
            textBoxPassportNumber.TabIndex = 1;
            // 
            // labelPassportNumber
            // 
            labelPassportNumber.AutoSize = true;
            labelPassportNumber.Location = new Point(6, 21);
            labelPassportNumber.Name = "labelPassportNumber";
            labelPassportNumber.Size = new Size(57, 15);
            labelPassportNumber.TabIndex = 0;
            labelPassportNumber.Text = "Паспорт:";
            // 
            // c1ContextMenu1
            // 
            c1ContextMenu1.CommandLinks.AddRange(new C1.Win.Command.C1CommandLink[] { c1CommandLink1 });
            c1ContextMenu1.Name = "c1ContextMenu1";
            c1ContextMenu1.ShortcutText = "";
            // 
            // c1CommandLink1
            // 
            c1CommandLink1.Text = "New Command";
            // 
            // c1CommandHolder1
            // 
            c1CommandHolder1.Commands.Add(c1ContextMenu1);
            c1CommandHolder1.Commands.Add(c1ContextMenu2);
            c1CommandHolder1.Owner = this;
            // 
            // c1ContextMenu2
            // 
            c1ContextMenu2.CommandLinks.AddRange(new C1.Win.Command.C1CommandLink[] { c1CommandLink2 });
            c1ContextMenu2.Name = "c1ContextMenu2";
            c1ContextMenu2.ShortcutText = "";
            // 
            // c1CommandLink2
            // 
            c1CommandLink2.Text = "New Command";
            // 
            // PersonControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBoxPassport);
            Controls.Add(groupBoxMain);
            Name = "PersonControl";
            Size = new Size(494, 324);
            groupBoxMain.ResumeLayout(false);
            groupBoxMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)c1LabelNameLat).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            groupBoxPassport.ResumeLayout(false);
            groupBoxPassport.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)c1CommandHolder1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBoxMain;
        private Label labelSurName;
        private Label labelpatronymic;
        private Label labelFirstName;
        private TableLayoutPanel tableLayoutPanel1;
        private Label labelName;
        private C1.Win.Input.C1Label c1LabelNameLat;
        private Label labelNameShort;
        private Label labelTaxNo;
        private Label labelPrefix;
        private Label labelINPS;
        private GroupBox groupBoxPassport;
        private Label labelPassportNumber;
        private Label labelPassportDate;
        private Label labelExpiredDate;
        private Label labelIssuedBy;
        private Label labelAddressResidence;
        private Label labelAddress;
        private C1.Win.Command.C1ContextMenu c1ContextMenu1;
        private C1.Win.Command.C1CommandLink c1CommandLink1;
        private C1.Win.Command.C1CommandHolder c1CommandHolder1;
        private C1.Win.Command.C1ContextMenu c1ContextMenu2;
        private C1.Win.Command.C1CommandLink c1CommandLink2;
        public DateTimePicker dateTimePickerPassportDate;
        public TextBox textBoxPassportNumber;
        public DateTimePicker dateTimePickerExpiredDate;
        public TextBox textBoxAddress;
        public TextBox textBoxIssuedBy;
        public TextBox textBoxAddressResidence;
        public TextBox textBoxFirstName;
        public TextBox textBoxSurName;
        public TextBox textBoxPatronymic;
        public TextBox textBoxName;
        public TextBox textBoxNameShort;
        public TextBox textBoxNameLat;
        public TextBox textBoxTaxno;
        public TextBox textBoxPrefix;
        public TextBox textBoxInps;
    }
}
