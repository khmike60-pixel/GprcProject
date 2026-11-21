using C1.Win.FlexGrid;
using SmartLib;

namespace GrpcWinForms.Controls.UserPermissionsUI.Views.Forms
{
    partial class RightObjectsManagerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RightObjectsManagerForm));
            FooterDescription footerDescription2 = new FooterDescription();
            RightObjectsGrid = new SmartGrid(components);
            toolStrip1 = new ToolStrip();
            AddObjectRight = new ToolStripButton();
            DeleteObjectRight = new ToolStripButton();
            RefreshRightObjects = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            ((System.ComponentModel.ISupportInitialize)RightObjectsGrid).BeginInit();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // RightObjectsGrid
            // 
            RightObjectsGrid.AllowDragging = AllowDraggingEnum.None;
            RightObjectsGrid.AllowMerging = AllowMergingEnum.FixedOnly;
            RightObjectsGrid.AllowMergingFixed = AllowMergingEnum.FixedOnly;
            RightObjectsGrid.AllowNodeMove = true;
            RightObjectsGrid.AutoGenerateColumns = false;
            RightObjectsGrid.ColumnInfo = resources.GetString("RightObjectsGrid.ColumnInfo");
            RightObjectsGrid.Dock = DockStyle.Fill;
            RightObjectsGrid.DrawMode = DrawModeEnum.OwnerDraw;
            RightObjectsGrid.Footers.Descriptions.Add(footerDescription2);
            RightObjectsGrid.Footers.Fixed = true;
            RightObjectsGrid.IdName = null;
            RightObjectsGrid.Location = new Point(0, 31);
            RightObjectsGrid.Margin = new Padding(4, 3, 4, 3);
            RightObjectsGrid.Name = "RightObjectsGrid";
            RightObjectsGrid.Rows.Count = 51;
            RightObjectsGrid.SelectedRows = null;
            RightObjectsGrid.SelectionMode = SelectionModeEnum.Row;
            RightObjectsGrid.Size = new Size(933, 488);
            RightObjectsGrid.SortingType = SortingType.Descending;
            RightObjectsGrid.StyleInfo = resources.GetString("RightObjectsGrid.StyleInfo");
            RightObjectsGrid.TabIndex = 2;
            RightObjectsGrid.BeforeNodeMove += RightObjectsGrid_BeforeNodeMove;
            RightObjectsGrid.AfterNodeMove += RightObjectsGrid_AfterNodeMove;
            RightObjectsGrid.SelChange += RightObjectsGrid_SelChange;
            RightObjectsGrid.BeforeEdit += RightObjectsGrid_BeforeEdit;
            RightObjectsGrid.AfterEdit += RightObjectsGrid_AfterEdit;
            RightObjectsGrid.MouseDown += RightObjectsGrid_MouseDown;
            RightObjectsGrid.MouseUp += RightObjectsGrid_MouseUp;
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(24, 24);
            toolStrip1.Items.AddRange(new ToolStripItem[] { AddObjectRight, DeleteObjectRight, RefreshRightObjects, toolStripSeparator1 });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(933, 31);
            toolStrip1.TabIndex = 4;
            toolStrip1.Text = "toolStrip1";
            // 
            // AddObjectRight
            // 
            AddObjectRight.DisplayStyle = ToolStripItemDisplayStyle.Image;
            AddObjectRight.Image = Properties.Resources.icons8_документ_50;
            AddObjectRight.ImageTransparentColor = Color.Magenta;
            AddObjectRight.Name = "AddObjectRight";
            AddObjectRight.Size = new Size(28, 28);
            AddObjectRight.Text = "Новый";
            // 
            // DeleteObjectRight
            // 
            DeleteObjectRight.DisplayStyle = ToolStripItemDisplayStyle.Image;
            DeleteObjectRight.Image = Properties.Resources.icons8_удалить_файл_50;
            DeleteObjectRight.ImageTransparentColor = Color.Magenta;
            DeleteObjectRight.Name = "DeleteObjectRight";
            DeleteObjectRight.Size = new Size(28, 28);
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
            // RightObjectsManagerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(933, 519);
            Controls.Add(RightObjectsGrid);
            Controls.Add(toolStrip1);
            Margin = new Padding(4, 3, 4, 3);
            Name = "RightObjectsManagerForm";
            ShowInTaskbar = false;
            Text = "Объекты прав";
            ((System.ComponentModel.ISupportInitialize)RightObjectsGrid).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private SmartLib.SmartGrid RightObjectsGrid;
        private ToolStrip toolStrip1;
        private ToolStripButton AddObjectRight;
        private ToolStripButton DeleteObjectRight;
        private ToolStripButton RefreshRightObjects;
        private ToolStripSeparator toolStripSeparator1;
    }
}