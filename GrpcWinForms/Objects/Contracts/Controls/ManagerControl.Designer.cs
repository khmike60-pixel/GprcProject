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
            groupBox1 = new GroupBox();
            label1 = new Label();
            labelExecutor = new Label();
            labelInitiator = new Label();
            c1DropDownControl2 = new C1.Win.Input.C1DropDownControl();
            textBox1 = new TextBox();
            labelManagerType = new Label();
            lookupInittiator = new C1.Win.Input.C1DropDownControl();
            c1DropDownControl1 = new C1.Win.Input.C1DropDownControl();
            labelDescription = new Label();
            lookupExecutor = new C1.Win.Input.C1DropDownControl();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)c1DropDownControl2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lookupInittiator).BeginInit();
            ((System.ComponentModel.ISupportInitialize)c1DropDownControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lookupExecutor).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(labelExecutor);
            groupBox1.Controls.Add(labelInitiator);
            groupBox1.Controls.Add(c1DropDownControl2);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(labelManagerType);
            groupBox1.Controls.Add(lookupInittiator);
            groupBox1.Controls.Add(c1DropDownControl1);
            groupBox1.Controls.Add(labelDescription);
            groupBox1.Controls.Add(lookupExecutor);
            groupBox1.Location = new Point(3, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(569, 73);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
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
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox1.Location = new Point(121, 44);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(296, 23);
            textBox1.TabIndex = 7;
            // 
            // labelManagerType
            // 
            labelManagerType.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelManagerType.AutoSize = true;
            labelManagerType.Location = new Point(377, 19);
            labelManagerType.Name = "labelManagerType";
            labelManagerType.Size = new Size(80, 15);
            labelManagerType.TabIndex = 10;
            labelManagerType.Text = "Менедж. тип:";
            labelManagerType.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lookupInittiator
            // 
            lookupInittiator.Location = new Point(259, 15);
            lookupInittiator.Name = "lookupInittiator";
            lookupInittiator.Size = new Size(54, 23);
            lookupInittiator.TabIndex = 3;
            // 
            // c1DropDownControl1
            // 
            c1DropDownControl1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            c1DropDownControl1.Location = new Point(463, 15);
            c1DropDownControl1.Name = "c1DropDownControl1";
            c1DropDownControl1.Size = new Size(94, 23);
            c1DropDownControl1.TabIndex = 5;
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
            // lookupExecutor
            // 
            lookupExecutor.Location = new Point(121, 15);
            lookupExecutor.Name = "lookupExecutor";
            lookupExecutor.Size = new Size(54, 23);
            lookupExecutor.TabIndex = 1;
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
            ((System.ComponentModel.ISupportInitialize)c1DropDownControl2).EndInit();
            ((System.ComponentModel.ISupportInitialize)lookupInittiator).EndInit();
            ((System.ComponentModel.ISupportInitialize)c1DropDownControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)lookupExecutor).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label labelExecutor;
        private C1.Win.Input.C1DropDownControl lookupExecutor;
        private C1.Win.Input.C1DropDownControl lookupInittiator;
        private Label labelInitiator;
        private Label labelDescription;
        private C1.Win.Input.C1DropDownControl c1DropDownControl1;
        private TextBox textBox1;
        private C1.Win.Input.C1DropDownControl c1DropDownControl2;
        private Label labelManagerType;
        private Label label1;
    }
}
