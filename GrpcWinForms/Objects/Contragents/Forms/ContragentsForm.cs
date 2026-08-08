using Google.Protobuf.WellKnownTypes;
using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Library.Contragent;
using GrpcWinForms.GrpcUtils;
using GrpcWinForms.Models;
using SmartGrid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrpcWinForms.Objects.Contragents.Forms
{
    public partial class ContragentsForm : Form
    {
        private static ContragentServices.ContragentServicesClient _service;
        private Loader loaderContragent = new Loader();
        int row = 0;
        public bool ModeEdit { get; set; } = false;
        public Contragent SelectedContragent { get; set; } = null;

        public ContragentsForm()
        {
            InitializeComponent();

            loaderContragent.Parent = smartGrid;
            loaderContragent.Size = smartGrid.Size;

            c1SplitterPanel2.Collapsed = true;
        }

        private void ContragentsForm_Load(object sender, EventArgs e)
        {
            comboBoxType.SelectedIndex = 0;
            Refresh(sender, e);
        }

        private async Task<bool> Refresh(object sender, EventArgs e)
        {
            loaderContragent.ShowLoader();
            try
            {
                var type = comboBoxType.SelectedIndex == 0 ? ContragentTypeFilter.All :
                           comboBoxType.SelectedIndex == 1 ? ContragentTypeFilter.EntityFilter :
                           comboBoxType.SelectedIndex == 2 ? ContragentTypeFilter.PersonFilter : ContragentTypeFilter.UnknownFilter;

                ContragentFilterRequest request = new ContragentFilterRequest()
                {
                    TypeFilter = type,
                    Taxno = string.IsNullOrWhiteSpace(textBoxTaxno.Text) ? String.Empty : textBoxTaxno.Text,
                    Name = string.IsNullOrWhiteSpace(textBoxName.Text) ? String.Empty : textBoxName.Text,
                    //CountrySymbol = comboBoxCountry.SelectedValue.ToString() ?? String.Empty
                };
                request.FieldMask = new Google.Protobuf.WellKnownTypes.FieldMask()
                {
                    Paths = { "id", "name", "taxno", "type", "country_symbol" }
                };
                CountListContragentResponse responseCount = await GrpcRetry.CallAsync(()=>
                    GrpcClients.GrpcClients.Contragent.CountListContragentAsync(request).ResponseAsync
                );

                ListContragentResponse response = await GrpcRetry.CallAsync(()=>
                    GrpcClients.GrpcClients.Contragent.ShortListContragentAsync(request).ResponseAsync
                );


                BindingList<Contragent> contragents = new BindingList<Contragent>(response.Contragents);
                smartGrid.DataSource = contragents;
                loaderContragent.HideLoader();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
                // test

            }
        }

        private void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            Refresh(sender, e);
        }

        private async void smartGrid_AfterSelChange(object sender, C1.Win.FlexGrid.RangeEventArgs e)
        {
            if (smartGrid.RowSel <= smartGrid.Rows.Fixed - 1) return;
            if (row == smartGrid.Row) return;
            else row = smartGrid.Row;

            Contragent contragent = (Contragent)smartGrid.Rows[smartGrid.RowSel].DataSource;

            contragent = await GetContragent(contragent.Id);
            try
            {
                if (contragent.Type == ContragentType.Entity)
                {
                    EntityControlFill(contragent);
                    c1DockingTabPageEntity.TabVisible = true;
                    c1DockingTabPagePerson.TabVisible = false;
                    c1DockingTabPageUnknow.TabVisible = false;
                }
                else if (contragent.Type == ContragentType.Person)
                {
                    PersonControlFill(contragent);
                    c1DockingTabPageEntity.TabVisible = false;
                    c1DockingTabPagePerson.TabVisible = true;
                    c1DockingTabPageUnknow.TabVisible = false;
                }
                else
                {
                    UnknowComtrolFill(contragent);
                    c1DockingTabPageEntity.TabVisible = false;
                    c1DockingTabPagePerson.TabVisible = false;
                    c1DockingTabPageUnknow.TabVisible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return;

            /*
            entityControlMain.textBoxTaxno.Text = smartGrid[smartGrid.Row, "Taxno"].ToString();
            entityControlMain.textBoxName.Text = smartGrid[smartGrid.Row, "Name"].ToString();
            entityControlMain.textBoxId.Text = smartGrid[smartGrid.Row, "Id"].ToString();
            entityControlMain.textBoxPrefix.Text = smartGrid[smartGrid.Row, "PrefixCode"].ToString();
            entityControlMain.c1DropDownControlCountry.Text = smartGrid[smartGrid.Row, "CountrySymbol"].ToString();
            entityControlMain.dateTimePickerDateActualized.Value = (DateTime)smartGrid[smartGrid.Row, "CreateDate"];
            entityControlMain.textBoxNameFull.Text = smartGrid[smartGrid.Row, "NameFull"].ToString();
            */
        }

        private async Task<Contragent> GetContragent(int id)
        {

            ContragentRequest request = new ContragentRequest()
            {
                Id = id
                //FieldMask = new FieldMask() { Paths = { "id", "name", "taxno", "type", "country_symbol", "enity" } }
            };
            ContragentResponse response = await GrpcRetry.CallAsync(()=>
                GrpcClients.GrpcClients.Contragent.GetContragentAsync(request).ResponseAsync
            );

            return response.Contragent;
        }

        private void EntityControlFill(Contragent contragent)
        {
            entityControlMain.textBoxName.Text = contragent.Name;
            entityControlMain.textBoxId.Text = contragent.Id.ToString();
            entityControlMain.textBoxTaxno.Text = contragent.Taxno;
            entityControlMain.textBoxVatCode.Text = contragent.Entity.HasEntityVatNumber ? contragent.Entity.EntityVatNumber : string.Empty;
            entityControlMain.textBoxNameFull.Text = contragent.Entity.EntityName;
            entityControlMain.textBoxNameLat.Text = contragent.Entity.HasEntityLatName ? contragent.Entity.EntityLatName : string.Empty;
            entityControlMain.dateTimePickerDateActualized.Text = contragent.Entity.EntityDateActualized == null ? "01.01.2000" : contragent.Entity.EntityDateActualized.ToDateTime().ToString();
            entityControlMain.textBoxPrefix.Text = contragent.Prefix;
            entityControlMain.c1DropDownControlCountry.Text = contragent.CountrySymbol; // Исправлять
            entityControlMain.textBoxAddress.Text = contragent.Entity.EntityAddress;
            entityControlMain.textBoxAddressLat.Text = contragent.Entity.HasEntityLatAddress ? contragent.Entity.EntityLatAddress : string.Empty;
            entityControlMain.textBoxAddressFact.Text = contragent.Entity.HasEntityFactAddress ? contragent.Entity.EntityFactAddress : string.Empty;
            entityControlMain.textBoxEntityPhone.Text = contragent.Entity.EntityPhone;
            entityControlMain.textBoxEmail.Text = contragent.Entity.EntityEmail;
            entityControlMain.textBoxSite.Text = contragent.Entity.HasEnitySite ? contragent.Entity.EnitySite : string.Empty;
            entityControlMain.textBoxContactor.Text = contragent.Entity.HasEntityContactor ? contragent.Entity.EntityContactor : string.Empty;
            entityControlMain.textBoxContactorPosition.Text = contragent.Entity.HasEntityContactorPosition ? contragent.Entity.EntityContactorPosition : string.Empty;
            entityControlMain.textBoxContactorPhone.Text = contragent.Entity.HasEntityContactorPhone ? contragent.Entity.EntityContactorPhone : string.Empty;
            entityControlMain.textBoxComment.Text = contragent.Entity.HasEnityComment ? contragent.Entity.EnityComment : string.Empty;

        }

        private void PersonControlFill(Contragent contragent)
        {
            personControlMain.textBoxSurName.Text = contragent.Person.PersonSurname;
            personControlMain.textBoxFirstName.Text = contragent.Person.PersonFirstName;
            personControlMain.textBoxPatronymic.Text = contragent.Person.PersonPatronymic;
            personControlMain.textBoxName.Text = contragent.Name;
            personControlMain.textBoxNameLat.Text = contragent.Person.PersonLatName;
            personControlMain.textBoxNameShort.Text = contragent.Name;
            personControlMain.textBoxPrefix.Text = contragent.Prefix;
            personControlMain.textBoxPassportNumber.Text = contragent.Person.PersonPassportNumber;
            personControlMain.dateTimePickerPassportDate.Text = contragent.Person.PersonPassportDateIssue == null ? string.Empty : contragent.Person.PersonPassportDateIssue.ToDateTime().ToString();
            personControlMain.dateTimePickerExpiredDate.Text = contragent.Person.PersonPassportDateExpired == null ? string.Empty : contragent.Person.PersonPassportDateExpired.ToDateTime().ToString();
            personControlMain.textBoxIssuedBy.Text = contragent.Person.PersonPassportIssuedBy;
            personControlMain.textBoxAddress.Text = contragent.Person.PersonAddressRegistration;
            personControlMain.textBoxAddressResidence.Text = contragent.Person.PersonAddressResidence;

        }

        private void UnknowComtrolFill(Contragent contragent)
        {
            unknowControl.textBoxName.Text = contragent.Name;
            unknowControl.textBoxId.Text = contragent.Id.ToString();
        }

        private void smartGrid_AfterResizeColumn(object sender, C1.Win.FlexGrid.RowColEventArgs e)
        {
            smartGrid.Cols["Name"].StarWidth = "*";
        }

        private void smartGrid_GetUnboundValue(object sender, C1.Win.FlexGrid.UnboundValueEventArgs e)
        {
            Contragent contragent = (Contragent)smartGrid.Rows[e.Row].DataSource;
            if (e.Row < smartGrid.Rows.Fixed || e.Row >= smartGrid.Rows.Count || contragent == null)
                return;
            switch (smartGrid.Cols[e.Col].Name)
            {
                case "colType":
                    {
                        switch (contragent.Type)
                        {
                            case ContragentType.Entity:
                                e.Value = "ЮЛ";
                                break;
                            case ContragentType.Person:
                                e.Value = "ФЛ";
                                break;
                            default:
                                e.Value = "Неизв.";
                                break;
                        }
                        break;
                    }
            }
        }

        private void smartGrid_DoubleClick(object sender, EventArgs e)
        {
            if (!ModeEdit) return;
            SelectedContragent = smartGrid.Rows[smartGrid.Row].DataSource as Contragent;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
