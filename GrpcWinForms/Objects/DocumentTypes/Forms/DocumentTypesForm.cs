using C1.Win.FlexGrid;
using Google.Protobuf.WellKnownTypes;
using GrpcCommonNet.Library.Common;
using GrpcWinForms.Models;
using GrpcWinForms.Objects.DocumentTypes.Presenters;
using GrpcWinForms.Objects.DocumentTypes.Views;
using GrpcWinForms.Objects.DocumentTypes.Models;

namespace GrpcWinForms.Objects.DocumentTypes.Forms
{
    public partial class DocumentTypesForm : Form, IDocumentTypesView
    {
        private Loader loaderDocumentTypes = new Loader();
        private DocumentType documentType;
        private readonly DocumentTypesPresenter _presenter;

        public string HeadCode { get => HeadCodeField; set => HeadCodeField = value; }
        public bool DialogMode { get; set; }

        // Вспомогательное приватное поле для реализации свойства HeadCode (чтобы не ломать существующий код)
        private string HeadCodeField = string.Empty;

        public DocumentType DocumentType => documentType;

        public int Row => gridDocumentTypes.Row;
        public int RowSel => gridDocumentTypes.RowSel;
        public IList<int> SelectedRows => gridDocumentTypes.SelectedRows;

        public DocumentTypesForm()
        {
            InitializeComponent();
            loaderDocumentTypes.Parent = gridDocumentTypes;
            loaderDocumentTypes.Size = gridDocumentTypes.Size;

            _presenter = new DocumentTypesPresenter(this);
        }

        #region View API (IDocumentTypesView реализация)

        public void BeginUpdate()
        {
            gridDocumentTypes.BeginUpdate();
        }

        public void EndUpdate()
        {
            gridDocumentTypes.EndUpdate();
        }

        public void BuildTree(IEnumerable<object> treeData)
        {
            // Ожидаем, что элементы - это TreeDocumentType
            var asTree = treeData.Cast<TreeDocumentType>().ToList();
            gridDocumentTypes.BuildTree(asTree);
            if (DialogMode)
            {
                for (int i = 0; i < gridDocumentTypes.Cols.Count; i++)
                    gridDocumentTypes.Cols[i].Visible = false;
                gridDocumentTypes.Cols[0].Visible = gridDocumentTypes.Cols[1].Visible = true;
            }
        }

        public int GetDepth() => gridDocumentTypes.GetDepth();

        public void ExpandByLevel(int level) => gridDocumentTypes.ExpandByLevel(level);

        public void ConfigureLevels(int maxLevel)
        {
            toolStripButtonLevels.DropDownItems.Clear();
            for (int i = 1; i <= maxLevel; i++)
            {
                var levelItem = new ToolStripMenuItem($"Уровень {i}");
                int level = i;
                levelItem.Click += (s, e) =>
                {
                    gridDocumentTypes.BeginUpdate();
                    gridDocumentTypes.ExpandByLevel(level);
                    if (toolStripButtonPath.Checked) toolStripButtonPath.Checked = false;
                    gridDocumentTypes.EndUpdate();
                };
                toolStripButtonLevels.DropDownItems.Add(levelItem);
            }
        }

        public object GetSelectedTreeItem()
        {
            if (gridDocumentTypes.Row < gridDocumentTypes.Rows.Fixed) return null;
            var node = gridDocumentTypes.Rows[gridDocumentTypes.Row].Node;
            return node?.Key;
        }

        public DialogResult ShowDocumentTypeDialog(Form form)
        {
            return form.ShowDialog(this);
        }

        public void ReplaceCurrentNode(object documentTypeObj)
        {
            if (documentTypeObj == null) return;
            var dt = documentTypeObj as DocumentType;
            if (dt == null) return;
            try
            {
                Node node = gridDocumentTypes.Rows[gridDocumentTypes.Row].Node;
                DocumentTypeToNode(dt, node);
                gridDocumentTypes.Rows[gridDocumentTypes.Row].Node.Data = dt.Name;
                gridDocumentTypes.Rows[gridDocumentTypes.Row]["ParentNames"] = dt.Parents;
                gridDocumentTypes.Rows[gridDocumentTypes.Row]["Code"] = dt.Code;
                gridDocumentTypes.Rows[gridDocumentTypes.Row]["Form"] = dt.Form;
            }
            catch { }
        }

