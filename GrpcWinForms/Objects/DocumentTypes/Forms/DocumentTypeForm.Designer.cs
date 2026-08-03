namespace GrpcWinForms.Objects.DocumentTypes.Forms
{
    partial class DocumentTypeForm
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
            C1.Win.Input.ComboBoxItem comboBoxItem1 = new C1.Win.Input.ComboBoxItem();
            lName = new Label();
            lParent = new Label();
            lCurrencyType = new Label();
            lCountryCurrency = new Label();
            lViewMaster = new Label();
            lViewDetail = new Label();
            tbName = new TextBox();
            cbCurrency = new C1.Win.Input.C1ComboBox();
            chkDefault = new C1.Win.Input.C1CheckBox();
            btnAdditionalParameters = new C1.Win.Input.C1Button();
            lCode = new Label();
            tbCode = new TextBox();
            tbViewMaster = new TextBox();
            tbViewDetail = new TextBox();
            btnCancel = new Button();
            btnOk = new Button();
            tbParent = new TextBox();
            cbCountryCurrency = new C1.Win.Input.C1ComboBox();
            lForm = new Label();
            tbForm = new TextBox();
            ((System.ComponentModel.ISupportInitialize)cbCurrency).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chkDefault).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnAdditionalParameters).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cbCountryCurrency).BeginInit();
            SuspendLayout();
            // 
            // lName
            // 
            lName.AutoSize = true;
            lName.Location = new Point(14, 10);
            lName.Name = "lName";
            lName.Size = new Size(93, 15);
            lName.TabIndex = 0;
            lName.Text = "Наименование:";
            // 
            // lParent
            // 
            lParent.AutoSize = true;
            lParent.Location = new Point(14, 142);
            lParent.Name = "lParent";
            lParent.Size = new Size(109, 15);
            lParent.TabIndex = 1;
            lParent.Text = "Родительский тип:";
            // 
            // lCurrencyType
            // 
            lCurrencyType.AutoSize = true;
            lCurrencyType.Location = new Point(14, 230);
            lCurrencyType.Name = "lCurrencyType";
            lCurrencyType.Size = new Size(79, 15);
            lCurrencyType.TabIndex = 2;
            lCurrencyType.Text = "Тип валюты: ";
            // 
            // lCountryCurrency
            // 
            lCountryCurrency.AutoSize = true;
            lCountryCurrency.Location = new Point(14, 186);
            lCountryCurrency.Name = "lCountryCurrency";
            lCountryCurrency.Size = new Size(82, 15);
            lCountryCurrency.TabIndex = 3;
            lCountryCurrency.Text = "Тип продажи:";
            // 
            // lViewMaster
            // 
            lViewMaster.AutoSize = true;
            lViewMaster.Location = new Point(14, 274);
            lViewMaster.Name = "lViewMaster";
            lViewMaster.Size = new Size(236, 15);
            lViewMaster.TabIndex = 5;
            lViewMaster.Text = "Процедура получения основных данных:";
            // 
            // lViewDetail
            // 
            lViewDetail.AutoSize = true;
            lViewDetail.Location = new Point(14, 318);
            lViewDetail.Name = "lViewDetail";
            lViewDetail.Size = new Size(229, 15);
            lViewDetail.TabIndex = 5;
            lViewDetail.Text = "Процедура получения строк документа:";
            // 
            // tbName
            // 
            tbName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbName.Location = new Point(14, 28);
            tbName.Name = "tbName";
            tbName.Size = new Size(320, 23);
            tbName.TabIndex = 1;
            // 
            // cbCurrency
            // 
            cbCurrency.DropDownStyle = C1.Win.Input.DropDownStyle.DropDownList;
            cbCurrency.InitialSelection = C1.Win.Input.InitialSelection.CaretAtStart;
            cbCurrency.Location = new Point(14, 248);
            cbCurrency.Name = "cbCurrency";
            cbCurrency.ReadOnly = true;
            cbCurrency.Size = new Size(78, 23);
            cbCurrency.TabIndex = 6;
            cbCurrency.Value = "";
            cbCurrency.SelectedItemChanged += cbCurrency_SelectedItemChanged;
            // 
            // chkDefault
            // 
            chkDefault.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            chkDefault.AutoSize = true;
            chkDefault.CheckAlign = ContentAlignment.MiddleRight;
            chkDefault.Location = new Point(247, 250);
            chkDefault.Name = "chkDefault";
            chkDefault.Size = new Size(87, 19);
            chkDefault.TabIndex = 7;
            chkDefault.Text = "Основной:";
            // 
            // btnAdditionalParameters
            // 
            btnAdditionalParameters.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnAdditionalParameters.AutoSize = true;
            btnAdditionalParameters.Icon = new C1.Framework.C1BitmapIcon(null, new Size(16, 16), Color.Transparent, Properties.Resources.icons8_json_50);
            btnAdditionalParameters.ImageAlign = ContentAlignment.MiddleLeft;
            btnAdditionalParameters.Location = new Point(14, 365);
            btnAdditionalParameters.Name = "btnAdditionalParameters";
            btnAdditionalParameters.Size = new Size(320, 32);
            btnAdditionalParameters.Styles.Padding = new C1.Framework.Thickness(0, 0, 0, 0);
            btnAdditionalParameters.TabIndex = 10;
            btnAdditionalParameters.Text = "Посмотреть дополнительные параметры ";
            btnAdditionalParameters.TextAlign = ContentAlignment.MiddleLeft;
            btnAdditionalParameters.TextImageRelation = TextImageRelation.ImageBeforeText;
            // 
            // lCode
            // 
            lCode.AutoSize = true;
            lCode.Location = new Point(14, 54);
            lCode.Name = "lCode";
            lCode.Size = new Size(30, 15);
            lCode.TabIndex = 13;
            lCode.Text = "Код:";
            // 
            // tbCode
            // 
            tbCode.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbCode.Location = new Point(14, 72);
            tbCode.Name = "tbCode";
            tbCode.Size = new Size(320, 23);
            tbCode.TabIndex = 2;
            // 
            // tbViewMaster
            // 
            tbViewMaster.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbViewMaster.Location = new Point(14, 292);
            tbViewMaster.Name = "tbViewMaster";
            tbViewMaster.Size = new Size(320, 23);
            tbViewMaster.TabIndex = 8;
            // 
            // tbViewDetail
            // 
            tbViewDetail.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbViewDetail.Location = new Point(14, 336);
            tbViewDetail.Name = "tbViewDetail";
            tbViewDetail.Size = new Size(320, 23);
            tbViewDetail.TabIndex = 9;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.Location = new Point(259, 406);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 12;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnOk
            // 
            btnOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnOk.Location = new Point(178, 406);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(75, 23);
            btnOk.TabIndex = 11;
            btnOk.Text = "Ok";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // tbParent
            // 
            tbParent.Location = new Point(14, 160);
            tbParent.Name = "tbParent";
            tbParent.ReadOnly = true;
            tbParent.Size = new Size(316, 23);
            tbParent.TabIndex = 4;
            // 
            // cbCountryCurrency
            // 
            cbCountryCurrency.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cbCountryCurrency.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbCountryCurrency.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbCountryCurrency.DropDownStyle = C1.Win.Input.DropDownStyle.DropDownList;
            cbCountryCurrency.InitialSelection = C1.Win.Input.InitialSelection.CaretAtStart;
            comboBoxItem1.DisplayText = "Продажа в DDP (Узбекистан)";
            comboBoxItem1.Value = "1";
            cbCountryCurrency.Items.Add(comboBoxItem1);
            cbCountryCurrency.Location = new Point(14, 204);
            cbCountryCurrency.Name = "cbCountryCurrency";
            cbCountryCurrency.ReadOnly = true;
            cbCountryCurrency.Size = new Size(320, 23);
            cbCountryCurrency.TabIndex = 5;
            cbCountryCurrency.Value = "";
            // 
            // lForm
            // 
            lForm.AutoSize = true;
            lForm.Location = new Point(14, 98);
            lForm.Name = "lForm";
            lForm.Size = new Size(71, 15);
            lForm.TabIndex = 14;
            lForm.Text = "Код формы";
            // 
            // tbForm
            // 
            tbForm.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbForm.Location = new Point(14, 116);
            tbForm.Name = "tbForm";
            tbForm.Size = new Size(318, 23);
            tbForm.TabIndex = 3;
            // 
            // DocumentTypeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(344, 441);
            Controls.Add(tbForm);
            Controls.Add(lForm);
            Controls.Add(tbParent);
            Controls.Add(btnOk);
            Controls.Add(btnCancel);
            Controls.Add(tbViewDetail);
            Controls.Add(tbViewMaster);
            Controls.Add(tbCode);
            Controls.Add(lCode);
            Controls.Add(btnAdditionalParameters);
            Controls.Add(chkDefault);
            Controls.Add(cbCountryCurrency);
            Controls.Add(cbCurrency);
            Controls.Add(tbName);
            Controls.Add(lViewDetail);
            Controls.Add(lViewMaster);
            Controls.Add(lCountryCurrency);
            Controls.Add(lCurrencyType);
            Controls.Add(lParent);
            Controls.Add(lName);
            MinimumSize = new Size(360, 480);
            Name = "DocumentTypeForm";
            Text = "Тип документа";
            Load += DocumentTypeForm_Load;
            ((System.ComponentModel.ISupportInitialize)cbCurrency).EndInit();
            ((System.ComponentModel.ISupportInitialize)chkDefault).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnAdditionalParameters).EndInit();
            ((System.ComponentModel.ISupportInitialize)cbCountryCurrency).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lName;
        private Label lParent;
        private Label lCurrencyType;
        private Label lCountryCurrency;
        private Label lViewMaster;
        private Label lViewDetail;
        private TextBox tbName;
        private C1.Win.Input.C1ComboBox cbCurrency;
        private C1.Win.Input.C1CheckBox chkDefault;
        private C1.Win.Input.C1Button btnAdditionalParameters;
        private Label lCode;
        private TextBox tbCode;
        private TextBox tbViewMaster;
        private TextBox tbViewDetail;
        private Button btnCancel;
        private Button btnOk;
        private TextBox tbParent;
        private C1.Win.Input.C1ComboBox cbCountryCurrency;
        private Label lForm;
        private TextBox tbForm;
    }
}