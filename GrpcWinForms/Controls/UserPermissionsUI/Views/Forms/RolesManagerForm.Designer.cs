namespace GrpcWinForms.Controls.UserPermissionsUI.Views.Forms
{
    partial class RolesManagerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RolesManagerForm));
            C1.Win.FlexGrid.FooterDescription footerDescription2 = new C1.Win.FlexGrid.FooterDescription();
            C1.Win.FlexGrid.AggregateDefinition aggregateDefinition2 = new C1.Win.FlexGrid.AggregateDefinition();
            tsRoles = new ToolStrip();
            AddRole = new ToolStripButton();
            DuplicateRole = new ToolStripButton();
            DeleteRole = new ToolStripButton();
            RefreshRole = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            ApproveRole = new ToolStripButton();
            CheckRole = new ToolStripButton();
            c1SplitContainer1 = new C1.Win.SplitContainer.C1SplitContainer();
            c1SplitterPanel1 = new C1.Win.SplitContainer.C1SplitterPanel();
            RolesGrid = new SmartLib.SmartGrid(components);
            c1SplitterPanel2 = new C1.Win.SplitContainer.C1SplitterPanel();
            _roleRightsGrid = new GrpcWinForms.Controls.UserPermissionsUI.Views.Components.RoleRightsGrid();
            tsRoles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)c1SplitContainer1).BeginInit();
            c1SplitContainer1.SuspendLayout();
            c1SplitterPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)RolesGrid).BeginInit();
            c1SplitterPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // tsRoles
            // 
            tsRoles.ImageScalingSize = new Size(24, 24);
            tsRoles.Items.AddRange(new ToolStripItem[] { AddRole, DuplicateRole, DeleteRole, RefreshRole, toolStripSeparator1, ApproveRole, CheckRole });
            tsRoles.Location = new Point(0, 0);
            tsRoles.Name = "tsRoles";
            tsRoles.Size = new Size(600, 31);
            tsRoles.TabIndex = 5;
            tsRoles.Text = "toolStrip1";
            // 
            // AddRole
            // 
            AddRole.DisplayStyle = ToolStripItemDisplayStyle.Image;
            AddRole.Image = Properties.Resources.icons8_документ_50;
            AddRole.ImageTransparentColor = Color.Magenta;
            AddRole.Name = "AddRole";
            AddRole.Size = new Size(28, 28);
            AddRole.Tag = "{\"name\": \"LocalRightObjects\"}";
            AddRole.Text = "Новый";
            AddRole.Click += AddRole_Click;
            // 
            // DuplicateRole
            // 
            DuplicateRole.DisplayStyle = ToolStripItemDisplayStyle.Image;
            DuplicateRole.Image = Properties.Resources.icons8_скопировать_50;
            DuplicateRole.ImageTransparentColor = Color.Magenta;
            DuplicateRole.Name = "DuplicateRole";
            DuplicateRole.Size = new Size(28, 28);
            DuplicateRole.Text = "toolStripButton1";
            DuplicateRole.Click += DuplicateRole_Click;
            // 
            // DeleteRole
            // 
            DeleteRole.DisplayStyle = ToolStripItemDisplayStyle.Image;
            DeleteRole.Image = Properties.Resources.icons8_удалить_файл_50;
            DeleteRole.ImageTransparentColor = Color.Magenta;
            DeleteRole.Name = "DeleteRole";
            DeleteRole.Size = new Size(28, 28);
            DeleteRole.Tag = "{\"name\": \"LocalRightObjects\"}";
            DeleteRole.Text = "Удалить";
            DeleteRole.Click += DeleteRole_Click;
            // 
            // RefreshRole
            // 
            RefreshRole.Alignment = ToolStripItemAlignment.Right;
            RefreshRole.Image = Properties.Resources.icons8_refresh_50;
            RefreshRole.ImageTransparentColor = Color.Magenta;
            RefreshRole.Name = "RefreshRole";
            RefreshRole.Size = new Size(89, 28);
            RefreshRole.Text = "Обновить";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 31);
            // 
            // ApproveRole
            // 
            ApproveRole.DisplayStyle = ToolStripItemDisplayStyle.Image;
            ApproveRole.Image = (Image)resources.GetObject("ApproveRole.Image");
            ApproveRole.ImageTransparentColor = Color.Magenta;
            ApproveRole.Name = "ApproveRole";
            ApproveRole.Size = new Size(28, 28);
            ApproveRole.Text = "Утвердить";
            ApproveRole.Click += ApproveRole_Click;
            // 
            // CheckRole
            // 
            CheckRole.DisplayStyle = ToolStripItemDisplayStyle.Image;
            CheckRole.Image = (Image)resources.GetObject("CheckRole.Image");
            CheckRole.ImageTransparentColor = Color.Magenta;
            CheckRole.Name = "CheckRole";
            CheckRole.Size = new Size(28, 28);
            CheckRole.Text = "Проверить";
            CheckRole.Click += CheckRole_Click;
            // 
            // c1SplitContainer1
            // 
            c1SplitContainer1.AutoSizeElement = C1.Framework.AutoSizeElement.Both;
            c1SplitContainer1.Dock = DockStyle.Fill;
            c1SplitContainer1.HeaderButtonBackColor = Color.Transparent;
            c1SplitContainer1.Location = new Point(0, 0);
            c1SplitContainer1.Name = "c1SplitContainer1";
            c1SplitContainer1.Panels.Add(c1SplitterPanel1);
            c1SplitContainer1.Panels.Add(c1SplitterPanel2);
            c1SplitContainer1.Size = new Size(1203, 450);
            c1SplitContainer1.TabIndex = 6;
            // 
            // c1SplitterPanel1
            // 
            c1SplitterPanel1.Controls.Add(RolesGrid);
            c1SplitterPanel1.Controls.Add(tsRoles);
            c1SplitterPanel1.Dock = C1.Win.SplitContainer.PanelDockStyle.Left;
            c1SplitterPanel1.Location = new Point(0, 21);
            c1SplitterPanel1.Name = "c1SplitterPanel1";
            c1SplitterPanel1.Size = new Size(600, 429);
            c1SplitterPanel1.TabIndex = 0;
            c1SplitterPanel1.Text = "Роли";
            c1SplitterPanel1.Width = 600;
            // 
            // RolesGrid
            // 
            RolesGrid.AllowAddNew = true;
            RolesGrid.AllowDelete = true;
            RolesGrid.AllowMerging = C1.Win.FlexGrid.AllowMergingEnum.FixedOnly;
            RolesGrid.AllowMergingFixed = C1.Win.FlexGrid.AllowMergingEnum.FixedOnly;
            RolesGrid.AllowNodeMove = false;
            RolesGrid.AutoGenerateColumns = false;
            RolesGrid.ColumnInfo = resources.GetString("RolesGrid.ColumnInfo");
            RolesGrid.Dock = DockStyle.Fill;
            RolesGrid.DrawMode = C1.Win.FlexGrid.DrawModeEnum.OwnerDraw;
            aggregateDefinition2.Aggregate = C1.Win.FlexGrid.AggregateEnum.Count;
            aggregateDefinition2.Caption = "Всего: ";
            aggregateDefinition2.Column = 1;
            footerDescription2.Aggregates.Add(aggregateDefinition2);
            RolesGrid.Footers.Descriptions.Add(footerDescription2);
            RolesGrid.Footers.Fixed = true;
            RolesGrid.IdName = null;
            RolesGrid.Location = new Point(0, 31);
            RolesGrid.Name = "RolesGrid";
            RolesGrid.Rows.Count = 5;
            RolesGrid.SelectedRows = (List<int>)resources.GetObject("RolesGrid.SelectedRows");
            RolesGrid.SelectionMode = C1.Win.FlexGrid.SelectionModeEnum.Row;
            RolesGrid.Size = new Size(600, 398);
            RolesGrid.SortingType = SmartLib.SortingType.Descending;
            RolesGrid.StyleInfo = resources.GetString("RolesGrid.StyleInfo");
            RolesGrid.TabIndex = 6;
            // 
            // c1SplitterPanel2
            // 
            c1SplitterPanel2.Controls.Add(_roleRightsGrid);
            c1SplitterPanel2.Height = 450;
            c1SplitterPanel2.Location = new Point(604, 21);
            c1SplitterPanel2.Name = "c1SplitterPanel2";
            c1SplitterPanel2.Size = new Size(599, 429);
            c1SplitterPanel2.TabIndex = 1;
            c1SplitterPanel2.Text = "Права роли";
            // 
            // _roleRightsGrid
            // 
            _roleRightsGrid.Dock = DockStyle.Fill;
            _roleRightsGrid.Location = new Point(0, 0);
            _roleRightsGrid.Name = "_roleRightsGrid";
            _roleRightsGrid.Size = new Size(599, 429);
            _roleRightsGrid.TabIndex = 0;
            // 
            // RolesManagerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1203, 450);
            Controls.Add(c1SplitContainer1);
            Name = "RolesManagerForm";
            Text = "Роли";
            tsRoles.ResumeLayout(false);
            tsRoles.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)c1SplitContainer1).EndInit();
            c1SplitContainer1.ResumeLayout(false);
            c1SplitterPanel1.ResumeLayout(false);
            c1SplitterPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)RolesGrid).EndInit();
            c1SplitterPanel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private ToolStrip tsRoles;
        private ToolStripButton AddRole;
        private ToolStripButton DuplicateRole;
        private ToolStripButton DeleteRole;
        private ToolStripButton RefreshRole;
        private ToolStripSeparator toolStripSeparator1;
        private C1.Win.SplitContainer.C1SplitContainer c1SplitContainer1;
        private C1.Win.SplitContainer.C1SplitterPanel c1SplitterPanel1;
        private SmartLib.SmartGrid RolesGrid;
        private C1.Win.SplitContainer.C1SplitterPanel c1SplitterPanel2;
        private Components.RoleRightsGrid _roleRightsGrid;
        private ToolStripButton ApproveRole;
        private ToolStripButton CheckRole;
    }
}