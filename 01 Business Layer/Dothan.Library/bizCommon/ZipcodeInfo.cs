using System;
using System.Data;
using System.Data.SqlClient;
using Dothan;
using Dothan.Data;


namespace Dothan.Library.bizCommon
{
    [Serializable()]
    public class ZipcodeInfo : ReadOnlyBase<ZipcodeInfo>
    {
        private string _zipcode;
        private string _city;
        private string _state;
        private string _county;
        private int _no;


        public int No
        {
            get
            {
                return _no;
            }
        }
        public string Zipcode
        {
            get
            {
                return _zipcode;
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
        public string County
        {
            get
            {
                return _county;
            }
        }

        protected override object GetIdValue()
        {
            return _no;
        }

        public override string ToString()
        {
            return _zipcode;
        }

        private ZipcodeInfo() { }


        internal ZipcodeInfo(SafeDataReader dr)
        {
            _no = dr.GetInt32("id");
            _city = dr.GetString("city");
            _state = dr.GetString("state");
            _zipcode = dr.GetString("zipcode");
            _county = dr.GetString("county");
        }

    }
}
