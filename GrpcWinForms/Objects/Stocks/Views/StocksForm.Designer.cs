namespace GrpcWinForms.Objects.Stocks.Views
{
    partial class StocksForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StocksForm));
            C1.Win.FlexGrid.FooterDescription footerDescription1 = new C1.Win.FlexGrid.FooterDescription();
            C1.Win.FlexGrid.AggregateDefinition aggregateDefinition1 = new C1.Win.FlexGrid.AggregateDefinition();
            C1.Win.FlexGrid.FooterDescription footerDescription2 = new C1.Win.FlexGrid.FooterDescription();
            C1.Win.FlexGrid.AggregateDefinition aggregateDefinition2 = new C1.Win.FlexGrid.AggregateDefinition();
            c1SplitContainer1 = new C1.Win.SplitContainer.C1SplitContainer();
            spPlaces = new C1.Win.SplitContainer.C1SplitterPanel();
            gridPlaces = new SmartLib.SmartGrid(components);
            toolStripRates = new ToolStrip();
            tsbNewPlace = new ToolStripButton();
            tsbDoublePlace = new ToolStripButton();
            tsbEditPlace = new ToolStripButton();
            tsbDeletePlace = new ToolStripButton();
            tsbRefreshPlace = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            spStocks = new C1.Win.SplitContainer.C1SplitterPanel();
            gridStocks = new SmartLib.SmartGrid(components);
            toolStripCurrencies = new ToolStrip();
            tsbNewStock = new ToolStripButton();
            tsbDoubleStock = new ToolStripButton();
            tsbEditStock = new ToolStripButton();
            tsbDeleteStock = new ToolStripButton();
            tsbRefreshStock = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            panel1 = new Panel();
            lName = new Label();
            txtName = new TextBox();
            ((System.ComponentModel.ISupportInitialize)c1SplitContainer1).BeginInit();
            c1SplitContainer1.SuspendLayout();
            spPlaces.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridPlaces).BeginInit();
            toolStripRates.SuspendLayout();
            spStocks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridStocks).BeginInit();
            toolStripCurrencies.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // c1SplitContainer1
            // 
            c1SplitContainer1.AutoSizeElement = C1.Framework.AutoSizeElement.Both;
            c1SplitContainer1.BorderWidth = 1;
            c1SplitContainer1.Dock = DockStyle.Fill;
            c1SplitContainer1.HeaderButtonBackColor = Color.Transparent;
            c1SplitContainer1.Location = new Point(0, 34);
            c1SplitContainer1.Name = "c1SplitContainer1";
            c1SplitContainer1.Panels.Add(spPlaces);
            c1SplitContainer1.Panels.Add(spStocks);
            c1SplitContainer1.Size = new Size(684, 416);
            c1SplitContainer1.TabIndex = 4;
            // 
            // spPlaces
            // 
            spPlaces.Collapsible = true;
            spPlaces.Controls.Add(gridPlaces);
            spPlaces.Controls.Add(toolStripRates);
            spPlaces.Dock = C1.Win.SplitContainer.PanelDockStyle.Right;
            spPlaces.Location = new Point(351, 22);
            spPlaces.Name = "spPlaces";
            spPlaces.Size = new Size(332, 393);
            spPlaces.TabIndex = 0;
            spPlaces.Text = "Места  хранения";
            spPlaces.Width = 339;
            // 
            // gridPlaces
            // 
            gridPlaces.AllowEditing = false;
            gridPlaces.AllowMerging = C1.Win.FlexGrid.AllowMergingEnum.FixedOnly;
            gridPlaces.AllowMergingFixed = C1.Win.FlexGrid.AllowMergingEnum.FixedOnly;
            gridPlaces.AllowNodeMove = false;
            gridPlaces.AutoGenerateColumns = false;
            gridPlaces.ColumnInfo = resources.GetString("gridPlaces.ColumnInfo");
            gridPlaces.Dock = DockStyle.Fill;
            gridPlaces.DrawMode = C1.Win.FlexGrid.DrawModeEnum.OwnerDraw;
            aggregateDefinition1.Aggregate = C1.Win.FlexGrid.AggregateEnum.Count;
            aggregateDefinition1.Caption = "Всего: ";
            aggregateDefinition1.Column = 2;
            footerDescription1.Aggregates.Add(aggregateDefinition1);
            gridPlaces.Footers.Descriptions.Add(footerDescription1);
            gridPlaces.Footers.Fixed = true;
            gridPlaces.IdName = null;
            gridPlaces.Location = new Point(0, 31);
            gridPlaces.Name = "gridPlaces";
            gridPlaces.Rows.Count = 2;
            gridPlaces.SelectedRows = (List<int>)resources.GetObject("gridPlaces.SelectedRows");
            gridPlaces.SelectionMode = C1.Win.FlexGrid.SelectionModeEnum.Row;
            gridPlaces.Size = new Size(332, 362);
            gridPlaces.SortingType = SmartLib.SortingType.Descending;
            gridPlaces.StyleInfo = resources.GetString("gridPlaces.StyleInfo");
            gridPlaces.TabIndex = 3;
            // 
            // toolStripRates
            // 
            toolStripRates.ImageScalingSize = new Size(24, 24);
            toolStripRates.Items.AddRange(new ToolStripItem[] { tsbNewPlace, tsbDoublePlace, tsbEditPlace, tsbDeletePlace, tsbRefreshPlace, toolStripSeparator1 });
            toolStripRates.Location = new Point(0, 0);
            toolStripRates.Name = "toolStripRates";
            toolStripRates.Size = new Size(332, 31);
            toolStripRates.TabIndex = 1;
            toolStripRates.Text = "toolStrip1";
            // 
            // tsbNewPlace
            // 
            tsbNewPlace.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbNewPlace.Image = Properties.Resources.icons8_документ_50;
            tsbNewPlace.ImageTransparentColor = Color.Magenta;
            tsbNewPlace.Name = "tsbNewPlace";
            tsbNewPlace.Size = new Size(28, 28);
            tsbNewPlace.Text = "Новый";
            // 
            // tsbDoublePlace
            // 
            tsbDoublePlace.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbDoublePlace.Enabled = false;
            tsbDoublePlace.Image = Properties.Resources.icons8_скопировать_50;
            tsbDoublePlace.ImageTransparentColor = Color.Magenta;
            tsbDoublePlace.Name = "tsbDoublePlace";
            tsbDoublePlace.Size = new Size(28, 28);
            tsbDoublePlace.Text = "Дублировать";
            // 
            // tsbEditPlace
            // 
            tsbEditPlace.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbEditPlace.Enabled = false;
            tsbEditPlace.Image = Properties.Resources.icons8_редактирование_файла_50;
            tsbEditPlace.ImageTransparentColor = Color.Magenta;
            tsbEditPlace.Name = "tsbEditPlace";
            tsbEditPlace.Size = new Size(28, 28);
            tsbEditPlace.Text = "Редактировать";
            // 
            // tsbDeletePlace
            // 
            tsbDeletePlace.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbDeletePlace.Image = Properties.Resources.icons8_удалить_файл_50;
            tsbDeletePlace.ImageTransparentColor = Color.Magenta;
            tsbDeletePlace.Name = "tsbDeletePlace";
            tsbDeletePlace.Size = new Size(28, 28);
            tsbDeletePlace.Text = "Удалить";
            // 
            // tsbRefreshPlace
            // 
            tsbRefreshPlace.Alignment = ToolStripItemAlignment.Right;
            tsbRefreshPlace.Image = Properties.Resources.icons8_refresh_50;
            tsbRefreshPlace.ImageTransparentColor = Color.Magenta;
            tsbRefreshPlace.Name = "tsbRefreshPlace";
            tsbRefreshPlace.Size = new Size(89, 28);
            tsbRefreshPlace.Text = "Обновить";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 31);
            // 
            // spStocks
            // 
            spStocks.Controls.Add(gridStocks);
            spStocks.Controls.Add(toolStripCurrencies);
            spStocks.Height = 414;
            spStocks.Location = new Point(1, 22);
            spStocks.Name = "spStocks";
            spStocks.Size = new Size(339, 393);
            spStocks.TabIndex = 1;
            spStocks.Text = "Склады";
            // 
            // gridStocks
            // 
            gridStocks.AllowEditing = false;
            gridStocks.AllowMerging = C1.Win.FlexGrid.AllowMergingEnum.FixedOnly;
            gridStocks.AllowMergingFixed = C1.Win.FlexGrid.AllowMergingEnum.FixedOnly;
            gridStocks.AllowNodeMove = false;
            gridStocks.AutoGenerateColumns = false;
            gridStocks.ColumnInfo = resources.GetString("gridStocks.ColumnInfo");
            gridStocks.Dock = DockStyle.Fill;
            gridStocks.DrawMode = C1.Win.FlexGrid.DrawModeEnum.OwnerDraw;
            aggregateDefinition2.Aggregate = C1.Win.FlexGrid.AggregateEnum.Count;
            aggregateDefinition2.Caption = "Всего: ";
            aggregateDefinition2.Column = 2;
            footerDescription2.Aggregates.Add(aggregateDefinition2);
            gridStocks.Footers.Descriptions.Add(footerDescription2);
            gridStocks.Footers.Fixed = true;
            gridStocks.IdName = null;
            gridStocks.Location = new Point(0, 31);
            gridStocks.Name = "gridStocks";
            gridStocks.Rows.Count = 2;
            gridStocks.SelectedRows = (List<int>)resources.GetObject("gridStocks.SelectedRows");
            gridStocks.SelectionMode = C1.Win.FlexGrid.SelectionModeEnum.Row;
            gridStocks.Size = new Size(339, 362);
            gridStocks.SortingType = SmartLib.SortingType.Descending;
            gridStocks.StyleInfo = resources.GetString("gridStocks.StyleInfo");
            gridStocks.TabIndex = 5;
            // 
            // toolStripCurrencies
            // 
            toolStripCurrencies.ImageScalingSize = new Size(24, 24);
            toolStripCurrencies.Items.AddRange(new ToolStripItem[] { tsbNewStock, tsbDoubleStock, tsbEditStock, tsbDeleteStock, tsbRefreshStock, toolStripSeparator2 });
            toolStripCurrencies.Location = new Point(0, 0);
            toolStripCurrencies.Name = "toolStripCurrencies";
            toolStripCurrencies.Size = new Size(339, 31);
            toolStripCurrencies.TabIndex = 3;
            toolStripCurrencies.Text = "toolStrip2";
            // 
            // tsbNewStock
            // 
            tsbNewStock.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbNewStock.Image = Properties.Resources.icons8_документ_50;
            tsbNewStock.ImageTransparentColor = Color.Magenta;
            tsbNewStock.Name = "tsbNewStock";
            tsbNewStock.Size = new Size(28, 28);
            tsbNewStock.Text = "Новый";
            // 
            // tsbDoubleStock
            // 
            tsbDoubleStock.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbDoubleStock.Enabled = false;
            tsbDoubleStock.Image = Properties.Resources.icons8_скопировать_50;
            tsbDoubleStock.ImageTransparentColor = Color.Magenta;
            tsbDoubleStock.Name = "tsbDoubleStock";
            tsbDoubleStock.Size = new Size(28, 28);
            tsbDoubleStock.Text = "Дублировать";
            // 
            // tsbEditStock
            // 
            tsbEditStock.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbEditStock.Image = Properties.Resources.icons8_редактирование_файла_50;
            tsbEditStock.ImageTransparentColor = Color.Magenta;
            tsbEditStock.Name = "tsbEditStock";
            tsbEditStock.Size = new Size(28, 28);
            tsbEditStock.Text = "Редактировать";
            // 
            // tsbDeleteStock
            // 
            tsbDeleteStock.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbDeleteStock.Image = Properties.Resources.icons8_удалить_файл_50;
            tsbDeleteStock.ImageTransparentColor = Color.Magenta;
            tsbDeleteStock.Name = "tsbDeleteStock";
            tsbDeleteStock.Size = new Size(28, 28);
            tsbDeleteStock.Text = "Удалить";
            // 
            // tsbRefreshStock
            // 
            tsbRefreshStock.Alignment = ToolStripItemAlignment.Right;
            tsbRefreshStock.Image = Properties.Resources.icons8_refresh_50;
            tsbRefreshStock.ImageTransparentColor = Color.Magenta;
            tsbRefreshStock.Name = "tsbRefreshStock";
            tsbRefreshStock.Size = new Size(89, 28);
            tsbRefreshStock.Text = "Обновить";
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 31);
            // 
            // panel1
            // 
            panel1.Controls.Add(lName);
            panel1.Controls.Add(txtName);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(684, 34);
            panel1.TabIndex = 3;
            // 
            // lName
            // 
            lName.AutoSize = true;
            lName.Location = new Point(20, 10);
            lName.Name = "lName";
            lName.Size = new Size(133, 15);
            lName.TabIndex = 1;
            lName.Text = "Наименование склада:";
            // 
            // txtName
            // 
            txtName.Location = new Point(159, 6);
            txtName.Name = "txtName";
            txtName.PlaceholderText = "Наименование склада";
            txtName.Size = new Size(191, 23);
            txtName.TabIndex = 2;
            // 
            // StocksForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(684, 450);
            Controls.Add(c1SplitContainer1);
            Controls.Add(panel1);
            MinimumSize = new Size(700, 0);
            Name = "StocksForm";
            Text = "Склады";
            Load += StocksForm_Load;
            ((System.ComponentModel.ISupportInitialize)c1SplitContainer1).EndInit();
            c1SplitContainer1.ResumeLayout(false);
            spPlaces.ResumeLayout(false);
            spPlaces.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridPlaces).EndInit();
            toolStripRates.ResumeLayout(false);
            toolStripRates.PerformLayout();
            spStocks.ResumeLayout(false);
            spStocks.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridStocks).EndInit();
            toolStripCurrencies.ResumeLayout(false);
            toolStripCurrencies.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private C1.Win.SplitContainer.C1SplitContainer c1SplitContainer1;
        private C1.Win.SplitContainer.C1SplitterPanel spPlaces;
        private SmartLib.SmartGrid gridPlaces;
        private ToolStrip toolStripRates;
        private ToolStripButton tsbNewPlace;
        private ToolStripButton tsbDoublePlace;
        private ToolStripButton tsbEditPlace;
        private ToolStripButton tsbDeletePlace;
        private ToolStripButton tsbRefreshPlace;
        private ToolStripSeparator toolStripSeparator1;
        private C1.Win.SplitContainer.C1SplitterPanel spStocks;
        private SmartLib.SmartGrid gridStocks;
        private ToolStrip toolStripCurrencies;
        private ToolStripButton tsbNewStock;
        private ToolStripButton tsbDoubleStock;
        private ToolStripButton tsbEditStock;
        private ToolStripButton tsbDeleteStock;
        private ToolStripButton tsbRefreshStock;
        private ToolStripSeparator toolStripSeparator2;
        private Panel panel1;
        private Label lName;
        private TextBox txtName;
    }
}