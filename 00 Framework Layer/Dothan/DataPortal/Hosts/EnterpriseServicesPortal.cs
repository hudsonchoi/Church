using System;
using System.EnterpriseServices;
using System.Runtime.InteropServices;
using System.Reflection;

namespace Dothan.Server.Hosts
{
    [EventTrackingEnabled(true)]
    [ComVisible(true)]
    public abstract class EnterpriseServicesPortal : ServicedComponent, Server.IDataPortalServer
    {

        static EnterpriseServicesPortal()
        {
            SerializationWorkaround();
        }

    
        public virtual DataPortalResult Create(Type objectType, object criteria, DataPortalContext context)
        {
            Server.DataPortal portal = new Server.DataPortal();
            return portal.Create(objectType, criteria, context);
        }

        public virtual DataPortalResult Fetch(object criteria, DataPortalContext context)
        {
            Server.DataPortal portal = new Server.DataPortal();
            return portal.Fetch(criteria, context);
        }

      
        public virtual DataPortalResult Update(object obj, DataPortalContext context)
        {
            Server.DataPortal portal = new Server.DataPortal();
            return portal.Update(obj, context);
        }

   
        public virtual DataPortalResult Delete(object criteria, DataPortalContext context)
        {
            Server.DataPortal portal = new Server.DataPortal();
            return portal.Delete(criteria, context);
        }

        #region Serialization bug workaround

        private static void SerializationWorkaround()
        {
            AppDomain currentDomain = AppDomain.CurrentDomain;

            currentDomain.AssemblyResolve +=
              new ResolveEventHandler(ResolveEventHandler);
        }

        private static Assembly ResolveEventHandler(object sender, ResolveEventArgs args)
        {
            
            Assembly[] list = AppDomain.CurrentDomain.GetAssemblies();

            foreach (Assembly asm in list)
                if (asm.FullName == args.Name)
                    return asm;
            return Assembly.Load(args.Name);
        }

        #endregion
    }
}
