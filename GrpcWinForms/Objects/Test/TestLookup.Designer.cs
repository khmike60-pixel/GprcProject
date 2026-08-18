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
            components = new System.ComponentModel.Container();
            buttonCancel = new Button();
            buttonSave = new Button();
            buttonSaveExit = new Button();
            textBox1 = new TextBox();
            period1 = new GrpcWinForms.Controls.PeriodControl.PeriodComponent(components);
            periodComponent1 = new GrpcWinForms.Controls.PeriodControl.PeriodComponent(components);
            ((System.ComponentModel.ISupportInitialize)period1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)periodComponent1).BeginInit();
            SuspendLayout();
            // 
            // buttonCancel
            // 
            buttonCancel.AutoSize = true;
            buttonCancel.Location = new Point(546, 415);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 25);
            buttonCancel.TabIndex = 23;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(465, 417);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(75, 23);
            buttonSave.TabIndex = 22;
            buttonSave.Text = "Записать";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // buttonSaveExit
            // 
            buttonSaveExit.Location = new Point(337, 417);
            buttonSaveExit.Name = "buttonSaveExit";
            buttonSaveExit.Size = new Size(122, 23);
            buttonSaveExit.TabIndex = 21;
            buttonSaveExit.Text = "Записать и выйти";
            buttonSaveExit.UseVisualStyleBackColor = true;
            buttonSaveExit.Click += buttonSaveExit_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(102, 42);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 1;
            // 
            // period1
            // 
            period1.DropDownAlign = C1.Framework.DropDownAlignment.Left;
            period1.DropDownWidth = 250;
            period1.EndDate = new DateTime(2026, 8, 9, 13, 31, 29, 635);
            period1.Location = new Point(108, 129);
            period1.Name = "period1";
            period1.Size = new Size(153, 23);
            period1.StartDate = new DateTime(2026, 5, 11, 13, 31, 29, 635);
            period1.Styles.Default.BackColor = SystemColors.Control;
            period1.TabIndex = 2;
            period1.Value = "11.05.2026 - 09.08.2026";
            // 
            // periodComponent1
            // 
            periodComponent1.DropDownAlign = C1.Framework.DropDownAlignment.Left;
            periodComponent1.DropDownWidth = 250;
            periodComponent1.EndDate = new DateTime(0L);
            periodComponent1.Location = new Point(108, 193);
            periodComponent1.Name = "periodComponent1";
            periodComponent1.Size = new Size(153, 23);
            periodComponent1.StartDate = new DateTime(0L);
            periodComponent1.Styles.Default.BackColor = SystemColors.Control;
            periodComponent1.TabIndex = 24;
            periodComponent1.Value = "";
            // 
            // TestLookup
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(627, 450);
            Controls.Add(periodComponent1);
            Controls.Add(period1);
            Controls.Add(textBox1);
            Controls.Add(buttonSaveExit);
            Controls.Add(buttonSave);
            Controls.Add(buttonCancel);
            Name = "TestLookup";
            Text = "TestLoolkup";
            ((System.ComponentModel.ISupportInitialize)period1).EndInit();
            ((System.ComponentModel.ISupportInitialize)periodComponent1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button buttonCancel;
        private Button buttonSave;
        private Button buttonSaveExit;
        private TextBox textBox1;
        private Controls.PeriodControl.PeriodComponent period1;
        private Controls.PeriodControl.PeriodComponent periodComponent1;
    }
}