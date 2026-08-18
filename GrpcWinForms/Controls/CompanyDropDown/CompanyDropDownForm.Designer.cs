using GrpcWinForms.Properties;

namespace GrpcWinForms.Objects.Contragents.Components
{
    partial class CompanyDropDownForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CompanyDropDownForm));
            C1.Win.FlexGrid.FooterDescription footerDescription1 = new C1.Win.FlexGrid.FooterDescription();
            C1.Win.FlexGrid.AggregateDefinition aggregateDefinition1 = new C1.Win.FlexGrid.AggregateDefinition();
            panelButton = new Panel();
            buttonOk = new Button();
            buttonCancel = new Button();
            smart1 = new SmartLib.SmartGrid(components);
            panelButton.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)smart1).BeginInit();
            SuspendLayout();
            // 
            // panelButton
            // 
            panelButton.Controls.Add(buttonOk);
            panelButton.Controls.Add(buttonCancel);
            panelButton.Dock = DockStyle.Bottom;
            panelButton.Location = new Point(0, 270);
            panelButton.Name = "panelButton";
            panelButton.Size = new Size(380, 30);
            panelButton.TabIndex = 0;
            // 
            // buttonOk
            // 
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonOk.Location = new Point(221, 4);
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
            buttonCancel.Location = new Point(302, 4);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 23);
            buttonCancel.TabIndex = 0;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // smart1
            // 
            smart1.AllowMerging = C1.Win.FlexGrid.AllowMergingEnum.FixedOnly;
            smart1.AllowMergingFixed = C1.Win.FlexGrid.AllowMergingEnum.FixedOnly;
            smart1.AllowNodeMove = false;
            smart1.AutoGenerateColumns = false;
            smart1.ColumnInfo = resources.GetString("smart1.ColumnInfo");
            smart1.Dock = DockStyle.Fill;
            smart1.DrawMode = C1.Win.FlexGrid.DrawModeEnum.OwnerDraw;
            aggregateDefinition1.Aggregate = C1.Win.FlexGrid.AggregateEnum.Sum;
            aggregateDefinition1.Caption = "Всего: ";
            aggregateDefinition1.Column = 2;
            footerDescription1.Aggregates.Add(aggregateDefinition1);
            smart1.Footers.Descriptions.Add(footerDescription1);
            smart1.Footers.Fixed = true;
            smart1.IdName = null;
            smart1.Location = new Point(0, 0);
            smart1.Name = "smart1";
            smart1.Rows.Count = 51;
            smart1.SelectedRows = (List<int>)resources.GetObject("smart1.SelectedRows");
            smart1.SelectionMode = C1.Win.FlexGrid.SelectionModeEnum.Row;
            smart1.Size = new Size(380, 270);
            smart1.SortingType = SmartLib.SortingType.Descending;
            smart1.StyleInfo = resources.GetString("smart1.StyleInfo");
            smart1.TabIndex = 2;
            smart1.DoubleClick += smart_DoubleClick;
            // 
            // CompanyDropDownForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(smart1);
            Controls.Add(panelButton);
            Name = "CompanyDropDownForm";
            Size = new Size(380, 300);
            panelButton.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)smart1).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private Panel panelButton;
        private Button buttonOk;
        private Button buttonCancel;
        public SmartLib.SmartGrid smart1;
    }
}
