using System;
using System.Data;
using System.Data.SqlClient;
using Dothan;
using Dothan.Data;
using Dothan.Library.Properties;

namespace Dothan.Library.bizMember
{
    [Serializable()]
    public class MemberFellowship : BusinessBase<MemberFellowship>
    {
        private int _id;
        private string _fellowship = string.Empty;
        private SmartDate _startdate = new SmartDate(false);
        private SmartDate _enddate = new SmartDate(false);

        private string _username = string.Empty;
        private byte[] _lastchanged = new byte[8];

        public int ID
        {
            get
            {
                return _id;
            }

        }
        public string Fellowship { get { return _fellowship; } }

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

        protected override object GetIdValue()
        {
            return _id;
        }
        private MemberFellowship() { }

        internal MemberFellowship(SafeDataReader dr)
        {
            MarkAsChild();
            _id = dr.GetInt32("id");
            _fellowship = dr.GetString("fellowship");
            _enddate = dr.GetSmartDate("enddate", _enddate.EmptyIsMin);
            _startdate = dr.GetSmartDate("startdate", _startdate.EmptyIsMin);
            dr.GetBytes("lastchanged", 0, _lastchanged, 0, 8);

            _username = Dothan.ApplicationContext.User.Identity.Name;
            MarkOld();
        }


        //  internal void Insert(SqlConnection cn)
        //{
        //    if (!this.IsDirty) return;
        //    using (SqlCommand cm = cn.CreateCommand())
        //    {
        //        cm.CommandType = CommandType.StoredProcedure;
        //        cm.CommandText = "[app_ministry].[ministry_member_insert]";
        //        cm.Parameters.AddWithValue("@ministryCode", _ministrycode);
        //        cm.Parameters.AddWithValue("@roleCode", _role);
        //        cm.Parameters.AddWithValue("@memberId", _memberid);
        //        cm.Parameters.AddWithValue("@startDate", _startdate.DBValue);
        //        cm.Parameters.AddWithValue("@username", _username);
        //        cm.Parameters.Add("@newid", SqlDbType.Int).Direction = ParameterDirection.Output;
        //        cm.Parameters.Add("@newlastchanged", SqlDbType.Timestamp).Direction = ParameterDirection.Output;
        //        cm.ExecuteNonQuery();
        //        _id = (int)cm.Parameters["@newid"].Value;
        //        _lastchanged = (byte[])cm.Parameters["@newlastchanged"].Value;
        //        _idSet = true;
        //        MarkOld();
        //    }
        //}

        internal void Update(SqlConnection cn)
        {
            ValidationRules.CheckRules();

            if (!this.IsDirty) return;

            using (SqlCommand cm = cn.CreateCommand())
            {
                
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "[app_fellowship].[fellowship_member_update]";
                    cm.Parameters.AddWithValue("@id", _id);
                    cm.Parameters.AddWithValue("@startdate", _startdate.DBValue);
                    cm.Parameters.AddWithValue("@enddate", _enddate.DBValue);
                    cm.Parameters.AddWithValue("@lastchanged", _lastchanged);
                    cm.Parameters.AddWithValue("@username", _username);
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
                //cm.CommandType = CommandType.StoredProcedure;
                //cm.CommandText = "D[app_member].[ministry_member_delete]";
                //cm.Parameters.AddWithValue("@id", id);
                //cm.Parameters.AddWithValue("@username", username);
                //cm.ExecuteNonQuery();
            }

        }
    }
    
}
