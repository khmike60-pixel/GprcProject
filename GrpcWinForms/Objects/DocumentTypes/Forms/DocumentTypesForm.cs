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
                        ParentId = Convert.ToInt32(item.Parent),
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

        private void smartGridDocumentTypes_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                Node oldTree = smartGridDocumentTypes.Rows[smartGridDocumentTypes.Row].Node;

                DocumentType documentType = NodeToDocumentType(oldTree);
                using DocumentTypeForm f = new DocumentTypeForm();
                f.documentType = documentType;
                f.EditMode = false;
                f.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: \n" + ex.Message, "Оишбка");
            }
        }

        private void toolStripButtonEdit_Click(object sender, EventArgs e)
        {
            try
            {
                Node oldTree = smartGridDocumentTypes.Rows[smartGridDocumentTypes.Row].Node;
                DocumentType documentType = NodeToDocumentType(oldTree);

                using DocumentTypeForm f = new DocumentTypeForm();
                f.documentType = documentType;
                f.EditMode = true;
                if (DialogResult.OK == f.ShowDialog())
                {
                    // UpdateDocumentType();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: \n" + ex.Message, "Оишбка");
            }
        }


        #region Технические методы

        private DocumentType NodeToDocumentType(Node node)
        {
            DocumentType documentType = new DocumentType();
            try
            {
                TreeDocumentType tree = node.Key as TreeDocumentType;

                documentType = new DocumentType()
                {
                    Name = tree.Name,
                    Parent = tree.ParentId,
                    Code = tree.Code,
                    IsDefault = tree.IsDefault,
                    //                    CountryCurrencyId = tree.CountryCurrencyId,
                    ViewMaster = tree.ViewMaster,
                    ViewDetail = tree.ViewDetail,
                    //                    CurrencyType = tree.CurrencyType,
                    Data = tree.Data
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка конвертации NodeToDocumentType");
            }
            return documentType;
        }

        #endregion

    }

    public class TreeDocumentType : ITreeData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int ParentId { get; set; }
        public string ParentIds { get; set; }
        public string ParentNames { get; set; }
        public string ViewMaster {  get; set; }
        public string ViewDetail {  get; set; }
        public Struct Data { get; set; }
        public bool IsDefault {  get; set; }
        public int KindId {  get; set; }
    }
}
