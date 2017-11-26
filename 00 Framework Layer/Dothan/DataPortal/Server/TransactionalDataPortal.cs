using System;
using System.Transactions;

namespace Dothan.Server
{
    public class TransactionalDataPortal : IDataPortalServer
    {
        public DataPortalResult Create(
       System.Type objectType, object criteria, DataPortalContext context)
        {
            DataPortalResult result;
            using (TransactionScope tr = new TransactionScope())
            {
                SimpleDataPortal portal = new SimpleDataPortal();
                result = portal.Create(objectType, criteria, context);
                tr.Complete();
            }
            return result;
        }

        public DataPortalResult Fetch(object criteria, DataPortalContext context)
        {
            DataPortalResult result;
            using (TransactionScope tr = new TransactionScope())
            {
                SimpleDataPortal portal = new SimpleDataPortal();
                result = portal.Fetch(criteria, context);
                tr.Complete();
            }
            return result;
        }


        public DataPortalResult Update(object obj, DataPortalContext context)
        {
            DataPortalResult result;
            using (TransactionScope tr = new TransactionScope())
            {
                SimpleDataPortal portal = new SimpleDataPortal();
                result = portal.Update(obj, context);
                tr.Complete();
            }
            return result;
        }
        public DataPortalResult Delete(object criteria, DataPortalContext context)
        {
            DataPortalResult result;
            using (TransactionScope tr = new TransactionScope())
            {
                SimpleDataPortal portal = new SimpleDataPortal();
                result = portal.Delete(criteria, context);
                tr.Complete();
            }
            return result;
        }
    }
}
