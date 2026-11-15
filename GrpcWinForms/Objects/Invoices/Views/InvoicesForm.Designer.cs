namespace GrpcWinForms.Objects.Invoices.Views
{
    partial class InvoicesForm
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
            c1SplitContainer1 = new C1.Win.SplitContainer.C1SplitContainer();
            spInvoices = new C1.Win.SplitContainer.C1SplitterPanel();
            invoiceList1 = new GrpcWinForms.Objects.Invoices.Controls.InvoiceList();
            spLines = new C1.Win.SplitContainer.C1SplitterPanel();
            invoiceLinesControl1 = new GrpcWinForms.Objects.Invoices.Controls.InvoiceLinesControl();
            ((System.ComponentModel.ISupportInitialize)c1SplitContainer1).BeginInit();
            c1SplitContainer1.SuspendLayout();
            spInvoices.SuspendLayout();
            spLines.SuspendLayout();
            SuspendLayout();
            // 
            // c1SplitContainer1
            // 
            c1SplitContainer1.AutoSizeElement = C1.Framework.AutoSizeElement.Both;
            c1SplitContainer1.Dock = DockStyle.Fill;
            c1SplitContainer1.HeaderButtonBackColor = Color.Transparent;
            c1SplitContainer1.Location = new Point(0, 0);
            c1SplitContainer1.Name = "c1SplitContainer1";
            c1SplitContainer1.Panels.Add(spLines);
            c1SplitContainer1.Panels.Add(spInvoices);
            c1SplitContainer1.Size = new Size(1293, 514);
            c1SplitContainer1.TabIndex = 1;
            // 
            // spInvoices
            // 
            spInvoices.Collapsible = true;
            spInvoices.Controls.Add(invoiceList1);
            spInvoices.Dock = C1.Win.SplitContainer.PanelDockStyle.Bottom;
            spInvoices.Height = 255;
            spInvoices.Location = new Point(0, 21);
            spInvoices.Name = "spInvoices";
            spInvoices.Size = new Size(1293, 234);
            spInvoices.TabIndex = 0;
            spInvoices.Text = "Документы";
            // 
            // invoiceList1
            // 
            invoiceList1.Dock = DockStyle.Fill;
            invoiceList1.Location = new Point(0, 0);
            invoiceList1.Name = "invoiceList1";
            invoiceList1.Size = new Size(1293, 234);
            invoiceList1.TabIndex = 0;
            // 
            // spLines
            // 
            spLines.Collapsible = true;
            spLines.Controls.Add(invoiceLinesControl1);
            spLines.Dock = C1.Win.SplitContainer.PanelDockStyle.Bottom;
            spLines.Height = 255;
            spLines.Location = new Point(0, 287);
            spLines.Name = "spLines";
            spLines.Size = new Size(1293, 227);
            spLines.TabIndex = 1;
            spLines.Text = "Строки документов";
            // 
            // invoiceLinesControl1
            // 
            invoiceLinesControl1.Dock = DockStyle.Fill;
            invoiceLinesControl1.Location = new Point(0, 0);
            invoiceLinesControl1.Name = "invoiceLinesControl1";
            invoiceLinesControl1.Size = new Size(1293, 227);
            invoiceLinesControl1.TabIndex = 0;
            // 
            // InvoicesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1293, 514);
            Controls.Add(c1SplitContainer1);
            Name = "InvoicesForm";
            Text = "Счета-Фактуры";
            ((System.ComponentModel.ISupportInitialize)c1SplitContainer1).EndInit();
            c1SplitContainer1.ResumeLayout(false);
            spInvoices.ResumeLayout(false);
            spLines.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private C1.Win.SplitContainer.C1SplitContainer c1SplitContainer1;
        private C1.Win.SplitContainer.C1SplitterPanel spInvoices;
        private C1.Win.SplitContainer.C1SplitterPanel spLines;
        private Invoices.Controls.InvoiceList invoiceList1;
        private Invoices.Controls.InvoiceLinesControl invoiceLinesControl1;
    }
}