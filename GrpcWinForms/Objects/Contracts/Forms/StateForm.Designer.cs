namespace GrpcWinForms.Objects.Contracts.Forms
{
    partial class StateForm
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
            lDocName = new Label();
            label1 = new Label();
            label2 = new Label();
            txDocName = new TextBox();
            tbNumber = new TextBox();
            cdtDate = new C1.Win.Calendar.C1DateEdit();
            chkSigned = new C1.Win.Input.C1CheckBox();
            chkActived = new C1.Win.Input.C1CheckBox();
            chkComplited = new C1.Win.Input.C1CheckBox();
            buttonOk = new Button();
            buttonCancel = new Button();
            chkSentToClient = new C1.Win.Input.C1CheckBox();
            ((System.ComponentModel.ISupportInitialize)cdtDate).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chkSigned).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chkActived).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chkComplited).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chkSentToClient).BeginInit();
            SuspendLayout();
            // 
            // lDocName
            // 
            lDocName.AutoSize = true;
            lDocName.Location = new Point(11, 15);
            lDocName.Name = "lDocName";
            lDocName.Size = new Size(64, 15);
            lDocName.TabIndex = 0;
            lDocName.Text = "Документ:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 44);
            label1.Name = "label1";
            label1.Size = new Size(48, 15);
            label1.TabIndex = 1;
            label1.Text = "Номер:";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(182, 44);
            label2.Name = "label2";
            label2.Size = new Size(22, 15);
            label2.TabIndex = 2;
            label2.Text = "от:";
            // 
            // txDocName
            // 
            txDocName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txDocName.Location = new Point(81, 12);
            txDocName.Name = "txDocName";
            txDocName.ReadOnly = true;
            txDocName.Size = new Size(229, 23);
            txDocName.TabIndex = 7;
            // 
            // tbNumber
            // 
            tbNumber.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbNumber.Location = new Point(81, 41);
            tbNumber.Name = "tbNumber";
            tbNumber.ReadOnly = true;
            tbNumber.Size = new Size(94, 23);
            tbNumber.TabIndex = 8;
            // 
            // cdtDate
            // 
            cdtDate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cdtDate.DisplayFormat.FormatType = C1.Win.Input.FormatType.ShortDate;
            cdtDate.DisplayFormat.Inherit = C1.Win.Input.FormatInfoInheritProperties.CustomFormat | C1.Win.Input.FormatInfoInheritProperties.NullText | C1.Win.Input.FormatInfoInheritProperties.EmptyAsNull | C1.Win.Input.FormatInfoInheritProperties.TrimStart | C1.Win.Input.FormatInfoInheritProperties.TrimEnd | C1.Win.Input.FormatInfoInheritProperties.CalendarType;
            cdtDate.FormatType = C1.Win.Input.FormatType.ShortDate;
            cdtDate.Location = new Point(210, 41);
            cdtDate.Name = "cdtDate";
            cdtDate.ReadOnly = true;
            cdtDate.Size = new Size(100, 23);
            cdtDate.TabIndex = 11;
            cdtDate.Value = new DateTime(2026, 12, 31, 0, 0, 0, 0);
            // 
            // chkSigned
            // 
            chkSigned.AutoSize = true;
            chkSigned.ImageAlign = ContentAlignment.MiddleLeft;
            chkSigned.Location = new Point(12, 125);
            chkSigned.Name = "chkSigned";
            chkSigned.Size = new Size(83, 19);
            chkSigned.TabIndex = 12;
            chkSigned.Text = "Подписан";
            chkSigned.CheckedChanged += chkBox_CheckedChanged;
            // 
            // chkActived
            // 
            chkActived.AutoSize = true;
            chkActived.Location = new Point(12, 165);
            chkActived.Name = "chkActived";
            chkActived.Size = new Size(73, 19);
            chkActived.TabIndex = 15;
            chkActived.Text = "Активен";
            chkActived.CheckedChanged += chkBox_CheckedChanged;
            // 
            // chkComplited
            // 
            chkComplited.AutoSize = true;
            chkComplited.Location = new Point(12, 205);
            chkComplited.Name = "chkComplited";
            chkComplited.Size = new Size(84, 19);
            chkComplited.TabIndex = 16;
            chkComplited.Text = "Исполнен";
            chkComplited.CheckedChanged += chkBox_CheckedChanged;
            // 
            // buttonOk
            // 
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonOk.Location = new Point(234, 233);
            buttonOk.Name = "buttonOk";
            buttonOk.Size = new Size(75, 23);
            buttonOk.TabIndex = 17;
            buttonOk.Text = "Ok";
            buttonOk.UseVisualStyleBackColor = true;
            buttonOk.Click += buttonOk_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Location = new Point(153, 233);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 23);
            buttonCancel.TabIndex = 18;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            // 
            // chkSentToClient
            // 
            chkSentToClient.AutoSize = true;
            chkSentToClient.Location = new Point(12, 85);
            chkSentToClient.Name = "chkSentToClient";
            chkSentToClient.Size = new Size(122, 19);
            chkSentToClient.TabIndex = 19;
            chkSentToClient.Text = "Передан клиенту";
            chkSentToClient.CheckedChanged += chkBox_CheckedChanged;
            // 
            // StateForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(321, 268);
            Controls.Add(chkSentToClient);
            Controls.Add(buttonCancel);
            Controls.Add(buttonOk);
            Controls.Add(chkComplited);
            Controls.Add(chkActived);
            Controls.Add(chkSigned);
            Controls.Add(cdtDate);
            Controls.Add(tbNumber);
            Controls.Add(txDocName);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lDocName);
            Name = "StateForm";
            Text = "Статус документа";
            Load += StateForm_Load;
            ((System.ComponentModel.ISupportInitialize)cdtDate).EndInit();
            ((System.ComponentModel.ISupportInitialize)chkSigned).EndInit();
            ((System.ComponentModel.ISupportInitialize)chkActived).EndInit();
            ((System.ComponentModel.ISupportInitialize)chkComplited).EndInit();
            ((System.ComponentModel.ISupportInitialize)chkSentToClient).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lDocName;
        private Label label1;
        private Label label2;
        private TextBox txDocName;
        private TextBox tbNumber;
        private C1.Win.Calendar.C1DateEdit cdtDate;
        private C1.Win.Input.C1CheckBox chkSigned;
        private C1.Win.Input.C1CheckBox chkActived;
        private C1.Win.Input.C1CheckBox chkComplited;
        private Button buttonOk;
        private Button buttonCancel;
        private C1.Win.Input.C1CheckBox chkSentToClient;
    }
}