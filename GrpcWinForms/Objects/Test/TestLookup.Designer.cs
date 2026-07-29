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
            label2 = new Label();
            c1DropDownControl1 = new C1.Win.Input.C1DropDownControl();
            label1 = new Label();
            companyDropDown1 = new GrpcWinForms.Objects.Contragents.Components.CompanyDropDown(components);
            buttonCancel = new Button();
            buttonUpdate = new Button();
            buttonUpdateExit = new Button();
            periodComponent1 = new GrpcWinForms.Controls.PeriodControl.PeriodComponent(components);
            ((System.ComponentModel.ISupportInitialize)c1DropDownControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)companyDropDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)periodComponent1).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(25, 25);
            label2.Name = "label2";
            label2.Size = new Size(104, 15);
            label2.TabIndex = 3;
            label2.Text = "DropDownControl";
            // 
            // c1DropDownControl1
            // 
            c1DropDownControl1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            c1DropDownControl1.ButtonsSettings.CustomButton.Icon = new C1.Framework.C1BitmapIcon(null, new Size(16, 16), Color.Transparent, Properties.Resources.icons8_multiply_16);
            c1DropDownControl1.ButtonsSettings.CustomButton.Visible = true;
            c1DropDownControl1.Location = new Point(228, 21);
            c1DropDownControl1.Name = "c1DropDownControl1";
            c1DropDownControl1.Size = new Size(387, 23);
            c1DropDownControl1.TabIndex = 4;
            c1DropDownControl1.Value = "";
            c1DropDownControl1.CustomButtonClick += c1DropDownControl1_CustomButtonClick;
            c1DropDownControl1.TextChanged += c1DropDownControl1_TextChanged;
            c1DropDownControl1.KeyPress += c1DropDownControl1_KeyPress;
            c1DropDownControl1.Leave += c1DropDownControl1_Leave;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 107);
            label1.Name = "label1";
            label1.Size = new Size(181, 15);
            label1.TabIndex = 5;
            label1.Text = "Компонент CompanyDropDown";
            // 
            // companyDropDown1
            // 
            companyDropDown1.ButtonsSettings.CustomButton.Icon = new C1.Framework.C1BitmapIcon(null, new Size(16, 16), Color.Transparent, (Image)resources.GetObject("companyDropDown1.ButtonsSettings.CustomButton.Icon"));
            companyDropDown1.ButtonsSettings.CustomButton.Visible = true;
            companyDropDown1.DropDownAlign = C1.Framework.DropDownAlignment.Left;
            companyDropDown1.DropDownWidth = 300;
            companyDropDown1.GetDataSourceFunc = null;
            companyDropDown1.Location = new Point(228, 107);
            companyDropDown1.Name = "companyDropDown1";
            companyDropDown1.Size = new Size(387, 23);
            companyDropDown1.TabIndex = 6;
            companyDropDown1.Value = "";
            // 
            // buttonCancel
            // 
            buttonCancel.AutoSize = true;
            buttonCancel.Location = new Point(546, 415);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 25);
            buttonCancel.TabIndex = 7;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // buttonUpdate
            // 
            buttonUpdate.Location = new Point(465, 417);
            buttonUpdate.Name = "buttonUpdate";
            buttonUpdate.Size = new Size(75, 23);
            buttonUpdate.TabIndex = 8;
            buttonUpdate.Text = "Записать";
            buttonUpdate.UseVisualStyleBackColor = true;
            buttonUpdate.Click += buttonUpdate_Click;
            // 
            // buttonUpdateExit
            // 
            buttonUpdateExit.Location = new Point(337, 417);
            buttonUpdateExit.Name = "buttonUpdateExit";
            buttonUpdateExit.Size = new Size(122, 23);
            buttonUpdateExit.TabIndex = 9;
            buttonUpdateExit.Text = "Записать и выйти";
            buttonUpdateExit.UseVisualStyleBackColor = true;
            // 
            // periodComponent1
            // 
            periodComponent1.EndDate = new DateTime(0L);
            periodComponent1.Location = new Point(228, 184);
            periodComponent1.Name = "periodComponent1";
            periodComponent1.Size = new Size(179, 23);
            periodComponent1.StartDate = new DateTime(0L);
            periodComponent1.TabIndex = 10;
            periodComponent1.Value = "";
            // 
            // TestLookup
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(627, 450);
            Controls.Add(periodComponent1);
            Controls.Add(buttonUpdateExit);
            Controls.Add(buttonUpdate);
            Controls.Add(buttonCancel);
            Controls.Add(companyDropDown1);
            Controls.Add(label1);
            Controls.Add(c1DropDownControl1);
            Controls.Add(label2);
            Name = "TestLookup";
            Text = "TestLoolkup";
            ((System.ComponentModel.ISupportInitialize)c1DropDownControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)companyDropDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)periodComponent1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label2;
        private C1.Win.Input.C1DropDownControl c1DropDownControl1;
        private Label label1;
        private Contragents.Components.CompanyDropDown companyDropDown1;
        private Button buttonCancel;
        private Button buttonUpdate;
        private Button buttonUpdateExit;
        private Controls.PeriodControl.PeriodComponent periodComponent1;
    }
}