namespace GrpcWinForms.Controls.PeriodControl
{
    partial class PeriodDropDownForm
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
            C1.Win.Input.ComboBoxItem comboBoxItem1 = new C1.Win.Input.ComboBoxItem();
            C1.Win.Input.ComboBoxItem comboBoxItem2 = new C1.Win.Input.ComboBoxItem();
            C1.Win.Input.ComboBoxItem comboBoxItem3 = new C1.Win.Input.ComboBoxItem();
            C1.Win.Input.ComboBoxItem comboBoxItem4 = new C1.Win.Input.ComboBoxItem();
            labelYear = new Label();
            labelQuarter = new Label();
            labelMonth = new Label();
            labelStart = new Label();
            labelStop = new Label();
            editYear = new C1.Win.Input.C1NumericEdit();
            editQuarter = new C1.Win.Input.C1ComboBox();
            editMonth = new C1.Win.Input.C1ComboBox();
            rbYear = new RadioButton();
            rbQuater = new RadioButton();
            rbMonth = new RadioButton();
            labelFree = new Label();
            btnCancel = new Button();
            btnOk = new Button();
            editStart = new C1.Win.Calendar.C1DateEdit();
            editEnd = new C1.Win.Calendar.C1DateEdit();
            rbFree = new RadioButton();
            ((System.ComponentModel.ISupportInitialize)editYear).BeginInit();
            ((System.ComponentModel.ISupportInitialize)editQuarter).BeginInit();
            ((System.ComponentModel.ISupportInitialize)editMonth).BeginInit();
            ((System.ComponentModel.ISupportInitialize)editStart).BeginInit();
            ((System.ComponentModel.ISupportInitialize)editEnd).BeginInit();
            SuspendLayout();
            // 
            // labelYear
            // 
            labelYear.AutoSize = true;
            labelYear.Location = new Point(10, 14);
            labelYear.Name = "labelYear";
            labelYear.Size = new Size(29, 15);
            labelYear.TabIndex = 0;
            labelYear.Text = "Год:";
            // 
            // labelQuarter
            // 
            labelQuarter.AutoSize = true;
            labelQuarter.Location = new Point(10, 43);
            labelQuarter.Name = "labelQuarter";
            labelQuarter.Size = new Size(54, 15);
            labelQuarter.TabIndex = 1;
            labelQuarter.Text = "Квартал:";
            // 
            // labelMonth
            // 
            labelMonth.AutoSize = true;
            labelMonth.Location = new Point(10, 72);
            labelMonth.Name = "labelMonth";
            labelMonth.Size = new Size(46, 15);
            labelMonth.TabIndex = 2;
            labelMonth.Text = "Месяц:";
            // 
            // labelStart
            // 
            labelStart.AutoSize = true;
            labelStart.Location = new Point(12, 142);
            labelStart.Name = "labelStart";
            labelStart.Size = new Size(52, 15);
            labelStart.TabIndex = 0;
            labelStart.Text = "Начало:";
            // 
            // labelStop
            // 
            labelStop.AutoSize = true;
            labelStop.Location = new Point(12, 171);
            labelStop.Name = "labelStop";
            labelStop.Size = new Size(72, 15);
            labelStop.TabIndex = 1;
            labelStop.Text = "Окончание:";
            // 
            // editYear
            // 
            editYear.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            editYear.Location = new Point(107, 10);
            editYear.Name = "editYear";
            editYear.Size = new Size(100, 23);
            editYear.TabIndex = 1;
            editYear.Value = new decimal(new int[] { 0, 0, 0, 0 });
            // 
            // editQuarter
            // 
            editQuarter.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            editQuarter.HideSelection = false;
            editQuarter.Location = new Point(107, 39);
            editQuarter.Name = "editQuarter";
            editQuarter.Size = new Size(100, 23);
            editQuarter.TabIndex = 3;
            editQuarter.Value = "1";
            // 
            // editMonth
            // 
            editMonth.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            editMonth.DropDownStyle = C1.Win.Input.DropDownStyle.DropDownList;
            editMonth.InitialSelection = C1.Win.Input.InitialSelection.CaretAtStart;
            comboBoxItem1.DisplayText = "1";
            comboBoxItem1.Value = "1";
            comboBoxItem2.DisplayText = "2";
            comboBoxItem2.Value = "2";
            comboBoxItem3.DisplayText = "3";
            comboBoxItem3.Value = "3";
            comboBoxItem4.DisplayText = "4";
            comboBoxItem4.Value = "4";
            editMonth.Items.Add(comboBoxItem1);
            editMonth.Items.Add(comboBoxItem2);
            editMonth.Items.Add(comboBoxItem3);
            editMonth.Items.Add(comboBoxItem4);
            editMonth.Location = new Point(107, 68);
            editMonth.Name = "editMonth";
            editMonth.ReadOnly = true;
            editMonth.Size = new Size(100, 23);
            editMonth.TabIndex = 5;
            editMonth.Value = "1";
            // 
            // rbYear
            // 
            rbYear.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            rbYear.AutoSize = true;
            rbYear.Location = new Point(223, 15);
            rbYear.Name = "rbYear";
            rbYear.Size = new Size(14, 13);
            rbYear.TabIndex = 2;
            rbYear.UseVisualStyleBackColor = true;
            // 
            // rbQuater
            // 
            rbQuater.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            rbQuater.AutoSize = true;
            rbQuater.Location = new Point(223, 44);
            rbQuater.Name = "rbQuater";
            rbQuater.Size = new Size(14, 13);
            rbQuater.TabIndex = 4;
            rbQuater.UseVisualStyleBackColor = true;
            // 
            // rbMonth
            // 
            rbMonth.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            rbMonth.AutoSize = true;
            rbMonth.Location = new Point(223, 73);
            rbMonth.Name = "rbMonth";
            rbMonth.Size = new Size(14, 13);
            rbMonth.TabIndex = 6;
            rbMonth.UseVisualStyleBackColor = true;
            // 
            // labelFree
            // 
            labelFree.AutoSize = true;
            labelFree.Location = new Point(10, 114);
            labelFree.Name = "labelFree";
            labelFree.Size = new Size(148, 15);
            labelFree.TabIndex = 9;
            labelFree.Text = "Произвольный интервал:";
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.Location = new Point(172, 214);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 11;
            btnCancel.Text = "Отменить";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnOk
            // 
            btnOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnOk.Location = new Point(91, 214);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(75, 23);
            btnOk.TabIndex = 10;
            btnOk.Text = "Ok";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // editStart
            // 
            editStart.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            editStart.ButtonsSettings.UpDownButton.Visible = false;
            editStart.Calendar.MaxDate = new DateTime(2099, 12, 31, 23, 59, 0, 0);
            editStart.Calendar.MinDate = new DateTime(2000, 1, 1, 0, 0, 0, 0);
            editStart.DisplayFormat.FormatType = C1.Win.Input.FormatType.ShortDate;
            editStart.DisplayFormat.Inherit = C1.Win.Input.FormatInfoInheritProperties.CustomFormat | C1.Win.Input.FormatInfoInheritProperties.NullText | C1.Win.Input.FormatInfoInheritProperties.EmptyAsNull | C1.Win.Input.FormatInfoInheritProperties.TrimStart | C1.Win.Input.FormatInfoInheritProperties.TrimEnd | C1.Win.Input.FormatInfoInheritProperties.CalendarType;
            editStart.EditFormat.FormatType = C1.Win.Input.FormatType.ShortDate;
            editStart.EditFormat.Inherit = C1.Win.Input.FormatInfoInheritProperties.CustomFormat | C1.Win.Input.FormatInfoInheritProperties.NullText | C1.Win.Input.FormatInfoInheritProperties.EmptyAsNull | C1.Win.Input.FormatInfoInheritProperties.TrimStart | C1.Win.Input.FormatInfoInheritProperties.TrimEnd | C1.Win.Input.FormatInfoInheritProperties.CalendarType;
            editStart.FormatType = C1.Win.Input.FormatType.ShortDate;
            editStart.Location = new Point(107, 138);
            editStart.Name = "editStart";
            editStart.Size = new Size(100, 23);
            editStart.TabIndex = 8;
            editStart.Value = new DateTime(2026, 1, 1, 0, 0, 0, 0);
            // 
            // editEnd
            // 
            editEnd.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            editEnd.ButtonsSettings.UpDownButton.Visible = false;
            editEnd.Calendar.MaxDate = new DateTime(2099, 12, 31, 23, 59, 0, 0);
            editEnd.Calendar.MinDate = new DateTime(2000, 1, 1, 0, 0, 0, 0);
            editEnd.DisplayFormat.EmptyAsNull = true;
            editEnd.DisplayFormat.FormatType = C1.Win.Input.FormatType.ShortDate;
            editEnd.DisplayFormat.Inherit = C1.Win.Input.FormatInfoInheritProperties.CustomFormat | C1.Win.Input.FormatInfoInheritProperties.NullText | C1.Win.Input.FormatInfoInheritProperties.TrimStart | C1.Win.Input.FormatInfoInheritProperties.TrimEnd | C1.Win.Input.FormatInfoInheritProperties.CalendarType;
            editEnd.EditFormat.EmptyAsNull = true;
            editEnd.EditFormat.FormatType = C1.Win.Input.FormatType.ShortDate;
            editEnd.EditFormat.Inherit = C1.Win.Input.FormatInfoInheritProperties.CustomFormat | C1.Win.Input.FormatInfoInheritProperties.NullText | C1.Win.Input.FormatInfoInheritProperties.TrimStart | C1.Win.Input.FormatInfoInheritProperties.TrimEnd | C1.Win.Input.FormatInfoInheritProperties.CalendarType;
            editEnd.FormatType = C1.Win.Input.FormatType.ShortDate;
            editEnd.Location = new Point(107, 167);
            editEnd.Name = "editEnd";
            editEnd.Size = new Size(100, 23);
            editEnd.TabIndex = 9;
            editEnd.Value = new DateTime(2026, 12, 31, 0, 0, 0, 0);
            // 
            // rbFree
            // 
            rbFree.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            rbFree.AutoSize = true;
            rbFree.Checked = true;
            rbFree.Location = new Point(223, 114);
            rbFree.Name = "rbFree";
            rbFree.Size = new Size(14, 13);
            rbFree.TabIndex = 7;
            rbFree.TabStop = true;
            rbFree.UseVisualStyleBackColor = true;
            // 
            // PeriodDropDownForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(rbFree);
            Controls.Add(editEnd);
            Controls.Add(editStart);
            Controls.Add(btnOk);
            Controls.Add(btnCancel);
            Controls.Add(labelFree);
            Controls.Add(rbMonth);
            Controls.Add(rbQuater);
            Controls.Add(rbYear);
            Controls.Add(editMonth);
            Controls.Add(editQuarter);
            Controls.Add(editYear);
            Controls.Add(labelStop);
            Controls.Add(labelStart);
            Controls.Add(labelMonth);
            Controls.Add(labelQuarter);
            Controls.Add(labelYear);
            Name = "PeriodDropDownForm";
            Size = new Size(250, 240);
            ((System.ComponentModel.ISupportInitialize)editYear).EndInit();
            ((System.ComponentModel.ISupportInitialize)editQuarter).EndInit();
            ((System.ComponentModel.ISupportInitialize)editMonth).EndInit();
            ((System.ComponentModel.ISupportInitialize)editStart).EndInit();
            ((System.ComponentModel.ISupportInitialize)editEnd).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelYear;
        private Label labelQuarter;
        private Label labelMonth;
        private Label labelStop;
        private Label labelStart;
        private C1.Win.Input.C1NumericEdit editYear;
        private C1.Win.Input.C1ComboBox editQuarter;
        private C1.Win.Input.C1ComboBox editMonth;
        private RadioButton rbYear;
        private RadioButton rbQuater;
        private RadioButton rbMonth;
        private Label labelFree;
        private Button btnCancel;
        private Button btnOk;
        private C1.Win.Calendar.C1DateEdit editStart;
        private C1.Win.Calendar.C1DateEdit editEnd;
        private RadioButton rbFree;
    }
}
