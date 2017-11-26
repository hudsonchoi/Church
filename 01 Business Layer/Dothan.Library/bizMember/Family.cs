using System;
using System.Data;
using System.Data.SqlClient;
using Dothan;
using Dothan.Data;


namespace Dothan.Library
{
    [Serializable()]
    public class Family : BusinessBase<Family>
    {

        #region Business


      
        private int _memberid;
        private int _familycode;
        private string _firstname = string.Empty;
        private string _lastname = string.Empty;
        private string _en_firstname = string.Empty;
        private string _en_lastname = string.Empty;
        private int _sex;
        private int _age;
        private int _marriage;
        private string _cell = string.Empty;
        private SmartDate _birth;
        private int _subdivisioncode;
        private int _relationship = 1;
        private int _baptismcode;
        private string _baptism;
        private string _subdiv = string.Empty;
        private SmartDate _baptismyear = new SmartDate(false);
        private SmartDate _regdate;
        private string _job;
        private string _work;
        private int _fellowshipcode;
        private int _status;
        private int _entrytype;
        private string _email;
        private int _dontateid;

        [System.ComponentModel.DataObjectField(true, true)]
        public int MemberID
        {
            get
            {
              
                return _memberid;
            }
            set
            {
                CanWriteProperty(true);
                if (!_memberid.Equals(value))
                {
                    _memberid = value;
                    PropertyHasChanged();
                }
            }
        }
        public string Ko_Firstname
        {
            get
            {
              
                return _firstname;
            }
            set
            {
                CanWriteProperty(true);
                if (value == null) value = string.Empty;
                if (_firstname != value)
                {
                    _firstname = value;
                    PropertyHasChanged();
                }
            }
        }
        public string Ko_Lastname
        {
            get
            {
              
                return _lastname;
            }
            set
            {
                CanWriteProperty(true);
                if (value == null) value = string.Empty;
                if (_lastname != value)
                {
                    _lastname = value;
                    PropertyHasChanged();
                }
            }
        }
        public string Ko_FullName
        {
            get
            {
              
                return string.Format("{0}{1}", _lastname, _firstname);
            }
        }
        public string En_FullName
        {
            get
            {
              
                return string.Format("{0}  {1}", _en_lastname, _en_firstname);
            }
        }
        public string En_Firstname
        {
            get
            {
              
                return _en_firstname;
            }
            set
            {
                CanWriteProperty(true);
                if (value == null) value = string.Empty;
                if (_en_firstname != value)
                {
                    _en_firstname = value;
                    PropertyHasChanged();
                }
            }
        }
        public string En_Lastname
        {
            get
            {
              
                return _en_lastname;
            }
            set
            {
                CanWriteProperty(true);
                if (value == null) value = string.Empty;
                if (_en_lastname != value)
                {
                    _en_lastname = value;
                    PropertyHasChanged();
                }
            }
        }

        public int Sex
        {
            get
            {
              
                return _sex;
            }
            set
            {
                CanWriteProperty(true);
                if (!_sex.Equals(value))
                {
                    _sex = value;
                    PropertyHasChanged();
                }
            }
        }
        public int EntryType
        {
            get
            {
              
                return _entrytype;
            }
            set
            {
                CanWriteProperty(true);
                if (!_entrytype.Equals(value))
                {
                    _entrytype = value;
                    PropertyHasChanged();
                }
            }
        }
        public String BirthDay
        {
            get
            {
              
                return _birth.Text;
            }
            set
            {
                CanWriteProperty(true);
                if (value == null) value = string.Empty;
                if (_birth.Text != value)
                {
                    _birth.Text = value;
                    PropertyHasChanged();
                }
            }
        }

