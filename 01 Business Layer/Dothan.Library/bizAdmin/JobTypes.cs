using System;
using System.Data;
using System.Data.SqlClient;
using Dothan;
using Dothan.Data;

namespace Dothan.Library.bizAdmin
{
    [Serializable()]
    public class JobTypes : BusinessListBase<JobTypes, JobType>
    {

        protected override object AddNewCore()
        {
            JobType item = JobType.New();
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
            bool result = false;
            if(Dothan.ApplicationContext.User.IsInRole("SysAdmin") 
                    || Dothan.ApplicationContext.User.IsInRole("Visit_CanGet"))
                result = true;

            return result;
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

        public static JobTypes GetList()
        {
            return DataPortal.Fetch<JobTypes>(new Criteria());
        }

        private JobTypes()
        {
            this.AllowNew = true;
        }


        #region Criteria

        [Serializable()]
        public class Criteria
        {
        }
        #endregion

        public override JobTypes Save()
        {
            if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to save roles");
            JobTypes result;
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
                    cm.CommandText = "[app_admin].[type_job_get]";
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        while (dr.Read())
                        {
                            JobType item = JobType.Get(dr);
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
          
                foreach (JobType item in DeletedList)
                {
                    item.DeleteSelf(cn);
                }
                DeletedList.Clear();
               
                foreach (JobType item in this)
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