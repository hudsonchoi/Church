using System;
using System.Security.Principal;
using System.Threading;
using System.Collections.Specialized;

namespace Dothan.Server
{
    [Serializable()]
    public class DataPortalContext
    {
        private IPrincipal _principal;
        private bool _remotePortal;
        private string _clientCulture;
        private string _clientUICulture;
        private HybridDictionary _clientContext;
        private HybridDictionary _globalContext;

        public IPrincipal Principal
        {
            get { return _principal; }
        }


        public bool IsRemotePortal
        {
            get { return _remotePortal; }
        }


        public string ClientCulture
        {
            get { return _clientCulture; }
        }

        public string ClientUICulture
        {
            get { return _clientUICulture; }
        }
        internal HybridDictionary ClientContext
        {
            get { return _clientContext; }
        }

        internal HybridDictionary GlobalContext
        {
            get { return _globalContext; }
        }

        public DataPortalContext(IPrincipal principal, bool isRemotePortal)
        {
            if (isRemotePortal)
            {
                _principal = principal;
                _remotePortal = isRemotePortal;
                _clientCulture =System.Threading.Thread.CurrentThread.CurrentCulture.Name;
                _clientUICulture = System.Threading.Thread.CurrentThread.CurrentUICulture.Name;
                _clientContext = Dothan.ApplicationContext.GetClientContext();
                _globalContext = Dothan.ApplicationContext.GetGlobalContext();
            }
        }
    }
}