        public int Status
        {
            get
            {
              
                return _status;
            }
            set
            {
                CanWriteProperty(true);
                if (!_status.Equals(value))
                {
                    _status = value;
                    ValidationRules.CheckRules("Status");
                    PropertyHasChanged();
                }
            }
        }
        public string Baptism_Name
        {
            get
            {
              
                return _baptism;
            }
        }
        public int Age
        {
            get
            {
              
                return _age;
            }
        }
        public int Baptism_memberid
        {
            get
            {
              
                return _baptismcode;
            }
            set
            {
                CanWriteProperty(true);
                if (!_baptismcode.Equals(value))
                {
                    _baptismcode = value;
                    PropertyHasChanged();
                }
            }
        }
        public string Baptism_Year
        {
            get
            {
              
                return _baptismyear.Text;
            }
            set
            {
                CanWriteProperty(true);
                if (value == null) value = string.Empty;
                if (_baptismyear.Text != value)
                {
                    _baptismyear.Text = value;
                    PropertyHasChanged();
                }
            }
        }
        public string RegDate
        {
            get
            {
              
                return _regdate.Text;
            }
            set
            {
                CanWriteProperty(true);
                if (value == null) value = string.Empty;
                if (_regdate != value)
                {
                    _regdate.Text = value;
                    PropertyHasChanged();
                }
            }
        }
        public string Sub_Division
        {
            get
            {
              
                return _subdiv;
            }

        }
        public int Sub_Division_memberid
        {
            get
            {
              
                return _subdivisioncode;
            }
            set
            {
                CanWriteProperty(true);
                if (!_subdivisioncode.Equals(value))
                {
                    _subdivisioncode = value;

                    PropertyHasChanged();
                }
            }
        }
        public int Fellowship_memberid
        {
            get
            {
              
                return _fellowshipcode;
            }
            set
            {
                CanWriteProperty(true);
                if (!_fellowshipcode.Equals(value))
                {
                    _fellowshipcode = value;

                    PropertyHasChanged();
                }
            }
        }
        public int Relationship
        {
            get
            {
              
                return _relationship;
            }
            set
            {
                CanWriteProperty(true);
                if (!_relationship.Equals(value))
                {
                    switch (value)
                    {
                        case 0:
                            if (_memberid == _familycode)
                            {
                                _relationship = value;
                                PropertyHasChanged();
                            }
                            break;
                        default:
                            _relationship = value;
                            PropertyHasChanged();
                            break;
                    }

                }
            }
        }
        public int Family_memberid
        {
            get
            {
              
                return _familycode;
            }
            set
            {
                CanWriteProperty(true);
                if (!_familycode.Equals(value))
                {
                    _familycode = value;
                    PropertyHasChanged();
                }
            }
        }
        public int Married
        {
            get
            {
              
                return _marriage;
            }
            set
            {
                CanWriteProperty(true);
                if (!_marriage.Equals(value))
                {
                    _marriage = value;
                    PropertyHasChanged();
                }
            }
        }
        public string Cell
        {
            get
            {
              
                return _cell;
            }
            set
            {
                CanWriteProperty(true);
                if (value == null) value = string.Empty;
                if (_cell != value)
                {
                    _cell = value;
                    PropertyHasChanged();
                }
            }
        }
        public int DonateID
        {
            set
            {
                if (this.IsNew)
                    CanWriteProperty(true);
                else
                    CanWriteProperty(false);
                if (!_dontateid.Equals(value))
                {
                    _dontateid = value;
                    PropertyHasChanged();
                }
            }
        }  
        public string Email
        {
            get
            {
              
                return _email;
            }
            set
            {
                CanWriteProperty(true);
                if (value == null) value = string.Empty;
                if (_email != value)
                {
                    _email = value;
                    PropertyHasChanged();
                }
            }
        }
        public string Work
        {
            get
            {
              
                return _work;
            }
            set
            {
                CanWriteProperty(true);
                if (value == null) value = string.Empty;
                if (_work != value)
                {
                    _work = value;
                    PropertyHasChanged();
                }
            }
        }

        
        public string Job
        {
            get
            {
              
                return _job;
            }
            set
            {
                CanWriteProperty(true);
                if (value == null) value = string.Empty;
                if (_job != value)
                {
                    _job = value;
                    PropertyHasChanged();
                }
            }
        }


        protected override object GetIdValue()
        {
            return _memberid;
        }

        protected override void AddBusinessRules()
        {
            ValidationRules.AddRule(Dothan.Validation.CommonRules.StringRequired, "Ko_Firstname");
            ValidationRules.AddRule(Dothan.Validation.CommonRules.StringRequired, "Ko_Lastname");
            ValidationRules.AddRule(StatusValidation, "Status");
        }

        private bool StatusValidation(object target, Dothan.Validation.RuleArgs e)
        {
            if (_status == 0)
            {
                e.Description = "Please Select Member Status";
                return false;
            }
            else
            {
               return true;
            }
        }
        private bool NoDuplicates(object target, Dothan.Validation.RuleArgs e)
        {

            Familys parent = (Familys)this.Parent;
            if (parent != null)
                foreach (Family item in parent)
                    if (item.Code == _memberid && !ReferenceEquals(item, this))
                    {
                        e.Description = "Id must be unique";
                        return false;
                    }

            return true;
        }
        public static Family New()
        {
            return new Family();
        }
        public static Family Get(SafeDataReader dr)
        {
            return new Family(dr);
        }
        private Family() 
        {
            _regdate.Date = DateTime.Today;
            MarkAsChild();
            ValidationRules.CheckRules();
        }
        
