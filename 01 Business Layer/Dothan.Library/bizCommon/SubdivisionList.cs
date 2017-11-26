using System;
using System.Data;
using System.Data.SqlClient;
using Dothan;
using Dothan.Data;

namespace Dothan.Library.bizCommon
{
    [Serializable()]
    public class SubdivisionList : NameValueListBase<int,string>
    {
        public static SubdivisionList Get(bool set)
        {
           
             return DataPortal.Fetch<SubdivisionList>(new Criteria(set));
        }

      
        private SubdivisionList() {}
                
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
                    cm.CommandText = "[app_common].[subdivision_list]";
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        IsReadOnly = false;
                        while (dr.Read())
                        {
                            int code = dr.GetInt32("id");
                            if (code == 0)
                            {
                                this.Add(new NameValuePair(code, criteria.set));
                            }
                            else
                                this.Add(new NameValuePair(code, dr.GetString("Name")));
                        }    
                        IsReadOnly = true;
                    }
                }
            }

            this.RaiseListChangedEvents = true;
        }
    }
}
