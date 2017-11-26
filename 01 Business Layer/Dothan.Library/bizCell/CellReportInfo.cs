using System;
using System.Data;
using System.Data.SqlClient;
using Dothan;
using Dothan.Data;
using Dothan.Library.Properties;

namespace Dothan.Library.bizCell
{
    [Serializable()]
    public class CellReportInfo : ReadOnlyBase<CellReportInfo>
    {
        private int _id;
        private SmartDate _regdate = new SmartDate(false);
        private SmartDate _celldate= new SmartDate(false);
        private string _cellplace;
        private int _attendance;
        private string _newmember;
        private string _request;
        private string _leader;
        private string _cellname;
        private int _memberno;
        private int _attenfamily;
        private string _memo;
 
        public int ID { get { return _id; } }
        public string CellName { get { return _cellname; } } 
        public string Leader { get { return _leader; } }
        public string Celldate { get { return _celldate.Text; } }
        public string CellPlace { get { return _cellplace; } }  
        public int MemberNo { get { return _memberno; } }
        public int Attendance { get { return _attendance; } }
        public int AttenFamily { get { return _attenfamily; } }
        public string NewMember { get { return _newmember; } }
        public string Request { get { return _request; } }
        public string Regdate { get { return _regdate.Text; } }
        public string Memo { get { return _memo; } }
       
        
        

        protected override object GetIdValue()
        {
            return _id;
        }
        public override string ToString()
        {
            return _id.ToString();
        }
        private CellReportInfo() { }

        internal CellReportInfo(SafeDataReader dr)
        {
            _id = dr.GetInt32("id");
            _regdate = dr.GetSmartDate("reg_date", _regdate.EmptyIsMin);
            _request = dr.GetString("request");
            _newmember = dr.GetString("new_member");
            _attendance = dr.GetInt32("attendance");
            _celldate = dr.GetSmartDate("cell_date", _celldate.EmptyIsMin);
            _cellplace = dr.GetString("cell_place");
            _leader = dr.GetString("leader");
            _cellname = dr.GetString("cell");
            _memberno = dr.GetInt32("memberno");

            _attenfamily = dr.GetInt32("atten_family_count");
            _memo = dr.GetString("memo");
        }
    }
}
