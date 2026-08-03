using Accessibility;
using C1.Win.FlexGrid;
using Google.Protobuf.WellKnownTypes;
using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Library.Currency;
using GrpcCommonNet.Library.DocumentType;
using GrpcCommonNet.Library.Product;
using GrpcCommonNet.Proto.Utils;
using GrpcWinForms.Models;
using GrpcWinForms.Objects.Products.ProductsForm;
using SmartGrid;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrpcWinForms.Objects.DocumentTypes.Forms
{
    public partial class DocumentTypesForm : Form
    {
        private Loader loaderDocumentTypes = new Loader();
        private BindingList<DocumentType> documentTypes;
        private int maxLevel = 0;

        public string HeadCode = string.Empty;
        public DocumentTypesForm()
        {
            InitializeComponent();
            loaderDocumentTypes.Parent = smartGridDocumentTypes;
            loaderDocumentTypes.Size = smartGridDocumentTypes.Size;
        }

        public async void RefreshDocumentTypes()
        {
            loaderDocumentTypes.ShowLoader();
            try
            {
                smartGridDocumentTypes.BeginUpdate();
                List<DocumentType> treeContractTypes = new List<DocumentType>();

                DocumentTypeFilterRequest request = new DocumentTypeFilterRequest()
                {
                    Head = HeadCode, // Получить весь список
                    FieldMask = new FieldMask()
                    {
                        Paths = { "id", "parent", "ids", "parents", "name", "code", "form", "currency_type", "data", "country_currency_id", "view_master", "view_detail", "is_default", "approved", "kind_id" }
                    }
                };
                ListDocumentTypeResponse response = new ListDocumentTypeResponse();
                response = await GrpcClients.GrpcClients.DocumentType.GetBranchDocumentTypesAsync(request);

                List<TreeDocumentType> treeDocumentTypes = new List<TreeDocumentType>();

                foreach (DocumentType item in response.DocumentTypes)
                {
                    treeDocumentTypes.Add(new TreeDocumentType()
                    {
                        Id = Convert.ToInt32(item.Id),
                        Name = item.Name,
                        Code = item.Code,
                        Form = item.Form,
                        ParentId = Convert.ToInt32(item.Parent.Id),
                        Parent = item.Parent,
                        ParentIds = item.Ids,
                        ParentNames = item.Parents,
                        KindId = Convert.ToInt32(item.KindId),
                        IsDefault = item.IsDefault,
                        //CountryCurrencyId = Convert.ToInt32(item.CountryCurrencyId),
                        //CurrencyType = item.CurrencyType,
                        Data = item.Data,
                        ViewMaster = item.ViewMaster,
                        ViewDetail = item.ViewDetail
                    });
                }

                var tree = treeDocumentTypes.AsEnumerable();

                smartGridDocumentTypes.BuildTree(tree);

                // Находим максимальный уровень среди всех строк, которые являются узлами
                int maxLevel = smartGridDocumentTypes.GetDepth();

                for (int i = 1; i <= maxLevel; i++)
                {
                    var levelItem = new ToolStripMenuItem($"Уровень {i}");
                    int level = i; // Локальная копия для замыкания
                    levelItem.Click += (s, e) =>
                    {
                        smartGridDocumentTypes.BeginUpdate();
                        smartGridDocumentTypes.ExpandByLevel(level);
                        if (toolStripButtonPath.Checked) toolStripButtonPath.Checked = false;
                        smartGridDocumentTypes.EndUpdate();
                    };
                    toolStripButtonLevels.DropDownItems.Add(levelItem);
                }
                smartGridDocumentTypes.EndUpdate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            loaderDocumentTypes.HideLoader();
        }

        private void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            RefreshDocumentTypes();
        }

        private void ContractTypesForm_Load(object sender, EventArgs e)
        {
            RefreshDocumentTypes();
        }

        private async void smartGridDocumentTypes_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                Node treeNode = smartGridDocumentTypes.Rows[smartGridDocumentTypes.Row].Node;
                TreeDocumentType treeNodeKey = (TreeDocumentType)treeNode.Key;
                DocumentTypeRequest requestById = new DocumentTypeRequest() { Id = treeNodeKey.Id };

                DocumentTypeResponse responseById = await GrpcClients.GrpcClients.DocumentType.GetDocumentTypeAsync(requestById);
                using DocumentTypeForm form = new DocumentTypeForm();
                form.EditMode = false;
                form.DocumentType = responseById.DocumentType;
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: \n" + ex.Message, "Оишбка");
            }
        }

        private async void toolStripButtonEdit_Click(object sender, EventArgs e)
        {
            try
            {
                Node treeNode = smartGridDocumentTypes.Rows[smartGridDocumentTypes.Row].Node;
                TreeDocumentType treeNodeKey = (TreeDocumentType)treeNode.Key;
                DocumentTypeRequest requestById = new DocumentTypeRequest() { Id = treeNodeKey.Id };

                DocumentTypeResponse responseById = await GrpcClients.GrpcClients.DocumentType.GetDocumentTypeAsync(requestById);
                using DocumentTypeForm form = new DocumentTypeForm();
                form.EditMode = true;
                form.DocumentType = responseById.DocumentType;

                if (DialogResult.OK == form.ShowDialog())
                {
                    UpdateDocumentTypeRequest request = new UpdateDocumentTypeRequest()
                    {
                        DocumentType = form.DocumentType
                    };

                    DocumentTypeResponse response = await GrpcClients.GrpcClients.DocumentType.UpdateDocumentTypeAsync(request);
                    if (response.Result.Status == Status.Ok)
                    {
                        DocumentTypeToNode(response.DocumentType, treeNode);
                        smartGridDocumentTypes.Rows[smartGridDocumentTypes.Row].Node.Data = response.DocumentType.Name;
                        smartGridDocumentTypes.Rows[smartGridDocumentTypes.Row]["ParentNames"] = response.DocumentType.Parents;
                        smartGridDocumentTypes.Rows[smartGridDocumentTypes.Row]["Code"] = response.DocumentType.Code;
                        smartGridDocumentTypes.Rows[smartGridDocumentTypes.Row]["Form"] = response.DocumentType.Form;

                    }
                    else
                    {
                        MessageBox.Show("Ошибка: \n" + response.Result.Message, "Оишбка");
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: \n" + ex.Message, "Оишбка");
            }
        }

        private void smartGridDocumentTypes_AfterNodeMove(Node currentNode, Node parentNode, ref bool allowMove)
        {

            MoveDocumentTypeRequest request = new MoveDocumentTypeRequest()
            {
                Id = ((TreeDocumentType)currentNode.Key).Id,
                NewParentId = ((TreeDocumentType)parentNode.Key).Id
            };

            DocumentTypeResponse response = GrpcClients.GrpcClients.DocumentType.MoveDocumentType(request);
            if (response.Result.Status != Status.Ok)
            {
                MessageBox.Show("Ошибка: \n" + response.Result.Message, "Оишбка");
                allowMove = false;
                return;
            }
            //smartGridDocumentTypes.MoveNode(currentNode, parentNode);
        }

        private void smartGridDocumentTypes_BeforeNodeMove(Node currentNode, Node parentNode, ref bool allowMove)
        {

        }

        private async void toolStripButtonNew_Click(object sender, EventArgs e)
        {
            try
            {
                Node ParentNode = smartGridDocumentTypes.Rows[smartGridDocumentTypes.Row].Node;
                TreeDocumentType currentNodeKey = (TreeDocumentType)ParentNode.Key;
                using DocumentTypeForm form = new DocumentTypeForm();
                form.EditMode = true;
                form.DocumentType = new DocumentType()
                {
                    Name = "Новый тип документа",
                    Parent = new Tree() { Id = currentNodeKey.Id, Name = currentNodeKey.Name }
                };

                if (DialogResult.OK != form.ShowDialog()) return;

                CreateDocumentTypeRequest request = new CreateDocumentTypeRequest() { DocumentType = form.DocumentType };

                DocumentTypeResponse response = await GrpcClients.GrpcClients.DocumentType.CreateDocumentTypeAsync(request);
                if (response.Result.Status == Status.Ok)
                {
                    TreeDocumentType newTree = new TreeDocumentType()
                    {
                        Id = response.DocumentType.Id,
                        Name = response.DocumentType.Name,
                        Code = response.DocumentType.Code,
                        Form = response.DocumentType.Form,
                        Parent = response.DocumentType.Parent,
                        ParentId = response.DocumentType.Parent.Id,
                        ParentIds = response.DocumentType.Ids,
                        IsDefault = response.DocumentType.IsDefault,
                        KindId = response.DocumentType.KindId,
                        CountryCurrency_Id = response.DocumentType.CountryCurrencyId,
                        CurrencyType_Id = response.DocumentType.CurrencyType,
                        Data = response.DocumentType.Data,
                        ViewDetail = response.DocumentType.ViewDetail,
                        ViewMaster = response.DocumentType.ViewMaster
                    };

                    Node newNode = ParentNode.AddNode(NodeTypeEnum.FirstChild, response.DocumentType.Name);

                    newNode.Key = newTree;
                    smartGridDocumentTypes.Row += 1;

                    smartGridDocumentTypes.Rows[smartGridDocumentTypes.Row].Node.Data = response.DocumentType.Name;
                    smartGridDocumentTypes.Rows[smartGridDocumentTypes.Row]["ParentNames"] = response.DocumentType.Parents;
                    smartGridDocumentTypes.Rows[smartGridDocumentTypes.Row]["Id"] = response.DocumentType.Id;
                    smartGridDocumentTypes.Rows[smartGridDocumentTypes.Row]["Code"] = response.DocumentType.Code;
                    smartGridDocumentTypes.Rows[smartGridDocumentTypes.Row]["Form"] = response.DocumentType.Form;


                }
                else
                {
                    MessageBox.Show("Ошибка: \n" + response.Result.Message, "Оишбка");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: \n" + ex.Message, "Оишбка");
            }
        }

        private async void toolStripButtonDelete_Click(object sender, EventArgs e)
        {
            List<int> ids = new List<int>();
            List<int> oldList = new List<int>();
            List<int> newMarked = new List<int>();

            if (smartGridDocumentTypes.SelectedRows.Count == 0)
            { // Удаляется одна запись
                DialogResult result = MessageBox.Show("Удалить текущую строку данных?", "Удаление", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    DeleteDocumentTypeRequest request = new DeleteDocumentTypeRequest()
                    {
                        Id = (int)smartGridDocumentTypes.Rows[smartGridDocumentTypes.Row]["Id"]
                    };
                    DeleteDocumentTypeResponse response = await GrpcClients.GrpcClients.DocumentType.DeleteDocumentTypeAsync(request);
                    int i = smartGridDocumentTypes.RowSel - smartGridDocumentTypes.Rows.Fixed;
                    if (response.Result.Status == Status.Ok)
                    {
                        smartGridDocumentTypes.BeginUpdate();
                        smartGridDocumentTypes.Rows[smartGridDocumentTypes.Row].Node.RemoveNode();
                        smartGridDocumentTypes.EndUpdate();
                    }
                    else
                        MessageBox.Show("Ошибка при удалении: \nВероятно есть зависимые данные.\n" + response.Result.Message, "Ошибка");
                }
            }
            else
            { // Был режим выделения
                DialogResult result = MessageBox.Show($"Вы отметили {smartGridDocumentTypes.SelectedRows.Count} строк." + Environment.NewLine + "Удалить отмеченные строки?", "Удаление", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    List<Node> selectedNodes = new List<Node>();
                    for (int i = 0; i < smartGridDocumentTypes.SelectedRows.Count; i++)
                    {
                        Node selectNode = smartGridDocumentTypes.Rows[smartGridDocumentTypes.SelectedRows[i]].Node;
                        selectedNodes.Add(selectNode);
                    }
                    oldList.AddRange(smartGridDocumentTypes.SelectedRows);
                    newMarked.AddRange(smartGridDocumentTypes.SelectedRows);

                    foreach (var index in oldList) ids.Add(Convert.ToInt32(smartGridDocumentTypes.Rows[index]["Id"]));

                    DeleteIdsDocumentTypeRequest request = new DeleteIdsDocumentTypeRequest();
                    request.Ids.AddRange(ids);

                    UndeletedIdsDocumentTypeResponse response = new UndeletedIdsDocumentTypeResponse();
                    response = await GrpcClients.GrpcClients.DocumentType.DeleteIdsDocumentTypeAsync(request);
                    if (response.Result.Status != Status.Ok)
                    {
                        MessageBox.Show("Ошибка при удалении: " + response.Result.Message);
                        return;
                    }
                    else
                    {
                        List<int> undelIds = new List<int>();
                        smartGridDocumentTypes.BeginUpdate();
                        oldList.Sort(); oldList.Reverse();

                        for (int i = 0; i < oldList.Count; i++)
                        {
                            Node selectNode = smartGridDocumentTypes.Rows[oldList[i]].Node;
                            if (!response.UndeletedIds.Contains(((TreeDocumentType)selectNode.Key).Id))
                            {
                                selectNode.RemoveNode();
                            }
                        }
                        smartGridDocumentTypes.SelectedRows = undelIds;
                        smartGridDocumentTypes.EndUpdate();
                        if (response.UndeletedIds.Count > 0)
                            MessageBox.Show("Данные, которые не удалось удалить.\n Неудвленные строки остались выделенными.", "Внимание");
                    }
                }
            }
        }

        private void toolStripButtonPath_Click(object sender, EventArgs e)
        {
            if (!toolStripButtonPath.Checked)
            {
                smartGridDocumentTypes.BeginUpdate();
                foreach (var row in smartGridDocumentTypes.Rows.Cast<Row>())
                    if (row.IsNode) row.Visible = true;
                smartGridDocumentTypes.EndUpdate();
            }
            else
            {
                IsolateCurrentBranch(smartGridDocumentTypes);
            }

        }
        #region Технические методы

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
            catch (Exception ex)
            {
                return null;
            }

        }

        private void IsolateCurrentBranch(SmartGrid.SmartGrid grid)
        {
            if (grid.Row < grid.Rows.Fixed) return;

            Node selectedNode = grid.Rows[grid.Row].Node;
            if (selectedNode == null) return;

            grid.BeginUpdate();
            try
            {
                // Используем HashSet для индексов строк (самый быстрый способ в .NET 8)
                var visibleRowIndices = new HashSet<int>();

                // 1. Добавляем индекс текущей строки
                visibleRowIndices.Add(selectedNode.Row.Index);

                // 2. Добавляем индексы всех предков (вверх)
                Node parent = selectedNode.Parent;
                while (parent != null)
                {
                    visibleRowIndices.Add(parent.Row.Index);
                    parent = parent.Parent;
                }

                // 3. Добавляем индексы всех потомков (вниз)
                AddChildrenRowIndices(selectedNode, visibleRowIndices);

                // 4. Проходим по всем строкам и меняем видимость
                for (int i = grid.Rows.Fixed; i < grid.Rows.Count; i++)
                {
                    // Теперь сравниваем целые числа (индексы), это сработает на 100%
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

    public class TreeDocumentType : ITreeData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Form { get; set; }
        public int ParentId { get; set; }
        public Tree Parent { get; set; }
        public string ParentIds { get; set; }
        public string ParentNames { get; set; }
        public string ViewMaster {  get; set; }
        public string ViewDetail {  get; set; }
        public Struct Data { get; set; }
        public bool IsDefault {  get; set; }
        public int CurrencyType_Id { get; set; }
        public int CountryCurrency_Id { get; set; }
        public int KindId {  get; set; }
    }

}
