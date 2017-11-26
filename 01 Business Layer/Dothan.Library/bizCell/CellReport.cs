using System;
using System.Data;
using System.Data.SqlClient;
using Dothan;
using Dothan.Data;

namespace Dothan.Library.bizCell
{
    [Serializable()]
    public class CellReport : BusinessBase<CellReport>
    {
        private int _id;
        private SmartDate _regdate = new SmartDate(true);
        private SmartDate _celldate = new SmartDate(false);
        private int _cellcode;
        private string _cellname = string.Empty;
        private string _cellplace = string.Empty;
        private string _newmember = string.Empty;
        private string _leader = string.Empty;
        private string _prayer = string.Empty;
        private string _memo = string.Empty;
        private string _request = string.Empty;
        private string _createby = string.Empty;
        private string _username = string.Empty;
        private int _attendence;
        private int _totalfamily;
        private string _level1 = string.Empty;
        private string _level2 = string.Empty;
        private byte[] _lastchanged = new byte[8];
    
        private int _attfamily ;

        [System.ComponentModel.DataObjectField(true, true)]
        public int Id
        {
            get
            {
                
                return _id;
            }
        }
        public int CellCode
        {
            get
            {
                
                return _cellcode;
            }
            set
            {
                CanWriteProperty(true);
                if (!_cellcode.Equals(value))
                {
                    _cellcode = value;
                    PropertyHasChanged();
                }
            }
        }
        public string CellName
        {
            get
            {
                
                return _cellname;
            }
            set
            {
                CanWriteProperty(true);
                if (value == null) value = string.Empty;
                if (_cellname != value)
                {
                    _cellname = value;
                    PropertyHasChanged();
                }
            }
        }
        public string CreateBy
        {
            set
            {
                _createby = value;
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
        public string CellDate
        {
            get
            {
                
                return _celldate.Text;
            }
            set
            {
                CanWriteProperty(true);
                if (value == null) value = string.Empty;
                if (_celldate != value)
                {
                    _celldate.Text = value;
                    PropertyHasChanged();
                }
            }
        }
        public string CellPlace
        {
            get
            {
                
                return _cellplace;
            }
            set
            {
                CanWriteProperty(true);
                if (value == null) value = string.Empty;
                if (_cellplace != value)
                {
                    _cellplace = value;
                    PropertyHasChanged();
                }
            }
        }
        public string Prayer
        {
            get
            {
                
                return _prayer;
            }
            set
            {
                CanWriteProperty(true);
                if (value == null) value = string.Empty;
                if (_prayer != value)
                {
                    _prayer = value;
                    PropertyHasChanged();
                }
            }
        }

        public string Leader
        {
            get
            {
                
                return _leader;
            }
            set
            {
                CanWriteProperty(true);
                if (value == null) value = string.Empty;
                if (_leader != value)
                {
                    _leader = value;
                    PropertyHasChanged();
                }
            }
        }
        public string NewMember
        {
            get
            {
                
                return _newmember;
            }
            set
            {
                CanWriteProperty(true);
                if (value == null) value = string.Empty;
                if (_newmember != value)
                {
                    _newmember = value;
                    PropertyHasChanged();
                }
            }
        }
        public string Memo
        {
            get
            {
                
                return _memo;
            }
            set
            {
                CanWriteProperty(true);
                if (value == null) value = string.Empty;
                if (_memo != value)
                {
                    _memo = value;
                    PropertyHasChanged();
                }
            }
        }
        public string Request
        {
            get
            {
                
                return _request;
            }
            set
            {
                CanWriteProperty(true);
                if (value == null) value = string.Empty;
                if (_request != value)
                {
                    _request = value;
                    PropertyHasChanged();
                }
            }
        }
        public int Attendence
        {
            get
            {
                
                return _attendence;
            }
           
        }
        public int AttendFamily
        {
            get
            {
                
                return _attfamily;
            }
            set
            {
                CanWriteProperty(true);
                if (!_attfamily.Equals(value))
                {
                    _attfamily = value;
                    PropertyHasChanged();
                }
            }
        }
        public string Level1
        {
            get
            {

                return _level1;
            }
            set
            {
                CanWriteProperty(true);
                if (value == null) value = string.Empty;
                if (_level1 != value)
                {
                    _level1 = value;
                    PropertyHasChanged();
                }
            }
        }
        public string Level2
        {
            get
            {

                return _level2;
            }
            set
            {
                CanWriteProperty(true);
                if (value == null) value = string.Empty;
                if (_level2 != value)
                {
                    _level2 = value;
                    PropertyHasChanged();
                }
            }
        }


        public string UserName
        {
            get
            {
                return _username;
            }
            set
            {
                CanWriteProperty(true);
                if (value == null) value = string.Empty;
                if (_username != value)
                {
                    _username = value;
                    PropertyHasChanged();
                }
            }
        }

        #region Authorization Rules



        protected override object GetIdValue()
        {
            return _id;
        }

        protected override void AddAuthorizationRules()
        {
            // add AuthorizationRules here
        }

        public static bool CanAddObject()
        {
            return true;
        }

        public static bool CanGetObject()
        {
            return true;
        }

        public static bool CanDeleteObject()
        {
            return true;
        }

        public static bool CanEditObject()
        {
            return true;
        }

        #endregion

        #region Validation Rules

        protected override void AddBusinessRules()
        {
            ValidationRules.AddRule(Dothan.Validation.CommonRules.StringRequired, "CellPlace");
            ValidationRules.AddRule(Dothan.Validation.CommonRules.StringRequired, "CellDate");
            ValidationRules.AddRule(Dothan.Validation.CommonRules.StringRequired, "Leader");
        }

        #endregion

        
        public static CellReport Get(int code)
        {
            return DataPortal.Fetch<CellReport>(new Criteria(code));
        }

        public static CellReport New(int code )
        {
            return DataPortal.Create<CellReport>(new Criteria(code));
        }


        public static void Delete(int id , string username)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a Report");
            DataPortal.Delete(new Criteria(id, username));
        }
        public override CellReport Save()
        {
            return base.Save();
        }

        private CellReport() 
        {
           
        }
        [Serializable()]
        private class Criteria
        {
            private int _code;
            private string _username  = string.Empty;
            public int code
            {
                get
                {
                    return _code;
                }
            }
            public string username
            {
                get
                {
                    return _username;
                }
            }

            public Criteria(int code)
            {
                _code = code;
            }
            public Criteria(int code, string username)
            {
                _code = code;
                _username = username;
            }
        }

        [RunLocal()]
        private void DataPortal_Create(Criteria criteria)
        {
            _cellcode = criteria.code;
            _regdate.Date = DateTime.Today;
            _celldate.Date = DateTime.Today;
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
                    cm.CommandText = "[app_cell].[report_get]";
                    cm.Parameters.AddWithValue("@id", criteria.code);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        dr.Read();
                        _id = dr.GetInt32("Id");
                        _cellcode = dr.GetInt32("cell_code");
                        _cellname = dr.GetString("CellName");
                        _regdate = dr.GetSmartDate("reg_date", _regdate.EmptyIsMin);
                        _celldate = dr.GetSmartDate("cell_date", _celldate.EmptyIsMin);
                        _newmember = dr.GetString("new_member");
                        _leader = dr.GetString("leader");
                        _cellplace = dr.GetString("cell_place");
                        _prayer = dr.GetString("prayer");
                        _memo = dr.GetString("memo");
                        _request = dr.GetString("Request");
                        _attfamily = dr.GetInt32("atten_family_count");
                        _attendence = dr.GetInt32("atten_count");
                        _createby = dr.GetString("create_by");
                        _level1 = dr.GetString("cell_leader");
                        _level2 = dr.GetString("cell_leader2");
                        dr.GetBytes("Lastchanged", 0, _lastchanged, 0, 8); 
                    }

                }
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
                    cm.CommandText = "[app_cell].[report_insert]";
                    cm.Parameters.AddWithValue("@regdate", _regdate.DBValue);
                    cm.Parameters.AddWithValue("@celldate", _celldate.DBValue);
                    cm.Parameters.AddWithValue("@cellcode", _cellcode);
                    cm.Parameters.AddWithValue("@cellplace", _cellplace);
                    cm.Parameters.AddWithValue("@newmember", _newmember);
                    cm.Parameters.AddWithValue("@leader", _leader);
                    cm.Parameters.AddWithValue("@prayer", _prayer);
                    cm.Parameters.AddWithValue("@memo", _memo);
                    cm.Parameters.AddWithValue("@request", _request);
                    cm.Parameters.AddWithValue("@attenCount", _attfamily);
                    cm.Parameters.AddWithValue("@cell_leader",_level1);
                    cm.Parameters.AddWithValue("@cell_leader2",_level2);
                    cm.Parameters.AddWithValue("@username", _username);
                    cm.Parameters.Add("@newid", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cm.Parameters.Add("@newlastchanged", SqlDbType.Timestamp).Direction = ParameterDirection.Output;
                    cm.ExecuteNonQuery();
                    _id = (int)cm.Parameters["@newid"].Value;
                    _lastchanged = (byte[])cm.Parameters["@newlastchanged"].Value;
                }
                MarkOld();
            }
        }

        [Transactional(TransactionalTypes.TransactionScope)]
        protected override void DataPortal_Update()
        {
            if (!this.IsDirty) return;


            using (SqlConnection cn = new SqlConnection(Database.ConnectionString))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {

                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "[app_cell].[report_update]";
                    cm.Parameters.AddWithValue("@id", _id);
                    cm.Parameters.AddWithValue("@celldate", _celldate.DBValue);
                    cm.Parameters.AddWithValue("@cellplace", _cellplace);
                    cm.Parameters.AddWithValue("@newmember", _newmember);
                    cm.Parameters.AddWithValue("@leader", _leader);
                    cm.Parameters.AddWithValue("@prayer", _prayer);
                    cm.Parameters.AddWithValue("@memo", _memo);
                    cm.Parameters.AddWithValue("@request", _request);
                    cm.Parameters.AddWithValue("@attenCount", _attfamily);
                    cm.Parameters.AddWithValue("@username", _username);
                    cm.Parameters.AddWithValue("@lastchanged", _lastchanged);
                    cm.Parameters.Add("@newlastchanged", SqlDbType.Timestamp).Direction = ParameterDirection.Output;
                    cm.ExecuteNonQuery();
                    _lastchanged = (byte[])cm.Parameters["@newlastchanged"].Value;

                    MarkClean();
                }
            }

        }
        [Transactional(TransactionalTypes.TransactionScope)]
        protected override void DataPortal_DeleteSelf()
        {
            DataPortal_Delete(new Criteria(_id));
        }

        [Transactional(TransactionalTypes.TransactionScope)]
        private void DataPortal_Delete(Criteria criteria)
        {
            using (SqlConnection cn = new SqlConnection(Database.ConnectionString))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "[app_cell].[report_delete]";
                    cm.Parameters.AddWithValue("@id", criteria.code);
                    cm.Parameters.AddWithValue("@username", criteria.username);
                    cm.ExecuteNonQuery();
                }
            }
        }

        #region ChangePassword
    
        public static void ChangePasswordCellUser(string email,string pwd,string newpwd)
        {
             DataPortal.Execute<ChangePwdCommand>
              (new ChangePwdCommand(email,pwd,newpwd));
           
        }

        [Serializable()]
        private class ChangePwdCommand : CommandBase
        {
            private string _email;
            private string _pwd;
            private string _newpwd;

            public ChangePwdCommand (string email, string pwd,string newpwd)
            {
                _email = email;
                _pwd = pwd;
                _newpwd = newpwd;
            }

            protected override void DataPortal_Execute()
            {
                using (SqlConnection cn = new SqlConnection(Database.ConnectionString))
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "[app_cell].[user_password_update]";
                        cm.Parameters.AddWithValue("@username", _email);
                        cm.Parameters.AddWithValue("@oldpassword",_pwd);
                        cm.Parameters.AddWithValue("@password", _newpwd);
                        cm.ExecuteNonQuery();
                    }
                }
            }
        }
       
        #endregion

        #region SearchPassword

        public static string SearchPasswordCellUser(string email, string birthdate)
        {
            SearchPwdCommand result;
            result=DataPortal.Execute<SearchPwdCommand>(new SearchPwdCommand(email, birthdate));
            return result.Password;
        }

        [Serializable()]
        private class SearchPwdCommand : CommandBase
        {
            private string _email;
            private SmartDate _birthday;
            private string _password = string.Empty;

            public string Password
            { get { return _password; } }

            public SearchPwdCommand(string email, string birth)
            {
                _email = email;
                _birthday.Text = birth;
            }

            protected override void DataPortal_Execute()
            {
                using (SqlConnection cn = new SqlConnection(Database.ConnectionString))
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "[app_cell].[user_password_get]";
                        cm.Parameters.AddWithValue("@email", _email);
                        cm.Parameters.AddWithValue("@birthdate",_birthday.DBValue);
                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            dr.Read();
                            _password = dr.GetString("password");
                        }
                        
                    }
                }
            }
        }

        #endregion
    }
}
