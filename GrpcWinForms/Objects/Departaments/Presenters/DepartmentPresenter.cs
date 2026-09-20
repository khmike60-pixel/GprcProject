using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Library.Department;
using GrpcWinForms.Objects.Departaments.Views;
using System;

namespace GrpcWinForms.Objects.Departaments.Presenters
{
    public class DepartmentPresenter
    {
        private readonly IDepartmentView _view;

        public DepartmentPresenter(IDepartmentView view)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _view.LoadView += OnLoad;
            _view.OkClicked += OnOkClicked;
            _view.CancelClicked += OnCancelClicked;
        }

        private void OnLoad(object? sender, EventArgs e)
        {
            // Заполняем контролы из модели Department (если задана)
            var d = _view.Department ?? new Department();
            _view.IdText = d.Id.ToString();
            _view.NameText = d.Name ?? string.Empty;
            _view.ShortText = d.Short ?? string.Empty;
            _view.CodeText = d.Symbol ?? string.Empty;
        }

        private void OnOkClicked(object? sender, EventArgs e)
        {
            try
            {
                var dept = _view.Department ?? new Department();

                // Парсим Id безопасно
                if (int.TryParse(_view.IdText, out int id))
                    dept.Id = id;
                else
                    dept.Id = 0;

                dept.Name = _view.NameText ?? string.Empty;
                dept.Short = _view.ShortText ?? string.Empty;
                dept.Symbol = _view.CodeText ?? string.Empty;

                _view.Department = dept;
                _view.CloseWithOk();
            }
            catch (Exception ex)
            {
                _view.ShowMessage("Ошибка при сохранении данных: " + ex.Message);
            }
        }

        private void OnCancelClicked(object? sender, EventArgs e)
        {
            // Ничего не делаем — форма сама закроется по событию
        }
    }
}