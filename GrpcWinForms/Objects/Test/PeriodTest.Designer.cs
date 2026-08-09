namespace GrpcWinForms.Objects.Test
{
    partial class PeriodTest
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
            btnOk = new Button();
            btnCancel = new Button();
            editEnd = new C1.Win.Calendar.C1DateEdit();
            labelStop = new Label();
            rbFree = new RadioButton();
            editStart = new C1.Win.Calendar.C1DateEdit();
            labelFree = new Label();
            rbMonth = new RadioButton();
            rbQuater = new RadioButton();
            rbYear = new RadioButton();
            editMonth = new C1.Win.Input.C1ComboBox();
            editQuarter = new C1.Win.Input.C1ComboBox();
            editYear = new C1.Win.Input.C1NumericEdit();
            labelStart = new Label();
            labelMonth = new Label();
            labelQuarter = new Label();
            labelYear = new Label();
            ((System.ComponentModel.ISupportInitialize)editEnd).BeginInit();
            ((System.ComponentModel.ISupportInitialize)editStart).BeginInit();
            ((System.ComponentModel.ISupportInitialize)editMonth).BeginInit();
            ((System.ComponentModel.ISupportInitialize)editQuarter).BeginInit();
            ((System.ComponentModel.ISupportInitialize)editYear).BeginInit();
            SuspendLayout();
            // 
            // btnOk
            // 
            btnOk.Location = new Point(86, 173);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(75, 23);
            btnOk.TabIndex = 43;
            btnOk.Text = "Ok";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(167, 173);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 42;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // editEnd
            // 
            editEnd.ButtonsSettings.UpDownButton.Visible = false;
            editEnd.Calendar.MaxDate = new DateTime(2099, 12, 31, 23, 59, 0, 0);
            editEnd.Calendar.MinDate = new DateTime(2000, 1, 1, 0, 0, 0, 0);
            editEnd.DisplayFormat.EmptyAsNull = true;
            editEnd.DisplayFormat.FormatType = C1.Win.Input.FormatType.ShortDate;
            editEnd.DisplayFormat.Inherit = C1.Win.Input.FormatInfoInheritProperties.CustomFormat | C1.Win.Input.FormatInfoInheritProperties.NullText | C1.Win.Input.FormatInfoInheritProperties.TrimStart | C1.Win.Input.FormatInfoInheritProperties.TrimEnd | C1.Win.Input.FormatInfoInheritProperties.CalendarType;
            editEnd.EditFormat.EmptyAsNull = true;
            editEnd.EditFormat.FormatType = C1.Win.Input.FormatType.ShortDate;
            editEnd.EditFormat.Inherit = C1.Win.Input.FormatInfoInheritProperties.CustomFormat | C1.Win.Input.FormatInfoInheritProperties.NullText | C1.Win.Input.FormatInfoInheritProperties.TrimStart | C1.Win.Input.FormatInfoInheritProperties.TrimEnd | C1.Win.Input.FormatInfoInheritProperties.CalendarType;
            editEnd.Enabled = false;
            editEnd.FormatType = C1.Win.Input.FormatType.ShortDate;
            editEnd.Location = new Point(86, 144);
            editEnd.Name = "editEnd";
            editEnd.Size = new Size(116, 23);
            editEnd.TabIndex = 41;
            editEnd.Value = new DateTime(2026, 12, 31, 0, 0, 0, 0);
            // 
            // labelStop
            // 
            labelStop.AutoSize = true;
            labelStop.Location = new Point(7, 148);
            labelStop.Name = "labelStop";
            labelStop.Size = new Size(72, 15);
            labelStop.TabIndex = 40;
            labelStop.Text = "Окончание:";
            // 
            // rbFree
            // 
            rbFree.AutoSize = true;
            rbFree.Location = new Point(218, 120);
            rbFree.Name = "rbFree";
            rbFree.Size = new Size(14, 13);
            rbFree.TabIndex = 37;
            rbFree.UseVisualStyleBackColor = true;
            rbFree.CheckedChanged += rb_CheckedChanged;
            // 
            // editStart
            // 
            editStart.ButtonsSettings.UpDownButton.Visible = false;
            editStart.Calendar.MaxDate = new DateTime(2099, 12, 31, 23, 59, 0, 0);
            editStart.Calendar.MinDate = new DateTime(2000, 1, 1, 0, 0, 0, 0);
            editStart.DisplayFormat.FormatType = C1.Win.Input.FormatType.ShortDate;
            editStart.DisplayFormat.Inherit = C1.Win.Input.FormatInfoInheritProperties.CustomFormat | C1.Win.Input.FormatInfoInheritProperties.NullText | C1.Win.Input.FormatInfoInheritProperties.EmptyAsNull | C1.Win.Input.FormatInfoInheritProperties.TrimStart | C1.Win.Input.FormatInfoInheritProperties.TrimEnd | C1.Win.Input.FormatInfoInheritProperties.CalendarType;
            editStart.EditFormat.FormatType = C1.Win.Input.FormatType.ShortDate;
            editStart.EditFormat.Inherit = C1.Win.Input.FormatInfoInheritProperties.CustomFormat | C1.Win.Input.FormatInfoInheritProperties.NullText | C1.Win.Input.FormatInfoInheritProperties.EmptyAsNull | C1.Win.Input.FormatInfoInheritProperties.TrimStart | C1.Win.Input.FormatInfoInheritProperties.TrimEnd | C1.Win.Input.FormatInfoInheritProperties.CalendarType;
            editStart.Enabled = false;
            editStart.FormatType = C1.Win.Input.FormatType.ShortDate;
            editStart.Location = new Point(86, 115);
            editStart.Name = "editStart";
            editStart.Size = new Size(116, 23);
            editStart.TabIndex = 38;
            editStart.Value = new DateTime(2026, 1, 1, 0, 0, 0, 0);
            // 
            // labelFree
            // 
            labelFree.AutoSize = true;
            labelFree.Location = new Point(5, 95);
            labelFree.Name = "labelFree";
            labelFree.Size = new Size(148, 15);
            labelFree.TabIndex = 39;
            labelFree.Text = "Произвольный интервал:";
            // 
            // rbMonth
            // 
            rbMonth.AutoSize = true;
            rbMonth.Location = new Point(218, 67);
            rbMonth.Name = "rbMonth";
            rbMonth.Size = new Size(14, 13);
            rbMonth.TabIndex = 36;
            rbMonth.UseVisualStyleBackColor = true;
            rbMonth.CheckedChanged += rb_CheckedChanged;
            // 
            // rbQuater
            // 
            rbQuater.AutoSize = true;
            rbQuater.Checked = true;
            rbQuater.Location = new Point(218, 38);
            rbQuater.Name = "rbQuater";
            rbQuater.Size = new Size(14, 13);
            rbQuater.TabIndex = 34;
            rbQuater.TabStop = true;
            rbQuater.UseVisualStyleBackColor = true;
            rbQuater.CheckedChanged += rb_CheckedChanged;
            // 
            // rbYear
            // 
            rbYear.AutoSize = true;
            rbYear.Location = new Point(218, 9);
            rbYear.Name = "rbYear";
            rbYear.Size = new Size(14, 13);
            rbYear.TabIndex = 31;
            rbYear.UseVisualStyleBackColor = true;
            rbYear.CheckedChanged += rb_CheckedChanged;
            // 
            // editMonth
            // 
            editMonth.AutoCompleteSource = AutoCompleteSource.ListItems;
            editMonth.DropDownStyle = C1.Win.Input.DropDownStyle.DropDownList;
            editMonth.Enabled = false;
            editMonth.InitialSelection = C1.Win.Input.InitialSelection.CaretAtStart;
            editMonth.Location = new Point(86, 62);
            editMonth.Name = "editMonth";
            editMonth.ReadOnly = true;
            editMonth.Size = new Size(116, 23);
            editMonth.TabIndex = 35;
            editMonth.Value = "";
            editMonth.SelectedIndexChanged += editMonth_SelectedIndexChanged;
            // 
            // editQuarter
            // 
            editQuarter.AutoCompleteSource = AutoCompleteSource.ListItems;
            editQuarter.DropDownStyle = C1.Win.Input.DropDownStyle.DropDownList;
            editQuarter.HideSelection = false;
            editQuarter.InitialSelection = C1.Win.Input.InitialSelection.CaretAtStart;
            editQuarter.Location = new Point(86, 33);
            editQuarter.Name = "editQuarter";
            editQuarter.ReadOnly = true;
            editQuarter.Size = new Size(116, 23);
            editQuarter.TabIndex = 33;
            editQuarter.Value = "";
            editQuarter.SelectedIndexChanged += editQuarter_SelectedIndexChanged;
            // 
            // editYear
            // 
            editYear.DataType = typeof(int);
            editYear.DisplayFormat.FormatType = C1.Win.Input.FormatType.Integer;
            editYear.DisplayFormat.Inherit = C1.Win.Input.FormatInfoInheritProperties.CustomFormat | C1.Win.Input.FormatInfoInheritProperties.NullText | C1.Win.Input.FormatInfoInheritProperties.EmptyAsNull | C1.Win.Input.FormatInfoInheritProperties.TrimStart | C1.Win.Input.FormatInfoInheritProperties.TrimEnd | C1.Win.Input.FormatInfoInheritProperties.CalendarType;
            editYear.EditFormat.FormatType = C1.Win.Input.FormatType.Integer;
            editYear.EditFormat.Inherit = C1.Win.Input.FormatInfoInheritProperties.CustomFormat | C1.Win.Input.FormatInfoInheritProperties.NullText | C1.Win.Input.FormatInfoInheritProperties.EmptyAsNull | C1.Win.Input.FormatInfoInheritProperties.TrimStart | C1.Win.Input.FormatInfoInheritProperties.TrimEnd | C1.Win.Input.FormatInfoInheritProperties.CalendarType;
            editYear.Enabled = false;
            editYear.Location = new Point(86, 4);
            editYear.Name = "editYear";
            editYear.Size = new Size(116, 23);
            editYear.TabIndex = 29;
            editYear.Value = 2026;
            editYear.TextChanged += editYear_TextChanged;
            // 
            // labelStart
            // 
            labelStart.AutoSize = true;
            labelStart.Location = new Point(7, 119);
            labelStart.Name = "labelStart";
            labelStart.Size = new Size(52, 15);
            labelStart.TabIndex = 27;
            labelStart.Text = "Начало:";
            // 
            // labelMonth
            // 
            labelMonth.AutoSize = true;
            labelMonth.Location = new Point(5, 66);
            labelMonth.Name = "labelMonth";
            labelMonth.Size = new Size(46, 15);
            labelMonth.TabIndex = 32;
            labelMonth.Text = "Месяц:";
            // 
            // labelQuarter
            // 
            labelQuarter.AutoSize = true;
            labelQuarter.Location = new Point(5, 37);
            labelQuarter.Name = "labelQuarter";
            labelQuarter.Size = new Size(54, 15);
            labelQuarter.TabIndex = 30;
            labelQuarter.Text = "Квартал:";
            // 
            // labelYear
            // 
            labelYear.AutoSize = true;
            labelYear.Location = new Point(5, 8);
            labelYear.Name = "labelYear";
            labelYear.Size = new Size(29, 15);
            labelYear.TabIndex = 28;
            labelYear.Text = "Год:";
            // 
            // Period
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnOk);
            Controls.Add(btnCancel);
            Controls.Add(editEnd);
            Controls.Add(labelStop);
            Controls.Add(rbFree);
            Controls.Add(editStart);
            Controls.Add(labelFree);
            Controls.Add(rbMonth);
            Controls.Add(rbQuater);
            Controls.Add(rbYear);
            Controls.Add(editMonth);
            Controls.Add(editQuarter);
            Controls.Add(editYear);
            Controls.Add(labelStart);
            Controls.Add(labelMonth);
            Controls.Add(labelQuarter);
            Controls.Add(labelYear);
            Name = "Period";
            Size = new Size(248, 202);
            Enter += Period_Enter;
            ((System.ComponentModel.ISupportInitialize)editEnd).EndInit();
            ((System.ComponentModel.ISupportInitialize)editStart).EndInit();
            ((System.ComponentModel.ISupportInitialize)editMonth).EndInit();
            ((System.ComponentModel.ISupportInitialize)editQuarter).EndInit();
            ((System.ComponentModel.ISupportInitialize)editYear).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnOk;
        private Button btnCancel;
        private C1.Win.Calendar.C1DateEdit editEnd;
        private Label labelStop;
        private RadioButton rbFree;
        private C1.Win.Calendar.C1DateEdit editStart;
        private Label labelFree;
        private RadioButton rbMonth;
        private RadioButton rbQuater;
        private RadioButton rbYear;
        private C1.Win.Input.C1ComboBox editMonth;
        private C1.Win.Input.C1ComboBox editQuarter;
        private C1.Win.Input.C1NumericEdit editYear;
        private Label labelStart;
        private Label labelMonth;
        private Label labelQuarter;
        private Label labelYear;
    }
}
