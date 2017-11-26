using System;
using System.Threading;
using System.Security.Principal;
using System.Collections.Specialized;
using System.Configuration;
using System.Web;
namespace Dothan
{
    public static class ApplicationContext
    {

        #region User


        public static IPrincipal User
        {
            get
            {
                if (HttpContext.Current == null)
                    return Thread.CurrentPrincipal;
                else
                    return HttpContext.Current.User;
            }
            set
            {
                if (HttpContext.Current != null)
                    HttpContext.Current.User = value;
                Thread.CurrentPrincipal = value;
            }
        }

        #endregion

        #region Client/Global Context

  
        public static HybridDictionary ClientContext
        {
            get
            {
                HybridDictionary ctx = GetClientContext();
                if (ctx == null)
                {
                    ctx = new HybridDictionary();
                    SetClientContext(ctx);
                }
                return ctx;
            }
        }

        public static HybridDictionary GlobalContext
        {
            get
            {
                HybridDictionary ctx = GetGlobalContext();
                if (ctx == null)
                {
                    ctx = new HybridDictionary();
                    SetGlobalContext(ctx);
                }
                return ctx;
            }
        }

        internal static HybridDictionary GetClientContext()
        {
            if (HttpContext.Current == null)
            {
                LocalDataStoreSlot slot =Thread.GetNamedDataSlot("Dothan.ClientContext");
                return (HybridDictionary)Thread.GetData(slot);
            }
            else
                return (HybridDictionary)HttpContext.Current.Items["Dothan.ClientContext"];
        }

        internal static HybridDictionary GetGlobalContext()
        {
            if (HttpContext.Current == null)
            {
                LocalDataStoreSlot slot = Thread.GetNamedDataSlot("Dothan.GlobalContext");
                return (HybridDictionary)Thread.GetData(slot);
            }
            else
                return (HybridDictionary)HttpContext.Current.Items["Dothan.GlobalContext"];
        }

        private static void SetClientContext(HybridDictionary clientContext)
        {
            if (HttpContext.Current == null)
            {
                LocalDataStoreSlot slot = Thread.GetNamedDataSlot("Dothan.ClientContext");
                Thread.SetData(slot, clientContext);
            }
            else
                HttpContext.Current.Items["Dothan.ClientContext"] = clientContext;
        }

        internal static void SetGlobalContext(HybridDictionary globalContext)
        {
            if (HttpContext.Current == null)
            {
                LocalDataStoreSlot slot = Thread.GetNamedDataSlot("Dothan.GlobalContext");
                Thread.SetData(slot, globalContext);
            }
            else
                HttpContext.Current.Items["Dothan.GlobalContext"] = globalContext;
        }

        internal static void SetContext(
          HybridDictionary clientContext,
          HybridDictionary globalContext)
        {
            SetClientContext(clientContext);
            SetGlobalContext(globalContext);
        }

        public static void Clear()
        {
            SetContext(null, null);
        }

        #endregion

        #region Config Settings

   
        public static string AuthenticationType
        {
            get { return ConfigurationManager.AppSettings["DothanAuthentication"]; }
        }

      
        /// </remarks>
        public static string DataPortalProxy
        {
            get
            {
                string result = ConfigurationManager.AppSettings["DothanDataPortalProxy"];
                if (string.IsNullOrEmpty(result))
                    result = "Local";
                return result;
            }
        }

      
        public static Uri DataPortalUrl
        {
            get { return new Uri(ConfigurationManager.AppSettings["DothanDataPortalUrl"]); }
        }

        public enum ExecutionLocations
        {
            Client,
            Server
        }

        #endregion

        #region In-Memory Settings

        private static ExecutionLocations _executionLocation =
          ExecutionLocations.Client;

    
        public static ExecutionLocations ExecutionLocation
        {
            get { return _executionLocation; }
        }

        internal static void SetExecutionLocation(ExecutionLocations location)
        {
            _executionLocation = location;
        }

        #endregion
    }
}
