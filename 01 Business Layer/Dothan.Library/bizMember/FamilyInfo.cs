using System;
using System.Data;
using System.Data.SqlClient;
using Dothan;
using Dothan.Data;
using Dothan.Library.Properties;


namespace Dothan.Library.bizMember
{

    [Serializable()]
    public class FamilyInfo : ReadOnlyBase<FamilyInfo>
    {
        private int _id;
        private string _first_name = string.Empty;
        private string _last_name = string.Empty;                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           
        private string _en_first = string.Empty;
        private string _en_last = string.Empty;
        private int _age;
        private string _sex = string.Empty;
        private string _marrige = string.Empty;
        private string _baptismname = string.Empty;
        private string _fellowship = string.Empty;
        private string _subdivision = string.Empty;
        private string _relastionship = string.Empty;
        private int _relastionshipcode = 0;
        private string _job = string.Empty;
        private string _active = string.Empty;
        private int _familycode;
        private string _statusname = string.Empty;



        public int MemberId { get { return _id; } }
        public string Ko_Name { get { return string.Format("{0}{1}", _last_name, _first_name); } }
        public string En_Name { get { return string.Format("{0}, {1}", _en_first, _en_last); } }
        public string Sex { get { return _sex; } }
        public string Married { get { return _marrige; } }
        public int Age { get { return _age; } }
        public string FellowshipName { get { return _fellowship; } }
        public int FamilyCode { get { return _familycode; } }
        public string RelationShip { get { return _relastionship; } }
        public string Baptism { get { return _baptismname; } }
        public string SubDivision { get { return _subdivision; } }
        public string Job { get { return _job; } }
        public string Active { get { return _active; } }
        public string StatusName { get { return _statusname; } }
        public int RelationShipCode { get { return _relastionshipcode; } }



        protected override object GetIdValue()
        {
            return _id;
        }
        public override string ToString()
        {
            return Ko_Name;
        }
        private FamilyInfo() { }

        internal FamilyInfo(SafeDataReader dr)
        {
            _id = dr.GetInt32("id");
            _first_name = dr.GetString("first_name");
            _last_name = dr.GetString("last_name");
            _en_first = dr.GetString("en_first_name");
            _en_last = dr.GetString("en_last_name");
      
            _age = dr.GetInt32("age");
    
            if (dr.GetBoolean("sex")) 
                _sex = Resources.Male.ToString();
            else
                _sex = Resources.Female.ToString();

            if (dr.GetBoolean("married"))
                _marrige = Resources.Married;
            else
                _marrige = Resources.Single;

            _relastionship = dr.GetString("relationship");
            _relastionshipcode = (int)dr.GetByte("family_relationship");
            _baptismname = dr.GetString("baptismName");
      
            _subdivision = dr.GetString("SubDivisionName");
            _familycode = dr.GetInt32("family_code");
            _statusname = dr.GetString("StatusName");
            if (dr.GetBoolean("active"))
                _active = Resources.Active;
            else
                _active = Resources.InActive;
            
        }
    }
}
