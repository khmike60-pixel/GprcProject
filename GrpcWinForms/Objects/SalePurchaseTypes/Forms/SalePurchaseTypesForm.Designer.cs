namespace GrpcWinForms.Objects.SalePurchaseTypes.Forms
{
    partial class SalePurchaseTypesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SalePurchaseTypesForm));
            C1.Win.FlexGrid.FooterDescription footerDescription1 = new C1.Win.FlexGrid.FooterDescription();
            C1.Win.FlexGrid.AggregateDefinition aggregateDefinition1 = new C1.Win.FlexGrid.AggregateDefinition();
            SmartLib.StringItem stringItem1 = new SmartLib.StringItem();
            SmartLib.StringItem stringItem2 = new SmartLib.StringItem();
            smartGridSalePurchase = new SmartLib.SmartGrid(components);
            toolStrip1 = new ToolStrip();
            toolStripButtonNew = new ToolStripButton();
            toolStripButtonDouble = new ToolStripButton();
            toolStripButtonEdit = new ToolStripButton();
            toolStripButtonDelete = new ToolStripButton();
            toolStripButtonRefresh = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            panel1 = new Panel();
            checkIncludeInvisible = new CheckBox();
            labelAbbrev = new Label();
            textAbbrev = new TextBox();
            c1SplitContainer1 = new C1.Win.SplitContainer.C1SplitContainer();
            c1SplitterPanel2 = new C1.Win.SplitContainer.C1SplitterPanel();
            c1SplitterPanel1 = new C1.Win.SplitContainer.C1SplitterPanel();
            toolStrip2 = new ToolStrip();
            toolStripButton2 = new ToolStripButton();
            toolStripButton3 = new ToolStripButton();
            toolStripButton4 = new ToolStripButton();
            toolStripButton5 = new ToolStripButton();
            toolStripButton6 = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            smartGridRates = new SmartLib.SmartGrid(components);
            ((System.ComponentModel.ISupportInitialize)smartGridSalePurchase).BeginInit();
            toolStrip1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)c1SplitContainer1).BeginInit();
            c1SplitContainer1.SuspendLayout();
            c1SplitterPanel2.SuspendLayout();
            c1SplitterPanel1.SuspendLayout();
            toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)smartGridRates).BeginInit();
            SuspendLayout();
            // 
            // smartGridSalePurchase
            // 
            smartGridSalePurchase.AllowEditing = false;
            smartGridSalePurchase.AllowMerging = C1.Win.FlexGrid.AllowMergingEnum.FixedOnly;
            smartGridSalePurchase.AllowMergingFixed = C1.Win.FlexGrid.AllowMergingEnum.FixedOnly;
            smartGridSalePurchase.AllowNodeMove = false;
            smartGridSalePurchase.AutoGenerateColumns = false;
            smartGridSalePurchase.ColumnInfo = resources.GetString("smartGridSalePurchase.ColumnInfo");
            smartGridSalePurchase.Dock = DockStyle.Fill;
            smartGridSalePurchase.DrawMode = C1.Win.FlexGrid.DrawModeEnum.OwnerDraw;
            aggregateDefinition1.Aggregate = C1.Win.FlexGrid.AggregateEnum.Count;
            aggregateDefinition1.Caption = "Всего: ";
            aggregateDefinition1.Column = 4;
            footerDescription1.Aggregates.Add(aggregateDefinition1);
            smartGridSalePurchase.Footers.Descriptions.Add(footerDescription1);
            smartGridSalePurchase.Footers.Fixed = true;
            stringItem1.Name = "Заголовок 1";
            stringItem1.Value = "...;Id; ;Наименование;Страна;Используемые валюты;Используемые валюты;Используемые валюты";
            stringItem2.Name = "Заголовок  2";
            stringItem2.Value = "...;Id; ;Наименование;Страна;Базовая;Выдача;Кросс-курс";
            smartGridSalePurchase.Headers.Add(stringItem1);
            smartGridSalePurchase.Headers.Add(stringItem2);
            smartGridSalePurchase.IdName = null;
            smartGridSalePurchase.Location = new Point(0, 31);
            smartGridSalePurchase.Name = "smartGridSalePurchase";
            smartGridSalePurchase.Rows.Count = 5;
            smartGridSalePurchase.Rows.Fixed = 2;
            smartGridSalePurchase.SelectedRows = (List<int>)resources.GetObject("smartGridSalePurchase.SelectedRows");
            smartGridSalePurchase.SelectionMode = C1.Win.FlexGrid.SelectionModeEnum.Row;
            smartGridSalePurchase.Size = new Size(470, 364);
            smartGridSalePurchase.SortingType = SmartLib.SortingType.Descending;
            smartGridSalePurchase.StyleInfo = resources.GetString("smartGridSalePurchase.StyleInfo");
            smartGridSalePurchase.TabIndex = 3;
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(24, 24);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripButtonNew, toolStripButtonDouble, toolStripButtonEdit, toolStripButtonDelete, toolStripButtonRefresh, toolStripSeparator1 });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(470, 31);
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
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 31);
            // 
            // panel1
            // 
            panel1.Controls.Add(checkIncludeInvisible);
            panel1.Controls.Add(labelAbbrev);
            panel1.Controls.Add(textAbbrev);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(754, 34);
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
            // c1SplitContainer1
            // 
            c1SplitContainer1.AutoSizeElement = C1.Framework.AutoSizeElement.Both;
            c1SplitContainer1.Dock = DockStyle.Fill;
            c1SplitContainer1.HeaderButtonBackColor = Color.Transparent;
            c1SplitContainer1.Location = new Point(0, 34);
            c1SplitContainer1.Name = "c1SplitContainer1";
            c1SplitContainer1.Panels.Add(c1SplitterPanel2);
            c1SplitContainer1.Panels.Add(c1SplitterPanel1);
            c1SplitContainer1.Size = new Size(754, 416);
            c1SplitContainer1.TabIndex = 4;
            // 
            // c1SplitterPanel2
            // 
            c1SplitterPanel2.Collapsible = true;
            c1SplitterPanel2.Controls.Add(smartGridRates);
            c1SplitterPanel2.Controls.Add(toolStrip2);
            c1SplitterPanel2.Dock = C1.Win.SplitContainer.PanelDockStyle.Right;
            c1SplitterPanel2.Height = 416;
            c1SplitterPanel2.Location = new Point(481, 21);
            c1SplitterPanel2.Name = "c1SplitterPanel2";
            c1SplitterPanel2.Size = new Size(273, 395);
            c1SplitterPanel2.SizeRatio = 37.398D;
            c1SplitterPanel2.TabIndex = 1;
            c1SplitterPanel2.Text = "Валюты и курсы";
            c1SplitterPanel2.Width = 280;
            // 
            // c1SplitterPanel1
            // 
            c1SplitterPanel1.Collapsible = true;
            c1SplitterPanel1.Controls.Add(smartGridSalePurchase);
            c1SplitterPanel1.Controls.Add(toolStrip1);
            c1SplitterPanel1.Dock = C1.Win.SplitContainer.PanelDockStyle.Left;
            c1SplitterPanel1.Location = new Point(0, 21);
            c1SplitterPanel1.Name = "c1SplitterPanel1";
            c1SplitterPanel1.Size = new Size(470, 395);
            c1SplitterPanel1.SizeRatio = 34.602D;
            c1SplitterPanel1.TabIndex = 0;
            c1SplitterPanel1.Text = "Типы продаж (покупок)";
            c1SplitterPanel1.Width = 470;
            // 
            // toolStrip2
            // 
            toolStrip2.ImageScalingSize = new Size(24, 24);
            toolStrip2.Items.AddRange(new ToolStripItem[] { toolStripButton2, toolStripButton3, toolStripButton4, toolStripButton5, toolStripButton6, toolStripSeparator2 });
            toolStrip2.Location = new Point(0, 0);
            toolStrip2.Name = "toolStrip2";
            toolStrip2.Size = new Size(273, 31);
            toolStrip2.TabIndex = 1;
            toolStrip2.Text = "toolStrip2";
            // 
            // toolStripButton2
            // 
            toolStripButton2.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton2.Image = Properties.Resources.icons8_документ_50;
            toolStripButton2.ImageTransparentColor = Color.Magenta;
            toolStripButton2.Name = "toolStripButton2";
            toolStripButton2.Size = new Size(28, 28);
            toolStripButton2.Text = "Новый";
            // 
            // toolStripButton3
            // 
            toolStripButton3.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton3.Enabled = false;
            toolStripButton3.Image = Properties.Resources.icons8_скопировать_50;
            toolStripButton3.ImageTransparentColor = Color.Magenta;
            toolStripButton3.Name = "toolStripButton3";
            toolStripButton3.Size = new Size(28, 28);
            toolStripButton3.Text = "Дублировать";
            // 
            // toolStripButton4
            // 
            toolStripButton4.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton4.Image = Properties.Resources.icons8_редактирование_файла_50;
            toolStripButton4.ImageTransparentColor = Color.Magenta;
            toolStripButton4.Name = "toolStripButton4";
            toolStripButton4.Size = new Size(28, 28);
            toolStripButton4.Text = "Редактировать";
            // 
            // toolStripButton5
            // 
            toolStripButton5.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton5.Image = Properties.Resources.icons8_удалить_файл_50;
            toolStripButton5.ImageTransparentColor = Color.Magenta;
            toolStripButton5.Name = "toolStripButton5";
            toolStripButton5.Size = new Size(28, 28);
            toolStripButton5.Text = "Удалить";
            // 
            // toolStripButton6
            // 
            toolStripButton6.Alignment = ToolStripItemAlignment.Right;
            toolStripButton6.Image = Properties.Resources.icons8_refresh_50;
            toolStripButton6.ImageTransparentColor = Color.Magenta;
            toolStripButton6.Name = "toolStripButton6";
            toolStripButton6.Size = new Size(89, 28);
            toolStripButton6.Text = "Обновить";
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 31);
            // 
            // smartGridRates
            // 
            smartGridRates.AllowMerging = C1.Win.FlexGrid.AllowMergingEnum.FixedOnly;
            smartGridRates.AllowMergingFixed = C1.Win.FlexGrid.AllowMergingEnum.FixedOnly;
            smartGridRates.AllowNodeMove = false;
            smartGridRates.ColumnInfo = resources.GetString("smartGridRates.ColumnInfo");
            smartGridRates.Dock = DockStyle.Fill;
            smartGridRates.DrawMode = C1.Win.FlexGrid.DrawModeEnum.OwnerDraw;
            smartGridRates.IdName = null;
            smartGridRates.Location = new Point(0, 31);
            smartGridRates.Name = "smartGridRates";
            smartGridRates.Rows.Count = 5;
            smartGridRates.SelectedRows = (List<int>)resources.GetObject("smartGridRates.SelectedRows");
            smartGridRates.SelectionMode = C1.Win.FlexGrid.SelectionModeEnum.Row;
            smartGridRates.Size = new Size(273, 364);
            smartGridRates.SortingType = SmartLib.SortingType.Descending;
            smartGridRates.StyleInfo = resources.GetString("smartGridRates.StyleInfo");
            smartGridRates.TabIndex = 2;
            // 
            // SalePurchaseTypesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(754, 450);
            Controls.Add(c1SplitContainer1);
            Controls.Add(panel1);
            Name = "SalePurchaseTypesForm";
            Text = "Типы  продаж (покупок)";
            ((System.ComponentModel.ISupportInitialize)smartGridSalePurchase).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)c1SplitContainer1).EndInit();
            c1SplitContainer1.ResumeLayout(false);
            c1SplitterPanel2.ResumeLayout(false);
            c1SplitterPanel2.PerformLayout();
            c1SplitterPanel1.ResumeLayout(false);
            c1SplitterPanel1.PerformLayout();
            toolStrip2.ResumeLayout(false);
            toolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)smartGridRates).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private SmartLib.SmartGrid smartGridSalePurchase;
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
        private C1.Win.SplitContainer.C1SplitContainer c1SplitContainer1;
        private C1.Win.SplitContainer.C1SplitterPanel c1SplitterPanel1;
        private C1.Win.SplitContainer.C1SplitterPanel c1SplitterPanel2;
        private SmartLib.SmartGrid smartGridRates;
        private ToolStrip toolStrip2;
        private ToolStripButton toolStripButton2;
        private ToolStripButton toolStripButton3;
        private ToolStripButton toolStripButton4;
        private ToolStripButton toolStripButton5;
        private ToolStripButton toolStripButton6;
        private ToolStripSeparator toolStripSeparator2;
    }
}