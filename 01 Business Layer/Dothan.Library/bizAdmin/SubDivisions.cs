using System;
using System.Data;
using System.Data.SqlClient;
using Dothan;
using Dothan.Data;

namespace Dothan.Library.bizAdmin
{
    [Serializable()]
    public class SubDivisions : BusinessListBase<SubDivisions,SubDivision>
    {

        protected override object AddNewCore()
        {
            SubDivision item = SubDivision.New();
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

        public static SubDivisions Get()
        {
            return DataPortal.Fetch<SubDivisions>(new Criteria());
        }

        private SubDivisions()
        {
            this.AllowNew = true;
        }

        [Serializable()]
        public class Criteria
        {          
        }

        public override SubDivisions Save()
        {
            if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to save roles");
            SubDivisions result;
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
                    cm.CommandText = "[app_admin].[sub_division_get]";
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        while (dr.Read())
                            this.Add(SubDivision.Get(dr));
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

                foreach (SubDivision item in DeletedList)
                {
                    item.DeleteSelf(cn);
                }
                DeletedList.Clear();
               
                foreach (SubDivision item in this)
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
