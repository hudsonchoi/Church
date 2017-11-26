using System;
using System.Data;
using System.Data.SqlClient;
using Dothan;
using Dothan.Data;

namespace Dothan.Library.bizCell
{
    [Serializable()]
    public class Cells : BusinessListBase<Cells, Cell>
    {
       
        #region Authorization Rules

        public static bool CanAddObject()
        {
            bool result = false;
            if (Dothan.ApplicationContext.User.IsInRole("Cell_RW"))
                result = true;
            if (Dothan.ApplicationContext.User.IsInRole("SysAdmin"))
                result = true;
            return result;
        }

        public static bool CanGetObject()
        {
            bool result = false;
            if (Dothan.ApplicationContext.User.IsInRole("Cell_R")||
                Dothan.ApplicationContext.User.IsInRole("Cell_RW") ||
                 Dothan.ApplicationContext.User.IsInRole("SysAdmin") )
                result = true;
            return result;
        }

        public static bool CanDeleteObject()
        {
            bool result = false;
            if (Dothan.ApplicationContext.User.IsInRole("Cell_RW"))
                result = true;
            if (Dothan.ApplicationContext.User.IsInRole("SysAdmin"))
                result = true;
            return result;
        }

        public static bool CanEditObject()
        {
            bool result = false;
            if (Dothan.ApplicationContext.User.IsInRole("Cell_RW"))
                result = true;
            if (Dothan.ApplicationContext.User.IsInRole("SysAdmin"))
                result = true;
            return result;
        }

        #endregion

        #region Criteria
        [Serializable()]
        public class Criteria
        {        }

        #endregion

        private Cells() { this.AllowNew = true; }

        public static Cells Get()
        {
            return DataPortal.Fetch<Cells>(new Criteria());
        }

        protected override object AddNewCore()
        {
            Cell item = Cell.New();
            Add(item);
            return item;
        }

     

        public void Remove(int id)
        {
            
            foreach (Cell item in this)
            {
                if (item.Code == id)
                {
                    Remove(item);
                    break;
                }
            }
        }
        public override Cells Save()
        {
            if (!CanEditObject())
                throw new System.Security.SecurityException(Dothan.Library.Properties.Resources.Users_not_authorized.ToString());
            Cells result;
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
                    cm.CommandText = "app_cell.cell_get";
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        while (dr.Read())
                            this.Add(Cell.Get(dr));
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
                foreach (Cell item in DeletedList)
                {
                    item.DeleteSelf(cn);
                }
                DeletedList.Clear();

                foreach (Cell item in this)
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
