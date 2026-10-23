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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestLookup));
            GrpcCommonNet.Library.Common.Contragent contragent2 = new GrpcCommonNet.Library.Common.Contragent();
            buttonCancel = new Button();
            textBox1 = new TextBox();
            smartBoxCurrency = new GrpcWinForms.Controls.SmartBox.SmartBox(components);
            smartBoxDepartment = new GrpcWinForms.Controls.SmartBox.SmartBox(components);
            companyDropDown = new GrpcWinForms.Objects.Contragents.Components.CompanyDropDown(components);
            ((System.ComponentModel.ISupportInitialize)smartBoxCurrency).BeginInit();
            ((System.ComponentModel.ISupportInitialize)smartBoxDepartment).BeginInit();
            ((System.ComponentModel.ISupportInitialize)companyDropDown).BeginInit();
            SuspendLayout();
            // 
            // buttonCancel
            // 
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.AutoSize = true;
            buttonCancel.Location = new Point(383, 190);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 25);
            buttonCancel.TabIndex = 23;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(72, 168);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 25;
            // 
            // smartBoxCurrency
            // 
            smartBoxCurrency.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            smartBoxCurrency.AutoCompleteSource = AutoCompleteSource.ListItems;
            smartBoxCurrency.AutoSuggestMode = C1.Win.Input.AutoSuggestMode.Contains;
            smartBoxCurrency.ButtonsSettings.CustomButton.Icon = new C1.Framework.C1BitmapIcon(null, new Size(16, 16), Color.Transparent, (Image)resources.GetObject("smartBoxCurrency.ButtonsSettings.CustomButton.Icon"));
            smartBoxCurrency.ButtonsSettings.CustomButton.Visible = true;
            smartBoxCurrency.ButtonsSettings.ModalButton.Visible = true;
            smartBoxCurrency.Location = new Point(72, 37);
            smartBoxCurrency.ModalForm = null;
            smartBoxCurrency.Name = "smartBoxCurrency";
            smartBoxCurrency.NullEnable = true;
            smartBoxCurrency.Size = new Size(100, 23);
            smartBoxCurrency.TabIndex = 26;
            smartBoxCurrency.Value = "";
            // 
            // smartBoxDepartment
            // 
            smartBoxDepartment.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            smartBoxDepartment.AutoCompleteSource = AutoCompleteSource.ListItems;
            smartBoxDepartment.AutoSuggestMode = C1.Win.Input.AutoSuggestMode.Contains;
            smartBoxDepartment.ButtonsSettings.CustomButton.Icon = new C1.Framework.C1BitmapIcon(null, new Size(16, 16), Color.Transparent, (Image)resources.GetObject("smartBoxDepartment.ButtonsSettings.CustomButton.Icon"));
            smartBoxDepartment.ButtonsSettings.CustomButton.Visible = true;
            smartBoxDepartment.ButtonsSettings.ModalButton.Visible = true;
            smartBoxDepartment.Location = new Point(72, 81);
            smartBoxDepartment.ModalForm = null;
            smartBoxDepartment.Name = "smartBoxDepartment";
            smartBoxDepartment.NullEnable = true;
            smartBoxDepartment.Size = new Size(100, 23);
            smartBoxDepartment.TabIndex = 27;
            smartBoxDepartment.Value = "";
            // 
            // companyDropDown
            // 
            companyDropDown.ButtonsSettings.CustomButton.Icon = new C1.Framework.C1BitmapIcon(null, new Size(16, 16), Color.Transparent, (Image)resources.GetObject("companyDropDown1.ButtonsSettings.CustomButton.Icon"));
            companyDropDown.ButtonsSettings.CustomButton.Visible = true;
            companyDropDown.DropDownAlign = C1.Framework.DropDownAlignment.Left;
            companyDropDown.DropDownWidth = 300;
            companyDropDown.GetDataSourceFunc = null;
            companyDropDown.Location = new Point(72, 126);
            companyDropDown.Name = "companyDropDown";
            contragent2.CountryId = 0;
            contragent2.CountrySymbol = "";
            contragent2.Entity = null;
            contragent2.Id = 0;
            contragent2.Name = "";
            contragent2.Person = null;
            contragent2.Prefix = "";
            contragent2.Taxno = "";
            contragent2.Type = GrpcCommonNet.Library.Common.ContragentType.Entity;
            companyDropDown.SelectedCompany = contragent2;
            companyDropDown.Size = new Size(386, 23);
            companyDropDown.TabIndex = 28;
            companyDropDown.Value = "";
            // 
            // TestLookup
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(470, 227);
            Controls.Add(companyDropDown);
            Controls.Add(smartBoxDepartment);
            Controls.Add(smartBoxCurrency);
            Controls.Add(textBox1);
            Controls.Add(buttonCancel);
            Name = "TestLookup";
            Text = "TestLoolkup";
            Load += TestLookup_Load;
            ((System.ComponentModel.ISupportInitialize)smartBoxCurrency).EndInit();
            ((System.ComponentModel.ISupportInitialize)smartBoxDepartment).EndInit();
            ((System.ComponentModel.ISupportInitialize)companyDropDown).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button buttonCancel;
        private TextBox textBox1;
        private Controls.SmartBox.SmartBox smartBoxCurrency;
        private Controls.SmartBox.SmartBox smartBoxDepartment;
        private Contragents.Components.CompanyDropDown companyDropDown;
    }
}