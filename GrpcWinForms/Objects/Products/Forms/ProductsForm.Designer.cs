namespace GrpcWinForms.Objects.Products.ProductsForm
{
    partial class ProductsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductsForm));
            C1.Win.FlexGrid.FooterDescription footerDescription1 = new C1.Win.FlexGrid.FooterDescription();
            panel2 = new Panel();
            c1SplitContainer1 = new C1.Win.SplitContainer.C1SplitContainer();
            c1SplitterPanel2 = new C1.Win.SplitContainer.C1SplitterPanel();
            c1SplitterPanel1 = new C1.Win.SplitContainer.C1SplitterPanel();
            smartGrid = new SmartGrid.SmartGrid();
            toolStrip1 = new ToolStrip();
            toolStripButtonNew = new ToolStripButton();
            toolStripButtonDouble = new ToolStripButton();
            toolStripButtonEdit = new ToolStripButton();
            toolStripButtonDelete = new ToolStripButton();
            toolStripButtonRefresh = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripButtonLevels = new ToolStripSplitButton();
            toolStripButtonPath = new ToolStripButton();
            catalogLineBindingSource = new BindingSource(components);
            panel1 = new Panel();
            checkIncludeInvisible = new CheckBox();
            labelAbbrev = new Label();
            textAbbrev = new TextBox();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)c1SplitContainer1).BeginInit();
            c1SplitContainer1.SuspendLayout();
            c1SplitterPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)smartGrid).BeginInit();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)catalogLineBindingSource).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.Controls.Add(c1SplitContainer1);
            panel2.Controls.Add(toolStrip1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 68);
            panel2.Name = "panel2";
            panel2.Size = new Size(988, 382);
            panel2.TabIndex = 3;
            // 
            // c1SplitContainer1
            // 
            c1SplitContainer1.AutoSizeElement = C1.Framework.AutoSizeElement.Both;
            c1SplitContainer1.Dock = DockStyle.Fill;
            c1SplitContainer1.EnlargeCollapsingHandle = true;
            c1SplitContainer1.Location = new Point(0, 31);
            c1SplitContainer1.Name = "c1SplitContainer1";
            c1SplitContainer1.Panels.Add(c1SplitterPanel2);
            c1SplitContainer1.Panels.Add(c1SplitterPanel1);
            c1SplitContainer1.Size = new Size(988, 351);
            c1SplitContainer1.SplitterWidth = 2;
            c1SplitContainer1.TabIndex = 3;
            // 
            // c1SplitterPanel2
            // 
            c1SplitterPanel2.Collapsible = true;
            c1SplitterPanel2.Dock = C1.Win.SplitContainer.PanelDockStyle.Right;
            c1SplitterPanel2.Location = new Point(309, 0);
            c1SplitterPanel2.Name = "c1SplitterPanel2";
            c1SplitterPanel2.Size = new Size(679, 351);
            c1SplitterPanel2.SizeRatio = 70D;
            c1SplitterPanel2.TabIndex = 1;
            c1SplitterPanel2.Width = 690;
            // 
            // c1SplitterPanel1
            // 
            c1SplitterPanel1.Collapsible = true;
            c1SplitterPanel1.Controls.Add(smartGrid);
            c1SplitterPanel1.Dock = C1.Win.SplitContainer.PanelDockStyle.Left;
            c1SplitterPanel1.KeepRelativeSize = false;
            c1SplitterPanel1.Location = new Point(0, 0);
            c1SplitterPanel1.Name = "c1SplitterPanel1";
            c1SplitterPanel1.Size = new Size(296, 351);
            c1SplitterPanel1.SizeRatio = 30D;
            c1SplitterPanel1.TabIndex = 0;
            c1SplitterPanel1.Width = 296;
            // 
            // smartGrid
            // 
            smartGrid.AllowEditing = false;
            smartGrid.AllowMergingFixed = C1.Win.FlexGrid.AllowMergingEnum.None;
            smartGrid.AllowNodeMove = false;
            smartGrid.AutoGenerateColumns = false;
            smartGrid.ColumnInfo = resources.GetString("smartGrid.ColumnInfo");
            smartGrid.Dock = DockStyle.Fill;
            smartGrid.DrawMode = C1.Win.FlexGrid.DrawModeEnum.OwnerDraw;
            smartGrid.Footers.Descriptions.Add(footerDescription1);
            smartGrid.Footers.Fixed = true;
            smartGrid.Headers = null;
            smartGrid.IdName = null;
            smartGrid.IsEditing = false;
            smartGrid.Location = new Point(0, 0);
            smartGrid.Name = "smartGrid";
            smartGrid.Rows.Count = 15;
            smartGrid.SelectedRows = (List<int>)resources.GetObject("smartGrid.SelectedRows");
            smartGrid.SelectionMode = C1.Win.FlexGrid.SelectionModeEnum.Row;
            smartGrid.Size = new Size(296, 351);
            smartGrid.SortingType = SmartGrid.SortingType.Descending;
            smartGrid.StyleInfo = resources.GetString("smartGrid.StyleInfo");
            smartGrid.TabIndex = 2;
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(24, 24);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripButtonNew, toolStripButtonDouble, toolStripButtonEdit, toolStripButtonDelete, toolStripButtonRefresh, toolStripSeparator1, toolStripButtonLevels, toolStripButtonPath });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(988, 31);
            toolStrip1.TabIndex = 0;
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
            // toolStripButtonLevels
            // 
            toolStripButtonLevels.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButtonLevels.Image = Properties.Resources.icons8_дерево_папок_40;
            toolStripButtonLevels.ImageTransparentColor = Color.Magenta;
            toolStripButtonLevels.Name = "toolStripButtonLevels";
            toolStripButtonLevels.Size = new Size(40, 28);
            toolStripButtonLevels.Text = "Уровень группировок";
            // 
            // toolStripButtonPath
            // 
            toolStripButtonPath.CheckOnClick = true;
            toolStripButtonPath.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButtonPath.Image = Properties.Resources.icons8_древовидная_структура_50;
            toolStripButtonPath.ImageTransparentColor = Color.Magenta;
            toolStripButtonPath.Name = "toolStripButtonPath";
            toolStripButtonPath.Size = new Size(28, 28);
            toolStripButtonPath.Text = "Только текущая ветка";
            toolStripButtonPath.Click += toolStripButtonPath_Click;
            // 
            // catalogLineBindingSource
            // 
            catalogLineBindingSource.DataSource = typeof(GrpcCommonNet.Library.Common.CatalogLine);
            // 
            // panel1
            // 
            panel1.Controls.Add(checkIncludeInvisible);
            panel1.Controls.Add(labelAbbrev);
            panel1.Controls.Add(textAbbrev);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(988, 68);
            panel1.TabIndex = 2;
            // 
            // checkIncludeInvisible
            // 
            checkIncludeInvisible.AutoSize = true;
            checkIncludeInvisible.CheckAlign = ContentAlignment.MiddleRight;
            checkIncludeInvisible.Location = new Point(117, 9);
            checkIncludeInvisible.Name = "checkIncludeInvisible";
            checkIncludeInvisible.Size = new Size(45, 19);
            checkIncludeInvisible.TabIndex = 2;
            checkIncludeInvisible.Text = "Все";
            checkIncludeInvisible.UseVisualStyleBackColor = true;
            // 
            // labelAbbrev
            // 
            labelAbbrev.AutoSize = true;
            labelAbbrev.Location = new Point(20, 9);
            labelAbbrev.Name = "labelAbbrev";
            labelAbbrev.Size = new Size(48, 15);
            labelAbbrev.TabIndex = 1;
            labelAbbrev.Text = "Валюта";
            // 
            // textAbbrev
            // 
            textAbbrev.Location = new Point(74, 6);
            textAbbrev.Name = "textAbbrev";
            textAbbrev.Size = new Size(37, 23);
            textAbbrev.TabIndex = 0;
            // 
            // ProductsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(988, 450);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "ProductsForm";
            Text = "Номенклатура";
            Load += ProductsForm_Load;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)c1SplitContainer1).EndInit();
            c1SplitContainer1.ResumeLayout(false);
            c1SplitterPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)smartGrid).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)catalogLineBindingSource).EndInit();
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
        private CheckBox checkIncludeInvisible;
        private Label labelAbbrev;
        private TextBox textAbbrev;
        private BindingSource catalogLineBindingSource;
        private C1.Win.SplitContainer.C1SplitContainer c1SplitContainer1;
        private C1.Win.SplitContainer.C1SplitterPanel c1SplitterPanel2;
        private C1.Win.SplitContainer.C1SplitterPanel c1SplitterPanel1;
        private ToolStripSplitButton toolStripButtonLevels;
        private ToolStripButton toolStripButtonPath;
    }
}