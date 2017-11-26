using System;
using System.Data;
using System.Data.SqlClient;
using Dothan;
using Dothan.Data;


namespace Dothan.Library.bizDonate
{
    [Serializable()]
    public class DonateType : BusinessBase<DonateType>
    {
        private int _code;
        private bool _idSet;
        private string _name = string.Empty;
        private int _parentcode;
        private bool _status;
        private string _username = string.Empty;
        private byte[] _lastchanged = new byte[8];


        [System.ComponentModel.DataObjectField(true, true)]
        public int Code
        {
            get
            {
                if (!_idSet)
                {
                    _idSet = true;
                    DonateTypes parent = (DonateTypes)this.Parent;
                    int max = 0;
                    foreach (DonateType item in parent)
                    {
                        if (item.Code > max)
                            max = item.Code;
                    }
                    _code = max + 1;
                }
                return _code;
            }
            set
            {
                CanWriteProperty(true);
                if (!_code.Equals(value))
                {
                    _code = value;
                    PropertyHasChanged();
                }
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
        public int ParentCode
        {
            get
            {
              
                return _parentcode;
            }
            set
            {
                CanWriteProperty(true);
                if (!_parentcode.Equals(value))
                {
                    _parentcode = value;
                    PropertyHasChanged();
                }
            }
        }
        public bool Status
        {
            get
            {
              
                return _status;
            }
            set
            {
                CanWriteProperty(true);
                if (!_status.Equals(value))
                {
                    _status = value;
                    PropertyHasChanged();
                }
            }
        }
        protected override object GetIdValue()
        {
            return _code;
        }

        protected override void AddBusinessRules()
        {
            ValidationRules.AddRule(Dothan.Validation.CommonRules.StringRequired, "Name");
        }

        internal static DonateType Get(SafeDataReader dr)
        {
            return new DonateType(dr);
        }
        internal static DonateType New()
        {
            return new DonateType();
        }

        private DonateType()
        {
            MarkAsChild();
            _username = Dothan.ApplicationContext.User.Identity.Name;
            ValidationRules.CheckRules();
        }
        private DonateType(SafeDataReader dr)
        {
            MarkAsChild();
            _idSet = true;
            _code = dr.GetInt32("code");
            _name = dr.GetString("name");
            _parentcode = dr.GetInt32("parent_code");
            _status = dr.GetBoolean("status");
            dr.GetBytes("lastchanged", 0, _lastchanged, 0, 8);

            _username = Dothan.ApplicationContext.User.Identity.Name;
            MarkOld();
        }

        internal void Insert(SqlConnection cn)
        {
            if (!this.IsDirty) return;
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "[app_donate].[donatetype_insert]";
                cm.Parameters.AddWithValue("@name", _name);
                cm.Parameters.AddWithValue("@parentcode", _parentcode);
                cm.Parameters.AddWithValue("@status", _status);
                cm.Parameters.AddWithValue("@username", _username);
                cm.Parameters.Add("@newid", SqlDbType.Int).Direction = ParameterDirection.Output;
                cm.Parameters.Add("@newlastchanged", SqlDbType.Timestamp).Direction = ParameterDirection.Output;
             
                cm.ExecuteNonQuery();
                _code = (int)cm.Parameters["@newid"].Value;
                _lastchanged = (byte[])cm.Parameters["@newlastchanged"].Value;

                MarkOld();
            }
        }

        internal void Update(SqlConnection cn)
        {
            if (!this.IsDirty) return;
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "[app_donate].[donatetype_update]";
                cm.Parameters.AddWithValue("@name", _name);
                cm.Parameters.AddWithValue("@code", _code);
                cm.Parameters.AddWithValue("@status", _status);
                cm.Parameters.AddWithValue("@parentcode", _parentcode);
                cm.Parameters.AddWithValue("@lastchanged", _lastchanged);
                cm.Parameters.AddWithValue("@username", _username);
                cm.Parameters.Add("@newlastchanged", SqlDbType.Timestamp).Direction = ParameterDirection.Output;
                cm.ExecuteNonQuery();
                _lastchanged = (byte[])cm.Parameters["@newlastchanged"].Value;
            }
        }

        internal void DeleteSelf(SqlConnection cn)
        {
            if (!this.IsDirty) return;
            if (this.IsNew) return;
            DeleteDonateType(cn, _code);
            MarkNew();
        }

        internal static void DeleteDonateType(SqlConnection cn, int code)
        {

            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "[app_donate].[donatetype_delete]";
                cm.Parameters.AddWithValue("@code", code);
                cm.ExecuteNonQuery();
            }
        }
    }
}