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
            buttonUpdate = new Button();
            buttonUpdateExit = new Button();
            periodComponent1 = new GrpcWinForms.Controls.PeriodControl.PeriodComponent(components);
            ((System.ComponentModel.ISupportInitialize)periodComponent1).BeginInit();
            SuspendLayout();
            // 
            // buttonCancel
            // 
            buttonCancel.AutoSize = true;
            buttonCancel.Location = new Point(546, 415);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 25);
            buttonCancel.TabIndex = 7;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // buttonUpdate
            // 
            buttonUpdate.Location = new Point(465, 417);
            buttonUpdate.Name = "buttonUpdate";
            buttonUpdate.Size = new Size(75, 23);
            buttonUpdate.TabIndex = 8;
            buttonUpdate.Text = "Записать";
            buttonUpdate.UseVisualStyleBackColor = true;
            // 
            // buttonUpdateExit
            // 
            buttonUpdateExit.Location = new Point(337, 417);
            buttonUpdateExit.Name = "buttonUpdateExit";
            buttonUpdateExit.Size = new Size(122, 23);
            buttonUpdateExit.TabIndex = 9;
            buttonUpdateExit.Text = "Записать и выйти";
            buttonUpdateExit.UseVisualStyleBackColor = true;
            // 
            // periodComponent1
            // 
            periodComponent1.DropDownAlign = C1.Framework.DropDownAlignment.Left;
            periodComponent1.DropDownWidth = 250;
            periodComponent1.EndDate = new DateTime(0L);
            periodComponent1.Location = new Point(154, 21);
            periodComponent1.Name = "periodComponent1";
            periodComponent1.Size = new Size(179, 23);
            periodComponent1.StartDate = new DateTime(0L);
            periodComponent1.TabIndex = 10;
            periodComponent1.Value = "01.01.2026 - 31.12.2026";
            // 
            // TestLookup
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(627, 450);
            Controls.Add(periodComponent1);
            Controls.Add(buttonUpdateExit);
            Controls.Add(buttonUpdate);
            Controls.Add(buttonCancel);
            Name = "TestLookup";
            Text = "TestLoolkup";
            ((System.ComponentModel.ISupportInitialize)periodComponent1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button buttonCancel;
        private Button buttonUpdate;
        private Button buttonUpdateExit;
        private Controls.PeriodControl.PeriodComponent periodComponent1;
    }
}