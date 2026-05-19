using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcWinForms.Objects.Test
{
    public interface ISmartLookupDataProvider<T>
    {
        Task<List<T>> SearchAsync(string text, int take = 20);
    }
}
