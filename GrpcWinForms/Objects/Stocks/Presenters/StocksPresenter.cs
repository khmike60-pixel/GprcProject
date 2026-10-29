using GrpcWinForms.Objects.Currencies.Views.Interfaces;
using GrpcWinForms.Objects.Stocks.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcWinForms.Objects.Stocks.Presenters
{
    public class StocksPresenter
    {
        private readonly IStocks _view;

        public StocksPresenter(IStocks view)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
        }

        public async Task RefreshStocks()
        {

        }
    }
}
