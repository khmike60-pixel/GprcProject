namespace GrpcWinForms.Objects.DocumentTypes.Forms
{
    partial class DocumentTypesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DocumentTypesForm));
            C1.Win.FlexGrid.FooterDescription footerDescription1 = new C1.Win.FlexGrid.FooterDescription();
            panel1 = new Panel();
            textBoxContractTypeName = new TextBox();
            labelName = new Label();
            panel2 = new Panel();
            smartGridDocumentTypes = new SmartGrid.SmartGrid();
            toolStrip1 = new ToolStrip();
            toolStripButtonNew = new ToolStripButton();
            toolStripButtonDouble = new ToolStripButton();
            toolStripButtonEdit = new ToolStripButton();
            toolStripButtonDelete = new ToolStripButton();
            toolStripButtonRefresh = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripButtonLevels = new ToolStripSplitButton();
            toolStripButtonPath = new ToolStripButton();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)smartGridDocumentTypes).BeginInit();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(textBoxContractTypeName);
            panel1.Controls.Add(labelName);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 34);
            panel1.TabIndex = 1;
            // 
            // textBoxContractTypeName
            // 
            textBoxContractTypeName.Location = new Point(117, 5);
            textBoxContractTypeName.Name = "textBoxContractTypeName";
            textBoxContractTypeName.Size = new Size(127, 23);
            textBoxContractTypeName.TabIndex = 1;
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
            // panel2
            // 
            panel2.Controls.Add(smartGridDocumentTypes);
            panel2.Controls.Add(toolStrip1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 34);
            panel2.Name = "panel2";
            panel2.Size = new Size(800, 416);
            panel2.TabIndex = 2;
            // 
            // smartGridDocumentTypes
            // 
            smartGridDocumentTypes.AllowEditing = false;
            smartGridDocumentTypes.AllowMergingFixed = C1.Win.FlexGrid.AllowMergingEnum.FixedOnly;
            smartGridDocumentTypes.AllowNodeMove = false;
            smartGridDocumentTypes.AllowSorting = C1.Win.FlexGrid.AllowSortingEnum.None;
            smartGridDocumentTypes.AutoGenerateColumns = false;
            smartGridDocumentTypes.ColumnInfo = resources.GetString("smartGridDocumentTypes.ColumnInfo");
            smartGridDocumentTypes.Dock = DockStyle.Fill;
            smartGridDocumentTypes.DrawMode = C1.Win.FlexGrid.DrawModeEnum.OwnerDraw;
            smartGridDocumentTypes.Footers.Descriptions.Add(footerDescription1);
            smartGridDocumentTypes.Footers.Fixed = true;
            smartGridDocumentTypes.Headers = new string[]
    {
    "...\tНаименование\tКод\tВышестояшие\tId"
    };
            smartGridDocumentTypes.IdName = null;
            smartGridDocumentTypes.IsEditing = false;
            smartGridDocumentTypes.Location = new Point(0, 31);
            smartGridDocumentTypes.Name = "smartGridDocumentTypes";
            smartGridDocumentTypes.Rows.Count = 4;
            smartGridDocumentTypes.SelectedRows = (List<int>)resources.GetObject("smartGridDocumentTypes.SelectedRows");
            smartGridDocumentTypes.SelectionMode = C1.Win.FlexGrid.SelectionModeEnum.Row;
            smartGridDocumentTypes.Size = new Size(800, 385);
            smartGridDocumentTypes.SortingType = SmartGrid.SortingType.Descending;
            smartGridDocumentTypes.StyleInfo = resources.GetString("smartGridDocumentTypes.StyleInfo");
            smartGridDocumentTypes.TabIndex = 2;
            smartGridDocumentTypes.Tree.Column = 3;
            smartGridDocumentTypes.DoubleClick += smartGridDocumentTypes_DoubleClick;
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(24, 24);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripButtonNew, toolStripButtonDouble, toolStripButtonEdit, toolStripButtonDelete, toolStripButtonRefresh, toolStripSeparator1, toolStripButtonLevels, toolStripButtonPath });
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
            toolStripButtonEdit.Click += toolStripButtonEdit_Click;
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
            // 
            // DocumentTypesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "DocumentTypesForm";
            Text = "Типы документов";
            Load += ContractTypesForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)smartGridDocumentTypes).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TextBox textBoxContractTypeName;
        private Label labelName;
        private Panel panel2;
        private ToolStrip toolStrip1;
        private ToolStripButton toolStripButtonNew;
        private ToolStripButton toolStripButtonDouble;
        private ToolStripButton toolStripButtonEdit;
        private ToolStripButton toolStripButtonDelete;
        private ToolStripButton toolStripButtonRefresh;
        private ToolStripSeparator toolStripSeparator1;
        public SmartGrid.SmartGrid smartGridDocumentTypes;
        private ToolStripSplitButton toolStripButtonLevels;
        private ToolStripButton toolStripButtonPath;
    }
}