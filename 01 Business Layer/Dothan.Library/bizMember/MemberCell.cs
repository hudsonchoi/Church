using System;
using System.Data;
using System.Data.SqlClient;
using Dothan;
using Dothan.Data;
using Dothan.Library.Properties;

namespace Dothan.Library.bizMember
{
    [Serializable()]
    public class MemberCell : BusinessBase<MemberCell>
    {
        private int _id;
        private int _role;
        private string _cellname = string.Empty;
        private string _rolename = string.Empty;
        private SmartDate _startdate = new SmartDate(false);
        private SmartDate _enddate = new SmartDate(false);


        private string _username = string.Empty;
        private byte[] _lastchanged = new byte[8];

        public int ID { get { return _id; } }
        public string CellName { get { return _cellname; } }
        public string RoleName { get { return _rolename; } }
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
        private MemberCell() { }

        internal MemberCell(SafeDataReader dr)
        {
            MarkAsChild();
            _id = dr.GetInt32("id");
             _role = dr.GetInt32("role_code");
            _cellname = dr.GetString("cellname");
            _enddate = dr.GetSmartDate("enddate", _enddate.EmptyIsMin);
            _startdate = dr.GetSmartDate("startdate", _startdate.EmptyIsMin);
            _rolename = dr.GetString("rolename");
            
            _username = Dothan.ApplicationContext.User.Identity.Name;
            dr.GetBytes("lastchanged", 0, _lastchanged, 0, 8);


            MarkOld();

        }
          internal void Update(SqlConnection cn)
        {
            ValidationRules.CheckRules();

            if (!this.IsDirty) return;

            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "[app_cell].[cell_member_update]";
                cm.Parameters.AddWithValue("@id", _id);
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

            Delete(cn, _id, _username);
            MarkNew();
        }
        internal static void Delete(SqlConnection cn, int id, string username)
        {
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                //cm.CommandText = "D[app_member].[ministry_member_delete]";
                //cm.Parameters.AddWithValue("@id", id);
                //cm.Parameters.AddWithValue("@username", username);
                //cm.ExecuteNonQuery();
            }

        }
    }
}
