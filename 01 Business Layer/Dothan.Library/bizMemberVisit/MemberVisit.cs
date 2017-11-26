using System;
using System.Data;
using System.Data.SqlClient;
using Dothan;
using Dothan.Data;
using Dothan.Library.Properties;

namespace Dothan.Library.bizMemberVisit
{
    [Serializable()]
    public class MemberVisit : BusinessBase<MemberVisit>
    {
        private int _id;
        private int _memberid;
        private int _visittype;
        private SmartDate _visitdate = new SmartDate(false);
        private string _pastor = string.Empty;
        private string _attendent = string.Empty;
        private string _content = string.Empty;
        private string _recorder = string.Empty;
        private string _bible = string.Empty;
        private string _song = string.Empty;
        private string _fullname = string.Empty;
        private string _username = string.Empty;

        private byte[] _lastchanged = new byte[8];

        [System.ComponentModel.DataObjectField(true, true)]
        public int ID
        {
            get
            {
              
                return _id;
            }
        }
        public int MemberId
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
        public int VisitType
        {
            get
            {
              
                return _visittype;
            }
            set
            {
                CanWriteProperty(true);
                if (!_visittype.Equals(value))
                {
                    _visittype = value;
                    PropertyHasChanged();
                }
            }
        }
        public string Visitdate
        {
            get
            {
              
                return _visitdate.Text;
            }
            set
            {
                CanWriteProperty(true);
                if (value == null) value = string.Empty;
                if (_visitdate != value)
                {
                    _visitdate.Text = value;
                    PropertyHasChanged();
                }
            }
        }
        public string Pastor
        {
            get
            {
              
                return _pastor;
            }
            set
            {
                CanWriteProperty(true);
                if (value == null) value = string.Empty;
                if (_pastor != value)
                {
                    _pastor = value;
                    PropertyHasChanged();
                }
            }
        }
        public string Attendent
        {
            get
            {
              
                return _attendent;
            }
            set
            {
                CanWriteProperty(true);
                if (value == null) value = string.Empty;
                if (_attendent != value)
                {
                    _attendent = value;
                    PropertyHasChanged();
                }
            }
        }
        public string Content
        {
            get
            {
              
                return _content;
            }
            set
            {
                CanWriteProperty(true);
                if (value == null) value = string.Empty;
                if (_content != value)
                {
                    _content = value;
                    PropertyHasChanged();
                }
            }
        }
        public string Recorder
        {
            get
            {
              
                return _recorder;
            }
            
        }
        public string Bible
        {
            get
            {
              
                return _bible;
            }
            set
            {
                CanWriteProperty(true);
                if (value == null) value = string.Empty;
                if (_bible != value)
                {
                    _bible = value;
                    PropertyHasChanged();
                }
            }
        }
        public string Song
        {
            get
            {
              
                return _song;
            }
            set
            {
                CanWriteProperty(true);
                if (value == null) value = string.Empty;
                if (_song != value)
                {
                    _song = value;
                    PropertyHasChanged();
                }
            }
        }
        public string FullName
        {
            get
            {
              
                return _fullname;
            }

            set
            {
                CanWriteProperty(true);
                if (value == null) value = string.Empty;
                if (_fullname != value)
                {
                    _fullname = value;
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
            ValidationRules.AddRule(Dothan.Validation.CommonRules.StringRequired, "Pastor");
            ValidationRules.AddRule(Dothan.Validation.CommonRules.StringRequired, "Recorder");
            ValidationRules.AddRule(Dothan.Validation.CommonRules.StringRequired, "Visitdate");
            ValidationRules.AddRule(Dothan.Validation.CommonRules.StringRequired, "Content");
        }
        public static bool CanAddObject()
        {
            return Dothan.ApplicationContext.User.IsInRole("Visit_CanEdit");
        }

        public static bool CanGetAllObject()
        {
            return Dothan.ApplicationContext.User.IsInRole("Visit_CanGetAll");
        }

        public static bool CanGetObject()
        {
            return Dothan.ApplicationContext.User.IsInRole("Visit_CanGet");
        }

        public static bool CanDeleteObject()
        {
            return Dothan.ApplicationContext.User.IsInRole("Visit_CanDelete");
        }

        public static bool CanEditObject()
        {
            return Dothan.ApplicationContext.User.IsInRole("Visit_CanEdit");
        }

        public static MemberVisit New()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to Add a Visit");
            return DataPortal.Create<MemberVisit>();
        }

        public static MemberVisit Get(int id)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a Visit");
            return DataPortal.Fetch<MemberVisit>(new Criteria(id));
        }

