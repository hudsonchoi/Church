using System;
using System.Data;
using System.Data.SqlClient;
using Dothan;
using Dothan.Data;

namespace Dothan.Library.bizCourse
{
    [Serializable()]
    public class Courses : BusinessListBase<Courses,Course>
    {

        public bool Contains(string name)
        {
            bool result = false;
            foreach (Course item in this)
                if (item.Name == name)
                {
                    result = true;
                    break;
                }
            return result;
        }
        protected override object AddNewCore()
        {
           Course item = Course.New();
            Add(item);
            return item;
        }
        public static bool CanGetObject()
        {
            bool result = false;
            if (Dothan.ApplicationContext.User.IsInRole("Course_R")
                || Dothan.ApplicationContext.User.IsInRole("Course_RW")
                || Dothan.ApplicationContext.User.IsInRole("SysAdmin"))
                result = true;
            return result;
        }

        public static bool CanDeleteObject()
        {
            bool result = false;
            if (Dothan.ApplicationContext.User.IsInRole("Course_RW")
                || Dothan.ApplicationContext.User.IsInRole("SysAdmin"))
                result = true;
            return result;
        }

        public static bool CanEditObject()
        {
            bool result = false;
            if (Dothan.ApplicationContext.User.IsInRole("Course_RW")
                || Dothan.ApplicationContext.User.IsInRole("SysAdmin"))
                result = true;
            return result;
        }



        [Serializable()]
        public class Criteria
        {
        }

        private Courses() { this.AllowNew = true; }

        public static Courses Get()
        {
            return DataPortal.Fetch <Courses>(new Criteria());
        }

        public void Remove(int id)
        {
            foreach (Course item in this)
            {
                if (item.Code == id)
                {
                    Remove(item);
                    break;
                }
            }
        }
        public override Courses Save()
        {
            if (!CanEditObject())
                throw new System.Security.SecurityException(Dothan.Library.Properties.Resources.Users_not_authorized.ToString());
            Courses result;
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
                    cm.CommandText = "[app_course].[course_get]";
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        while (dr.Read())
                            this.Add(Course.Get(dr));
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
                SqlCommand com = cn.CreateCommand();
                SqlTransaction trans = cn.BeginTransaction() ;
                com.Transaction = trans ;
                foreach (Course item in DeletedList)
                {
                    item.DeleteSelf(cn);
                }
                DeletedList.Clear();
                try
                {

                    foreach (Course item in this)
                    {
                        if (item.IsNew)
                            item.Insert(com);
                        else
                            item.Update(com);
                    }
                    trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                }
            }
            this.RaiseListChangedEvents = true;
        }
    }
}
