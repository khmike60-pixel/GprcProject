namespace GrpcWinForms.Objects.Stocks.Views
{
    partial class StockForm
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
            lName = new C1.Win.Input.C1Label();
            txtNameStock = new C1.Win.Input.C1TextBox();
            lGeolocation = new C1.Win.Input.C1Label();
            sbPlace = new SmartLib.Base.SmartBox.SmartBox(components);
            btnOk = new C1.Win.Input.C1Button();
            btnCancel = new C1.Win.Input.C1Button();
            ((System.ComponentModel.ISupportInitialize)lName).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtNameStock).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lGeolocation).BeginInit();
            ((System.ComponentModel.ISupportInitialize)sbPlace).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnOk).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnCancel).BeginInit();
            SuspendLayout();
            // 
            // lName
            // 
            lName.AutoSize = true;
            lName.Location = new Point(36, 12);
            lName.Name = "lName";
            lName.Size = new Size(139, 21);
            lName.TabIndex = 0;
            lName.Text = "Наименование склада:";
            // 
            // txtNameStock
            // 
            txtNameStock.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtNameStock.Location = new Point(181, 10);
            txtNameStock.Name = "txtNameStock";
            txtNameStock.Size = new Size(216, 23);
            txtNameStock.TabIndex = 1;
            txtNameStock.Value = "";
            // 
            // lGeolocation
            // 
            lGeolocation.AutoSize = true;
            lGeolocation.Location = new Point(18, 39);
            lGeolocation.Name = "lGeolocation";
            lGeolocation.Size = new Size(157, 21);
            lGeolocation.TabIndex = 2;
            lGeolocation.Text = "Место положение склада:";
            // 
            // sbPlace
            // 
            sbPlace.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            sbPlace.Location = new Point(181, 39);
            sbPlace.Name = "sbPlace";
            sbPlace.Size = new Size(216, 23);
            sbPlace.TabIndex = 3;
            sbPlace.Value = "";
            // 
            // btnOk
            // 
            btnOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnOk.Location = new Point(241, 69);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(75, 23);
            btnOk.TabIndex = 4;
            btnOk.Text = "Ok";
            btnOk.Click += btnOk_Click;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.Location = new Point(322, 69);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Cancel";
            btnCancel.Click += btnCancel_Click;
            // 
            // StockForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(409, 104);
            Controls.Add(btnCancel);
            Controls.Add(btnOk);
            Controls.Add(sbPlace);
            Controls.Add(lGeolocation);
            Controls.Add(txtNameStock);
            Controls.Add(lName);
            MinimumSize = new Size(425, 143);
            Name = "StockForm";
            Text = "Склад";
            Load += StockForm_Load;
            ((System.ComponentModel.ISupportInitialize)lName).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtNameStock).EndInit();
            ((System.ComponentModel.ISupportInitialize)lGeolocation).EndInit();
            ((System.ComponentModel.ISupportInitialize)sbPlace).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnOk).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnCancel).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private C1.Win.Input.C1Label lName;
        private C1.Win.Input.C1TextBox txtNameStock;
        private C1.Win.Input.C1Label lGeolocation;
        private SmartLib.Base.SmartBox.SmartBox sbPlace;
        private C1.Win.Input.C1Button btnOk;
        private C1.Win.Input.C1Button btnCancel;
    }
}