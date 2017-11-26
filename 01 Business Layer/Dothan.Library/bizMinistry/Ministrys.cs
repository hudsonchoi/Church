using System;
using System.Data;
using System.Data.SqlClient;
using Dothan;
using Dothan.Data;

namespace Dothan.Library.bizMinistry 
{
    [Serializable()]
    public class Ministrys : BusinessListBase<Ministrys,Ministry>
    {


        #region Authorization Rules

        public static bool CanEditObject()
        {
            bool result = false;
            if (Dothan.ApplicationContext.User.IsInRole("Ministry_RW")
                || Dothan.ApplicationContext.User.IsInRole("SysAdmin"))
                result = true;
            return result;
        }

        public static bool CanGetObject()
        {
            bool result = false;
            if (Dothan.ApplicationContext.User.IsInRole("Ministry_R")
                || Dothan.ApplicationContext.User.IsInRole("Ministry_RW")
                || Dothan.ApplicationContext.User.IsInRole("SysAdmin"))
                result = true;
            return result;
        }

        public static bool CanDeleteObject()
        {
            bool result = false;
            if (Dothan.ApplicationContext.User.IsInRole("Ministry_RW")
                || Dothan.ApplicationContext.User.IsInRole("SysAdmin"))
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

        private Ministrys() { this.AllowNew = true; }

        public static Ministrys Get()
        {
            return DataPortal.Fetch<Ministrys>(new Criteria());
        }

        protected override object AddNewCore()
        {
            Ministry item = Ministry.New();
            Add(item);
            return item;
        }

        public void Remove(int id)
        {
            foreach (Ministry item in this)
            {
                if (item.Code == id)
                {
                    Remove(item);
                    break;
                }
            }

        }

      
        public override Ministrys Save()
        {
            if (!CanEditObject())
                throw new System.Security.SecurityException(Dothan.Library.Properties.Resources.Users_not_authorized.ToString());
            Ministrys result;
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
                    cm.CommandText = "[app_ministry].[ministry_get]";
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        while (dr.Read())
                            this.Add(Ministry.Get(dr));
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
                foreach (Ministry item in DeletedList)
                {
                    item.DeleteSelf(cn);
                }
                DeletedList.Clear();

                foreach (Ministry item in this)
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
