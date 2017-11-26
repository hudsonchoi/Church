using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Dothan;
using Dothan.Data;

namespace Dothan.Library.bizAdmin
{
    [Serializable()]
    public class UserInfo : ReadOnlyBase<UserInfo>
    {
        private int _id;
        private string _username;
        private string _name;
        private string _email;
        private SmartDate _regdate;
        private SmartDate _lastlogin;
        private bool _isActive;
        private string _updateby;

        public int Id
        {
            get { return _id; }
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
        public string Regdate
        {
            get { return _regdate.Text; }
        }
        public string LastLogin
        {
            get { return _lastlogin.Text; }
        }
        public bool IsActive
        {
            get { return _isActive; }
        }
        public string UpdateBy
        {
            get
            {
                return _updateby;
            }
        }
        protected override object GetIdValue()
        {
            return _id;
        }
        public override string ToString()
        {
            return _username;
        }

        private UserInfo(){}

        internal UserInfo(SafeDataReader dr)
        {
            _id = dr.GetInt32("id");
            _username = dr.GetString("username");
            _name = dr.GetString("name");
            _email = dr.GetString("email");
            _regdate = dr.GetSmartDate("regdate", _regdate.EmptyIsMin);
            _lastlogin = dr.GetSmartDate("lastlogin", _lastlogin.EmptyIsMin);
            _isActive = dr.GetBoolean("isActive");
            _updateby = dr.GetString("update_by");
        }


    }
}