        public void InsertChildNode(object documentTypeObj)
        {
            if (documentTypeObj == null) return;
            var dt = documentTypeObj as DocumentType;
            if (dt == null) return;
            try
            {
                Node parentNode = gridDocumentTypes.Rows[gridDocumentTypes.Row].Node;
                var newTree = new TreeDocumentType()
                {
                    Id = dt.Id,
                    Name = dt.Name,
                    Code = dt.Code,
                    Form = dt.Form,
                    Parent = dt.Parent,
                    ParentId = dt.Parent?.Id ?? 0,
                    ParentIds = dt.Ids,
                    IsDefault = dt.IsDefault,
                    KindId = dt.KindId,
                    CountryCurrency_Id = dt.CountryCurrencyId,
                    CurrencyType_Id = dt.CurrencyType,
                    Data = dt.Data,
                    ViewDetail = dt.ViewDetail,
                    ViewMaster = dt.ViewMaster
                };
                Node newNode = parentNode.AddNode(NodeTypeEnum.FirstChild, dt.Name);
                newNode.Key = newTree;
                gridDocumentTypes.Row += 1;
                gridDocumentTypes.Rows[gridDocumentTypes.Row].Node.Data = dt.Name;
                gridDocumentTypes.Rows[gridDocumentTypes.Row]["ParentNames"] = dt.Parents;
                gridDocumentTypes.Rows[gridDocumentTypes.Row]["Id"] = dt.Id;
                gridDocumentTypes.Rows[gridDocumentTypes.Row]["Code"] = dt.Code;
                gridDocumentTypes.Rows[gridDocumentTypes.Row]["Form"] = dt.Form;
            }
            catch { }
        }

        public void RemoveCurrentNode()
        {
            try
            {
                gridDocumentTypes.BeginUpdate();
                gridDocumentTypes.Rows[gridDocumentTypes.Row].Node.RemoveNode();
                gridDocumentTypes.EndUpdate();
            }
            catch { }
        }

        public void RemoveNodesByIds(IEnumerable<int> ids)
        {
            if (ids == null) return;
            try
            {
                gridDocumentTypes.BeginUpdate();
                // Проходим все строки, ищем Node.Key.Id и удаляем совпадения
                var rowsToRemove = new List<Row>();
                foreach (Row r in gridDocumentTypes.Rows)
                {
                    if (!r.IsNode) continue;
                    if (r.Node?.Key is TreeDocumentType td)
                    {
                        if (ids.Contains(td.Id)) rowsToRemove.Add(r);
                    }
                }
                // Удаляем в обратном порядке
                foreach (var r in rowsToRemove.OrderByDescending(x => x.Index))
                {
                    r.Node.RemoveNode();
                }
                gridDocumentTypes.EndUpdate();
            }
            catch { }
        }

        public void ShowMessage(string text, string caption = "", MessageBoxButtons buttons = MessageBoxButtons.OK)
        {
            MessageBox.Show(text, caption, buttons);
        }

