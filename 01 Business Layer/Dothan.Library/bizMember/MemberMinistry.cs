using System;
using System.Data;
using System.Data.SqlClient;
using Dothan;
using Dothan.Data;
using Dothan.Library.Properties;

namespace Dothan.Library.bizMember
{
    [Serializable()]
    public class MemberMinistry : BusinessBase<MemberMinistry>
    {

        private int _id;
        private bool _idSet;
        private int _role;
        private int _memberid;
        private int _ministrycode;
        private SmartDate _startdate;
        private SmartDate _enddate = new SmartDate(false);
        private string _updateby = string.Empty;
        private string _username = string.Empty;

        private byte[] _lastchanged = new byte[8];


        [System.ComponentModel.DataObjectField(true, true)]
        public int ID
        {

            get
            {

                if (!_idSet)
                {
                    // generate a default id value
                    _idSet = true;
                    MemberMinistrys parent = (MemberMinistrys)this.Parent;
                    int max = 0;
                    foreach (MemberMinistry item in parent)
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
                    ValidationRules.CheckRules("EndDate");
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

        protected override void AddBusinessRules()
        {
            ValidationRules.AddRule(StartDateOverToday, "EndDate");
            ValidationRules.AddRule(Dothan.Validation.CommonRules.IntegerMinValue, new Dothan.Validation.CommonRules.IntegerMinValueRuleArgs("MinistryCode", 1));
            ValidationRules.AddRule(Dothan.Validation.CommonRules.IntegerMinValue, new Dothan.Validation.CommonRules.IntegerMinValueRuleArgs("Role", 1));
            
        }
        private bool StartDateOverToday(object target, Dothan.Validation.RuleArgs e)
        {
            if (!_enddate.IsEmpty)
            {
                if (  _startdate > _enddate)
                {
                    e.Description = Dothan.Library.Properties.Resources.Date_start_end_rule;
                    return false;
                }
                else
                    return true;
            }
            else
                return true;
        }
        protected override object GetIdValue()
        {
            return _id;
        }
        internal static MemberMinistry New(int memberid)
        {
            return new MemberMinistry(memberid);
        }
        internal static MemberMinistry Get(SafeDataReader dr)
        {
            return new MemberMinistry(dr);
        }

        private MemberMinistry(int memberid) 
        {
            MarkAsChild();
            _memberid = memberid;
            _username = Dothan.ApplicationContext.User.Identity.Name;
            _startdate.Date = DateTime.Today;

            ValidationRules.CheckRules();
        }
        
        private MemberMinistry(SafeDataReader dr)
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
            _memberid = dr.GetInt32("memberid"); ;
            dr.GetBytes("lastchanged", 0, _lastchanged, 0, 8);
            
            MarkOld();
        }


        internal void Insert(SqlConnection cn)
        {
            if (!this.IsDirty) return;
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "[app_ministry].[ministry_member_insert]";
                cm.Parameters.AddWithValue("@ministryCode", _ministrycode);
                cm.Parameters.AddWithValue("@roleCode", _role);
                cm.Parameters.AddWithValue("@memberId", _memberid);
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
            ValidationRules.CheckRules();

            if (!this.IsDirty) return;

            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "[app_ministry].[ministry_member_update]";
                cm.Parameters.AddWithValue("@id", _id);
                cm.Parameters.AddWithValue("@ministryCode", _ministrycode);
                cm.Parameters.AddWithValue("@roleCode", _role);
                cm.Parameters.AddWithValue("@startDate", _startdate.DBValue);
                cm.Parameters.AddWithValue("@endDate", _startdate.DBValue);
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

            Delete(cn, _id, _username);
            MarkNew();
        }
        internal static void Delete(SqlConnection cn, int id, string username)
        {
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "[app_ministry].[ministry_member_delete]";
                cm.Parameters.AddWithValue("@id", id);
                cm.Parameters.AddWithValue("@username", username);
                cm.ExecuteNonQuery();
            }

        }
    }
}
