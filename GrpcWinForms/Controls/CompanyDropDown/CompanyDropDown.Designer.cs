using C1.Win.Input;

namespace GrpcWinForms.Objects.Contragents.Components
{
    partial class CompanyDropDown
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CompanyDropDown));
            companyDropDownForm = new CompanyDropDownForm();
            ((System.ComponentModel.ISupportInitialize)this).BeginInit();
            SuspendLayout();
            // 
            // companyDropDownForm
            // 
            companyDropDownForm.ContragentSelected = null;
            companyDropDownForm.Name = "companyDropDownForm";
            companyDropDownForm.Size = new Size(380, 300);
            companyDropDownForm.TabIndex = 0;
            // 
            // CompanyDropDown
            // 
            ButtonsSettings.CustomButton.Icon = new C1.Framework.C1BitmapIcon(null, new Size(16, 16), Color.Transparent, Properties.Resources.icons8_multiply_16);
            ButtonsSettings.CustomButton.Visible = true;
            Control = companyDropDownForm;
            DropDownAlign = C1.Framework.DropDownAlignment.Left;
            DropDownWidth = 300;
            CustomButtonClick += CompanyDropDown_CustomButtonClick;
            TextChanged += CompanyDropDown_TextChanged;
            KeyPress += CompanyDropDown_KeyPress;
            Leave += CompanyDropDown_Leave;
            ((System.ComponentModel.ISupportInitialize)this).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private CompanyDropDownForm companyDropDownForm;

    }
}
