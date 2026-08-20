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
            C1.Win.FlexGrid.FooterDescription footerDescription1 = new C1.Win.FlexGrid.FooterDescription();
            C1.Win.FlexGrid.AggregateDefinition aggregateDefinition1 = new C1.Win.FlexGrid.AggregateDefinition();
            buttonCancel = new Button();
            buttonSave = new Button();
            buttonSaveExit = new Button();
            smartGrid1 = new SmartLib.SmartGrid(components);
            periodBox1 = new SmartLib.PeriodBox(components);
            ((System.ComponentModel.ISupportInitialize)smartGrid1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)periodBox1).BeginInit();
            SuspendLayout();
            // 
            // buttonCancel
            // 
            buttonCancel.AutoSize = true;
            buttonCancel.Location = new Point(546, 415);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 25);
            buttonCancel.TabIndex = 23;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(465, 417);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(75, 23);
            buttonSave.TabIndex = 22;
            buttonSave.Text = "Записать";
            buttonSave.UseVisualStyleBackColor = true;
            // 
            // buttonSaveExit
            // 
            buttonSaveExit.Location = new Point(337, 417);
            buttonSaveExit.Name = "buttonSaveExit";
            buttonSaveExit.Size = new Size(122, 23);
            buttonSaveExit.TabIndex = 21;
            buttonSaveExit.Text = "Записать и выйти";
            buttonSaveExit.UseVisualStyleBackColor = true;
            buttonSaveExit.Click += buttonSaveExit_Click;
            // 
            // smartGrid1
            // 
            smartGrid1.AllowMerging = C1.Win.FlexGrid.AllowMergingEnum.FixedOnly;
            smartGrid1.AllowMergingFixed = C1.Win.FlexGrid.AllowMergingEnum.FixedOnly;
            smartGrid1.AllowNodeMove = false;
            smartGrid1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            smartGrid1.ColumnInfo = resources.GetString("smartGrid1.ColumnInfo");
            smartGrid1.DrawMode = C1.Win.FlexGrid.DrawModeEnum.OwnerDraw;
            footerDescription1.Aggregates.Add(aggregateDefinition1);
            smartGrid1.Footers.Descriptions.Add(footerDescription1);
            smartGrid1.Footers.Fixed = true;
            smartGrid1.IdName = null;
            smartGrid1.Location = new Point(12, 51);
            smartGrid1.Name = "smartGrid1";
            smartGrid1.Rows.Count = 51;
            smartGrid1.Rows.Fixed = 2;
            smartGrid1.SelectedRows = (List<int>)resources.GetObject("smartGrid1.SelectedRows");
            smartGrid1.SelectionMode = C1.Win.FlexGrid.SelectionModeEnum.Row;
            smartGrid1.Size = new Size(603, 358);
            smartGrid1.SortingType = SmartLib.SortingType.Descending;
            smartGrid1.StyleInfo = resources.GetString("smartGrid1.StyleInfo");
            smartGrid1.TabIndex = 24;
            smartGrid1.Tree.Column = 1;
            // 
            // periodBox1
            // 
            periodBox1.Location = new Point(12, 12);
            periodBox1.Name = "periodBox1";
            periodBox1.Period.From = new DateTime(2026, 5, 22, 11, 1, 24, 642);
            periodBox1.Period.To = new DateTime(2026, 8, 20, 11, 1, 24, 642);
            // 
            // TestLookup
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(627, 450);
            Controls.Add(periodBox1);
            Controls.Add(smartGrid1);
            Controls.Add(buttonSaveExit);
            Controls.Add(buttonSave);
            Controls.Add(buttonCancel);
            Name = "TestLookup";
            Text = "TestLoolkup";
            Load += TestLookup_Load;
            ((System.ComponentModel.ISupportInitialize)smartGrid1).EndInit();
            ((System.ComponentModel.ISupportInitialize)periodBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button buttonCancel;
        private Button buttonSave;
        private Button buttonSaveExit;
        private SmartLib.SmartGrid smartGrid1;
        private SmartLib.PeriodBox periodBox1;
    }
}