namespace GrpcWinForms.Objects.Geolocations.GeoForms
{
    partial class GeolocationsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GeolocationsForm));
            C1.Win.FlexGrid.FooterDescription footerDescription1 = new C1.Win.FlexGrid.FooterDescription();
            panel2 = new Panel();
            smartGrid = new SmartGrid.SmartGrid();
            toolStrip1 = new ToolStrip();
            toolStripButtonNew = new ToolStripButton();
            toolStripButtonDouble = new ToolStripButton();
            toolStripButtonEdit = new ToolStripButton();
            toolStripButtonDelete = new ToolStripButton();
            toolStripButtonRefresh = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripSplitButtonLevels = new ToolStripSplitButton();
            toolStripButtonPath = new ToolStripButton();
            panel1 = new Panel();
            textBoxGeoName = new TextBox();
            labelName = new Label();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)smartGrid).BeginInit();
            toolStrip1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.Controls.Add(smartGrid);
            panel2.Controls.Add(toolStrip1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 34);
            panel2.Name = "panel2";
            panel2.Size = new Size(800, 416);
            panel2.TabIndex = 3;
            // 
            // smartGrid
            // 
            smartGrid.AllowMergingFixed = C1.Win.FlexGrid.AllowMergingEnum.FixedOnly;
            smartGrid.AllowNodeMove = false;
            smartGrid.AllowSorting = C1.Win.FlexGrid.AllowSortingEnum.SingleColumn;
            smartGrid.AutoGenerateColumns = false;
            smartGrid.ColumnInfo = resources.GetString("smartGrid.ColumnInfo");
            smartGrid.Dock = DockStyle.Fill;
            smartGrid.DrawMode = C1.Win.FlexGrid.DrawModeEnum.OwnerDraw;
            smartGrid.Footers.Descriptions.Add(footerDescription1);
            smartGrid.Footers.Fixed = true;
            smartGrid.Headers = new string[]
    {
    "..\tНаименование\tId\tParentId\tКод 2\tJsonCode\tКод 3"
    };
            smartGrid.IdName = null;
            smartGrid.IsEditing = false;
            smartGrid.Location = new Point(0, 31);
            smartGrid.Name = "smartGrid";
            smartGrid.Rows.Count = 14;
            smartGrid.SelectedRows = (List<int>)resources.GetObject("smartGrid.SelectedRows");
            smartGrid.SelectionMode = C1.Win.FlexGrid.SelectionModeEnum.Row;
            smartGrid.Size = new Size(800, 385);
            smartGrid.SortingType = SmartGrid.SortingType.Descending;
            smartGrid.StyleInfo = resources.GetString("smartGrid.StyleInfo");
            smartGrid.TabIndex = 2;
            smartGrid.AfterResizeColumn += smartGrid_AfterResizeColumn;
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(24, 24);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripButtonNew, toolStripButtonDouble, toolStripButtonEdit, toolStripButtonDelete, toolStripButtonRefresh, toolStripSeparator1, toolStripSplitButtonLevels, toolStripButtonPath });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(800, 31);
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
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
            toolStripButtonDouble.Enabled = false;
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
            toolStripButtonRefresh.Click += toolStripButtonRefresh_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 31);
            // 
            // toolStripSplitButtonLevels
            // 
            toolStripSplitButtonLevels.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripSplitButtonLevels.Image = Properties.Resources.icons8_дерево_папок_40;
            toolStripSplitButtonLevels.ImageTransparentColor = Color.Magenta;
            toolStripSplitButtonLevels.Name = "toolStripSplitButtonLevels";
            toolStripSplitButtonLevels.Size = new Size(40, 28);
            toolStripSplitButtonLevels.Text = "Уровень группировок";
            // 
            // toolStripButtonPath
            // 
            toolStripButtonPath.CheckOnClick = true;
            toolStripButtonPath.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButtonPath.Image = Properties.Resources.icons8_древовидная_структура_50;
            toolStripButtonPath.ImageTransparentColor = Color.Magenta;
            toolStripButtonPath.Name = "toolStripButtonPath";
            toolStripButtonPath.Size = new Size(28, 28);
            toolStripButtonPath.Text = "toolStripButton1";
            toolStripButtonPath.Click += toolStripButtonPath_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(textBoxGeoName);
            panel1.Controls.Add(labelName);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 34);
            panel1.TabIndex = 2;
            // 
            // textBoxGeoName
            // 
            textBoxGeoName.Location = new Point(117, 5);
            textBoxGeoName.Name = "textBoxGeoName";
            textBoxGeoName.Size = new Size(127, 23);
            textBoxGeoName.TabIndex = 1;
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Location = new Point(20, 8);
            labelName.Name = "labelName";
            labelName.Size = new Size(90, 15);
            labelName.TabIndex = 0;
            labelName.Text = "Наименование";
            // 
            // GeolocationsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "GeolocationsForm";
            Text = "Страны, города, районы";
            Load += GeolocationsForm_Load;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)smartGrid).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel2;
        private SmartGrid.SmartGrid smartGrid;
        private ToolStrip toolStrip1;
        private ToolStripButton toolStripButtonNew;
        private ToolStripButton toolStripButtonDouble;
        private ToolStripButton toolStripButtonEdit;
        private ToolStripButton toolStripButtonDelete;
        private ToolStripButton toolStripButtonRefresh;
        private ToolStripSeparator toolStripSeparator1;
        private Panel panel1;
        private TextBox textBoxGeoName;
        private Label labelName;
        private ToolStripSplitButton toolStripSplitButtonLevels;
        private ToolStripButton toolStripButtonPath;
    }
}