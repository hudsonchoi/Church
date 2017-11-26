using System;
using System.Data;
using System.Data.SqlClient;
using Dothan;
using Dothan.Data;

namespace Dothan.Library.bizCourse
{
    [Serializable()]
    public class CourseList : ReadOnlyListBase<CourseList, CourseInfo>
    {
        public static CourseList GetList()
        {
            return DataPortal.Fetch<CourseList>(new Criteria());
           
        }
  
        
        [Serializable()]
        private class Criteria
        {
           
        }

        private CourseList() { }

        private void DataPortal_Fetch(Criteria criteria)
        {
            this.RaiseListChangedEvents = false;
            IsReadOnly = false;
            using (SqlConnection cn = new SqlConnection(Database.ConnectionString))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "[app_course].[course_list]";
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        IsReadOnly = false;
                        while (dr.Read())
                        {
                            this.Add(new CourseInfo(dr));
                            //this.Add(new NameValuePair(dr.GetInt32("code"), dr.GetString("name")));
                        }
                        IsReadOnly = true;
                    }
                }
            }
            this.RaiseListChangedEvents = true;
        }
    }
}
