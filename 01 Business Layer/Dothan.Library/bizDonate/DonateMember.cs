using System;
using System.Data;
using System.Data.SqlClient;
using Dothan;
using Dothan.Data;

namespace Dothan.Library.bizDonate
{
    [Serializable()]
    public class DonateMember : BusinessBase<DonateMember>
    {

        #region business Methods
        private int _id;
        private string _name = string.Empty;
        private string _enFirstName = string.Empty;
        private string _enLastName = string.Empty;
        private int _memberId;
        private int _addressId;
        private string _memo = string.Empty;
        //private string _home = string.Empty;
        //private string _address = string.Empty;
        //private string _city = string.Empty;
        //private string _state = string.Empty;
        //private string _zipcode = string.Empty;
        private SmartDate _regdate = new SmartDate(false);
        private byte[] _lastchanged = new byte[8];

        [System.ComponentModel.DataObjectField(true, true)]
        public int Id
        {
            get
            {
             
                return _id;
            }
        }
        public int AddressId
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
        public int MemberId
        {
            get
            {
             
                return _memberId;
            }
        }

        public string Name
        {
            get
            {
             
                return _name;
            }
            set
            {
                CanWriteProperty(true);
                if (value == null) value = string.Empty;
                if (_name != value)
                {
                    _name = value;
                    PropertyHasChanged();
                }
            }
        }

        public string EnFisrtName
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

        protected override object GetIdValue()
        {
            return _id;
        }

        #endregion

        #region  Validation Rules

        protected override void AddBusinessRules()
        {
            ValidationRules.AddRule(Dothan.Validation.CommonRules.StringRequired, "Name");
        }
        #endregion

        public static bool CanAddObject()
        {
            bool result = false;
            if (Dothan.ApplicationContext.User.IsInRole("DonateAdmin"))
                result = true;
            if (Dothan.ApplicationContext.User.IsInRole("DonateUser"))
                result = true;
            return result;
        }

        public static bool CanGetObject()
        {
            bool result = false;
            if (Dothan.ApplicationContext.User.IsInRole("DonateAdmin"))
                result = true;
            if (Dothan.ApplicationContext.User.IsInRole("DonateUser"))
                result = true;
            return result;
        }

        public static bool CanDeleteObject()
        {
            return Dothan.ApplicationContext.User.IsInRole("DonateAdmin");
        }

        public static bool CanEditObject()
        {
            bool result = false;
            if (Dothan.ApplicationContext.User.IsInRole("DonateAdmin"))
                result = true;
            if (Dothan.ApplicationContext.User.IsInRole("DonateUser"))
                result = true;
            return result;
        }

        #region Factory Methods

        public static DonateMember New()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a donate member.");
            return DataPortal.Create<DonateMember>();
        }

