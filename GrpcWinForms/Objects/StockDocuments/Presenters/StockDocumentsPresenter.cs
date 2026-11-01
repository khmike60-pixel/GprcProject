using C1.Win.TreeView;
using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Library.Geolocation;
using GrpcWinForms.Objects.StockDocuments.Repositories;
using GrpcWinForms.Objects.StockDocuments.Views;
using GrpcWinForms.Objects.Stocks.Repositories;
using GrpcWinForms.Objects.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcWinForms.Objects.StockDocuments.Presenters
{
    public class StockDocumentsPresenter
    {
        private IStockDocuments _view;

        public StockDocumentsPresenter(IStockDocuments view)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
        }

        public async void LoadStockDocuments()
        {
            var operations = await StockDocumentsRepository.GetStockDocuments(
                _view.Period.Period,
                _view.ContragentTo,
                _view.ContragentFrom,
                _view.StockTo,
                _view.StockFrom,
                _view.Type,
                _view.Number);

            _view.Operations = new System.ComponentModel.BindingList<StockOperation>(operations.ToList());
        }

        public async Task<List<TreeItem>> GetPlaceTo()
        {
            try
            {
                if (_view.PlaceTo == null) _view.PlaceTo = new();
                var placeTo = _view.PlaceTo;
                if (placeTo != null) placeTo = new();
                List<GeoPlace> places = await StocksReposirory.GetGeoPlacesAsync(placeTo);

                List<TreeItem> itemsTo = new List<TreeItem>();
                foreach (GeoPlace p in places)
                {
                    itemsTo.Add(new TreeItem()
                    {
                        Id = p.Id,
                        ParentId = p.ParentId,
                        Name = p.Place.Name
                    });
                }
                return itemsTo;

            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return new List<TreeItem>();
        }

        public async Task<List<TreeItem>> GetPlaceFrom()
        {
            try
            {
                if (_view.PlaceFrom == null) _view.PlaceFrom = new();
                var placeFrom = _view.PlaceFrom;
                if (placeFrom != null) placeFrom = new();
                List<GeoPlace> places = await StocksReposirory.GetGeoPlacesAsync(placeFrom);

                List<TreeItem> itemsFrom = new List<TreeItem>();
                foreach (GeoPlace p in places)
                {
                    itemsFrom.Add(new TreeItem()
                    {
                        Id = p.Id,
                        ParentId = p.ParentId,
                        Name = p.Place.Name
                    });
                }
                return itemsFrom;
            } catch  (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return new List<TreeItem>();
        }



    }
}
