using System;
using System.Data;
using System.Data.SqlClient;
using Dothan;
using Dothan.Data;


namespace Dothan.Library.bizMinistry
{
  

    [Serializable()]
    public class Ministry : BusinessBase<Ministry> 
    {
        #region Business 

        private int _id;
        private bool _idSet;
        private string _name = string.Empty;
        private int _assigned = 0;
        private int _parentcode;
        private string _username;
        private string _status;
        private string _updateby = string.Empty;
        private byte[] _lastchanged = new byte[8];

        [System.ComponentModel.DataObjectField(true, true)]
        public int Code
        {
            get
            {
              
                if (!_idSet)
                {
                    // generate a default id value
                    _idSet = true;
                    Ministrys parent = (Ministrys)this.Parent;
                    int max = 0;
                    foreach (Ministry item in parent)
                    {
                        if (item.Code > max)
                            max = item.Code;
                    }
                    _id = max + 1;
                }
                return _id;
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
        public string Status { get { return _status; } }
     
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
        public string CreateDate
        {
            get;
            private set;
        }
        public string UpdateBy { get { return _updateby; } }
        public int Assigned
        {
            get
            { return _assigned; }
        }
        protected override object GetIdValue()
        {
            return _id;
        }
        public override string ToString()
        {
            return _name;
        }
        #endregion

        protected override void AddBusinessRules()
        {
            ValidationRules.AddRule(Dothan.Validation.CommonRules.StringRequired, "Name");
           
        }

   
        internal static Ministry Get(SafeDataReader dr)
        {
            return new Ministry(dr);
        }

        internal static Ministry New()
        {
            return new Ministry();
        }

        private Ministry()
        {
            MarkAsChild();
            _status = "C";
            _username = Dothan.ApplicationContext.User.Identity.Name;
            ValidationRules.CheckRules();
        }

        private Ministry(SafeDataReader dr)
        {
            MarkAsChild();
            _idSet = true;
            _id = dr.GetInt32("code");
            _parentcode = dr.GetInt32("parent_code");
            _name = dr.GetString("name");
            _assigned = dr.GetInt32("total_assign");
            _status = dr.GetString("row_Status");
            _updateby = dr.GetString("update_by");
            CreateDate = dr.GetSmartDate("create_date", false).ToString();
            dr.GetBytes("lastchanged", 0, _lastchanged, 0, 8);
            MarkOld();
            _username = Dothan.ApplicationContext.User.Identity.Name;
           
        }

        internal void Insert(SqlConnection cn)
        {
            if (!this.IsDirty) return;
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "[app_ministry].[ministry_insert]";
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
                cm.CommandText = "[app_ministry].[ministry_update]";
                cm.Parameters.AddWithValue("@name", _name);
                cm.Parameters.AddWithValue("@id", _id);
                cm.Parameters.AddWithValue("@parentid", _parentcode);
                cm.Parameters.AddWithValue("@username", _username);
                cm.Parameters.AddWithValue("@lastchanged", _lastchanged);
                SqlParameter param = new SqlParameter("@newlastchanged", SqlDbType.Timestamp);
                param.Direction = ParameterDirection.Output;
                cm.Parameters.Add(param);
                cm.ExecuteNonQuery();
                _lastchanged = (byte[])cm.Parameters["@newlastchanged"].Value;
            
            }
        }

        internal void DeleteSelf(SqlConnection cn)
        {
            if (!this.IsDirty) return;
            if (this.IsNew) return;
            DeleteMinistry(cn, _id,_username);
            MarkNew();
        }


        internal static void DeleteMinistry(SqlConnection cn, int code , string username)
        {

            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "[app_ministry].[ministry_delete]";
                cm.Parameters.AddWithValue("@id", code);
                cm.Parameters.AddWithValue("@username", username);
                cm.ExecuteNonQuery();
            }
        }
        
    }
}
