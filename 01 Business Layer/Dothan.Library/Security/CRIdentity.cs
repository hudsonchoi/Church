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
    public class CRIdentity : ReadOnlyBase<CRIdentity>, IIdentity
    {
        #region Business Methods

        private bool _isAuthenticated;
        private string _name = string.Empty;
        private int _cellcode;
        private List<string> _roles = new List<string>();


        public string AuthenticationType
        {
            get { return "Dothan"; }
        }

        public bool IsAuthenticated
        {
            get { return _isAuthenticated; }
        }
        public string Name
        {
            get { return _name; }
        }

   
        protected override object GetIdValue()
        {
            return _cellcode;
        }

        internal bool IsInRole(string role)
        {
            return _roles.Contains(role);
        }

        #endregion

        #region Factory Methods

        internal static CRIdentity UnauthenticatedIdentity()
        {
            return new CRIdentity();
        }

        internal static CRIdentity GetIdentity(string username, string password)
        {
            return DataPortal.Fetch<CRIdentity>(new Criteria(username, password));
        }

        private CRIdentity()
        { }

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
                    cm.CommandText = "[app_cell].[login]";
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.Parameters.AddWithValue("@user", criteria.Username);
                    cm.Parameters.AddWithValue("@pw", criteria.Password);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        if (dr.Read())
                        {
                            _name = dr.GetInt32("memberid").ToString();
                            _cellcode = dr.GetInt32("cellcode");
                            _roles.Add("Cellleader");
                            _isAuthenticated = true;
                        }
                        else
                        {
                            _name = string.Empty;
                            _isAuthenticated = false;
                            _cellcode = 0;
                        }
                    }
                }
            }
        }
        #endregion
    }
}
