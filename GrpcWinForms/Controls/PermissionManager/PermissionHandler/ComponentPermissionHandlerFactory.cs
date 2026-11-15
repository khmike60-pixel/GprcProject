using C1.Win.Command;
using C1.Win.FlexGrid;
using C1.Win.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcWinForms.Controls.PermissionManager.PermissionHandler
{
    internal class ComponentPermissionHandlerFactory
    {
        private readonly DropDownControlPermissionHandler _dropDownControlHandler;
        private readonly ButtonPermissionHandler _buttonHandler;
        private readonly CommandLinkPermissionHandler _commandLinkHandler;
        private readonly C1FlexGridPermissionHandler _gridLinkHandler;
        private readonly DefaultPermissionHandler _defaultHandler;

        public ComponentPermissionHandlerFactory()
        {
            _dropDownControlHandler = new DropDownControlPermissionHandler();
            _buttonHandler = new ButtonPermissionHandler();
            _commandLinkHandler = new CommandLinkPermissionHandler();
            _gridLinkHandler = new C1FlexGridPermissionHandler();
            _defaultHandler = new DefaultPermissionHandler();
        }

        public BasePermissionHandler GetHandler(object component)
        {
            switch (component)
            {
                case C1DropDownControl _: return _dropDownControlHandler;
                case C1Button _: return _buttonHandler;
                case Button _: return _buttonHandler;
                case C1CommandLink _: return _commandLinkHandler;
                case C1FlexGrid _: return _gridLinkHandler;
                default: return _defaultHandler;
            }
        }
    }
}
