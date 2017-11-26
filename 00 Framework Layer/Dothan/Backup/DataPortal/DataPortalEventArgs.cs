using System;


namespace Dothan
{
    public class DataPortalEventArgs : EventArgs
    {
        private Server.DataPortalContext _dataPortalContext;

        public Server.DataPortalContext DataPortalContext
        {
            get { return _dataPortalContext; }
        }

        public DataPortalEventArgs(Server.DataPortalContext dataPortalContext)
        {
            _dataPortalContext = dataPortalContext;
        }
    }
}
