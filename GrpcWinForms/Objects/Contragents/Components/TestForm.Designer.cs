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
            lookup = new LookupDropDownControl();
            button1 = new Button();
            c1MultiColumnCombo1 = new C1.Win.Input.MultiColumnCombo.C1MultiColumnCombo();
            ((System.ComponentModel.ISupportInitialize)lookup).BeginInit();
            ((System.ComponentModel.ISupportInitialize)c1MultiColumnCombo1).BeginInit();
            SuspendLayout();
            // 
            // lookup
            // 
            lookup.AutoOpen = true;
            lookup.DataProviderAsync = null;
            lookup.DisplayMember = null;
            lookup.Location = new Point(81, 81);
            lookup.MaxRows = 10;
            lookup.Name = "lookup";
            lookup.Size = new Size(206, 23);
            lookup.TabIndex = 0;
            lookup.Value = "";
            lookup.ValueMember = null;
            // 
            // button1
            // 
            button1.Location = new Point(308, 81);
            button1.Name = "button1";
            button1.Size = new Size(206, 23);
            button1.TabIndex = 1;
            button1.Text = "Показать выбранный Id";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // c1MultiColumnCombo1
            // 
            c1MultiColumnCombo1.Location = new Point(81, 203);
            c1MultiColumnCombo1.Name = "c1MultiColumnCombo1";
            c1MultiColumnCombo1.Size = new Size(206, 23);
            c1MultiColumnCombo1.TabIndex = 2;
            // 
            // TestForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(c1MultiColumnCombo1);
            Controls.Add(button1);
            Controls.Add(lookup);
            Name = "TestForm";
            Text = "TestForm";
            Load += TestForm_Load;
            ((System.ComponentModel.ISupportInitialize)lookup).EndInit();
            ((System.ComponentModel.ISupportInitialize)c1MultiColumnCombo1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private LookupDropDownControl lookup;
        private Button button1;
        private C1.Win.Input.MultiColumnCombo.C1MultiColumnCombo c1MultiColumnCombo1;
    }
}