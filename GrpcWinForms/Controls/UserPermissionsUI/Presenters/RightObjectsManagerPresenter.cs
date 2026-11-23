using GrpcWinForms.Controls.UserPermissionsUI.Models;
using GrpcWinForms.Controls.UserPermissionsUI.Services.Implementaions;
using GrpcWinForms.Controls.UserPermissionsUI.Services.Interfaces;
using GrpcWinForms.Controls.UserPermissionsUI.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcWinForms.Controls.UserPermissionsUI.Presenters
{
    public class RightObjectsManagerPresenter
    {
        private IRightObjectsManagerView _view;
        private IRightObjectsService _objectsRightService;

        public RightObjectsManagerPresenter(IRightObjectsManagerView view, IRightObjectsService objectsRightService)
        {
            _view = view;
            _view.OnLoad += View_OnLoad;
            _view.OnRefresh += View_Refresh;
            _view.OnAdd += View_OnAdd;
            _view.OnEdit += View_OnEdit;
            _view.OnDelete += View_OnDelete;
            _view.OnMove += View_OnMove;

            _objectsRightService = objectsRightService;
        }

        public void ShowView() =>
            _view.Show();

        private async void View_OnLoad() =>
            View_Refresh();

        private async void View_Refresh(RightObjectTreeModel selectedModel = null) =>
            _view.Refresh(await _objectsRightService.GetAsync(), selectedModel);

        private void View_OnAdd(int parentId) =>
            View_Refresh(_objectsRightService.Add(parentId));

        private void View_OnEdit(RightObjectTreeModel model)
        {
            if (_objectsRightService.IsNameExists(model.Name, model.Id))
                MessageBox.Show("Имя уже существует!", "Ошибка редактирования",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (_objectsRightService.IsCodeExists(model.Code, model.Id))
                MessageBox.Show("Код уже существует!", "Ошибка редактирования",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                _objectsRightService.Edit(model);

            View_Refresh(model);
        }

        private void View_OnDelete(RightObjectTreeModel model)
        {
            if (_objectsRightService.HasForeignKey(model.Id))
            {
                MessageBox.Show("У некоторых ролей установлены значения этого права!",
                    "Ошибка удаления", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_objectsRightService.HasChilds(model.Id))
            {
                MessageBox.Show("Удаление подгрупп невозможно!",
                    "Ошибка удаления", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (MessageBox.Show("Вы действительно хотите удалить право?", "Подтвердить удаление",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                return;


            _objectsRightService.Delete(model);
            View_Refresh();
        }

        private void View_OnMove(RightObjectTreeModel model, RightObjectTreeModel parentModel)
        {
            _objectsRightService.Move(model, parentModel);
            View_Refresh(model);
        }



    }
}
