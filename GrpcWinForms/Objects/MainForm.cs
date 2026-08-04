
using GrpcWinForms.Models;
using GrpcWinForms.Objects;
using GrpcWinForms.Objects.Applications;
using GrpcWinForms.Objects.Contracts.Forms;
using GrpcWinForms.Objects.DocumentTypes.Forms;
using GrpcWinForms.Objects.Contragents.Components;
using GrpcWinForms.Objects.Contragents.Forms;
using GrpcWinForms.Objects.Currencies.Forms;
using GrpcWinForms.Objects.Geolocations.GeoForms;
using GrpcWinForms.Objects.OurCompanies.Forms;
using GrpcWinForms.Objects.Products.ProductsForm;
using GrpcWinForms.Objects.Test;
using GrpcWinForms.Objects.Users.Forms;
using System;
using System.Windows.Forms;
using GrpcWinForms.Objects.Departaments;

namespace GrpcWinForms.Forms
{

    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.Text = $"Приложение {MainClass.AppName} ({MainClass.HostName})";
            IsMdiContainer = true;
            //InitMenu();
        }

        private void CurrenciesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form child in MdiChildren)
            {
                if (child is CurrenciesForm) { child.Activate(); return; }
            }
            var f = new CurrenciesForm { MdiParent = this };
            f.Show();
        }

        private void UnitsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form child in MdiChildren)
            {
                if (child is CurrenciesForm) { child.Activate(); return; }
            }
            var f = new UnitsForm { MdiParent = this };
            f.Show();

        }

        private void ApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form child in MdiChildren)
            {
                if (child is ApplicationsForm) { child.Activate(); return; }
            }
            var f = new ApplicationsForm { MdiParent = this };
            f.Show();

        }

        private void ContragentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form child in MdiChildren)
            {
                if (child is ContragentsForm) { child.Activate(); return; }
            }
            var f = new ContragentsForm { MdiParent = this };
            f.Show();

        }

        private void географияToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void GeolocationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form child in MdiChildren)
            {
                if (child is GeolocationsForm) { child.Activate(); return; }
            }
            var f = new GeolocationsForm { MdiParent = this };
            f.Show();
        }

        private void RatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form child in MdiChildren)
            {
                if (child is RatesForm) { child.Activate(); return; }
            }
            var f = new RatesForm { MdiParent = this };
            f.Show();
        }

        private void ProductsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form child in MdiChildren)
            {
                if (child is ProductsForm) { child.Activate(); return; }
            }
            var f = new ProductsForm { MdiParent = this };
            f.Show();
        }

        private void ToolStripMenuItemContrtacts_Click(object sender, EventArgs e)
        {
            foreach (Form child in MdiChildren)
            {
                if (child is ContractsForm) { child.Activate(); return; }
            }
            var f = new ContractsForm { MdiParent = this };
            f.Show();

        }

        private void UsersOfAppToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form child in MdiChildren)
            {
                if (child is UsersForm) { child.Activate(); return; }
            }
            var f = new UsersForm { MdiParent = this };
            f.Show();
        }

        private void тестоваяФормаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form child in MdiChildren)
            {
                if (child is TestLookup) { child.Activate(); return; }
            }
            var f = new TestLookup { MdiParent = this };
            f.Show();
        }

        private void DocumentTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form child in MdiChildren)
            {
                if (child is DocumentTypesForm) { child.Activate(); return; }
            }
            var f = new DocumentTypesForm { MdiParent = this };
            f.Show();
        }

        private void ContractTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form child in MdiChildren)
            {
                if (child is DocumentTypesForm) { child.Activate(); return; }
            }
            var f = new DocumentTypesForm { MdiParent = this };
            f.HeadCode = "Contracts";
            f.Show();

        }

        private void DepartmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form child in MdiChildren)
            {
                if (child is DepartamentsForm) { child.Activate(); return; }
            }
            var f = new DepartamentsForm { MdiParent = this };
            f.Show();
        }

        private void OurCompanyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form child in MdiChildren)
            {
                if (child is OurCompaniesForm) { child.Activate(); return; }
            }
            var f = new OurCompaniesForm { MdiParent = this };
            f.Show();

        }
    }
}
