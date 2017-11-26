using System;
using System.Data;
using System.Data.SqlClient;
using Dothan;
using Dothan.Data;

namespace Dothan.Library.bizAdmin
{
    [Serializable()]
    public class StatusType : BusinessBase<StatusType>
    {
         #region Business Methods

        private int _id ;
        private bool _idSet;
        private string _name = string.Empty;
        private bool _isActive ;
        private string _updateby = string.Empty;
        private byte[] _lastchanged = new byte[8];
        private string _username = string.Empty;

        [System.ComponentModel.DataObjectField(true,true)]
        public int ID
        {
            get
            {
                
                if (!_idSet)
                {
                    _idSet = true;
                    StatusTypes parent = (StatusTypes)this.Parent;
                    int max = 0;
                    foreach (StatusType item in parent)
                    {
                        if (item.ID > max)
                            max = item.ID;
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
        public bool IsActive
        {
            get
            {
                
                return _isActive;
            }
            set
            {
                CanWriteProperty(true);
                if (!_isActive.Equals(value))
                {
                    _isActive = value;
                    PropertyHasChanged();
                }
            }
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

        #endregion


        internal static StatusType GetLabel(SafeDataReader dr)
        {
            return new StatusType(dr);
        }

        internal static StatusType NewLabel()
        {
            return new StatusType();
        }

        private StatusType() { MarkAsChild(); }

        private StatusType(SafeDataReader dr)
        {
            MarkAsChild();
            _id = dr.GetInt32("id");
            _name = dr.GetString("name");
            _isActive = dr.GetBoolean("is_active");
            
            _updateby = dr.GetString("update_by");
            dr.GetBytes("lastchanged", 0, _lastchanged, 0, 8);

            _username = Dothan.ApplicationContext.User.Identity.Name;
            
            _idSet = true;
            MarkOld(); 
        }

        internal void Insert(SqlConnection cn)
        {
            if (!this.IsDirty) return;
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "[app_admin].[type_status_insert]";
                cm.Parameters.AddWithValue("@name", _name);
                cm.Parameters.AddWithValue("@isActive", _isActive);
                cm.Parameters.Add("@newid", SqlDbType.Int).Direction = ParameterDirection.Output;
                cm.Parameters.Add("@newlastchanged", SqlDbType.Timestamp).Direction = ParameterDirection.Output;
                cm.ExecuteNonQuery();
                _id = (int)cm.Parameters["@newid"].Value;
                _lastchanged = (byte[])cm.Parameters["@newlastchanged"].Value;
                _idSet = true;
            }
            MarkOld(); 
        }
        internal void Update(SqlConnection cn)
        {
            if (!this.IsDirty) return;
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "[app_admin].[type_status_update]";
                cm.Parameters.AddWithValue("@name", _name);
                cm.Parameters.AddWithValue("@isActive", _isActive);
                cm.Parameters.AddWithValue("@id", _id);
                cm.Parameters.AddWithValue("@username", _username);
                cm.Parameters.AddWithValue("@lastchanged", _lastchanged);
                cm.Parameters.Add("@newlastchanged", SqlDbType.Timestamp).Direction = ParameterDirection.Output;
                cm.ExecuteNonQuery();
                _lastchanged = (byte[])cm.Parameters["@newlastchanged"].Value;
            }
            MarkClean();
        }
        internal void DeleteSelf(SqlConnection cn)
        {

            if (!this.IsDirty) return;


            if (this.IsNew) return;
            Delete(cn, _id, _username);
            MarkNew();
        }

        private void Delete(SqlConnection cn, int id, string username)
        {
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "[app_admin].[type_status_delete]";
                cm.Parameters.AddWithValue("@id", id);
                cm.Parameters.AddWithValue("@username", username);
                cm.ExecuteNonQuery();
            }
        }
    }
}
