using GrpcWinForms.Controls.UserPermissionsUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcWinForms.Controls.UserPermissionsUI.Views.Interfaces
{
    public interface IRightObjectsManagerView
    {
        event Action OnLoad;
        event Action<RightObjectTreeModel> OnRefresh;
        event Action<int> OnAdd;
        event Action<RightObjectTreeModel> OnEdit;
        event Action<RightObjectTreeModel> OnDelete;
        event Action<RightObjectTreeModel, RightObjectTreeModel> OnMove;

        void Show();
        void Refresh(IEnumerable<RightObjectTreeModel> data, RightObjectTreeModel selectedModel);
    }
}
