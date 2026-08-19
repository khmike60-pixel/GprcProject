namespace GrpcWinForms.Objects.Applications
{
    partial class ApplicationsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ApplicationsForm));
            C1.Win.FlexGrid.FooterDescription footerDescription1 = new C1.Win.FlexGrid.FooterDescription();
            C1.Win.FlexGrid.AggregateDefinition aggregateDefinition1 = new C1.Win.FlexGrid.AggregateDefinition();
            panel1 = new Panel();
            textBoxAppName = new TextBox();
            labelName = new Label();
            panel2 = new Panel();
            smartGrid1 = new SmartLib.SmartGrid(components);
            applicationBindingSource = new BindingSource(components);
            toolStrip1 = new ToolStrip();
            toolStripButtonNew = new ToolStripButton();
            toolStripButtonDouble = new ToolStripButton();
            toolStripButtonEdit = new ToolStripButton();
            toolStripButtonDelete = new ToolStripButton();
            toolStripButtonRefresh = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)smartGrid1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)applicationBindingSource).BeginInit();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(textBoxAppName);
            panel1.Controls.Add(labelName);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 34);
            panel1.TabIndex = 0;
            // 
            // textBoxAppName
            // 
            textBoxAppName.Location = new Point(117, 5);
            textBoxAppName.Name = "textBoxAppName";
            textBoxAppName.Size = new Size(127, 23);
            textBoxAppName.TabIndex = 1;
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
            panel2.Controls.Add(smartGrid1);
            panel2.Controls.Add(toolStrip1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 34);
            panel2.Name = "panel2";
            panel2.Size = new Size(800, 416);
            panel2.TabIndex = 1;
            // 
            // smartGrid1
            // 
            smartGrid1.AllowMerging = C1.Win.FlexGrid.AllowMergingEnum.FixedOnly;
            smartGrid1.AllowMergingFixed = C1.Win.FlexGrid.AllowMergingEnum.FixedOnly;
            smartGrid1.AllowNodeMove = false;
            smartGrid1.AutoGenerateColumns = false;
            smartGrid1.ColumnInfo = resources.GetString("smartGrid1.ColumnInfo");
            smartGrid1.Dock = DockStyle.Fill;
            smartGrid1.DrawMode = C1.Win.FlexGrid.DrawModeEnum.OwnerDraw;
            aggregateDefinition1.Aggregate = C1.Win.FlexGrid.AggregateEnum.Count;
            aggregateDefinition1.Caption = "Всего: ";
            aggregateDefinition1.Column = 2;
            footerDescription1.Aggregates.Add(aggregateDefinition1);
            smartGrid1.Footers.Descriptions.Add(footerDescription1);
            smartGrid1.Footers.Fixed = true;
            smartGrid1.IdName = null;
            smartGrid1.Location = new Point(0, 31);
            smartGrid1.Name = "smartGrid1";
            smartGrid1.Rows.Count = 51;
            smartGrid1.SelectedRows = (List<int>)resources.GetObject("smartGrid1.SelectedRows");
            smartGrid1.SelectionMode = C1.Win.FlexGrid.SelectionModeEnum.Row;
            smartGrid1.Size = new Size(800, 385);
            smartGrid1.SortingType = SmartLib.SortingType.Descending;
            smartGrid1.StyleInfo = resources.GetString("smartGrid1.StyleInfo");
            smartGrid1.TabIndex = 3;
            smartGrid1.DoubleClick += smartGrid_DoubleClick;
            // 
            // applicationBindingSource
            // 
            applicationBindingSource.DataSource = typeof(GrpcCommonNet.Library.Common.Application);
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(24, 24);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripButtonNew, toolStripButtonDouble, toolStripButtonEdit, toolStripButtonDelete, toolStripButtonRefresh, toolStripSeparator1 });
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
            // ApplicationsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "ApplicationsForm";
            Text = "Приложения";
            Load += ApplicationsForm_Load;
            KeyDown += ApplicationsForm_KeyDown;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)smartGrid1).EndInit();
            ((System.ComponentModel.ISupportInitialize)applicationBindingSource).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TextBox textBoxAppName;
        private Label labelName;
        private Panel panel2;
        private ToolStrip toolStrip1;
        private ToolStripButton toolStripButtonNew;
        private ToolStripButton toolStripButtonDouble;
        private ToolStripButton toolStripButtonEdit;
        private ToolStripButton toolStripButtonDelete;
        private ToolStripButton toolStripButtonRefresh;
        private ToolStripSeparator toolStripSeparator1;
        private BindingSource applicationBindingSource;
        private SmartLib.SmartGrid smartGrid1;
    }
}