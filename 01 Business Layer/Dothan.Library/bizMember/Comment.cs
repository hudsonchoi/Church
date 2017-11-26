using System;
using System.Data;
using System.Data.SqlClient;
using Dothan;
using Dothan.Data;

namespace Dothan.Library.bizMember
{
    [Serializable()]
    public class Comment : BusinessBase<Comment>
    {

        private int _id;
        private string _comment;
        private int _memberid;
        private string _username = string.Empty;
        private SmartDate _regdate = new SmartDate(false);
        private SmartDate _updatedate;
        private string _updateby = string.Empty;
        private string _membername;
        private byte[] _lastchanged = new byte[8];

        [System.ComponentModel.DataObjectField(true, true)]
        public int Id
        {
            get
            {
              
                return _id;
            }
        }
        public string Context
        {
            get
            {
              
                return _comment;
            }
            set
            {
                CanWriteProperty(true);
                if (value == null) value = string.Empty;
                if (_comment != value)
                {
                    _comment = value;
                    PropertyHasChanged();
                }
            }
        }
        public string Regdate
        {
            get
            {
              
                return _regdate.Text;
            }
        }
        public string LastUpdated
        {
            get
            {

                return _updatedate.Text;
            }
        }
        public string Username
        {
            get
            {
              
                return _updateby;
            }

        }
        public string Member
        {
            get
            {
              
                return _membername;
            }
              set
            {
                CanWriteProperty(true);
                if (value == null) value = string.Empty;
                if (_membername != value)
                {
                    _membername = value;
                    PropertyHasChanged();
                }
            }
        }
        protected override object GetIdValue()
        {
            return _id;
        }
        protected override void AddBusinessRules()
        {
            ValidationRules.AddRule(Dothan.Validation.CommonRules.StringRequired, "Context");
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
            bool result = false;
           
            if (Dothan.ApplicationContext.User.IsInRole("SysAdmin"))
                result = true;
            return result;
        }

        public static bool CanEditObject()
        {
            return true;
        }

        public static Comment New(int id)
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a Comment");
            return DataPortal.Create<Comment>(new Criteria(id));
        }

        public static Comment Get(int id)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a Comment");
            return DataPortal.Fetch<Comment>(new Criteria(id));
        }

        public static void DeleteComment(int id)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a Comment");
            DataPortal.Delete(new Criteria(id));

        }

        [Serializable()]
        private class Criteria
        {
            private int _id;
            public int Id
            {
                get { return _id; }
            }

            public Criteria(int id)
            { _id = id; }
        }

        private Comment() { }

        [RunLocal()]
        private void DataPortal_Create(Criteria criteria)
        {
            _memberid = criteria.Id;
            _regdate.Date = DateTime.Today;
            _updatedate.Date = DateTime.Today;
            _updateby = Dothan.ApplicationContext.User.Identity.Name;
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
                    cm.CommandText = "app_member.comment_get";
                    cm.Parameters.AddWithValue("@id", criteria.Id);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        dr.Read();
                        _id = dr.GetInt32("id");
                        _comment = dr.GetString("comment");
                        _regdate = dr.GetSmartDate("regdate", _regdate.EmptyIsMin);
                        _updatedate = dr.GetSmartDate("update_date", _updatedate.EmptyIsMin);
                        _updateby = dr.GetString("update_by");
                        _memberid = dr.GetInt32("memberid");
                        _membername = dr.GetString("membername");

                        _username = Dothan.ApplicationContext.User.Identity.Name;
                        dr.GetBytes("lastChanged", 0, _lastchanged, 0, 8);
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
                    cm.CommandText = "app_member.comment_insert";
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.Parameters.AddWithValue("@comment", _comment);
                    cm.Parameters.AddWithValue("@memberid", _memberid);
                    cm.Parameters.AddWithValue("@username", _username);
                    cm.Parameters.Add("@newlastchanged", SqlDbType.Timestamp).Direction = ParameterDirection.Output;
                    cm.Parameters.Add("@newid", SqlDbType.Int).Direction = ParameterDirection.Output;
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
            if (base.IsDirty)
            {
                using (SqlConnection cn = new SqlConnection(Database.ConnectionString))
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                      
                        cm.CommandText = "app_member.comment_update";
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.Parameters.AddWithValue("@comment", _comment);
                        cm.Parameters.AddWithValue("@id", _id);
                        cm.Parameters.AddWithValue("@username", _username);
                        cm.Parameters.AddWithValue("@lastchanged", _lastchanged);
                        cm.Parameters.Add("@newlastchanged", SqlDbType.Timestamp).Direction = ParameterDirection.Output;
                        
                        cm.ExecuteNonQuery();

                        _lastchanged = (byte[])cm.Parameters["@newlastChanged"].Value;
                    }
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
                    cm.CommandText = "app_member.comment_delete";
                    cm.Parameters.AddWithValue("@id", criteria.Id);
                    cm.Parameters.AddWithValue("@username", Dothan.ApplicationContext.User.Identity.Name);
                    cm.ExecuteNonQuery();
                }
            }
        }

    }
}
