using System;
using System.EnterpriseServices;
using System.Runtime.InteropServices;

namespace Dothan.Server
{
    [Transaction(TransactionOption.Required)]
    [EventTrackingEnabled(true)]
    [ComVisible(true)]
    public class ServicedDataPortal : ServicedComponent, IDataPortalServer
    {
        [AutoComplete(true)]
        public DataPortalResult Create(
          Type objectType, object criteria, DataPortalContext context)
        {
            SimpleDataPortal portal = new SimpleDataPortal();
            return portal.Create(objectType, criteria, context);
        }

       
        [AutoComplete(true)]
        public DataPortalResult Fetch(object criteria, DataPortalContext context)
        {
            SimpleDataPortal portal = new SimpleDataPortal();
            return portal.Fetch(criteria, context);
        }

       
        [AutoComplete(true)]
        public DataPortalResult Update(object obj, DataPortalContext context)
        {
            SimpleDataPortal portal = new SimpleDataPortal();
            return portal.Update(obj, context);
        }

        [AutoComplete(true)]
        public DataPortalResult Delete(object criteria, DataPortalContext context)
        {
            SimpleDataPortal portal = new SimpleDataPortal();
            return portal.Delete(criteria, context);
        }
    }
}
