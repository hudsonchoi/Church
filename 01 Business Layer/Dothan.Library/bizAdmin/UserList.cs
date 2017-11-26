using System;
using System.Data;
using System.Data.SqlClient;
using Dothan;
using Dothan.Data;

namespace Dothan.Library.bizAdmin
{
    [Serializable()]
    public class UserList :ReadOnlyListBase<UserList,UserInfo>
    {

        public static UserList Get()
        {
            return DataPortal.Fetch<UserList>(new Criteria());
        }

        private UserList() { }

        [Serializable()]
        private class Criteria
        { /* no criteria - retrieve all resources */ }


        private void DataPortal_Fetch(Criteria criteria)
        {
            using (SqlConnection cn = new SqlConnection(Database.ConnectionString))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "[app_admin].[user_list]";
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        IsReadOnly = false;
                        while (dr.Read())
                        {
                            UserInfo info = new UserInfo(dr);
                            this.Add(info);
                        }
                        IsReadOnly = true;
                    }
                }
            }
        }

    }
}
