using System;
using System.Data;
using System.Data.SqlClient;
using Dothan;
using Dothan.Data;

namespace Dothan.Library.bizCell
{
    [Serializable()]
    public class CellRole : BusinessBase<CellRole>
    {
        private bool _idSet;
        private int _code;
        private string _name = string.Empty;
        private int _level;
        private bool _multipleAssign = true;
        private bool _default = false;
        private string _username = string.Empty;
        private string _updateBy = string.Empty;

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
                    CellRoles parent = (CellRoles)this.Parent;
                    int max = 0;
                    foreach (CellRole item in parent)
                    {
                        if (item.Code > max)
                            max = item.Code;
                    }
                    _code = max + 1;
                }
                return _code;
            }
        }
        public int Level
        {

            get
            {
                CellRoles parent = (CellRoles)this.Parent;
                if (!_level.Equals(parent.IndexOf(this) + 1))
                {
                    _level = parent.IndexOf(this) + 1;
                    PropertyHasChanged();
                }
                return _level;
            }

        }

        public bool Default
        {
            get
            {
                
                return _default;
            }
            set
            {
                CanWriteProperty(true);
                if (_default != value)
                {
                    _default = value;
                    if (_default)
                        ((CellRoles)this.Parent).SetDefault(_code);

                    PropertyHasChanged();
                }
            }
        }
        public string Name
        {
            get { return _name; }
            set
            {
                if (value == null) value = string.Empty;
                if (_name != value)
                {
                    _name = value;
                    PropertyHasChanged();
                }
            }
        }
        public bool MultipleAssign
        {
            get
            {
                
                return _multipleAssign;
            }
            set
            {
                CanWriteProperty(true);
                if (_multipleAssign != value)
                {
                    _multipleAssign = value;
                    PropertyHasChanged();
                }
            }
        }
        public string UpdateBy
        {
            get
            {
                return _updateBy;
            }
        }

        protected override void AddBusinessRules()
        {
            ValidationRules.AddRule(Dothan.Validation.CommonRules.StringRequired, "Name");
        }

        private bool NoDuplicates(object target, Dothan.Validation.RuleArgs e)
        {
            CellRoles parent = (CellRoles)this.Parent;
            foreach (CellRole item in parent)
                if (item.Name== _name && !ReferenceEquals(item, this))
                {
                    e.Description = "Role Name must be unique";
                    return false;
                }
            return true;
        }
        protected override object GetIdValue()
        {
            return _code;
        }

        internal static CellRole New()
        {
            return new CellRole();
        }

        internal static CellRole Get(SafeDataReader dr)
        {
            return new CellRole(dr);

        }
        private CellRole() 
        {
            _username = Dothan.ApplicationContext.User.Identity.Name;
            MarkAsChild(); 
        }
        
        private CellRole(SafeDataReader dr)
        {
            MarkAsChild();
            _idSet = true;
            _code = dr.GetInt32("code");
            _name = dr.GetString("name");
            _multipleAssign = dr.GetBoolean("multiple_assign");
            _level = dr.GetInt32("levels");
            _default = dr.GetBoolean("default_level");
            _updateBy = dr.GetString("update_by");
            _username = Dothan.ApplicationContext.User.Identity.Name;

            dr.GetBytes("lastchanged", 0, _lastchanged, 0, 8);
            MarkOld(); 
        }

        internal void Insert(SqlConnection cn)
        {
            if (!this.IsDirty) return;
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "[app_cell].[cell_role_insert]";
                cm.Parameters.AddWithValue("@name", _name);
                cm.Parameters.AddWithValue("@multipleAssign", _multipleAssign);
                cm.Parameters.AddWithValue("@level", _level);
                cm.Parameters.AddWithValue("@default", _default);
                cm.Parameters.AddWithValue("@username", _username);
                cm.Parameters.Add("@newid", SqlDbType.Int).Direction = ParameterDirection.Output;
                cm.Parameters.Add("@newlastchanged", SqlDbType.Timestamp).Direction = ParameterDirection.Output;
                cm.ExecuteNonQuery();
                _code = (int)cm.Parameters["@newid"].Value;
                _lastchanged = (byte[])cm.Parameters["@newlastchanged"].Value;
                this.MarkOld();
            }
        }
        internal void Update(SqlConnection cn)
        {
            if (!this.IsDirty) return;
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "[app_cell].[cell_role_update]";
                cm.Parameters.AddWithValue("@name", _name);
                cm.Parameters.AddWithValue("@multipleAssign", _multipleAssign);
                cm.Parameters.AddWithValue("@level", _level);
                cm.Parameters.AddWithValue("@default", _default);
                cm.Parameters.AddWithValue("@username", _username);
                cm.Parameters.AddWithValue("@id", _code);
                cm.Parameters.AddWithValue("@lastchanged", _lastchanged);
                cm.Parameters.Add("@newlastchanged", SqlDbType.Timestamp).Direction = ParameterDirection.Output;
                cm.ExecuteNonQuery();
                _lastchanged = (byte[])cm.Parameters["@newlastchanged"].Value;
  
                cm.ExecuteNonQuery();
                this.MarkClean();
            }
        }
    
        internal void DeleteSelf(SqlConnection cn)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            // if we're new then don't update the database
            if (this.IsNew) return;

            DeleteRole(cn, _code,_username);
            MarkNew();
        }

        internal static void DeleteRole(SqlConnection cn, int id , string username)
        {
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "[app_cell].[cell_role_delete]";
                cm.Parameters.AddWithValue("@id", id);
                cm.Parameters.AddWithValue("@username", id);
                cm.ExecuteNonQuery();
            }
        }
    }
}
