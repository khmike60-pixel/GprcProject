using C1.Framework;
using C1.Win.Input;
using C1.Win.Themes;
using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Library.Contragent;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrpcWinForms.Objects.Test
{
    public partial class DropDownUserControl : UserControl, IDropDownForm
    {
        BindingList<ShortContragent> _contragents = new BindingList<ShortContragent>();

        public ShortContragent contragentSelected = null;

        public DropDownUserControl()
        {
            InitializeComponent();
            smart.DataSource = GetData("");
        }

        public BindingList<ShortContragent> GetData(string filter)
        {
            SearchRequest searchRequest = new SearchRequest()
            {
                Search = filter,
                Paging = new Paging() { PageNumber = 1, PageSize = 10 }
            };

            searchRequest.FieldMask =
                new Google.Protobuf.WellKnownTypes.FieldMask() { Paths = { "id", "name", "taxno" } };

            ListContragentResponse searchResponse = GrpcClients.GrpcClients.Contragent.SearchListContragent(searchRequest);

            _contragents.Clear();
            foreach (Contragent item in searchResponse.Contragents)
            {
                _contragents.Add(new ShortContragent()
                {
                    Id = item.Id,
                    Name = item.Name,
                    TaxNo = item.Taxno
                });
            }
            return new BindingList<ShortContragent>(_contragents);
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            int rowIndex = smart.Row;
            int bindingIndex = smart.Row - smart.Rows.Fixed;
            contragentSelected = _contragents[bindingIndex];

            C1DropDownControl parent = (C1DropDownControl)((C1.Win.Input.DropDownForm)this.Parent).DropDownOwner;

            parent.Text = contragentSelected.Name;

        }

        #region Методы интерфейса

        public bool Focusable { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool InternalFocusMovement { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void ApplyStyle(BaseStyle style, int dpi)
        {
            throw new NotImplementedException();
        }

        public void Close()
        {
            throw new NotImplementedException();
        }

        public void CloseForm()
        {
            C1DropDownControl parent = (C1DropDownControl)((C1.Win.Input.DropDownForm)this.Parent).DropDownOwner;
            parent.DroppedDown = false;
        }

        public void OpenForm()
        {
            C1DropDownControl parent = (C1DropDownControl)((C1.Win.Input.DropDownForm)this.Parent).DropDownOwner;
            parent.DroppedDown = true;

        }
        #endregion

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            CloseForm();
        }

        private void smart_DoubleClick(object sender, EventArgs e)
        {
            buttonOk_Click(sender, e);
        }
    }
}
