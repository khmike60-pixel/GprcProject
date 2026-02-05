namespace GrpcWinForms.Objects.Units.Forms
{
    partial class UnitForm
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
            labelShort = new Label();
            textBoxShort = new TextBox();
            labelRem = new Label();
            textBoxRem = new TextBox();
            buttonOk = new Button();
            buttonCancel = new Button();
            labelRwsCode = new Label();
            textBoxRwsCode = new TextBox();
            textBoxRwsMcode = new TextBox();
            labelRwsMcode = new Label();
            labelId = new Label();
            textBoxId = new TextBox();
            labelComment = new Label();
            textBoxComment = new TextBox();
            labelCode = new Label();
            textBoxCode = new TextBox();
            checkBoxIsArchive = new CheckBox();
            SuspendLayout();
            // 
            // labelShort
            // 
            labelShort.AutoSize = true;
            labelShort.Location = new Point(12, 9);
            labelShort.Name = "labelShort";
            labelShort.Size = new Size(138, 15);
            labelShort.TabIndex = 0;
            labelShort.Text = "Краткое наименование:";
            // 
            // textBoxShort
            // 
            textBoxShort.Location = new Point(153, 5);
            textBoxShort.Name = "textBoxShort";
            textBoxShort.Size = new Size(100, 23);
            textBoxShort.TabIndex = 1;
            // 
            // labelRem
            // 
            labelRem.AutoSize = true;
            labelRem.Location = new Point(12, 37);
            labelRem.Name = "labelRem";
            labelRem.Size = new Size(65, 15);
            labelRem.TabIndex = 2;
            labelRem.Text = "Описание:";
            // 
            // textBoxRem
            // 
            textBoxRem.Location = new Point(153, 34);
            textBoxRem.Name = "textBoxRem";
            textBoxRem.Size = new Size(100, 23);
            textBoxRem.TabIndex = 3;
            // 
            // buttonOk
            // 
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonOk.Location = new Point(232, 150);
            buttonOk.Name = "buttonOk";
            buttonOk.Size = new Size(75, 23);
            buttonOk.TabIndex = 30;
            buttonOk.Text = "Ok";
            buttonOk.UseVisualStyleBackColor = true;
            buttonOk.Click += buttonOk_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Location = new Point(313, 150);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 23);
            buttonCancel.TabIndex = 31;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // labelRwsCode
            // 
            labelRwsCode.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelRwsCode.AutoSize = true;
            labelRwsCode.Location = new Point(267, 67);
            labelRwsCode.Name = "labelRwsCode";
            labelRwsCode.Size = new Size(47, 15);
            labelRwsCode.TabIndex = 6;
            labelRwsCode.Text = "RWS Id:";
            // 
            // textBoxRwsCode
            // 
            textBoxRwsCode.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            textBoxRwsCode.Location = new Point(320, 63);
            textBoxRwsCode.Name = "textBoxRwsCode";
            textBoxRwsCode.ReadOnly = true;
            textBoxRwsCode.Size = new Size(68, 23);
            textBoxRwsCode.TabIndex = 51;
            // 
            // textBoxRwsMcode
            // 
            textBoxRwsMcode.Location = new Point(153, 63);
            textBoxRwsMcode.Name = "textBoxRwsMcode";
            textBoxRwsMcode.ReadOnly = true;
            textBoxRwsMcode.Size = new Size(100, 23);
            textBoxRwsMcode.TabIndex = 5;
            // 
            // labelRwsMcode
            // 
            labelRwsMcode.AutoSize = true;
            labelRwsMcode.Location = new Point(12, 67);
            labelRwsMcode.Name = "labelRwsMcode";
            labelRwsMcode.Size = new Size(129, 15);
            labelRwsMcode.TabIndex = 4;
            labelRwsMcode.Text = "Наименование в RWS:";
            // 
            // labelId
            // 
            labelId.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelId.AutoSize = true;
            labelId.Location = new Point(294, 9);
            labelId.Name = "labelId";
            labelId.Size = new Size(20, 15);
            labelId.TabIndex = 30;
            labelId.Text = "Id:";
            // 
            // textBoxId
            // 
            textBoxId.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            textBoxId.Location = new Point(320, 5);
            textBoxId.Name = "textBoxId";
            textBoxId.ReadOnly = true;
            textBoxId.Size = new Size(68, 23);
            textBoxId.TabIndex = 50;
            // 
            // labelComment
            // 
            labelComment.AutoSize = true;
            labelComment.Location = new Point(12, 96);
            labelComment.Name = "labelComment";
            labelComment.Size = new Size(87, 15);
            labelComment.TabIndex = 6;
            labelComment.Text = "Комментарий:";
            // 
            // textBoxComment
            // 
            textBoxComment.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxComment.Location = new Point(153, 92);
            textBoxComment.Name = "textBoxComment";
            textBoxComment.Size = new Size(235, 23);
            textBoxComment.TabIndex = 7;
            // 
            // labelCode
            // 
            labelCode.AutoSize = true;
            labelCode.Location = new Point(12, 125);
            labelCode.Name = "labelCode";
            labelCode.Size = new Size(85, 15);
            labelCode.TabIndex = 8;
            labelCode.Text = "Код по ГОСТу:";
            // 
            // textBoxCode
            // 
            textBoxCode.Location = new Point(153, 121);
            textBoxCode.Name = "textBoxCode";
            textBoxCode.Size = new Size(100, 23);
            textBoxCode.TabIndex = 9;
            // 
            // checkBoxIsArchive
            // 
            checkBoxIsArchive.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            checkBoxIsArchive.AutoSize = true;
            checkBoxIsArchive.Location = new Point(305, 123);
            checkBoxIsArchive.Name = "checkBoxIsArchive";
            checkBoxIsArchive.Size = new Size(83, 19);
            checkBoxIsArchive.TabIndex = 10;
            checkBoxIsArchive.Text = "Архивный";
            checkBoxIsArchive.UseVisualStyleBackColor = true;
            // 
            // UnitForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(400, 182);
            Controls.Add(checkBoxIsArchive);
            Controls.Add(textBoxCode);
            Controls.Add(labelCode);
            Controls.Add(textBoxComment);
            Controls.Add(labelComment);
            Controls.Add(textBoxId);
            Controls.Add(labelId);
            Controls.Add(labelRwsMcode);
            Controls.Add(textBoxRwsMcode);
            Controls.Add(textBoxRwsCode);
            Controls.Add(labelRwsCode);
            Controls.Add(buttonCancel);
            Controls.Add(buttonOk);
            Controls.Add(textBoxRem);
            Controls.Add(labelRem);
            Controls.Add(textBoxShort);
            Controls.Add(labelShort);
            MinimumSize = new Size(416, 221);
            Name = "UnitForm";
            ShowInTaskbar = false;
            Text = "Единица измерения";
            Load += UnitForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelShort;
        private TextBox textBoxShort;
        private Label labelRem;
        private TextBox textBoxRem;
        private Button buttonOk;
        private Button buttonCancel;
        private Label labelRwsCode;
        private TextBox textBoxRwsCode;
        private TextBox textBoxRwsMcode;
        private Label labelRwsMcode;
        private Label labelId;
        private TextBox textBoxId;
        private Label labelComment;
        private TextBox textBoxComment;
        private Label labelCode;
        private TextBox textBoxCode;
        private CheckBox checkBoxIsArchive;
    }
}