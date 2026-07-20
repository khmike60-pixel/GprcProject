namespace GrpcWinForms.Objects.Contragents.Components
{
    partial class TestForm
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
            c1ComboBox1 = new C1.Win.Input.C1ComboBox();
            c1ComboBox2 = new C1.Win.Input.C1ComboBox();
            ((System.ComponentModel.ISupportInitialize)c1ComboBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)c1ComboBox2).BeginInit();
            SuspendLayout();
            // 
            // c1ComboBox1
            // 
            c1ComboBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            c1ComboBox1.DropDownAlign = C1.Framework.DropDownAlignment.Left;
            c1ComboBox1.DropDownWidth = -1;
            c1ComboBox1.Location = new Point(146, 124);
            c1ComboBox1.Name = "c1ComboBox1";
            c1ComboBox1.Size = new Size(270, 23);
            c1ComboBox1.TabIndex = 0;
            c1ComboBox1.Value = "";
            c1ComboBox1.Resize += c1ComboBox1_Resize;
            // 
            // c1ComboBox2
            // 
            c1ComboBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            c1ComboBox2.Location = new Point(146, 209);
            c1ComboBox2.Name = "c1ComboBox2";
            c1ComboBox2.Size = new Size(270, 23);
            c1ComboBox2.TabIndex = 1;
            c1ComboBox2.TranslateValue = false;
            c1ComboBox2.Value = "";
            c1ComboBox2.TextChanged += c1ComboBox2_TextChanged;
            // 
            // TestForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(460, 450);
            Controls.Add(c1ComboBox2);
            Controls.Add(c1ComboBox1);
            Name = "TestForm";
            Text = "TestForm";
            ((System.ComponentModel.ISupportInitialize)c1ComboBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)c1ComboBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private C1.Win.Input.C1ComboBox c1ComboBox1;
        private C1.Win.Input.C1ComboBox c1ComboBox2;
    }
}