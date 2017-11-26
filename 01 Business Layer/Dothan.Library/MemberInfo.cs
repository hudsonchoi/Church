using System;
using System.Data;
using System.Data.SqlClient;
using Dothan;
using Dothan.Data;
using Dothan.Library.Properties;

namespace Dothan.Library
{
    [Serializable()]
    public class MemberInfo : ReadOnlyBase<MemberInfo>
    {
        #region Business Methods
        private int _id;
        private string _ko_name;
        private string _en_name;
        private string _email;
        private string _address;
        private string _city;
        private string _statecode;
        private string _zipcode;
        private string _home;
        private int _age;
        private string _sex;
        private string _cell;
        private SmartDate _regdate;
        private string _baptismname;
        private SmartDate _baptism_year;

        public int ID { get { return _id; } }
        public string Ko_Name { get { return _ko_name; } }
        public string En_Name { get { return _en_name; } }
        public string Email { get { return _email; } }
        public string Address { get { return _address; } }
        public string City { get { return _city; } }
        public string State { get { return _statecode; } }
        public string Zipcode { get { return _zipcode; } }
        public string Home { get { return _home; } }
        public string Cell { get { return _cell; } }
        public string Sex { get { return _sex; } }
        public int Age { get { return _age; } }
        public string RegDate { get { return _regdate.Text; } }
        public string Baptism { get { return _baptismname; } }
        public string Baptism_year { get { return _baptism_year.Text; } }

        protected override object GetIdValue()
        {
            return _id;
        }
        public override string ToString()
        {
            return Ko_Name;
        }

        #endregion
        public static MemberInfo GetMemberInfo(int code)
        {
            return DataPortal.Fetch<MemberInfo>(new Criteria(code));
        }

        [Serializable()]
        private class Criteria
        {
            private int _code;
            public int code
            {
                get
                {
                    return _code;
                }
            }
            public Criteria(int code)
            {
                _code = code;
            }
        }

        private MemberInfo() { }

        internal MemberInfo(SafeDataReader dr)
        {
            _id = dr.GetInt32("id");
            _ko_name = dr.GetString("ko_name");
            _en_name = dr.GetString("en_name");
            _email = dr.GetString("email");
            _address = dr.GetString("address");
            _city = dr.GetString("city");
            _statecode = dr.GetString("statecode");
            _zipcode = dr.GetString("zipcode");
            _home = dr.GetString("home");
            _age = dr.GetInt32("age");
            if (dr.GetByte("sex") == 0)
               _sex = Resources.Female.ToString();
            else
                 _sex = Resources.Male.ToString();
            _cell = dr.GetString("cell");
            _regdate = dr.GetSmartDate("regdate");
            _baptismname = dr.GetString("baptism_name");
            _baptism_year = dr.GetSmartDate("baptism_year");
        }



        private void DataPortal_Fetch(Criteria criteria)
        {
            using (SqlConnection cn = new SqlConnection(Database.ConnectionString))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "GetMemberInfo";
                    cm.Parameters.AddWithValue("@code", criteria.code);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        dr.Read();
                        _id = dr.GetInt32("id");
                        _ko_name = dr.GetString("ko_name");
                        _en_name = dr.GetString("en_name");
                        _email = dr.GetString("email");
                        _address = dr.GetString("address");
                        _city = dr.GetString("city");
                        _statecode = dr.GetString("statecode");
                        _zipcode = dr.GetString("zipcode");
                        _home = dr.GetString("home");
                        _age = dr.GetInt32("age");
                        if (dr.GetByte("sex") == 0)
                            _sex = Resources.Female.ToString();
                        else
                            _sex = Resources.Male.ToString();
                        _cell = dr.GetString("cell");
                        _regdate = dr.GetSmartDate("regdate");
                        _baptismname = dr.GetString("baptism_name");
                        _baptism_year = dr.GetSmartDate("baptism_year");
                          
                    }
                }
            }
        }
    }
}
