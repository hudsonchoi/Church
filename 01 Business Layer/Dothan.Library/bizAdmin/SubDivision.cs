using System;
using System.Data;
using System.Data.SqlClient;
using Dothan;
using Dothan.Data;

namespace Dothan.Library.bizAdmin
{
    [Serializable()]
    public class SubDivision : BusinessBase<SubDivision>
    {
        private int _id;
        private bool _idSet;
        private string _name = string.Empty;
        private int _parentId;
        private string _updateBy = string.Empty ;
        private string _username = string.Empty;
        private SmartDate _updateDate = new SmartDate(false);
        private byte[] _lastchanged = new byte[8];

        [System.ComponentModel.DataObjectField(true, true)]
        public int Id
        {
            get
            {
                
                if (!_idSet)
                {
                    // generate a default id value
                    _idSet = true;
                    SubDivisions parent = (SubDivisions)this.Parent;
                    int max = 0;
                    foreach (SubDivision item in parent)
                    {
                        if (item.Id > max)
                            max = item.Id;
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
        public int ParentId
        {
            get
            {
                
                return _parentId;
            }
            set
            {
                CanWriteProperty(true);
                if (!_parentId.Equals(value))
                {
                    _parentId = value;
                    PropertyHasChanged();
                }
            }
        }
        public string UpdateBy { get { return _updateBy; } }

        protected override object GetIdValue()
        {
            return _id;
        }

        internal static SubDivision Get(SafeDataReader dr)
        {
            return new SubDivision(dr);
        }

        internal static SubDivision New()
        {
            return new SubDivision();
        }

        private SubDivision() 
        {

            _username = Dothan.ApplicationContext.User.Identity.Name; 
            MarkAsChild(); 
        }
        private SubDivision(SafeDataReader dr)
        {
            MarkAsChild();
            _id = dr.GetInt32("id");
            _name = dr.GetString("name");
            _parentId = dr.GetInt32("parent_id");
            _username = Dothan.ApplicationContext.User.Identity.Name; 
            _updateBy = dr.GetString("update_by");
            dr.GetBytes("lastchanged", 0, _lastchanged, 0, 8);
            MarkOld(); 
        }
        internal void Insert(SqlConnection cn)
        {
            if (!this.IsDirty) return;
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "[app_admin].[sub_division_insert]";
                cm.Parameters.AddWithValue("@name", _name);
                cm.Parameters.AddWithValue("@parentid", _parentId);
                cm.Parameters.AddWithValue("@userName" , _username);
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
                cm.CommandText = "[app_admin].[sub_division_update]";
                cm.Parameters.AddWithValue("@id", _id);
                cm.Parameters.AddWithValue("@name", _name);
                cm.Parameters.AddWithValue("@parentid", _parentId);
                cm.Parameters.AddWithValue("@lastchanged", _lastchanged);
                cm.Parameters.AddWithValue("@userName", _username);
                cm.Parameters.Add("@newlastchanged", SqlDbType.Timestamp).Direction = ParameterDirection.Output;
                cm.ExecuteNonQuery();
                _lastchanged = (byte[])cm.Parameters["@newlastchanged"].Value;
            }
            MarkClean();
            MarkOld(); 
        }
        internal void DeleteSelf(SqlConnection cn)
        {
            
            if (!this.IsDirty) return;

           
            if (this.IsNew) return;

            Delete(cn, _id, _username);
            MarkNew();
        }

        internal static void Delete(SqlConnection cn, int id, string username)
        {
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "[app_admin].[sub_division_delete]";
                cm.Parameters.AddWithValue("@id", id);
                cm.Parameters.AddWithValue("@userName", username);
                cm.ExecuteNonQuery();
            }
        }
    }
}
