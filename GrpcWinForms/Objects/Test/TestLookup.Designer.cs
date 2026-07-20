namespace GrpcWinForms.Objects.Test
{
    partial class TestLookup
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label2 = new Label();
            c1DropDownControl1 = new C1.Win.Input.C1DropDownControl();
            textBox1 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)c1DropDownControl1).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(25, 25);
            label2.Name = "label2";
            label2.Size = new Size(104, 15);
            label2.TabIndex = 3;
            label2.Text = "DropDownControl";
            // 
            // c1DropDownControl1
            // 
            c1DropDownControl1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            c1DropDownControl1.ButtonsSettings.CustomButton.Icon = new C1.Framework.C1BitmapIcon(null, new Size(16, 16), Color.Transparent, Properties.Resources.icons8_multiply_16);
            c1DropDownControl1.ButtonsSettings.CustomButton.Visible = true;
            c1DropDownControl1.Location = new Point(191, 21);
            c1DropDownControl1.Name = "c1DropDownControl1";
            c1DropDownControl1.Size = new Size(317, 23);
            c1DropDownControl1.TabIndex = 4;
            c1DropDownControl1.Value = "";
            c1DropDownControl1.CustomButtonClick += c1DropDownControl1_CustomButtonClick;
            c1DropDownControl1.TextChanged += c1DropDownControl1_TextChanged;
            c1DropDownControl1.Leave += c1DropDownControl1_Leave;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(191, 92);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 5;
            // 
            // TestLookup
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(520, 450);
            Controls.Add(textBox1);
            Controls.Add(c1DropDownControl1);
            Controls.Add(label2);
            Name = "TestLookup";
            Text = "TestLoolkup";
            ((System.ComponentModel.ISupportInitialize)c1DropDownControl1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label2;
        private C1.Win.Input.C1DropDownControl c1DropDownControl1;
        private TextBox textBox1;
    }
}