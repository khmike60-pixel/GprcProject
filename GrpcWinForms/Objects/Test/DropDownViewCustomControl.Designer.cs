namespace GrpcWinForms.Objects.Test
{
    partial class DropDownViewCustomControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DropDownViewCustomControl));
            panel1 = new Panel();
            grid = new SmartGrid.SmartGrid();
            panel2 = new Panel();
            buttonOk = new Button();
            buttonCancel = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grid).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(grid);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(378, 214);
            panel1.TabIndex = 0;
            // 
            // grid
            // 
            grid.AllowEditing = false;
            grid.AllowMergingFixed = C1.Win.FlexGrid.AllowMergingEnum.None;
            grid.AllowNodeMove = false;
            grid.AutoGenerateColumns = false;
            grid.ColumnInfo = "4,1,0,0,0,-1,Columns:0{Width:30;}\t1{Width:55;Name:\"Id\";Caption:\"Id\";}\t2{Width:174;StarWidth:\"*\";Name:\"Name\";Caption:\"Наименование\";}\t3{Width:100;Name:\"TaxNo\";Caption:\"ИНН / ПИНФЛ\";}\t";
            grid.Dock = DockStyle.Fill;
            grid.DrawMode = C1.Win.FlexGrid.DrawModeEnum.OwnerDraw;
            grid.Headers = null;
            grid.IdName = null;
            grid.IsEditing = false;
            grid.Location = new Point(0, 0);
            grid.Name = "grid";
            grid.Rows.Count = 10;
            grid.SelectedRows = (List<int>)resources.GetObject("grid.SelectedRows");
            grid.SelectionMode = C1.Win.FlexGrid.SelectionModeEnum.Row;
            grid.Size = new Size(378, 214);
            grid.SortingType = SmartGrid.SortingType.Descending;
            grid.StyleInfo = resources.GetString("grid.StyleInfo");
            grid.TabIndex = 1;
            grid.DoubleClick += grid_DoubleClick;
            // 
            // panel2
            // 
            panel2.Controls.Add(buttonOk);
            panel2.Controls.Add(buttonCancel);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 214);
            panel2.Name = "panel2";
            panel2.Size = new Size(378, 28);
            panel2.TabIndex = 1;
            // 
            // buttonOk
            // 
            buttonOk.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonOk.Location = new Point(219, 3);
            buttonOk.Name = "buttonOk";
            buttonOk.Size = new Size(75, 23);
            buttonOk.TabIndex = 0;
            buttonOk.Text = "Ok";
            buttonOk.UseVisualStyleBackColor = true;
            buttonOk.Click += buttonOk_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonCancel.Location = new Point(300, 3);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 23);
            buttonCancel.TabIndex = 3;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // DropDownViewCustomControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Controls.Add(panel2);
            Name = "DropDownViewCustomControl";
            Size = new Size(378, 242);
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)grid).EndInit();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Button buttonOk;
        private Button buttonCancel;
        public SmartGrid.SmartGrid grid;
    }
}
