using System;
using System.Data;
using System.Data.SqlClient;
using Dothan;
using Dothan.Data;
using Dothan.Library.Properties;

namespace Dothan.Library.bizMember
{
    [Serializable()]
    public class MemberCourse : BusinessBase<MemberCourse>
    {
        private int _id;
        private bool _idSet;
        private int _courseid;
        private int _memberid;
        private SmartDate _graduate = new SmartDate(false);
        private string _username = string.Empty;
        private byte[] _lastchanged = new byte[8];


        [System.ComponentModel.DataObjectField(true, true)]
        public int ID
        {

            get
            {
              
                if (!_idSet)
                {
                  
                    _idSet = true;
                    MemberCourses parent = (MemberCourses)this.Parent;
                    int max = 0;
                    foreach (MemberCourse item in parent)
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

        public int CourseId
        {
            get
            {
              
                return _courseid;
            }
            set
            {
                CanWriteProperty(true);
                if (value == 0) return;
                if (!_courseid.Equals(value))
                {
                    _courseid = value;
                    PropertyHasChanged();
                }
            }
        }


        public string Graduate
        {
            get
            {
                return _graduate.Text;
            }
            set
            {
                CanWriteProperty(true);
                if (string.IsNullOrEmpty(value)) return;
                if (!_graduate.Equals(value))
                {
                    _graduate.Text = value;
                    PropertyHasChanged();
                }
            }
        }


        protected override void AddBusinessRules()
        {
            ValidationRules.AddRule(Dothan.Validation.CommonRules.IntegerMinValue, new Dothan.Validation.CommonRules.IntegerMinValueRuleArgs("CourseId" , 1));
        }

       
    
        protected override object GetIdValue()
        {
            return _id;
        }

        internal static MemberCourse New(int memberid)
        {
            return new MemberCourse(memberid);
        }
        private MemberCourse() { MarkAsChild(); }
        private MemberCourse(int memberid) 
        {
            _memberid = memberid;
            _graduate.Date = DateTime.Today;

            _username = Dothan.ApplicationContext.User.Identity.Name;
            ValidationRules.CheckRules();
            MarkAsChild(); 
        
        }
        internal static MemberCourse Get(SafeDataReader dr)
        {
            return new MemberCourse(dr);
        }

        private MemberCourse(SafeDataReader dr)
        {
            MarkAsChild();
            _id = dr.GetInt32("id");
            _idSet = true;
            _courseid = dr.GetInt32("course_code");
            _graduate = dr.GetSmartDate("graduated", _graduate.EmptyIsMin);
            _memberid = dr.GetInt32("memberid");

            dr.GetBytes("lastchanged", 0, _lastchanged, 0, 8);

            _username = Dothan.ApplicationContext.User.Identity.Name;
            MarkOld();
        }

        internal void Insert(SqlConnection cn)
        {
            if (!this.IsDirty) return;

            if (_courseid == 0) return;
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "[app_course].[course_member_insert]";
                cm.Parameters.AddWithValue("@courseid", _courseid);
                cm.Parameters.AddWithValue("@memberid", _memberid);
                cm.Parameters.AddWithValue("@graduate", _graduate.DBValue);
                cm.Parameters.AddWithValue("@username", _username);
                cm.Parameters.Add("@newid", SqlDbType.Int).Direction = ParameterDirection.Output;
                cm.Parameters.Add("@newlastchanged", SqlDbType.Timestamp).Direction = ParameterDirection.Output;
                cm.ExecuteNonQuery();
                _id = (int)cm.Parameters["@newid"].Value;

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
                cm.CommandText = "[app_course].[course_member_update]";
                cm.Parameters.AddWithValue("@id", _id);
                cm.Parameters.AddWithValue("@courseid", _courseid);
                cm.Parameters.AddWithValue("@graduate", _graduate.DBValue);
                cm.Parameters.AddWithValue("@lastchanged", _lastchanged);
                cm.Parameters.AddWithValue("@username", _username);
                cm.Parameters.Add("@newlastchanged", SqlDbType.Timestamp).Direction = ParameterDirection.Output;
                cm.ExecuteNonQuery();

                _lastchanged = (byte[])cm.Parameters["@newlastchanged"].Value;
                this.MarkOld();
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
        internal static void Delete(SqlConnection cn, int id , string username)
        {
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "[app_course].[course_member_delete]";
                cm.Parameters.AddWithValue("@id", id);
                cm.Parameters.AddWithValue("@username", username);
                cm.ExecuteNonQuery();
            }
        }
    }
}