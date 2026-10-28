namespace GrpcWinForms.Objects.StockDocuments.Views
{
    partial class StockDocumentsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StockDocumentsForm));
            C1.Win.FlexGrid.FooterDescription footerDescription1 = new C1.Win.FlexGrid.FooterDescription();
            C1.Win.FlexGrid.AggregateDefinition aggregateDefinition1 = new C1.Win.FlexGrid.AggregateDefinition();
            SmartLib.StringItem stringItem1 = new SmartLib.StringItem();
            SmartLib.StringItem stringItem2 = new SmartLib.StringItem();
            panel2 = new Panel();
            gridStockOperation = new SmartLib.SmartGrid(components);
            toolStrip1 = new ToolStrip();
            NewToolStripButton = new ToolStripButton();
            DoubleToolStripButton = new ToolStripButton();
            EditToolStripButton = new ToolStripButton();
            DeleteToolStripButton = new ToolStripButton();
            RefreshToolStripButton = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            panel1 = new Panel();
            c1Label1 = new C1.Win.Input.C1Label();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridStockOperation).BeginInit();
            toolStrip1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)c1Label1).BeginInit();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.Controls.Add(gridStockOperation);
            panel2.Controls.Add(toolStrip1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 65);
            panel2.Name = "panel2";
            panel2.Size = new Size(1045, 438);
            panel2.TabIndex = 3;
            // 
            // gridStockOperation
            // 
            gridStockOperation.AllowEditing = false;
            gridStockOperation.AllowMerging = C1.Win.FlexGrid.AllowMergingEnum.FixedOnly;
            gridStockOperation.AllowMergingFixed = C1.Win.FlexGrid.AllowMergingEnum.FixedOnly;
            gridStockOperation.AllowNodeMove = false;
            gridStockOperation.AutoGenerateColumns = false;
            gridStockOperation.ColumnInfo = resources.GetString("gridStockOperation.ColumnInfo");
            gridStockOperation.Dock = DockStyle.Fill;
            gridStockOperation.DrawMode = C1.Win.FlexGrid.DrawModeEnum.OwnerDraw;
            aggregateDefinition1.Aggregate = C1.Win.FlexGrid.AggregateEnum.Count;
            aggregateDefinition1.Caption = "Всего: ";
            aggregateDefinition1.Column = 3;
            footerDescription1.Aggregates.Add(aggregateDefinition1);
            gridStockOperation.Footers.Descriptions.Add(footerDescription1);
            gridStockOperation.Footers.Fixed = true;
            stringItem1.Name = "Head2";
            stringItem1.Value = "...;Id;Статус;Номер;Дата;Тип;Грузоотправитель;Грузоотправитель;Грузополучатель;Грузополучатель;Сумма операции;Сумма операции;";
            stringItem2.Name = "Head1";
            stringItem2.Value = "...;Id;Статус;Номер;Дата;Тип;Контрагент;Склад;Контрагент;Склад;Приход;Расход;";
            gridStockOperation.Headers.Add(stringItem1);
            gridStockOperation.Headers.Add(stringItem2);
            gridStockOperation.IdName = null;
            gridStockOperation.Location = new Point(0, 31);
            gridStockOperation.Name = "gridStockOperation";
            gridStockOperation.Rows.Count = 5;
            gridStockOperation.Rows.Fixed = 2;
            gridStockOperation.SelectedRows = (List<int>)resources.GetObject("gridStockOperation.SelectedRows");
            gridStockOperation.SelectionMode = C1.Win.FlexGrid.SelectionModeEnum.Row;
            gridStockOperation.Size = new Size(1045, 407);
            gridStockOperation.SortingType = SmartLib.SortingType.Descending;
            gridStockOperation.StyleInfo = resources.GetString("gridStockOperation.StyleInfo");
            gridStockOperation.TabIndex = 3;
            gridStockOperation.BeforeResizeColumn += gridStockOperation_BeforeResizeColumn;
            gridStockOperation.AfterResizeColumn += gridStockOperation_AfterResizeColumn;
            gridStockOperation.ClientSizeChanged += gridStockOperation_ClientSizeChanged;
            gridStockOperation.Resize += gridStockOperation_Resize;
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(24, 24);
            toolStrip1.Items.AddRange(new ToolStripItem[] { NewToolStripButton, DoubleToolStripButton, EditToolStripButton, DeleteToolStripButton, RefreshToolStripButton, toolStripSeparator1 });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1045, 31);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // NewToolStripButton
            // 
            NewToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            NewToolStripButton.Image = Properties.Resources.icons8_документ_50;
            NewToolStripButton.ImageTransparentColor = Color.Magenta;
            NewToolStripButton.Name = "NewToolStripButton";
            NewToolStripButton.Size = new Size(28, 28);
            NewToolStripButton.Text = "Новый";
            // 
            // DoubleToolStripButton
            // 
            DoubleToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            DoubleToolStripButton.Enabled = false;
            DoubleToolStripButton.Image = Properties.Resources.icons8_скопировать_50;
            DoubleToolStripButton.ImageTransparentColor = Color.Magenta;
            DoubleToolStripButton.Name = "DoubleToolStripButton";
            DoubleToolStripButton.Size = new Size(28, 28);
            DoubleToolStripButton.Text = "Дублировать";
            // 
            // EditToolStripButton
            // 
            EditToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            EditToolStripButton.Image = Properties.Resources.icons8_редактирование_файла_50;
            EditToolStripButton.ImageTransparentColor = Color.Magenta;
            EditToolStripButton.Name = "EditToolStripButton";
            EditToolStripButton.Size = new Size(28, 28);
            EditToolStripButton.Text = "Редактировать";
            // 
            // DeleteToolStripButton
            // 
            DeleteToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            DeleteToolStripButton.Image = Properties.Resources.icons8_удалить_файл_50;
            DeleteToolStripButton.ImageTransparentColor = Color.Magenta;
            DeleteToolStripButton.Name = "DeleteToolStripButton";
            DeleteToolStripButton.Size = new Size(28, 28);
            DeleteToolStripButton.Text = "Удалить";
            // 
            // RefreshToolStripButton
            // 
            RefreshToolStripButton.Alignment = ToolStripItemAlignment.Right;
            RefreshToolStripButton.Image = Properties.Resources.icons8_refresh_50;
            RefreshToolStripButton.ImageTransparentColor = Color.Magenta;
            RefreshToolStripButton.Name = "RefreshToolStripButton";
            RefreshToolStripButton.Size = new Size(89, 28);
            RefreshToolStripButton.Text = "Обновить";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 31);
            // 
            // panel1
            // 
            panel1.Controls.Add(c1Label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1045, 65);
            panel1.TabIndex = 2;
            // 
            // c1Label1
            // 
            c1Label1.AutoSize = true;
            c1Label1.Location = new Point(21, 12);
            c1Label1.Name = "c1Label1";
            c1Label1.Size = new Size(58, 21);
            c1Label1.TabIndex = 1;
            c1Label1.Text = "Период:";
            // 
            // StockDocumentsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1045, 503);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "StockDocumentsForm";
            Text = "Складские  документы";
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridStockOperation).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)c1Label1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel2;
        private SmartLib.SmartGrid gridStockOperation;
        private ToolStrip toolStrip1;
        private ToolStripButton NewToolStripButton;
        private ToolStripButton DoubleToolStripButton;
        private ToolStripButton EditToolStripButton;
        private ToolStripButton DeleteToolStripButton;
        private ToolStripButton RefreshToolStripButton;
        private ToolStripSeparator toolStripSeparator1;
        private Panel panel1;
        private C1.Win.Input.C1Label c1Label1;
    }
}