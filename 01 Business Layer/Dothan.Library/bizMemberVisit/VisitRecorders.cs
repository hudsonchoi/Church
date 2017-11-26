using System;
using System.Data;
using System.Data.SqlClient;
using Dothan;
using Dothan.Data;

namespace Dothan.Library.bizMember
{
    [Serializable()]
    public class VisitRecorders : NameValueListBase<string, string>
    {
        public static VisitRecorders Get()
        {
            return DataPortal.Fetch<VisitRecorders>(new Criteria());
        }
  
        private VisitRecorders()
        {

        }

        [Serializable()]
        private class Criteria
        {
            
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
                    cm.CommandText = "[app_member].[visit_recoder_get]";

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        IsReadOnly = false;
                        this.Add(new NameValuePair("", "ALL"));
                        while (dr.Read())
                            this.Add(new NameValuePair(dr.GetString("create_by"), dr.GetString("create_by")));
                        IsReadOnly = true;
                    }
                }
            }

            this.RaiseListChangedEvents = true;
        }



    }
}