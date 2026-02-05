namespace GrpcWinForms.Objects.Currencies.Forms
{
    partial class CurrencyForm
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
            labelSymbol = new Label();
            textBoxSymbol = new TextBox();
            labelName = new Label();
            textBoxName = new TextBox();
            labelCode = new Label();
            c1CommandHolder1 = new C1.Win.Command.C1CommandHolder();
            textBoxCode = new TextBox();
            checkBoxIsVisible = new CheckBox();
            labelId = new Label();
            textBoxId = new TextBox();
            buttonCancel = new Button();
            buttonOk = new Button();
            ((System.ComponentModel.ISupportInitialize)c1CommandHolder1).BeginInit();
            SuspendLayout();
            // 
            // labelSymbol
            // 
            labelSymbol.AutoSize = true;
            labelSymbol.Location = new Point(51, 17);
            labelSymbol.Name = "labelSymbol";
            labelSymbol.Size = new Size(100, 15);
            labelSymbol.TabIndex = 0;
            labelSymbol.Text = "Символ валюты:";
            // 
            // textBoxSymbol
            // 
            textBoxSymbol.Location = new Point(157, 15);
            textBoxSymbol.Name = "textBoxSymbol";
            textBoxSymbol.Size = new Size(59, 23);
            textBoxSymbol.TabIndex = 1;
            textBoxSymbol.Text = "USD";
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Location = new Point(12, 48);
            labelName.Name = "labelName";
            labelName.Size = new Size(139, 15);
            labelName.TabIndex = 2;
            labelName.Text = "Наименование валюты:";
            // 
            // textBoxName
            // 
            textBoxName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxName.Location = new Point(157, 45);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(241, 23);
            textBoxName.TabIndex = 3;
            textBoxName.Text = "Доллар США";
            // 
            // labelCode
            // 
            labelCode.AutoSize = true;
            labelCode.Location = new Point(75, 77);
            labelCode.Name = "labelCode";
            labelCode.Size = new Size(76, 15);
            labelCode.TabIndex = 4;
            labelCode.Text = "Код валюты:";
            // 
            // c1CommandHolder1
            // 
            c1CommandHolder1.Owner = this;
            // 
            // textBoxCode
            // 
            textBoxCode.Location = new Point(157, 74);
            textBoxCode.Name = "textBoxCode";
            textBoxCode.Size = new Size(59, 23);
            textBoxCode.TabIndex = 5;
            textBoxCode.Text = "840";
            // 
            // checkBoxIsVisible
            // 
            checkBoxIsVisible.AutoSize = true;
            checkBoxIsVisible.CheckAlign = ContentAlignment.MiddleRight;
            checkBoxIsVisible.Location = new Point(29, 103);
            checkBoxIsVisible.Name = "checkBoxIsVisible";
            checkBoxIsVisible.Size = new Size(142, 19);
            checkBoxIsVisible.TabIndex = 6;
            checkBoxIsVisible.Text = "Часто используемая:";
            checkBoxIsVisible.UseVisualStyleBackColor = true;
            // 
            // labelId
            // 
            labelId.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelId.AutoSize = true;
            labelId.Location = new Point(272, 18);
            labelId.Name = "labelId";
            labelId.Size = new Size(20, 15);
            labelId.TabIndex = 7;
            labelId.Text = "Id:";
            // 
            // textBoxId
            // 
            textBoxId.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            textBoxId.Location = new Point(298, 14);
            textBoxId.Name = "textBoxId";
            textBoxId.ReadOnly = true;
            textBoxId.Size = new Size(100, 23);
            textBoxId.TabIndex = 8;
            textBoxId.Text = "123";
            // 
            // buttonCancel
            // 
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Location = new Point(323, 138);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 23);
            buttonCancel.TabIndex = 9;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // buttonOk
            // 
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonOk.Location = new Point(242, 138);
            buttonOk.Name = "buttonOk";
            buttonOk.Size = new Size(75, 23);
            buttonOk.TabIndex = 10;
            buttonOk.Text = "Ok";
            buttonOk.UseVisualStyleBackColor = true;
            buttonOk.Click += buttonOk_Click;
            // 
            // CurrencyForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(410, 173);
            Controls.Add(buttonOk);
            Controls.Add(buttonCancel);
            Controls.Add(textBoxId);
            Controls.Add(labelId);
            Controls.Add(checkBoxIsVisible);
            Controls.Add(textBoxCode);
            Controls.Add(labelCode);
            Controls.Add(textBoxName);
            Controls.Add(labelName);
            Controls.Add(textBoxSymbol);
            Controls.Add(labelSymbol);
            MinimumSize = new Size(426, 212);
            Name = "CurrencyForm";
            Text = "Валюта";
            Load += CurrencyForm_Load;
            ((System.ComponentModel.ISupportInitialize)c1CommandHolder1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelSymbol;
        private TextBox textBoxSymbol;
        private Label labelName;
        private TextBox textBoxName;
        private Label labelCode;
        private C1.Win.Command.C1CommandHolder c1CommandHolder1;
        private TextBox textBoxCode;
        private TextBox textBoxId;
        private Label labelId;
        private CheckBox checkBoxIsVisible;
        private Button buttonOk;
        private Button buttonCancel;
    }
}