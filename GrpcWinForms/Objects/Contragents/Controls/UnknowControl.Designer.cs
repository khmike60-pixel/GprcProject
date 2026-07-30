namespace GrpcWinForms.Objects.Contragents.Forms
{
    partial class UnknowControl
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
            groupBoxUnknow = new GroupBox();
            labelName = new Label();
            textBoxName = new TextBox();
            labelId = new Label();
            textBoxId = new TextBox();
            groupBoxUnknow.SuspendLayout();
            SuspendLayout();
            // 
            // groupBoxUnknow
            // 
            groupBoxUnknow.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxUnknow.Controls.Add(labelName);
            groupBoxUnknow.Controls.Add(textBoxName);
            groupBoxUnknow.Controls.Add(labelId);
            groupBoxUnknow.Controls.Add(textBoxId);
            groupBoxUnknow.Location = new Point(3, 3);
            groupBoxUnknow.Name = "groupBoxUnknow";
            groupBoxUnknow.Size = new Size(488, 95);
            groupBoxUnknow.TabIndex = 0;
            groupBoxUnknow.TabStop = false;
            groupBoxUnknow.Text = "Основные реквизиты";
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Location = new Point(8, 22);
            labelName.Name = "labelName";
            labelName.Size = new Size(138, 15);
            labelName.TabIndex = 4;
            labelName.Text = "Краткое наименование:";
            // 
            // textBoxName
            // 
            textBoxName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxName.Location = new Point(152, 18);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(184, 23);
            textBoxName.TabIndex = 5;
            // 
            // labelId
            // 
            labelId.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelId.AutoSize = true;
            labelId.Location = new Point(375, 22);
            labelId.Name = "labelId";
            labelId.Size = new Size(20, 15);
            labelId.TabIndex = 6;
            labelId.Text = "Id:";
            // 
            // textBoxId
            // 
            textBoxId.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            textBoxId.Location = new Point(401, 18);
            textBoxId.Name = "textBoxId";
            textBoxId.ReadOnly = true;
            textBoxId.Size = new Size(79, 23);
            textBoxId.TabIndex = 7;
            textBoxId.TextAlign = HorizontalAlignment.Right;
            // 
            // UnknowControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBoxUnknow);
            Name = "UnknowControl";
            Size = new Size(494, 324);
            groupBoxUnknow.ResumeLayout(false);
            groupBoxUnknow.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBoxUnknow;
        private Label labelName;
        public TextBox textBoxName;
        private Label labelId;
        public TextBox textBoxId;
    }
}
