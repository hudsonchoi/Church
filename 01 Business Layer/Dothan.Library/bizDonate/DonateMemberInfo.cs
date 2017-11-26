using System;
using System.Data;
using System.Data.SqlClient;
using Dothan;
using Dothan.Data;

namespace Dothan.Library.bizDonate
{
    [Serializable()]
    public class DonateMemberInfo : ReadOnlyBase<DonateMemberInfo>
    {
        private int _id;
        private int _memberid;
        private int _addressid;
        private string _name;
        private string _en_first;
        private string _en_last;
        private string _address;
        private string _city;
        private string _state;
        private string _zipcode;
        private string _memo;
        private string _spouse;
        private string _cellphone;
        private bool _active;
        private decimal _total;
        private SmartDate _regdate;


        [System.ComponentModel.DataObjectField(true, true)]
        public int ID
        {
            get { return _id; }
        }
        public int MemberID
        {
            get { return _memberid; }
        }
        public string CellPhone
        {
            get { return _cellphone; }
        }
        public int AddressID
        {
            get
            { return _addressid; }
        }
        public string Ko_name
        {
            get { return _name; }
        }
        public string Memo
        {
            get
            {
                return _memo;
            }
        }
        public string Spouse
        {
            get
            {
                return _spouse;
            }
        }
        public bool Active
        {
            get
            {
                return _active;
            }
        }
        public string En_name
        {
            get { return string.Format("{0} {1}", _en_first, _en_last); }
        }
        public string En_firstname
        {
            get
            {
                return _en_first;
            }
        }
        public string En_lastname
        {
            get
            {
                return _en_last;
            }
        }
        public string Address
        {
            get
            {
                return _address;
            }
        }
        public string City
        {
            get
            {
                return _city;
            }
        }
        public string State
        {
            get
            {
                return _state;
            }
        }
        public string Zipcode
        {
            get
            {
                return _zipcode;
            }
        }
        public string FullAddress
        {
            get { return string.Format("{0}  {1}, {2}  {3}", _address, _city, _state, _zipcode); }
        }
        public string Regdate
        {
            get { return _regdate.Text; }
        }
        private DonateMemberInfo() { }


        protected override object GetIdValue()
        {
            return _id;
        }

        internal DonateMemberInfo(SafeDataReader dr)
        {
            _id = dr.GetInt32("Id");
            _memberid = dr.GetInt32("member_id");
            _addressid = dr.GetInt32("address_id");
            _name = dr.GetString("name");
            _en_first = dr.GetString("en_first");
            _en_last = dr.GetString("en_last");
            _city = dr.GetString("city");
            _state = dr.GetString("statecode");
            _zipcode = dr.GetString("zipcode");
            _address = dr.GetString("address");
            _regdate = dr.GetSmartDate("regdate");
            _spouse = dr.GetString("Spousename");
            _memo = dr.GetString("memo");
            _active = dr.GetBoolean("active");
            _cellphone = dr.GetString("cell");

        }


        public override string ToString()
        {
            return _name;
        }
    }
}
