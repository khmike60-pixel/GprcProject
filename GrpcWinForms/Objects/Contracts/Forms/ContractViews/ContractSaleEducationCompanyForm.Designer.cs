namespace GrpcWinForms.Objects.Contracts.Forms.ContractViews
{
    partial class ContractSaleEducationCompanyForm
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(220, 174);
            label1.Name = "label1";
            label1.Size = new Size(178, 15);
            label1.TabIndex = 0;
            label1.Text = "Это форма для типа контракта:";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(220, 205);
            label2.Name = "label2";
            label2.Size = new Size(138, 15);
            label2.TabIndex = 1;
            label2.Text = "Контракт (УЦ, юр.лицо)";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(220, 241);
            label3.Name = "label3";
            label3.Size = new Size(207, 15);
            label3.TabIndex = 2;
            label3.Text = "ContractSaleEducationCompanyForm";
            // 
            // ContractSaleEducationCompanyForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "ContractSaleEducationCompanyForm";
            Text = "ContractSaleEducationCompanyForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
    }
}