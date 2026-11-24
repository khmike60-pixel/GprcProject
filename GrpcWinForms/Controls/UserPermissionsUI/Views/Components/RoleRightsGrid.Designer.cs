namespace GrpcWinForms.Controls.UserPermissionsUI.Views.Components
{
    partial class RoleRightsGrid
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RoleRightsGrid));
            C1.Win.FlexGrid.FooterDescription footerDescription1 = new C1.Win.FlexGrid.FooterDescription();
            C1.Win.FlexGrid.AggregateDefinition aggregateDefinition1 = new C1.Win.FlexGrid.AggregateDefinition();
            toolStrip1 = new ToolStrip();
            AddObjectRight = new ToolStripButton();
            DeleteObjectRight = new ToolStripButton();
            RefreshRightObjects = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            _rightsGrid = new SmartLib.SmartGrid(components);
            _rightValuesCombo = new C1.Win.Input.C1ComboBox();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_rightsGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_rightValuesCombo).BeginInit();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(24, 24);
            toolStrip1.Items.AddRange(new ToolStripItem[] { AddObjectRight, DeleteObjectRight, RefreshRightObjects, toolStripSeparator1 });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(596, 31);
            toolStrip1.TabIndex = 5;
            toolStrip1.Text = "toolStrip1";
            // 
            // AddObjectRight
            // 
            AddObjectRight.DisplayStyle = ToolStripItemDisplayStyle.Image;
            AddObjectRight.Image = Properties.Resources.icons8_документ_50;
            AddObjectRight.ImageTransparentColor = Color.Magenta;
            AddObjectRight.Name = "AddObjectRight";
            AddObjectRight.Size = new Size(28, 28);
            AddObjectRight.Tag = "{\"name\": \"LocalRightObjects\"}";
            AddObjectRight.Text = "Новый";
            // 
            // DeleteObjectRight
            // 
            DeleteObjectRight.DisplayStyle = ToolStripItemDisplayStyle.Image;
            DeleteObjectRight.Image = Properties.Resources.icons8_удалить_файл_50;
            DeleteObjectRight.ImageTransparentColor = Color.Magenta;
            DeleteObjectRight.Name = "DeleteObjectRight";
            DeleteObjectRight.Size = new Size(28, 28);
            DeleteObjectRight.Tag = "{\"name\": \"LocalRightObjects\"}";
            DeleteObjectRight.Text = "Удалить";
            // 
            // RefreshRightObjects
            // 
            RefreshRightObjects.Alignment = ToolStripItemAlignment.Right;
            RefreshRightObjects.Image = Properties.Resources.icons8_refresh_50;
            RefreshRightObjects.ImageTransparentColor = Color.Magenta;
            RefreshRightObjects.Name = "RefreshRightObjects";
            RefreshRightObjects.Size = new Size(89, 28);
            RefreshRightObjects.Text = "Обновить";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 31);
            // 
            // _rightsGrid
            // 
            _rightsGrid.AllowMerging = C1.Win.FlexGrid.AllowMergingEnum.FixedOnly;
            _rightsGrid.AllowMergingFixed = C1.Win.FlexGrid.AllowMergingEnum.FixedOnly;
            _rightsGrid.AllowNodeMove = false;
            _rightsGrid.ColumnInfo = resources.GetString("_rightsGrid.ColumnInfo");
            _rightsGrid.Dock = DockStyle.Fill;
            _rightsGrid.DrawMode = C1.Win.FlexGrid.DrawModeEnum.OwnerDraw;
            aggregateDefinition1.Caption = "Всего: ";
            aggregateDefinition1.Column = 1;
            footerDescription1.Aggregates.Add(aggregateDefinition1);
            _rightsGrid.Footers.Descriptions.Add(footerDescription1);
            _rightsGrid.Footers.Fixed = true;
            _rightsGrid.IdName = null;
            _rightsGrid.Location = new Point(0, 31);
            _rightsGrid.Name = "_rightsGrid";
            _rightsGrid.Rows.Count = 51;
            _rightsGrid.SelectedRows = (List<int>)resources.GetObject("_rightsGrid.SelectedRows");
            _rightsGrid.SelectionMode = C1.Win.FlexGrid.SelectionModeEnum.Row;
            _rightsGrid.Size = new Size(596, 289);
            _rightsGrid.SortingType = SmartLib.SortingType.Descending;
            _rightsGrid.StyleInfo = resources.GetString("_rightsGrid.StyleInfo");
            _rightsGrid.TabIndex = 6;
            // 
            // _rightValuesCombo
            // 
            _rightValuesCombo.Location = new Point(269, 84);
            _rightValuesCombo.Name = "_rightValuesCombo";
            _rightValuesCombo.Size = new Size(100, 23);
            _rightValuesCombo.TabIndex = 7;
            _rightValuesCombo.Value = "";
            // 
            // RoleRightsGrid
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(_rightValuesCombo);
            Controls.Add(_rightsGrid);
            Controls.Add(toolStrip1);
            Name = "RoleRightsGrid";
            Size = new Size(596, 320);
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_rightsGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)_rightValuesCombo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripButton AddObjectRight;
        private ToolStripButton DeleteObjectRight;
        private ToolStripButton RefreshRightObjects;
        private ToolStripSeparator toolStripSeparator1;
        private SmartLib.SmartGrid _rightsGrid;
        private C1.Win.Input.C1ComboBox _rightValuesCombo;
    }
}
