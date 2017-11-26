using System;
using System.Data;
using System.Data.SqlClient;
using Dothan;
using Dothan.Data;

namespace Dothan.Library
{
    [Serializable()]
    public class VisitTypeList : NameValueListBase<int, string>
    {
        private static VisitTypeList _list;
        public static VisitTypeList GetList(string div, bool set)
        {
            _list = DataPortal.Fetch<VisitTypeList>(new filterCriteria(div, set));
            return _list;
        }
        public static void InvalidateCache()
        {
            _list = null;
        }
        public static string GetName(int key, string div)
        {

            VisitTypeList list = GetList(div, false);
            return list.Value(key);
        }
        private VisitTypeList()
        {

        }

        [Serializable()]
        private class filterCriteria
        {
            private string _div;
            private bool _set;

            public string div
            {
                get
                {
                    return _div;
                }
            }

            public bool set { get { return _set; } }
            public filterCriteria(string div, bool set)
            {
                _div = div;
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
                    cm.CommandText = "GetVisitTypeList";
                    cm.Parameters.AddWithValue("@div", criteria.div);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        IsReadOnly = false;
                        if (criteria.set)
                            this.Add(new NameValuePair(0, "All"));
                        else
                            this.Add(new NameValuePair(0, ""));
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
