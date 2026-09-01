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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManagerControl));
            C1.Win.Input.ComboBoxItem comboBoxItem1 = new C1.Win.Input.ComboBoxItem();
            C1.Win.Input.ComboBoxItem comboBoxItem2 = new C1.Win.Input.ComboBoxItem();
            C1.Win.Input.ComboBoxItem comboBoxItem3 = new C1.Win.Input.ComboBoxItem();
            groupBox1 = new GroupBox();
            smartBoxCreator = new GrpcWinForms.Controls.SmartBox.SmartBox(components);
            smartBoxExecutor = new GrpcWinForms.Controls.SmartBox.SmartBox(components);
            smartBoxInitiator = new GrpcWinForms.Controls.SmartBox.SmartBox(components);
            cbProjectType = new C1.Win.Input.C1ComboBox();
            label1 = new Label();
            labelExecutor = new Label();
            labelInitiator = new Label();
            tbComment = new TextBox();
            labelManagerType = new Label();
            labelDescription = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)smartBoxCreator).BeginInit();
            ((System.ComponentModel.ISupportInitialize)smartBoxExecutor).BeginInit();
            ((System.ComponentModel.ISupportInitialize)smartBoxInitiator).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cbProjectType).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(smartBoxCreator);
            groupBox1.Controls.Add(smartBoxExecutor);
            groupBox1.Controls.Add(smartBoxInitiator);
            groupBox1.Controls.Add(cbProjectType);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(labelExecutor);
            groupBox1.Controls.Add(labelInitiator);
            groupBox1.Controls.Add(tbComment);
            groupBox1.Controls.Add(labelManagerType);
            groupBox1.Controls.Add(labelDescription);
            groupBox1.Location = new Point(3, 0);
            groupBox1.MinimumSize = new Size(569, 73);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(734, 73);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            // 
            // smartBoxCreator
            // 
            smartBoxCreator.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            smartBoxCreator.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            smartBoxCreator.AutoCompleteSource = AutoCompleteSource.ListItems;
            smartBoxCreator.AutoSuggestMode = C1.Win.Input.AutoSuggestMode.Contains;
            smartBoxCreator.ButtonsSettings.CustomButton.Icon = new C1.Framework.C1BitmapIcon(null, new Size(16, 16), Color.Transparent, (Image)resources.GetObject("smartBoxCreator.ButtonsSettings.CustomButton.Icon"));
            smartBoxCreator.ButtonsSettings.CustomButton.Visible = true;
            smartBoxCreator.ButtonsSettings.ModalButton.Visible = true;
            smartBoxCreator.Location = new Point(638, 15);
            smartBoxCreator.ModalForm = null;
            smartBoxCreator.Name = "smartBoxCreator";
            smartBoxCreator.NullEnable = true;
            smartBoxCreator.Size = new Size(90, 23);
            smartBoxCreator.TabIndex = 4;
            smartBoxCreator.Value = "";
            // 
            // smartBoxExecutor
            // 
            smartBoxExecutor.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            smartBoxExecutor.AutoCompleteSource = AutoCompleteSource.ListItems;
            smartBoxExecutor.AutoSuggestMode = C1.Win.Input.AutoSuggestMode.Contains;
            smartBoxExecutor.ButtonsSettings.CustomButton.Icon = new C1.Framework.C1BitmapIcon(null, new Size(16, 16), Color.Transparent, (Image)resources.GetObject("smartBoxExecutor.ButtonsSettings.CustomButton.Icon"));
            smartBoxExecutor.ButtonsSettings.CustomButton.Visible = true;
            smartBoxExecutor.ButtonsSettings.ModalButton.Visible = true;
            smartBoxExecutor.Location = new Point(121, 15);
            smartBoxExecutor.ModalForm = null;
            smartBoxExecutor.Name = "smartBoxExecutor";
            smartBoxExecutor.NullEnable = true;
            smartBoxExecutor.Size = new Size(90, 23);
            smartBoxExecutor.TabIndex = 1;
            smartBoxExecutor.Value = "";
            // 
            // smartBoxInitiator
            // 
            smartBoxInitiator.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            smartBoxInitiator.AutoCompleteSource = AutoCompleteSource.ListItems;
            smartBoxInitiator.AutoSuggestMode = C1.Win.Input.AutoSuggestMode.Contains;
            smartBoxInitiator.ButtonsSettings.CustomButton.Icon = new C1.Framework.C1BitmapIcon(null, new Size(16, 16), Color.Transparent, (Image)resources.GetObject("smartBoxInitiator.ButtonsSettings.CustomButton.Icon"));
            smartBoxInitiator.ButtonsSettings.CustomButton.Visible = true;
            smartBoxInitiator.ButtonsSettings.ModalButton.Visible = true;
            smartBoxInitiator.Location = new Point(288, 15);
            smartBoxInitiator.ModalForm = null;
            smartBoxInitiator.Name = "smartBoxInitiator";
            smartBoxInitiator.NullEnable = true;
            smartBoxInitiator.Size = new Size(90, 23);
            smartBoxInitiator.TabIndex = 2;
            smartBoxInitiator.Value = "";
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
            cbProjectType.Location = new Point(471, 15);
            cbProjectType.Name = "cbProjectType";
            cbProjectType.Size = new Size(99, 23);
            cbProjectType.TabIndex = 3;
            cbProjectType.Value = "";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(576, 19);
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
            labelInitiator.Location = new Point(211, 19);
            labelInitiator.Name = "labelInitiator";
            labelInitiator.Size = new Size(72, 15);
            labelInitiator.TabIndex = 2;
            labelInitiator.Text = "Инициатор:";
            labelInitiator.TextAlign = ContentAlignment.MiddleRight;
            // 
            // tbComment
            // 
            tbComment.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbComment.Location = new Point(121, 45);
            tbComment.Name = "tbComment";
            tbComment.Size = new Size(607, 23);
            tbComment.TabIndex = 5;
            tbComment.TextChanged += tbComment_TextChanged;
            // 
            // labelManagerType
            // 
            labelManagerType.AutoSize = true;
            labelManagerType.Location = new Point(385, 19);
            labelManagerType.Name = "labelManagerType";
            labelManagerType.Size = new Size(80, 15);
            labelManagerType.TabIndex = 10;
            labelManagerType.Text = "Менедж. тип:";
            labelManagerType.TextAlign = ContentAlignment.MiddleRight;
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
            // ManagerControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBox1);
            MinimumSize = new Size(740, 76);
            Name = "ManagerControl";
            Size = new Size(740, 76);
            Load += ManagerControl_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)smartBoxCreator).EndInit();
            ((System.ComponentModel.ISupportInitialize)smartBoxExecutor).EndInit();
            ((System.ComponentModel.ISupportInitialize)smartBoxInitiator).EndInit();
            ((System.ComponentModel.ISupportInitialize)cbProjectType).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label labelExecutor;
        private Label labelInitiator;
        private Label labelDescription;
        private Label labelManagerType;
        private Label label1;
        public TextBox tbComment;
        public GrpcWinForms.Controls.SmartBox.SmartBox smartBoxInitiator;
        public C1.Win.Input.C1ComboBox cbProjectType;
        public GrpcWinForms.Controls.SmartBox.SmartBox smartBoxCreator;
        public GrpcWinForms.Controls.SmartBox.SmartBox smartBoxExecutor;
    }
}
