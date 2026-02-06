using GrpcWinForms.Objects.Contracts.Forms.Controls;

namespace GrpcWinForms.Objects.Contracts.Forms.SaleStandart
{
    partial class ContractStandartForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContractStandartForm));
            C1.Win.FlexGrid.FooterDescription footerDescription1 = new C1.Win.FlexGrid.FooterDescription();
            C1.Win.FlexGrid.AggregateDefinition aggregateDefinition1 = new C1.Win.FlexGrid.AggregateDefinition();
            c1SplitContainer1 = new C1.Win.SplitContainer.C1SplitContainer();
            c1SplitterPanelMain = new C1.Win.SplitContainer.C1SplitterPanel();
            c1DockingTab2 = new C1.Win.Command.C1DockingTab();
            c1DockingTabPageMain = new C1.Win.Command.C1DockingTabPage();
            headContractControl = new HeadContractControl();
            toolStripHead = new ToolStrip();
            toolStripButtonNew = new ToolStripButton();
            toolStripButtonDouble = new ToolStripButton();
            toolStripButtonEdit = new ToolStripButton();
            toolStripButtonDelete = new ToolStripButton();
            toolStripButtonRefresh = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            managerControl1 = new ManagerControl();
            sumContractControl1 = new SumContractControl();
            c1DockingTabPageProperties = new C1.Win.Command.C1DockingTabPage();
            propertiesControl1 = new GrpcWinForms.Objects.Contracts.Controls.PropertiesControl();
            c1DockingTabPageHistory = new C1.Win.Command.C1DockingTabPage();
            historyContractControl = new GrpcWinForms.Objects.Contracts.Controls.HistoryContractControl();
            c1SplitterPanelSpecification = new C1.Win.SplitContainer.C1SplitterPanel();
            c1DockingTab1 = new C1.Win.Command.C1DockingTab();
            c1DockingTabPageSpecification = new C1.Win.Command.C1DockingTabPage();
            smartGrid1 = new SmartGrid.SmartGrid();
            toolStripLines = new ToolStrip();
            toolStripButton1 = new ToolStripButton();
            toolStripButton2 = new ToolStripButton();
            toolStripButton3 = new ToolStripButton();
            toolStripButton4 = new ToolStripButton();
            toolStripButton5 = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            toolStripButtonSetupSpecification = new ToolStripButton();
            panelOk = new Panel();
            buttonOk = new Button();
            buttonCancel = new Button();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)c1SplitContainer1).BeginInit();
            c1SplitContainer1.SuspendLayout();
            c1SplitterPanelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)c1DockingTab2).BeginInit();
            c1DockingTab2.SuspendLayout();
            c1DockingTabPageMain.SuspendLayout();
            toolStripHead.SuspendLayout();
            c1DockingTabPageProperties.SuspendLayout();
            c1DockingTabPageHistory.SuspendLayout();
            c1SplitterPanelSpecification.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)c1DockingTab1).BeginInit();
            c1DockingTab1.SuspendLayout();
            c1DockingTabPageSpecification.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)smartGrid1).BeginInit();
            toolStripLines.SuspendLayout();
            panelOk.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // c1SplitContainer1
            // 
            c1SplitContainer1.AutoSizeElement = C1.Framework.AutoSizeElement.Both;
            c1SplitContainer1.Dock = DockStyle.Fill;
            c1SplitContainer1.Location = new Point(0, 0);
            c1SplitContainer1.Name = "c1SplitContainer1";
            c1SplitContainer1.Panels.Add(c1SplitterPanelMain);
            c1SplitContainer1.Panels.Add(c1SplitterPanelSpecification);
            c1SplitContainer1.Size = new Size(896, 622);
            c1SplitContainer1.TabIndex = 2;
            // 
            // c1SplitterPanelMain
            // 
            c1SplitterPanelMain.Collapsible = true;
            c1SplitterPanelMain.Controls.Add(c1DockingTab2);
            c1SplitterPanelMain.Height = 320;
            c1SplitterPanelMain.KeepRelativeSize = false;
            c1SplitterPanelMain.Location = new Point(0, 21);
            c1SplitterPanelMain.MinHeight = 320;
            c1SplitterPanelMain.MinWidth = 800;
            c1SplitterPanelMain.Name = "c1SplitterPanelMain";
            c1SplitterPanelMain.Size = new Size(896, 292);
            c1SplitterPanelMain.SizeRatio = 51.78D;
            c1SplitterPanelMain.TabIndex = 1;
            c1SplitterPanelMain.Text = "Текущее состояние контракта";
            c1SplitterPanelMain.Width = 896;
            // 
            // c1DockingTab2
            // 
            c1DockingTab2.Controls.Add(c1DockingTabPageMain);
            c1DockingTab2.Controls.Add(c1DockingTabPageProperties);
            c1DockingTab2.Controls.Add(c1DockingTabPageHistory);
            c1DockingTab2.Dock = DockStyle.Fill;
            c1DockingTab2.Location = new Point(0, 0);
            c1DockingTab2.Name = "c1DockingTab2";
            c1DockingTab2.Size = new Size(896, 292);
            c1DockingTab2.TabIndex = 7;
            // 
            // c1DockingTabPageMain
            // 
            c1DockingTabPageMain.Controls.Add(headContractControl);
            c1DockingTabPageMain.Controls.Add(toolStripHead);
            c1DockingTabPageMain.Controls.Add(managerControl1);
            c1DockingTabPageMain.Controls.Add(sumContractControl1);
            c1DockingTabPageMain.Location = new Point(1, 27);
            c1DockingTabPageMain.Name = "c1DockingTabPageMain";
            c1DockingTabPageMain.Size = new Size(894, 264);
            c1DockingTabPageMain.TabIndex = 0;
            c1DockingTabPageMain.Text = "Основное";
            // 
            // headContractControl
            // 
            headContractControl.Location = new Point(5, 34);
            headContractControl.MinimumSize = new Size(575, 136);
            headContractControl.Name = "headContractControl";
            headContractControl.Size = new Size(605, 136);
            headContractControl.TabIndex = 0;
            // 
            // toolStripHead
            // 
            toolStripHead.ImageScalingSize = new Size(24, 24);
            toolStripHead.Items.AddRange(new ToolStripItem[] { toolStripButtonNew, toolStripButtonDouble, toolStripButtonEdit, toolStripButtonDelete, toolStripButtonRefresh, toolStripSeparator1 });
            toolStripHead.Location = new Point(0, 0);
            toolStripHead.Name = "toolStripHead";
            toolStripHead.Size = new Size(894, 31);
            toolStripHead.TabIndex = 5;
            toolStripHead.Text = "toolStrip1";
            // 
            // toolStripButtonNew
            // 
            toolStripButtonNew.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButtonNew.Enabled = false;
            toolStripButtonNew.Image = Properties.Resources.icons8_документ_50;
            toolStripButtonNew.ImageTransparentColor = Color.Magenta;
            toolStripButtonNew.Name = "toolStripButtonNew";
            toolStripButtonNew.Size = new Size(28, 28);
            toolStripButtonNew.Text = "Новый";
            // 
            // toolStripButtonDouble
            // 
            toolStripButtonDouble.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButtonDouble.Enabled = false;
            toolStripButtonDouble.Image = Properties.Resources.icons8_скопировать_50;
            toolStripButtonDouble.ImageTransparentColor = Color.Magenta;
            toolStripButtonDouble.Name = "toolStripButtonDouble";
            toolStripButtonDouble.Size = new Size(28, 28);
            toolStripButtonDouble.Text = "Дублировать";
            // 
            // toolStripButtonEdit
            // 
            toolStripButtonEdit.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButtonEdit.Image = Properties.Resources.icons8_редактирование_файла_50;
            toolStripButtonEdit.ImageTransparentColor = Color.Magenta;
            toolStripButtonEdit.Name = "toolStripButtonEdit";
            toolStripButtonEdit.Size = new Size(28, 28);
            toolStripButtonEdit.Text = "Редактировать";
            // 
            // toolStripButtonDelete
            // 
            toolStripButtonDelete.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButtonDelete.Enabled = false;
            toolStripButtonDelete.Image = Properties.Resources.icons8_удалить_файл_50;
            toolStripButtonDelete.ImageTransparentColor = Color.Magenta;
            toolStripButtonDelete.Name = "toolStripButtonDelete";
            toolStripButtonDelete.Size = new Size(28, 28);
            toolStripButtonDelete.Text = "Удалить";
            // 
            // toolStripButtonRefresh
            // 
            toolStripButtonRefresh.Alignment = ToolStripItemAlignment.Right;
            toolStripButtonRefresh.Image = Properties.Resources.icons8_refresh_50;
            toolStripButtonRefresh.ImageTransparentColor = Color.Magenta;
            toolStripButtonRefresh.Name = "toolStripButtonRefresh";
            toolStripButtonRefresh.Size = new Size(89, 28);
            toolStripButtonRefresh.Text = "Обновить";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 31);
            // 
            // managerControl1
            // 
            managerControl1.Location = new Point(5, 176);
            managerControl1.MinimumSize = new Size(575, 84);
            managerControl1.Name = "managerControl1";
            managerControl1.Size = new Size(889, 84);
            managerControl1.TabIndex = 6;
            // 
            // sumContractControl1
            // 
            sumContractControl1.Location = new Point(614, 34);
            sumContractControl1.MinimumSize = new Size(277, 136);
            sumContractControl1.Name = "sumContractControl1";
            sumContractControl1.Size = new Size(277, 136);
            sumContractControl1.TabIndex = 1;
            // 
            // c1DockingTabPageProperties
            // 
            c1DockingTabPageProperties.Controls.Add(propertiesControl1);
            c1DockingTabPageProperties.Location = new Point(1, 27);
            c1DockingTabPageProperties.Name = "c1DockingTabPageProperties";
            c1DockingTabPageProperties.Size = new Size(894, 264);
            c1DockingTabPageProperties.TabIndex = 1;
            c1DockingTabPageProperties.Text = "Дополнительные параметры";
            // 
            // propertiesControl1
            // 
            propertiesControl1.Dock = DockStyle.Fill;
            propertiesControl1.Location = new Point(0, 0);
            propertiesControl1.Name = "propertiesControl1";
            propertiesControl1.Size = new Size(894, 264);
            propertiesControl1.TabIndex = 0;
            // 
            // c1DockingTabPageHistory
            // 
            c1DockingTabPageHistory.Controls.Add(historyContractControl);
            c1DockingTabPageHistory.Location = new Point(1, 27);
            c1DockingTabPageHistory.Name = "c1DockingTabPageHistory";
            c1DockingTabPageHistory.Size = new Size(894, 264);
            c1DockingTabPageHistory.TabIndex = 2;
            c1DockingTabPageHistory.Text = "История";
            // 
            // historyContractControl
            // 
            historyContractControl.Location = new Point(25, 30);
            historyContractControl.Name = "historyContractControl";
            historyContractControl.Size = new Size(835, 184);
            historyContractControl.TabIndex = 0;
            // 
            // c1SplitterPanelSpecification
            // 
            c1SplitterPanelSpecification.Collapsible = true;
            c1SplitterPanelSpecification.Controls.Add(c1DockingTab1);
            c1SplitterPanelSpecification.Dock = C1.Win.SplitContainer.PanelDockStyle.Bottom;
            c1SplitterPanelSpecification.Height = 298;
            c1SplitterPanelSpecification.Location = new Point(0, 345);
            c1SplitterPanelSpecification.Name = "c1SplitterPanelSpecification";
            c1SplitterPanelSpecification.Size = new Size(896, 277);
            c1SplitterPanelSpecification.TabIndex = 0;
            c1SplitterPanelSpecification.Text = "Спецификации";
            // 
            // c1DockingTab1
            // 
            c1DockingTab1.Controls.Add(c1DockingTabPageSpecification);
            c1DockingTab1.Dock = DockStyle.Fill;
            c1DockingTab1.Location = new Point(0, 0);
            c1DockingTab1.Name = "c1DockingTab1";
            c1DockingTab1.Size = new Size(896, 277);
            c1DockingTab1.TabIndex = 7;
            // 
            // c1DockingTabPageSpecification
            // 
            c1DockingTabPageSpecification.Controls.Add(smartGrid1);
            c1DockingTabPageSpecification.Controls.Add(toolStripLines);
            c1DockingTabPageSpecification.Location = new Point(1, 27);
            c1DockingTabPageSpecification.Name = "c1DockingTabPageSpecification";
            c1DockingTabPageSpecification.Size = new Size(894, 249);
            c1DockingTabPageSpecification.TabIndex = 0;
            c1DockingTabPageSpecification.Text = "Спецификация";
            // 
            // smartGrid1
            // 
            smartGrid1.AllowMergingFixed = C1.Win.FlexGrid.AllowMergingEnum.FixedOnly;
            smartGrid1.AllowNodeMove = false;
            smartGrid1.AutoGenerateColumns = false;
            smartGrid1.ColumnInfo = resources.GetString("smartGrid1.ColumnInfo");
            smartGrid1.Dock = DockStyle.Fill;
            smartGrid1.DrawMode = C1.Win.FlexGrid.DrawModeEnum.OwnerDraw;
            aggregateDefinition1.Aggregate = C1.Win.FlexGrid.AggregateEnum.Count;
            aggregateDefinition1.Caption = "Всего: ";
            aggregateDefinition1.Column = 2;
            footerDescription1.Aggregates.Add(aggregateDefinition1);
            smartGrid1.Footers.Descriptions.Add(footerDescription1);
            smartGrid1.Footers.Fixed = true;
            smartGrid1.Headers = new string[]
    {
    "Id\tНомер\tНаименование\tЕд.изм.\tКол-во\tРеализация\tРеализация\tНДС\tНДС\tСумма с НДС",
    "Id\tНомер\tНаименование\tЕд.изм.\tКол-во\tЦена\tСумма\t%\tСумма\tСумма с НДС",
    "Id\tНомер\tНаименование\tЕд.изм.\tКол-во\tЦена\tСумма\t%\tСумма\tСумма с НДС"
    };
            smartGrid1.IdName = null;
            smartGrid1.IsEditing = false;
            smartGrid1.Location = new Point(0, 31);
            smartGrid1.Name = "smartGrid1";
            smartGrid1.Rows.Count = 16;
            smartGrid1.Rows.Fixed = 3;
            smartGrid1.SelectedRows = (List<int>)resources.GetObject("smartGrid1.SelectedRows");
            smartGrid1.SelectionMode = C1.Win.FlexGrid.SelectionModeEnum.Row;
            smartGrid1.Size = new Size(894, 218);
            smartGrid1.SortingType = SmartGrid.SortingType.Descending;
            smartGrid1.StyleInfo = resources.GetString("smartGrid1.StyleInfo");
            smartGrid1.TabIndex = 6;
            // 
            // toolStripLines
            // 
            toolStripLines.ImageScalingSize = new Size(24, 24);
            toolStripLines.Items.AddRange(new ToolStripItem[] { toolStripButton1, toolStripButton2, toolStripButton3, toolStripButton4, toolStripButton5, toolStripSeparator2, toolStripButtonSetupSpecification });
            toolStripLines.Location = new Point(0, 0);
            toolStripLines.Name = "toolStripLines";
            toolStripLines.Size = new Size(894, 31);
            toolStripLines.TabIndex = 5;
            toolStripLines.Text = "toolStrip2";
            // 
            // toolStripButton1
            // 
            toolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton1.Image = Properties.Resources.icons8_документ_50;
            toolStripButton1.ImageTransparentColor = Color.Magenta;
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Size = new Size(28, 28);
            toolStripButton1.Text = "Новый";
            // 
            // toolStripButton2
            // 
            toolStripButton2.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton2.Image = Properties.Resources.icons8_скопировать_50;
            toolStripButton2.ImageTransparentColor = Color.Magenta;
            toolStripButton2.Name = "toolStripButton2";
            toolStripButton2.Size = new Size(28, 28);
            toolStripButton2.Text = "Дублировать";
            // 
            // toolStripButton3
            // 
            toolStripButton3.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton3.Image = Properties.Resources.icons8_редактирование_файла_50;
            toolStripButton3.ImageTransparentColor = Color.Magenta;
            toolStripButton3.Name = "toolStripButton3";
            toolStripButton3.Size = new Size(28, 28);
            toolStripButton3.Text = "Редактировать";
            // 
            // toolStripButton4
            // 
            toolStripButton4.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton4.Image = Properties.Resources.icons8_удалить_файл_50;
            toolStripButton4.ImageTransparentColor = Color.Magenta;
            toolStripButton4.Name = "toolStripButton4";
            toolStripButton4.Size = new Size(28, 28);
            toolStripButton4.Text = "Удалить";
            // 
            // toolStripButton5
            // 
            toolStripButton5.Alignment = ToolStripItemAlignment.Right;
            toolStripButton5.Image = Properties.Resources.icons8_refresh_50;
            toolStripButton5.ImageTransparentColor = Color.Magenta;
            toolStripButton5.Name = "toolStripButton5";
            toolStripButton5.Size = new Size(89, 28);
            toolStripButton5.Text = "Обновить";
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 31);
            // 
            // toolStripButtonSetupSpecification
            // 
            toolStripButtonSetupSpecification.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButtonSetupSpecification.Image = Properties.Resources.icons8_настройка_проекта_50;
            toolStripButtonSetupSpecification.ImageTransparentColor = Color.Magenta;
            toolStripButtonSetupSpecification.Name = "toolStripButtonSetupSpecification";
            toolStripButtonSetupSpecification.Size = new Size(28, 28);
            toolStripButtonSetupSpecification.Text = "Настройка";
            toolStripButtonSetupSpecification.Click += toolStripButtonSetupSpecification_Click;
            // 
            // panelOk
            // 
            panelOk.BorderStyle = BorderStyle.FixedSingle;
            panelOk.Controls.Add(buttonOk);
            panelOk.Controls.Add(buttonCancel);
            panelOk.Dock = DockStyle.Bottom;
            panelOk.Location = new Point(0, 622);
            panelOk.Name = "panelOk";
            panelOk.Size = new Size(896, 32);
            panelOk.TabIndex = 0;
            // 
            // buttonOk
            // 
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonOk.Location = new Point(816, 4);
            buttonOk.Name = "buttonOk";
            buttonOk.Size = new Size(75, 23);
            buttonOk.TabIndex = 0;
            buttonOk.Text = "Ok";
            buttonOk.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Location = new Point(735, 4);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 23);
            buttonCancel.TabIndex = 1;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(c1SplitContainer1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(896, 622);
            panel1.TabIndex = 3;
            // 
            // ContractStandartForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(896, 654);
            Controls.Add(panel1);
            Controls.Add(panelOk);
            MinimumSize = new Size(880, 633);
            Name = "ContractStandartForm";
            Text = "Контракт (обычная купля-продажа)";
            Load += ContractStandartForm_Load;
            ((System.ComponentModel.ISupportInitialize)c1SplitContainer1).EndInit();
            c1SplitContainer1.ResumeLayout(false);
            c1SplitterPanelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)c1DockingTab2).EndInit();
            c1DockingTab2.ResumeLayout(false);
            c1DockingTabPageMain.ResumeLayout(false);
            c1DockingTabPageMain.PerformLayout();
            toolStripHead.ResumeLayout(false);
            toolStripHead.PerformLayout();
            c1DockingTabPageProperties.ResumeLayout(false);
            c1DockingTabPageHistory.ResumeLayout(false);
            c1SplitterPanelSpecification.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)c1DockingTab1).EndInit();
            c1DockingTab1.ResumeLayout(false);
            c1DockingTabPageSpecification.ResumeLayout(false);
            c1DockingTabPageSpecification.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)smartGrid1).EndInit();
            toolStripLines.ResumeLayout(false);
            toolStripLines.PerformLayout();
            panelOk.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private C1.Win.SplitContainer.C1SplitContainer c1SplitContainer1;
        private C1.Win.SplitContainer.C1SplitterPanel c1SplitterPanelMain;
        private C1.Win.SplitContainer.C1SplitterPanel c1SplitterPanelSpecification;
        private HeadContractControl headContractControl;
        private SumContractControl sumContractControl1;
        private ToolStrip toolStripHead;
        private ToolStripButton toolStripButtonNew;
        private ToolStripButton toolStripButtonDouble;
        private ToolStripButton toolStripButtonEdit;
        private ToolStripButton toolStripButtonDelete;
        private ToolStripButton toolStripButtonRefresh;
        private ToolStripSeparator toolStripSeparator1;
        private ManagerControl managerControl1;
        private Panel panelOk;
        private Button buttonCancel;
        private Button buttonOk;
        private ToolStrip toolStripLines;
        private ToolStripButton toolStripButton1;
        private ToolStripButton toolStripButton2;
        private ToolStripButton toolStripButton3;
        private ToolStripButton toolStripButton4;
        private ToolStripButton toolStripButton5;
        private ToolStripSeparator toolStripSeparator2;
        private C1.Win.Command.C1DockingTab c1DockingTab1;
        private C1.Win.Command.C1DockingTabPage c1DockingTabPageSpecification;
        private SmartGrid.SmartGrid smartGrid1;
        private Panel panel1;
        private ToolStripButton toolStripButtonSetupSpecification;
        private C1.Win.Command.C1DockingTabPage c1DockingTabPageProperies;
        private Contracts.Controls.PropertiesControl propertiesControl1;
        private C1.Win.Command.C1DockingTab c1DockingTab2;
        private C1.Win.Command.C1DockingTabPage c1DockingTabPageMain;
        private C1.Win.Command.C1DockingTabPage c1DockingTabPageProperties;
        private C1.Win.Command.C1DockingTabPage c1DockingTabPageHistory;
        private Contracts.Controls.HistoryContractControl historyContractControl;
    }
}