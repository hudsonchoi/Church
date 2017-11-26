using System;
using System.Data;
using System.Data.SqlClient;
using Dothan;
using Dothan.Data;
using System.Collections.Generic;
using System.Xml;

namespace Dothan.Library.bizMember
{

    [Serializable()]
    public class Member : BusinessBase<Member>
    {
        #region Business Methods

        private int _id;
        private int _familyCode;
        private int _addressId;
        private string _firstName = string.Empty;
        private string _lastName = string.Empty;
        private string _enFirstName = string.Empty;
        private string _enLastName = string.Empty;
        private string _email = string.Empty;
        private string _cell = string.Empty;
        private string _work = string.Empty;
        private int _relationshipId;
        
        private bool _sex;
        private bool _marriage;
        
        
        
        private int _status;
        private SmartDate _statusDate = new SmartDate(false);
        private SmartDate _regDate = new SmartDate(false);
        private SmartDate _birthday = new SmartDate(false);
        private string _cellName = string.Empty;
        private string _ministryName = string.Empty;
        private int _fellowshipId;
        private int _subDivId;
        
        private string _familyName = string.Empty;
        private int _baptismId;
        private SmartDate _baptismyear;
        private string _job = string.Empty;
        private string _username = string.Empty;
        private int _jobtype;
        private int _entrytypeId;
        private int _dontateId;
        private string _fellowshipName = string.Empty;

        private byte[] _lastchanged = new byte[8];

        [System.ComponentModel.DataObjectField(true, true)]
        public int MemberID
        {
            get
            {
                return _id;
            }
        }


        #region Readonly Property

        public string CellName { get { return _cellName; } }
        public string Ministry { get { return _ministryName; } }

        public string StatusChanged { get { return _statusDate.Text; } }
        public string FamilyName { get { return _familyName; } }
        public string KoName { get { return string.Format("{0}{1}", _lastName, _firstName); } }

        public string EnName { get { return string.Format("{0}, {1}", _enFirstName, _enLastName); } }

        #endregion

