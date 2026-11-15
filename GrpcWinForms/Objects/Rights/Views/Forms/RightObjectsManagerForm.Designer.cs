namespace GrpcWinForms.Objects.Rights.Views.Forms
{
    partial class RightObjectsManagerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RightObjectsManagerForm));
            C1.Win.FlexGrid.FooterDescription footerDescription1 = new C1.Win.FlexGrid.FooterDescription();
            C1.Win.FlexGrid.AggregateDefinition aggregateDefinition1 = new C1.Win.FlexGrid.AggregateDefinition();
            panel2 = new Panel();
            grid = new SmartLib.SmartGrid(components);
            toolStrip1 = new ToolStrip();
            btnNew = new ToolStripButton();
            btnDouble = new ToolStripButton();
            btnEdit = new ToolStripButton();
            btnDelete = new ToolStripButton();
            btnRefresh = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            panel1 = new Panel();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grid).BeginInit();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.Controls.Add(grid);
            panel2.Controls.Add(toolStrip1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 34);
            panel2.Name = "panel2";
            panel2.Size = new Size(800, 416);
            panel2.TabIndex = 3;
            // 
            // grid
            // 
            grid.AllowEditing = false;
            grid.AllowMerging = C1.Win.FlexGrid.AllowMergingEnum.FixedOnly;
            grid.AllowMergingFixed = C1.Win.FlexGrid.AllowMergingEnum.FixedOnly;
            grid.AllowNodeMove = false;
            grid.AutoGenerateColumns = false;
            grid.ColumnInfo = resources.GetString("grid.ColumnInfo");
            grid.Dock = DockStyle.Fill;
            grid.DrawMode = C1.Win.FlexGrid.DrawModeEnum.OwnerDraw;
            aggregateDefinition1.Aggregate = C1.Win.FlexGrid.AggregateEnum.Count;
            aggregateDefinition1.Caption = "Всего: ";
            aggregateDefinition1.Column = 2;
            footerDescription1.Aggregates.Add(aggregateDefinition1);
            grid.Footers.Descriptions.Add(footerDescription1);
            grid.Footers.Fixed = true;
            grid.IdName = null;
            grid.Location = new Point(0, 31);
            grid.Name = "grid";
            grid.Rows.Count = 51;
            grid.SelectedRows = (List<int>)resources.GetObject("grid.SelectedRows");
            grid.SelectionMode = C1.Win.FlexGrid.SelectionModeEnum.Row;
            grid.Size = new Size(800, 385);
            grid.SortingType = SmartLib.SortingType.Descending;
            grid.StyleInfo = resources.GetString("grid.StyleInfo");
            grid.TabIndex = 3;
            grid.BeforeNodeMove += grid_BeforeNodeMove;
            grid.AfterNodeMove += grid_AfterNodeMove;
            grid.BeforeEdit += grid_BeforeEdit;
            grid.AfterEdit += grid_AfterEdit;
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(24, 24);
            toolStrip1.Items.AddRange(new ToolStripItem[] { btnNew, btnDouble, btnEdit, btnDelete, btnRefresh, toolStripSeparator1 });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(800, 31);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // btnNew
            // 
            btnNew.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnNew.Image = Properties.Resources.icons8_документ_50;
            btnNew.ImageTransparentColor = Color.Magenta;
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(28, 28);
            btnNew.Text = "Новый";
            btnNew.Click += btnNew_Click;
            // 
            // btnDouble
            // 
            btnDouble.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnDouble.Enabled = false;
            btnDouble.Image = Properties.Resources.icons8_скопировать_50;
            btnDouble.ImageTransparentColor = Color.Magenta;
            btnDouble.Name = "btnDouble";
            btnDouble.Size = new Size(28, 28);
            btnDouble.Text = "Дублировать";
            // 
            // btnEdit
            // 
            btnEdit.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnEdit.Image = Properties.Resources.icons8_редактирование_файла_50;
            btnEdit.ImageTransparentColor = Color.Magenta;
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(28, 28);
            btnEdit.Text = "Редактировать";
            // 
            // btnDelete
            // 
            btnDelete.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnDelete.Image = Properties.Resources.icons8_удалить_файл_50;
            btnDelete.ImageTransparentColor = Color.Magenta;
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(28, 28);
            btnDelete.Text = "Удалить";
            btnDelete.Click += btnDelete_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Alignment = ToolStripItemAlignment.Right;
            btnRefresh.Image = Properties.Resources.icons8_refresh_50;
            btnRefresh.ImageTransparentColor = Color.Magenta;
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(89, 28);
            btnRefresh.Text = "Обновить";
            btnRefresh.Click += btnRefresh_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 31);
            // 
            // panel1
            // 
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 34);
            panel1.TabIndex = 2;
            // 
            // RightObjectsManagerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "RightObjectsManagerForm";
            Text = "Объекты права";
            Load += RightObjectsManagerForm_Load;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)grid).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel2;
        private SmartLib.SmartGrid grid;
        private ToolStrip toolStrip1;
        private ToolStripButton btnNew;
        private ToolStripButton btnDouble;
        private ToolStripButton btnEdit;
        private ToolStripButton btnDelete;
        private ToolStripButton btnRefresh;
        private ToolStripSeparator toolStripSeparator1;
        private Panel panel1;
    }
}