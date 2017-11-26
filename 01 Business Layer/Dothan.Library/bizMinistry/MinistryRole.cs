using System;
using System.Data;
using System.Data.SqlClient;
using Dothan;
using Dothan.Data;

namespace Dothan.Library.bizMinistry
{
    [Serializable()]
    public class MinistryRole : BusinessBase<MinistryRole>
    {
        private bool _idSet;
        private int _code;
        private string _name = string.Empty;
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
                    MinistryRoles parent = (MinistryRoles)this.Parent;
                    int max = 0;
                    foreach (MinistryRole item in parent)
                    {
                        if (item.Code > max)
                            max = item.Code;
                    }
                    _code = max + 1;
                }
                return _code;
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
                        ((MinistryRoles)this.Parent).SetDefault(_code);

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
            MinistryRoles parent = (MinistryRoles)this.Parent;
            foreach (MinistryRole item in parent)
                if (item.Name == _name && !ReferenceEquals(item, this))
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

        internal static MinistryRole New()
        {
            return new MinistryRole();
        }

        internal static MinistryRole Get(SafeDataReader dr)
        {
            return new MinistryRole(dr);

        }
        private MinistryRole()
        {
            _username = Dothan.ApplicationContext.User.Identity.Name;
            MarkAsChild();
        }

        private MinistryRole(SafeDataReader dr)
        {
            MarkAsChild();
            _idSet = true;
            _code = dr.GetInt32("code");
            _name = dr.GetString("name");
            _default = dr.GetBoolean("isdefault");
            _updateBy = dr.GetString("create_by");
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
                cm.CommandText = "[app_ministry].[ministry_role_insert]";
                cm.Parameters.AddWithValue("@name", _name);
                cm.Parameters.AddWithValue("@isDefault", _default);
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
                cm.CommandText = "[app_ministry].[ministry_role_update]";
                cm.Parameters.AddWithValue("@name", _name);

                cm.Parameters.AddWithValue("@isDefault", _default);
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

            DeleteRole(cn, _code, _username);
            MarkNew();
        }

        internal static void DeleteRole(SqlConnection cn, int id, string username)
        {
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "[app_ministry].[ministry_role_delete]";
                cm.Parameters.AddWithValue("@id", id);
                cm.Parameters.AddWithValue("@username", username);
                cm.ExecuteNonQuery();
            }
        }
    }
}
