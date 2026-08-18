namespace GrpcWinForms.Objects.Users.Forms
{
    partial class UsersForm
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
            C1.Win.Input.ComboBoxItem comboBoxItem1 = new C1.Win.Input.ComboBoxItem();
            C1.Win.Input.ComboBoxItem comboBoxItem2 = new C1.Win.Input.ComboBoxItem();
            C1.Win.Input.ComboBoxItem comboBoxItem3 = new C1.Win.Input.ComboBoxItem();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UsersForm));
            C1.Win.FlexGrid.FooterDescription footerDescription1 = new C1.Win.FlexGrid.FooterDescription();
            C1.Win.FlexGrid.AggregateDefinition aggregateDefinition1 = new C1.Win.FlexGrid.AggregateDefinition();
            SmartLib.StringItem stringItem1 = new SmartLib.StringItem();
            C1.Win.FlexGrid.FooterDescription footerDescription2 = new C1.Win.FlexGrid.FooterDescription();
            C1.Win.FlexGrid.AggregateDefinition aggregateDefinition2 = new C1.Win.FlexGrid.AggregateDefinition();
            SmartLib.StringItem stringItem2 = new SmartLib.StringItem();
            panel1 = new Panel();
            c1ComboBoxIsBlocked = new C1.Win.Input.C1ComboBox();
            labelIsBlocked = new Label();
            textBoxApp = new TextBox();
            labelApp = new Label();
            labelUserName = new Label();
            textAbbrev = new TextBox();
            c1SplitContainer1 = new C1.Win.SplitContainer.C1SplitContainer();
            c1SplitterPanelApps = new C1.Win.SplitContainer.C1SplitterPanel();
            smartGridApps1 = new SmartLib.SmartGrid(components);
            toolStripRates = new ToolStrip();
            toolStripButtonAppNew = new ToolStripButton();
            toolStripButtonAppDouble = new ToolStripButton();
            toolStripButtonAppEdit = new ToolStripButton();
            toolStripButtonAppDelete = new ToolStripButton();
            toolStripButtonAppRefresh = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            c1SplitterPanelUsers = new C1.Win.SplitContainer.C1SplitterPanel();
            smartGridUsers1 = new SmartLib.SmartGrid(components);
            toolStripCurrencies = new ToolStrip();
            toolStripButtonUserNew = new ToolStripButton();
            toolStripButtonUserDouble = new ToolStripButton();
            toolStripButtonUserEdit = new ToolStripButton();
            toolStripButtonUserDelete = new ToolStripButton();
            toolStripButtonUserRefresh = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            applicationBindingSource = new BindingSource(components);
            userBindingSource = new BindingSource(components);
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)c1ComboBoxIsBlocked).BeginInit();
            ((System.ComponentModel.ISupportInitialize)c1SplitContainer1).BeginInit();
            c1SplitContainer1.SuspendLayout();
            c1SplitterPanelApps.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)smartGridApps1).BeginInit();
            toolStripRates.SuspendLayout();
            c1SplitterPanelUsers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)smartGridUsers1).BeginInit();
            toolStripCurrencies.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)applicationBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)userBindingSource).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(c1ComboBoxIsBlocked);
            panel1.Controls.Add(labelIsBlocked);
            panel1.Controls.Add(textBoxApp);
            panel1.Controls.Add(labelApp);
            panel1.Controls.Add(labelUserName);
            panel1.Controls.Add(textAbbrev);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1114, 34);
            panel1.TabIndex = 1;
            // 
            // c1ComboBoxIsBlocked
            // 
            comboBoxItem1.DisplayText = "Все";
            comboBoxItem1.Value = "Все";
            comboBoxItem2.DisplayText = "Активные";
            comboBoxItem2.Value = "Активные";
            comboBoxItem3.DisplayText = "Блокированы";
            comboBoxItem3.Value = "Блокированы";
            c1ComboBoxIsBlocked.Items.Add(comboBoxItem1);
            c1ComboBoxIsBlocked.Items.Add(comboBoxItem2);
            c1ComboBoxIsBlocked.Items.Add(comboBoxItem3);
            c1ComboBoxIsBlocked.Location = new Point(620, 6);
            c1ComboBoxIsBlocked.Name = "c1ComboBoxIsBlocked";
            c1ComboBoxIsBlocked.Size = new Size(100, 23);
            c1ComboBoxIsBlocked.TabIndex = 5;
            // 
            // labelIsBlocked
            // 
            labelIsBlocked.AutoSize = true;
            labelIsBlocked.Location = new Point(574, 9);
            labelIsBlocked.Name = "labelIsBlocked";
            labelIsBlocked.Size = new Size(40, 15);
            labelIsBlocked.TabIndex = 4;
            labelIsBlocked.Text = "Блок.:";
            // 
            // textBoxApp
            // 
            textBoxApp.Location = new Point(395, 6);
            textBoxApp.Name = "textBoxApp";
            textBoxApp.Size = new Size(173, 23);
            textBoxApp.TabIndex = 3;
            // 
            // labelApp
            // 
            labelApp.AutoSize = true;
            labelApp.Location = new Point(307, 10);
            labelApp.Name = "labelApp";
            labelApp.Size = new Size(82, 15);
            labelApp.TabIndex = 2;
            labelApp.Text = "Приложение:";
            // 
            // labelUserName
            // 
            labelUserName.AutoSize = true;
            labelUserName.Location = new Point(20, 10);
            labelUserName.Name = "labelUserName";
            labelUserName.Size = new Size(84, 15);
            labelUserName.TabIndex = 1;
            labelUserName.Text = "Пользователь";
            // 
            // textAbbrev
            // 
            textAbbrev.Location = new Point(110, 6);
            textAbbrev.Name = "textAbbrev";
            textAbbrev.PlaceholderText = "Логин или Краткое имя";
            textAbbrev.Size = new Size(191, 23);
            textAbbrev.TabIndex = 0;
            // 
            // c1SplitContainer1
            // 
            c1SplitContainer1.AutoSizeElement = C1.Framework.AutoSizeElement.Both;
            c1SplitContainer1.BorderWidth = 1;
            c1SplitContainer1.Dock = DockStyle.Fill;
            c1SplitContainer1.HeaderButtonBackColor = Color.Transparent;
            c1SplitContainer1.Location = new Point(0, 34);
            c1SplitContainer1.Name = "c1SplitContainer1";
            c1SplitContainer1.Panels.Add(c1SplitterPanelApps);
            c1SplitContainer1.Panels.Add(c1SplitterPanelUsers);
            c1SplitContainer1.Size = new Size(1114, 416);
            c1SplitContainer1.TabIndex = 2;
            // 
            // c1SplitterPanelApps
            // 
            c1SplitterPanelApps.Collapsible = true;
            c1SplitterPanelApps.Controls.Add(smartGridApps1);
            c1SplitterPanelApps.Controls.Add(toolStripRates);
            c1SplitterPanelApps.Dock = C1.Win.SplitContainer.PanelDockStyle.Right;
            c1SplitterPanelApps.KeepRelativeSize = false;
            c1SplitterPanelApps.Location = new Point(608, 22);
            c1SplitterPanelApps.Name = "c1SplitterPanelApps";
            c1SplitterPanelApps.Size = new Size(505, 393);
            c1SplitterPanelApps.SizeRatio = 44.991D;
            c1SplitterPanelApps.TabIndex = 0;
            c1SplitterPanelApps.Text = "Приложения";
            c1SplitterPanelApps.Width = 512;
            // 
            // smartGridApps1
            // 
            smartGridApps1.AllowMerging = C1.Win.FlexGrid.AllowMergingEnum.FixedOnly;
            smartGridApps1.AllowMergingFixed = C1.Win.FlexGrid.AllowMergingEnum.FixedOnly;
            smartGridApps1.AllowNodeMove = false;
            smartGridApps1.AutoGenerateColumns = false;
            smartGridApps1.ColumnInfo = resources.GetString("smartGridApps1.ColumnInfo");
            smartGridApps1.Dock = DockStyle.Fill;
            smartGridApps1.DrawMode = C1.Win.FlexGrid.DrawModeEnum.OwnerDraw;
            aggregateDefinition1.Aggregate = C1.Win.FlexGrid.AggregateEnum.Count;
            aggregateDefinition1.Caption = "Всего: ";
            aggregateDefinition1.Column = 2;
            footerDescription1.Aggregates.Add(aggregateDefinition1);
            smartGridApps1.Footers.Descriptions.Add(footerDescription1);
            smartGridApps1.Footers.Fixed = true;
            stringItem1.Name = "Заголовок 1";
            stringItem1.Value = "...;Id;Наименование приложения;База данных;Код приложения";
            smartGridApps1.Headers.Add(stringItem1);
            smartGridApps1.IdName = null;
            smartGridApps1.Location = new Point(0, 31);
            smartGridApps1.Name = "smartGridApps1";
            smartGridApps1.Rows.Count = 2;
            smartGridApps1.SelectedRows = (List<int>)resources.GetObject("smartGridApps1.SelectedRows");
            smartGridApps1.SelectionMode = C1.Win.FlexGrid.SelectionModeEnum.Row;
            smartGridApps1.Size = new Size(505, 362);
            smartGridApps1.SortingType = SmartLib.SortingType.Descending;
            smartGridApps1.StyleInfo = resources.GetString("smartGridApps1.StyleInfo");
            smartGridApps1.TabIndex = 3;
            smartGridApps1.GetUnboundValue += smartGridApps_GetUnboundValue;
            // 
            // toolStripRates
            // 
            toolStripRates.ImageScalingSize = new Size(24, 24);
            toolStripRates.Items.AddRange(new ToolStripItem[] { toolStripButtonAppNew, toolStripButtonAppDouble, toolStripButtonAppEdit, toolStripButtonAppDelete, toolStripButtonAppRefresh, toolStripSeparator1 });
            toolStripRates.Location = new Point(0, 0);
            toolStripRates.Name = "toolStripRates";
            toolStripRates.Size = new Size(505, 31);
            toolStripRates.TabIndex = 1;
            toolStripRates.Text = "toolStrip1";
            // 
            // toolStripButtonAppNew
            // 
            toolStripButtonAppNew.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButtonAppNew.Image = Properties.Resources.icons8_документ_50;
            toolStripButtonAppNew.ImageTransparentColor = Color.Magenta;
            toolStripButtonAppNew.Name = "toolStripButtonAppNew";
            toolStripButtonAppNew.Size = new Size(28, 28);
            toolStripButtonAppNew.Text = "Новый";
            toolStripButtonAppNew.Click += toolStripButtonAppNew_Click;
            // 
            // toolStripButtonAppDouble
            // 
            toolStripButtonAppDouble.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButtonAppDouble.Enabled = false;
            toolStripButtonAppDouble.Image = Properties.Resources.icons8_скопировать_50;
            toolStripButtonAppDouble.ImageTransparentColor = Color.Magenta;
            toolStripButtonAppDouble.Name = "toolStripButtonAppDouble";
            toolStripButtonAppDouble.Size = new Size(28, 28);
            toolStripButtonAppDouble.Text = "Дублировать";
            // 
            // toolStripButtonAppEdit
            // 
            toolStripButtonAppEdit.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButtonAppEdit.Enabled = false;
            toolStripButtonAppEdit.Image = Properties.Resources.icons8_редактирование_файла_50;
            toolStripButtonAppEdit.ImageTransparentColor = Color.Magenta;
            toolStripButtonAppEdit.Name = "toolStripButtonAppEdit";
            toolStripButtonAppEdit.Size = new Size(28, 28);
            toolStripButtonAppEdit.Text = "Редактировать";
            // 
            // toolStripButtonAppDelete
            // 
            toolStripButtonAppDelete.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButtonAppDelete.Image = Properties.Resources.icons8_удалить_файл_50;
            toolStripButtonAppDelete.ImageTransparentColor = Color.Magenta;
            toolStripButtonAppDelete.Name = "toolStripButtonAppDelete";
            toolStripButtonAppDelete.Size = new Size(28, 28);
            toolStripButtonAppDelete.Text = "Удалить";
            toolStripButtonAppDelete.Click += toolStripButtonAppDelete_Click;
            // 
            // toolStripButtonAppRefresh
            // 
            toolStripButtonAppRefresh.Alignment = ToolStripItemAlignment.Right;
            toolStripButtonAppRefresh.Image = Properties.Resources.icons8_refresh_50;
            toolStripButtonAppRefresh.ImageTransparentColor = Color.Magenta;
            toolStripButtonAppRefresh.Name = "toolStripButtonAppRefresh";
            toolStripButtonAppRefresh.Size = new Size(89, 28);
            toolStripButtonAppRefresh.Text = "Обновить";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 31);
            // 
            // c1SplitterPanelUsers
            // 
            c1SplitterPanelUsers.Controls.Add(smartGridUsers1);
            c1SplitterPanelUsers.Controls.Add(toolStripCurrencies);
            c1SplitterPanelUsers.Height = 414;
            c1SplitterPanelUsers.Location = new Point(1, 22);
            c1SplitterPanelUsers.Name = "c1SplitterPanelUsers";
            c1SplitterPanelUsers.Size = new Size(596, 393);
            c1SplitterPanelUsers.TabIndex = 1;
            c1SplitterPanelUsers.Text = "Пользователи";
            // 
            // smartGridUsers1
            // 
            smartGridUsers1.AllowEditing = false;
            smartGridUsers1.AllowMerging = C1.Win.FlexGrid.AllowMergingEnum.FixedOnly;
            smartGridUsers1.AllowMergingFixed = C1.Win.FlexGrid.AllowMergingEnum.FixedOnly;
            smartGridUsers1.AllowNodeMove = false;
            smartGridUsers1.AutoGenerateColumns = false;
            smartGridUsers1.ColumnInfo = resources.GetString("smartGridUsers1.ColumnInfo");
            smartGridUsers1.Dock = DockStyle.Fill;
            smartGridUsers1.DrawMode = C1.Win.FlexGrid.DrawModeEnum.OwnerDraw;
            aggregateDefinition2.Aggregate = C1.Win.FlexGrid.AggregateEnum.Count;
            aggregateDefinition2.Caption = "Всего: ";
            aggregateDefinition2.Column = 3;
            footerDescription2.Aggregates.Add(aggregateDefinition2);
            smartGridUsers1.Footers.Descriptions.Add(footerDescription2);
            smartGridUsers1.Footers.Fixed = true;
            stringItem2.Name = "Заголовок 1";
            stringItem2.Value = "...;Id;Блок.;Код;Логин;Кр.имя;Фамилия";
            smartGridUsers1.Headers.Add(stringItem2);
            smartGridUsers1.IdName = null;
            smartGridUsers1.Location = new Point(0, 31);
            smartGridUsers1.Name = "smartGridUsers1";
            smartGridUsers1.Rows.Count = 2;
            smartGridUsers1.SelectedRows = (List<int>)resources.GetObject("smartGridUsers1.SelectedRows");
            smartGridUsers1.SelectionMode = C1.Win.FlexGrid.SelectionModeEnum.Row;
            smartGridUsers1.Size = new Size(596, 362);
            smartGridUsers1.SortingType = SmartLib.SortingType.Descending;
            smartGridUsers1.StyleInfo = resources.GetString("smartGridUsers1.StyleInfo");
            smartGridUsers1.TabIndex = 5;
            smartGridUsers1.AfterSelChange += smartGridUsers_AfterSelChange;
            smartGridUsers1.GetUnboundValue += smartGridUsers_GetUnboundValue;
            // 
            // toolStripCurrencies
            // 
            toolStripCurrencies.ImageScalingSize = new Size(24, 24);
            toolStripCurrencies.Items.AddRange(new ToolStripItem[] { toolStripButtonUserNew, toolStripButtonUserDouble, toolStripButtonUserEdit, toolStripButtonUserDelete, toolStripButtonUserRefresh, toolStripSeparator2 });
            toolStripCurrencies.Location = new Point(0, 0);
            toolStripCurrencies.Name = "toolStripCurrencies";
            toolStripCurrencies.Size = new Size(596, 31);
            toolStripCurrencies.TabIndex = 3;
            toolStripCurrencies.Text = "toolStrip2";
            // 
            // toolStripButtonUserNew
            // 
            toolStripButtonUserNew.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButtonUserNew.Image = Properties.Resources.icons8_документ_50;
            toolStripButtonUserNew.ImageTransparentColor = Color.Magenta;
            toolStripButtonUserNew.Name = "toolStripButtonUserNew";
            toolStripButtonUserNew.Size = new Size(28, 28);
            toolStripButtonUserNew.Text = "Новый";
            toolStripButtonUserNew.Click += toolStripButtonUserNew_Click;
            // 
            // toolStripButtonUserDouble
            // 
            toolStripButtonUserDouble.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButtonUserDouble.Enabled = false;
            toolStripButtonUserDouble.Image = Properties.Resources.icons8_скопировать_50;
            toolStripButtonUserDouble.ImageTransparentColor = Color.Magenta;
            toolStripButtonUserDouble.Name = "toolStripButtonUserDouble";
            toolStripButtonUserDouble.Size = new Size(28, 28);
            toolStripButtonUserDouble.Text = "Дублировать";
            // 
            // toolStripButtonUserEdit
            // 
            toolStripButtonUserEdit.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButtonUserEdit.Image = Properties.Resources.icons8_редактирование_файла_50;
            toolStripButtonUserEdit.ImageTransparentColor = Color.Magenta;
            toolStripButtonUserEdit.Name = "toolStripButtonUserEdit";
            toolStripButtonUserEdit.Size = new Size(28, 28);
            toolStripButtonUserEdit.Text = "Редактировать";
            toolStripButtonUserEdit.Click += toolStripButtonUserEdit_Click;
            // 
            // toolStripButtonUserDelete
            // 
            toolStripButtonUserDelete.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButtonUserDelete.Image = Properties.Resources.icons8_удалить_файл_50;
            toolStripButtonUserDelete.ImageTransparentColor = Color.Magenta;
            toolStripButtonUserDelete.Name = "toolStripButtonUserDelete";
            toolStripButtonUserDelete.Size = new Size(28, 28);
            toolStripButtonUserDelete.Text = "Удалить";
            toolStripButtonUserDelete.Click += toolStripButtonUserDelete_Click;
            // 
            // toolStripButtonUserRefresh
            // 
            toolStripButtonUserRefresh.Alignment = ToolStripItemAlignment.Right;
            toolStripButtonUserRefresh.Image = Properties.Resources.icons8_refresh_50;
            toolStripButtonUserRefresh.ImageTransparentColor = Color.Magenta;
            toolStripButtonUserRefresh.Name = "toolStripButtonUserRefresh";
            toolStripButtonUserRefresh.Size = new Size(89, 28);
            toolStripButtonUserRefresh.Text = "Обновить";
            toolStripButtonUserRefresh.Click += toolStripButtonUserRefresh_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 31);
            // 
            // applicationBindingSource
            // 
            applicationBindingSource.DataSource = typeof(GrpcCommonNet.Library.Common.Application);
            // 
            // userBindingSource
            // 
            userBindingSource.DataSource = typeof(GrpcCommonNet.Library.Common.User);
            // 
            // UsersForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1114, 450);
            Controls.Add(c1SplitContainer1);
            Controls.Add(panel1);
            Name = "UsersForm";
            Text = "Приложения пользователей";
            Load += UsersForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)c1ComboBoxIsBlocked).EndInit();
            ((System.ComponentModel.ISupportInitialize)c1SplitContainer1).EndInit();
            c1SplitContainer1.ResumeLayout(false);
            c1SplitterPanelApps.ResumeLayout(false);
            c1SplitterPanelApps.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)smartGridApps1).EndInit();
            toolStripRates.ResumeLayout(false);
            toolStripRates.PerformLayout();
            c1SplitterPanelUsers.ResumeLayout(false);
            c1SplitterPanelUsers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)smartGridUsers1).EndInit();
            toolStripCurrencies.ResumeLayout(false);
            toolStripCurrencies.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)applicationBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)userBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label labelUserName;
        private TextBox textAbbrev;
        private C1.Win.SplitContainer.C1SplitContainer c1SplitContainer1;
        private C1.Win.SplitContainer.C1SplitterPanel c1SplitterPanelApps;
        private C1.Win.SplitContainer.C1SplitterPanel c1SplitterPanelUsers;
        private ToolStrip toolStripCurrencies;
        private ToolStripButton toolStripButtonUserNew;
        private ToolStripButton toolStripButtonUserDouble;
        private ToolStripButton toolStripButtonUserEdit;
        private ToolStripButton toolStripButtonUserDelete;
        private ToolStripButton toolStripButtonUserRefresh;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStrip toolStripRates;
        private ToolStripButton toolStripButtonAppNew;
        private ToolStripButton toolStripButtonAppDouble;
        private ToolStripButton toolStripButtonAppEdit;
        private ToolStripButton toolStripButtonAppDelete;
        private ToolStripButton toolStripButtonAppRefresh;
        private ToolStripSeparator toolStripSeparator1;
        private BindingSource userBindingSource;
        private BindingSource applicationBindingSource;
        private Label labelApp;
        private TextBox textBoxApp;
        private Label labelIsBlocked;
        private C1.Win.Input.C1ComboBox c1ComboBoxIsBlocked;
        private SmartLib.SmartGrid smartGridUsers1;
        private SmartLib.SmartGrid smartGridApps1;
    }
}