namespace GrpcWinForms.Objects.Applications.Forms
{
    partial class ApplicationForm
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
            labelId = new Label();
            textBoxId = new TextBox();
            labelName = new Label();
            textBoxName = new TextBox();
            labelDb = new Label();
            textBoxDb = new TextBox();
            labelProduct = new Label();
            textBoxProduct = new TextBox();
            buttonCancel = new Button();
            buttonOk = new Button();
            SuspendLayout();
            // 
            // labelId
            // 
            labelId.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelId.AutoSize = true;
            labelId.Location = new Point(337, 45);
            labelId.Name = "labelId";
            labelId.Size = new Size(20, 15);
            labelId.TabIndex = 6;
            labelId.Text = "Id:";
            // 
            // textBoxId
            // 
            textBoxId.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            textBoxId.Location = new Point(363, 41);
            textBoxId.Name = "textBoxId";
            textBoxId.ReadOnly = true;
            textBoxId.Size = new Size(99, 23);
            textBoxId.TabIndex = 7;
            textBoxId.Text = "Новый";
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Location = new Point(10, 16);
            labelName.Name = "labelName";
            labelName.Size = new Size(138, 15);
            labelName.TabIndex = 0;
            labelName.Text = "Описание приложения:";
            // 
            // textBoxName
            // 
            textBoxName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxName.Location = new Point(154, 12);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(308, 23);
            textBoxName.TabIndex = 1;
            textBoxName.Text = "Балансы подразделения, кассы, утвержденные курсы";
            // 
            // labelDb
            // 
            labelDb.AutoSize = true;
            labelDb.Location = new Point(70, 45);
            labelDb.Name = "labelDb";
            labelDb.Size = new Size(78, 15);
            labelDb.TabIndex = 2;
            labelDb.Text = "База данных:";
            // 
            // textBoxDb
            // 
            textBoxDb.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxDb.Location = new Point(154, 41);
            textBoxDb.Name = "textBoxDb";
            textBoxDb.Size = new Size(133, 23);
            textBoxDb.TabIndex = 3;
            textBoxDb.Text = "Subdivfinances";
            // 
            // labelProduct
            // 
            labelProduct.AutoSize = true;
            labelProduct.Location = new Point(45, 73);
            labelProduct.Name = "labelProduct";
            labelProduct.Size = new Size(103, 15);
            labelProduct.TabIndex = 4;
            labelProduct.Text = "Код приложения:";
            // 
            // textBoxProduct
            // 
            textBoxProduct.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxProduct.Location = new Point(154, 70);
            textBoxProduct.Name = "textBoxProduct";
            textBoxProduct.Size = new Size(133, 23);
            textBoxProduct.TabIndex = 5;
            textBoxProduct.Text = "subdivfinances";
            // 
            // buttonCancel
            // 
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Location = new Point(387, 111);
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
            buttonOk.Location = new Point(306, 111);
            buttonOk.Name = "buttonOk";
            buttonOk.Size = new Size(75, 23);
            buttonOk.TabIndex = 8;
            buttonOk.Text = "Ok";
            buttonOk.UseVisualStyleBackColor = true;
            buttonOk.Click += buttonOk_Click;
            // 
            // ApplicationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(474, 146);
            Controls.Add(buttonOk);
            Controls.Add(buttonCancel);
            Controls.Add(textBoxProduct);
            Controls.Add(labelProduct);
            Controls.Add(textBoxDb);
            Controls.Add(labelDb);
            Controls.Add(textBoxName);
            Controls.Add(labelName);
            Controls.Add(textBoxId);
            Controls.Add(labelId);
            MaximizeBox = false;
            MaximumSize = new Size(607, 185);
            MinimumSize = new Size(446, 185);
            Name = "ApplicationForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Добавить или редактировать Приложение";
            Load += ApplicationForm_Load;
            KeyDown += ApplicationForm_KeyDown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelId;
        private TextBox textBoxId;
        private Label labelName;
        private TextBox textBoxName;
        private Label labelDb;
        private TextBox textBoxDb;
        private Label labelProduct;
        private TextBox textBoxProduct;
        private Button buttonCancel;
        private Button buttonOk;
    }
}