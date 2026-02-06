namespace GrpcWinForms.Objects.Contracts.Controls
{
    partial class PropertiesControl
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            C1.Win.FlexGrid.FooterDescription footerDescription1 = new C1.Win.FlexGrid.FooterDescription();
            C1.Win.FlexGrid.AggregateDefinition aggregateDefinition1 = new C1.Win.FlexGrid.AggregateDefinition();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PropertiesControl));
            smartGridProperies = new SmartGrid.SmartGrid();
            c1CommandHolder1 = new C1.Win.Command.C1CommandHolder();
            c1Command1 = new C1.Win.Command.C1CommandControl();
            toolStripProperties = new ToolStrip();
            toolStripButtonNew = new ToolStripButton();
            toolStripButtonDouble = new ToolStripButton();
            toolStripButtonEdit = new ToolStripButton();
            toolStripButtonDelete = new ToolStripButton();
            toolStripButtonRefresh = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            ((System.ComponentModel.ISupportInitialize)smartGridProperies).BeginInit();
            ((System.ComponentModel.ISupportInitialize)c1CommandHolder1).BeginInit();
            toolStripProperties.SuspendLayout();
            SuspendLayout();
            // 
            // smartGridProperies
            // 
            smartGridProperies.AllowMergingFixed = C1.Win.FlexGrid.AllowMergingEnum.None;
            smartGridProperies.AllowNodeMove = false;
            smartGridProperies.ColumnInfo = "3,1,0,0,0,-1,Columns:0{Width:30;}\t1{Width:370;StarWidth:\"*\";Caption:\"Наименование свойста\";AllowEditing:False;}\t2{Width:370;StarWidth:\"*\";Caption:\"Значение\";}\t";
            smartGridProperies.Dock = DockStyle.Fill;
            smartGridProperies.DrawMode = C1.Win.FlexGrid.DrawModeEnum.OwnerDraw;
            footerDescription1.Aggregates.Add(aggregateDefinition1);
            smartGridProperies.Footers.Descriptions.Add(footerDescription1);
            smartGridProperies.Footers.Fixed = true;
            smartGridProperies.Headers = null;
            smartGridProperies.IdName = null;
            smartGridProperies.IsEditing = false;
            smartGridProperies.Location = new Point(0, 31);
            smartGridProperies.Name = "smartGridProperies";
            smartGridProperies.Rows.Count = 4;
            smartGridProperies.SelectedRows = (List<int>)resources.GetObject("smartGridProperies.SelectedRows");
            smartGridProperies.SelectionMode = C1.Win.FlexGrid.SelectionModeEnum.Row;
            smartGridProperies.Size = new Size(772, 254);
            smartGridProperies.SortingType = SmartGrid.SortingType.Descending;
            smartGridProperies.StyleInfo = resources.GetString("smartGridProperies.StyleInfo");
            smartGridProperies.TabIndex = 0;
            // 
            // c1CommandHolder1
            // 
            c1CommandHolder1.Commands.Add(c1Command1);
            c1CommandHolder1.Owner = this;
            // 
            // c1Command1
            // 
            c1Command1.Name = "c1Command1";
            c1Command1.ShortcutText = "";
            c1Command1.Text = "New Command";
            // 
            // toolStripProperties
            // 
            toolStripProperties.ImageScalingSize = new Size(24, 24);
            toolStripProperties.Items.AddRange(new ToolStripItem[] { toolStripButtonNew, toolStripButtonDouble, toolStripButtonEdit, toolStripButtonDelete, toolStripButtonRefresh, toolStripSeparator1 });
            toolStripProperties.Location = new Point(0, 0);
            toolStripProperties.Name = "toolStripProperties";
            toolStripProperties.Size = new Size(772, 31);
            toolStripProperties.TabIndex = 1;
            toolStripProperties.Text = "toolStrip1";
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
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 31);
            // 
            // PropertiesControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(smartGridProperies);
            Controls.Add(toolStripProperties);
            Name = "PropertiesControl";
            Size = new Size(772, 285);
            ((System.ComponentModel.ISupportInitialize)smartGridProperies).EndInit();
            ((System.ComponentModel.ISupportInitialize)c1CommandHolder1).EndInit();
            toolStripProperties.ResumeLayout(false);
            toolStripProperties.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private C1.Win.Command.C1CommandHolder c1CommandHolder1;
        private C1.Win.Command.C1CommandControl c1Command1;
        private ToolStrip toolStripProperties;
        private ToolStripButton toolStripButtonNew;
        private ToolStripButton toolStripButtonDouble;
        private ToolStripButton toolStripButtonEdit;
        private ToolStripButton toolStripButtonDelete;
        private ToolStripButton toolStripButtonRefresh;
        private ToolStripSeparator toolStripSeparator1;
        public SmartGrid.SmartGrid smartGridProperies;
    }
}