        public static void Delete(int id)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a Visit");
            DataPortal.Delete(new Criteria(id));
        }


        private MemberVisit()
        { }

        public override MemberVisit Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a Visit");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a Visit");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a Visit");

            return base.Save();
        }

        #region Data Access

        [Serializable()]
        private class Criteria
        {
            private int _id;
            private string _username = string.Empty;
            public string UserName { get { return _username; } }
            public int Id
            {
                get { return _id; }
            }

            public Criteria(int id)
            { _id = id; }

            public Criteria(int id, string username)
            {
                _id = id;
                _username = username;
            }
        }

        [RunLocal()]
        private void DataPortal_Create(Criteria criteria)
        {
            _visitdate.Date = DateTime.Today;
            _recorder = ((Security.PTPrincipal)Dothan.ApplicationContext.User).UserName;
         
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
                    cm.CommandText = "[app_member].[visit_get]";
                    cm.Parameters.AddWithValue("@id", criteria.Id);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        dr.Read();
                        _id=dr.GetInt32("id");
                        _visittype = dr.GetInt32("visittype");
                        _visitdate = dr.GetSmartDate("visitdate", _visitdate.EmptyIsMin);
                        _pastor = dr.GetString("pastor");
                        _content = dr.GetString("contents");
                        _attendent = dr.GetString("attendent");
                        _recorder = dr.GetString("create_by");
                        _bible = dr.GetString("bible");
                        _song = dr.GetString("song");
                        _memberid = dr.GetInt32("memberid");
                        _fullname = string.Format("{0}{1}", dr.GetString("last_name"), dr.GetString("first_name"));

                        _username = Dothan.ApplicationContext.User.Identity.Name;
                        dr.GetBytes("lastChanged", 0, _lastchanged, 0, 8);//Retrived to enable update 031317
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
                    cm.CommandText = "[app_member].[visit_insert]";
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.Parameters.AddWithValue("@memberid", _memberid);
                    cm.Parameters.AddWithValue("@visittype", _visittype);
                    cm.Parameters.AddWithValue("@visitdate", _visitdate.DBValue);
                    cm.Parameters.AddWithValue("@pastor", _pastor);
                    cm.Parameters.AddWithValue("@attendent", _attendent);
                    cm.Parameters.AddWithValue("@content", _content);
                    cm.Parameters.AddWithValue("@username", _recorder);
                    cm.Parameters.AddWithValue("@bible", _bible);
                    cm.Parameters.AddWithValue("@song", _song);
                    cm.Parameters.Add("@newid", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cm.Parameters.Add("@newlastchanged", SqlDbType.Timestamp).Direction = ParameterDirection.Output;

                    cm.ExecuteNonQuery();
                    _id = (int)cm.Parameters["@newid"].Value;
                    _lastchanged = (byte[])cm.Parameters["@newlastchanged"].Value;
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
                        cm.CommandText = "[app_member].[visit_update]";
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.Parameters.AddWithValue("@id", _id);
                        cm.Parameters.AddWithValue("@visittype", _visittype);
                        cm.Parameters.AddWithValue("@visitdate", _visitdate.DBValue);
                        cm.Parameters.AddWithValue("@pastor", _pastor);
                        cm.Parameters.AddWithValue("@attendent", _attendent);
                        cm.Parameters.AddWithValue("@username", _username);
                        cm.Parameters.AddWithValue("@content", _content);
                        cm.Parameters.AddWithValue("@bible", _bible);
                        cm.Parameters.AddWithValue("@song", _song);
                        cm.Parameters.AddWithValue("@lastchanged", _lastchanged);
                        cm.Parameters.Add("@newlastchanged", SqlDbType.Timestamp).Direction = ParameterDirection.Output;
                        cm.ExecuteNonQuery();

                        _lastchanged = (byte[])cm.Parameters["@newlastchanged"].Value;//Debugged typo newlastchnaged 031317
     
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
                    cm.CommandText = "[app_member].[visit_delete]";
                    cm.Parameters.AddWithValue("@id", criteria.Id);
                    cm.Parameters.AddWithValue("@username", criteria.UserName);
                    cm.ExecuteNonQuery();
                }
            }
        }
        #endregion
    }
}
