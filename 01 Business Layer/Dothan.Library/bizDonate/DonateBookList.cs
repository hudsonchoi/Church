using System;
using System.Data;
using System.Data.SqlClient;
using Dothan;
using Dothan.Data;

namespace Dothan.Library.bizDonate
{
    [Serializable()]
    public class DonateBookList : ReadOnlyListBase<DonateBookList, DonateBookInfo>
    {
        public static DonateBookList GetList(string startdate, string endate, int donatetype,int userid)
        {
            return DataPortal.Fetch<DonateBookList>(new Criteria(startdate, endate, donatetype,userid));
        }

        [Serializable()]
        private class Criteria
        {
            private SmartDate _startdate;
            private SmartDate _enddate;
            private int _donatetype;
            private int _userid;

            public SmartDate startdate { get { return _startdate; } }
            public SmartDate enddate { get { return _enddate; } }
            public int donatetype { get { return _donatetype; } }
            public int userid { get { return _userid; } }

            public Criteria(string start, string end, int type, int userid)
            {
                _startdate.Text = start;
                _enddate.Text = end;
                _donatetype = type;
                _userid = userid;
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
                    cm.CommandText = "[app_donate].[donatebook_list]";
                        cm.Parameters.AddWithValue("@startdate", criteria.startdate.DBValue);

                        cm.Parameters.AddWithValue("@enddate", criteria.enddate.DBValue);
                        cm.Parameters.AddWithValue("@donatetype", criteria.donatetype);
                        cm.Parameters.AddWithValue("@userid", criteria.userid);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        IsReadOnly = false;
                        while (dr.Read())
                            this.Add(new DonateBookInfo(dr));
                       IsReadOnly = true;
                    }
                }
            }
        }

    }
}
