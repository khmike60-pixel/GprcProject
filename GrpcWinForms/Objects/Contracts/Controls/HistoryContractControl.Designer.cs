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
            smartGridHistory = new SmartGrid.SmartGrid();
            ((System.ComponentModel.ISupportInitialize)smartGridHistory).BeginInit();
            SuspendLayout();
            // 
            // smartGridHistory
            // 
            smartGridHistory.AllowMergingFixed = C1.Win.FlexGrid.AllowMergingEnum.None;
            smartGridHistory.AllowNodeMove = false;
            smartGridHistory.AutoGenerateColumns = false;
            smartGridHistory.ColumnInfo = resources.GetString("smartGridHistory.ColumnInfo");
            smartGridHistory.Dock = DockStyle.Fill;
            smartGridHistory.DrawMode = C1.Win.FlexGrid.DrawModeEnum.OwnerDraw;
            aggregateDefinition1.Aggregate = C1.Win.FlexGrid.AggregateEnum.Count;
            aggregateDefinition1.Caption = "Всего: ";
            aggregateDefinition1.Column = 1;
            footerDescription1.Aggregates.Add(aggregateDefinition1);
            smartGridHistory.Footers.Descriptions.Add(footerDescription1);
            smartGridHistory.Footers.Fixed = true;
            smartGridHistory.Headers = null;
            smartGridHistory.IdName = null;
            smartGridHistory.IsEditing = false;
            smartGridHistory.Location = new Point(0, 0);
            smartGridHistory.Name = "smartGridHistory";
            smartGridHistory.Rows.Count = 3;
            smartGridHistory.SelectedRows = (List<int>)resources.GetObject("smartGridHistory.SelectedRows");
            smartGridHistory.SelectionMode = C1.Win.FlexGrid.SelectionModeEnum.Row;
            smartGridHistory.Size = new Size(835, 184);
            smartGridHistory.SortingType = SmartGrid.SortingType.Descending;
            smartGridHistory.StyleInfo = resources.GetString("smartGridHistory.StyleInfo");
            smartGridHistory.TabIndex = 0;
            // 
            // HistoryContractControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(smartGridHistory);
            Name = "HistoryContractControl";
            Size = new Size(835, 184);
            ((System.ComponentModel.ISupportInitialize)smartGridHistory).EndInit();
            ResumeLayout(false);
        }

        #endregion

        public SmartGrid.SmartGrid smartGridHistory;
    }
}
