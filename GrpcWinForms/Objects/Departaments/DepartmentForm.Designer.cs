namespace GrpcWinForms.Objects.Departaments
{
    partial class DepartmentForm
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
            lName = new Label();
            label2 = new Label();
            buttonOk = new Button();
            buttonCancel = new Button();
            tName = new TextBox();
            tCode = new TextBox();
            tShort = new TextBox();
            lShort = new Label();
            lId = new Label();
            tId = new TextBox();
            SuspendLayout();
            // 
            // lName
            // 
            lName.AutoSize = true;
            lName.Location = new Point(12, 39);
            lName.Name = "lName";
            lName.Size = new Size(137, 15);
            lName.TabIndex = 0;
            lName.Text = "Полное наименование:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(116, 96);
            label2.Name = "label2";
            label2.Size = new Size(30, 15);
            label2.TabIndex = 1;
            label2.Text = "Код:";
            // 
            // buttonOk
            // 
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonOk.Location = new Point(327, 127);
            buttonOk.Name = "buttonOk";
            buttonOk.Size = new Size(75, 23);
            buttonOk.TabIndex = 4;
            buttonOk.Text = "Ok";
            buttonOk.UseVisualStyleBackColor = true;
            buttonOk.Click += buttonOk_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Location = new Point(413, 127);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 23);
            buttonCancel.TabIndex = 5;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // tName
            // 
            tName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tName.Location = new Point(155, 35);
            tName.Name = "tName";
            tName.Size = new Size(333, 23);
            tName.TabIndex = 1;
            // 
            // tCode
            // 
            tCode.Location = new Point(155, 93);
            tCode.Name = "tCode";
            tCode.Size = new Size(44, 23);
            tCode.TabIndex = 3;
            // 
            // tShort
            // 
            tShort.Location = new Point(155, 64);
            tShort.Name = "tShort";
            tShort.Size = new Size(122, 23);
            tShort.TabIndex = 2;
            // 
            // lShort
            // 
            lShort.AutoSize = true;
            lShort.Location = new Point(8, 67);
            lShort.Name = "lShort";
            lShort.Size = new Size(138, 15);
            lShort.TabIndex = 16;
            lShort.Text = "Краткое наименование:";
            // 
            // lId
            // 
            lId.AutoSize = true;
            lId.Location = new Point(49, 9);
            lId.Name = "lId";
            lId.Size = new Size(97, 15);
            lId.TabIndex = 17;
            lId.Text = "Идентификатор:";
            // 
            // tId
            // 
            tId.Location = new Point(155, 6);
            tId.Name = "tId";
            tId.ReadOnly = true;
            tId.Size = new Size(122, 23);
            tId.TabIndex = 18;
            // 
            // DepartmentForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(498, 162);
            Controls.Add(tId);
            Controls.Add(lId);
            Controls.Add(lShort);
            Controls.Add(tShort);
            Controls.Add(tCode);
            Controls.Add(tName);
            Controls.Add(buttonOk);
            Controls.Add(buttonCancel);
            Controls.Add(label2);
            Controls.Add(lName);
            MinimumSize = new Size(303, 201);
            Name = "DepartmentForm";
            Text = "Подразделение";
            Load += DepartmentForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lName;
        private Label label2;
        private Button buttonOk;
        private Button buttonCancel;
        private TextBox tName;
        private TextBox tCode;
        private TextBox tShort;
        private Label lShort;
        private Label lId;
        private TextBox tId;
    }
}