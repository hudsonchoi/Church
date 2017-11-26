using System;
using System.Data;
using System.Data.SqlClient;
using Dothan;
using System.Collections.Generic;
using Dothan.Data;

namespace Dothan.Library
{
    [Serializable()]
    public class MemberDonate : ReadOnlyBase<MemberDonate>
    {
        private int _id;
        private int _memberid;
        private string _koname;
        private string _enname;
        private string _address;
        private string _city;
        private string _state;
        private string _zipcode;
        private string _sponse;
        private string _donatename;
        private SmartDate _donatedate = new SmartDate(false);
        private string _paidtype;
        private decimal _amount;
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
        public string  DonateName
        {
            get
            {
                return _donatename;
            }
        }
        public string DonateDate
        {
            get
            {
                return _donatedate.Text;
            }

        }
        public decimal DonateAmount
        {
            get
            {
                return _amount;
            }
        }
        public string Address
        {
            get
            {
                return string.Format("{0}, {1}, {2} {3}", _address, _city, _state, _zipcode);
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

        internal MemberDonate(SafeDataReader dr)
        {
            _id = dr.GetInt32("Id");
            _memberid = dr.GetInt32("member_id");
            _koname = dr.GetString("name");
            _fellowshipname = dr.GetString("FellowshipName");
            _enname = string.Format("{0} {1}",dr.GetString("en_first") , dr.GetString("en_last"));
            _city = dr.GetString("city");
            _state = dr.GetString("statecode");
            _zipcode = dr.GetString("zipcode");
            _address = dr.GetString("address");
            _sponse = dr.GetString("SpouseName");
           
        }

    }
}
