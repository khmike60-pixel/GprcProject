using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Library.Geolocation;
using GrpcWinForms.Objects.Currencies.Views.Interfaces;
using GrpcWinForms.Objects.Stocks.Models;
using GrpcWinForms.Objects.Stocks.Repositories;
using GrpcWinForms.Objects.Stocks.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            try
            {
                List<Stock> stocks = await StocksReposirory.GetStocksAsync(_view.NameText);
                _view.Stocks = new BindingList<Stock>(stocks);
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Join(Environment.NewLine,
                    "Ошибка при получении списка складов",
                    ex.Message), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public async Task RefreshPlaces(Stock stock)
        {
            try
            {
                List<GeoPlace> geoplaces = await StocksReposirory.GetGeoPlacesAsync(stock);
                //_view.GeoPlaces = new BindingList<GeoPlace>(geoplaces);
                List<TreePlace> tree = new();
                foreach (GeoPlace geoplace in geoplaces)
                {
                    TreePlace item = new TreePlace()
                    { Id = geoplace.Id, ParentId = geoplace.ParentId, Name = geoplace.Place.Name };
                    tree.Add(item);
                }
                
                _view.Places = tree;

            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Join(Environment.NewLine,
                    "Ошибка при получении списка мест хранения",
                    ex.Message), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public async Task<List<TreePlace>> Builder(BindingList<GeoPlace> places)
        {
            List<TreePlace> tree = new();
            foreach (GeoPlace geoplace in places)
            {
                TreePlace item = new TreePlace()
                { Id = geoplace.Id, ParentId = geoplace.ParentId, Name = geoplace.Place.Name };
                tree.Add(item);
            }
            return tree;
        }
    
        public async Task AddEditStock(Stock stock)
        {

        }

        public async Task DeleteStock(IList<int> selectedRows)
        {

        }
    
    }
}
