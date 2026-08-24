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
            C1.Win.FlexGrid.AggregateDefinition aggregateDefinition1 = new C1.Win.FlexGrid.AggregateDefinition();
            panel1 = new Panel();
            textBoxContractTypeName = new TextBox();
            labelName = new Label();
            panel2 = new Panel();
            smartGridDocumentTypes1 = new SmartLib.SmartGrid(components);
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
            ((System.ComponentModel.ISupportInitialize)smartGridDocumentTypes1).BeginInit();
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
            panel2.Controls.Add(smartGridDocumentTypes1);
            panel2.Controls.Add(toolStrip1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 34);
            panel2.Name = "panel2";
            panel2.Size = new Size(800, 416);
            panel2.TabIndex = 2;
            // 
            // smartGridDocumentTypes1
            // 
            smartGridDocumentTypes1.AllowEditing = false;
            smartGridDocumentTypes1.AllowMerging = C1.Win.FlexGrid.AllowMergingEnum.FixedOnly;
            smartGridDocumentTypes1.AllowMergingFixed = C1.Win.FlexGrid.AllowMergingEnum.FixedOnly;
            smartGridDocumentTypes1.AllowNodeMove = false;
            smartGridDocumentTypes1.AutoGenerateColumns = false;
            smartGridDocumentTypes1.ColumnInfo = resources.GetString("smartGridDocumentTypes1.ColumnInfo");
            smartGridDocumentTypes1.Dock = DockStyle.Fill;
            smartGridDocumentTypes1.DrawMode = C1.Win.FlexGrid.DrawModeEnum.OwnerDraw;
            aggregateDefinition1.Aggregate = C1.Win.FlexGrid.AggregateEnum.Count;
            aggregateDefinition1.Caption = "Всего: ";
            aggregateDefinition1.Column = 1;
            footerDescription1.Aggregates.Add(aggregateDefinition1);
            smartGridDocumentTypes1.Footers.Descriptions.Add(footerDescription1);
            smartGridDocumentTypes1.Footers.Fixed = true;
            smartGridDocumentTypes1.IdName = null;
            smartGridDocumentTypes1.Location = new Point(0, 31);
            smartGridDocumentTypes1.Name = "smartGridDocumentTypes1";
            smartGridDocumentTypes1.Rows.Count = 51;
            smartGridDocumentTypes1.SelectedRows = (List<int>)resources.GetObject("smartGridDocumentTypes1.SelectedRows");
            smartGridDocumentTypes1.SelectionMode = C1.Win.FlexGrid.SelectionModeEnum.Row;
            smartGridDocumentTypes1.Size = new Size(800, 385);
            smartGridDocumentTypes1.SortingType = SmartLib.SortingType.Descending;
            smartGridDocumentTypes1.StyleInfo = resources.GetString("smartGridDocumentTypes1.StyleInfo");
            smartGridDocumentTypes1.TabIndex = 3;
            smartGridDocumentTypes1.Tree.Column = 1;
            smartGridDocumentTypes1.BeforeNodeMove += smartGridDocumentTypes_BeforeNodeMove;
            smartGridDocumentTypes1.AfterNodeMove += smartGridDocumentTypes_AfterNodeMove;
            smartGridDocumentTypes1.DoubleClick += smartGridDocumentTypes1_DoubleClick;
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
            toolStripButtonNew.Click += toolStripButtonNew_Click;
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
            toolStripButtonDelete.Click += toolStripButtonDelete_Click;
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
            ((System.ComponentModel.ISupportInitialize)smartGridDocumentTypes1).EndInit();
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
        private ToolStripSplitButton toolStripButtonLevels;
        private ToolStripButton toolStripButtonPath;
        private SmartLib.SmartGrid smartGridDocumentTypes1;
    }
}