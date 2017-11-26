using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Dothan;
using Dothan.Data;

namespace Dothan.Library.bizDonate
{
    [Serializable()]
    public class DonateBookInfo : ReadOnlyBase<DonateBookInfo>
    {
        private int _id;
        private string _username;
        private SmartDate _regdate;
        private decimal _total;
        private string _donatename;

        public int Id
        {
            get { return _id; }
        }
        public string UserName
        {
            get { return _username; }
        }
        public DateTime Regdate
        {
            get { return _regdate.Date; }
        }
        public decimal  Amount
        {
            get { return _total; }
        }
        public string DonateType
        {
            get { return _donatename; }
        }

        protected override object GetIdValue()
        {
            return _id;
        }
        public override string ToString()
        {
            return _id.ToString();
        }

        private DonateBookInfo() { }
        internal DonateBookInfo(SafeDataReader dr)
        {
            _id = dr.GetInt32("id");
            _username = dr.GetString("username");
            _total = dr.GetDecimal("total");
            _donatename = dr.GetString("donatename");
            _regdate = dr.GetSmartDate("regdate", _regdate.EmptyIsMin);
        }
    }
}
