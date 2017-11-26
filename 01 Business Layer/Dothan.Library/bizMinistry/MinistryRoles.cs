using System;
using System.Data;
using System.Data.SqlClient;
using Dothan;
using Dothan.Data;

namespace Dothan.Library.bizMinistry
{
    [Serializable()]
    public class MinistryRoles : BusinessListBase<MinistryRoles , MinistryRole>
    {

        #region Authorization Rules

        public static bool CanAddObject()
        {
            bool result = false;
            if (Dothan.ApplicationContext.User.IsInRole("Ministry_RW")
                || Dothan.ApplicationContext.User.IsInRole("SysAdmin")
                )
                result = true;

            return result;
        }

        public static bool CanGetObject()
        {
            bool result = false;
            if (Dothan.ApplicationContext.User.IsInRole("Ministry_R")
                || Dothan.ApplicationContext.User.IsInRole("SysAdmin")
                )
                result = true;

            return result;
        }

        public static bool CanDeleteObject()
        {
            bool result = false;
            if (Dothan.ApplicationContext.User.IsInRole("SysAdmin"))
                result = true;
            return result;
        }

        public static bool CanEditObject()
        {
            bool result = false;
            if (Dothan.ApplicationContext.User.IsInRole("Ministry_RW")
             || Dothan.ApplicationContext.User.IsInRole("SysAdmin")
             )
                result = true;
            return result;
        }

        #endregion

        #region Criteria
        [Serializable()]
        public class Criteria
        {

        }

        #endregion

        public void Remove(int code)
        {
            foreach (MinistryRole item in this)
            {
                if (item.Code == code)
                {
                    Remove(item);
                    break;
                }
            }
        }

        public void SetDefault(int code)
        {
            foreach (MinistryRole item in this)
            {
                if (item.Code != code)
                    item.Default = false;
            }
        }

        private MinistryRoles() 
        { 
            this.AllowNew = true; 
        }
        public static MinistryRoles GetList()
        {
            return DataPortal.Fetch<MinistryRoles>(new Criteria());
        }

        protected override object AddNewCore()
        {
            MinistryRole item = MinistryRole.New();
            Add(item);
            return item;
        }

        public override MinistryRoles Save()
        {
            if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to save roles");
            MinistryRoles result;
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
                    cm.CommandText = "[app_ministry].[ministry_role_get]";
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        while (dr.Read())
                            this.Add(MinistryRole.Get(dr));
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
                
                foreach (MinistryRole item in DeletedList)
                {
                    item.DeleteSelf(cn);
                }
                DeletedList.Clear();

                foreach (MinistryRole item in this)
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
