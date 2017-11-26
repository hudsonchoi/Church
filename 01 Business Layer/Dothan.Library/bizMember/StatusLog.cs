using System;
using System.Data;
using System.Data.SqlClient;
using Dothan;
using Dothan.Data;


namespace Dothan.Library.bizMember
{
    [Serializable()]
    public class StatusLog : ReadOnlyBase<StatusLog>
    {
        private string _eventlog;
        private SmartDate _regdate;
        private string _memo;
        private int _id;
        public string Memo
        {
            get { return _memo; }
        }
        public int ID
        {
            get
            {
                return _id;
            }
        }
        public string EventLog
        {
            get
            {
                return _eventlog;
            }
        }
        public string RegDate
        {
            get
            {
                return _regdate.Text;
            }
        }


        protected override object GetIdValue()
        {
            return _id;
        }

        public override string ToString()
        {
            return _id.ToString();
        }

        private StatusLog() { }


        internal StatusLog(SafeDataReader dr)
        {
            _id = dr.GetInt32("no");
            _memo = dr.GetString("memo");
            _eventlog = dr.GetString("eventlog");
            _regdate = dr.GetSmartDate("regdate",_regdate.EmptyIsMin);
        }
    }

}