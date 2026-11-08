namespace GrpcWinForms.Objects.Locations.Views
{
    partial class LocationsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LocationsForm));
            C1.Win.FlexGrid.FooterDescription footerDescription1 = new C1.Win.FlexGrid.FooterDescription();
            C1.Win.FlexGrid.AggregateDefinition aggregateDefinition1 = new C1.Win.FlexGrid.AggregateDefinition();
            C1.Win.Input.ComboBoxItem comboBoxItem1 = new C1.Win.Input.ComboBoxItem();
            C1.Win.Input.ComboBoxItem comboBoxItem2 = new C1.Win.Input.ComboBoxItem();
            C1.Win.Input.ComboBoxItem comboBoxItem3 = new C1.Win.Input.ComboBoxItem();
            panel2 = new Panel();
            grid = new SmartLib.SmartGrid(components);
            toolStrip1 = new ToolStrip();
            btnNew = new ToolStripButton();
            btnDouble = new ToolStripButton();
            btnEdit = new ToolStripButton();
            btnDelete = new ToolStripButton();
            btnRefresh = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            btnLevels = new ToolStripSplitButton();
            btnPath = new ToolStripButton();
            panel1 = new Panel();
            lType = new C1.Win.Input.C1Label();
            cbType = new C1.Win.Input.C1ComboBox();
            txtName = new TextBox();
            labelName = new Label();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grid).BeginInit();
            toolStrip1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)lType).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cbType).BeginInit();
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
            panel2.TabIndex = 5;
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
            grid.Tree.Column = 2;
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(24, 24);
            toolStrip1.Items.AddRange(new ToolStripItem[] { btnNew, btnDouble, btnEdit, btnDelete, btnRefresh, toolStripSeparator1, btnLevels, btnPath });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(800, 31);
            toolStrip1.TabIndex = 1;
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
            btnDouble.Click += btnDouble_Click;
            // 
            // btnEdit
            // 
            btnEdit.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnEdit.Image = Properties.Resources.icons8_редактирование_файла_50;
            btnEdit.ImageTransparentColor = Color.Magenta;
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(28, 28);
            btnEdit.Text = "Редактировать";
            btnEdit.Click += btnEdit_Click;
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
            // btnLevels
            // 
            btnLevels.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnLevels.Image = Properties.Resources.icons8_дерево_папок_40;
            btnLevels.ImageTransparentColor = Color.Magenta;
            btnLevels.Name = "btnLevels";
            btnLevels.Size = new Size(40, 28);
            btnLevels.Text = "Уровень группировок";
            // 
            // btnPath
            // 
            btnPath.CheckOnClick = true;
            btnPath.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnPath.Image = Properties.Resources.icons8_древовидная_структура_50;
            btnPath.ImageTransparentColor = Color.Magenta;
            btnPath.Name = "btnPath";
            btnPath.Size = new Size(28, 28);
            btnPath.Text = "toolStripButton1";
            btnPath.Click += btnPath_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(lType);
            panel1.Controls.Add(cbType);
            panel1.Controls.Add(txtName);
            panel1.Controls.Add(labelName);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 34);
            panel1.TabIndex = 4;
            // 
            // lType
            // 
            lType.AutoSize = true;
            lType.Location = new Point(250, 5);
            lType.Name = "lType";
            lType.Size = new Size(36, 21);
            lType.TabIndex = 2;
            lType.Text = "Тип:";
            // 
            // cbType
            // 
            comboBoxItem1.DisplayText = "Страны";
            comboBoxItem1.Value = "0";
            comboBoxItem2.DisplayText = "Регионы и города";
            comboBoxItem2.Value = "1";
            comboBoxItem3.DisplayText = "Места размещения";
            comboBoxItem3.Value = "2";
            cbType.Items.Add(comboBoxItem1);
            cbType.Items.Add(comboBoxItem2);
            cbType.Items.Add(comboBoxItem3);
            cbType.Location = new Point(292, 5);
            cbType.Name = "cbType";
            cbType.Size = new Size(166, 23);
            cbType.TabIndex = 3;
            cbType.Value = "0";
            // 
            // txtName
            // 
            txtName.Location = new Point(117, 5);
            txtName.Name = "txtName";
            txtName.Size = new Size(127, 23);
            txtName.TabIndex = 1;
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
            // LocationsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "LocationsForm";
            Text = "Страны, регионы,  города  и места  размещения";
            Load += LocationsForm_Load;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)grid).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)lType).EndInit();
            ((System.ComponentModel.ISupportInitialize)cbType).EndInit();
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
        private ToolStripSplitButton btnLevels;
        private ToolStripButton btnPath;
        private Panel panel1;
        private C1.Win.Input.C1Label lType;
        private C1.Win.Input.C1ComboBox cbType;
        private TextBox txtName;
        private Label labelName;
    }
}