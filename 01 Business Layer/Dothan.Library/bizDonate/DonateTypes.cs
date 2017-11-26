using System;
using System.Data;
using System.Data.SqlClient;
using Dothan;
using Dothan.Data;

namespace Dothan.Library.bizDonate
{
    [Serializable()]
    public class DonateTypes : BusinessListBase<DonateTypes, DonateType>
    {
        public void Remove(int id)
        {
            foreach (DonateType item in this)
                if (item.Code.Equals(id))
                {
                    Remove(item);
                    break;
                }
        }

        #region Authorization Rules

        public static bool CanAddObject()
        {
            return Dothan.ApplicationContext.User.IsInRole("DonateAdmin");
        }

        public static bool CanGetObject()
        {
            return true;
        }

        public static bool CanDeleteObject()
        {
            return Dothan.ApplicationContext.User.IsInRole("DonateAdmin");
        }

        public static bool CanEditObject()
        {
            return Dothan.ApplicationContext.User.IsInRole("DonateAdmin");
        }

        #endregion

        #region Criteria
        [Serializable()]
        public class Criteria {  }

        #endregion

        #region Factory Methods

        private DonateTypes() { this.AllowNew = true; }


        public static DonateTypes GetList()
        {
            return DataPortal.Fetch<DonateTypes>(new Criteria());
        }

        protected override object AddNewCore()
        {
            DonateType item = DonateType.New();
            Add(item);
            return item;
        }


        #endregion

        #region DataAccess

        public override DonateTypes Save()
        {
            if (!CanEditObject())
                throw new System.Security.SecurityException(Dothan.Library.Properties.Resources.Users_not_authorized.ToString());
            DonateTypes result;
            result = base.Save();
            DonateTypeList.InvalidateCache();
            return result;
        }


        protected override void DataPortal_OnDataPortalInvokeComplete(DataPortalEventArgs e)
        {
            if (ApplicationContext.ExecutionLocation == ApplicationContext.ExecutionLocations.Server)
            {
                DonateTypeList.InvalidateCache();
            }
        }
        private void DataPortal_Fetch(Criteria criteria)
        {
            RaiseListChangedEvents = false;
            using (SqlConnection cn = new SqlConnection(Database.ConnectionString))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "[app_donate].[donatetype_get]";
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        while (dr.Read())
                            this.Add(DonateType.Get(dr));
                }
            }
            RaiseListChangedEvents = true;
        }

        [Transactional(TransactionalTypes.TransactionScope)]
        protected override void DataPortal_Update()
        {
            this.RaiseListChangedEvents = false;
            using (SqlConnection cn = new SqlConnection(Database.ConnectionString))
            {
                cn.Open();
                foreach (DonateType item in DeletedList)
                {
                    item.DeleteSelf(cn);
                }
                DeletedList.Clear();

                foreach (DonateType item in this)
                {
                    if (item.IsNew)
                        item.Insert(cn);
                    else
                        item.Update(cn);
                }
            }
            this.RaiseListChangedEvents = true;
        }

        #endregion
    }
}