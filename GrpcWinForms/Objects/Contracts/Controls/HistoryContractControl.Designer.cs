namespace GrpcWinForms.Objects.Contracts.Controls
{
    partial class HistoryContractControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HistoryContractControl));
            C1.Win.FlexGrid.FooterDescription footerDescription1 = new C1.Win.FlexGrid.FooterDescription();
            C1.Win.FlexGrid.AggregateDefinition aggregateDefinition1 = new C1.Win.FlexGrid.AggregateDefinition();
            smartGridHistory1 = new SmartLib.SmartGrid(components);
            ((System.ComponentModel.ISupportInitialize)smartGridHistory1).BeginInit();
            SuspendLayout();
            // 
            // smartGridHistory1
            // 
            smartGridHistory1.AllowMerging = C1.Win.FlexGrid.AllowMergingEnum.FixedOnly;
            smartGridHistory1.AllowMergingFixed = C1.Win.FlexGrid.AllowMergingEnum.FixedOnly;
            smartGridHistory1.AllowNodeMove = false;
            smartGridHistory1.AutoGenerateColumns = false;
            smartGridHistory1.ColumnInfo = resources.GetString("smartGridHistory1.ColumnInfo");
            smartGridHistory1.Dock = DockStyle.Fill;
            smartGridHistory1.DrawMode = C1.Win.FlexGrid.DrawModeEnum.OwnerDraw;
            aggregateDefinition1.Aggregate = C1.Win.FlexGrid.AggregateEnum.Count;
            aggregateDefinition1.Caption = "Всего: ";
            aggregateDefinition1.Column = 4;
            footerDescription1.Aggregates.Add(aggregateDefinition1);
            smartGridHistory1.Footers.Descriptions.Add(footerDescription1);
            smartGridHistory1.Footers.Fixed = true;
            smartGridHistory1.IdName = null;
            smartGridHistory1.Location = new Point(0, 0);
            smartGridHistory1.Name = "smartGridHistory1";
            smartGridHistory1.Rows.Count = 51;
            smartGridHistory1.SelectedRows = (List<int>)resources.GetObject("smartGridHistory1.SelectedRows");
            smartGridHistory1.SelectionMode = C1.Win.FlexGrid.SelectionModeEnum.Row;
            smartGridHistory1.Size = new Size(835, 184);
            smartGridHistory1.SortingType = SmartLib.SortingType.Descending;
            smartGridHistory1.StyleInfo = resources.GetString("smartGridHistory1.StyleInfo");
            smartGridHistory1.TabIndex = 1;
            // 
            // HistoryContractControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(smartGridHistory1);
            Name = "HistoryContractControl";
            Size = new Size(835, 184);
            ((System.ComponentModel.ISupportInitialize)smartGridHistory1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        public SmartLib.SmartGrid smartGridHistory1;
    }
}
