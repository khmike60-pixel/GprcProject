using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcWinForms.Objects.Auth.Views
{
    public interface IAuth
    {
        #region Методы
        void ShowError(string message);
        void SetBusy(bool busy);
        #endregion

        #region Свойства UI
        string LoginTxt { get; set; }
        string PasswordTxt { get; set; }

        #endregion

    }
}
