using System;
using System.Data;
using System.Data.SqlClient;
using Dothan;
using Dothan.Data;


namespace Dothan.Library.bizDonate
{
    [Serializable()]
    public class MemberDonateList : ReadOnlyListBase<MemberDonateList, MemberDonateInfo>
    {
        public static MemberDonateList GetList(string name, string firstname, string lastname, int membertype, string startdate, string enddate, int fellowship, int memberid , int year)
        {
            return DataPortal.Fetch<MemberDonateList>(new Criteria(name, firstname, lastname, membertype, startdate, enddate, fellowship, memberid , year));
        }

        [Serializable()]
        private class Criteria
        {
            private string _name = string.Empty;
            private string _firstname = string.Empty;
            private string _lastname = string.Empty;
            private int _membertype ;
            private SmartDate _startdate = new SmartDate(false);
            private SmartDate _enddate = new SmartDate(false);
            private int _fellowship;
            private int _memberid;
            private int _year;

            public string Koname { get { return _name; } }
            public string Firstname { get { return _firstname; } }
            public string Lastname { get { return _lastname; } }
            public SmartDate Startdate { get { return _startdate; } }
            public SmartDate Enddate { get { return _enddate; } }
            public int Fellowship { get { return _fellowship; } }
            public int Memberid { get { return _memberid; } }
            public int Membertype { get { return _membertype; } }
            public int Year { get { return _year; } }

            public Criteria(string name, string firstname, string lastname, int membertype, string startdate, string enddate, int fellowship, int memberid , int year )
            {
                _name = name;
                _firstname = firstname;
                _lastname = lastname;
                _membertype = membertype;
                _startdate.Text = startdate;
                _enddate.Text = enddate;
                _fellowship = fellowship;
                _memberid = memberid;
                _year = year;
            }
        }
        private bool Contains(int donateid)
        {
            bool result = false;
            foreach (MemberDonateInfo item in this)
                if (item.ID == donateid)
                {
                    result = true;
                    break;
                }
            return result;
        }
        private MemberDonateInfo GetMemberDoate(int donateid)
        {
            MemberDonateInfo result = null;
            foreach (MemberDonateInfo item in this)
                if (item.ID == donateid)
                {
                    result = item;
                    break;
                }
            return result;

        }
        private void DataPortal_Fetch(Criteria critera)
        {
            using (SqlConnection cn = new SqlConnection(Database.ConnectionString))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "[app_donate].[memberdonate_list]";
                    cm.Parameters.AddWithValue("@name", critera.Koname);
                    cm.Parameters.AddWithValue("@enFirstName", critera.Firstname);
                    cm.Parameters.AddWithValue("@enLastName", critera.Lastname);
                    cm.Parameters.AddWithValue("@from", critera.Startdate.DBValue);
                    cm.Parameters.AddWithValue("@to", critera.Enddate.DBValue);
                    cm.Parameters.AddWithValue("@fellowship", critera.Fellowship);
                    cm.Parameters.AddWithValue("@memberid", critera.Memberid);
                    cm.Parameters.AddWithValue("@membertype", critera.Membertype);
                    cm.Parameters.AddWithValue("@year", critera.Year);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        IsReadOnly = false;
                        while (dr.Read())
                        {
                            MemberDonateInfo info;
                            if (this.Contains(dr.GetInt32("donate_id")))
                            {
                                info = this.GetMemberDoate(dr.GetInt32("donate_id"));
                                info.AddAmount(dr);
                            }
                            else
                            {
                                info = new MemberDonateInfo(dr);
                                this.Add(info);
                            }
                        }
                    }
                }
            }
        }
    }
}
