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
            components = new System.ComponentModel.Container();
            companyDropDownForm = new CompanyDropDownForm();

            ButtonsSettings.CustomButton.Icon = new C1.Framework.C1BitmapIcon(null, new Size(16, 16), Color.Transparent, Properties.Resources.icons8_multiply_16);
            ButtonsSettings.CustomButton.Visible = true;
            Name = "CompanyDropDown";
            Control = companyDropDownForm;
            TextChanged += CompanyDropDown_TextChanged;
            CustomButtonClick += CompanyDropDown_CustomButtonClick;
            Leave += CompanyDropDown_Leave;
            KeyPress += CompanyDropDown_KeyPress;

        }

        #endregion

        private CompanyDropDownForm companyDropDownForm;

    }
}