        public static DonateMember Get(int id)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a donate member.");
            return DataPortal.Fetch<DonateMember>(new Criteria(id));
        }


        public override DonateMember Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove  a donate member");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a donate member");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a donate member");
            return base.Save();
        }

        private DonateMember() { }

        #endregion
        #region Data Access

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

        [RunLocal()]
        private void DataPortal_Create(Criteria criteria)
        {
            _regdate.Date = DateTime.Today;
            ValidationRules.CheckRules();
        }


        private void DataPortal_Fetch(Criteria criteria)
        {
            using(SqlConnection cn = new SqlConnection(Database.ConnectionString))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "app_donate.donatemember_get";
                    cm.Parameters.AddWithValue("@id", criteria.Id);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        dr.Read();
                        _id = dr.GetInt32("id");
                        _name = dr.GetString("name");
                        _enLastName = dr.GetString("en_last");
                        _enFirstName = dr.GetString("en_first");
                        _addressId = dr.GetInt32("address_id");
                        _memberId = dr.GetInt32("member_id");
                        _memo = dr.GetString("memo");
                        _regdate = dr.GetSmartDate("regdate");
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
                    cm.CommandText = "app_donate.donatemember_insert";
                    cm.Parameters.AddWithValue("@name", _name);
                    cm.Parameters.AddWithValue("@enFirstName", _enFirstName);
                    cm.Parameters.AddWithValue("@enLastName", _enLastName);
                    cm.Parameters.AddWithValue("@memo", _memo);
                    cm.Parameters.AddWithValue("@addressid", _addressId);
                    cm.Parameters.AddWithValue("@regdate", _regdate.DBValue);
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
            if (base.IsDirty)
            {
                using (SqlConnection cn = new SqlConnection(Database.ConnectionString))
                {

                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "app_donate.donatemember_update";
                        cm.Parameters.AddWithValue("@id", _id);
                        cm.Parameters.AddWithValue("@name", _name);
                        cm.Parameters.AddWithValue("@enFirtName", _enFirstName);
                        cm.Parameters.AddWithValue("@enLastName", _enLastName);
                        cm.Parameters.AddWithValue("@memo", _memo);

                        cm.Parameters.AddWithValue("@addressid", _addressId);
                        cm.Parameters.AddWithValue("@lastchanged", _lastchanged);

                        SqlParameter param = new SqlParameter("@newlastchanged", SqlDbType.Timestamp);
                        param.Direction = ParameterDirection.Output;
                        cm.Parameters.Add(param);
                        cm.ExecuteNonQuery();
                        _lastchanged = (byte[])cm.Parameters["@newlastchanged"].Value;
                    }
                }
            }
        }

        [Transactional(TransactionalTypes.TransactionScope)]
        protected override void DataPortal_DeleteSelf()
        {
            DataPortal_Delete(new Criteria(_id));
        }

        #endregion


        public static void Remove(int id)
        {
             DataPortal.Execute<DeleteDonateCommand>(new DeleteDonateCommand(id));
        }
        [Serializable()]
        private class DeleteDonateCommand : CommandBase
        {

            private int _id;

            public DeleteDonateCommand(int id)
            {
                _id = id;
            }

            protected override void DataPortal_Execute()
            {
                
                    using (SqlConnection cn = new SqlConnection(Database.ConnectionString))
                    {
                        cn.Open();
                        using (SqlCommand cm = cn.CreateCommand())
                        {
                            cm.CommandType = CommandType.StoredProcedure;
                            cm.CommandText = "app_donate.donatemember_delete";
                            cm.Parameters.AddWithValue("@id", _id);
                            cm.ExecuteNonQuery();

                            int result = (int)cm.Parameters["@frk_n4ErrorCode"].Value;

                        }
                    }
                

            }
        }

        #region
        public static int MergeDonateMember(int donateid, string list, string username)
        {
           MergeDonate result = DataPortal.Execute<MergeDonate>(new MergeDonate(donateid, list, username));

           return result.AffectedRow;
        }

        [Serializable()]
        private class MergeDonate : CommandBase
        {
            private int _id;
            private string _list = string.Empty;
            private string _username = string.Empty;
            private int _affected = 0;

            public int AffectedRow { get { return _affected; } }

            public MergeDonate(int memberid, string list, string username)
            {
                _id = memberid;
                _list = list;
                _username = username;
            }
            protected override void DataPortal_Execute()
            {
                using (SqlConnection cn = new SqlConnection(Database.ConnectionString))
                {
                    cn.Open(); 
                    SqlCommand cm = cn.CreateCommand();
                    SqlTransaction trans = cn.BeginTransaction();
                    cm.Transaction = trans;
                    
                    try
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "[app_donate].[donatemember_merge]";
                        cm.Parameters.AddWithValue("@donateid", _id);
                        cm.Parameters.AddWithValue("@list", _list);
                        cm.Parameters.AddWithValue("@username", Dothan.ApplicationContext.User.Identity.Name);
                        cm.Parameters.Add("@roweffect", SqlDbType.Int).Direction = ParameterDirection.Output;
                        cm.ExecuteNonQuery();
                        trans.Commit();
                        _affected = (int)cm.Parameters["@roweffect"].Value;

                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                    }
                }
            }
        }

        #endregion
        //public static string GetDonateid(int id)
        //{
        //    GetDonateidCommand result;
        //    result = DataPortal.Execute<GetDonateidCommand>(new GetDonateidCommand(id));
        //    return result.Name;
        //}

        //[Serializable()]
        //private class GetDonateidCommand : CommandBase
        //{

        //    private int _id;
        //    private int _donateid;
        //    private string _name;

        //    public int Donateid
        //    {
        //        get { return _donateid; }
        //    }
        //    public string Name
        //    {
        //        get { return _name; }
        //    }
        //    public GetDonateidCommand(int id)
        //    {
        //        _id = id;
        //    }

        //    protected override void DataPortal_Execute()
        //    {
        //        using (SqlConnection cn = new SqlConnection(Database.ConnectionString))
        //        {
        //            cn.Open();
        //            using (SqlCommand cm = cn.CreateCommand())
        //            {
        //                cm.CommandType = CommandType.StoredProcedure;
        //                cm.CommandText = "GetDonateid";
        //                cm.Parameters.AddWithValue("@id", _id);
        //                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
        //                {
        //                    if (dr.Read())
        //                    {
        //                        _donateid = dr.GetInt32("id");
        //                        _name = string.Format("{0},{1}", dr.GetInt32("id"), dr.GetString("name"));
        //                    }
        //                    else
        //                    {
        //                        _donateid = 0;
        //                        _name = string.Empty;
        //                    }
        //                }
        //            }
        //        }
        //    }
        //}

        //public static bool CheckDonateHistory(int id)
        //{
        //    CheckDonateCommand result;
        //    result = DataPortal.Execute<CheckDonateCommand>(new CheckDonateCommand(id));
        //    return result.Result;
        //}

        //[Serializable()]
        //private class CheckDonateCommand : CommandBase
        //{

        //    private int _id;
        //    private bool _result;

        //    public bool Result
        //    {
        //        get { return _result; }
        //    }
      
        //    public CheckDonateCommand(int id)
        //    {
        //        _id = id;
        //    }

        //    protected override void DataPortal_Execute()
        //    {
        //        using (SqlConnection cn = new SqlConnection(Database.ConnectionString))
        //        {
        //            cn.Open();
        //            using (SqlCommand cm = cn.CreateCommand())
        //            {
        //                cm.CommandType = CommandType.StoredProcedure;
        //                cm.CommandText = "CheckDonateHistory";
        //                cm.Parameters.AddWithValue("@id", _id);
        //                int Count = (int)cm.ExecuteScalar();
        //                _result = Count > 0 ? false : true;
        //            }
        //        }
        //    }
        //}
    }
}
