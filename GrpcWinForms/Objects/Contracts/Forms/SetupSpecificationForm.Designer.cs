namespace GrpcWinForms.Objects.Contracts.Forms
{
    partial class SetupSpecificationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetupSpecificationForm));
            panel1 = new Panel();
            buttonCancel = new Button();
            buttonOk = new Button();
            toolStripLines = new ToolStrip();
            toolStripButtonNew = new ToolStripButton();
            toolStripButtonDouble = new ToolStripButton();
            toolStripButtonEdit = new ToolStripButton();
            toolStripButtonDelete = new ToolStripButton();
            toolStripButtonRefresh = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            smartGrid = new SmartGrid.SmartGrid();
            panel1.SuspendLayout();
            toolStripLines.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)smartGrid).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(buttonCancel);
            panel1.Controls.Add(buttonOk);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 183);
            panel1.Name = "panel1";
            panel1.Size = new Size(453, 30);
            panel1.TabIndex = 0;
            // 
            // buttonCancel
            // 
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Location = new Point(294, 3);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 23);
            buttonCancel.TabIndex = 1;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // buttonOk
            // 
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonOk.Location = new Point(375, 3);
            buttonOk.Name = "buttonOk";
            buttonOk.Size = new Size(75, 23);
            buttonOk.TabIndex = 0;
            buttonOk.Text = "Ok";
            buttonOk.UseVisualStyleBackColor = true;
            buttonOk.Click += buttonOk_Click;
            // 
            // toolStripLines
            // 
            toolStripLines.ImageScalingSize = new Size(24, 24);
            toolStripLines.Items.AddRange(new ToolStripItem[] { toolStripButtonNew, toolStripButtonDouble, toolStripButtonEdit, toolStripButtonDelete, toolStripButtonRefresh, toolStripSeparator2 });
            toolStripLines.Location = new Point(0, 0);
            toolStripLines.Name = "toolStripLines";
            toolStripLines.Size = new Size(453, 31);
            toolStripLines.TabIndex = 6;
            toolStripLines.Text = "toolStrip2";
            // 
            // toolStripButtonNew
            // 
            toolStripButtonNew.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButtonNew.Image = Properties.Resources.icons8_документ_50;
            toolStripButtonNew.ImageTransparentColor = Color.Magenta;
            toolStripButtonNew.Name = "toolStripButtonNew";
            toolStripButtonNew.Size = new Size(28, 28);
            toolStripButtonNew.Text = "Новый";
            // 
            // toolStripButtonDouble
            // 
            toolStripButtonDouble.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButtonDouble.Image = Properties.Resources.icons8_скопировать_50;
            toolStripButtonDouble.ImageTransparentColor = Color.Magenta;
            toolStripButtonDouble.Name = "toolStripButtonDouble";
            toolStripButtonDouble.Size = new Size(28, 28);
            toolStripButtonDouble.Text = "Дублировать";
            // 
            // toolStripButtonEdit
            // 
            toolStripButtonEdit.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButtonEdit.Image = Properties.Resources.icons8_редактирование_файла_50;
            toolStripButtonEdit.ImageTransparentColor = Color.Magenta;
            toolStripButtonEdit.Name = "toolStripButtonEdit";
            toolStripButtonEdit.Size = new Size(28, 28);
            toolStripButtonEdit.Text = "Редактировать";
            // 
            // toolStripButtonDelete
            // 
            toolStripButtonDelete.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButtonDelete.Image = Properties.Resources.icons8_удалить_файл_50;
            toolStripButtonDelete.ImageTransparentColor = Color.Magenta;
            toolStripButtonDelete.Name = "toolStripButtonDelete";
            toolStripButtonDelete.Size = new Size(28, 28);
            toolStripButtonDelete.Text = "Удалить";
            // 
            // toolStripButtonRefresh
            // 
            toolStripButtonRefresh.Alignment = ToolStripItemAlignment.Right;
            toolStripButtonRefresh.Image = Properties.Resources.icons8_refresh_50;
            toolStripButtonRefresh.ImageTransparentColor = Color.Magenta;
            toolStripButtonRefresh.Name = "toolStripButtonRefresh";
            toolStripButtonRefresh.Size = new Size(89, 28);
            toolStripButtonRefresh.Text = "Обновить";
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 31);
            // 
            // smartGrid
            // 
            smartGrid.AllowMergingFixed = C1.Win.FlexGrid.AllowMergingEnum.None;
            smartGrid.AllowNodeMove = false;
            smartGrid.AutoGenerateColumns = false;
            smartGrid.ColumnInfo = resources.GetString("smartGrid.ColumnInfo");
            smartGrid.Dock = DockStyle.Fill;
            smartGrid.DrawMode = C1.Win.FlexGrid.DrawModeEnum.OwnerDraw;
            smartGrid.Headers = null;
            smartGrid.IdName = null;
            smartGrid.IsEditing = false;
            smartGrid.Location = new Point(0, 31);
            smartGrid.Name = "smartGrid";
            smartGrid.Rows.Count = 10;
            smartGrid.SelectedRows = (List<int>)resources.GetObject("smartGrid.SelectedRows");
            smartGrid.SelectionMode = C1.Win.FlexGrid.SelectionModeEnum.Row;
            smartGrid.Size = new Size(453, 152);
            smartGrid.SortingType = SmartGrid.SortingType.Descending;
            smartGrid.StyleInfo = resources.GetString("smartGrid.StyleInfo");
            smartGrid.TabIndex = 7;
            // 
            // SetupSpecificationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(453, 213);
            Controls.Add(smartGrid);
            Controls.Add(toolStripLines);
            Controls.Add(panel1);
            Name = "SetupSpecificationForm";
            Text = "Настройка спецификаций";
            Load += SetupSpecificationForm_Load;
            panel1.ResumeLayout(false);
            toolStripLines.ResumeLayout(false);
            toolStripLines.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)smartGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Button buttonCancel;
        private Button buttonOk;
        private ToolStrip toolStripLines;
        private ToolStripButton toolStripButtonNew;
        private ToolStripButton toolStripButtonDouble;
        private ToolStripButton toolStripButtonEdit;
        private ToolStripButton toolStripButtonDelete;
        private ToolStripButton toolStripButtonRefresh;
        private ToolStripSeparator toolStripSeparator2;
        private SmartGrid.SmartGrid smartGrid;
    }
}