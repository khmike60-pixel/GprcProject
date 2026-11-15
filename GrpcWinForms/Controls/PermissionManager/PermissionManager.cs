using GrpcCommonNet.Library.Common;
using GrpcWinForms.Controls.PermissionManager.Exceptions;
using GrpcWinForms.Controls.PermissionManager.Initializers;
using GrpcWinForms.Controls.PermissionManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcWinForms.Controls.PermissionManager
{
    public class PermissionManager
    {
        Form _form;
        IPermissionService _permissionService;
        IFormInitializer _formInitializer;
        IFormComponentsInitializer _formComponentsInitializer;

        public PermissionSubjects PermissionSubjects
        {
            set
            {
                _permissionService = new PermissionService(value);
                _formInitializer.PermissionService = _permissionService;
                _formComponentsInitializer.PermissionService = _permissionService;
            }
        }

        public PermissionManager(Form form, PermissionSubjects subjects)
        {
            _form = form;
            _permissionService = new PermissionService(subjects);
            _formInitializer = new FormInitializer(_permissionService);
            _formComponentsInitializer = new FormComponentsInitializer(_permissionService);
        }

        public PermissionManager(Form form)
            : this(form, new PermissionSubjects() { GlobalSubjectId = GlobalConfig.GlobalSubjectId, LocalSubjectId = GlobalConfig.LocalSubjectId })
        { }

        public void Initialize()
        {
            try
            {
                _formInitializer.InitializeForm(_form);
                _formComponentsInitializer.InitializeComponents(_form);
            }
            catch (FormNoAccessException)
            {
                MessageBox.Show("У вас нет доступа на просмотр этой формы!", "Нет доступа",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                _form.BeginInvoke(new MethodInvoker(_form.Close));
            }
            catch (FormTagNotFound)
            {
                MessageBox.Show("Указанный объект права не найден!", "Нет доступа",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                _form.BeginInvoke(new MethodInvoker(_form.Close));
            }
            catch
            {
                MessageBox.Show("Произошла ошибка при инициализации формы!", "Ошибка инициализации",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                _form.BeginInvoke(new MethodInvoker(_form.Close));
            }
        }

        /// <summary> Вернет true если форма доступна для просмотра. </summary>
        public bool CanShowForm()
        {
            try
            {
                // temp 
                _formInitializer.InitializeForm(_form);
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
