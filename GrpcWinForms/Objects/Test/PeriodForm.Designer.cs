namespace GrpcWinForms.Objects.Test
{
    partial class PeriodForm
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
            btnOk = new Button();
            btnCancel = new Button();
            editEnd = new C1.Win.Calendar.C1DateEdit();
            labelStop = new Label();
            ((System.ComponentModel.ISupportInitialize)editStart).BeginInit();
            ((System.ComponentModel.ISupportInitialize)editMonth).BeginInit();
            ((System.ComponentModel.ISupportInitialize)editQuarter).BeginInit();
            ((System.ComponentModel.ISupportInitialize)editYear).BeginInit();
            ((System.ComponentModel.ISupportInitialize)editEnd).BeginInit();
            SuspendLayout();
            // 
            // rbFree
            // 
            rbFree.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            rbFree.AutoSize = true;
            rbFree.Location = new Point(226, 103);
            rbFree.Name = "rbFree";
            rbFree.Size = new Size(14, 13);
            rbFree.TabIndex = 20;
            rbFree.UseVisualStyleBackColor = true;
            rbFree.CheckedChanged += rb_CheckedChanged;
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
            editStart.Enabled = false;
            editStart.FormatType = C1.Win.Input.FormatType.ShortDate;
            editStart.Location = new Point(93, 123);
            editStart.Name = "editStart";
            editStart.Size = new Size(116, 23);
            editStart.TabIndex = 21;
            editStart.Value = new DateTime(2026, 1, 1, 0, 0, 0, 0);
            editStart.TextChanged += editStart_TextChanged;
            // 
            // labelFree
            // 
            labelFree.AutoSize = true;
            labelFree.Location = new Point(12, 103);
            labelFree.Name = "labelFree";
            labelFree.Size = new Size(148, 15);
            labelFree.TabIndex = 22;
            labelFree.Text = "Произвольный интервал:";
            // 
            // rbMonth
            // 
            rbMonth.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            rbMonth.AutoSize = true;
            rbMonth.Location = new Point(225, 75);
            rbMonth.Name = "rbMonth";
            rbMonth.Size = new Size(14, 13);
            rbMonth.TabIndex = 19;
            rbMonth.UseVisualStyleBackColor = true;
            rbMonth.CheckedChanged += rb_CheckedChanged;
            // 
            // rbQuater
            // 
            rbQuater.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            rbQuater.AutoSize = true;
            rbQuater.Checked = true;
            rbQuater.Location = new Point(225, 46);
            rbQuater.Name = "rbQuater";
            rbQuater.Size = new Size(14, 13);
            rbQuater.TabIndex = 17;
            rbQuater.TabStop = true;
            rbQuater.UseVisualStyleBackColor = true;
            rbQuater.CheckedChanged += rb_CheckedChanged;
            // 
            // rbYear
            // 
            rbYear.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            rbYear.AutoSize = true;
            rbYear.Location = new Point(225, 17);
            rbYear.Name = "rbYear";
            rbYear.Size = new Size(14, 13);
            rbYear.TabIndex = 14;
            rbYear.UseVisualStyleBackColor = true;
            rbYear.CheckedChanged += rb_CheckedChanged;
            // 
            // editMonth
            // 
            editMonth.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            editMonth.AutoCompleteSource = AutoCompleteSource.ListItems;
            editMonth.DropDownStyle = C1.Win.Input.DropDownStyle.DropDownList;
            editMonth.Enabled = false;
            editMonth.InitialSelection = C1.Win.Input.InitialSelection.CaretAtStart;
            editMonth.Location = new Point(93, 70);
            editMonth.Name = "editMonth";
            editMonth.ReadOnly = true;
            editMonth.Size = new Size(116, 23);
            editMonth.TabIndex = 18;
            editMonth.Value = "";
            editMonth.SelectedIndexChanged += editMonth_SelectedIndexChanged;
            // 
            // editQuarter
            // 
            editQuarter.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            editQuarter.AutoCompleteSource = AutoCompleteSource.ListItems;
            editQuarter.DropDownStyle = C1.Win.Input.DropDownStyle.DropDownList;
            editQuarter.HideSelection = false;
            editQuarter.InitialSelection = C1.Win.Input.InitialSelection.CaretAtStart;
            editQuarter.Location = new Point(93, 41);
            editQuarter.Name = "editQuarter";
            editQuarter.ReadOnly = true;
            editQuarter.Size = new Size(116, 23);
            editQuarter.TabIndex = 16;
            editQuarter.Value = "";
            editQuarter.SelectedIndexChanged += editQuarter_SelectedIndexChanged;
            // 
            // editYear
            // 
            editYear.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            editYear.DataType = typeof(int);
            editYear.DisplayFormat.FormatType = C1.Win.Input.FormatType.Integer;
            editYear.DisplayFormat.Inherit = C1.Win.Input.FormatInfoInheritProperties.CustomFormat | C1.Win.Input.FormatInfoInheritProperties.NullText | C1.Win.Input.FormatInfoInheritProperties.EmptyAsNull | C1.Win.Input.FormatInfoInheritProperties.TrimStart | C1.Win.Input.FormatInfoInheritProperties.TrimEnd | C1.Win.Input.FormatInfoInheritProperties.CalendarType;
            editYear.EditFormat.FormatType = C1.Win.Input.FormatType.Integer;
            editYear.EditFormat.Inherit = C1.Win.Input.FormatInfoInheritProperties.CustomFormat | C1.Win.Input.FormatInfoInheritProperties.NullText | C1.Win.Input.FormatInfoInheritProperties.EmptyAsNull | C1.Win.Input.FormatInfoInheritProperties.TrimStart | C1.Win.Input.FormatInfoInheritProperties.TrimEnd | C1.Win.Input.FormatInfoInheritProperties.CalendarType;
            editYear.Enabled = false;
            editYear.Location = new Point(93, 12);
            editYear.Name = "editYear";
            editYear.Size = new Size(116, 23);
            editYear.TabIndex = 12;
            editYear.Value = 2026;
            editYear.TextChanged += editYear_TextChanged;
            // 
            // labelStart
            // 
            labelStart.AutoSize = true;
            labelStart.Location = new Point(14, 127);
            labelStart.Name = "labelStart";
            labelStart.Size = new Size(52, 15);
            labelStart.TabIndex = 10;
            labelStart.Text = "Начало:";
            // 
            // labelMonth
            // 
            labelMonth.AutoSize = true;
            labelMonth.Location = new Point(12, 74);
            labelMonth.Name = "labelMonth";
            labelMonth.Size = new Size(46, 15);
            labelMonth.TabIndex = 15;
            labelMonth.Text = "Месяц:";
            // 
            // labelQuarter
            // 
            labelQuarter.AutoSize = true;
            labelQuarter.Location = new Point(12, 45);
            labelQuarter.Name = "labelQuarter";
            labelQuarter.Size = new Size(54, 15);
            labelQuarter.TabIndex = 13;
            labelQuarter.Text = "Квартал:";
            // 
            // labelYear
            // 
            labelYear.AutoSize = true;
            labelYear.Location = new Point(12, 16);
            labelYear.Name = "labelYear";
            labelYear.Size = new Size(29, 15);
            labelYear.TabIndex = 11;
            labelYear.Text = "Год:";
            // 
            // btnOk
            // 
            btnOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnOk.Location = new Point(93, 181);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(75, 23);
            btnOk.TabIndex = 26;
            btnOk.Text = "Ok";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.Location = new Point(174, 181);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 25;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
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
            editEnd.Enabled = false;
            editEnd.FormatType = C1.Win.Input.FormatType.ShortDate;
            editEnd.Location = new Point(93, 152);
            editEnd.Name = "editEnd";
            editEnd.Size = new Size(116, 23);
            editEnd.TabIndex = 24;
            editEnd.Value = new DateTime(2026, 12, 31, 0, 0, 0, 0);
            editEnd.TextChanged += editEnd_TextChanged;
            // 
            // labelStop
            // 
            labelStop.AutoSize = true;
            labelStop.Location = new Point(14, 156);
            labelStop.Name = "labelStop";
            labelStop.Size = new Size(72, 15);
            labelStop.TabIndex = 23;
            labelStop.Text = "Окончание:";
            // 
            // PeriodForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(259, 213);
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
            MinimumSize = new Size(275, 252);
            Name = "PeriodForm";
            Text = "PeriodForm";
            Load += PeriodForm_Load;
            Enter += control_Enter;
            ((System.ComponentModel.ISupportInitialize)editStart).EndInit();
            ((System.ComponentModel.ISupportInitialize)editMonth).EndInit();
            ((System.ComponentModel.ISupportInitialize)editQuarter).EndInit();
            ((System.ComponentModel.ISupportInitialize)editYear).EndInit();
            ((System.ComponentModel.ISupportInitialize)editEnd).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

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
        private Button btnOk;
        private Button btnCancel;
        private C1.Win.Calendar.C1DateEdit editEnd;
        private Label labelStop;
    }
}