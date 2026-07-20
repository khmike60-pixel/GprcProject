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
            smartGrid1 = new SmartGrid.SmartGrid();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)smartGrid1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(buttonOk);
            panel1.Controls.Add(buttonCancel);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 233);
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
            // 
            // smartGrid1
            // 
            smartGrid1.AllowMergingFixed = C1.Win.FlexGrid.AllowMergingEnum.None;
            smartGrid1.AllowNodeMove = false;
            smartGrid1.ColumnInfo = "4,1,0,0,0,-1,Columns:0{Width:30;}\t1{Width:50;Name:\"Id\";Caption:\"Id\";}\t2{Width:182;StarWidth:\"*\";Name:\"Name\";Caption:\"Наименование\";}\t3{Width:100;Name:\"TaxNo\";Caption:\"ИНН/ПИНФЛ\";}\t";
            smartGrid1.Dock = DockStyle.Fill;
            smartGrid1.DrawMode = C1.Win.FlexGrid.DrawModeEnum.OwnerDraw;
            aggregateDefinition1.Aggregate = C1.Win.FlexGrid.AggregateEnum.Count;
            aggregateDefinition1.Caption = "Всего: ";
            aggregateDefinition1.Column = 1;
            footerDescription1.Aggregates.Add(aggregateDefinition1);
            smartGrid1.Footers.Descriptions.Add(footerDescription1);
            smartGrid1.Footers.Fixed = true;
            smartGrid1.Headers = null;
            smartGrid1.IdName = null;
            smartGrid1.IsEditing = false;
            smartGrid1.Location = new Point(0, 0);
            smartGrid1.Name = "smartGrid1";
            smartGrid1.Rows.Count = 11;
            smartGrid1.SelectedRows = (List<int>)resources.GetObject("smartGrid1.SelectedRows");
            smartGrid1.SelectionMode = C1.Win.FlexGrid.SelectionModeEnum.Row;
            smartGrid1.Size = new Size(381, 233);
            smartGrid1.SortingType = SmartGrid.SortingType.Descending;
            smartGrid1.StyleInfo = resources.GetString("smartGrid1.StyleInfo");
            smartGrid1.TabIndex = 1;
            // 
            // DropDownUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(smartGrid1);
            Controls.Add(panel1);
            Name = "DropDownUserControl";
            Size = new Size(381, 263);
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)smartGrid1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button buttonOk;
        private Button buttonCancel;
        private SmartGrid.SmartGrid smartGrid1;
    }
}
