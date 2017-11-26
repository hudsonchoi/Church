using System;
using System.Data;
using System.Data.SqlClient;
using Dothan;
using Dothan.Data;

namespace Dothan.Library.bizCommon
{
    [Serializable()]
    public class Address :BusinessBase<Address>
    {
        public int _id;
        private string _address = string.Empty;
        private string _city = string.Empty;
        private string _statecode = string.Empty;
        private string _zipcode = string.Empty;
        private string _home = string.Empty;
        private byte[] _lastchanged = new byte[8];

        [System.ComponentModel.DataObjectField(true, true)]
        public int ID
        {
            get
            {
                return _id;
            }
        }
        public string Street
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
                
                return _statecode;
            }
            set
            {
                CanWriteProperty(true);
                if (value == null) value = string.Empty;
                if (_statecode != value)
                {
                    _statecode = value;
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
        public string Home
        {
            get
            {
                
                return _home;
            }
            set
            {
                CanWriteProperty(true);
                if (value == null) value = string.Empty;
                if (_home != value)
                {
                    _home = value;
                    PropertyHasChanged();
                }
            }
        }
        public string UserName { get; set; }

        public static bool CanAddObject()
        {
            return true;
        }

        public static bool CanGetObject()
        {
            return true;
        }

        public static bool CanDeleteObject()
        {
            return true;
        }

        public static bool CanEditObject()
        {
            return true;
        }

        public static Address New()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a address");
            return DataPortal.Create<Address>();
        }
        public static Address Get(int id)
        {
            return DataPortal.Fetch<Address>(new Criteria(id));
        }
        public override Address Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a resource");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a resource");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a resource");
            return base.Save();

        }

        private Address() { }

        protected override object GetIdValue()
        {
            return _id;
        }

        [Serializable()]
        private class Criteria
        {
            private int _ID;
            public int ID
            {
                get { return _ID; }
            }

            public Criteria(int id)
            { _ID = id; }
        }

        private void DataPortal_Create(Criteria criteria)
        {
            // nothing to initialize
        }
        
        private void DataPortal_Fetch(Criteria criteria)
        {
            using (SqlConnection cn = new SqlConnection(Database.ConnectionString))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "[app_common].[address_get]";
                    cm.Parameters.AddWithValue("@id", criteria.ID);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        dr.Read();
                        _id = dr.GetInt32("id");
                        _address = dr.GetString("address");
                        _city = dr.GetString("city");
                        _statecode = dr.GetString("statecode");
                        _zipcode = dr.GetString("zipcode");
                        _home = dr.GetString("home");
                        dr.GetBytes("lastchanged", 0, _lastchanged, 0, 8);
                    }
                }
            }
        }

        [Transactional(TransactionalTypes.TransactionScope)]
        protected override void DataPortal_Insert()
        {
            using (SqlConnection cn = new SqlConnection(Database.ConnectionString))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandText = "[app_common].[address_insert]";
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.Parameters.AddWithValue("@address", _address);
                    cm.Parameters.AddWithValue("@city", _city);
                    cm.Parameters.AddWithValue("@statecode", _statecode);
                    cm.Parameters.AddWithValue("@zipcode", _zipcode);
                    cm.Parameters.AddWithValue("@home", _home);
                    cm.Parameters.AddWithValue("@username", UserName);
                    cm.Parameters.Add("@newid",SqlDbType.Int).Direction = ParameterDirection.Output;
                    cm.Parameters.Add("@newlastchanged", SqlDbType.Timestamp).Direction = ParameterDirection.Output;
                    cm.ExecuteNonQuery();

                    _id = (int)cm.Parameters["@newid"].Value;
                    _lastchanged = (byte[])cm.Parameters["@newlastchanged"].Value;
                }
            }
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
                    cm.CommandText = "[app_common].[address_update]";
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.Parameters.AddWithValue("@address", _address);
                    cm.Parameters.AddWithValue("@city", _city);
                    cm.Parameters.AddWithValue("@statecode", _statecode);
                    cm.Parameters.AddWithValue("@zipcode", _zipcode);
                    cm.Parameters.AddWithValue("@home", _home);
                    cm.Parameters.AddWithValue("@lastchanged", _lastchanged);
                    cm.Parameters.AddWithValue("@username", UserName);
                    cm.Parameters.AddWithValue("@id", _id);
                    cm.Parameters.Add("@newlastchanged", SqlDbType.Timestamp).Direction = ParameterDirection.Output;

                    cm.ExecuteNonQuery();

                    _lastchanged = (byte[])cm.Parameters["@newlastchanged"].Value;
                }
            }
            }
        }
    }
}
