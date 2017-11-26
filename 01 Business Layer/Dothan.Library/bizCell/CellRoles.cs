using System;
using System.Data;
using System.Data.SqlClient;
using Dothan;
using Dothan.Data;

namespace Dothan.Library.bizCell
{
    [Serializable()]
    public class CellRoles : BusinessListBase<CellRoles, CellRole>
    {
        #region Authorization Rules

        public static bool CanAddObject()
        {
            bool result = false;
            if (Dothan.ApplicationContext.User.IsInRole("Cell_RW")
                || Dothan.ApplicationContext.User.IsInRole("SysAdmin")
                )
                result = true;

            return result;
        }

        public static bool CanGetObject()
        {
            return true;
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
            if (Dothan.ApplicationContext.User.IsInRole("Cell_RW")
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
            foreach (CellRole item in this)
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
            foreach (CellRole item in this)
            {
                if (item.Code != code)
                    item.Default = false;
            }
        }
        private CellRoles() { this.AllowNew = true; }

        public static CellRoles GetList()
        {
            return DataPortal.Fetch<CellRoles>(new Criteria());
        }

        protected override object AddNewCore()
        {
            CellRole item = CellRole.New();
            Add(item);
            return item;
        }

        public override CellRoles Save()
        {
            if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to save roles");
            CellRoles result;
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
                    cm.CommandText = "[app_cell].[cell_role_get]";

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        while (dr.Read())
                            this.Add(CellRole.Get(dr));
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

                foreach (CellRole item in DeletedList)
                {
                    item.DeleteSelf(cn);
                }
                DeletedList.Clear();

                foreach (CellRole item in this)
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
