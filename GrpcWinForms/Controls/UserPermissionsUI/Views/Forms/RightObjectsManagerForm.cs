using C1.Win.Command;
using C1.Win.FlexGrid;
using GrpcWinForms.Controls.UserPermissionsUI.Models;
using GrpcWinForms.Controls.UserPermissionsUI.Presenters;
using GrpcWinForms.Controls.UserPermissionsUI.Services.Implementaions;
using GrpcWinForms.Controls.UserPermissionsUI.Services.Interfaces;
using GrpcWinForms.Controls.UserPermissionsUI.Views.Interfaces;
using SmartLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrpcWinForms.Controls.UserPermissionsUI.Views.Forms
{
    public partial class RightObjectsManagerForm : Form, IRightObjectsManagerView
    {
        public event Action OnLoad;
        public event Action<RightObjectTreeModel> OnRefresh;
        public event Action<int> OnAdd;
        public event Action<RightObjectTreeModel> OnEdit;
        public event Action<RightObjectTreeModel> OnDelete;
        public event Action<RightObjectTreeModel, RightObjectTreeModel> OnMove;
        public PermissionManager.PermissionManager PermissionManager { get; private set; }

        public RightObjectsManagerForm(string tagName)
        {
            InitializeComponent();

            Setup();

            PermissionManager = new PermissionManager.PermissionManager(this);

            this.Tag = "{\"name\": \"" + tagName + "\"}";
            AddObjectRight.Tag = "{\"name\": \"" + tagName + "\"}";
            DeleteObjectRight.Tag = "{\"name\": \"" + tagName + "\"}";
            
            // Добавить инициализацию презентера
            var service = new RightObjectsService("cwatis"); 
            var presenter = new RightObjectsManagerPresenter(this, service);
        }

        private void Setup()
        {
            this.Load += new System.EventHandler(this.RightObjectsManagerForm_Load);

            this.RightObjectsGrid.BeforeNodeMove += new SmartGrid.NodeMoveDelegate(this.RightObjectsGrid_BeforeNodeMove);
            this.RightObjectsGrid.AfterNodeMove += new SmartGrid.NodeMoveDelegate(this.RightObjectsGrid_AfterNodeMove);
            this.RightObjectsGrid.SelChange += new System.EventHandler(this.RightObjectsGrid_SelChange);
            this.RightObjectsGrid.MouseDown += new System.Windows.Forms.MouseEventHandler(this.RightObjectsGrid_MouseDown);
            this.RightObjectsGrid.MouseUp += new System.Windows.Forms.MouseEventHandler(this.RightObjectsGrid_MouseUp);
            this.RightObjectsGrid.BeforeEdit += new RowColEventHandler(this.RightObjectsGrid_BeforeEdit);
            this.RightObjectsGrid.AfterEdit += new RowColEventHandler(this.RightObjectsGrid_AfterEdit);
            this.RightObjectsGrid.AfterNodeMove += new SmartGrid.NodeMoveDelegate(this.RightObjectsGrid_AfterNodeMove);
            //this.RightObjectsGrid_BeforeNodeMove += new SmartGrid.NodeMoveDelegate(this.RightObjectsGrid_BeforeNodeMove);
        }

        public void Refresh(IEnumerable<RightObjectTreeModel> data, RightObjectTreeModel selectedModel)
        {
            RightObjectsGrid.BeginUpdate();
            RightObjectsGrid.BuildTree(data);
            RightObjectsGrid.EndUpdate();

            if (selectedModel != null)
                RightObjectsGrid.Row = FindRow(selectedModel, RightObjectsGrid.Nodes);
            if (RightObjectsGrid.Row == -1) RightObjectsGrid.Row = RightObjectsGrid.Rows.Fixed;
        }

        private void AddObjectRight_Click(object sender, EventArgs e)
        {
            var currentNode = RightObjectsGrid.Rows[RightObjectsGrid.Row].Node;
            int currentId = 0;
            if (currentNode != null && currentNode.Key is RightObjectTreeModel)
                currentId = ((RightObjectTreeModel)currentNode.Key).Id;

            OnAdd?.Invoke(currentId);
        }

        private void DeleteObjectRight_Click(object sender, EventArgs e)
        {
            if (RightObjectsGrid.Rows[RightObjectsGrid.Row].Node.Key == null)
            {
                MessageBox.Show("Удаление корня невозможно");
                return;
            }

            OnDelete?.Invoke(RightObjectsGrid.GetCurrentObj<RightObjectTreeModel>());
        }

        private void RefreshRightObjects_Click(object sender, EventArgs e) =>
            OnRefresh?.Invoke(RightObjectsGrid.GetCurrentObj<RightObjectTreeModel>());

        private void RightObjectsGrid_AfterEdit(object sender, RowColEventArgs e)
        {
            var currentModel = RightObjectsGrid.GetCurrentObj<RightObjectTreeModel>();
            currentModel.Name = RightObjectsGrid[RightObjectsGrid.Row, "Name"].ToString();
            currentModel.Code = RightObjectsGrid[RightObjectsGrid.Row, "Code"].ToString();
            currentModel.CheckAndApproveEnable = Convert.ToBoolean(RightObjectsGrid[RightObjectsGrid.Row,
                "CheckAndApproveEnable"]);

            OnEdit?.Invoke(currentModel);
        }

        private void RightObjectsGrid_BeforeEdit(object sender, RowColEventArgs e)
        {
            var currentNode = RightObjectsGrid.Rows[RightObjectsGrid.Row].Node;
            if (currentNode == null || currentNode.Key == null || currentNode.Parent == null)
                e.Cancel = true;
        }

        private void RightObjectsGrid_MouseUp(object? sender, MouseEventArgs e) => EndDrag();

        /// <summary>Индекс строки, которую тащат мышью; -1, если перетаскивания нет.</summary>
        private int _dragRow = -1;
        private void RightObjectsGrid_MouseDown(object? sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;

            var hit = RightObjectsGrid.HitTest(e.X, e.Y);
            if (hit.Type != HitTestTypeEnum.Cell || hit.Row < RightObjectsGrid.Rows.Fixed) return;

            var node = RightObjectsGrid.Rows[hit.Row].Node;
            if (node == null) return;

            _dragRow = hit.Row;
            // Корень перемещать нельзя
            RightObjectsGrid.AllowNodeMove = node.Key != null && node.Parent != null;
            RightObjectsGrid.Cursor = Cursors.Hand;
        }

        private void RightObjectsGrid_SelChange(object? sender, EventArgs e)
        {
            if (_dragRow < 0) return;

            if (MouseButtons != MouseButtons.Left)
            {
                EndDrag();
                return;
            }

            RightObjectsGrid.Cursor = CanDropTo(RightObjectsGrid.Row) ? Cursors.NoMoveVert : Cursors.No;
        }

        /// <summary>
        /// Можно ли перенести перетаскиваемый объект в объект строки <paramref name="targetRow"/>.
        /// </summary>
        private bool CanDropTo(int targetRow)
        {
            if (!RightObjectsGrid.AllowNodeMove) return false;
            if (_dragRow >= RightObjectsGrid.Rows.Count) return false;
            if (targetRow < RightObjectsGrid.Rows.Fixed || targetRow >= RightObjectsGrid.Rows.Count) return false;
            if (targetRow == _dragRow) return false;

            var dragNode = RightObjectsGrid.Rows[_dragRow].Node;
            var targetNode = RightObjectsGrid.Rows[targetRow].Node;
            if (dragNode == null || targetNode == null) return false;

            // Уже лежит в этом родителе
            var dragParent = dragNode.Parent;
            if (dragParent != null && dragParent.Row.Index == targetRow) return false;

            // Нельзя переносить объект в собственного потомка
            for (var parent = targetNode.Parent; parent != null; parent = parent.Parent)
                if (parent.Row.Index == _dragRow) return false;

            return true;
        }

        private void EndDrag()
        {
            _dragRow = -1;
            RightObjectsGrid.Cursor = Cursors.Default;
        }

        private void RightObjectsGrid_AfterNodeMove(Node currentNode, Node parentNode, ref bool allowMove) =>
            OnMove?.Invoke((RightObjectTreeModel)currentNode.Key, parentNode.Key != null ? (RightObjectTreeModel)parentNode.Key : null);

        private void RightObjectsGrid_BeforeNodeMove(Node currentNode, Node parentNode, ref bool allowMove)
        {
            EndDrag();

            if (RightObjectsGrid.IsSubroot(currentNode, parentNode))
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

        private void RightObjectsManagerForm_Load(object? sender, EventArgs e)
        {
            PermissionManager.Initialize();
            OnLoad?.Invoke();
        }


        private static int FindRow(RightObjectTreeModel selectedModel, Node[] nodes)
        {
            int index = -1;
            if (selectedModel == null) return index;

            foreach (Node node in nodes) 
            {
                index = node.Index;
                RightObjectTreeModel model = node.Key as RightObjectTreeModel;
                if (model == selectedModel) return index;
                if (node.Nodes.Length > 0)
                {
                    index = FindRow(selectedModel, node.Nodes);
                    if (index > -1) return index;
                }
            }
            return index;
        }

    }
}
