namespace GrpcWinForms.Objects.Contracts.Forms.Controls
{
    partial class SumContractControl
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
            groupBox1 = new GroupBox();
            textBoxSumSaldo = new C1.Win.Input.C1TextBox();
            textBoxSumContract = new C1.Win.Input.C1TextBox();
            textBoxSumPayed = new C1.Win.Input.C1TextBox();
            labelContractSum = new Label();
            labelSumSaldo = new Label();
            labelSumDeliveried = new Label();
            labelSumPayed = new Label();
            textBoxSumDeliveried = new C1.Win.Input.C1TextBox();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)textBoxSumSaldo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)textBoxSumContract).BeginInit();
            ((System.ComponentModel.ISupportInitialize)textBoxSumPayed).BeginInit();
            ((System.ComponentModel.ISupportInitialize)textBoxSumDeliveried).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(textBoxSumSaldo);
            groupBox1.Controls.Add(textBoxSumContract);
            groupBox1.Controls.Add(textBoxSumPayed);
            groupBox1.Controls.Add(labelContractSum);
            groupBox1.Controls.Add(labelSumSaldo);
            groupBox1.Controls.Add(labelSumDeliveried);
            groupBox1.Controls.Add(labelSumPayed);
            groupBox1.Controls.Add(textBoxSumDeliveried);
            groupBox1.Location = new Point(3, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(271, 133);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            // 
            // textBoxSumSaldo
            // 
            textBoxSumSaldo.Cursor = Cursors.IBeam;
            textBoxSumSaldo.DisplayFormat.FormatType = C1.Win.Input.FormatType.StandardNumber;
            textBoxSumSaldo.DisplayFormat.Inherit = C1.Win.Input.FormatInfoInheritProperties.CustomFormat | C1.Win.Input.FormatInfoInheritProperties.NullText | C1.Win.Input.FormatInfoInheritProperties.EmptyAsNull | C1.Win.Input.FormatInfoInheritProperties.TrimStart | C1.Win.Input.FormatInfoInheritProperties.TrimEnd | C1.Win.Input.FormatInfoInheritProperties.CalendarType;
            textBoxSumSaldo.EditFormat.FormatType = C1.Win.Input.FormatType.StandardNumber;
            textBoxSumSaldo.EditFormat.Inherit = C1.Win.Input.FormatInfoInheritProperties.CustomFormat | C1.Win.Input.FormatInfoInheritProperties.NullText | C1.Win.Input.FormatInfoInheritProperties.EmptyAsNull | C1.Win.Input.FormatInfoInheritProperties.TrimStart | C1.Win.Input.FormatInfoInheritProperties.TrimEnd | C1.Win.Input.FormatInfoInheritProperties.CalendarType;
            textBoxSumSaldo.Location = new Point(141, 100);
            textBoxSumSaldo.Name = "textBoxSumSaldo";
            textBoxSumSaldo.Size = new Size(124, 23);
            textBoxSumSaldo.TabIndex = 6;
            textBoxSumSaldo.TextAlign = HorizontalAlignment.Right;
            textBoxSumSaldo.Value = "0";
            // 
            // textBoxSumContract
            // 
            textBoxSumContract.DisplayFormat.FormatType = C1.Win.Input.FormatType.StandardNumber;
            textBoxSumContract.DisplayFormat.Inherit = C1.Win.Input.FormatInfoInheritProperties.CustomFormat | C1.Win.Input.FormatInfoInheritProperties.NullText | C1.Win.Input.FormatInfoInheritProperties.EmptyAsNull | C1.Win.Input.FormatInfoInheritProperties.TrimStart | C1.Win.Input.FormatInfoInheritProperties.TrimEnd | C1.Win.Input.FormatInfoInheritProperties.CalendarType;
            textBoxSumContract.EditFormat.FormatType = C1.Win.Input.FormatType.StandardNumber;
            textBoxSumContract.EditFormat.Inherit = C1.Win.Input.FormatInfoInheritProperties.CustomFormat | C1.Win.Input.FormatInfoInheritProperties.NullText | C1.Win.Input.FormatInfoInheritProperties.EmptyAsNull | C1.Win.Input.FormatInfoInheritProperties.TrimStart | C1.Win.Input.FormatInfoInheritProperties.TrimEnd | C1.Win.Input.FormatInfoInheritProperties.CalendarType;
            textBoxSumContract.Location = new Point(141, 13);
            textBoxSumContract.Name = "textBoxSumContract";
            textBoxSumContract.Size = new Size(124, 23);
            textBoxSumContract.TabIndex = 1;
            textBoxSumContract.TextAlign = HorizontalAlignment.Right;
            textBoxSumContract.Value = "0";
            // 
            // textBoxSumPayed
            // 
            textBoxSumPayed.DisplayFormat.FormatType = C1.Win.Input.FormatType.StandardNumber;
            textBoxSumPayed.DisplayFormat.Inherit = C1.Win.Input.FormatInfoInheritProperties.CustomFormat | C1.Win.Input.FormatInfoInheritProperties.NullText | C1.Win.Input.FormatInfoInheritProperties.EmptyAsNull | C1.Win.Input.FormatInfoInheritProperties.TrimStart | C1.Win.Input.FormatInfoInheritProperties.TrimEnd | C1.Win.Input.FormatInfoInheritProperties.CalendarType;
            textBoxSumPayed.EditFormat.FormatType = C1.Win.Input.FormatType.StandardNumber;
            textBoxSumPayed.EditFormat.Inherit = C1.Win.Input.FormatInfoInheritProperties.CustomFormat | C1.Win.Input.FormatInfoInheritProperties.NullText | C1.Win.Input.FormatInfoInheritProperties.EmptyAsNull | C1.Win.Input.FormatInfoInheritProperties.TrimStart | C1.Win.Input.FormatInfoInheritProperties.TrimEnd | C1.Win.Input.FormatInfoInheritProperties.CalendarType;
            textBoxSumPayed.Location = new Point(141, 71);
            textBoxSumPayed.Name = "textBoxSumPayed";
            textBoxSumPayed.Size = new Size(124, 23);
            textBoxSumPayed.TabIndex = 5;
            textBoxSumPayed.TextAlign = HorizontalAlignment.Right;
            textBoxSumPayed.Value = "0";
            // 
            // labelContractSum
            // 
            labelContractSum.AutoSize = true;
            labelContractSum.Location = new Point(12, 17);
            labelContractSum.Name = "labelContractSum";
            labelContractSum.Size = new Size(123, 15);
            labelContractSum.TabIndex = 0;
            labelContractSum.Text = "Сумма по контракту:";
            labelContractSum.TextAlign = ContentAlignment.MiddleRight;
            // 
            // labelSumSaldo
            // 
            labelSumSaldo.AutoSize = true;
            labelSumSaldo.Location = new Point(12, 104);
            labelSumSaldo.Name = "labelSumSaldo";
            labelSumSaldo.Size = new Size(50, 15);
            labelSumSaldo.TabIndex = 7;
            labelSumSaldo.Text = "Сальдо:";
            labelSumSaldo.TextAlign = ContentAlignment.MiddleRight;
            // 
            // labelSumDeliveried
            // 
            labelSumDeliveried.AutoSize = true;
            labelSumDeliveried.Location = new Point(12, 46);
            labelSumDeliveried.Name = "labelSumDeliveried";
            labelSumDeliveried.Size = new Size(71, 15);
            labelSumDeliveried.TabIndex = 2;
            labelSumDeliveried.Text = "Отгружено:";
            labelSumDeliveried.TextAlign = ContentAlignment.MiddleRight;
            // 
            // labelSumPayed
            // 
            labelSumPayed.AutoSize = true;
            labelSumPayed.Location = new Point(12, 75);
            labelSumPayed.Name = "labelSumPayed";
            labelSumPayed.Size = new Size(66, 15);
            labelSumPayed.TabIndex = 4;
            labelSumPayed.Text = "Оплачено:";
            labelSumPayed.TextAlign = ContentAlignment.MiddleRight;
            // 
            // textBoxSumDeliveried
            // 
            textBoxSumDeliveried.DisplayFormat.FormatType = C1.Win.Input.FormatType.StandardNumber;
            textBoxSumDeliveried.DisplayFormat.Inherit = C1.Win.Input.FormatInfoInheritProperties.CustomFormat | C1.Win.Input.FormatInfoInheritProperties.NullText | C1.Win.Input.FormatInfoInheritProperties.EmptyAsNull | C1.Win.Input.FormatInfoInheritProperties.TrimStart | C1.Win.Input.FormatInfoInheritProperties.TrimEnd | C1.Win.Input.FormatInfoInheritProperties.CalendarType;
            textBoxSumDeliveried.EditFormat.FormatType = C1.Win.Input.FormatType.StandardNumber;
            textBoxSumDeliveried.EditFormat.Inherit = C1.Win.Input.FormatInfoInheritProperties.CustomFormat | C1.Win.Input.FormatInfoInheritProperties.NullText | C1.Win.Input.FormatInfoInheritProperties.EmptyAsNull | C1.Win.Input.FormatInfoInheritProperties.TrimStart | C1.Win.Input.FormatInfoInheritProperties.TrimEnd | C1.Win.Input.FormatInfoInheritProperties.CalendarType;
            textBoxSumDeliveried.Location = new Point(141, 42);
            textBoxSumDeliveried.Name = "textBoxSumDeliveried";
            textBoxSumDeliveried.Size = new Size(124, 23);
            textBoxSumDeliveried.TabIndex = 3;
            textBoxSumDeliveried.TextAlign = HorizontalAlignment.Right;
            textBoxSumDeliveried.Value = "0";
            // 
            // SumContractControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBox1);
            MinimumSize = new Size(277, 136);
            Name = "SumContractControl";
            Size = new Size(277, 136);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)textBoxSumSaldo).EndInit();
            ((System.ComponentModel.ISupportInitialize)textBoxSumContract).EndInit();
            ((System.ComponentModel.ISupportInitialize)textBoxSumPayed).EndInit();
            ((System.ComponentModel.ISupportInitialize)textBoxSumDeliveried).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label labelContractSum;
        private C1.Win.Input.C1TextBox textBox1;
        private Label labelSumDeliveried;
        private Label labelSumPayed;
        private Label labelSumSaldo;
        public C1.Win.Input.C1TextBox textBoxSumContract;
        public C1.Win.Input.C1TextBox textBoxSumDeliveried;
        public C1.Win.Input.C1TextBox textBoxSumPayed;
        public C1.Win.Input.C1TextBox textBoxSumSaldo;
    }
}
