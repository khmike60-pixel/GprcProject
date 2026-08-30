namespace GrpcWinForms.Objects.Contracts.Forms.Controls
{
    partial class ManagerControl
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
            C1.Win.Input.ComboBoxItem comboBoxItem1 = new C1.Win.Input.ComboBoxItem();
            C1.Win.Input.ComboBoxItem comboBoxItem2 = new C1.Win.Input.ComboBoxItem();
            C1.Win.Input.ComboBoxItem comboBoxItem3 = new C1.Win.Input.ComboBoxItem();
            groupBox1 = new GroupBox();
            cbProjectType = new C1.Win.Input.C1ComboBox();
            label1 = new Label();
            labelExecutor = new Label();
            labelInitiator = new Label();
            cddByCreate = new C1.Win.Input.C1DropDownControl();
            tbComment = new TextBox();
            labelManagerType = new Label();
            empInittiator = new C1.Win.Input.C1DropDownControl();
            labelDescription = new Label();
            empExecutor = new C1.Win.Input.C1DropDownControl();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)cbProjectType).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cddByCreate).BeginInit();
            ((System.ComponentModel.ISupportInitialize)empInittiator).BeginInit();
            ((System.ComponentModel.ISupportInitialize)empExecutor).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(cbProjectType);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(labelExecutor);
            groupBox1.Controls.Add(labelInitiator);
            groupBox1.Controls.Add(cddByCreate);
            groupBox1.Controls.Add(tbComment);
            groupBox1.Controls.Add(labelManagerType);
            groupBox1.Controls.Add(empInittiator);
            groupBox1.Controls.Add(labelDescription);
            groupBox1.Controls.Add(empExecutor);
            groupBox1.Location = new Point(3, 0);
            groupBox1.MinimumSize = new Size(569, 73);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(694, 73);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            // 
            // cbProjectType
            // 
            cbProjectType.AutoCompleteCustomSource.AddRange(new string[] { "стандарт", "проект", "распродажа" });
            cbProjectType.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBoxItem1.DisplayText = "стандарт";
            comboBoxItem2.DisplayText = "проект";
            comboBoxItem3.DisplayText = "распродажа";
            cbProjectType.Items.Add(comboBoxItem1);
            cbProjectType.Items.Add(comboBoxItem2);
            cbProjectType.Items.Add(comboBoxItem3);
            cbProjectType.Location = new Point(447, 15);
            cbProjectType.Name = "cbProjectType";
            cbProjectType.Size = new Size(99, 23);
            cbProjectType.TabIndex = 5;
            cbProjectType.Value = "";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(552, 19);
            label1.Name = "label1";
            label1.Size = new Size(49, 15);
            label1.TabIndex = 11;
            label1.Text = "Создал:";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // labelExecutor
            // 
            labelExecutor.AutoSize = true;
            labelExecutor.Location = new Point(6, 19);
            labelExecutor.Name = "labelExecutor";
            labelExecutor.Size = new Size(84, 15);
            labelExecutor.TabIndex = 0;
            labelExecutor.Text = "Исполнитель:";
            labelExecutor.TextAlign = ContentAlignment.MiddleRight;
            // 
            // labelInitiator
            // 
            labelInitiator.AutoSize = true;
            labelInitiator.Location = new Point(202, 19);
            labelInitiator.Name = "labelInitiator";
            labelInitiator.Size = new Size(72, 15);
            labelInitiator.TabIndex = 2;
            labelInitiator.Text = "Инициатор:";
            labelInitiator.TextAlign = ContentAlignment.MiddleRight;
            // 
            // cddByCreate
            // 
            cddByCreate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cddByCreate.ButtonsSettings.CustomButton.Icon = new C1.Framework.C1BitmapIcon(null, new Size(16, 16), Color.Transparent, Properties.Resources.icons8_multiply_16);
            cddByCreate.ButtonsSettings.CustomButton.Visible = true;
            cddByCreate.ButtonsSettings.DropDownButton.Visible = false;
            cddByCreate.ButtonsSettings.ModalButton.Visible = true;
            cddByCreate.Location = new Point(607, 15);
            cddByCreate.Name = "cddByCreate";
            cddByCreate.Size = new Size(75, 23);
            cddByCreate.TabIndex = 9;
            cddByCreate.Value = "МВХ";
            // 
            // tbComment
            // 
            tbComment.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbComment.Location = new Point(121, 45);
            tbComment.Name = "tbComment";
            tbComment.Size = new Size(561, 23);
            tbComment.TabIndex = 7;
            tbComment.TextChanged += tbComment_TextChanged;
            // 
            // labelManagerType
            // 
            labelManagerType.AutoSize = true;
            labelManagerType.Location = new Point(361, 19);
            labelManagerType.Name = "labelManagerType";
            labelManagerType.Size = new Size(80, 15);
            labelManagerType.TabIndex = 10;
            labelManagerType.Text = "Менедж. тип:";
            labelManagerType.TextAlign = ContentAlignment.MiddleRight;
            // 
            // empInittiator
            // 
            empInittiator.ButtonsSettings.CustomButton.Icon = new C1.Framework.C1BitmapIcon(null, new Size(16, 16), Color.Transparent, Properties.Resources.icons8_multiply_16);
            empInittiator.ButtonsSettings.CustomButton.Visible = true;
            empInittiator.ButtonsSettings.DropDownButton.Visible = false;
            empInittiator.ButtonsSettings.ModalButton.Visible = true;
            empInittiator.Location = new Point(280, 15);
            empInittiator.Name = "empInittiator";
            empInittiator.Size = new Size(75, 23);
            empInittiator.TabIndex = 3;
            // 
            // labelDescription
            // 
            labelDescription.AutoSize = true;
            labelDescription.Location = new Point(6, 48);
            labelDescription.Name = "labelDescription";
            labelDescription.Size = new Size(65, 15);
            labelDescription.TabIndex = 6;
            labelDescription.Text = "Описание:";
            labelDescription.TextAlign = ContentAlignment.MiddleRight;
            // 
            // empExecutor
            // 
            empExecutor.ButtonsSettings.CustomButton.Icon = new C1.Framework.C1BitmapIcon(null, new Size(16, 16), Color.Transparent, Properties.Resources.icons8_multiply_16);
            empExecutor.ButtonsSettings.CustomButton.Visible = true;
            empExecutor.ButtonsSettings.DropDownButton.Visible = false;
            empExecutor.ButtonsSettings.ModalButton.Visible = true;
            empExecutor.Location = new Point(121, 15);
            empExecutor.Name = "empExecutor";
            empExecutor.Size = new Size(75, 23);
            empExecutor.TabIndex = 1;
            // 
            // ManagerControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBox1);
            MinimumSize = new Size(700, 76);
            Name = "ManagerControl";
            Size = new Size(700, 76);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)cbProjectType).EndInit();
            ((System.ComponentModel.ISupportInitialize)cddByCreate).EndInit();
            ((System.ComponentModel.ISupportInitialize)empInittiator).EndInit();
            ((System.ComponentModel.ISupportInitialize)empExecutor).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label labelExecutor;
        private Label labelInitiator;
        private Label labelDescription;
        private Label labelManagerType;
        private Label label1;
        public C1.Win.Input.C1DropDownControl empExecutor;
        public C1.Win.Input.C1DropDownControl empInittiator;
        public TextBox tbComment;
        public C1.Win.Input.C1DropDownControl cddByCreate;
        private C1.Win.Input.C1ComboBox cbProjectType;
    }
}
