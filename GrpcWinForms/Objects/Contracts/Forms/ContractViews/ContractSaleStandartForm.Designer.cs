using GrpcWinForms.Objects.Contracts.Forms.Controls;
using GrpcWinForms.Objects.Contracts.Models;

namespace GrpcWinForms.Objects.Contracts.Forms.ContractViews
{
    partial class ContractSaleStandartForm 
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContractSaleStandartForm));
            C1.Win.FlexGrid.FooterDescription footerDescription2 = new C1.Win.FlexGrid.FooterDescription();
            C1.Win.FlexGrid.AggregateDefinition aggregateDefinition5 = new C1.Win.FlexGrid.AggregateDefinition();
            C1.Win.FlexGrid.AggregateDefinition aggregateDefinition6 = new C1.Win.FlexGrid.AggregateDefinition();
            C1.Win.FlexGrid.AggregateDefinition aggregateDefinition7 = new C1.Win.FlexGrid.AggregateDefinition();
            C1.Win.FlexGrid.AggregateDefinition aggregateDefinition8 = new C1.Win.FlexGrid.AggregateDefinition();
            SmartLib.StringItem stringItem3 = new SmartLib.StringItem();
            SmartLib.StringItem stringItem4 = new SmartLib.StringItem();
            splitContainerAll = new C1.Win.SplitContainer.C1SplitContainer();
            c1SplitterPanelMain = new C1.Win.SplitContainer.C1SplitterPanel();
            buttonOk = new Button();
            headContractControl = new HeadContractControl();
            buttonCancel = new Button();
            managerControl1 = new ManagerControl();
            sumContractControl1 = new SumContractControl();
            toolStripHead = new ToolStrip();
            toolStripButtonNew = new ToolStripButton();
            toolStripButtonDouble = new ToolStripButton();
            toolStripButtonEdit = new ToolStripButton();
            toolStripButtonDelete = new ToolStripButton();
            toolStripButtonRefresh = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            c1SplitterPanelSpecification = new C1.Win.SplitContainer.C1SplitterPanel();
            c1DockingTab1 = new C1.Win.Command.C1DockingTab();
            c1DockingTabPageSpecification = new C1.Win.Command.C1DockingTabPage();
            smartGridLines1 = new SmartLib.SmartGrid(components);
            toolStripLines = new ToolStrip();
            toolStripButton1 = new ToolStripButton();
            toolStripButton2 = new ToolStripButton();
            toolStripButton3 = new ToolStripButton();
            toolStripButton4 = new ToolStripButton();
            toolStripButton5 = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            toolStripButtonSetupSpecification = new ToolStripButton();
            c1DockingTab2 = new C1.Win.Command.C1DockingTab();
            c1DockingTabPageMain = new C1.Win.Command.C1DockingTabPage();
            c1DockingTabPageProperties = new C1.Win.Command.C1DockingTabPage();
            propertiesControl1 = new GrpcWinForms.Objects.Contracts.Controls.PropertiesControl();
            c1DockingTabPageHistory = new C1.Win.Command.C1DockingTabPage();
            historyContractControl = new GrpcWinForms.Objects.Contracts.Controls.HistoryContractControl();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)splitContainerAll).BeginInit();
            splitContainerAll.SuspendLayout();
            c1SplitterPanelMain.SuspendLayout();
            toolStripHead.SuspendLayout();
            c1SplitterPanelSpecification.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)c1DockingTab1).BeginInit();
            c1DockingTab1.SuspendLayout();
            c1DockingTabPageSpecification.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)smartGridLines1).BeginInit();
            toolStripLines.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)c1DockingTab2).BeginInit();
            c1DockingTab2.SuspendLayout();
            c1DockingTabPageMain.SuspendLayout();
            c1DockingTabPageProperties.SuspendLayout();
            c1DockingTabPageHistory.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainerAll
            // 
            splitContainerAll.AutoSizeElement = C1.Framework.AutoSizeElement.Both;
            splitContainerAll.Dock = DockStyle.Fill;
            splitContainerAll.HeaderButtonBackColor = Color.Transparent;
            splitContainerAll.Location = new Point(0, 0);
            splitContainerAll.Name = "splitContainerAll";
            splitContainerAll.Panels.Add(c1SplitterPanelMain);
            splitContainerAll.Panels.Add(c1SplitterPanelSpecification);
            splitContainerAll.Size = new Size(1068, 626);
            splitContainerAll.TabIndex = 2;
            // 
            // c1SplitterPanelMain
            // 
            c1SplitterPanelMain.Collapsible = true;
            c1SplitterPanelMain.Controls.Add(buttonOk);
            c1SplitterPanelMain.Controls.Add(headContractControl);
            c1SplitterPanelMain.Controls.Add(buttonCancel);
            c1SplitterPanelMain.Controls.Add(managerControl1);
            c1SplitterPanelMain.Controls.Add(sumContractControl1);
            c1SplitterPanelMain.Controls.Add(toolStripHead);
            c1SplitterPanelMain.Height = 320;
            c1SplitterPanelMain.KeepRelativeSize = false;
            c1SplitterPanelMain.Location = new Point(0, 21);
            c1SplitterPanelMain.MinHeight = 320;
            c1SplitterPanelMain.MinWidth = 800;
            c1SplitterPanelMain.Name = "c1SplitterPanelMain";
            c1SplitterPanelMain.Size = new Size(1068, 292);
            c1SplitterPanelMain.SizeRatio = 51.78D;
            c1SplitterPanelMain.TabIndex = 1;
            c1SplitterPanelMain.Text = "Общие данные";
            c1SplitterPanelMain.Width = 1068;
            // 
            // buttonOk
            // 
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonOk.Location = new Point(982, 266);
            buttonOk.Name = "buttonOk";
            buttonOk.Size = new Size(75, 23);
            buttonOk.TabIndex = 0;
            buttonOk.Text = "Ok";
            buttonOk.UseVisualStyleBackColor = true;
            buttonOk.Click += buttonOk_Click;
            // 
            // headContractControl
            // 
            headContractControl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            headContractControl.Location = new Point(3, 34);
            headContractControl.MinimumSize = new Size(575, 136);
            headContractControl.Name = "headContractControl";
            headContractControl.Size = new Size(781, 136);
            headContractControl.TabIndex = 0;
            // 
            // buttonCancel
            // 
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Location = new Point(901, 266);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 23);
            buttonCancel.TabIndex = 1;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // managerControl1
            // 
            managerControl1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            managerControl1.Contract = null;
            managerControl1.Location = new Point(3, 176);
            managerControl1.MinimumSize = new Size(575, 84);
            managerControl1.Name = "managerControl1";
            managerControl1.Size = new Size(781, 84);
            managerControl1.TabIndex = 6;
            // 
            // sumContractControl1
            // 
            sumContractControl1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            sumContractControl1.Location = new Point(787, 34);
            sumContractControl1.MinimumSize = new Size(277, 136);
            sumContractControl1.Name = "sumContractControl1";
            sumContractControl1.Size = new Size(277, 136);
            sumContractControl1.TabIndex = 1;
            // 
            // toolStripHead
            // 
            toolStripHead.ImageScalingSize = new Size(24, 24);
            toolStripHead.Items.AddRange(new ToolStripItem[] { toolStripButtonNew, toolStripButtonDouble, toolStripButtonEdit, toolStripButtonDelete, toolStripButtonRefresh, toolStripSeparator1 });
            toolStripHead.Location = new Point(0, 0);
            toolStripHead.Name = "toolStripHead";
            toolStripHead.Size = new Size(1068, 31);
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
            // c1SplitterPanelSpecification
            // 
            c1SplitterPanelSpecification.Collapsible = true;
            c1SplitterPanelSpecification.Controls.Add(c1DockingTab1);
            c1SplitterPanelSpecification.Dock = C1.Win.SplitContainer.PanelDockStyle.Bottom;
            c1SplitterPanelSpecification.Height = 302;
            c1SplitterPanelSpecification.Location = new Point(0, 345);
            c1SplitterPanelSpecification.Name = "c1SplitterPanelSpecification";
            c1SplitterPanelSpecification.Size = new Size(1068, 281);
            c1SplitterPanelSpecification.TabIndex = 0;
            c1SplitterPanelSpecification.Text = "Спецификации";
            // 
            // c1DockingTab1
            // 
            c1DockingTab1.Controls.Add(c1DockingTabPageSpecification);
            c1DockingTab1.Dock = DockStyle.Fill;
            c1DockingTab1.Location = new Point(0, 0);
            c1DockingTab1.Name = "c1DockingTab1";
            c1DockingTab1.Size = new Size(1068, 281);
            c1DockingTab1.TabIndex = 7;
            // 
            // c1DockingTabPageSpecification
            // 
            c1DockingTabPageSpecification.Controls.Add(smartGridLines1);
            c1DockingTabPageSpecification.Controls.Add(toolStripLines);
            c1DockingTabPageSpecification.Location = new Point(1, 27);
            c1DockingTabPageSpecification.Name = "c1DockingTabPageSpecification";
            c1DockingTabPageSpecification.Size = new Size(1066, 253);
            c1DockingTabPageSpecification.TabIndex = 0;
            c1DockingTabPageSpecification.Text = "Спецификация";
            // 
            // smartGridLines1
            // 
            smartGridLines1.AllowEditing = false;
            smartGridLines1.AllowMerging = C1.Win.FlexGrid.AllowMergingEnum.FixedOnly;
            smartGridLines1.AllowMergingFixed = C1.Win.FlexGrid.AllowMergingEnum.FixedOnly;
            smartGridLines1.AllowNodeMove = false;
            smartGridLines1.AutoGenerateColumns = false;
            smartGridLines1.ColumnInfo = resources.GetString("smartGridLines1.ColumnInfo");
            smartGridLines1.Dock = DockStyle.Fill;
            smartGridLines1.DrawMode = C1.Win.FlexGrid.DrawModeEnum.OwnerDraw;
            aggregateDefinition5.Aggregate = C1.Win.FlexGrid.AggregateEnum.Count;
            aggregateDefinition5.Caption = "Всего: ";
            aggregateDefinition5.Column = 2;
            aggregateDefinition6.Aggregate = C1.Win.FlexGrid.AggregateEnum.Sum;
            aggregateDefinition6.Column = 7;
            aggregateDefinition7.Aggregate = C1.Win.FlexGrid.AggregateEnum.Sum;
            aggregateDefinition7.Column = 9;
            aggregateDefinition8.Aggregate = C1.Win.FlexGrid.AggregateEnum.Sum;
            aggregateDefinition8.Column = 10;
            footerDescription2.Aggregates.Add(aggregateDefinition5);
            footerDescription2.Aggregates.Add(aggregateDefinition6);
            footerDescription2.Aggregates.Add(aggregateDefinition7);
            footerDescription2.Aggregates.Add(aggregateDefinition8);
            smartGridLines1.Footers.Descriptions.Add(footerDescription2);
            smartGridLines1.Footers.Fixed = true;
            stringItem3.Name = "Заголовок 1";
            stringItem3.Value = "...;Номер;Наименование;ИПКУ;Ед.изм.;Кол-во;Реализация;Реализация;НДС;НДС;Сумма с НДС;Операция";
            stringItem4.Name = "Заголовок 2";
            stringItem4.Value = "...;Номер;Наименование;ИПКУ;Ед.изм.;Кол-во;Цена;Сумма;%;Сумма;Сумма с НДС;Операция";
            smartGridLines1.Headers.Add(stringItem3);
            smartGridLines1.Headers.Add(stringItem4);
            smartGridLines1.IdName = null;
            smartGridLines1.Location = new Point(0, 31);
            smartGridLines1.Name = "smartGridLines1";
            smartGridLines1.Rows.Count = 51;
            smartGridLines1.Rows.Fixed = 2;
            smartGridLines1.SelectedRows = (List<int>)resources.GetObject("smartGridLines1.SelectedRows");
            smartGridLines1.SelectionMode = C1.Win.FlexGrid.SelectionModeEnum.Row;
            smartGridLines1.Size = new Size(1066, 222);
            smartGridLines1.SortingType = SmartLib.SortingType.Descending;
            smartGridLines1.StyleInfo = resources.GetString("smartGridLines1.StyleInfo");
            smartGridLines1.TabIndex = 7;
            smartGridLines1.GetUnboundValue += smartGridLines_GetUnboundValue;
            smartGridLines1.OwnerDrawCell += smartGridLines1_OwnerDrawCell;
            // 
            // toolStripLines
            // 
            toolStripLines.ImageScalingSize = new Size(24, 24);
            toolStripLines.Items.AddRange(new ToolStripItem[] { toolStripButton1, toolStripButton2, toolStripButton3, toolStripButton4, toolStripButton5, toolStripSeparator2, toolStripButtonSetupSpecification });
            toolStripLines.Location = new Point(0, 0);
            toolStripLines.Name = "toolStripLines";
            toolStripLines.Size = new Size(1066, 31);
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
            // c1DockingTab2
            // 
            c1DockingTab2.Controls.Add(c1DockingTabPageMain);
            c1DockingTab2.Controls.Add(c1DockingTabPageProperties);
            c1DockingTab2.Controls.Add(c1DockingTabPageHistory);
            c1DockingTab2.Dock = DockStyle.Fill;
            c1DockingTab2.Location = new Point(0, 0);
            c1DockingTab2.Name = "c1DockingTab2";
            c1DockingTab2.Size = new Size(1070, 654);
            c1DockingTab2.TabIndex = 7;
            c1DockingTab2.SelectedIndexChanged += c1DockingTab2_SelectedIndexChanged;
            // 
            // c1DockingTabPageMain
            // 
            c1DockingTabPageMain.Controls.Add(splitContainerAll);
            c1DockingTabPageMain.Location = new Point(1, 27);
            c1DockingTabPageMain.Name = "c1DockingTabPageMain";
            c1DockingTabPageMain.Size = new Size(1068, 626);
            c1DockingTabPageMain.TabIndex = 0;
            c1DockingTabPageMain.Text = "Основное";
            // 
            // c1DockingTabPageProperties
            // 
            c1DockingTabPageProperties.Controls.Add(propertiesControl1);
            c1DockingTabPageProperties.Location = new Point(1, 27);
            c1DockingTabPageProperties.Name = "c1DockingTabPageProperties";
            c1DockingTabPageProperties.Size = new Size(1068, 626);
            c1DockingTabPageProperties.TabIndex = 1;
            c1DockingTabPageProperties.Text = "Дополнительные параметры";
            // 
            // propertiesControl1
            // 
            propertiesControl1.Dock = DockStyle.Fill;
            propertiesControl1.Location = new Point(0, 0);
            propertiesControl1.Name = "propertiesControl1";
            propertiesControl1.Size = new Size(1068, 626);
            propertiesControl1.TabIndex = 0;
            // 
            // c1DockingTabPageHistory
            // 
            c1DockingTabPageHistory.Controls.Add(historyContractControl);
            c1DockingTabPageHistory.Location = new Point(1, 27);
            c1DockingTabPageHistory.Name = "c1DockingTabPageHistory";
            c1DockingTabPageHistory.Size = new Size(1068, 626);
            c1DockingTabPageHistory.TabIndex = 2;
            c1DockingTabPageHistory.Text = "История";
            // 
            // historyContractControl
            // 
            historyContractControl.Dock = DockStyle.Fill;
            historyContractControl.Location = new Point(0, 0);
            historyContractControl.Name = "historyContractControl";
            historyContractControl.Size = new Size(1068, 626);
            historyContractControl.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(c1DockingTab2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1070, 654);
            panel1.TabIndex = 3;
            // 
            // ContractSaleStandartForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1070, 654);
            Controls.Add(panel1);
            MinimumSize = new Size(880, 633);
            Name = "ContractSaleStandartForm";
            Text = "Контракт (обычная купля-продажа)";
            Load += ContractStandartForm_Load;
            ((System.ComponentModel.ISupportInitialize)splitContainerAll).EndInit();
            splitContainerAll.ResumeLayout(false);
            c1SplitterPanelMain.ResumeLayout(false);
            c1SplitterPanelMain.PerformLayout();
            toolStripHead.ResumeLayout(false);
            toolStripHead.PerformLayout();
            c1SplitterPanelSpecification.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)c1DockingTab1).EndInit();
            c1DockingTab1.ResumeLayout(false);
            c1DockingTabPageSpecification.ResumeLayout(false);
            c1DockingTabPageSpecification.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)smartGridLines1).EndInit();
            toolStripLines.ResumeLayout(false);
            toolStripLines.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)c1DockingTab2).EndInit();
            c1DockingTab2.ResumeLayout(false);
            c1DockingTabPageMain.ResumeLayout(false);
            c1DockingTabPageProperties.ResumeLayout(false);
            c1DockingTabPageHistory.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion

        private C1.Win.SplitContainer.C1SplitContainer splitContainerAll;
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
        private Panel panel1;
        private ToolStripButton toolStripButtonSetupSpecification;
        private C1.Win.Command.C1DockingTabPage c1DockingTabPageProperies;
        private Contracts.Controls.PropertiesControl propertiesControl1;
        private C1.Win.Command.C1DockingTab c1DockingTab2;
        private C1.Win.Command.C1DockingTabPage c1DockingTabPageMain;
        private C1.Win.Command.C1DockingTabPage c1DockingTabPageProperties;
        private C1.Win.Command.C1DockingTabPage c1DockingTabPageHistory;
        private Contracts.Controls.HistoryContractControl historyContractControl;
        private SmartLib.SmartGrid smartGridLines1;
    }
}