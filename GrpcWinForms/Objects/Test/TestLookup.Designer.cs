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
            c1MultiColumnComboCustom = new C1.Win.Input.MultiColumnCombo.C1MultiColumnCombo();
            label1 = new Label();
            label2 = new Label();
            c1DropDownControl1 = new C1.Win.Input.C1DropDownControl();
            ((System.ComponentModel.ISupportInitialize)c1MultiColumnComboCustom).BeginInit();
            ((System.ComponentModel.ISupportInitialize)c1DropDownControl1).BeginInit();
            SuspendLayout();
            // 
            // c1MultiColumnComboCustom
            // 
            c1MultiColumnComboCustom.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            c1MultiColumnComboCustom.DisplayMember = "Name";
            c1MultiColumnComboCustom.DropDownAlign = C1.Framework.DropDownAlignment.Left;
            c1MultiColumnComboCustom.DropDownView = C1.Win.Input.MultiColumnCombo.DropDownView.Custom;
            c1MultiColumnComboCustom.Location = new Point(191, 42);
            c1MultiColumnComboCustom.Name = "c1MultiColumnComboCustom";
            c1MultiColumnComboCustom.Size = new Size(317, 23);
            c1MultiColumnComboCustom.TabIndex = 1;
            c1MultiColumnComboCustom.ValueMember = "Id";
            c1MultiColumnComboCustom.SelectedIndexChanged += c1MultiColumnComboCustom_SelectedIndexChanged;
            c1MultiColumnComboCustom.TextChanged += c1MultiColumnComboCustom_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 46);
            label1.Name = "label1";
            label1.Size = new Size(160, 15);
            label1.TabIndex = 2;
            label1.Text = "MultiColumnComboCustom";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(25, 109);
            label2.Name = "label2";
            label2.Size = new Size(104, 15);
            label2.TabIndex = 3;
            label2.Text = "DropDownControl";
            // 
            // c1DropDownControl1
            // 
            c1DropDownControl1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            c1DropDownControl1.Location = new Point(191, 105);
            c1DropDownControl1.Name = "c1DropDownControl1";
            c1DropDownControl1.Size = new Size(317, 23);
            c1DropDownControl1.TabIndex = 4;
            c1DropDownControl1.Value = "";
            // 
            // TestLookup
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(520, 450);
            Controls.Add(c1DropDownControl1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(c1MultiColumnComboCustom);
            Name = "TestLookup";
            Text = "TestLoolkup";
            ((System.ComponentModel.ISupportInitialize)c1MultiColumnComboCustom).EndInit();
            ((System.ComponentModel.ISupportInitialize)c1DropDownControl1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private C1.Win.Input.MultiColumnCombo.C1MultiColumnCombo c1MultiColumnComboCustom;
        private Label label1;
        private Label label2;
        private C1.Win.Input.C1DropDownControl c1DropDownControl1;
    }
}