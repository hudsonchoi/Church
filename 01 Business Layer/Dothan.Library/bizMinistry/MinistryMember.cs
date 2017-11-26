using System;
using System.Data;
using System.Data.SqlClient;
using Dothan;
using Dothan.Data;
using Dothan.Library.Properties;

namespace Dothan.Library.bizMinistry
{

    [Serializable()]
    public class MinistryMember : BusinessBase<MinistryMember>
    {
        private int _id;
        private bool _idSet;
        private int _role;
        private int _ministrycode;
        private SmartDate _startdate;
        private SmartDate _enddate = new SmartDate(false);
        private string _updateby = string.Empty;
        private string _username = string.Empty;

        private byte[] _lastchanged = new byte[8];

        private MemberInfoBase _info = new MemberInfoBase();


        [System.ComponentModel.DataObjectField(true, true)]
        public int ID
        {

            get
            {
              
                if (!_idSet)
                {
                    // generate a default id value
                    _idSet = true;
                    MinistryMembers parent = (MinistryMembers)this.Parent;
                    int max = 0;
                    foreach (MinistryMember item in parent)
                    {
                        if (item.ID > max)
                            max = item.ID;
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
                    _idSet = true;
                    _id = value;
                    PropertyHasChanged();
                }
            }
        }
        public int MinistryCode
        {
            get
            {
                return _ministrycode;
            }
            set
            {
                CanWriteProperty(true);
                if (!_ministrycode.Equals(value))
                {
                    _ministrycode = value;
                    PropertyHasChanged();
                }
            }
        }
        public string StartDate
        {
            get
            {

                return _startdate.Text;
            }
            set
            {
                CanWriteProperty(true);
                if (!_startdate.Text.Equals(value))
                {
                    _startdate.Text = value;
                    PropertyHasChanged();
                }
            }
        }
        public string EndDate
        {
            get
            {
                return _enddate.Text;
            }
            set
            {
                CanWriteProperty(true);
                if (!_enddate.Text.Equals(value))
                {
                    _enddate.Text = value;
                    PropertyHasChanged();
                }
            }
        }
        public int Role
        {
            get
            {
              
                return _role;
            }
            set
            {
                CanWriteProperty(true);
                if (!_role.Equals(value))
                {
                    _role = value;
                    PropertyHasChanged();
                }
            }
        }
        
        // Memberninfo
        public int MemberId { get { return _info.MemberId; } }
        public string Ko_Name { get { return _info.Ko_Name; } }
        public string En_Name { get { return _info.En_Name; } }
        public string Email { get { return _info.Email; } }
        public string Address { get { return _info.Address; } }
        public string City { get { return _info.City; } }
        public string State { get { return _info.State; } }
        public string Zipcode { get { return _info.Zipcode; } }
        public string Home { get { return _info.Home; } }
        public string Cell { get { return _info.Cell; } }
        public string Sex { get { return _info.Sex; } }
        public string Married { get { return _info.Married; } }
        public int Age { get { return _info.Age; } }
        public string BirthDay { get { return _info.BirthDay; } }
        public string Spouse { get { return _info.Spouse; } }
        public string FamilyName { get { return _info.FamilyName; } }
        public int FamilyCode { get { return _info.FamilyCode; } }
        public string RelationShip { get { return _info.RelationShip; } }
        public string RegDate { get { return _info.RegDate; } }
        public string Baptism { get { return _info.Baptism; } }
        public string Baptism_year { get { return _info.Baptism_year; } }
        public string SubDivision { get { return _info.SubDivision; } }
        public string Job { get { return _info.Job; } }
        public string CellName { get { return _info.CellName; } }
        public int SpouseID { get { return _info.SpouseID; } }
        public string Active { get { return _info.Active; } }
        public int StatusCode { get { return _info.StatusCode; } }


        protected override object GetIdValue()
        {
            return _id;
        }


        internal static MinistryMember New(Dothan.Library.bizMember.MemberInfo info, int ministryid, string startdate,int roles)
        {
            return new MinistryMember(info, ministryid, startdate, roles);
        }

        internal static MinistryMember Get(SafeDataReader dr)
        {
            return new MinistryMember(dr);
        }
            
        private MinistryMember()
        {
            MarkAsChild();
        }

        private MinistryMember(SafeDataReader dr)
        {
            MarkAsChild();
            _id = dr.GetInt32("id");
            _idSet = true;
            _startdate = dr.GetSmartDate("startdate");
            _enddate = dr.GetSmartDate("enddate");
            _ministrycode = dr.GetInt32("ministry_code");
            _role = dr.GetInt32("role_code");
            _updateby = dr.GetString("update_by");
            _username = Dothan.ApplicationContext.User.Identity.Name;
            _info = MemberInfoBase.Get(dr);
            dr.GetBytes("lastchanged", 0, _lastchanged, 0, 8);
   
            MarkOld();
        }
        private MinistryMember(Dothan.Library.bizMember.MemberInfo info, int ministrycode, string startdate, int roles)
        {
            MarkAsChild();
    
            _ministrycode = ministrycode;
            _startdate.Text = startdate;
            _role = roles;
            _info = MemberInfoBase.Get(info);
            _username = Dothan.ApplicationContext.User.Identity.Name;
           
        }



        internal void Insert(SqlConnection cn)
        {
            if (!this.IsDirty) return;
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "[app_ministry].[ministry_member_insert]";
                cm.Parameters.AddWithValue("@ministryCode",_ministrycode);
                cm.Parameters.AddWithValue("@roleCode", _role);
                cm.Parameters.AddWithValue("@memberId",_info.MemberId);
                cm.Parameters.AddWithValue("@startDate", _startdate.DBValue);
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
                cm.CommandText = "[app_ministry].[ministry_member_update]";
                cm.Parameters.AddWithValue("@id", _id);
                cm.Parameters.AddWithValue("@ministryCode", _ministrycode);
                cm.Parameters.AddWithValue("@roleCode", _role);
                cm.Parameters.AddWithValue("@startDate", _startdate.DBValue);
                cm.Parameters.AddWithValue("@endDate", _enddate.DBValue);
                cm.Parameters.AddWithValue("@username", _username);
                cm.Parameters.AddWithValue("@lastchanged", _lastchanged);
                cm.Parameters.Add("@newlastchanged", SqlDbType.Timestamp).Direction = ParameterDirection.Output;
                cm.ExecuteNonQuery();
                _lastchanged = (byte[])cm.Parameters["@newlastchanged"].Value;

                this.MarkClean();
            }

        }
        internal void DeleteSelf(SqlConnection cn)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            // if we're new then don't update the database
            if (this.IsNew) return;

            Delete(cn, _id  , _username);
            MarkNew();
        }
        internal static void Delete(SqlConnection cn, int id, string username)
        {
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "D[app_ministry].[ministry_member_delete]";
                cm.Parameters.AddWithValue("@id", id);
                cm.Parameters.AddWithValue("@username", username);
                cm.ExecuteNonQuery();
            }

        }
    }
}
