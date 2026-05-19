namespace GrpcWinForms.Objects.Test
{
    partial class SmartLookup
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
            _popup.Close();
            _popup.Dispose();
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
            _button = new Button();
            _textBox = new C1.Win.Input.C1TextBox();
            ((System.ComponentModel.ISupportInitialize)_textBox).BeginInit();
            SuspendLayout();
            // 
            // _button
            // 
            _button.BackColor = SystemColors.Window;
            _button.Dock = DockStyle.Right;
            _button.FlatStyle = FlatStyle.Flat;
            _button.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            _button.ForeColor = SystemColors.ControlText;
            _button.Location = new Point(180, 0);
            _button.Margin = new Padding(0);
            _button.Name = "_button";
            _button.Size = new Size(20, 22);
            _button.TabIndex = 1;
            _button.Text = "∨";
            _button.UseVisualStyleBackColor = false;
            // 
            // _textBox
            // 
            _textBox.AutoSize = false;
            _textBox.Dock = DockStyle.Fill;
            _textBox.Location = new Point(0, 0);
            _textBox.Multiline = true;
            _textBox.Name = "_textBox";
            _textBox.Size = new Size(180, 22);
            _textBox.TabIndex = 2;
            _textBox.Value = "";
            // 
            // SmartLookup
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(_textBox);
            Controls.Add(_button);
            MaximumSize = new Size(0, 24);
            MinimumSize = new Size(0, 24);
            Name = "SmartLookup";
            Size = new Size(200, 22);
            ((System.ComponentModel.ISupportInitialize)_textBox).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button _button;
        private C1.Win.Input.C1TextBox _textBox;
    }
}
