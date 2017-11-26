using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Dothan;
using Dothan.Data;

namespace Dothan.Library.bizDonate
{
    [Serializable()]
    public class MemberDonateInfo : ReadOnlyBase<MemberDonateInfo>
    {
         private int _id;
        private int _memberid;
        private string _koname = string.Empty;
        private string _enname = string.Empty;
        private string _address = string.Empty;
        private string _city = string.Empty;
        private string _state = string.Empty;
        private string _zipcode = string.Empty;
        private string _sponse = string.Empty;
        private Dictionary<int, decimal> _donate = new Dictionary<int, decimal>();
        private decimal _total;
        private string _fellowshipname;

        [System.ComponentModel.DataObjectField(true, true)]
        public int ID
        {
            get { return _id; }
        }
        public int MemberID
        {
            get { return _memberid; }
        }
        public string KoName
        {
            get { return _koname; }
        }
        public string EnName
        {
            get { return _enname; }
        }
        public string Spouse
        {
            get
            {
                return _sponse;
            }
        }
        public string Fellowship
        {
            get
            {
                return _fellowshipname;
            }
        }

        public decimal GetDonate(int id)
        {
            if (_donate.ContainsKey(id))
                return _donate[id];
            else
                return 0;
        }

        public string Address
        {
            get
            {
                return string.Format("{0}, {1}, {2} {3}", _address, _city, _state, _zipcode);
            }
        }
    

        public decimal Total
        {
            get
            {
                return _total;
            }
        }
        public override string ToString()
        {
            return _koname;
        }

        protected override object GetIdValue()
        {
            return _id;
        }
        internal void AddAmount(SafeDataReader dr)
        {
            int parentcode = dr.GetInt32("parentcode");
            
                if (_donate.ContainsKey(parentcode))
                {
                    _donate[parentcode] = _donate[parentcode]+dr.GetDecimal("total");
                }
                else
                {
                    _donate.Add(dr.GetInt32("parentcode") , dr.GetDecimal("total"));
                }
            _total +=dr.GetDecimal("total");
        }

        internal MemberDonateInfo(SafeDataReader dr)
        {
            _id = dr.GetInt32("donate_id");
            _memberid = dr.GetInt32("member_id");
            _koname = dr.GetString("name");
            _fellowshipname = dr.GetString("fellowship");
            _enname = string.Format("{0} {1}",dr.GetString("en_first") , dr.GetString("en_last"));
            _city = dr.GetString("city");
            _state = dr.GetString("statecode");
            _zipcode = dr.GetString("zipcode");
            _address = dr.GetString("address");
            _sponse = dr.GetString("spousename");
            AddAmount(dr);
        }

    }
}
