using System;
using System.Data;
using System.Linq;
using System.Data.SqlClient;
using Dothan;
using Dothan.Data;
using Dothan.Validation;
using Dothan.Library.Security;

namespace Dothan.Library.bizDonate
{
    [Serializable()]
    public class DonateBook : BusinessBase<DonateBook>
    {
        #region Business Methods

        private int _id;
        private SmartDate _regdate = new SmartDate(false);
        private decimal _total;
        private int _donate_code;
        private decimal _checks;
        private string _detail = string.Empty;
        private string _createby = string.Empty;
        private int _userid;
        private int _hundred;
        private int _fifty;
        private int _twenty;
        private int _ten;
        private int _five;
        private string _typename;
        private int _one;
        private decimal _coins;
        private string _username;
        private int _checkcnt;
        private byte[] _lastchanged = new byte[8];

        private Donates _donates = Donates.New();


        [System.ComponentModel.DataObjectField(true, true)]
        public int Id
        {
            get
            {
              
                return _id;
            }
        }
        public string TypeName
        {
            get
            {
              
                return _typename;
            }
        }
        public int Hundred
        {
            get
            {
              
                return _hundred;
            }
            set
            {
                CanWriteProperty(true);
                if (!_hundred.Equals(value))
                {
                    _hundred = value;
                    PropertyHasChanged();
                }
            }

        }
        public int Fifty
        {
            get
            {
              
                return _fifty;
            }
            set
            {
                CanWriteProperty(true);
                if (!_fifty.Equals(value))
                {
                    _fifty = value;
                    PropertyHasChanged();
                }
            }
        }

        public int Twenty
        {
            get
            {
              
                return _twenty;
            }
            set
            {
                CanWriteProperty(true);
                if (!_twenty.Equals(value))
                {
                    _twenty = value;
                    PropertyHasChanged();
                }
            }
        }
        public int Ten
        {
            get
            {
              
                return _ten;
            }
            set
            {
                CanWriteProperty(true);
                if (!_ten.Equals(value))
                {
                    _ten = value;
                    PropertyHasChanged();
                }
            }
        }
        public int Five
        {
            get
            {
              
                return _five;
            }
            set
            {
                CanWriteProperty(true);
                if (!_five.Equals(value))
                {
                    _five = value;
                    PropertyHasChanged();
                }
            }
        }
        public int One
        {
            get
            {
              
                return _one;
            }
            set
            {
                CanWriteProperty(true);
                if (!_one.Equals(value))
                {
                    _one = value;
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
        public decimal Coins
        {
            get
            {
              
                return _coins;
            }
            set
            {
                CanWriteProperty(true);
                if (!_coins.Equals(value))
                {
                    _coins = value;
                    PropertyHasChanged();
                }
            }
        }
        public int CheckCount
        {
            get
            {
                if (_checkcnt == 0)
                {
                    _checkcnt = _donates.TotalCheckCount();
                }
                return _checkcnt;
            }
            set
            {
                CanWriteProperty(true);
                if (!_checkcnt.Equals(value))
                {
                    _checkcnt = value;
                    PropertyHasChanged();
                }
            }
        }
        public decimal Checks
        {
            get
            {
                return _checks;
            }
            set
            {
                CanWriteProperty(true);
                if (!_checks.Equals(value))
                {
                    _checks = value;
                    PropertyHasChanged();
                }
            }
        }
        public int DonateType
        {
            get
            {
              
                return _donate_code;
            }
            set
            {
                CanWriteProperty(true);
                if (!_donate_code.Equals(value))
                {
                    _donate_code = value;
                    
                    PropertyHasChanged();
                }
            }
        }

        public decimal Amount
        {
            get
            {
                _total =(decimal)(from o in _donates
                                    select o.Amount).Sum();
           
                return _total;
            }
        }

        public string Detail
        {
            get
            {
              
                return _detail;
            }
            set
            {
                CanWriteProperty(true);
                if (value == null) value = string.Empty;
                if (_detail != value)
                {
                    _detail = value;
                    PropertyHasChanged();
                }
            }
        }
        public string Createby { get { return _createby; } }
        public Donates DonateList
        {
            get { return _donates; }
        }

        public override bool IsValid
        {
            get
            {
                return base.IsValid && _donates.IsValid;
            }
        }

        public override bool IsDirty
        {
            get
            {
                return base.IsDirty || _donates.IsDirty;
            }
        }

        protected override object GetIdValue()
        {
            return _id;
        }

        public void CheckAmount()
        {
            _checks = _donates.TotalCheckAmt();
        }

        protected override void AddBusinessRules()
        {

            ValidationRules.AddRule(Dothan.Validation.CommonRules.IntegerMinValue, new Dothan.Validation.CommonRules.IntegerMinValueRuleArgs("DonateType", 1));
        }

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
            bool result = false;
            if (Dothan.ApplicationContext.User.IsInRole("DonateAdmin"))
                result = true;
            return result;
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

        #endregion

        private DonateBook() { }

   

        public static DonateBook New()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException( "User not authorized to add a donate report");
            return DataPortal.Create<DonateBook>();
        }


        public static DonateBook Get(int id)
        {
            if(!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a donate report");
            return DataPortal.Fetch<DonateBook>(new Criteria(id));
        }

        public override DonateBook Save()
        {
           
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a donate report");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a donate report");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a donate report");
            return base.Save();
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


        [RunLocal()]
        private void DataPortal_Create(Criteria criteria)
        {
            _regdate.Date = DateTime.Today;
            _createby = Dothan.ApplicationContext.User.Identity.Name;
            _userid = (Dothan.ApplicationContext.User as Dothan.Library.Security.PTPrincipal).ID;
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
                    cm.CommandText = "app_donate.donatebook_get";
                    cm.Parameters.AddWithValue("@id", criteria.Id);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        dr.Read();
                        _id = dr.GetInt32("id");
                        _total = dr.GetDecimal("total");
                        _detail = dr.GetString("detail");
                        _hundred = dr.GetInt32("hundred");
                        _fifty = dr.GetInt32("fifty");
                        _twenty = dr.GetInt32("twenty");
                        _ten = dr.GetInt32("ten");
                        _five = dr.GetInt32("five");
                        _one = dr.GetInt32("one");
                        _coins = dr.GetDecimal("coins");
                        _checks = dr.GetDecimal("checks");
                        _regdate = dr.GetSmartDate("regdate");
                        _checkcnt = dr.GetInt32("checkcnt");
                        _donate_code = dr.GetInt32("donate_code");
                        _createby = dr.GetString("create_by");
                        _typename = dr.GetString("typename");
                        _username = Dothan.ApplicationContext.User.Identity.Name;
                        dr.GetBytes("lastchanged", 0, _lastchanged, 0, 8);
                        dr.NextResult();
                        _donates = Donates.Get(dr);
                    }
                    MarkOld();
                }
            }
        }

