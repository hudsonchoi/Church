using System;
using System.Threading;
using System.Reflection;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using Dothan.Properties;

namespace Dothan
{
    public static class DataPortal
    {
        #region DataPortal events

       
        public static event Action<DataPortalEventArgs> DataPortalInvoke;

    
        public static event Action<DataPortalEventArgs> DataPortalInvokeComplete;

        private static void OnDataPortalInvoke(DataPortalEventArgs e)
        {
            Action<DataPortalEventArgs> action = DataPortalInvoke;
            if (action != null)
                action(e);
        }

        private static void OnDataPortalInvokeComplete(DataPortalEventArgs e)
        {
            Action<DataPortalEventArgs> action = DataPortalInvokeComplete;
            if (action != null)
                action(e);
        }

        #endregion

        #region Data Access methods

 
        public static T Create<T>(object criteria)
        {
            return (T)Create(typeof(T), criteria);
        }

    
        public static T Create<T>()
        {
            return (T)Create(typeof(T), null);
        }

        
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2223:MembersShouldDifferByMoreThanReturnType")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter")]
        public static object Create(object criteria)
        {
            return Create(MethodCaller.GetObjectType(criteria), criteria);
        }

        private static object Create(Type objectType, object criteria)
        {
            Server.DataPortalResult result;

            MethodInfo method =
              MethodCaller.GetMethod(objectType, "DataPortal_Create", criteria);

            DataPortalClient.IDataPortalProxy proxy;
            proxy = GetDataPortalProxy(RunLocal(method));

            Server.DataPortalContext dpContext =
              new Dothan.Server.DataPortalContext(GetPrincipal(), proxy.IsServerRemote);

            OnDataPortalInvoke(new DataPortalEventArgs(dpContext));

            try
            {
                result = proxy.Create(objectType, criteria, dpContext);
            }
            catch (Server.DataPortalException ex)
            {
                result = ex.Result;
                if (proxy.IsServerRemote)
                    ApplicationContext.SetGlobalContext(result.GlobalContext);
                throw new DataPortalException(
                  "DataPortal.Create " + Resources.Failed, ex.InnerException, result.ReturnObject);
            }

            if (proxy.IsServerRemote)
                ApplicationContext.SetGlobalContext(result.GlobalContext);

            OnDataPortalInvokeComplete(new DataPortalEventArgs(dpContext));

            return result.ReturnObject;
        }

        
        /// <returns>An object populated with values from the database.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2223:MembersShouldDifferByMoreThanReturnType")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:DoNotPassLiteralsAsLocalizedParameters", MessageId = "Dothan.DataPortalException.#ctor(System.String,System.Exception,System.Object)")]
        public static T Fetch<T>(object criteria)
        {
            return (T)Fetch(criteria);
        }

      
        public static object Fetch(object criteria)
        {
            Server.DataPortalResult result;

            MethodInfo method = MethodCaller.GetMethod(MethodCaller.GetObjectType(criteria),"DataPortal_Fetch", criteria);

            DataPortalClient.IDataPortalProxy proxy;
            proxy = GetDataPortalProxy(RunLocal(method));

            Server.DataPortalContext dpContext =
              new Server.DataPortalContext(GetPrincipal(),
              proxy.IsServerRemote);

            OnDataPortalInvoke(new DataPortalEventArgs(dpContext));

            try
            {
                result = proxy.Fetch(criteria, dpContext);
            }
            catch (Server.DataPortalException ex)
            {
                result = ex.Result;
                if (proxy.IsServerRemote)
                    ApplicationContext.SetGlobalContext(result.GlobalContext);
                throw new DataPortalException("DataPortal.Fetch " +
                  Resources.Failed, ex.InnerException, result.ReturnObject);
            }

            if (proxy.IsServerRemote)
                ApplicationContext.SetGlobalContext(result.GlobalContext);

            OnDataPortalInvokeComplete(new DataPortalEventArgs(dpContext));

            return result.ReturnObject;
        }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:DoNotPassLiteralsAsLocalizedParameters",
        MessageId = "Dothan.DataPortalException.#ctor(System.String,System.Exception,System.Object)")]
        public static T Execute<T>(T obj) where T : CommandBase
        {
            return (T)Update(obj);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:DoNotPassLiteralsAsLocalizedParameters", MessageId = "Dothan.DataPortalException.#ctor(System.String,System.Exception,System.Object)")]
        public static CommandBase Execute(CommandBase obj)
        {
            return (CommandBase)Update(obj);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:DoNotPassLiteralsAsLocalizedParameters", MessageId = "Dothan.DataPortalException.#ctor(System.String,System.Exception,System.Object)")]
        public static T Update<T>(T obj)
        {
            return (T)Update((object)obj);
        }

  
        public static object Update(object obj)
        {
            Server.DataPortalResult result;

            MethodInfo method;
            string methodName;
            if (obj is CommandBase)
                methodName = "DataPortal_Execute";
            else if (obj is Core.BusinessBase)
            {
                Core.BusinessBase tmp = (Core.BusinessBase)obj;
                if (tmp.IsDeleted)
                    methodName = "DataPortal_DeleteSelf";
                else
                    if (tmp.IsNew)
                        methodName = "DataPortal_Insert";
                    else
                        methodName = "DataPortal_Update";
            }
            else
                methodName = "DataPortal_Update";

            method = MethodCaller.GetMethod(obj.GetType(), methodName);

            DataPortalClient.IDataPortalProxy proxy;
            proxy = GetDataPortalProxy(RunLocal(method));

            Server.DataPortalContext dpContext =
              new Server.DataPortalContext(GetPrincipal(), proxy.IsServerRemote);

            OnDataPortalInvoke(new DataPortalEventArgs(dpContext));

            try
            {
                result = proxy.Update(obj, dpContext);
            }
            catch (Server.DataPortalException ex)
            {
                result = ex.Result;
                if (proxy.IsServerRemote)
                    ApplicationContext.SetGlobalContext(result.GlobalContext);
                throw new DataPortalException("DataPortal.Update " +
                  Resources.Failed, ex.InnerException, result.ReturnObject);
            }

            if (proxy.IsServerRemote)
                ApplicationContext.SetGlobalContext(result.GlobalContext);

            OnDataPortalInvokeComplete(new DataPortalEventArgs(dpContext));

            return result.ReturnObject;
        }

   
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:DoNotPassLiteralsAsLocalizedParameters", MessageId = "Dothan.DataPortalException.#ctor(System.String,System.Exception,System.Object)")]
        public static void Delete(object criteria)
        {
            Server.DataPortalResult result;

            MethodInfo method = MethodCaller.GetMethod(
              MethodCaller.GetObjectType(criteria), "DataPortal_Delete", criteria);

            DataPortalClient.IDataPortalProxy proxy;
            proxy = GetDataPortalProxy(RunLocal(method));

            Server.DataPortalContext dpContext = new Server.DataPortalContext(GetPrincipal(), proxy.IsServerRemote);

            OnDataPortalInvoke(new DataPortalEventArgs(dpContext));

            try
            {
                result = proxy.Delete(criteria, dpContext);
            }
            catch (Server.DataPortalException ex)
            {
                result = ex.Result;
                if (proxy.IsServerRemote)
                    ApplicationContext.SetGlobalContext(result.GlobalContext);
                throw new DataPortalException("DataPortal.Delete " + Resources.Failed, ex.InnerException, result.ReturnObject);
            }

            if (proxy.IsServerRemote)
                ApplicationContext.SetGlobalContext(result.GlobalContext);

            OnDataPortalInvokeComplete(new DataPortalEventArgs(dpContext));
        }

        #endregion

        #region DataPortal Proxy

        private static DataPortalClient.IDataPortalProxy _localPortal;
        private static DataPortalClient.IDataPortalProxy _portal;

        private static DataPortalClient.IDataPortalProxy GetDataPortalProxy(bool forceLocal)
        {
            if (forceLocal)
            {
                if (_localPortal == null)
                    _localPortal = new DataPortalClient.LocalProxy();
                return _localPortal;
            }
            else
            {
                if (_portal == null)
                {
                    string proxyTypeName = ApplicationContext.DataPortalProxy;
                    if (proxyTypeName == "Local")
                        _portal = new DataPortalClient.LocalProxy();
                    else
                    {
                        string typeName =
                          proxyTypeName.Substring(0, proxyTypeName.IndexOf(",")).Trim();
                        string assemblyName =
                          proxyTypeName.Substring(proxyTypeName.IndexOf(",") + 1).Trim();
                        _portal = (DataPortalClient.IDataPortalProxy)
                          Activator.CreateInstance(assemblyName, typeName).Unwrap();
                    }
                }
                return _portal;
            }
        }

        #endregion

        #region Security

        private static System.Security.Principal.IPrincipal GetPrincipal()
        {
            if (ApplicationContext.AuthenticationType == "Windows")
            {
                // Windows integrated security
                return null;
            }
            else
            {
                // we assume using the Dothan framework security
                return ApplicationContext.User;
            }
        }

        #endregion

        #region Helper methods

        private static bool RunLocal(MethodInfo method)
        {
            return Attribute.IsDefined(method, typeof(RunLocalAttribute));
        }

        #endregion
    }
}
