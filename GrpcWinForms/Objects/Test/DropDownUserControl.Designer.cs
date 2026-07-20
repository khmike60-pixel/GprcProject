namespace GrpcWinForms.Objects.Test
{
    partial class DropDownUserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DropDownUserControl));
            panel1 = new Panel();
            buttonOk = new Button();
            buttonCancel = new Button();
            smart = new SmartGrid.SmartGrid();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)smart).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(buttonOk);
            panel1.Controls.Add(buttonCancel);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 268);
            panel1.Name = "panel1";
            panel1.Size = new Size(381, 30);
            panel1.TabIndex = 0;
            // 
            // buttonOk
            // 
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonOk.Location = new Point(222, 4);
            buttonOk.Name = "buttonOk";
            buttonOk.Size = new Size(75, 23);
            buttonOk.TabIndex = 1;
            buttonOk.Text = "Выбрать";
            buttonOk.UseVisualStyleBackColor = true;
            buttonOk.Click += buttonOk_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Location = new Point(303, 4);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 23);
            buttonCancel.TabIndex = 0;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // smart
            // 
            smart.AllowEditing = false;
            smart.AllowMergingFixed = C1.Win.FlexGrid.AllowMergingEnum.None;
            smart.AllowNodeMove = false;
            smart.ColumnInfo = "4,1,0,0,0,-1,Columns:0{Width:30;}\t1{Width:50;Name:\"Id\";Caption:\"Id\";}\t2{Width:199;StarWidth:\"*\";Name:\"Name\";Caption:\"Наименование\";}\t3{Width:100;Name:\"TaxNo\";Caption:\"ИНН/ПИНФЛ\";}\t";
            smart.Dock = DockStyle.Fill;
            smart.DrawMode = C1.Win.FlexGrid.DrawModeEnum.OwnerDraw;
            aggregateDefinition1.Aggregate = C1.Win.FlexGrid.AggregateEnum.Count;
            aggregateDefinition1.Caption = "Всего: ";
            aggregateDefinition1.Column = 1;
            footerDescription1.Aggregates.Add(aggregateDefinition1);
            smart.Footers.Descriptions.Add(footerDescription1);
            smart.Footers.Fixed = true;
            smart.Headers = null;
            smart.IdName = null;
            smart.IsEditing = false;
            smart.Location = new Point(0, 0);
            smart.Name = "smart";
            smart.Rows.Count = 12;
            smart.SelectedRows = (List<int>)resources.GetObject("smart.SelectedRows");
            smart.SelectionMode = C1.Win.FlexGrid.SelectionModeEnum.Row;
            smart.Size = new Size(381, 268);
            smart.SortingType = SmartGrid.SortingType.Descending;
            smart.StyleInfo = resources.GetString("smart.StyleInfo");
            smart.TabIndex = 1;
            smart.DoubleClick += smart_DoubleClick;
            // 
            // DropDownUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(smart);
            Controls.Add(panel1);
            Name = "DropDownUserControl";
            Size = new Size(381, 298);
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)smart).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button buttonOk;
        private Button buttonCancel;
        public SmartGrid.SmartGrid smart;
    }
}
