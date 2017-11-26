using System;
using System.Data;
using System.Data.SqlClient;
using Dothan;
using Dothan.Data;
using Dothan.Library.Properties;

namespace Dothan.Library.bizMemberVisit
{
    [Serializable()]
    public class VisitReportInfo : ReadOnlyBase<VisitReportInfo>
    {
        #region Business Methods
        private int _id;
        private int _memberid;
        private string _membername = string.Empty;
        private string _cellname = string.Empty;
        private string _visittype = string.Empty;
        private SmartDate _visitdate = new SmartDate(false);
        private string _leader = string.Empty;
        private string _attendance = string.Empty;
        private string _context = string.Empty;
        private string _bible = string.Empty;
        private string _song = string.Empty;

        public int ID { get { return _id; } }
        public int MemberId { get { return _memberid; } }
        public string MemberName { get { return _membername; } }
        public string Attendance { get { return _attendance; } }
        public string Context { get { return _context; } }
        public string Bible { get { return _bible; } }
        public string Song { get { return _song; } }
        public string  VisitDate { get { return _visitdate.Text; } }
        public string CellName { get { return _cellname; } }
        public string VistType { get { return _visittype; } }
        public string Leader { get { return _leader; } }
        #endregion

        protected override object GetIdValue()
        {
            return _id;
        }

        public override string ToString()
        {
            return _membername;
        }

        private VisitReportInfo() { }

        internal VisitReportInfo(SafeDataReader dr)
        {
            _id = dr.GetInt32("Id");
            _memberid = dr.GetInt32("memberid");
            _membername = string.Format("{0}{1}",dr.GetString("last_name"),dr.GetString("first_name"));
            _song = dr.GetString("song").Trim();
            _bible = dr.GetString("bible").Trim();
            _cellname = dr.GetString("cellname");
            _context = dr.GetString("contents");
            if (_context.Length >75)
                _context = _context.Remove(74);
            _attendance = dr.GetString("attendent").Trim();
            _leader = dr.GetString("pastor").Trim();
            _visittype = dr.GetString("VisitTypeName").Trim();
            _visitdate = dr.GetSmartDate("visitdate", _visitdate.EmptyIsMin);
          
        }
    }
}
