using System;
using System.Data;
using System.Data.SqlClient;
using Dothan;
using Dothan.Data;

namespace Dothan.Library.bizAdmin
{
    [Serializable()]
    public class Baptisms : BusinessListBase<Baptisms,Baptism>
    {
        protected override object AddNewCore()
        {
            Baptism item = Baptism.New();
            Add(item);
            return item;
        }

        #region Authorization Rules

        public static bool CanAddObject()
        {
            return Dothan.ApplicationContext.User.IsInRole("SysAdmin");
        }

        public static bool CanGetObject()
        {
            return Dothan.ApplicationContext.User.IsInRole("SysAdmin");
        }

        public static bool CanDeleteObject()
        {
            return Dothan.ApplicationContext.User.IsInRole("SysAdmin");
        }

        public static bool CanEditObject()
        {
            return Dothan.ApplicationContext.User.IsInRole("SysAdmin");
        }


        #endregion

        public static Baptisms GetList()
        {
            return DataPortal.Fetch<Baptisms>(new Criteria());
        }

        private Baptisms()
        {
            this.AllowNew = true;
        }


        #region Criteria

        [Serializable()]
        public class Criteria
        {
        }
        #endregion

        public override Baptisms Save()
        {
            if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to save roles");
            Baptisms result;
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
                    cm.CommandText = "app_admin.type_baptism_get";
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        while (dr.Read())
                        {
                            Baptism item = Baptism.Get(dr);
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
                
                foreach (Baptism item in DeletedList)
                {
                    item.DeleteSelf(cn);
                }
                DeletedList.Clear();
               
                foreach (Baptism item in this)
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
