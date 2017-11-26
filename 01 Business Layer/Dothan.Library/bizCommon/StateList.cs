using System;
using System.Data;
using System.Data.SqlClient;
using Dothan;
using Dothan.Data;

namespace Dothan.Library.bizCommon
{
    [Serializable()]
    public class StateList : NameValueListBase<string, string>
    {
        public static StateList Get(bool set)
        {
            return DataPortal.Fetch<StateList>(new filterCriteria(set));
        }
        private StateList()
        {

        }

        [Serializable()]
        private class filterCriteria
        {
            private bool _set;
            public bool set { get { return _set; } }

            public filterCriteria(bool set)
            {
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
                    cm.CommandText = "[app_common].[state_list]";
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        IsReadOnly = false;
                        if(criteria.set)
                            this.Add(new NameValuePair("", "ALL"));
                        while (dr.Read())
                            this.Add(new NameValuePair(dr.GetString("code"), dr.GetString("name")));

                        IsReadOnly = true;
                    }
                }
            }

            this.RaiseListChangedEvents = true;
        }
    }
}
