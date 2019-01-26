using System;
using System.Data;
using System.Data.SqlClient;
using Dothan;
using Dothan.Data;

namespace Dothan.Library.bizCell
{
    [Serializable()]
    public class CellServiceTimePlaceList : NameValueListBase<int, string>
    {
        public static CellServiceTimePlaceList Get(bool set)
        {

            return DataPortal.Fetch<CellServiceTimePlaceList>(new Criteria(set));

        }
        private CellServiceTimePlaceList()
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
            this.Add(new NameValuePair(0, "Selet One"));
            using (SqlConnection cn = new SqlConnection(Database.ConnectionString))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "[app_cell].[service_time_place_list]";
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        IsReadOnly = false;
                        while (dr.Read())
                        {
                            this.Add(new NameValuePair(dr.GetInt32("id"), dr.GetString("time") + " " + dr.GetString("place")));
                        }
                        IsReadOnly = true;
                    }
                }
            }

            this.RaiseListChangedEvents = true;
        }
    }
}

