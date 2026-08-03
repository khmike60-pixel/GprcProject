using GrpcCommonNet.Library.Common;
using GrpcWinForms.Objects.Contracts.Forms.ContractViews;
using Microsoft.VisualBasic.ApplicationServices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrpcWinForms.Objects.Contracts.Forms
{
    public partial class SetupSpecificationForm : Form
    {
        private string _stringJson;

        public string StringJson
        {
            get => _stringJson;
            set => _stringJson = value;
        }

        private List<Specification> specifications = new List<Specification>();

        public SetupSpecificationForm()
        {
            InitializeComponent();
        }

        private List<Specification> Fill(string string_json)
        {
            var list = new List<Specification>();
            if (string.IsNullOrEmpty(string_json))
                string_json = "[{\"Order\": 1,\"Name\":\"Спецификация\",\"Comment\":\"\"}]";

            specifications = JsonConvert.DeserializeObject<List<Specification>>(string_json);

            foreach (var specification in specifications)
            {
                list.Add(new Specification
                {
                    Order = specification.Order,
                    Name = specification.Name,
                    Comment = specification.Comment
                });
            }
            return list;
        }

        private void SetupSpecificationForm_Load(object sender, EventArgs e)
        {
            smartGrid.DataSource = Fill(StringJson);
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            StringJson = JsonConvert.SerializeObject(specifications, Formatting.Indented);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }

    
}
