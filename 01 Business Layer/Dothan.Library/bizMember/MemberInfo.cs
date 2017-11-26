using System;
using System.Data;
using System.Data.SqlClient;
using Dothan;
using Dothan.Data;
using Dothan.Library.Properties;

namespace Dothan.Library.bizMember
{
    [Serializable()]
    public class MemberInfo : ReadOnlyBase<MemberInfo>
    {
        #region Business Methods
        private int _id;
        private string _first_name = string.Empty;
        private string _last_name = string.Empty;
        private string _en_first = string.Empty;
        private string _en_last = string.Empty;
        private string _email = string.Empty;
        private string _address = string.Empty;
        private string _city = string.Empty;
        private string _statecode = string.Empty;
        private string _zipcode = string.Empty;
        private string _home = string.Empty;
        private int _age;
        private string _sex = string.Empty;
        private string _cell = string.Empty;
        private SmartDate _regdate = new SmartDate(false);
        private SmartDate _birthday = new SmartDate(false);
        private string _marrige = string.Empty;
        private string _baptismname = string.Empty;
        private SmartDate _baptism_year = new SmartDate(false);
        private SmartDate _fellowshipdate = new SmartDate(false);
        private string _fellowship = string.Empty;
        private string _subdivision = string.Empty;
        private int _statuscode;
        private string _cellname = string.Empty;
        private string _familyname = string.Empty;
        private string _spousename = string.Empty;
        private int _spouseid;
        private string _relastionship = string.Empty;
        private string _job = string.Empty;
        private string _active = string.Empty;
        private int _familycode;
        private string _statusname = string.Empty;

   

        public int MemberId { get { return _id; } }
        public string Ko_Name { get { return string.Format("{0}{1}",_last_name,_first_name); } }
        public string En_Name { get { return string.Format("{0}, {1}",_en_first, _en_last); } }
        public string Email { get { return _email; } }
        public string Address { get { return _address; } }
        public string City { get { return _city; } }
        public string State { get { return _statecode; } }
        public string Zipcode { get { return _zipcode; } }
        public string Home { get { return _home; } }
        public string Cell { get { return _cell; } }
        public string Sex { get { return _sex; } }
        public string Married { get { return _marrige; } }
        public int Age { get { return _age; } }
        public string FellowshipDate { get { return _fellowshipdate.Text; } }
        public string BirthDay { get { return _birthday.Text; } }
        public string FellowshipName { get { return _fellowship ; } }
        public string Spouse { get { return _spousename; } }
        public string FamilyName { get { return _familyname; } }
        public int FamilyCode { get { return _familycode; } }
        public string RelationShip { get { return _relastionship; } }
        public string RegDate { get { return _regdate.Text; } }
        public string Baptism { get { return _baptismname; } }
        public string Baptism_year { get { return _baptism_year.Text; } }
        public string SubDivision { get { return _subdivision; } }
        public string Job { get { return _job; } }
        public string CellName { get { return _cellname; } }
        public int SpouseID { get { return _spouseid; } }
        public string Active { get { return _active; } }
        public int StatusCode { get { return _statuscode; } }
        public string StatusName { get { return _statusname; } }
       


        protected override object GetIdValue()
        {
            return _id;
        }
        public override string ToString()
        {
            return Ko_Name;
        }

        #endregion

        private MemberInfo() { }

        internal MemberInfo(SafeDataReader dr)
        {
            _id = dr.GetInt32("id");
            _first_name = dr.GetString("first_name");
            _last_name = dr.GetString("last_name");
            _en_first = dr.GetString("en_first_name");
            _en_last = dr.GetString("en_last_name");
            _email = dr.GetString("email");
            _address = dr.GetString("address");
            _city = dr.GetString("city");
            _statecode = dr.GetString("statecode");
            _zipcode = dr.GetString("zipcode");
            _home = dr.GetString("home");
            _age = dr.GetInt32("age");
            _familyname = dr.GetString("family_name");
            _fellowshipdate = dr.GetSmartDate("fellowship_date",_fellowshipdate.EmptyIsMin);
            _fellowship = dr.GetString("fellowshipname");
            _birthday = dr.GetSmartDate("birthday", _birthday.EmptyIsMin);

            if (dr.GetBoolean("sex")) 
                _sex = Resources.Male.ToString();
            else
                _sex = Resources.Female.ToString();

            if (dr.GetBoolean("married"))
                _marrige = Resources.Married;
            else
                _marrige = Resources.Single;

            _relastionship = dr.GetString("relationship");
            _spousename = dr.GetString("spousename");
            _spouseid = dr.GetInt32("spouse");
            _job = dr.GetString("job");
            _cell = dr.GetString("cell");
            _cellname = dr.GetString("cellname");
            _regdate = dr.GetSmartDate("regdate");
            _regdate.FormatString = "yyyy-MM-dd";
            _baptismname = dr.GetString("baptismName");
            _baptism_year = dr.GetSmartDate("baptism_year");
            _subdivision = dr.GetString("SubDivisionName");
            _familycode = dr.GetInt32("family_code");
            _statuscode = dr.GetInt32("StatusCode");
            _statusname = dr.GetString("StatusName");
            if (dr.GetBoolean("active"))
                _active = Resources.Active;
            else
                _active = Resources.InActive;
            
        }
    }
}
