using C1.Win.Input;
using C1.Win.Input.MultiColumnCombo;
using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Library.Contragent;
using GrpcWinForms.Objects.Contragents.Components;
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
    public partial class TestLookup : Form
    {
        private List<ShortContragent> _contragents = new List<ShortContragent>();
        private BindingList<ShortContragent> _bindingList = new BindingList<ShortContragent>();
        private ListContragentResponse searchResponse;
        private string _text = String.Empty;

        public TestLookup()
        {
            InitializeComponent();
            ConfigCustomView();
            ConfigDropDownControl();
        }

        private void ConfigCustomView()
        {
            DropDownViewCustomControl customView = new DropDownViewCustomControl();
            c1MultiColumnComboCustom.DropDownView = DropDownView.Custom;
            c1MultiColumnComboCustom.CustomView = customView;

            _bindingList = GetData("");
            customView.DataSource = _bindingList;

        }

        private void ConfigDropDownControl()
        {
            c1DropDownControl1.Control = new DropDownUserControl();

        }

        private BindingList<ShortContragent> GetData(string filter)
        {
            SearchRequest searchRequest = new SearchRequest()
            {
                Search = filter,
                Paging = new Paging() { PageNumber = 1, PageSize = 100 }
            };

            searchRequest.FieldMask =
                new Google.Protobuf.WellKnownTypes.FieldMask() { Paths = { "id", "name", "taxno" } };

            searchResponse = GrpcClients.GrpcClients.Contragent.SearchListContragent(searchRequest);

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

        #region События  c1MultiColumnComboCustom
        private void c1MultiColumnComboCustom_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (c1MultiColumnComboCustom.SelectedIndex >= 0)
            {
                int selectedIndex = c1MultiColumnComboCustom.CustomView.SelectedIndex;
                var view = c1MultiColumnComboCustom.CustomView;

                if (selectedIndex > -1)
                {
                    ShortContragent selectedItem = _bindingList[selectedIndex];
                    c1MultiColumnComboCustom.Text = selectedItem.Name;
                    var value = ((DropDownViewCustomControl)c1MultiColumnComboCustom.CustomView).Value;

                }
            }
        }

        private void c1MultiColumnComboCustom_TextChanged(object sender, EventArgs e)
        {
            _bindingList = GetData(c1MultiColumnComboCustom.Text);
            c1MultiColumnComboCustom.CustomView.DataSource = _bindingList;
        }

        #endregion

        
    }

    public class ShortContragent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TaxNo { get; set; }
    }
}