        private Family(SafeDataReader dr)
        {
            MarkAsChild();
            _memberid = dr.GetInt32("id");
            _firstname = dr.GetString("first_name");
            _lastname = dr.GetString("last_name");
            _en_firstname = dr.GetString("en_first_name");
            _en_lastname = dr.GetString("en_last_name");
            _sex = (int)dr.GetByte("sex");
            _marriage = (int)dr.GetByte("married");
            _baptismcode = dr.GetInt32("baptism_memberid");
            _baptismyear = dr.GetSmartDate("baptism_year");
            _birth = dr.GetSmartDate("birthday");
            _cell = dr.GetString("cell");
            _job = dr.GetString("job");
            _familycode = dr.GetInt32("family_memberid");
            _baptism = dr.GetString("baptism_name");
            _subdiv = dr.GetString("SubDivisionName");
             _fellowshipcode = dr.GetInt32("fellowship_memberid");
            _work = dr.GetString("work");
            _age = dr.GetInt32("age");
            _subdivisioncode = dr.GetInt32("subdiv_memberid");
            _status = dr.GetInt32("statusCode");
            _entrytype = dr.GetInt32("entrytype");
            _relationship = (int)dr.GetByte("family_relationship");
            MarkOld();
        }
        #endregion
     
        internal void Insert(SqlConnection cn)
        {
            if (!this.IsDirty) return;
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "app_member.member_insert";
                cm.Parameters.AddWithValue("@family_memberid", _familycode);
                cm.Parameters.AddWithValue("@first_name", _firstname);
                cm.Parameters.AddWithValue("@last_name", _lastname);
                cm.Parameters.AddWithValue("@regdate", _regdate.DBValue);
                cm.Parameters.AddWithValue("@sex", _sex);
                cm.Parameters.AddWithValue("@married", _marriage);
                cm.Parameters.AddWithValue("@en_first", _en_firstname);
                cm.Parameters.AddWithValue("@en_last", _en_lastname);
                    cm.Parameters.AddWithValue("@cell", _cell);
                   cm.Parameters.AddWithValue("@email", _email);
                    cm.Parameters.AddWithValue("@work", _work);
                cm.Parameters.AddWithValue("@family_relationship", _relationship);
                cm.Parameters.AddWithValue("@birthday", _birth.DBValue);
                
                    cm.Parameters.AddWithValue("@subdiv_memberid", _subdiv);
              
                    cm.Parameters.AddWithValue("@entrytype", _entrytype);
              
                    cm.Parameters.AddWithValue("@job", _job);
             
                    cm.Parameters.AddWithValue("@baptism_memberid", _baptismcode);

                cm.Parameters.AddWithValue("@donateid", _dontateid);
              
                    cm.Parameters.AddWithValue("@baptism_year", _baptismyear.DBValue);
  
                SqlParameter param = new SqlParameter("@newid", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;
                cm.Parameters.Add(param);
                cm.ExecuteNonQuery();
                _memberid = (int)cm.Parameters["@newid"].Value; 
                
            }
            if (_memberid != 0)
            {
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "InsertMemberstatus";
                    cm.Parameters.AddWithValue("@status_memberid", _status);
                    cm.Parameters.AddWithValue("@member_id", _memberid);
                    cm.Parameters.AddWithValue("@lastchanged", _regdate.DBValue);
                    cm.ExecuteNonQuery();
                }
                if (!_fellowshipcode.Equals(0))
                {
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "InsertMemberFellowship";
                        cm.Parameters.AddWithValue("@fellowship_memberid", _fellowshipcode);
                        cm.Parameters.AddWithValue("@member_id", _memberid);
                        cm.Parameters.AddWithValue("@startdate", _regdate.DBValue);
                        SqlParameter param = new SqlParameter("@newid", SqlDbType.Int);
                        param.Direction = ParameterDirection.Output;
                        cm.Parameters.Add(param);
                        cm.ExecuteNonQuery();
                    }
                }
            }
            MarkOld();
        }

        internal void Update(SqlConnection cn)
        {
            if (!this.IsDirty) return;
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "UpdateFamily";
                cm.Parameters.AddWithValue("@code", _memberid);
                cm.Parameters.AddWithValue("@relationship", _relationship);
                cm.Parameters.AddWithValue("@familycode", _familycode);
                cm.ExecuteNonQuery();
                
            }
        }
        
    }
}
