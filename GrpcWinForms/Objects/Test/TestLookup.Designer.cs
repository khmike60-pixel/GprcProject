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
            buttonCancel = new Button();
            textBox1 = new TextBox();
            smartBoxCurrency = new GrpcWinForms.Controls.SmartBox.SmartBox(components);
            smartBoxDepartment = new GrpcWinForms.Controls.SmartBox.SmartBox(components);
            c1Button1 = new C1.Win.Input.C1Button();
            ((System.ComponentModel.ISupportInitialize)smartBoxCurrency).BeginInit();
            ((System.ComponentModel.ISupportInitialize)smartBoxDepartment).BeginInit();
            ((System.ComponentModel.ISupportInitialize)c1Button1).BeginInit();
            SuspendLayout();
            // 
            // buttonCancel
            // 
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.AutoSize = true;
            buttonCancel.Location = new Point(383, 257);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 25);
            buttonCancel.TabIndex = 23;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(82, 170);
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
            // c1Button1
            // 
            c1Button1.Location = new Point(296, 187);
            c1Button1.Name = "c1Button1";
            c1Button1.Size = new Size(75, 23);
            c1Button1.TabIndex = 28;
            c1Button1.Text = "Статус";
            c1Button1.Click += c1Button1_Click;
            // 
            // TestLookup
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(470, 294);
            Controls.Add(c1Button1);
            Controls.Add(smartBoxDepartment);
            Controls.Add(smartBoxCurrency);
            Controls.Add(textBox1);
            Controls.Add(buttonCancel);
            Name = "TestLookup";
            Text = "TestLoolkup";
            Load += TestLookup_Load;
            ((System.ComponentModel.ISupportInitialize)smartBoxCurrency).EndInit();
            ((System.ComponentModel.ISupportInitialize)smartBoxDepartment).EndInit();
            ((System.ComponentModel.ISupportInitialize)c1Button1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button buttonCancel;
        private TextBox textBox1;
        private Controls.SmartBox.SmartBox smartBoxCurrency;
        private Controls.SmartBox.SmartBox smartBoxDepartment;
        private C1.Win.Input.C1Button c1Button1;
    }
}