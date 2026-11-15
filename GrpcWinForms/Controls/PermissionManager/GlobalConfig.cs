using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcWinForms.Controls.PermissionManager
{
    public static class GlobalConfig
    {
        /// <summary> True - использовать систему прав. </summary>
        public static bool Enabled = false;

        /// <summary> Имя локальной БД. </summary>
        public static string LocalDataBase = string.Empty;

        /// <summary> Имя глобальной БД. </summary>
        public static string GlobalDataBase = string.Empty;

        /// <summary> Идентификатор глобального субъекта. </summary>
        public static int GlobalSubjectId;

        /// <summary> Идентификатор локального субъекта. </summary>
        public static int LocalSubjectId;
    }
}
