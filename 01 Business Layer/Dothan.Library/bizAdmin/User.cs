using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using Dothan;
using Dothan.Data;


namespace Dothan.Library.bizAdmin
{
    [Serializable()]
    public class User : BusinessBase<User>
    {
        #region Business Methods

        private int _id;
        private string _username = string.Empty;
        private string _password = string.Empty;
        private string _name = string.Empty;
        private string _email;
        private SmartDate _regdate = new SmartDate(false);
        private SmartDate _lastlogin = new SmartDate(false);
        private string _roleList =string.Empty; 
        private string _updateBy = string.Empty;
        private string _editor = string.Empty;
       

        private byte[] _lastchanged = new byte[8];

        [System.ComponentModel.DataObjectField(true, true)]
        public int Id
        {
            get
            {
                return _id;
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
                if (_username != value)
                {
                    _username = value;
                    PropertyHasChanged();
                }
            }
        }
        public string MemberName
        {
            get
            {
                
                return _name;
            }
            set
            {
                CanWriteProperty(true);
                if (_name != value)
                {
                    _name = value;
                    PropertyHasChanged();
                }
            }
        }
        public string Password
        {
            get
            {
                
                return _password;
            }
            set
            {
                CanWriteProperty(true);
                if (_password != value)
                {
                    _password = value;
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
                if (string.IsNullOrEmpty(value)) return;
                if (_email != value)
                {
                    _email = value;
                    PropertyHasChanged();
                }
            }
        }
        public string UpdateBy
        {
            set
            {
                _updateBy = value;
            }
        }
  
        public string RoleList
        {
            get
            {
                
                return _roleList;
            }
            set
            {
                CanWriteProperty(true);
                if (string.IsNullOrEmpty(value)) return;
                if (_roleList !=value)
                {
                    _roleList = value;
                    PropertyHasChanged();
                }
            }
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
            return Dothan.ApplicationContext.User.IsInRole("SysAdmin");
        }

        public static bool CanGetObject()
        {
            return true;
        }

        public static bool CanDeleteObject()
        {
            return Dothan.ApplicationContext.User.IsInRole("SysAdmin");
        }

        public static bool CanEditObject()
        {
            return true;
        }

        #endregion

        #region Factory Method

   
        protected override void AddBusinessRules()
        {
            ValidationRules.AddRule(Dothan.Validation.CommonRules.StringRequired, "UserName");
            ValidationRules.AddRule(Dothan.Validation.CommonRules.StringRequired, "Password");
           
        }

        public static User Get(int id)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a user");
            return DataPortal.Fetch<User>(new Criteria(id)); 
        }

        public static User New()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a user");
            return DataPortal.Create<User>();
        }

        public static void Delete(int id, string username)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a user");
            DataPortal.Delete(new Criteria(id, username));
        }

        public override User Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a user");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a user");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a user");
            return base.Save();
        }

        private User() { }


        #endregion
        
        #region Data Access

        [Serializable()]
        private class Criteria
        {
            private int _id;
            private string _username;
            public int Id
            {
                get
                {
                    return _id;
                }
            }
            public string UserName { get { return _username; } }
            public Criteria(int id , string username)
            {
                _id = id;
                _username = username;
            }
            public Criteria(int id)
            {
                _id = id;
            }
        }

        [RunLocal()]
        private void DataPortal_Create(Criteria criteria)
        {
            _regdate.Date = DateTime.Today;
           
            _editor = Dothan.ApplicationContext.User.Identity.Name;
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
                    cm.CommandText = "[app_admin].[user_get]";
                    cm.Parameters.AddWithValue("@id", criteria.Id);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        dr.Read();
                        _id = dr.GetInt32("id");
                        _username = dr.GetString("username");
                        _password = dr.GetString("password");
                        _regdate = dr.GetSmartDate("regdate");
                        _lastlogin = dr.GetSmartDate("lastlogin");
                        _name = dr.GetString("name");
                        _email = dr.GetString("email");
                        _roleList = dr.GetString("roles").TrimEnd(',');
                        _updateBy = dr.GetString("update_by");

                        _editor = Dothan.ApplicationContext.User.Identity.Name;
                        dr.GetBytes("lastchanged", 0, _lastchanged, 0, 8);
                       
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
                    cm.CommandText = "app_admin.user_insert";
                    cm.Parameters.AddWithValue("@username", _username);
                    cm.Parameters.AddWithValue("@password", _password);
                    cm.Parameters.AddWithValue("@name", _name);
                    cm.Parameters.AddWithValue("@regdate", _regdate.DBValue);
                    cm.Parameters.AddWithValue("@roles", _roleList);
                    cm.Parameters.AddWithValue("@email", _email);
                    cm.Parameters.AddWithValue("@updateby", _editor);
                    cm.Parameters.Add("@newid", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cm.Parameters.Add("@newlastchanged", SqlDbType.Timestamp).Direction = ParameterDirection.Output;
                    cm.ExecuteNonQuery();
                    _id = (int)cm.Parameters["@newid"].Value;
                    _lastchanged = (byte[])cm.Parameters["@newlastchanged"].Value;
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
                        cm.CommandText = "app_admin.user_update";
                        cm.Parameters.AddWithValue("@id", _id);
                        cm.Parameters.AddWithValue("@username", _username);
                        cm.Parameters.AddWithValue("@password", _password);
                        cm.Parameters.AddWithValue("@name", _name);
                        cm.Parameters.AddWithValue("@roles", _roleList);
                        cm.Parameters.AddWithValue("@email", _email);
                        cm.Parameters.AddWithValue("@updateby", _editor);
                        cm.Parameters.AddWithValue("@lastchanged", _lastchanged);
                        cm.Parameters.Add("@newlastchanged", SqlDbType.Timestamp).Direction = ParameterDirection.Output;
                        cm.ExecuteNonQuery();

                        _lastchanged = (byte[])cm.Parameters["@newlastchanged"].Value;
                    }
                }
            }
        }


        [Transactional(TransactionalTypes.TransactionScope)]
        protected override void DataPortal_DeleteSelf()
        {
            DataPortal_Delete(new Criteria(_id,_editor));
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
                    cm.CommandText = "app_admin.user_delete";
                    cm.Parameters.AddWithValue("@id", criteria.Id);
                    cm.Parameters.AddWithValue("@updateBy", criteria.UserName);
                    cm.ExecuteNonQuery();
                }
            }
        }


       
        public static void ToChangePassword(string username , string oldpassword , string newpassword)
        {
            DataPortal.Execute<Comm_ChangePassword>(new Comm_ChangePassword(username , oldpassword,newpassword));
          
        }

        [Serializable()]
        private class Comm_ChangePassword : CommandBase
        {
            private string _username;
            private string _oldpassword;
            private string _newpassword;
     

            public Comm_ChangePassword(string username , string oldpassword , string newpassword)
            {
                _username = username;
                _oldpassword = oldpassword;
                _newpassword = newpassword;
            }

            protected override void DataPortal_Execute()
            {
                using (SqlConnection cn = new SqlConnection(Database.ConnectionString))
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "app_admin.user_password_reset";
                        cm.Parameters.AddWithValue("@username", _username);
                        cm.Parameters.AddWithValue("@newpassword", _newpassword);
                        cm.Parameters.AddWithValue("@oldpassword", _oldpassword);
                        cm.ExecuteNonQuery();
                    }
                }
            }
        }
        
        #endregion
    }
}
