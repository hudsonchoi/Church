using System;
using System.Data;
using System.Data.SqlClient;
using Dothan;
using Dothan.Data;

namespace Dothan.Library.bizCommon
{
    [Serializable()]
    public class CityList : NameValueListBase<string, string>
    {
      
        public static CityList Get(string state,bool set)
        {
            
               return  DataPortal.Fetch<CityList>(new filterCriteria(state,set));
            
        }
     
        private CityList()
        {

        }

        [Serializable()]
        private class filterCriteria
        {
            private string _state;
            private bool _set;

            public bool set { get { return _set; } }

            public string state
            {
                get
                {
                    return _state;
                }
            }



            public filterCriteria(string state,bool set)
            {
                _state = state;
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
                    cm.CommandText = "[app_common].[city_list]";
                    cm.Parameters.AddWithValue("@state", criteria.state);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        IsReadOnly = false;

                        if(criteria.set)
                            this.Add(new NameValuePair(string.Empty, "ALL"));
                        while (dr.Read())
                            this.Add(new NameValuePair(dr.GetString("city"), dr.GetString("city")));

                        IsReadOnly = true;
                    }
                }
            }

            this.RaiseListChangedEvents = true;
        }
    }
}
