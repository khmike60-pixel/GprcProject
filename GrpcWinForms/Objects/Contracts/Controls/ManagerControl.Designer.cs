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
            c1DropDownControl2 = new C1.Win.Input.C1DropDownControl();
            tbComment = new TextBox();
            labelManagerType = new Label();
            empInittiator = new C1.Win.Input.C1DropDownControl();
            labelDescription = new Label();
            empExecutor = new C1.Win.Input.C1DropDownControl();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)cbProjectType).BeginInit();
            ((System.ComponentModel.ISupportInitialize)c1DropDownControl2).BeginInit();
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
            groupBox1.Controls.Add(c1DropDownControl2);
            groupBox1.Controls.Add(tbComment);
            groupBox1.Controls.Add(labelManagerType);
            groupBox1.Controls.Add(empInittiator);
            groupBox1.Controls.Add(labelDescription);
            groupBox1.Controls.Add(empExecutor);
            groupBox1.Location = new Point(3, 0);
            groupBox1.MinimumSize = new Size(569, 73);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(569, 73);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            // 
            // cbProjectType
            // 
            cbProjectType.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cbProjectType.AutoCompleteCustomSource.AddRange(new string[] { "стандарт", "проект", "распродажа" });
            cbProjectType.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBoxItem1.DisplayText = "стандарт";
            comboBoxItem2.DisplayText = "проект";
            comboBoxItem3.DisplayText = "распродажа";
            cbProjectType.Items.Add(comboBoxItem1);
            cbProjectType.Items.Add(comboBoxItem2);
            cbProjectType.Items.Add(comboBoxItem3);
            cbProjectType.Location = new Point(435, 15);
            cbProjectType.Name = "cbProjectType";
            cbProjectType.Size = new Size(122, 23);
            cbProjectType.TabIndex = 5;
            cbProjectType.Value = "";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(448, 48);
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
            labelInitiator.Location = new Point(181, 19);
            labelInitiator.Name = "labelInitiator";
            labelInitiator.Size = new Size(72, 15);
            labelInitiator.TabIndex = 2;
            labelInitiator.Text = "Инициатор:";
            labelInitiator.TextAlign = ContentAlignment.MiddleRight;
            // 
            // c1DropDownControl2
            // 
            c1DropDownControl2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            c1DropDownControl2.Location = new Point(503, 44);
            c1DropDownControl2.Name = "c1DropDownControl2";
            c1DropDownControl2.Size = new Size(54, 23);
            c1DropDownControl2.TabIndex = 9;
            // 
            // tbComment
            // 
            tbComment.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbComment.Location = new Point(121, 44);
            tbComment.Name = "tbComment";
            tbComment.Size = new Size(296, 23);
            tbComment.TabIndex = 7;
            tbComment.TextChanged += tbComment_TextChanged;
            // 
            // labelManagerType
            // 
            labelManagerType.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelManagerType.AutoSize = true;
            labelManagerType.Location = new Point(349, 19);
            labelManagerType.Name = "labelManagerType";
            labelManagerType.Size = new Size(80, 15);
            labelManagerType.TabIndex = 10;
            labelManagerType.Text = "Менедж. тип:";
            labelManagerType.TextAlign = ContentAlignment.MiddleRight;
            // 
            // empInittiator
            // 
            empInittiator.Location = new Point(259, 15);
            empInittiator.Name = "empInittiator";
            empInittiator.Size = new Size(54, 23);
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
            empExecutor.Location = new Point(121, 15);
            empExecutor.Name = "empExecutor";
            empExecutor.Size = new Size(54, 23);
            empExecutor.TabIndex = 1;
            // 
            // ManagerControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBox1);
            MinimumSize = new Size(575, 76);
            Name = "ManagerControl";
            Size = new Size(575, 76);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)cbProjectType).EndInit();
            ((System.ComponentModel.ISupportInitialize)c1DropDownControl2).EndInit();
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
        public C1.Win.Input.C1DropDownControl c1DropDownControl2;
        private C1.Win.Input.C1ComboBox cbProjectType;
    }
}
