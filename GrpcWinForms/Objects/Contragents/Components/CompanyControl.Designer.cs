namespace GrpcWinForms.Objects.Contragents.Components
{
    partial class CompanyControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CompanyControl));
            smartGrid1 = new SmartGrid.SmartGrid();
            label1 = new Label();
            textBox1 = new TextBox();
            panelTop = new Panel();
            statusStrip = new StatusStrip();
            ((System.ComponentModel.ISupportInitialize)smartGrid1).BeginInit();
            panelTop.SuspendLayout();
            SuspendLayout();
            // 
            // smartGrid1
            // 
            smartGrid1.AllowEditing = false;
            smartGrid1.AllowMergingFixed = C1.Win.FlexGrid.AllowMergingEnum.None;
            smartGrid1.AllowNodeMove = false;
            smartGrid1.AutoGenerateColumns = false;
            smartGrid1.ColumnInfo = "3,1,0,0,0,-1,Columns:0{Width:30;}\t1{Name:\"Taxno\";Caption:\"ИНН / ПИН ФЛ\";}\t2{Width:281;StarWidth:\"*\";Name:\"Name\";Caption:\"Наименование\";}\t";
            smartGrid1.DrawMode = C1.Win.FlexGrid.DrawModeEnum.OwnerDraw;
            aggregateDefinition1.Aggregate = C1.Win.FlexGrid.AggregateEnum.Count;
            aggregateDefinition1.Caption = "Всего: ";
            aggregateDefinition1.Column = 2;
            footerDescription1.Aggregates.Add(aggregateDefinition1);
            smartGrid1.Footers.Descriptions.Add(footerDescription1);
            smartGrid1.Footers.Fixed = true;
            smartGrid1.Headers = null;
            smartGrid1.IdName = null;
            smartGrid1.IsEditing = false;
            smartGrid1.Location = new Point(4, 32);
            smartGrid1.Name = "smartGrid1";
            smartGrid1.Rows.Count = 11;
            smartGrid1.SelectedRows = (List<int>)resources.GetObject("smartGrid1.SelectedRows");
            smartGrid1.SelectionMode = C1.Win.FlexGrid.SelectionModeEnum.Row;
            smartGrid1.Size = new Size(440, 181);
            smartGrid1.SortingType = SmartGrid.SortingType.Descending;
            smartGrid1.StyleInfo = resources.GetString("smartGrid1.StyleInfo");
            smartGrid1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(4, 7);
            label1.Name = "label1";
            label1.Size = new Size(91, 15);
            label1.TabIndex = 1;
            label1.Text = "Строка поиска:";
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox1.Location = new Point(101, 3);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(343, 23);
            textBox1.TabIndex = 2;
            // 
            // panelTop
            // 
            panelTop.Controls.Add(textBox1);
            panelTop.Controls.Add(label1);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(447, 32);
            panelTop.TabIndex = 3;
            // 
            // statusStrip
            // 
            statusStrip.BackColor = Color.Transparent;
            statusStrip.Location = new Point(0, 216);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(447, 22);
            statusStrip.TabIndex = 4;
            statusStrip.Text = "statusStrip1";
            statusStrip.MouseDown += statusStrip_MouseDown;
            statusStrip.MouseMove += statusStrip_MouseMove;
            statusStrip.MouseUp += statusStrip_MouseUp;
            statusStrip.Resize += statusStrip_Resize;
            // 
            // CompanyControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(statusStrip);
            Controls.Add(smartGrid1);
            Controls.Add(panelTop);
            Name = "CompanyControl";
            Size = new Size(447, 238);
            ((System.ComponentModel.ISupportInitialize)smartGrid1).EndInit();
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public SmartGrid.SmartGrid smartGrid1;
        private Label label1;
        private TextBox textBox1;
        private Panel panelTop;
        private StatusStrip statusStrip;
    }
}
