namespace GrpcWinForms.Objects.Currencies.Forms
{
    partial class RatesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RatesForm));
            C1.Win.FlexGrid.FooterDescription footerDescription3 = new C1.Win.FlexGrid.FooterDescription();
            C1.Win.FlexGrid.AggregateDefinition aggregateDefinition3 = new C1.Win.FlexGrid.AggregateDefinition();
            C1.Win.FlexGrid.FooterDescription footerDescription1 = new C1.Win.FlexGrid.FooterDescription();
            C1.Win.FlexGrid.AggregateDefinition aggregateDefinition1 = new C1.Win.FlexGrid.AggregateDefinition();
            panel2 = new Panel();
            c1SplitContainer1 = new C1.Win.SplitContainer.C1SplitContainer();
            c1SplitterPanelRates = new C1.Win.SplitContainer.C1SplitterPanel();
            gridRates = new SmartLib.SmartGrid(components);
            toolStripRates = new ToolStrip();
            toolStripButtonNew = new ToolStripButton();
            toolStripButtonDouble = new ToolStripButton();
            toolStripButtonEdit = new ToolStripButton();
            toolStripButtonDelete = new ToolStripButton();
            toolStripButtonRefreshRates = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            c1SplitterPanelCurrencies = new C1.Win.SplitContainer.C1SplitterPanel();
            gridCurrencies = new SmartLib.SmartGrid(components);
            toolStripCurrencies = new ToolStrip();
            toolStripButton1 = new ToolStripButton();
            toolStripButton2 = new ToolStripButton();
            toolStripButton3 = new ToolStripButton();
            toolStripButton4 = new ToolStripButton();
            toolStripButtonCurrencies = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            panelFilter = new Panel();
            labelDateRates = new Label();
            dateTimePickerDateRates = new DateTimePicker();
            checkIncludeInvisible = new CheckBox();
            labelAbbrev = new Label();
            textAbbrev = new TextBox();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)c1SplitContainer1).BeginInit();
            c1SplitContainer1.SuspendLayout();
            c1SplitterPanelRates.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridRates).BeginInit();
            toolStripRates.SuspendLayout();
            c1SplitterPanelCurrencies.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridCurrencies).BeginInit();
            toolStripCurrencies.SuspendLayout();
            panelFilter.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.Controls.Add(c1SplitContainer1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 34);
            panel2.Name = "panel2";
            panel2.Size = new Size(714, 524);
            panel2.TabIndex = 3;
            // 
            // c1SplitContainer1
            // 
            c1SplitContainer1.AutoSizeElement = C1.Framework.AutoSizeElement.Both;
            c1SplitContainer1.Dock = DockStyle.Fill;
            c1SplitContainer1.HeaderButtonBackColor = Color.Transparent;
            c1SplitContainer1.Location = new Point(0, 0);
            c1SplitContainer1.Name = "c1SplitContainer1";
            c1SplitContainer1.Panels.Add(c1SplitterPanelRates);
            c1SplitContainer1.Panels.Add(c1SplitterPanelCurrencies);
            c1SplitContainer1.Size = new Size(714, 524);
            c1SplitContainer1.TabIndex = 3;
            // 
            // c1SplitterPanelRates
            // 
            c1SplitterPanelRates.Collapsible = true;
            c1SplitterPanelRates.Controls.Add(gridRates);
            c1SplitterPanelRates.Controls.Add(toolStripRates);
            c1SplitterPanelRates.Dock = C1.Win.SplitContainer.PanelDockStyle.Right;
            c1SplitterPanelRates.Location = new Point(445, 0);
            c1SplitterPanelRates.Name = "c1SplitterPanelRates";
            c1SplitterPanelRates.Size = new Size(269, 524);
            c1SplitterPanelRates.SizeRatio = 38.911D;
            c1SplitterPanelRates.TabIndex = 0;
            c1SplitterPanelRates.Width = 276;
            // 
            // gridRates
            // 
            gridRates.AllowEditing = false;
            gridRates.AllowMerging = C1.Win.FlexGrid.AllowMergingEnum.FixedOnly;
            gridRates.AllowMergingFixed = C1.Win.FlexGrid.AllowMergingEnum.FixedOnly;
            gridRates.AllowNodeMove = false;
            gridRates.AutoGenerateColumns = false;
            gridRates.ColumnInfo = resources.GetString("gridRates.ColumnInfo");
            gridRates.Dock = DockStyle.Fill;
            gridRates.DrawMode = C1.Win.FlexGrid.DrawModeEnum.OwnerDraw;
            aggregateDefinition3.Aggregate = C1.Win.FlexGrid.AggregateEnum.Count;
            aggregateDefinition3.Caption = "Всего: ";
            aggregateDefinition3.Column = 2;
            footerDescription3.Aggregates.Add(aggregateDefinition3);
            gridRates.Footers.Descriptions.Add(footerDescription3);
            gridRates.Footers.Fixed = true;
            gridRates.IdName = null;
            gridRates.Location = new Point(0, 31);
            gridRates.Name = "gridRates";
            gridRates.Rows.Count = 51;
            gridRates.SelectedRows = (List<int>)resources.GetObject("gridRates.SelectedRows");
            gridRates.SelectionMode = C1.Win.FlexGrid.SelectionModeEnum.Row;
            gridRates.Size = new Size(269, 493);
            gridRates.SortingType = SmartLib.SortingType.Descending;
            gridRates.StyleInfo = resources.GetString("gridRates.StyleInfo");
            gridRates.TabIndex = 2;
            gridRates.AfterFreezeColumn += gridRates_AfterFreezeColumn;
            gridRates.GetUnboundValue += gridRates_GetUnboundValue;
            // 
            // toolStripRates
            // 
            toolStripRates.ImageScalingSize = new Size(24, 24);
            toolStripRates.Items.AddRange(new ToolStripItem[] { toolStripButtonNew, toolStripButtonDouble, toolStripButtonEdit, toolStripButtonDelete, toolStripButtonRefreshRates, toolStripSeparator1 });
            toolStripRates.Location = new Point(0, 0);
            toolStripRates.Name = "toolStripRates";
            toolStripRates.Size = new Size(269, 31);
            toolStripRates.TabIndex = 0;
            toolStripRates.Text = "toolStrip1";
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
            // toolStripButtonRefreshRates
            // 
            toolStripButtonRefreshRates.Alignment = ToolStripItemAlignment.Right;
            toolStripButtonRefreshRates.Image = Properties.Resources.icons8_refresh_50;
            toolStripButtonRefreshRates.ImageTransparentColor = Color.Magenta;
            toolStripButtonRefreshRates.Name = "toolStripButtonRefreshRates";
            toolStripButtonRefreshRates.Size = new Size(89, 28);
            toolStripButtonRefreshRates.Text = "Обновить";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 31);
            // 
            // c1SplitterPanelCurrencies
            // 
            c1SplitterPanelCurrencies.Controls.Add(gridCurrencies);
            c1SplitterPanelCurrencies.Controls.Add(toolStripCurrencies);
            c1SplitterPanelCurrencies.Dock = C1.Win.SplitContainer.PanelDockStyle.Left;
            c1SplitterPanelCurrencies.Location = new Point(0, 0);
            c1SplitterPanelCurrencies.Name = "c1SplitterPanelCurrencies";
            c1SplitterPanelCurrencies.Size = new Size(434, 524);
            c1SplitterPanelCurrencies.TabIndex = 1;
            c1SplitterPanelCurrencies.Width = 434;
            // 
            // gridCurrencies
            // 
            gridCurrencies.AllowEditing = false;
            gridCurrencies.AllowMerging = C1.Win.FlexGrid.AllowMergingEnum.FixedOnly;
            gridCurrencies.AllowMergingFixed = C1.Win.FlexGrid.AllowMergingEnum.FixedOnly;
            gridCurrencies.AllowNodeMove = false;
            gridCurrencies.AutoGenerateColumns = false;
            gridCurrencies.ColumnInfo = resources.GetString("gridCurrencies.ColumnInfo");
            gridCurrencies.Dock = DockStyle.Fill;
            gridCurrencies.DrawMode = C1.Win.FlexGrid.DrawModeEnum.OwnerDraw;
            aggregateDefinition1.Aggregate = C1.Win.FlexGrid.AggregateEnum.Count;
            aggregateDefinition1.Caption = "Всего: ";
            aggregateDefinition1.Column = 3;
            footerDescription1.Aggregates.Add(aggregateDefinition1);
            gridCurrencies.Footers.Descriptions.Add(footerDescription1);
            gridCurrencies.Footers.Fixed = true;
            gridCurrencies.IdName = null;
            gridCurrencies.Location = new Point(0, 31);
            gridCurrencies.Name = "gridCurrencies";
            gridCurrencies.Rows.Count = 51;
            gridCurrencies.SelectedRows = (List<int>)resources.GetObject("gridCurrencies.SelectedRows");
            gridCurrencies.SelectionMode = C1.Win.FlexGrid.SelectionModeEnum.Row;
            gridCurrencies.Size = new Size(434, 493);
            gridCurrencies.SortingType = SmartLib.SortingType.Descending;
            gridCurrencies.StyleInfo = resources.GetString("gridCurrencies.StyleInfo");
            gridCurrencies.TabIndex = 4;
            gridCurrencies.AfterFreezeColumn += gridCurrencies_AfterFreezeColumn;
            gridCurrencies.AfterSelChange += gridCurrencies_AfterSelChange;
            gridCurrencies.GetUnboundValue += gridCurrencies_GetUnboundValue;
            // 
            // toolStripCurrencies
            // 
            toolStripCurrencies.ImageScalingSize = new Size(24, 24);
            toolStripCurrencies.Items.AddRange(new ToolStripItem[] { toolStripButton1, toolStripButton2, toolStripButton3, toolStripButton4, toolStripButtonCurrencies, toolStripSeparator2 });
            toolStripCurrencies.Location = new Point(0, 0);
            toolStripCurrencies.Name = "toolStripCurrencies";
            toolStripCurrencies.Size = new Size(434, 31);
            toolStripCurrencies.TabIndex = 2;
            toolStripCurrencies.Text = "toolStrip2";
            // 
            // toolStripButton1
            // 
            toolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton1.Enabled = false;
            toolStripButton1.Image = Properties.Resources.icons8_документ_50;
            toolStripButton1.ImageTransparentColor = Color.Magenta;
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Size = new Size(28, 28);
            toolStripButton1.Text = "Новый";
            // 
            // toolStripButton2
            // 
            toolStripButton2.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton2.Enabled = false;
            toolStripButton2.Image = Properties.Resources.icons8_скопировать_50;
            toolStripButton2.ImageTransparentColor = Color.Magenta;
            toolStripButton2.Name = "toolStripButton2";
            toolStripButton2.Size = new Size(28, 28);
            toolStripButton2.Text = "Дублировать";
            // 
            // toolStripButton3
            // 
            toolStripButton3.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton3.Enabled = false;
            toolStripButton3.Image = Properties.Resources.icons8_редактирование_файла_50;
            toolStripButton3.ImageTransparentColor = Color.Magenta;
            toolStripButton3.Name = "toolStripButton3";
            toolStripButton3.Size = new Size(28, 28);
            toolStripButton3.Text = "Редактировать";
            // 
            // toolStripButton4
            // 
            toolStripButton4.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton4.Enabled = false;
            toolStripButton4.Image = Properties.Resources.icons8_удалить_файл_50;
            toolStripButton4.ImageTransparentColor = Color.Magenta;
            toolStripButton4.Name = "toolStripButton4";
            toolStripButton4.Size = new Size(28, 28);
            toolStripButton4.Text = "Удалить";
            // 
            // toolStripButtonCurrencies
            // 
            toolStripButtonCurrencies.Alignment = ToolStripItemAlignment.Right;
            toolStripButtonCurrencies.Image = Properties.Resources.icons8_refresh_50;
            toolStripButtonCurrencies.ImageTransparentColor = Color.Magenta;
            toolStripButtonCurrencies.Name = "toolStripButtonCurrencies";
            toolStripButtonCurrencies.Size = new Size(89, 28);
            toolStripButtonCurrencies.Text = "Обновить";
            toolStripButtonCurrencies.Click += toolStripButtonCurrencies_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 31);
            // 
            // panelFilter
            // 
            panelFilter.Controls.Add(labelDateRates);
            panelFilter.Controls.Add(dateTimePickerDateRates);
            panelFilter.Controls.Add(checkIncludeInvisible);
            panelFilter.Controls.Add(labelAbbrev);
            panelFilter.Controls.Add(textAbbrev);
            panelFilter.Dock = DockStyle.Top;
            panelFilter.Location = new Point(0, 0);
            panelFilter.Name = "panelFilter";
            panelFilter.Size = new Size(714, 34);
            panelFilter.TabIndex = 2;
            // 
            // labelDateRates
            // 
            labelDateRates.AutoSize = true;
            labelDateRates.Location = new Point(168, 10);
            labelDateRates.Name = "labelDateRates";
            labelDateRates.Size = new Size(84, 15);
            labelDateRates.TabIndex = 3;
            labelDateRates.Text = "Курсы на дату";
            // 
            // dateTimePickerDateRates
            // 
            dateTimePickerDateRates.Format = DateTimePickerFormat.Short;
            dateTimePickerDateRates.Location = new Point(258, 6);
            dateTimePickerDateRates.Name = "dateTimePickerDateRates";
            dateTimePickerDateRates.Size = new Size(82, 23);
            dateTimePickerDateRates.TabIndex = 4;
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
            labelAbbrev.TabIndex = 0;
            labelAbbrev.Text = "Валюта";
            // 
            // textAbbrev
            // 
            textAbbrev.Location = new Point(74, 6);
            textAbbrev.Name = "textAbbrev";
            textAbbrev.Size = new Size(37, 23);
            textAbbrev.TabIndex = 1;
            // 
            // RatesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(714, 558);
            Controls.Add(panel2);
            Controls.Add(panelFilter);
            Name = "RatesForm";
            Text = "Курсы валют";
            Load += RatesForm_Load;
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)c1SplitContainer1).EndInit();
            c1SplitContainer1.ResumeLayout(false);
            c1SplitterPanelRates.ResumeLayout(false);
            c1SplitterPanelRates.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridRates).EndInit();
            toolStripRates.ResumeLayout(false);
            toolStripRates.PerformLayout();
            c1SplitterPanelCurrencies.ResumeLayout(false);
            c1SplitterPanelCurrencies.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridCurrencies).EndInit();
            toolStripCurrencies.ResumeLayout(false);
            toolStripCurrencies.PerformLayout();
            panelFilter.ResumeLayout(false);
            panelFilter.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel2;
        private C1.Win.SplitContainer.C1SplitContainer c1SplitContainer1;
        private C1.Win.SplitContainer.C1SplitterPanel c1SplitterPanelRates;
        private C1.Win.SplitContainer.C1SplitterPanel c1SplitterPanelCurrencies;
        private ToolStrip toolStripRates;
        private ToolStripButton toolStripButtonNew;
        private ToolStripButton toolStripButtonDouble;
        private ToolStripButton toolStripButtonEdit;
        private ToolStripButton toolStripButtonDelete;
        private ToolStripButton toolStripButtonRefreshRates;
        private ToolStripSeparator toolStripSeparator1;
        private Panel panelFilter;
        private CheckBox checkIncludeInvisible;
        private Label labelAbbrev;
        private TextBox textAbbrev;
        private Label labelDateRates;
        private DateTimePicker dateTimePickerDateRates;
        private ToolStrip toolStripCurrencies;
        private ToolStripButton toolStripButton1;
        private ToolStripButton toolStripButton2;
        private ToolStripButton toolStripButton3;
        private ToolStripButton toolStripButton4;
        private ToolStripButton toolStripButtonCurrencies;
        private ToolStripSeparator toolStripSeparator2;
        private SmartLib.SmartGrid gridRates;
        private SmartLib.SmartGrid gridCurrencies;
    }
}