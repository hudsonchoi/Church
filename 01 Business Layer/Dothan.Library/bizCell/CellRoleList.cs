using System;
using System.Data;
using System.Data.SqlClient;
using Dothan;
using Dothan.Data;

namespace Dothan.Library.bizCell
{
    [Serializable()]
    public class CellRoleList : NameValueListBase<int, string>
    {

        public static CellRoleList Get(bool set)
        {
            return DataPortal.Fetch<CellRoleList>(new Criteria(set));
        }
        private CellRoleList()
        {

        }

        [Serializable()]
        private class Criteria
        {
            private bool _set;

            public string set { get { return _set ? "All" : ""; } }
            public Criteria(bool set)
            {
                _set = set;
            }
        }

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
                    cm.CommandText = "[app_cell].[cell_role_list]";

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        IsReadOnly = false;
                        while (dr.Read())
                        {
                            int code = dr.GetInt32("code");
                            if (code == 0)
                            {
                                this.Add(new NameValuePair(code, criteria.set));
                            }
                            else
                                this.Add(new NameValuePair(code, dr.GetString("name")));
                        }
                        IsReadOnly = true;
                    }
                }
            }
            this.RaiseListChangedEvents = true;
        }
    }
}