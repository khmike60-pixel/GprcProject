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
            lookup = new SmartLookup();
            textBox1 = new TextBox();
            SuspendLayout();
            // 
            // lookup
            // 
            lookup.DataProvider = null;
            lookup.Location = new Point(72, 118);
            lookup.MaximumSize = new Size(0, 24);
            lookup.MinimumSize = new Size(0, 24);
            lookup.Name = "lookup";
            lookup.Size = new Size(234, 24);
            lookup.TabIndex = 0;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(443, 119);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(220, 23);
            textBox1.TabIndex = 1;
            // 
            // TestLookup
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(textBox1);
            Controls.Add(lookup);
            Name = "TestLookup";
            Text = "TestLoolkup";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private SmartLookup lookup;
        private TextBox textBox1;
    }
}