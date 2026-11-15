using GrpcWinForms.Objects.Rights.Models;
using GrpcWinForms.Objects.Rights.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GrpcWinForms.Controls.FormTemplate;
using Form = GrpcWinForms.Controls.FormTemplate.Form;

namespace GrpcWinForms.Objects.Rights.Views.Forms
{
    public partial class RightObjectsManagerForm : Form, IRightObjectsManagerView
    {
        public event Action OnLoad;
        public event Action<RightObjectTreeModel> OnRefresh;
        public event Action<int> OnAdd;
        public event Action<RightObjectTreeModel> OnEdit;
        public event Action<RightObjectTreeModel> OnDelete;
        public event Action<RightObjectTreeModel, RightObjectTreeModel> OnMove;
        //public PermissionManager PermissionManager { get; private set; }


        public RightObjectsManagerForm(string tagName)
        {
            InitializeComponent();

            //PermissionManager = new PermissionManager(this);

            this.Tag = "{\"name\": \"" + tagName + "\"}";
            btnNew.Tag = "{\"name\": \"" + tagName + "\"}";
            btnDelete.Tag = "{\"name\": \"" + tagName + "\"}";
            //AddObjectRight.UserData = "{\"name\": \"" + tagName + "\"}";
            //DeleteObjectRight.UserData = "{\"name\": \"" + tagName + "\"}";
        }

        public void Refresh(IEnumerable<RightObjectTreeModel> data)
        {
            grid.BeginUpdate();
            grid.BuildTree(data);
            grid.EndUpdate();

            //RightObjectsGrid.BeginUpdate();
            //RightObjectsGrid.BuildTreeNew(data);
            //RightObjectsGrid.EndUpdate();

            //if (selectedModel != null)
            //    RightObjectsGrid.Row = RightObjectsGrid.FindModel(selectedModel);
        }

        #region Form Events

        private void RightObjectsManagerForm_Load(object sender, EventArgs e)
        {
            //PermissionManager.Initialize();
            OnLoad?.Invoke();
        }

        #endregion

        private void btnRefresh_Click(object sender, EventArgs e) =>
            OnRefresh?.Invoke(grid.GetCurrentObj<RightObjectTreeModel>());

        private void btnNew_Click(object sender, EventArgs e)
        {
            var currentNode = grid.Rows[grid.Row].Node;
            int currentId = 0;
            if (currentNode != null && currentNode.Key is RightObjectTreeModel)
                currentId = ((RightObjectTreeModel)currentNode.Key).Id;

            OnAdd?.Invoke(currentId);
        }

        private void grid_AfterEdit(object sender, C1.Win.FlexGrid.RowColEventArgs e)
        {
            var currentModel = grid.GetCurrentObj<RightObjectTreeModel>();
            currentModel.Name = grid[grid.Row, "Name"].ToString();
            currentModel.Code = grid[grid.Row, "Code"].ToString();
            currentModel.CheckAndApproveEnable = Convert.ToBoolean(grid[grid.Row,
                "CheckAndApproveEnable"]);

            OnEdit?.Invoke(currentModel);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (grid.Rows[grid.Row].Node.Key == null)
            {
                MessageBox.Show("Удаление корня невозможно");
                return;
            }

            OnDelete?.Invoke(grid.GetCurrentObj<RightObjectTreeModel>());
        }

        private void grid_BeforeEdit(object sender, C1.Win.FlexGrid.RowColEventArgs e)
        {
            var currentNode = grid.Rows[grid.Row].Node;
            if (currentNode == null || currentNode.Key == null || currentNode.Parent == null)
                e.Cancel = true;
        }

        private void grid_BeforeNodeMove(C1.Win.FlexGrid.Node currentNode, C1.Win.FlexGrid.Node parentNode, ref bool allowMove)
        {
            if (grid.IsSubroot(currentNode, parentNode))
            {
                MessageBox.Show("Невозможно переместить родительский объект в объект потомка.", "Ошибка перемещения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                allowMove = false;
            }
            else
            {
                var result = MessageBox.Show($"Объект \"{currentNode.Data}\" будет перенесен в \"{parentNode.Data}\".\r\nПродолжить?",
                    "Изменение иерархии", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Cancel)
                    allowMove = false;
            }
        }

        private void grid_AfterNodeMove(C1.Win.FlexGrid.Node currentNode, C1.Win.FlexGrid.Node parentNode, ref bool allowMove)
        {
            OnMove?.Invoke((RightObjectTreeModel)currentNode.Key, parentNode.Key != null ? (RightObjectTreeModel)parentNode.Key : null);
        }
    }
}
