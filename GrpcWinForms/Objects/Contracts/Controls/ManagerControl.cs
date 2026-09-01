using Google.Protobuf.WellKnownTypes;
using GrpcCommonNet.Library.Contract;
using GrpcCommonNet.Library.Contragent;
using GrpcCommonNet.Library.Employee;
using GrpcCommonNet.Library.User;
using GrpcWinForms.GrpcUtils;
using GrpcWinForms.Objects.Contragents.Forms;
using GrpcWinForms.Objects.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrpcWinForms.Objects.Contracts.Forms.Controls
{
    public partial class ManagerControl : UserControl
    {
        private Contract _contract = new Contract();
        public Contract Contract { get => _contract; set => _contract = value; }

        private string[] projectTypes = new string[] { "стандартный", "проект", "распродажа" };

        private bool readOnly = false;
        public bool ReadOnly
        {
            get => readOnly;
            set
            {
                readOnly = value;
                smartBoxInitiator.ReadOnly = readOnly;
                smartBoxExecutor.ReadOnly = readOnly;
                smartBoxCreator.ReadOnly = readOnly;
                cbProjectType.ReadOnly = readOnly;
                tbComment.ReadOnly = readOnly;
            }
        }

        public ManagerControl()
        {
            InitializeComponent();
        }
        public ManagerControl(Contract contract)
        {
            InitializeComponent();
            _contract = contract;
        }

        public void SetControl(Contract cntr)
        {
            _contract = cntr;
            if (_contract.Id == 0) // Новый контракт
            {

            }
            // Инициатор, Исполнитель, Создатель
            smartBoxInitiator.SetSelectedItemBox(_contract.Initiator, "Id");
            smartBoxExecutor.SetSelectedItemBox(_contract.Executor, "Id");
            if (_contract.Metadata == null) _contract.Metadata = new Metadata();
            smartBoxCreator.SetSelectedItemBox(_contract.Metadata.CreateBy, "Id");

            // Менеджерский тип
            cbProjectType.Items.Clear();
            cbProjectType.Items.AddRange(projectTypes);
            for (int i = 0; i < projectTypes.Length; i++)
            {
                if (projectTypes[i] == _contract.ManagerType)
                {
                    cbProjectType.SelectedIndex = i; break;
                }
            }

            // Описание
            tbComment.Text = Contract.Comment;

        }

        private void tbComment_TextChanged(object sender, EventArgs e)
        {
            _contract.Comment = tbComment.Text;
            _contract.ManagerType = projectTypes[cbProjectType.SelectedIndex];
        }

        private async void ManagerControl_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            try
            {
                ContragentFilterRequest request = new ContragentFilterRequest()
                { PrefixNotEmpty = true, TypeFilter = GrpcCommonNet.Library.Common.ContragentTypeFilter.PersonFilter};
                ListContragentResponse response = await GrpcRetry.CallAsync(() =>
                    GrpcClients.GrpcClients.Contragent.ShortListContragentAsync(request).ResponseAsync
                );

                ContragentsShortForm form = new ContragentsShortForm()
                {
                    DialogMode = true,
                    TypeFilter = GrpcCommonNet.Library.Common.ContragentTypeFilter.PersonFilter,
                    ContragentTypeEnable = false,
                    CheckedPrefixEnable = false,
                    CheckedPrefix = true
                };
                smartBoxInitiator.DataSourceList(response.Contragents, "Prefix");
                smartBoxExecutor.DataSourceList(response.Contragents, "Prefix");

                smartBoxInitiator.SetModalForm(form);
                smartBoxExecutor.SetModalForm(form);

                UserFilterRequest request1 = new UserFilterRequest()
                {
                    FieldMask = new FieldMask() { Paths = { "id", "contragent.name" } }
                };
                ListUserResponse response1 = await GrpcRetry.CallAsync(() =>
                    GrpcClients.GrpcClients.User.GetListUserAsync(request1).ResponseAsync
                );

                UsersForm form1 = new UsersForm() { DialogMode = true };
                smartBoxCreator.DataSourceList(response1.Users, "Contragent.Name");
                smartBoxCreator.SetModalForm(form1);

            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Join(Environment.NewLine,
                    "Ошибка при загрузки данных",
                    ex.Message));
            }
        }
    }
}
