using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Library.Contract;
using GrpcWinForms.Models;
using GrpcWinForms.Objects.Contracts.ContractViews.Interfaces;
using GrpcWinForms.Objects.Contracts.ContractViews.Repositories;
using GrpcWinForms.Objects.Currencies.Repositories;
using GrpcWinForms.Objects.Currencies.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcWinForms.Objects.Contracts.ContractViews.Presenters
{
    public class ContractPresenter
    {
        private readonly IContract _view;
        ContractRepository _repo;

        public ContractPresenter(IContract view)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
        }

        public async Task RefreshAsync()
        {
            try
            {
                Contract contract = await _repo.GetContractAsync(_view.Contract.Id);

                _view.Lines = new BindingList<Line>(contract.Lines);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при получении данных: " + ex.Message, "Ошибка");
            }
        }
    }
}
