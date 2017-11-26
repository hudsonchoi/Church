using System;
using System.Data;
using System.Data.SqlClient;
using Dothan;
using Dothan.Data;

namespace Dothan.Library.bizCommon
{

    [Serializable()]
    public class TypeList : NameValueListBase<int, string>
    {
        public static TypeList Get(string typename, bool set)
        {
            return DataPortal.Fetch<TypeList>(new filterCriteria(typename, set));
        }
        private TypeList() { }

        [Serializable()]
        private class filterCriteria
        {
            private string _typename;
            private bool _set;

            public string Typename { get { return _typename; } }
            public bool set { get { return _set; } }

            public filterCriteria(string typename, bool set)
            {
                _typename = typename;
                _set = set;

            }
        }

        private void DataPortal_Fetch(filterCriteria criteria)
        {
            this.RaiseListChangedEvents = false;
            IsReadOnly = false;
            using (SqlConnection cn = new SqlConnection(Database.ConnectionString))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = string.Format("[app_common].[type_{0}_list]", criteria.Typename);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        IsReadOnly = false;

                        if(criteria.set)
                            this.Add(new NameValuePair(0, "All"));
                        while (dr.Read())
                            this.Add(new NameValuePair(dr.GetInt32("id"), dr.GetString("name")));

                        IsReadOnly = true;
                    }
                }
            }

            this.RaiseListChangedEvents = true;
        }
    }
}