        public string KoFirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                CanWriteProperty(true);
                if (value == null) value = string.Empty;
                if (_firstName != value)
                {
                    _firstName = value;
                    PropertyHasChanged();
                }
            }
        }
        public int DonateID
        {
            get
            {
                return _dontateId;
            }
            set
            {
                CanWriteProperty(true);
                if (!_dontateId.Equals(value))
                {
                    _dontateId = value;
                    PropertyHasChanged();
                }
            }

        }

        public string KoLastName
        {
            get
            {

                return _lastName;
            }
            set
            {
                CanWriteProperty(true);
                if (value == null) value = string.Empty;
                if (_lastName != value)
                {
                    _lastName = value;
                    PropertyHasChanged();
                }
            }
        }
        public string EnFirstName
        {
            get
            {
                return _enFirstName;
            }
            set
            {
                CanWriteProperty(true);
                if (value == null) value = string.Empty;
                if (_enFirstName != value)
                {
                    _enFirstName = value;
                    PropertyHasChanged();
                }
            }
        }
        public string EnLastName
        {
            get
            {
                return _enLastName;
            }
            set
            {
                CanWriteProperty(true);
                if (value == null) value = string.Empty;
                if (_enLastName != value)
                {
                    _enLastName = value;
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
        public int Sex
        {
            get
            {

                return _sex ? 1 : 0;
            }
            set
            {
                CanWriteProperty(true);
                if (!_sex.Equals(value))
                {
                    _sex = (value == 0) ? false : true;
                    PropertyHasChanged();
                }
            }
        }

        public int BaptismID
        {
            get
            {
                return _baptismId;
            }
            set
            {
                CanWriteProperty(true);
                if (!_baptismId.Equals(value))
                {
                    _baptismId = value;
                    PropertyHasChanged();
                }
            }
        }
        public string BaptismYear
        {
            get
            {
                return _baptismyear.Text;
            }
            set
            {
                CanWriteProperty(true);
                if (value == null) value = string.Empty;
                if (_baptismyear != value)
                {
                    _baptismyear.Text = value;
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
        public int Married
        {
            get
            {
                return _marriage ? 1 : 0;
            }
            set
            {
                CanWriteProperty(true);
                if (!_marriage.Equals(value))
                {
                    _marriage = (value == 0) ? false : true;
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
                if (!_status.Equals(value) && this.IsNew)
                {
                    _status = value;
                    _statusDate.Date = DateTime.Today;
                    PropertyHasChanged();
                }
            }
        }

        public int Relationship
        {
            get
            {
                return _relationshipId;
            }
            set
            {
                CanWriteProperty(true);
                
                    if (_familyCode == _id) return;

                if (_familyCode != _id && value == 0) return;

                if (!_relationshipId.Equals(value))
                {
                    _relationshipId = value;
                    PropertyHasChanged();
                }
            }
        }

        public int FamilyCode
        {
            get
            {
                return _familyCode;
            }
            set
            {
                CanWriteProperty(true);
                if (!_familyCode.Equals(value))
                {
                    _familyCode = value;

                    PropertyHasChanged();
                }
            }
        }
        public int EntryType
        {
            get
            {
                return _entrytypeId;
            }
            set
            {
                CanWriteProperty(true);
                if (!_entrytypeId.Equals(value))
                {
                    _entrytypeId = value;
                    PropertyHasChanged();
                }
            }
        }
        public int JobType
        {
            get
            {

                return _jobtype;
            }
            set
            {
                CanWriteProperty(true);
                if (!_jobtype.Equals(value))
                {
                    _jobtype = value;
                    PropertyHasChanged();
                }
            }
        }
        public int SubDivision
        {
            get
            {

                return _subDivId;
            }
            set
            {
                CanWriteProperty(true);
                if (!_subDivId.Equals(value))
                {
                    _subDivId = value;
                    PropertyHasChanged();
                }
            }
        }

        public string CellPhone
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
        public string WorkPhone
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

        public string RegDate
        {
            get
            {
                return _regDate.Text;
            }
            set
            {
                CanWriteProperty(true);
                if (value == null) value = string.Empty;
                if (_regDate != value)
                {
                    _regDate.Text = value;
                    PropertyHasChanged();
                }
            }
        }
        public string BirthDay
        {
            get
            {
                return _birthday.Text;
            }
            set
            {
                CanWriteProperty(true);
                if (value == null) value = string.Empty;
                if (_birthday != value)
                {
                    _birthday.Text = value;
                    PropertyHasChanged();
                }
            }
        }

        public string Fellowshinp
        {
            get
            {
                return _fellowshipName;
            }

        }

        public int Addressid
        {
            get
            {
                return _addressId;
            }
            set
            {
                CanWriteProperty(true);
                if (!_addressId.Equals(value))
                {
                    _addressId = value;
                    PropertyHasChanged();
                }
            }
        }





        public override bool IsValid
        {
            get { return base.IsValid; }
        }

        public override bool IsDirty
        {
            get { return base.IsDirty; }
        }

        protected override object GetIdValue()
        {
            return _id;
        }


        #endregion

        #region Authorization Rules


        protected override void AddAuthorizationRules()
        {
            // add AuthorizationRules here
        }

        public static bool CanAddObject()
        {
            bool result = false;
            /*  if (Dothan.ApplicationContext.User.IsInRole("Member_Admin"))
                  result = true;
              if (Dothan.ApplicationContext.User.IsInRole("SysAdmin"))
                  result = true;
              if (Dothan.ApplicationContext.User.IsInRole("Member_RW"))*/
            result = true;
            return result;
        }

        public static bool CanGetObject()
        {
            /*   bool result = false;
               if (Dothan.ApplicationContext.User.IsInRole("Member_R"))
                   result = true;
               if (Dothan.ApplicationContext.User.IsInRole("SysAdmin"))
                   result = true;
               if (Dothan.ApplicationContext.User.IsInRole("Member_RW"))
                   result = true;
               if (Dothan.ApplicationContext.User.IsInRole("Member_Admin"))
                   result = true; */
            return true;
        }

        public static bool CanDeleteObject()
        {
            bool result = false;
            if (Dothan.ApplicationContext.User.IsInRole("SysAdmin"))
                result = true;
            if (Dothan.ApplicationContext.User.IsInRole("Member_Admin"))
                result = true;
            return result;
        }

        public static bool CanEditObject()
        {
            /* bool result = false;
             if (Dothan.ApplicationContext.User.IsInRole("SysAdmin"))
                 result = true;
             if (Dothan.ApplicationContext.User.IsInRole("Member_RW"))
                 result = true;
             if (Dothan.ApplicationContext.User.IsInRole("Member_Admin"))
                 result = true;*/
            return true;
        }

        private bool BirthDayRule(object target, Dothan.Validation.RuleArgs e)
        {
            if (_birthday > DateTime.Today)
            {
                e.Description = "Birth date can't be after Today";
                return false;
            }
            else
                return true;
        }


        #endregion

        #region Validation Rules

        protected override void AddBusinessRules()
        {
            ValidationRules.AddRule(Dothan.Validation.CommonRules.StringRequired, "KoFirstName");
            ValidationRules.AddRule(Dothan.Validation.CommonRules.StringRequired, "KoLastName");
            ValidationRules.AddRule(Dothan.Validation.CommonRules.StringRequired, "BirthDay");
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
        #endregion
        
        #region Factory Methods

        public static Member Get(int code)
        {
            return DataPortal.Fetch<Member>(new Criteria(code));
        }

        public static Member New()
        {
            return DataPortal.Create<Member>();
        }

        public override Member Save()
        {
            return base.Save();
        }

        private Member() { }

        #endregion

        #region Data Access

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

        [RunLocal()]
        private void DataPortal_Create(Criteria criteria)
        {
            _regDate.Date = DateTime.Today;
            _username = Dothan.ApplicationContext.User.Identity.Name;
            ValidationRules.CheckRules();
        }

        private void DataPortal_Fetch(Criteria criteria)
        {
            using (SqlConnection cn = new SqlConnection(Database.ConnectionString))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "app_member.member_get";
                    cm.Parameters.AddWithValue("@id", criteria.code);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        dr.Read();
                        _id = dr.GetInt32("id");
                        _firstName = dr.GetString("first_name");
                        _lastName = dr.GetString("last_name");
                        _enFirstName = dr.GetString("en_first_name");
                        _enLastName = dr.GetString("en_last_name");
                        _email = dr.GetString("email");
                        _cell = dr.GetString("cell");
                        _addressId = dr.GetInt32("address_id");
                        _sex = dr.GetBoolean("sex");
                        _marriage = dr.GetBoolean("married");
                        _regDate = dr.GetSmartDate("regdate", _regDate.EmptyIsMin);
                        _statusDate = dr.GetSmartDate("statuschanged", _statusDate.EmptyIsMin);
                        _status = dr.GetInt32("statuscode");
                        _familyName = dr.GetString("familyName");
                        _familyCode = dr.GetInt32("family_code");
                        _baptismId = dr.GetInt32("baptism_id");
                        _baptismyear = dr.GetSmartDate("baptism_year");
                        _birthday = dr.GetSmartDate("birthday", _birthday.EmptyIsMin);
                        _entrytypeId = dr.GetInt32("entrytype");
                        _job = dr.GetString("job");
                        _work = dr.GetString("work_phone");
                        _cellName = dr.GetString("cellname");
                        _subDivId = dr.GetInt32("subdiv_id");
                        _jobtype = dr.GetInt32("jobtype");
                        _fellowshipName = dr.GetString("fellowshipname");
                        _relationshipId = (int)dr.GetByte("family_relationship");
                        _ministryName = dr.GetString("ministry");
                        dr.GetBytes("lastChanged", 0, _lastchanged, 0, 8);
                    }
                }
                _username = Dothan.ApplicationContext.User.Identity.Name;
            }
        }

        [Transactional(TransactionalTypes.TransactionScope)]
        protected override void DataPortal_Insert()
        {
            using (SqlConnection cn = new SqlConnection(Database.ConnectionString))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "app_member.member_insert";
                    cm.Parameters.AddWithValue("@first_name", _firstName);
                    cm.Parameters.AddWithValue("@last_name", _lastName);
                    cm.Parameters.AddWithValue("@en_first_name", _enFirstName);
                    cm.Parameters.AddWithValue("@en_last_name", _enLastName);
                    cm.Parameters.AddWithValue("@email", _email);
                    cm.Parameters.AddWithValue("@cell", _cell);
                    cm.Parameters.AddWithValue("@work_phone", _work);
                    cm.Parameters.AddWithValue("@regdate", _regDate.DBValue);
                    cm.Parameters.AddWithValue("@sex", _sex);
                    cm.Parameters.AddWithValue("@married", _marriage);
                    cm.Parameters.AddWithValue("@birthday", _birthday.DBValue);
                    cm.Parameters.AddWithValue("@family_code", _familyCode);
                    cm.Parameters.AddWithValue("@family_relationship", _relationshipId);
                    cm.Parameters.AddWithValue("@baptism_id", _baptismId);
                    cm.Parameters.AddWithValue("@baptism_year", _baptismyear.DBValue);
                    cm.Parameters.AddWithValue("@subdiv_id", _subDivId);
                    cm.Parameters.AddWithValue("@address_id", _addressId);
                    cm.Parameters.AddWithValue("@job", _job);
                    cm.Parameters.AddWithValue("@username", _username);
                    cm.Parameters.AddWithValue("@entrytype", _entrytypeId);
                    cm.Parameters.AddWithValue("@jobtype", _jobtype);
                    cm.Parameters.AddWithValue("@status", _status);
                    cm.Parameters.AddWithValue("@donateid", _dontateId);
                    cm.Parameters.Add("@newid", SqlDbType.Int).Direction = ParameterDirection.Output;

                    cm.Parameters.Add("@lastchanged", SqlDbType.Timestamp).Direction = ParameterDirection.Output;
                    cm.ExecuteNonQuery();

                    
                    _id = (int)cm.Parameters["@newid"].Value;
                    _lastchanged = (byte[])cm.Parameters["@lastchanged"].Value;

           
                   
                    MarkOld();
                }

            }
        }
        [Transactional(TransactionalTypes.TransactionScope)]
        protected override void DataPortal_Update()
        {
            if (base.IsDirty)
            {
                using (SqlConnection cn = new SqlConnection(Database.ConnectionString))
                {
                    cn.Open();

                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "app_member.member_update";
                        cm.Parameters.AddWithValue("@id", _id);
                        cm.Parameters.AddWithValue("@first_name", _firstName);
                        cm.Parameters.AddWithValue("@last_name", _lastName);
                        cm.Parameters.AddWithValue("@en_first_name", _enFirstName);
                        cm.Parameters.AddWithValue("@en_last_name", _enLastName);
                        cm.Parameters.AddWithValue("@email", _email);
                        cm.Parameters.AddWithValue("@cell", _cell);
                        cm.Parameters.AddWithValue("@work_phone", _work);
                        cm.Parameters.AddWithValue("@regdate", _regDate.DBValue);
                        cm.Parameters.AddWithValue("@sex", _sex);
                        cm.Parameters.AddWithValue("@married", _marriage);
                        cm.Parameters.AddWithValue("@birthday", _birthday.DBValue);
                        cm.Parameters.AddWithValue("@family_relationship", _relationshipId);
                        cm.Parameters.AddWithValue("@baptism_id", _baptismId);
                        cm.Parameters.AddWithValue("@baptism_year", _baptismyear.DBValue);
                        cm.Parameters.AddWithValue("@subdiv_id", _subDivId);
                        cm.Parameters.AddWithValue("@job", _job);
                        cm.Parameters.AddWithValue("@username" ,_username);
                        cm.Parameters.AddWithValue("@entrytype", _entrytypeId);
                        cm.Parameters.AddWithValue("@jobtype", _jobtype);
                        cm.Parameters.AddWithValue("@lastchanged", _lastchanged);
                        cm.Parameters.Add("@newlastchanged", SqlDbType.Timestamp).Direction = ParameterDirection.Output;
                        cm.ExecuteNonQuery();

                    } 
                    MarkClean();
                }
               
            }
        }




        #endregion


        #region To update SubDivision


        public static void ToUpdateSubDivision(int subDivId, string memberList)
        {
            DataPortal.Execute<MemberUpdateSubDivision>(new MemberUpdateSubDivision(subDivId, memberList));

        }

        [Serializable()]
        private class MemberUpdateSubDivision : CommandBase
        {
            private int _subDivId;
            private string _memberList = string.Empty;

            public MemberUpdateSubDivision(int subDivId, string memberList)
            {
                _memberList = memberList;
                _subDivId = subDivId;
            }
            protected override void DataPortal_Execute()
            {
                using (SqlConnection cn = new SqlConnection(Database.ConnectionString))
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {

                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "app_member.subdivision_update";
                        cm.Parameters.AddWithValue("@cList", _memberList.TrimEnd(','));
                        cm.Parameters.AddWithValue("@subdivision", _subDivId);
                        cm.ExecuteNonQuery();
                    }
                }
            }
        }
        #endregion

        #region To Update MemberStatus

        public static void ToUpdateStatus(int status, string id, string eventlog, string memo)
        {
            DataPortal.Execute<MemberUpdateSatus>(new MemberUpdateSatus(status, id, eventlog, memo));
        }

        [Serializable()]
        private class MemberUpdateSatus : CommandBase
        {
            private int _status;
            private string _id;
            private string _eventlog;
            private string _memo;

            public MemberUpdateSatus(int status, string id, string eventlog, string memo)
            {
                _status = status;
                _id = id;
                _eventlog = eventlog;
                _memo = memo;
            }
            protected override void DataPortal_Execute()
            {
                using (SqlConnection cn = new SqlConnection(Database.ConnectionString))
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {

                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "app_member.status_update";
                        cm.Parameters.AddWithValue("@statusid", _status);
                        cm.Parameters.AddWithValue("@eventlog", _eventlog);
                        cm.Parameters.AddWithValue("@memberList", _id);
                        cm.Parameters.AddWithValue("@memo", _memo);
                        cm.Parameters.AddWithValue("@username", Dothan.ApplicationContext.User.Identity.Name);

                        cm.ExecuteNonQuery();
                    }
                }
            }
        }



        #endregion


        #region To Serch MemberID by name and birthday

        public static int ToSearchMemberID(string name, string birthdate)
        {
            MemberGetID result;
            result = DataPortal.Execute<MemberGetID>(new MemberGetID(name, birthdate));
            return result.MemberId;
        }
        [Serializable()]
        private class MemberGetID : CommandBase
        {

            private string _name;
            private SmartDate _birthdate = new SmartDate(false);
            private int _memberid = 0;
            public int MemberId
            {
                get { return _memberid; }
            }

            public MemberGetID(string name, string birthdate)
            {
                _name = name;
                _birthdate.Text = birthdate;
            }
            protected override void DataPortal_Execute()
            {
                using (SqlConnection cn = new SqlConnection(Database.ConnectionString))
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {

                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "[app_member].[to_get_memberid]";
                        cm.Parameters.AddWithValue("@name", _name);
                        cm.Parameters.AddWithValue("@birthday", _birthdate.DBValue);
                        _memberid = (int)cm.ExecuteScalar();
                        
                    }
                }
            }
        }
        #endregion


        #region DeleteMember

        public static void DeleteMember(string memberlist, string username)
        {
            DataPortal.Execute<DeleteMemberCommand>(new DeleteMemberCommand(memberlist,username));
        }
        [Serializable()]
        private class DeleteMemberCommand : CommandBase
        {

            private string _memberlist;
            private string _username;

            public DeleteMemberCommand(string memberlist , string username)
            {
                _memberlist = memberlist;
                _username = username;

            }
            protected override void DataPortal_Execute()
            {
                using (SqlConnection cn = new SqlConnection(Database.ConnectionString))
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {

                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "[app_member].[member_delete]";
                        cm.Parameters.AddWithValue("@memberlist", _memberlist);
                        
                        cm.Parameters.AddWithValue("@username", _username);
                        cm.ExecuteNonQuery();
                    }
                }
            }
        }
        #endregion

        #region TO Splite Member From Family
        public static void ToSpliteMember(int memberid, int address, string username)
        {
            DataPortal.Execute<SpliteMemberCommand>(new SpliteMemberCommand(memberid, address, username));

        }

        [Serializable()]
        private class SpliteMemberCommand : CommandBase
        {
            private int _id;
            private int _address;
            private string _username;

            public SpliteMemberCommand(int memberid, int address, string username)
            {
                _id = memberid;
                _address = address;

                _username = username;
            }
            protected override void DataPortal_Execute()
            {
                using (SqlConnection cn = new SqlConnection(Database.ConnectionString))
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "[app_member].[to_splite_member]";
                        cm.Parameters.AddWithValue("@memberid", _id);
                        cm.Parameters.AddWithValue("@address", _address);
                        cm.Parameters.AddWithValue("@username", _username);
                        cm.ExecuteNonQuery();

                    }
                }
            }
        }
        #endregion


        #region TO Transfer member cell

        public static void ToTransferCell(string memberlist,string enddate, int cellcode, string username)
        {
            DataPortal.Execute<TransferCellCommand>(new TransferCellCommand(memberlist,enddate, cellcode, username));

        }

        [Serializable()]
        private class TransferCellCommand : CommandBase
        {
            private string _memberlist;
            private int _cellcode;
            private string _username;
            private SmartDate _enddate = new SmartDate(false);

            public TransferCellCommand(string memberlist, string enddate , int cellcode, string username)
            {
                _memberlist = memberlist;
                _cellcode = cellcode;
                _enddate.Text = enddate;
                _username = username;
            }
            protected override void DataPortal_Execute()
            {
                using (SqlConnection cn = new SqlConnection(Database.ConnectionString))
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "[app_cell].[transfer_member]";
                        cm.Parameters.AddWithValue("@list", _memberlist);
                        cm.Parameters.AddWithValue("@cellcode", _cellcode);
                        cm.Parameters.AddWithValue("@username", _username);
                        cm.Parameters.AddWithValue("@enddate", _enddate.DBValue);
                        cm.ExecuteNonQuery();

                    }
                }
            }
        }
        #endregion

        #region TO ChangeCode

        public static void ToChangeFamilyCode(int familycode,  XmlDocument relationship , string username)
        {
            DataPortal.Execute<ChangeFamilyCodeCommand>(new ChangeFamilyCodeCommand(familycode, relationship, username));

        }

        [Serializable()]
        private class ChangeFamilyCodeCommand : CommandBase
        {
            private int _familycode;
            private XmlDocument _relationship ;
            private string _username;

            public ChangeFamilyCodeCommand(int familycode, XmlDocument relationship, string username)
            {
                _familycode = familycode;
                _relationship = relationship;
                _username = username;
            }
            protected override void DataPortal_Execute()
            {
                using (SqlConnection cn = new SqlConnection(Database.ConnectionString))
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "[app_member].[familycode_update]";
                        cm.Parameters.AddWithValue("@familycode", _familycode);
                        cm.Parameters.AddWithValue("@relationship", _relationship.OuterXml);
                        cm.Parameters.AddWithValue("@username", _username);
                        cm.ExecuteNonQuery();
                    }
                }
            }
        }
        #endregion

        #region To Update Fellowship
        public static void ToUpdateFellowship(int memberid, int fellowshipcode)
        {
            DataPortal.Execute<UpdateFellowship>(new UpdateFellowship(memberid, fellowshipcode));

        }

        [Serializable()]
        private class UpdateFellowship : CommandBase
        {
            private int _id;

            private int _fellowship;

            public UpdateFellowship(int memberid, int fellowship)
            {
                _id = memberid;
                _fellowship = fellowship;
            }
            protected override void DataPortal_Execute()
            {
                using (SqlConnection cn = new SqlConnection(Database.ConnectionString))
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "[app_fellowship].[fellowship_member_insert]";
                        cm.Parameters.AddWithValue("@fellowshipCode", _fellowship);
                        cm.Parameters.AddWithValue("@memberid", _id);
                        cm.Parameters.AddWithValue("@startdate", DateTime.Today);
                        cm.Parameters.AddWithValue("@username", Dothan.ApplicationContext.User.Identity.Name);
                        
                        cm.ExecuteNonQuery();
                    }
                }
            }
        }
        #endregion
    }
}
