namespace GrpcWinForms.Objects.Users.Forms
{
    partial class UserForm
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
            buttonCancel = new Button();
            buttonOk = new Button();
            labelContragent = new Label();
            labelLogin = new Label();
            labelShortName = new Label();
            textBoxLogin = new TextBox();
            textBoxShortName = new TextBox();
            lookupContragent = new C1.Win.Input.C1DropDownControl();
            textBoxPassword = new TextBox();
            textBoxSymbol = new TextBox();
            labelPassword = new Label();
            labelSymbol = new Label();
            labelIsBlocked = new Label();
            checkBoxIsBlocked = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)lookupContragent).BeginInit();
            SuspendLayout();
            // 
            // buttonCancel
            // 
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Location = new Point(301, 159);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 23);
            buttonCancel.TabIndex = 12;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // buttonOk
            // 
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonOk.Location = new Point(220, 159);
            buttonOk.Name = "buttonOk";
            buttonOk.Size = new Size(75, 23);
            buttonOk.TabIndex = 11;
            buttonOk.Text = "Ok";
            buttonOk.UseVisualStyleBackColor = true;
            buttonOk.Click += buttonOk_Click;
            // 
            // labelContragent
            // 
            labelContragent.AutoSize = true;
            labelContragent.Location = new Point(12, 13);
            labelContragent.Name = "labelContragent";
            labelContragent.Size = new Size(72, 15);
            labelContragent.TabIndex = 1;
            labelContragent.Text = "Контрагент:";
            labelContragent.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelLogin
            // 
            labelLogin.AutoSize = true;
            labelLogin.Location = new Point(12, 71);
            labelLogin.Name = "labelLogin";
            labelLogin.Size = new Size(44, 15);
            labelLogin.TabIndex = 3;
            labelLogin.Text = "Логин:";
            labelLogin.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelShortName
            // 
            labelShortName.AutoSize = true;
            labelShortName.Location = new Point(12, 42);
            labelShortName.Name = "labelShortName";
            labelShortName.Size = new Size(79, 15);
            labelShortName.TabIndex = 7;
            labelShortName.Text = "Краткое имя:";
            labelShortName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBoxLogin
            // 
            textBoxLogin.Location = new Point(102, 67);
            textBoxLogin.Name = "textBoxLogin";
            textBoxLogin.Size = new Size(113, 23);
            textBoxLogin.TabIndex = 4;
            // 
            // textBoxShortName
            // 
            textBoxShortName.Location = new Point(102, 38);
            textBoxShortName.Name = "textBoxShortName";
            textBoxShortName.ReadOnly = true;
            textBoxShortName.Size = new Size(149, 23);
            textBoxShortName.TabIndex = 8;
            // 
            // lookupContragent
            // 
            lookupContragent.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lookupContragent.ButtonsSettings.ModalButton.Visible = true;
            lookupContragent.Location = new Point(102, 9);
            lookupContragent.Name = "lookupContragent";
            lookupContragent.Size = new Size(274, 23);
            lookupContragent.TabIndex = 2;
            // 
            // textBoxPassword
            // 
            textBoxPassword.Location = new Point(102, 96);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.PasswordChar = '*';
            textBoxPassword.Size = new Size(113, 23);
            textBoxPassword.TabIndex = 6;
            // 
            // textBoxSymbol
            // 
            textBoxSymbol.Location = new Point(323, 38);
            textBoxSymbol.Name = "textBoxSymbol";
            textBoxSymbol.Size = new Size(53, 23);
            textBoxSymbol.TabIndex = 10;
            // 
            // labelPassword
            // 
            labelPassword.AutoSize = true;
            labelPassword.Location = new Point(12, 100);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(52, 15);
            labelPassword.TabIndex = 5;
            labelPassword.Text = "Пароль:";
            labelPassword.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelSymbol
            // 
            labelSymbol.AutoSize = true;
            labelSymbol.Location = new Point(263, 42);
            labelSymbol.Name = "labelSymbol";
            labelSymbol.Size = new Size(54, 15);
            labelSymbol.TabIndex = 9;
            labelSymbol.Text = "Символ:";
            labelSymbol.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelIsBlocked
            // 
            labelIsBlocked.AutoSize = true;
            labelIsBlocked.Location = new Point(14, 126);
            labelIsBlocked.Name = "labelIsBlocked";
            labelIsBlocked.Size = new Size(77, 15);
            labelIsBlocked.TabIndex = 11;
            labelIsBlocked.Text = "Блокирован:";
            labelIsBlocked.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // checkBoxIsBlocked
            // 
            checkBoxIsBlocked.AutoSize = true;
            checkBoxIsBlocked.Location = new Point(102, 127);
            checkBoxIsBlocked.Name = "checkBoxIsBlocked";
            checkBoxIsBlocked.Size = new Size(15, 14);
            checkBoxIsBlocked.TabIndex = 12;
            checkBoxIsBlocked.UseVisualStyleBackColor = true;
            // 
            // UserForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(387, 194);
            Controls.Add(textBoxSymbol);
            Controls.Add(textBoxLogin);
            Controls.Add(labelSymbol);
            Controls.Add(labelContragent);
            Controls.Add(checkBoxIsBlocked);
            Controls.Add(textBoxShortName);
            Controls.Add(labelLogin);
            Controls.Add(lookupContragent);
            Controls.Add(labelShortName);
            Controls.Add(buttonOk);
            Controls.Add(textBoxPassword);
            Controls.Add(buttonCancel);
            Controls.Add(labelPassword);
            Controls.Add(labelIsBlocked);
            MaximumSize = new Size(403, 233);
            MinimumSize = new Size(403, 233);
            Name = "UserForm";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Пользователь";
            Load += UserForm_Load;
            ((System.ComponentModel.ISupportInitialize)lookupContragent).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonCancel;
        private Button buttonOk;
        private Label labelContragent;
        private Label labelLogin;
        private Label labelShortName;
        private TextBox textBoxLogin;
        private TextBox textBoxShortName;
        private C1.Win.Input.C1DropDownControl lookupContragent;
        private Label labelPassword;
        private TextBox textBoxPassword;
        private Label labelSymbol;
        private TextBox textBoxSymbol;
        private Label labelIsBlocked;
        private CheckBox checkBoxIsBlocked;
    }
}