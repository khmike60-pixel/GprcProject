namespace GrpcWinForms.Forms
{
    partial class LoginForm
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
            loginTextBox = new TextBox();
            passwordTextBox = new TextBox();
            buttonOk = new Button();
            buttonCancel = new Button();
            labelText = new Label();
            labelLogin = new Label();
            labelPassword = new Label();
            labelError = new Label();
            SuspendLayout();
            // 
            // loginTextBox
            // 
            loginTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            loginTextBox.Location = new Point(90, 32);
            loginTextBox.Name = "loginTextBox";
            loginTextBox.Size = new Size(193, 23);
            loginTextBox.TabIndex = 0;
            loginTextBox.Text = "khmike";
            // 
            // passwordTextBox
            // 
            passwordTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            passwordTextBox.Location = new Point(90, 61);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.PasswordChar = '*';
            passwordTextBox.Size = new Size(193, 23);
            passwordTextBox.TabIndex = 1;
            passwordTextBox.Text = "ReCC168l";
            // 
            // buttonOk
            // 
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonOk.Location = new Point(127, 115);
            buttonOk.Name = "buttonOk";
            buttonOk.Size = new Size(75, 23);
            buttonOk.TabIndex = 2;
            buttonOk.Text = "Ok";
            buttonOk.UseVisualStyleBackColor = true;
            buttonOk.Click += btnLogin_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Location = new Point(208, 115);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 23);
            buttonCancel.TabIndex = 3;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // labelText
            // 
            labelText.AutoSize = true;
            labelText.Location = new Point(12, 8);
            labelText.Name = "labelText";
            labelText.Size = new Size(218, 15);
            labelText.TabIndex = 4;
            labelText.Text = "Введите свои данные для авторизации";
            // 
            // labelLogin
            // 
            labelLogin.AutoSize = true;
            labelLogin.Location = new Point(14, 35);
            labelLogin.Name = "labelLogin";
            labelLogin.Size = new Size(44, 15);
            labelLogin.TabIndex = 5;
            labelLogin.Text = "Логин:";
            // 
            // labelPassword
            // 
            labelPassword.AutoSize = true;
            labelPassword.Location = new Point(14, 64);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(52, 15);
            labelPassword.TabIndex = 6;
            labelPassword.Text = "Пароль:";
            // 
            // labelError
            // 
            labelError.AutoSize = true;
            labelError.Location = new Point(9, 97);
            labelError.Name = "labelError";
            labelError.Size = new Size(250, 15);
            labelError.TabIndex = 7;
            labelError.Text = "Ошибка  авторизации. Попробуйте еще раз";
            labelError.Visible = false;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(292, 150);
            Controls.Add(labelError);
            Controls.Add(labelPassword);
            Controls.Add(labelLogin);
            Controls.Add(labelText);
            Controls.Add(buttonCancel);
            Controls.Add(buttonOk);
            Controls.Add(passwordTextBox);
            Controls.Add(loginTextBox);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            MaximizeBox = false;
            MaximumSize = new Size(308, 189);
            MinimizeBox = false;
            MinimumSize = new Size(276, 189);
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Авторизация:  Bookkeep (gRPCLocalhost)";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox loginTextBox;
        private TextBox passwordTextBox;
        private Button buttonOk;
        private Button buttonCancel;
        private Label labelText;
        private Label labelLogin;
        private Label labelPassword;
        private Label labelError;
    }
}