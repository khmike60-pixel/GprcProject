using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcWinForms.Objects.Contragents.Components
{
    public class LookupColumn
    {
        public string Name { get; set; }

        public string Caption { get; set; }

        public int Width { get; set; } = 120;

        public bool Visible { get; set; } = true;
    }
}
