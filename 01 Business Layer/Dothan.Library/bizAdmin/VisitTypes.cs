using System;
using System.Data;
using System.Data.SqlClient;
using Dothan;
using Dothan.Data;

namespace Dothan.Library.bizAdmin
{
    [Serializable()]
    public class VisitTypes : BusinessListBase<VisitTypes, VisitType>
    {
        protected override object AddNewCore()
        {
            VisitType item = VisitType.New();
            Add(item);
            return item;
        }

        #region Authorization Rules

        public static bool CanAddObject()
        {
            bool result = false;
            if (Dothan.ApplicationContext.User.IsInRole("Pastor"))
                result = true;
            if (Dothan.ApplicationContext.User.IsInRole("SysAdmin"))
                result = true;
            return result;
        }

        public static bool CanGetObject()
        {
            bool result = false;
            if (Dothan.ApplicationContext.User.IsInRole("Pastor"))
                result = true;
            if (Dothan.ApplicationContext.User.IsInRole("SysAdmin"))
                result = true;
            return result;
        }

        public static bool CanDeleteObject()
        {
            bool result = false;
            if (Dothan.ApplicationContext.User.IsInRole("Pastor"))
                result = true;
            if (Dothan.ApplicationContext.User.IsInRole("SysAdmin"))
                result = true;
            return result;
        }

        public static bool CanEditObject()
        {
            bool result = false;
            if (Dothan.ApplicationContext.User.IsInRole("Pastor"))
                result = true;
            if (Dothan.ApplicationContext.User.IsInRole("SysAdmin"))
                result = true;
            return result;
        }

        #endregion

        public static VisitTypes GetList()
        {
            return DataPortal.Fetch<VisitTypes>(new Criteria());
        }

        private VisitTypes()
        {
            this.AllowNew = true;
        }


        #region Criteria

        [Serializable()]
        public class Criteria
        {        }
        #endregion

        public override VisitTypes Save()
        {
            if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to save roles");
            VisitTypes result;
            result = base.Save();
            return result;
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
                    cm.CommandText = "[app_admin].[type_visit_get]";
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        while (dr.Read())
                        {
                            VisitType item = VisitType.Get(dr);
                            this.Add(item);
                        }
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

                foreach (VisitType item in DeletedList)
                {
                    item.DeleteSelf(cn);
                }
                DeletedList.Clear();

                foreach (VisitType item in this)
                {
                    if (item.IsNew)
                        item.Insert(cn);
                    else
                        item.Update(cn);
                }
            }
            this.RaiseListChangedEvents = true;
        }
    }
}
