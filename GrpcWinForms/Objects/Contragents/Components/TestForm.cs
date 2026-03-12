using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrpcWinForms.Objects.Contragents.Components
{
    public partial class TestForm : Form
    {
        List<Customer> customers;
        public TestForm()
        {
            InitializeComponent();

            GenerateData();

            lookup.DataProvider = SearchCustomers;
        }

        private IEnumerable<LookupItem> SearchCustomers(string text)
        {
            return customers
                .Where(x => x.Name.Contains(text,
                    System.StringComparison.OrdinalIgnoreCase))
                .Select(x => new LookupItem
                {
                    Value = x.Id,
                    DisplayValue = x.Name
                });
        }

        private void GenerateData()
        {
            customers = new List<Customer>();

            for (int i = 1; i <= 100; i++)
            {
                customers.Add(new Customer
                {
                    Id = i,
                    Name = "Customer " + i
                });
            }
            
        }
    }

    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
