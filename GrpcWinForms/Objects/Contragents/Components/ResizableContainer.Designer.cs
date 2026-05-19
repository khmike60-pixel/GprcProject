namespace GrpcWinForms.Objects.Contragents.Components
{
    partial class ResizableContainer
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
            statusStrip = new StatusStrip();
            SuspendLayout();
            // 
            // statusStrip
            // 
            statusStrip.BackColor = Color.Transparent;
            statusStrip.Location = new Point(0, 91);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(182, 22);
            statusStrip.TabIndex = 0;
            statusStrip.Text = "statusStrip1";
            statusStrip.MouseDown += Resizer_MouseDown;
            statusStrip.MouseMove += Resizer_MouseMove;
            statusStrip.MouseUp += Resizer_MouseUp;
            // 
            // ResizableContainer
            // 
            Controls.Add(statusStrip);
            Name = "ResizableContainer";
            Size = new Size(182, 113);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private StatusStrip statusStrip;
    }
}
