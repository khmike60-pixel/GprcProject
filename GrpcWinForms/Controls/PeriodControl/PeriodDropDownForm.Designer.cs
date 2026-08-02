// <содержимое файла полностью заменено>
using C1.Win.Input;

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
            labelYear = new Label();
            labelQuarter = new Label();
            labelMonth = new Label();
            labelStart = new Label();
            labelStop = new Label();
            editYear = new C1NumericEdit();
            editQuarter = new C1ComboBox();
            editMonth = new C1ComboBox();
            rbYear = new RadioButton();
            rbQuater = new RadioButton();
            rbMonth = new RadioButton();
            labelFree = new Label();
            editStart = new C1.Win.Calendar.C1DateEdit();
            editEnd = new C1.Win.Calendar.C1DateEdit();
            rbFree = new RadioButton();
            btnCancel = new Button();
            btnOk = new Button();
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
            labelStart.Location = new Point(12, 125);
            labelStart.Name = "labelStart";
            labelStart.Size = new Size(52, 15);
            labelStart.TabIndex = 0;
            labelStart.Text = "Начало:";
            // 
            // labelStop
            // 
            labelStop.AutoSize = true;
            labelStop.Location = new Point(12, 154);
            labelStop.Name = "labelStop";
            labelStop.Size = new Size(72, 15);
            labelStop.TabIndex = 1;
            labelStop.Text = "Окончание:";
            // 
            // editYear
            // 
            editYear.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            editYear.DataType = typeof(int);
            editYear.DisplayFormat.FormatType = FormatType.Integer;
            editYear.DisplayFormat.Inherit = FormatInfoInheritProperties.CustomFormat | FormatInfoInheritProperties.NullText | FormatInfoInheritProperties.EmptyAsNull | FormatInfoInheritProperties.TrimStart | FormatInfoInheritProperties.TrimEnd | FormatInfoInheritProperties.CalendarType;
            editYear.EditFormat.FormatType = FormatType.Integer;
            editYear.EditFormat.Inherit = FormatInfoInheritProperties.CustomFormat | FormatInfoInheritProperties.NullText | FormatInfoInheritProperties.EmptyAsNull | FormatInfoInheritProperties.TrimStart | FormatInfoInheritProperties.TrimEnd | FormatInfoInheritProperties.CalendarType;
            editYear.Enabled = false;
            editYear.Location = new Point(91, 10);
            editYear.Name = "editYear";
            editYear.Size = new Size(116, 23);
            editYear.TabIndex = 1;
            editYear.Value = 2026;
            editYear.TextChanged += editYear_TextChanged;
            editYear.Enter += control_Enter;
            // 
            // editQuarter
            // 
            editQuarter.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            editQuarter.AutoCompleteSource = AutoCompleteSource.ListItems;
            editQuarter.DropDownStyle = DropDownStyle.DropDownList;
            editQuarter.HideSelection = false;
            editQuarter.InitialSelection = InitialSelection.CaretAtStart;
            editQuarter.Location = new Point(91, 39);
            editQuarter.Name = "editQuarter";
            editQuarter.ReadOnly = true;
            editQuarter.Size = new Size(116, 23);
            editQuarter.TabIndex = 3;
            editQuarter.Value = "";
            editQuarter.SelectedIndexChanged += editQuarter_SelectedIndexChanged;
            editQuarter.Enter += control_Enter;
            editQuarter.Leave += editQuarter_Leave;
            // 
            // editMonth
            // 
            editMonth.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            editMonth.AutoCompleteSource = AutoCompleteSource.ListItems;
            editMonth.DropDownStyle = DropDownStyle.DropDownList;
            editMonth.Enabled = false;
            editMonth.InitialSelection = InitialSelection.CaretAtStart;
            editMonth.Location = new Point(91, 68);
            editMonth.Name = "editMonth";
            editMonth.ReadOnly = true;
            editMonth.Size = new Size(116, 23);
            editMonth.TabIndex = 5;
            editMonth.Value = "";
            editMonth.SelectedIndexChanged += editMonth_SelectedIndexChanged;
            editMonth.Enter += control_Enter;
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
            rbYear.CheckedChanged += rb_CheckedChanged;
            // 
            // rbQuater
            // 
            rbQuater.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            rbQuater.AutoSize = true;
            rbQuater.Checked = true;
            rbQuater.Location = new Point(223, 44);
            rbQuater.Name = "rbQuater";
            rbQuater.Size = new Size(14, 13);
            rbQuater.TabIndex = 4;
            rbQuater.TabStop = true;
            rbQuater.UseVisualStyleBackColor = true;
            rbQuater.CheckedChanged += rb_CheckedChanged;
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
            rbMonth.CheckedChanged += rb_CheckedChanged;
            // 
            // labelFree
            // 
            labelFree.AutoSize = true;
            labelFree.Location = new Point(10, 101);
            labelFree.Name = "labelFree";
            labelFree.Size = new Size(148, 15);
            labelFree.TabIndex = 9;
            labelFree.Text = "Произвольный интервал:";
            // 
            // editStart
            // 
            editStart.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            editStart.ButtonsSettings.UpDownButton.Visible = false;
            editStart.Calendar.MaxDate = new DateTime(2099, 12, 31, 23, 59, 0, 0);
            editStart.Calendar.MinDate = new DateTime(2000, 1, 1, 0, 0, 0, 0);
            editStart.DisplayFormat.FormatType = FormatType.ShortDate;
            editStart.DisplayFormat.Inherit = FormatInfoInheritProperties.CustomFormat | FormatInfoInheritProperties.NullText | FormatInfoInheritProperties.EmptyAsNull | FormatInfoInheritProperties.TrimStart | FormatInfoInheritProperties.TrimEnd | FormatInfoInheritProperties.CalendarType;
            editStart.EditFormat.FormatType = FormatType.ShortDate;
            editStart.EditFormat.Inherit = FormatInfoInheritProperties.CustomFormat | FormatInfoInheritProperties.NullText | FormatInfoInheritProperties.EmptyAsNull | FormatInfoInheritProperties.TrimStart | FormatInfoInheritProperties.TrimEnd | FormatInfoInheritProperties.CalendarType;
            editStart.Enabled = false;
            editStart.FormatType = FormatType.ShortDate;
            editStart.Location = new Point(91, 121);
            editStart.Name = "editStart";
            editStart.Size = new Size(116, 23);
            editStart.TabIndex = 8;
            editStart.Value = new DateTime(2026, 1, 1, 0, 0, 0, 0);
            editStart.TextChanged += editStart_TextChanged;
            editStart.Enter += control_Enter;
            // 
            // editEnd
            // 
            editEnd.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            editEnd.ButtonsSettings.UpDownButton.Visible = false;
            editEnd.Calendar.MaxDate = new DateTime(2099, 12, 31, 23, 59, 0, 0);
            editEnd.Calendar.MinDate = new DateTime(2000, 1, 1, 0, 0, 0, 0);
            editEnd.DisplayFormat.EmptyAsNull = true;
            editEnd.DisplayFormat.FormatType = FormatType.ShortDate;
            editEnd.DisplayFormat.Inherit = FormatInfoInheritProperties.CustomFormat | FormatInfoInheritProperties.NullText | FormatInfoInheritProperties.TrimStart | FormatInfoInheritProperties.TrimEnd | FormatInfoInheritProperties.CalendarType;
            editEnd.EditFormat.EmptyAsNull = true;
            editEnd.EditFormat.FormatType = FormatType.ShortDate;
            editEnd.EditFormat.Inherit = FormatInfoInheritProperties.CustomFormat | FormatInfoInheritProperties.NullText | FormatInfoInheritProperties.TrimStart | FormatInfoInheritProperties.TrimEnd | FormatInfoInheritProperties.CalendarType;
            editEnd.Enabled = false;
            editEnd.FormatType = FormatType.ShortDate;
            editEnd.Location = new Point(91, 150);
            editEnd.Name = "editEnd";
            editEnd.Size = new Size(116, 23);
            editEnd.TabIndex = 9;
            editEnd.Value = new DateTime(2026, 12, 31, 0, 0, 0, 0);
            editEnd.TextChanged += control_Enter;
            // 
            // rbFree
            // 
            rbFree.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            rbFree.AutoSize = true;
            rbFree.Location = new Point(224, 101);
            rbFree.Name = "rbFree";
            rbFree.Size = new Size(14, 13);
            rbFree.TabIndex = 7;
            rbFree.UseVisualStyleBackColor = true;
            rbFree.CheckedChanged += rb_CheckedChanged;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(172, 179);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 10;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnOk
            // 
            btnOk.Location = new Point(91, 179);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(75, 23);
            btnOk.TabIndex = 11;
            btnOk.Text = "Ok";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // PeriodDropDownForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnOk);
            Controls.Add(btnCancel);
            Controls.Add(rbFree);
            Controls.Add(editEnd);
            Controls.Add(editStart);
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
            Size = new Size(250, 207);
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
        private Label stop;
        private Label labelStop;
        private Label labelStart;
        private C1.Win.Input.C1NumericEdit editYear;
        private C1.Win.Input.C1ComboBox editQuarter;
        private C1.Win.Input.C1ComboBox editMonth;
        private RadioButton rbYear;
        private RadioButton rbQuater;
        private RadioButton rbMonth;
        private Label labelFree;
        private C1.Win.Calendar.C1DateEdit editStart;
        private C1.Win.Calendar.C1DateEdit editEnd;
        private RadioButton rbFree;
        private Button btnCancel;
        private Button btnOk;
    }
}