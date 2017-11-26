using System;
using System.Data;
using System.Data.SqlClient;
using Dothan;
using Dothan.Data;

namespace Dothan.Library.bizDonate
{
    [Serializable()]
    public class MemberDonates : ReadOnlyListBase<MemberDonates, MemberDonate>
    {
        public static MemberDonates Get(int donateid, string startdate, string enddate)
        {
            return DataPortal.Fetch<MemberDonates>(new Criteria(donateid, startdate, enddate));
        }

        [Serializable()]
        private class Criteria
        {
            private SmartDate _startdate = new SmartDate(false);
            private SmartDate _enddate = new SmartDate(false);
            private int _donateid = 0;

            public SmartDate StartDate { get { return _startdate; } }
            public SmartDate EndDate { get { return _enddate; } }
            public int Donateid { get { return _donateid; } }

            public Criteria(int donateid, string startdate, string enddate)
            {
                _startdate.Text = startdate;
                _enddate.Text = enddate;
                _donateid = donateid;
            }
        }


        private void DataPortal_Fetch(Criteria critera)
        {
            using (SqlConnection cn = new SqlConnection(Database.ConnectionString))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "memberdonate_get";
                    cm.Parameters.AddWithValue("@startdate", critera.StartDate.DBValue);
                    cm.Parameters.AddWithValue("@enddate", critera.EndDate.DBValue);
                    cm.Parameters.AddWithValue("@donateid", critera.Donateid);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        IsReadOnly = false;
                        while (dr.Read())
                        {
                            this.Add(new MemberDonate(dr));
                        }
                        IsReadOnly = true;
                    }
                }
            }
        }
    }
}
