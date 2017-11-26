using System;
using System.Data;
using System.Data.SqlClient;
using Dothan;
using Dothan.Data;

namespace Dothan.Library.bizAdmin
{
    [Serializable()]
    public class ChurchInfo : BusinessBase<ChurchInfo>
    {
        #region Business Methods

        private int _id;
        private string _name = string.Empty;
        private string _address = string.Empty;
        private string _address2 = string.Empty;
        private string _city = string.Empty;
        private string _state = string.Empty;
        private string _zipcode = string.Empty;
        private string _telephone = string.Empty;
        private string _signer = string.Empty;
        private string _taxid = string.Empty;
        private string _fax = string.Empty;
        private string _updateby = string.Empty;
        private string _username = string.Empty;


        private byte[] _lastchanged = new byte[8];

        [System.ComponentModel.DataObjectField(true, true)]
        public int Id
        {
            get
            {
                return _id;
            }
        }
        public string ChurchName
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
        public string Address
        {
            get
            {
                return _address;
            }
            set
            {
                CanWriteProperty(true);
                if (value == null) value = string.Empty;
                if (_address != value)
                {
                    _address = value;
                    PropertyHasChanged();
                }
            }
        }
        public string Address2
        {
            get
            {
                return _address2;
            }
            set
            {
                CanWriteProperty(true);
                if (_address2 != value)
                {
                    _address2 = value;
                    PropertyHasChanged();
                }
            }
        }
        public string City
        {
            get
            {
                return _city;
            }
            set
            {
                CanWriteProperty(true);
                if (value == null) value = string.Empty;
                if (_city != value)
                {
                    _city = value;
                    PropertyHasChanged();
                }
            }
        }
        public string State
        {
            get
            {
                return _state;
            }
            set
            {
                CanWriteProperty(true);
                if (value == null) value = string.Empty;
                if (_state != value)
                {
                    _state = value;
                    PropertyHasChanged();
                }
            }
        }
        public string Zipcode
        {
            get
            {
                return _zipcode;
            }
            set
            {
                CanWriteProperty(true);
                if (value == null) value = string.Empty;
                if (_zipcode != value)
                {
                    _zipcode = value;
                    PropertyHasChanged();
                }
            }
        }
        public string Telephone
        {
            get
            {
                return _telephone;
            }
            set
            {
                CanWriteProperty(true);
                if (_telephone != value)
                {
                    _telephone = value;
                    PropertyHasChanged();
                }
            }
        }
        public string TaxID
        {
            get
            {
                return _taxid;
            }
            set
            {
                CanWriteProperty(true);
                if (_taxid != value)
                {
                    _taxid = value;
                    PropertyHasChanged();
                }
            }
        }
        public string Signer
        {
            get
            {
                return _signer;
            }
            set
            {
                CanWriteProperty(true);
                if (_signer != value)
                {
                    _signer = value;
                    PropertyHasChanged();
                }
            }
        }
        public string Fax
        {
            get
            {
                return _fax;
            }
            set
            {
                CanWriteProperty(true);
                if (_fax != value)
                {
                    _fax = value;
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

        public override bool IsValid
        {
            get { return base.IsValid; }
        }

        public override bool IsDirty
        {
            get { return base.IsDirty; }
        }

        protected override object GetIdValue()
        {
            return _id;
        }

        #endregion

        #region Authorization Rules


        protected override void AddAuthorizationRules()
        {
            // add AuthorizationRules here
        }

        public static bool CanAddObject()
        {
            bool result =false;
            if (Dothan.ApplicationContext.User.IsInRole("SysAdmin") )
                result = true;
            return result;
        }

        public static bool CanGetObject()
        {
           return true;
        }

        public static bool CanDeleteObject()
        {
            bool result = false;
            if (Dothan.ApplicationContext.User.IsInRole("SysAdmin") || Dothan.ApplicationContext.User.IsInRole("DonateAdmin"))
                result = true;
            return result;
        }

        public static bool CanEditObject()
        {
            bool result = false;
            if (Dothan.ApplicationContext.User.IsInRole("SysAdmin") || Dothan.ApplicationContext.User.IsInRole("DonateAdmin"))
                result = true;
            return result;
        }
        public static ChurchInfo Get()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("Us not authorized to view a ChurchInfo");
            return DataPortal.Fetch<ChurchInfo>(new Criteria());
        }


        public override ChurchInfo Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a ChurchInfo");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a ChurchInfo");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a ChurchInfo");
            return base.Save();
        }

        #endregion

        #region Data Access

        [Serializable()]
        private class Criteria{ }
       
        private void DataPortal_Fetch(Criteria criteria)
        {
            using (SqlConnection cn = new SqlConnection(Database.ConnectionString))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "[app_admin].[church_get]";
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        dr.Read();
                        _id = dr.GetInt32("id");
                        _name = dr.GetString("name");
                        _address = dr.GetString("address1");
                        _address2 = dr.GetString("address2");
                        _city = dr.GetString("city");
                        _state = dr.GetString("state");
                        _zipcode = dr.GetString("zipcode");
                        _telephone = dr.GetString("telephone");
                        _taxid = dr.GetString("tax_id");
                        _signer = dr.GetString("signer");
                        _fax = dr.GetString("fax");
                        _updateby = dr.GetString("update_by");
                        _username = Dothan.ApplicationContext.User.Identity.Name;
                        dr.GetBytes("lastchanged", 0, _lastchanged, 0, 8);

                        MarkOld();
                    }
                }
            }
        }

        [Transactional(TransactionalTypes.TransactionScope)]
        protected override void DataPortal_Insert()
        {
            // Not Implement
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
                        cm.CommandText = "[app_admin].[church_update]";
                        cm.Parameters.AddWithValue("@id", _id);
                        cm.Parameters.AddWithValue("@name", _name);
                        cm.Parameters.AddWithValue("@address", _address);
                        cm.Parameters.AddWithValue("@address2", _address2);
                        cm.Parameters.AddWithValue("@city", _city);
                        cm.Parameters.AddWithValue("@state", _state);
                        cm.Parameters.AddWithValue("@zipcode", _zipcode);
                        cm.Parameters.AddWithValue("@telephone", _telephone);
                        cm.Parameters.AddWithValue("@fax", _fax);
                        cm.Parameters.AddWithValue("@signer", _signer);
                        cm.Parameters.AddWithValue("@taxid", _taxid);
                        cm.Parameters.AddWithValue("@username", _username);
                        cm.Parameters.AddWithValue("@lastchanged", _lastchanged);
                        cm.Parameters.Add("@newlastchanged", SqlDbType.Timestamp).Direction = ParameterDirection.Output;
                        cm.ExecuteNonQuery();

                        _lastchanged = (byte[])cm.Parameters["@newlastchanged"].Value;
                        MarkClean();
                    }
                }
            }
        }

        #endregion
    }
}
