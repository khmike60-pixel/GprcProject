namespace GrpcWinForms.Objects.SalePurchaseTypes.Forms
{
    partial class SalePurchaseTypeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SalePurchaseTypeForm));
            lblName = new C1.Win.Input.C1Label();
            txtName = new C1.Win.Input.C1TextBox();
            lblCountry = new C1.Win.Input.C1Label();
            cbCountry = new GrpcWinForms.Controls.SmartBox.SmartBox(components);
            txtCountryCode = new C1.Win.Input.C1TextBox();
            txtCurrency = new C1.Win.Input.C1TextBox();
            lblCurrency = new C1.Win.Input.C1Label();
            lblCurrencyMain = new Label();
            lblCurrencySalary = new C1.Win.Input.C1Label();
            lblCurrencyCross = new C1.Win.Input.C1Label();
            sbCurrencyMain = new GrpcWinForms.Controls.SmartBox.SmartBox(components);
            sbCurrencySalary = new GrpcWinForms.Controls.SmartBox.SmartBox(components);
            sbCurrencyCross = new GrpcWinForms.Controls.SmartBox.SmartBox(components);
            btnCancel = new C1.Win.Input.C1Button();
            btnOk = new C1.Win.Input.C1Button();
            ((System.ComponentModel.ISupportInitialize)lblName).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtName).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lblCountry).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cbCountry).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtCountryCode).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtCurrency).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lblCurrency).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lblCurrencySalary).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lblCurrencyCross).BeginInit();
            ((System.ComponentModel.ISupportInitialize)sbCurrencyMain).BeginInit();
            ((System.ComponentModel.ISupportInitialize)sbCurrencySalary).BeginInit();
            ((System.ComponentModel.ISupportInitialize)sbCurrencyCross).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnCancel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnOk).BeginInit();
            SuspendLayout();
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(38, 16);
            lblName.Name = "lblName";
            lblName.Size = new Size(127, 21);
            lblName.TabIndex = 1;
            lblName.Text = "Наименование типа:";
            // 
            // txtName
            // 
            txtName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtName.Location = new Point(171, 12);
            txtName.Name = "txtName";
            txtName.Size = new Size(423, 23);
            txtName.TabIndex = 2;
            txtName.Value = "";
            // 
            // lblCountry
            // 
            lblCountry.AutoSize = true;
            lblCountry.Location = new Point(7, 43);
            lblCountry.Name = "lblCountry";
            lblCountry.Size = new Size(158, 21);
            lblCountry.TabIndex = 3;
            lblCountry.Text = "Страна продажи/покупки:";
            // 
            // cbCountry
            // 
            cbCountry.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cbCountry.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbCountry.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbCountry.AutoSuggestMode = C1.Win.Input.AutoSuggestMode.Contains;
            cbCountry.ButtonsSettings.CustomButton.Icon = new C1.Framework.C1BitmapIcon(null, new Size(16, 16), Color.Transparent, (Image)resources.GetObject("smartBox1.ButtonsSettings.CustomButton.Icon"));
            cbCountry.ButtonsSettings.CustomButton.Visible = true;
            cbCountry.ButtonsSettings.ModalButton.Visible = true;
            cbCountry.Location = new Point(171, 41);
            cbCountry.ModalForm = null;
            cbCountry.Name = "cbCountry";
            cbCountry.NullEnable = true;
            cbCountry.Size = new Size(210, 23);
            cbCountry.TabIndex = 4;
            cbCountry.Value = "";
            // 
            // txtCountryCode
            // 
            txtCountryCode.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtCountryCode.Location = new Point(391, 41);
            txtCountryCode.Name = "txtCountryCode";
            txtCountryCode.ReadOnly = true;
            txtCountryCode.Size = new Size(28, 23);
            txtCountryCode.TabIndex = 5;
            txtCountryCode.TextAlign = HorizontalAlignment.Center;
            txtCountryCode.Value = "UZ";
            // 
            // txtCurrency
            // 
            txtCurrency.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtCurrency.Location = new Point(525, 39);
            txtCurrency.Name = "txtCurrency";
            txtCurrency.ReadOnly = true;
            txtCurrency.Size = new Size(69, 23);
            txtCurrency.TabIndex = 6;
            txtCurrency.TextAlign = HorizontalAlignment.Center;
            txtCurrency.Value = "UZS";
            // 
            // lblCurrency
            // 
            lblCurrency.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblCurrency.AutoSize = true;
            lblCurrency.Location = new Point(462, 41);
            lblCurrency.Name = "lblCurrency";
            lblCurrency.Size = new Size(57, 21);
            lblCurrency.TabIndex = 7;
            lblCurrency.Text = "Валюта:";
            // 
            // lblCurrencyMain
            // 
            lblCurrencyMain.AutoSize = true;
            lblCurrencyMain.Location = new Point(58, 74);
            lblCurrencyMain.Name = "lblCurrencyMain";
            lblCurrencyMain.Size = new Size(107, 15);
            lblCurrencyMain.TabIndex = 8;
            lblCurrencyMain.Text = "Основная валюта:";
            // 
            // lblCurrencySalary
            // 
            lblCurrencySalary.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblCurrencySalary.AutoSize = true;
            lblCurrencySalary.Location = new Point(243, 71);
            lblCurrencySalary.Name = "lblCurrencySalary";
            lblCurrencySalary.Size = new Size(101, 21);
            lblCurrencySalary.TabIndex = 9;
            lblCurrencySalary.Text = "Валюта выдачи:";
            // 
            // lblCurrencyCross
            // 
            lblCurrencyCross.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblCurrencyCross.AutoSize = true;
            lblCurrencyCross.Location = new Point(425, 71);
            lblCurrencyCross.Name = "lblCurrencyCross";
            lblCurrencyCross.Size = new Size(94, 21);
            lblCurrencyCross.TabIndex = 10;
            lblCurrencyCross.Text = "Кросс-валюта:";
            // 
            // sbCurrencyMain
            // 
            sbCurrencyMain.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            sbCurrencyMain.AutoCompleteSource = AutoCompleteSource.ListItems;
            sbCurrencyMain.AutoSuggestMode = C1.Win.Input.AutoSuggestMode.Contains;
            sbCurrencyMain.ButtonsSettings.CustomButton.Icon = new C1.Framework.C1BitmapIcon(null, new Size(16, 16), Color.Transparent, (Image)resources.GetObject("smartBox1.ButtonsSettings.CustomButton.Icon1"));
            sbCurrencyMain.ButtonsSettings.CustomButton.Visible = true;
            sbCurrencyMain.ButtonsSettings.DropDownButton.Visible = false;
            sbCurrencyMain.ButtonsSettings.ModalButton.Visible = true;
            sbCurrencyMain.Location = new Point(171, 70);
            sbCurrencyMain.ModalForm = null;
            sbCurrencyMain.Name = "sbCurrencyMain";
            sbCurrencyMain.NullEnable = true;
            sbCurrencyMain.Size = new Size(69, 23);
            sbCurrencyMain.TabIndex = 14;
            sbCurrencyMain.Value = "USD";
            // 
            // sbCurrencySalary
            // 
            sbCurrencySalary.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            sbCurrencySalary.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            sbCurrencySalary.AutoCompleteSource = AutoCompleteSource.ListItems;
            sbCurrencySalary.AutoSuggestMode = C1.Win.Input.AutoSuggestMode.Contains;
            sbCurrencySalary.ButtonsSettings.CustomButton.Icon = new C1.Framework.C1BitmapIcon(null, new Size(16, 16), Color.Transparent, (Image)resources.GetObject("smartBox1.ButtonsSettings.CustomButton.Icon2"));
            sbCurrencySalary.ButtonsSettings.CustomButton.Visible = true;
            sbCurrencySalary.ButtonsSettings.DropDownButton.Visible = false;
            sbCurrencySalary.ButtonsSettings.ModalButton.Visible = true;
            sbCurrencySalary.Location = new Point(350, 70);
            sbCurrencySalary.ModalForm = null;
            sbCurrencySalary.Name = "sbCurrencySalary";
            sbCurrencySalary.NullEnable = true;
            sbCurrencySalary.Size = new Size(69, 23);
            sbCurrencySalary.TabIndex = 15;
            sbCurrencySalary.Value = "UZS";
            // 
            // sbCurrencyCross
            // 
            sbCurrencyCross.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            sbCurrencyCross.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            sbCurrencyCross.AutoCompleteSource = AutoCompleteSource.ListItems;
            sbCurrencyCross.AutoSuggestMode = C1.Win.Input.AutoSuggestMode.Contains;
            sbCurrencyCross.ButtonsSettings.CustomButton.Icon = new C1.Framework.C1BitmapIcon(null, new Size(16, 16), Color.Transparent, (Image)resources.GetObject("smartBox1.ButtonsSettings.CustomButton.Icon3"));
            sbCurrencyCross.ButtonsSettings.CustomButton.Visible = true;
            sbCurrencyCross.ButtonsSettings.DropDownButton.Visible = false;
            sbCurrencyCross.ButtonsSettings.ModalButton.Visible = true;
            sbCurrencyCross.Location = new Point(525, 70);
            sbCurrencyCross.ModalForm = null;
            sbCurrencyCross.Name = "sbCurrencyCross";
            sbCurrencyCross.NullEnable = true;
            sbCurrencyCross.Size = new Size(69, 23);
            sbCurrencyCross.TabIndex = 16;
            sbCurrencyCross.Value = "UZS";
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.Location = new Point(519, 110);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 17;
            btnCancel.Text = "Cancel";
            // 
            // btnOk
            // 
            btnOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnOk.Location = new Point(425, 110);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(75, 23);
            btnOk.TabIndex = 18;
            btnOk.Text = "Ok";
            // 
            // SalePurchaseTypeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(606, 141);
            Controls.Add(btnOk);
            Controls.Add(btnCancel);
            Controls.Add(sbCurrencyCross);
            Controls.Add(sbCurrencySalary);
            Controls.Add(sbCurrencyMain);
            Controls.Add(lblCurrencyCross);
            Controls.Add(lblCurrencySalary);
            Controls.Add(lblCurrencyMain);
            Controls.Add(lblCurrency);
            Controls.Add(txtCurrency);
            Controls.Add(txtCountryCode);
            Controls.Add(cbCountry);
            Controls.Add(lblCountry);
            Controls.Add(txtName);
            Controls.Add(lblName);
            MinimumSize = new Size(622, 180);
            Name = "SalePurchaseTypeForm";
            Text = "Тип продажи/покупки";
            ((System.ComponentModel.ISupportInitialize)lblName).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtName).EndInit();
            ((System.ComponentModel.ISupportInitialize)lblCountry).EndInit();
            ((System.ComponentModel.ISupportInitialize)cbCountry).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtCountryCode).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtCurrency).EndInit();
            ((System.ComponentModel.ISupportInitialize)lblCurrency).EndInit();
            ((System.ComponentModel.ISupportInitialize)lblCurrencySalary).EndInit();
            ((System.ComponentModel.ISupportInitialize)lblCurrencyCross).EndInit();
            ((System.ComponentModel.ISupportInitialize)sbCurrencyMain).EndInit();
            ((System.ComponentModel.ISupportInitialize)sbCurrencySalary).EndInit();
            ((System.ComponentModel.ISupportInitialize)sbCurrencyCross).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnCancel).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnOk).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private C1.Win.Input.C1Label lblName;
        private C1.Win.Input.C1TextBox txtName;
        private C1.Win.Input.C1Label lblCountry;
        private Controls.SmartBox.SmartBox cbCountry;
        private C1.Win.Input.C1TextBox txtCountryCode;
        private C1.Win.Input.C1TextBox txtCurrency;
        private C1.Win.Input.C1Label lblCurrency;
        private Label lblCurrencyMain;
        private C1.Win.Input.C1Label lblCurrencySalary;
        private C1.Win.Input.C1Label lblCurrencyCross;
        private Controls.SmartBox.SmartBox sbCurrencyMain;
        private Controls.SmartBox.SmartBox sbCurrencySalary;
        private Controls.SmartBox.SmartBox sbCurrencyCross;
        private C1.Win.Input.C1Button btnCancel;
        private C1.Win.Input.C1Button btnOk;
    }
}