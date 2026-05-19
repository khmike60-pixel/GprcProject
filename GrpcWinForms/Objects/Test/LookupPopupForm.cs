using C1.Win.FlexGrid;
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
    public partial class LookupPopupForm : Form
    {
        public C1FlexGrid Grid => flexGrid;

        public LookupPopupForm()
        {
            InitializeComponent();

            FormBorderStyle = FormBorderStyle.None;
            StartPosition = FormStartPosition.Manual;
            ShowInTaskbar = false;
            TopMost = true;

            flexGrid.BorderStyle = C1.Win.FlexGrid.Util.BaseControls.BorderStyleEnum.None;
            flexGrid.SelectionMode = SelectionModeEnum.Row;
            flexGrid.KeyActionEnter = KeyActionEnum.None;
            flexGrid.KeyActionTab = KeyActionEnum.None;
            flexGrid.AutoGenerateColumns = false;
            flexGrid.AllowEditing = false;
            flexGrid.AllowSorting = AllowSortingEnum.None;
            flexGrid.FocusRect = FocusRectEnum.None;
        }
    }
}
