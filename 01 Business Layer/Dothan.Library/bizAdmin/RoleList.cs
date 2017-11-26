using System;
using System.Data;
using System.Data.SqlClient;
using Dothan;
using Dothan.Data;

namespace Dothan.Library.bizAdmin
{
    [Serializable()]
    public class RoleList : NameValueListBase<int , string>
    {
        #region Factory Method

        public static RoleList Get()
        {
            return DataPortal.Fetch<RoleList>(new Criteria(typeof(RoleList)));
        }
   

        private RoleList() { }

        #endregion


        #region  Data Access

        private void DataPortal_Fetch(Criteria criteria)
        {
            this.RaiseListChangedEvents = false;
            using (SqlConnection cn = new SqlConnection(Database.ConnectionString))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "[app_admin].[role_get]";

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        IsReadOnly = false;
                        while (dr.Read())
                        {
                            this.Add(new NameValuePair(dr.GetInt32("id"), dr.GetString("rolesName")));
                        }
                        IsReadOnly = true;
                    }
                }
            }
            this.RaiseListChangedEvents = true;
        }

        #endregion
    }
}