        public void CloseWithResult(object selectedDocumentType)
        {
            if (selectedDocumentType is DocumentType dt)
            {
                documentType = dt;
                DialogResult = DialogResult.OK;
                Close();
            }
            else if (selectedDocumentType is TreeDocumentType tree)
            {
                documentType = new DocumentType()
                {
                    Id = tree.Id,
                    Name = tree.Name,
                    Form = tree.Form
                };
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        #endregion

        #region События (делегируются Presenter-у)

        public async void RefreshDocumentTypes()
        {
            loaderDocumentTypes.ShowLoader();
            try
            {
                await _presenter.RefreshAsync();
            }
            finally
            {
                loaderDocumentTypes.HideLoader();
            }
        }

        private void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            RefreshDocumentTypes();
        }

        private void ContractTypesForm_Load(object sender, EventArgs e)
        {
            RefreshDocumentTypes();
        }

        private async void toolStripButtonEdit_Click(object sender, EventArgs e)
        {
            await _presenter.EditAsync();
        }

        private async void toolStripButtonNew_Click(object sender, EventArgs e)
        {
            await _presenter.NewAsync();
        }

        private async void toolStripButtonDelete_Click(object sender, EventArgs e)
        {
            await _presenter.DeleteAsync();
        }

        private void smartGridDocumentTypes_AfterNodeMove(Node currentNode, Node parentNode, ref bool allowMove)
        {
            int currentId = ((TreeDocumentType)currentNode.Key).Id;
            int newParentId = ((TreeDocumentType)parentNode.Key).Id;

            var movedOk = _presenter.MoveNodeAsync(currentId, newParentId).GetAwaiter().GetResult();
            if (!movedOk) allowMove = false;
        }

        private void smartGridDocumentTypes_BeforeNodeMove(Node currentNode, Node parentNode, ref bool allowMove)
        {
            // можно оставить пустым или использовать _presenter для валидации
        }

        private async void smartGridDocumentTypes1_DoubleClick(object sender, EventArgs e)
        {
            Point pt = gridDocumentTypes.PointToClient(Control.MousePosition);
            HitTestInfo hit = gridDocumentTypes.HitTest(pt);

            if (hit.Row + 1 > gridDocumentTypes.Rows.Count - gridDocumentTypes.Footers.Descriptions.Count) return;
            if (hit.Row < gridDocumentTypes.Rows.Fixed) return;

            int row = gridDocumentTypes.Row;
            if (row < gridDocumentTypes.Rows.Fixed || row > gridDocumentTypes.Rows.Count - gridDocumentTypes.Footers.Descriptions.Count)
                return;

            var treeDocType = gridDocumentTypes.Rows[row].Node.Key as TreeDocumentType;
            if (treeDocType == null) return;

            if (DialogMode)
            {
                if (String.IsNullOrEmpty(treeDocType.Form))
                {
                    MessageBox.Show("Данный тип выбрать нельзя.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    documentType = new DocumentType()
                    {
                        Id = treeDocType.Id,
                        Form = treeDocType.Form,
                        Name = treeDocType.Name,
                        Data = treeDocType.Data
                    };
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            else
            {
                await _presenter.EditAsync();
            }
        }

        private void toolStripButtonPath_Click(object sender, EventArgs e)
        {
            if (!toolStripButtonPath.Checked)
            {
                gridDocumentTypes.BeginUpdate();
                foreach (var row in gridDocumentTypes.Rows.Cast<Row>())
                    if (row.IsNode) row.Visible = true;
                gridDocumentTypes.EndUpdate();
            }
            else
            {
                IsolateCurrentBranch(gridDocumentTypes);
            }
        }

        #endregion

        #region Технические методы (внутренние помощники сохранены)

        private Node DocumentTypeToNode(DocumentType documentType, Node node)
        {
            try
            {
                var tree = (TreeDocumentType)node.Key;
                tree.Id = Convert.ToInt32(documentType.Id);
                tree.Name = documentType.Name;
                tree.Code = documentType.Code;
                tree.Form = documentType.Form;
                tree.ParentId = Convert.ToInt32(documentType.Parent.Id);
                tree.Parent = documentType.Parent;
                tree.ParentIds = documentType.Ids;
                tree.ParentNames = documentType.Parents;
                tree.KindId = Convert.ToInt32(documentType.KindId);
                tree.IsDefault = documentType.IsDefault;
                tree.ViewMaster = documentType.ViewMaster ?? string.Empty;
                tree.ViewDetail = documentType.ViewDetail ?? string.Empty;
                tree.Data = documentType.Data ?? new Struct();
                return node;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private void IsolateCurrentBranch(SmartLib.SmartGrid grid)
        {
            if (grid.Row < grid.Rows.Fixed) return;

            Node selectedNode = grid.Rows[grid.Row].Node;
            if (selectedNode == null) return;

            grid.BeginUpdate();
            try
            {
                var visibleRowIndices = new HashSet<int>();

                visibleRowIndices.Add(selectedNode.Row.Index);

                Node parent = selectedNode.Parent;
                while (parent != null)
                {
                    visibleRowIndices.Add(parent.Row.Index);
                    parent = parent.Parent;
                }

                AddChildrenRowIndices(selectedNode, visibleRowIndices);

                for (int i = grid.Rows.Fixed; i < grid.Rows.Count; i++)
                {
                    grid.Rows[i].Visible = visibleRowIndices.Contains(i);
                }
            }
            finally
            {
                grid.EndUpdate();
            }
        }

        private void AddChildrenRowIndices(Node node, HashSet<int> indices)
        {
            foreach (Node child in node.Nodes)
            {
                indices.Add(child.Row.Index);
                if (child.Nodes.Length > 0)
                {
                    AddChildrenRowIndices(child, indices);
                }
            }
        }

        #endregion
    }

    
}
