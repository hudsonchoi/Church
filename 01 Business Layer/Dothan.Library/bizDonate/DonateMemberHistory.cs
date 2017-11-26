using System;
using System.Data;
using System.Data.SqlClient;
using Dothan;
using Dothan.Data;

namespace Dothan.Library.bizDonate
{
    [Serializable()]
    public class DonateMemberHistory : ReadOnlyListBase<DonateMemberHistory, DonateInfo>
    {
        public static DonateMemberHistory GetList(string startdate, string endate, int donateid)
        {
            return DataPortal.Fetch<DonateMemberHistory>(new Criteria(startdate, endate, donateid));
        }

        [Serializable()]
        private class Criteria
        {
            private SmartDate _startdate;
            private SmartDate _enddate;
            private int _donateid;

            public SmartDate startdate { get { return _startdate; } }
            public SmartDate enddate { get { return _enddate; } }
            public int donateid { get { return _donateid; } }
            public Criteria(string start, string end, int donateid)
            {
                _startdate.Text = start;
                _enddate.Text = end;
                _donateid = donateid;
            }
        }
        private void DataPortal_Fetch(Criteria criteria)
        {

            using (SqlConnection cn = new SqlConnection(Database.ConnectionString))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "[app_donate].[recode_get]";
                    cm.Parameters.AddWithValue("@donateid", criteria.donateid);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        IsReadOnly = false;
                       
                        while (dr.Read())
                            this.Add(new DonateInfo(dr));
                        IsReadOnly = true;
                    }
                }
            }
        }

    }
}
