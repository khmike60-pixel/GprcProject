using GrpcCommonNet.Library.Common;
using SmartLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcWinForms.Objects.Locations.Views
{ 
    public interface ILocations
    {
        bool DialogMode { get; set; }

        /// <summary>
        /// Текущий объект (на  котором стоит курсор)
        /// </summary>
        Location CurrentLocation { get; set; }
        BindingList<Location> Locations { get; set; }

        #region Объекты интерфейса
        LocationType Type { get; }
        string TextString {  get; }
        SmartGrid Grid { get; set; }
        #endregion


    }
}
