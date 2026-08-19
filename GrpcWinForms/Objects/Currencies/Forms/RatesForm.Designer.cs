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
            C1.Win.FlexGrid.FooterDescription footerDescription1 = new C1.Win.FlexGrid.FooterDescription();
            C1.Win.FlexGrid.AggregateDefinition aggregateDefinition1 = new C1.Win.FlexGrid.AggregateDefinition();
            C1.Win.FlexGrid.FooterDescription footerDescription2 = new C1.Win.FlexGrid.FooterDescription();
            C1.Win.FlexGrid.AggregateDefinition aggregateDefinition2 = new C1.Win.FlexGrid.AggregateDefinition();
            panel2 = new Panel();
            c1SplitContainer1 = new C1.Win.SplitContainer.C1SplitContainer();
            c1SplitterPanelRates = new C1.Win.SplitContainer.C1SplitterPanel();
            smartGridRates1 = new SmartLib.SmartGrid(components);
            toolStripRates = new ToolStrip();
            toolStripButtonNew = new ToolStripButton();
            toolStripButtonDouble = new ToolStripButton();
            toolStripButtonEdit = new ToolStripButton();
            toolStripButtonDelete = new ToolStripButton();
            toolStripButtonRefreshRates = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            c1SplitterPanelCurrencies = new C1.Win.SplitContainer.C1SplitterPanel();
            smartGrid1 = new SmartLib.SmartGrid(components);
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
            ((System.ComponentModel.ISupportInitialize)smartGridRates1).BeginInit();
            toolStripRates.SuspendLayout();
            c1SplitterPanelCurrencies.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)smartGrid1).BeginInit();
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
            c1SplitterPanelRates.Controls.Add(smartGridRates1);
            c1SplitterPanelRates.Controls.Add(toolStripRates);
            c1SplitterPanelRates.Dock = C1.Win.SplitContainer.PanelDockStyle.Right;
            c1SplitterPanelRates.Location = new Point(445, 0);
            c1SplitterPanelRates.Name = "c1SplitterPanelRates";
            c1SplitterPanelRates.Size = new Size(269, 524);
            c1SplitterPanelRates.SizeRatio = 38.911D;
            c1SplitterPanelRates.TabIndex = 0;
            c1SplitterPanelRates.Width = 276;
            // 
            // smartGridRates1
            // 
            smartGridRates1.AllowEditing = false;
            smartGridRates1.AllowMerging = C1.Win.FlexGrid.AllowMergingEnum.FixedOnly;
            smartGridRates1.AllowMergingFixed = C1.Win.FlexGrid.AllowMergingEnum.FixedOnly;
            smartGridRates1.AllowNodeMove = false;
            smartGridRates1.AutoGenerateColumns = false;
            smartGridRates1.ColumnInfo = resources.GetString("smartGridRates1.ColumnInfo");
            smartGridRates1.Dock = DockStyle.Fill;
            smartGridRates1.DrawMode = C1.Win.FlexGrid.DrawModeEnum.OwnerDraw;
            aggregateDefinition1.Aggregate = C1.Win.FlexGrid.AggregateEnum.Count;
            aggregateDefinition1.Caption = "Всего: ";
            aggregateDefinition1.Column = 2;
            footerDescription1.Aggregates.Add(aggregateDefinition1);
            smartGridRates1.Footers.Descriptions.Add(footerDescription1);
            smartGridRates1.Footers.Fixed = true;
            smartGridRates1.IdName = null;
            smartGridRates1.Location = new Point(0, 31);
            smartGridRates1.Name = "smartGridRates1";
            smartGridRates1.Rows.Count = 51;
            smartGridRates1.SelectedRows = (List<int>)resources.GetObject("smartGridRates1.SelectedRows");
            smartGridRates1.SelectionMode = C1.Win.FlexGrid.SelectionModeEnum.Row;
            smartGridRates1.Size = new Size(269, 493);
            smartGridRates1.SortingType = SmartLib.SortingType.Descending;
            smartGridRates1.StyleInfo = resources.GetString("smartGridRates1.StyleInfo");
            smartGridRates1.TabIndex = 2;
            smartGridRates1.AfterFreezeColumn += smartGridRates_AfterFreezeColumn;
            smartGridRates1.GetUnboundValue += smartGridRates_GetUnboundValue;
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
            c1SplitterPanelCurrencies.Controls.Add(smartGrid1);
            c1SplitterPanelCurrencies.Controls.Add(toolStripCurrencies);
            c1SplitterPanelCurrencies.Dock = C1.Win.SplitContainer.PanelDockStyle.Left;
            c1SplitterPanelCurrencies.Location = new Point(0, 0);
            c1SplitterPanelCurrencies.Name = "c1SplitterPanelCurrencies";
            c1SplitterPanelCurrencies.Size = new Size(434, 524);
            c1SplitterPanelCurrencies.TabIndex = 1;
            c1SplitterPanelCurrencies.Width = 434;
            // 
            // smartGrid1
            // 
            smartGrid1.AllowEditing = false;
            smartGrid1.AllowMerging = C1.Win.FlexGrid.AllowMergingEnum.FixedOnly;
            smartGrid1.AllowMergingFixed = C1.Win.FlexGrid.AllowMergingEnum.FixedOnly;
            smartGrid1.AllowNodeMove = false;
            smartGrid1.AutoGenerateColumns = false;
            smartGrid1.ColumnInfo = resources.GetString("smartGrid1.ColumnInfo");
            smartGrid1.Dock = DockStyle.Fill;
            smartGrid1.DrawMode = C1.Win.FlexGrid.DrawModeEnum.OwnerDraw;
            aggregateDefinition2.Aggregate = C1.Win.FlexGrid.AggregateEnum.Count;
            aggregateDefinition2.Caption = "Всего: ";
            aggregateDefinition2.Column = 3;
            footerDescription2.Aggregates.Add(aggregateDefinition2);
            smartGrid1.Footers.Descriptions.Add(footerDescription2);
            smartGrid1.Footers.Fixed = true;
            smartGrid1.IdName = null;
            smartGrid1.Location = new Point(0, 31);
            smartGrid1.Name = "smartGrid1";
            smartGrid1.Rows.Count = 51;
            smartGrid1.SelectedRows = (List<int>)resources.GetObject("smartGrid1.SelectedRows");
            smartGrid1.SelectionMode = C1.Win.FlexGrid.SelectionModeEnum.Row;
            smartGrid1.Size = new Size(434, 493);
            smartGrid1.SortingType = SmartLib.SortingType.Descending;
            smartGrid1.StyleInfo = resources.GetString("smartGrid1.StyleInfo");
            smartGrid1.TabIndex = 4;
            smartGrid1.AfterFreezeColumn += smartGrid_AfterFreezeColumn;
            smartGrid1.AfterSelChange += smartGrid_AfterSelChange;
            smartGrid1.GetUnboundValue += smartGrid_GetUnboundValue;
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
            ((System.ComponentModel.ISupportInitialize)smartGridRates1).EndInit();
            toolStripRates.ResumeLayout(false);
            toolStripRates.PerformLayout();
            c1SplitterPanelCurrencies.ResumeLayout(false);
            c1SplitterPanelCurrencies.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)smartGrid1).EndInit();
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
        private SmartLib.SmartGrid smartGridRates1;
        private SmartLib.SmartGrid smartGrid1;
    }
}