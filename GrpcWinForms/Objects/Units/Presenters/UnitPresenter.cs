using GrpcCommonNet.Library.Common;
using GrpcWinForms.Objects.Units.Views;

namespace GrpcWinForms.Objects.Units.Presenters
{
    public class UnitPresenter
    {
        private readonly IUnitView _view;

        public UnitPresenter(IUnitView view)
        {
            _view = view;
        }

        public void OnLoad()
        {
            // Заполнить поля формы данными модели
            _view.SetFieldsFromUnit(_view.EditUnit);
            _view.AppendTitle(_view.IsTypeInsert ? " (Добавление)" : " (Редактирование)");
        }

        public void OnOk()
        {
            // Считать значения из view в EditUnit
            var u = _view.EditUnit ?? new Unit();
            u.Id = string.IsNullOrEmpty(_view.IdText) ? 0 : int.Parse(_view.IdText);
            u.Short = _view.ShortText;
            u.Rem = _view.RemText;
            u.RwsCode = _view.RwsCodeText;
            u.RwsMcode = _view.RwsMcodeText;
            u.Comment = _view.CommentText;
            u.Code = _view.CodeText;
            u.IsArchive = _view.IsArchiveChecked;

            _view.EditUnit = u;

            _view.CloseWithResult(DialogResult.OK);
        }

        public void OnCancel()
        {
            _view.CloseWithResult(DialogResult.Cancel);
        }
    }
}