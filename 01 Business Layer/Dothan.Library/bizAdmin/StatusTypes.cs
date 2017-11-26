using System;
using System.Data;
using System.Data.SqlClient;
using Dothan;
using Dothan.Data;


namespace Dothan.Library.bizAdmin
{
    [Serializable()]
    public class StatusTypes : BusinessListBase<StatusTypes,StatusType>
    {

        protected override object AddNewCore()
        {
            StatusType item = StatusType.NewLabel();
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
            return true;
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

        public static StatusTypes Get()
        {
            return DataPortal.Fetch<StatusTypes>(new Criteria());
        }

        private StatusTypes()
        {
            this.AllowNew = true;
        }
        
        [Serializable()]
        public class Criteria {
           
        }

        public override StatusTypes Save()
        {
            if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to save roles");
            StatusTypes result;
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
                    cm.CommandText = "[app_admin].[type_status_get]";
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        while (dr.Read())
                        {
                            StatusType item = StatusType.GetLabel(dr);
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
                
                foreach (StatusType item in DeletedList)
                {
                    item.DeleteSelf(cn);
                }
                DeletedList.Clear();
              
                foreach (StatusType item in this)
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
