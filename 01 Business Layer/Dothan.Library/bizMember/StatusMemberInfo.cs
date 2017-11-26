using System;
using System.Data;
using System.Data.SqlClient;
using Dothan;
using Dothan.Data;
using Dothan.Library.Properties;

namespace Dothan.Library.bizMember
{
    [Serializable()]
    public class StatusMemberInfo : ReadOnlyBase<StatusMemberInfo>
    {
        private int _id;
        private int _memberid;
        private string  _membername;
        private string _reasons;
        private string _status;
        private SmartDate _regdate;
        private string _home;
        private string _address;
        private SmartDate _entrydate;
        private string _fellowship;
        private string _subdivision;
        private string _cellname;

        public int ID { get { return _id; } }
        public string Status { get { return _status; } }
        public int MemberId { get { return _memberid; } }
        public string FullName { get { return _membername; } }
        public string Reasons { get { return _reasons; } }
        public string CellName { get { return _cellname; } }
        public DateTime RegDate { get { return _regdate.Date; } }
        public string Home { get { return _home; } }
        public string Address { get { return _address; } }
        public string Fellowship { get { return _fellowship; } }
        public DateTime EntryDate { get { return _entrydate.Date; } }
        public string SubDivision { get { return _subdivision; } }


        protected override object GetIdValue()
        {
            return _id;
        }

        public override string ToString()
        {
            return _id.ToString();
        }

        private StatusMemberInfo() { }
        
        internal StatusMemberInfo(SafeDataReader dr)
        {
            _id = dr.GetInt32("id");
            _status = dr.GetString("name");
            _memberid = dr.GetInt32("memberid");
            _membername = string.Format("{0}{1}", dr.GetString("last_name"), dr.GetString("first_name"));
            _reasons = dr.GetString("memo");
            _regdate = dr.GetSmartDate("regdate", _regdate.EmptyIsMin);
            _cellname = dr.GetString("cellname");
            _home = dr.GetString("home");
            _subdivision = dr.GetString("subdivisionname");
            _entrydate = dr.GetSmartDate("entrydate", _entrydate.EmptyIsMin);
            _fellowship = dr.GetString("fellowshipname");
            _address = string.Format("{0} {1} {2} {3}", dr.GetString("address"), dr.GetString("city"), dr.GetString("statecode"), dr.GetString("zipcode"));
        }
    }
}
