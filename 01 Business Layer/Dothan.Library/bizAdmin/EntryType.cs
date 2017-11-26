﻿using System;
using System.Data;
using System.Data.SqlClient;
using Dothan;
using Dothan.Data;

namespace Dothan.Library.bizAdmin
{
    [Serializable()]
    public class EntryType : BusinessBase<EntryType>
    {
          private int _id;
        private bool _idSet;
        private string _name = string.Empty;
        private string _updateBy = string.Empty;
        private byte[] _lastchanged = new byte[8];
        private string _username = string.Empty;

        [System.ComponentModel.DataObjectField(true, true)]
        public int ID
        {
            get
            {
                if (!_idSet)
                {
                    _idSet = true;
                    EntryTypes parent = (EntryTypes)this.Parent;
                    int max = 0;
                    foreach (EntryType item in parent)
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
        public string UpdateBy { get { return _updateBy; } }


        protected override object GetIdValue()
        {
            return _id;
        }




        internal static EntryType Get(SafeDataReader dr)
        {
            return new EntryType(dr);
        }

        internal static EntryType New()
        {
            return new EntryType();
        }
        private EntryType()
        {
            MarkAsChild();
            _username = Dothan.ApplicationContext.User.Identity.Name;
        }

        private EntryType(SafeDataReader dr)
        {
            MarkAsChild();
            _idSet = true;
            _id = dr.GetInt32("id");
            _name = dr.GetString("Name");
            _updateBy = dr.GetString("update_by");
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
                cm.CommandText = "[app_admin].[type_entry_insert]";
                cm.Parameters.AddWithValue("@name", _name);
                cm.Parameters.AddWithValue("@username", _username);
                cm.Parameters.Add("@newid", SqlDbType.Int).Direction = ParameterDirection.Output;
                cm.Parameters.Add("@newlastchanged", SqlDbType.Timestamp).Direction = ParameterDirection.Output;
                cm.ExecuteNonQuery();
                _id = (int)cm.Parameters["@newid"].Value;
                _lastchanged = (byte[])cm.Parameters["@newlastchanged"].Value;
                _idSet = true;
                MarkOld();
            }
        }
        internal void Update(SqlConnection cn)
        {
            if (!this.IsDirty) return;
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "[app_admin].[type_entry_update]";
                cm.Parameters.AddWithValue("@name", _name);
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

            Delete(cn, _id,_username);
            MarkNew();
        }

        private void Delete(SqlConnection cn, int id,string username)
        {
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "[app_admin].[type_entry_delete]";
                cm.Parameters.AddWithValue("@id", id);
                cm.Parameters.AddWithValue("@username", username);
                cm.ExecuteNonQuery();
            }
        }
    }
}
