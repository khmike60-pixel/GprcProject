namespace GrpcWinForms.Objects.Test
{
    partial class LookupPopupForm
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
            flexGrid = new C1.Win.FlexGrid.C1FlexGrid();
            ((System.ComponentModel.ISupportInitialize)flexGrid).BeginInit();
            SuspendLayout();
            // 
            // flexGrid
            // 
            flexGrid.ColumnInfo = "1,0,0,0,0,-1,Columns:0{Width:365;StarWidth:\"*\";}\t";
            flexGrid.Dock = DockStyle.Fill;
            flexGrid.Location = new Point(0, 0);
            flexGrid.Name = "flexGrid";
            flexGrid.Rows.Fixed = 0;
            flexGrid.Size = new Size(384, 314);
            flexGrid.TabIndex = 0;
            // 
            // LookupPopupForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(384, 314);
            Controls.Add(flexGrid);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "LookupPopupForm";
            Text = "LookupPopupForm";
            ((System.ComponentModel.ISupportInitialize)flexGrid).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private C1.Win.FlexGrid.C1FlexGrid flexGrid;
    }
}