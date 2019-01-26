using System;
using System.Data;
using System.Data.SqlClient;
using Dothan;
using Dothan.Data;
using Dothan.Library.Properties;

namespace Dothan.Library.bizCell
{
    [Serializable()]
    public class CellReportDetail : BusinessBase<CellReportDetail>
    {
        private int _id;
        private bool _idset;
        private int _memberid;
        private string _membername = string.Empty;
        private SmartDate _regdate = new SmartDate(false);
        private bool _attendence ;
        private int _familycode;
        private int _roleCode;
        private string _cell = string.Empty;
        private string _reason = string.Empty;
        private int _reportid;
        private string _memo = string.Empty;
        private string _sex =string.Empty;
        private int _roleLevel;

        private byte[] _lastchanged = new byte[8];
        private int _serviceTimePlaceID;
        [System.ComponentModel.DataObjectField(true, true)]
        public int ID
        {
            get
            {
                
                if (!_idset)
                {
                    _idset = true;
                    CellReportDetails parent = (CellReportDetails)this.Parent;
                    int max = 0;
                    foreach (CellReportDetail item in parent)
                    {
                        if (item.ID > max)
                            max = item.ID;
                    }
                    _id = max + 1;
                }
                return _id;
            }
        }
        public int Memberid
        {
            get
            {
                
                return _memberid;
            }
        }
        public int Reportid
        {
            get
            {
                
                return _reportid;
            }
            set
            {
                
                CanWriteProperty(true);
                if (!_reportid.Equals(value))
                {

                    _reportid = value;
                    PropertyHasChanged();
                }
            }

        }
        public int RoleCode
        {
            get
            {
            
                return _roleCode;
            }
        }
        public string Sex
        {
            get
            {
                
                return _sex;
            }
        }
        public string Cellphone
        {
            get
            {
                
                return _cell;
            }
        }

        public bool Attendence
        {
            get
            {
                
                return _attendence;
            }
            set
            {
                CanWriteProperty(true);
                if (_attendence != value)
                {
                    _attendence = value;
                    PropertyHasChanged();
                }
            }
        }
        public int Familycode
        {
            get
            {
                
                return _familycode;
            }
        }
        public string Reason
        {
            get
            {
                
                return _reason;
            }
            set
            {
                CanWriteProperty(true);
                if (value == null) value = string.Empty;
                if (_reason != value)
                {
                    _reason = value;
                    PropertyHasChanged();
                }
            }
        }
        public string Memo
        {
            get
            {
                
                return _memo;
            }
            set
            {
                CanWriteProperty(true);
                if (value == null) value = string.Empty;
                if (_memo != value)
                {
                    _memo = value;
                    PropertyHasChanged();
                }
            }
        }
        public string RegDate
        {
            get
            {
                
                return _regdate.Text;
            }
            set
            {

                CanWriteProperty(true);
                if (value == null) value = string.Empty;
                if (_regdate != value)
                {
                    _regdate.Text = value;

                    PropertyHasChanged();
                }
            }
        }
        public int RoleLevel { get { return _roleLevel; } }

        public string MemberName
        {
            get { return _membername; }
        }

        public int ServiceTimePlaceID
        {
            get
            {

                return _serviceTimePlaceID;
            }
            set
            {
                CanWriteProperty(true);
                if (_serviceTimePlaceID != value)
                {
                    _serviceTimePlaceID = value;
                    PropertyHasChanged();
                }
            }
        }

        protected override object GetIdValue()
        {
            return _id;
        }

        internal static CellReportDetail New(SafeDataReader dr)
        {
            return new CellReportDetail(dr, false);
        }
        internal static CellReportDetail Get(SafeDataReader dr)
        {
            return new CellReportDetail(dr , true);
        }
        private CellReportDetail(SafeDataReader dr, bool idSet)
        {
            MarkAsChild();
            _idset = idSet;
            FetchData(dr);
            if (idSet)
            {
                _id = dr.GetInt32("id");
                _attendence = dr.GetBoolean("Attendance");
                _memo = dr.GetString("Memo");
                _reason = dr.GetString("Reason");
                _regdate = dr.GetSmartDate("RegDate", _regdate.EmptyIsMin);
                _serviceTimePlaceID = dr.GetInt32("service_time_place_id");
                dr.GetBytes("Lastchanged", 0, _lastchanged, 0, 8); 
                MarkOld();
            }
            else
            {
                _regdate.Date = DateTime.Today;

            }
            

        }

        private void FetchData(SafeDataReader dr)
        {
            _memberid = dr.GetInt32("member_id");
            _membername = string.Format("{0}{1}", dr.GetString("last_name"), dr.GetString("first_name"));
            _roleCode = dr.GetInt32("role_code");
            _roleLevel = dr.GetInt32("role_level");
            _cell = dr.GetString("cell");
            _familycode = dr.GetInt32("family_code");
            if (dr.GetBoolean("sex"))
                _sex = Resources.sMale;
            else
                _sex = Resources.sFemale;

        }
       
        private CellReportDetail() 
        {
           
        }

        internal void Insert(SqlConnection cn , int reportid)
         {
             if (!this.IsDirty) return;
             using (SqlCommand cm = cn.CreateCommand())
             {
                 cm.CommandType = CommandType.StoredProcedure;
                 cm.CommandText = "[app_cell].[reportdetail_insert]";
                 cm.Parameters.AddWithValue("@memberid", _memberid);
                 cm.Parameters.AddWithValue("@parentid ", reportid);
                 cm.Parameters.AddWithValue("@attendance", _attendence);
                 cm.Parameters.AddWithValue("@reason", _reason);
                 cm.Parameters.AddWithValue("@memo", _memo);
                 cm.Parameters.AddWithValue("@roleCode", _roleCode);
                 cm.Parameters.AddWithValue("@roleLevel", _roleLevel);
                 cm.Parameters.AddWithValue("@serviceTimePlaceID", _serviceTimePlaceID);
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
                  cm.CommandText = "[app_cell].[reportdetail_update]";
                  cm.Parameters.AddWithValue("@id ", _id);
                 cm.Parameters.AddWithValue("@attendance", _attendence);
                 cm.Parameters.AddWithValue("@reason", _reason);
                 cm.Parameters.AddWithValue("@memo", _memo);
                 cm.Parameters.AddWithValue("@lastchanged", _lastchanged);
                 cm.Parameters.Add("@newlastchanged", SqlDbType.Timestamp).Direction = ParameterDirection.Output;
                 cm.Parameters.AddWithValue("@serviceTimePlaceID", _serviceTimePlaceID);
                 cm.ExecuteNonQuery();

                 _lastchanged = (byte[])cm.Parameters["@newlastchanged"].Value;
                 MarkOld();
                 
           
             }
         }
         internal void DeleteSelf(SqlConnection cn)
         {
             if (!this.IsDirty) return;

             if (this.IsNew) return;

             Delete(cn, _id);
             MarkNew();
         }

         internal static void Delete(SqlConnection cn, int id)
         {
             using (SqlCommand cm = cn.CreateCommand())
             {
                
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "[app_cell].[reportdetail_delete]";
                 cm.Parameters.AddWithValue("@id",id);
                 cm.ExecuteNonQuery();
             }
         }
    }
}
