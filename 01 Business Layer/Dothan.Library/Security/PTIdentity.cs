using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Security.Principal;
using Dothan;
using Dothan.Data;

namespace Dothan.Library.Security
{
    [Serializable()]
    public class PTIdentity :
      ReadOnlyBase<PTIdentity>, IIdentity
    {
        #region Business Methods

        private bool _isAuthenticated;
        private string _username = string.Empty;
        private string _name = string.Empty;
        private int _id;
        private string _email = string.Empty;
        private List<string> _roles = new List<string>();
        private List<string> _divs = new List<string>();

       
        public string AuthenticationType
        {
            get { return "Dothan"; }
        }

        public bool IsAuthenticated
        {
            get { return _isAuthenticated; }
        }
        public string UserName
        {
            get { return _username; }
        }
        public string Name
        {
            get { return _name; }
        }

        public string Email
        {
            get { return _email; }
        }
         
        public int Id
        {
            get { return _id; }
        }
        protected override object GetIdValue()
        {
            return _id;
        }

        internal bool IsInRole(string role)
        {
            return _roles.Contains(role);
        }

        public int NumberOfRoles
        {
            get
            {
                return _roles.Count;
            }
        }
        #endregion

        #region Factory Methods

        internal static PTIdentity UnauthenticatedIdentity()
        {
            return new PTIdentity();
        }

        internal static PTIdentity GetIdentity(string username, string password)
        {
            return DataPortal.Fetch<PTIdentity> (new Criteria(username, password));
        }

        private PTIdentity()
        {            }

        #endregion

        #region Data Access

        [Serializable()]
        private class Criteria
        {
            private string _username;
            public string Username
            {
                get { return _username; }
            }

            private string _password;
            public string Password
            {
                get { return _password; }
            }

            public Criteria(string username, string password)
            {
                _username = username;
                _password = password;
            }
        }
        private void DataPortal_Fetch(Criteria criteria)
        {
            using (SqlConnection cn = new SqlConnection(Database.ConnectionString))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandText = "[app_common].[login]";
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.Parameters.AddWithValue("@user", criteria.Username);
                    cm.Parameters.AddWithValue("@password", criteria.Password);
                    using (SafeDataReader dr =new SafeDataReader(cm.ExecuteReader()))
                    {
                        if (dr.Read())
                        {
                            _isAuthenticated = true;
                            _username = dr.GetString("username");
                            _name = dr.GetString("name");
                            _email = dr.GetString("email");
                            _id = dr.GetInt32("id");
                            if (dr.NextResult())
                            {
                                while (dr.Read())
                                {
                                    _roles.Add(dr.GetString("roles"));
                                }
                            }
                            
                        }
                        else
                        {
                            throw new InvalidOperationException();
                        }
                    }
                }
            }
        }
        #endregion
    }
}
