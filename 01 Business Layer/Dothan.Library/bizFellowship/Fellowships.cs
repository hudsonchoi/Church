using System;
using System.Data;
using System.Data.SqlClient;
using Dothan;
using Dothan.Data;

namespace Dothan.Library.bizFellowship
{
    [Serializable()]
    public class Fellowships : BusinessListBase<Fellowships, Fellowship>
    {
        
        #region Authorization Rules


        public static bool CanGetObject()
        {
            bool result = false;
            if (Dothan.ApplicationContext.User.IsInRole("Fellowship_R")
                || Dothan.ApplicationContext.User.IsInRole("Fellowship_RW")
                || Dothan.ApplicationContext.User.IsInRole("SysAdmin"))
                result = true;
            return result; 
        }

        public static bool CanDeleteObject()
        {
            bool result = false;
            if (Dothan.ApplicationContext.User.IsInRole("Fellowship_RW")
                || Dothan.ApplicationContext.User.IsInRole("SysAdmin"))
                result = true;
            return result; 
        }

        public static bool CanEditObject()
        {
            bool result = false;
            if (Dothan.ApplicationContext.User.IsInRole("Fellowship_RW")
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

        #region Factory Methods

        private Fellowships() { this.AllowNew = true; }

        
        public static Fellowships Get()
        {
            return DataPortal.Fetch<Fellowships>(new Criteria());
        }

        protected override object AddNewCore()
        {
            Fellowship item = Fellowship.New();
            Add(item);
            return item;
        }

        public void Remove(int id)
        {
            foreach (Fellowship item in this)
            {
                if (item.code == id)
                {
                    
                    Remove(item);
                    break;
                }
            }
        }

        #endregion

        #region DataAccess

        public override Fellowships Save()
        {
            if (!CanEditObject())
                throw new System.Security.SecurityException(Dothan.Library.Properties.Resources.Users_not_authorized.ToString());
            Fellowships result;
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
                    cm.CommandText = "[app_fellowship].[fellowship_get]";
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        while (dr.Read())
                            this.Add(Fellowship.Get(dr));
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
                foreach (Fellowship item in DeletedList)
                {
                    item.DeleteSelf(cn);
                }
                DeletedList.Clear();
                
                foreach (Fellowship item in this)
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
