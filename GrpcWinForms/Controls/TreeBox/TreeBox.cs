using C1.Win.Input;
using C1.Win.TreeView;
using GrpcCommonNet.Library.Common;
using GrpcWinForms.Objects.Test;
using SmartLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrpcWinForms.Controls.TreeBox
{

    public partial class TreeBox : C1DropDownControl
    {
        private C1TreeNode _selectedNode = new();
        private C1TreeNode _initialNode = new();

        public C1TreeView TreeView 
        { 
            get; 
            set; 
        } = new C1TreeView();
        public ITreeData InitialNode
        { 
            get => (ITreeData)_initialNode.GetValue();
            set
            {
                C1TreeNode nodeInit = new C1TreeNode();
                nodeInit.SetValue(value);

                nodeInit = FindNode( x => ((ITreeData)x.GetValue()).Id == value.Id );
                if (nodeInit != null)
                {
                    C1TreeNode node = nodeInit;
                    while (node.ParentCollection.Parent != null)
                    {
                        node.ParentCollection.Parent.Expanded = true;
                        node = node.ParentCollection.Parent;
                    }
                    nodeInit.Selected = true;
                    _initialNode = nodeInit;
                    this.Text = value.Name;
                }
            }
        }
        public ITreeData SelectedNode 
        { 
            get
            {
                C1TreeNode node = this.TreeView.GetFocusedNode();
                if (node == null) return null;
                _selectedNode = node;
                return (ITreeData)(_selectedNode.GetValue());
            }
        }


        public TreeBox()
        {
            InitializeComponent();
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;
            Setup();
        }

        public TreeBox(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;
            Setup();
        }

        private void Setup()
        {
            this.Control = TreeView;

            TreeView.SelectionChanged += TreeView_SelectionChanged;
        }

        public BindingInfo BuildTree<T>(List<T> source) where T : ITreeData, new()
        {
            this.TreeView.BindingInfo.DataSource = source;
            this.TreeView.BindingInfo.KeyField = "Id";
            this.TreeView.BindingInfo.ParentKeyField = "ParentId";
            this.TreeView.Columns.Clear();
            this.TreeView.Columns.Add(new C1TreeColumn() { HeaderText = "Наименование",  DisplayFieldName = "Name" });

            return this.TreeView.BindingInfo;
        }

        private void TreeView_SelectionChanged(object sender, C1TreeViewEventArgs e)
        {
            C1TreeNode node = this.TreeView.GetFocusedNode();
            _selectedNode = node;
            this.Text = SelectedNode?.Name;

            this.DroppedDown = false;
        }

        public C1TreeNode FindNode( Func<C1TreeNode, bool> predicate, C1TreeNode defaultValue = null)
        {
            if (this.TreeView.Nodes == null) throw new ArgumentNullException(nameof(this.TreeView.Nodes));
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));

            // Используем стек для нерекурсивного обхода в глубину
            var stack = new Stack<C1TreeNode>();

            // Заполняем стек корневыми узлами в обратном порядке, 
            // чтобы обход шел строго сверху вниз, как они отображаются на экране
            for (int i = this.TreeView.Nodes.Count - 1; i >= 0; i--)
            {
                stack.Push(this.TreeView.Nodes[i]);
            }

            while (stack.Count > 0)
            {
                C1TreeNode currentNode = stack.Pop();

                // Проверяем предикат для текущего узла
                if (predicate(currentNode))
                {
                    return currentNode;
                }

                // Если у узла есть дочерние элементы, добавляем их в стек
                if (currentNode.Nodes != null && currentNode.Nodes.Count > 0)
                {
                    // Тоже в обратном порядке для сохранения правильного визуального порядка обхода
                    for (int i = currentNode.Nodes.Count - 1; i >= 0; i--)
                    {
                        stack.Push(currentNode.Nodes[i]);
                    }
                }
            }

            // Если ничего не найдено, возвращаем значение по умолчанию
            return defaultValue;
        }

    }

    #region Классы для постоения иерархии
    public interface ITreeData
    {
        [DefaultValue(0)]
        int Id { get; set; }

        [DefaultValue(0)]
        int ParentId { get; set; }

        [DefaultValue("")]
        string Name { get; set; }
    }
    #endregion
}