        [Transactional(TransactionalTypes.TransactionScope)]
        protected override void DataPortal_Insert()
        {
            using (SqlConnection cn = new SqlConnection(Database.ConnectionString))
            {
                cn.Open();
                SqlTransaction trans = cn.BeginTransaction();
                SqlCommand cm = cn.CreateCommand();
                try
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "app_donate.donatebook_insert";
                    cm.Parameters.AddWithValue("@userid", _userid);
                    cm.Parameters.AddWithValue("@username", _createby);
                    cm.Parameters.AddWithValue("@total", _total);
                    cm.Parameters.AddWithValue("@detail", _detail);
                    cm.Parameters.AddWithValue("@hundred", _hundred);
                    cm.Parameters.AddWithValue("@fifty", _fifty);
                    cm.Parameters.AddWithValue("@twenty", _twenty);
                    cm.Parameters.AddWithValue("@ten", _ten);
                    cm.Parameters.AddWithValue("@five", _five);
                    cm.Parameters.AddWithValue("@one", _one);
                    cm.Parameters.AddWithValue("@coins", _coins);
                    cm.Parameters.AddWithValue("@checks", _checks);
                    cm.Parameters.AddWithValue("@checkCnt", _checkcnt);
                    cm.Parameters.AddWithValue("@regdate", _regdate.DBValue);
                    cm.Parameters.AddWithValue("@donate_code", _donate_code);
                    cm.Parameters.Add("@newid", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cm.Parameters.Add("@newlastchanged", SqlDbType.Timestamp).Direction = ParameterDirection.Output;

                    cm.ExecuteNonQuery();

                    _id = (int)cm.Parameters["@newid"].Value;
                    _lastchanged = (byte[])cm.Parameters["@newlastchanged"].Value;
                    _donates.Update(cm, this);

                    trans.Commit();
                }
                catch
                {
                    trans.Rollback();
                }
            }
        }

        [Transactional(TransactionalTypes.TransactionScope)]
        protected override void DataPortal_Update()
        {
            if (!this.IsDirty) return;

            using (SqlConnection cn = new SqlConnection(Database.ConnectionString))
            {
                cn.Open();
                SqlTransaction trans = cn.BeginTransaction();
                SqlCommand cm = cn.CreateCommand();
                try
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "app_donate.donatebook_update";
                    cm.Parameters.AddWithValue("@username", _username);
                    cm.Parameters.AddWithValue("@total", _total);
                    cm.Parameters.AddWithValue("@detail", _detail);
                    cm.Parameters.AddWithValue("@hundred", _hundred);
                    cm.Parameters.AddWithValue("@fifty", _fifty);
                    cm.Parameters.AddWithValue("@twenty", _twenty);
                    cm.Parameters.AddWithValue("@ten", _ten);
                    cm.Parameters.AddWithValue("@five", _five);
                    cm.Parameters.AddWithValue("@one", _one);
                    cm.Parameters.AddWithValue("@coins", _coins);
                    cm.Parameters.AddWithValue("@checks", _checks);
                    cm.Parameters.AddWithValue("@checkCnt", _checkcnt);
                    cm.Parameters.AddWithValue("@regdate", _regdate.DBValue);
                    cm.Parameters.AddWithValue("@donate_code", _donate_code);
                    cm.Parameters.AddWithValue("@lastchanged", _lastchanged);
                    cm.Parameters.AddWithValue("@id", _id);
                    cm.Parameters.Add("@newlastchanged", SqlDbType.Timestamp).Direction = ParameterDirection.Output;

                    cm.ExecuteNonQuery();

                    _lastchanged = (byte[])cm.Parameters["@newlastchanged"].Value;

                    _donates.Update(cm, this);

                    trans.Commit();

                    MarkClean();
                }
                catch
                {
                    trans.Rollback();
                }
            }
        }
    }
}
