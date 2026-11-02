using C1.Win.TreeView;
using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Library.Geolocation;
using GrpcWinForms.Controls.TreeBox;
using GrpcWinForms.Objects.DocumentTypes.Repositories;
using GrpcWinForms.Objects.StockDocuments.Models;
using GrpcWinForms.Objects.StockDocuments.Repositories;
using GrpcWinForms.Objects.StockDocuments.Views;
using GrpcWinForms.Objects.Stocks.Repositories;
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
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Возвращает список мест хранения в виде дерева (TreePlace) на основе переданного объекта Place.
        /// </summary>
        /// <param name="place">Объект Place, для которого необходимо получить список всех вложенных мест хранения.</param>
        /// <returns>Список объектов TreePlace, представляющих дерево мест хранения от объекта Place.</returns>
        public async Task<List<TreePlace>> GetPlace(Place place)
        {
            try
            {
                if (place == null) place = new();
                List<GeoPlace> places = await StocksReposirory.GetGeoPlacesAsync(place);

                List<TreePlace> items = new List<TreePlace>();
                foreach (GeoPlace p in places)
                {
                    items.Add(new TreePlace()
                    {
                        Id = p.Id,
                        ParentId = p.ParentId,
                        Name = p.Place.Name
                    });
                }
                return items;

            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return new List<TreePlace>();
        }

        public async Task<List<DocumentType>> GetDocumentTypes(DocumentType type)
        {
            try
            {
                if (type == null) type = new() { Code = "WHDocuments" };
                //List<DocumentType> items = await DocumentTypesRepository.GetDocumentTypes(type);
                //return items;
                return new List<DocumentType>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return new List<DocumentType>();
        }

    }
}
