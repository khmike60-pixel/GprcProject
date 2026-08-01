using Accessibility;
using C1.Win.FlexGrid;
using Google.Protobuf.WellKnownTypes;
using GrpcCommonNet.Library.Common;
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
                        Paths = { "id", "parent", "ids", "parents", "name", "code", "currency_type", "data", "country_currency_id", "view_master", "view_detail", "is_default", "approved", "kind_id" }
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
                        //if (toolStripButtonPath.Checked) toolStripButtonPath.Checked = false;
                        smartGridDocumentTypes.EndUpdate();
                    };
                    //                    toolStripButtonLevels.DropDownItems.Add(levelItem);
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

                if(DialogResult.OK != form.ShowDialog())
                {
                    return;
                }

                CreateDocumentTypeRequest request = new CreateDocumentTypeRequest()
                {
                    DocumentType = form.DocumentType
                };

                DocumentTypeResponse response = await GrpcClients.GrpcClients.DocumentType.CreateDocumentTypeAsync(request);
                if (response.Result.Status == Status.Ok)
                {

                    ParentNode.AddNode(NodeTypeEnum.FirstChild, new TreeDocumentType()
                    {
                        Id = response.DocumentType.Id,
                        Name = response.DocumentType.Name,
                        Code = response.DocumentType.Code,
                        IsDefault = response.DocumentType.IsDefault,
                        KindId = response.DocumentType.KindId,
                        CountryCurrency_Id = response.DocumentType.CountryCurrencyId,
                        CurrencyType_Id = response.DocumentType.CurrencyType,
                        Data = response.DocumentType.Data,
                        ViewDetail = response.DocumentType.ViewDetail,
                        ViewMaster = response.DocumentType.ViewMaster
                    });
                
                    smartGridDocumentTypes.Rows[smartGridDocumentTypes.Row].Node.Data = response.DocumentType.Name;
                    smartGridDocumentTypes.Rows[smartGridDocumentTypes.Row]["ParentNames"] = response.DocumentType.Parents;
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


        #region Технические методы

        private Node DocumentTypeToNode(DocumentType documentType, Node node)
        {
            try
            {
                var tree = (TreeDocumentType)node.Key;
                tree.Id = Convert.ToInt32(documentType.Id);
                tree.Name = documentType.Name;
                tree.Code = documentType.Code;
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

        #endregion

    }

    public class TreeDocumentType : ITreeData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
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
