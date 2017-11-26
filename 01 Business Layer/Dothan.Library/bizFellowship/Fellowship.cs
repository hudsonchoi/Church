using System;
using System.Data;
using System.Data.SqlClient;
using Dothan;
using Dothan.Data;


namespace Dothan.Library.bizFellowship
{
    [Serializable()]
    public class Fellowship : BusinessBase<Fellowship>
    {
        private int _id;
        private bool _idSet;
        private string _name = string.Empty;
        private int _parentcode;
        private string _status = string.Empty;
        private string _username = string.Empty;
        private string _updateby = string.Empty;
        private byte[] _lastchanged = new byte[8];

        [System.ComponentModel.DataObjectField(true, true)]
        public int code
        {
            get
            {
              
                if (!_idSet)
                {
                    _idSet = true;
                    Fellowships parent = (Fellowships)this.Parent;
                    int max = 0;
                    foreach (Fellowship item in parent)
                    {
                        if (item.code > max)
                            max = item.code;
                    }
                    _id = max + 1;
                }
                return _id;
            }
            set
            {
                CanWriteProperty(true);
                if (!_id.Equals(value))
                {
                    _id = value;
                    PropertyHasChanged();
                }
            }
        }
        public string name
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
        public int parentcode
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
        public string Status
        {
            get
            {
              
                return _status;
            }
        }
        public string Sort
        {
            get;
            private set;
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

        protected override void AddBusinessRules()
        {
            ValidationRules.AddRule(Dothan.Validation.CommonRules.StringRequired, "Name");
        }

        internal static Fellowship Get(SafeDataReader dr)
        {
            return new Fellowship(dr);
        }
        internal static Fellowship New()
        {
            return new Fellowship();
        }

        private Fellowship() 
        {
            _status = "C";
            _username = Dothan.ApplicationContext.User.Identity.Name;
            MarkAsChild(); 
        }
        private Fellowship(SafeDataReader dr)
        {
            MarkAsChild();
            _idSet = true;
            _id = dr.GetInt32("code");
            _name = dr.GetString("name");
            _parentcode = dr.GetInt32("parent_code");
            _updateby = dr.GetString("update_by");
            _status = dr.GetString("row_status");
            Sort = dr.GetString("sort");
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
                cm.CommandText = "[app_fellowship].[fellowship_insert]";
                cm.Parameters.AddWithValue("@name", _name);
                cm.Parameters.AddWithValue("@parentid", _parentcode);
                cm.Parameters.AddWithValue("@username", _username);
                cm.Parameters.Add("@newid", SqlDbType.Int).Direction = ParameterDirection.Output;
                cm.Parameters.Add("@newlastchanged", SqlDbType.Timestamp).Direction = ParameterDirection.Output;
                cm.ExecuteNonQuery();
                _id = (int)cm.Parameters["@newid"].Value;
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
                cm.CommandText = "[app_fellowship].[fellowship_update]";
                cm.Parameters.AddWithValue("@name", _name);
                cm.Parameters.AddWithValue("@id", _id);
                cm.Parameters.AddWithValue("@parentid", _parentcode);
                cm.Parameters.AddWithValue("@lastchanged", _lastchanged);
                SqlParameter param = new SqlParameter("@newlastchanged", SqlDbType.Timestamp);
                param.Direction = ParameterDirection.Output;
                cm.Parameters.Add(param);
                cm.ExecuteNonQuery();
                _lastchanged = (byte[])cm.Parameters["@newlastchanged"].Value;
                MarkClean();
            }
        }

        internal void DeleteSelf(SqlConnection cn)
        {
            if (!this.IsDirty) return;
            if (this.IsNew) return;
            DeleteFellowship(cn, _id, _username);
            MarkNew();
        }

        internal static void DeleteFellowship(SqlConnection cn, int code, string username)
        {

            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "[app_fellowship].[fellowship_delete]";
                cm.Parameters.AddWithValue("@id",code );
                cm.Parameters.AddWithValue("@username", username);
                cm.ExecuteNonQuery();
            }
        }
    }
}
