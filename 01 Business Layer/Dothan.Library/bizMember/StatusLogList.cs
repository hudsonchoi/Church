using System;
using System.Data;
using System.Data.SqlClient;
using Dothan;
using Dothan.Data;

namespace Dothan.Library.bizMember
{
    [Serializable()]
    public class StatusLogList : ReadOnlyListBase<StatusLogList, StatusLog>
    {

        public static StatusLogList Get(int memberid)
        {
            return DataPortal.Fetch<StatusLogList>(new Criteria(memberid));
        }
        private StatusLogList() { }


        [Serializable()]
        private class Criteria
        {
            private int _memberid;
            public int Memberid
            {
                get { return _memberid; }
            }
            public Criteria(int memberid)
            {
                _memberid = memberid;
            }
        }

        private void DataPortal_Fetch(Criteria criteria)
        {
            using (SqlConnection cn = new SqlConnection(Database.ConnectionString))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    IsReadOnly = false;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "[app_member].[statuslog_get]";
                    cm.Parameters.AddWithValue("@memberid", criteria.Memberid);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            this.Add(new StatusLog(dr));
                        }
                    }
                    IsReadOnly = true;
                }
            }
        }


    }
}
