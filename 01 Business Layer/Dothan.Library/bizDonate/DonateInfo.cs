using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Dothan;
using Dothan.Data;

namespace Dothan.Library.bizDonate
{
    [Serializable()]
    public class DonateInfo : ReadOnlyBase<DonateInfo>
    {
        private int _id;
        private decimal _amount;
        private string _donatetype;
        private SmartDate _donatedate;
        private string _paidtype;
        private string _memo;
     
        public int Id
        {
            get { return _id; }
        }
        public string Amount
        {
            get { return string.Format("{0:c}", _amount); }
        }
        public string Regdate
        {
            get { return _donatedate.Text; }
        }
        public string Memo
        {
            get { return _memo; }
        }
        public string DonateType
        {
            get { return _donatetype; }
        }

        protected override object GetIdValue()
        {
            return _id;
        }
        public override string ToString()
        {
            return _id.ToString();
        }

        private DonateInfo() { }
        internal DonateInfo(SafeDataReader dr)
        {
            _id = dr.GetInt32("no");
            _amount = dr.GetDecimal("amount");
            _donatetype = dr.GetString("donatetype");
            _donatedate = dr.GetSmartDate("donate_date", _donatedate.EmptyIsMin);
            _paidtype = dr.GetByte("pay_code").Equals(0)? "Cash":"Check";
            _memo = dr.GetString("memo");
        }
    }
}
