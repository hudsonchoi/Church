using System;
using System.Data;
using System.Data.SqlClient;
using Dothan;
using Dothan.Data;
using Dothan.Library.Properties;


namespace Dothan.Library.bizCourse
{
    [Serializable()]
    public class CourseMember : BusinessBase<CourseMember>
    {
        private int _id;
        private bool _idSet;
        private int _courseid;
        private string _coursename = string.Empty;
        private SmartDate _graduate = new SmartDate(false);
        private MemberInfoBase _info = new MemberInfoBase();
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
                    CourseMembers parent = (CourseMembers)this.Parent;
                    int max = 0;
                    foreach (CourseMember item in parent)
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

        /// <summary>
        /// Member Info 
        /// </summary>
        /// <returns></returns>
        /// 

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

        internal static CourseMember New(Dothan.Library.bizMember.MemberInfo info)
        {
            return new CourseMember(info);
        }
        private CourseMember() { MarkAsChild(); }
        private CourseMember(Dothan.Library.bizMember.MemberInfo info) 
        {
            _info = MemberInfoBase.Get(info);


            _username = Dothan.ApplicationContext.User.Identity.Name;
            MarkAsChild(); 
        
        }
        internal static CourseMember Get(SafeDataReader dr)
        {
            return new CourseMember(dr);
        }

        private CourseMember(SafeDataReader dr)
        {
            MarkAsChild();
            _id = dr.GetInt32("id");
            _idSet = true;
            _courseid = dr.GetInt32("course_code");
            _graduate = dr.GetSmartDate("graduated", _graduate.EmptyIsMin);
            _info = MemberInfoBase.Get(dr);

            dr.GetBytes("lastchanged", 0, _lastchanged, 0, 8);

            _username = Dothan.ApplicationContext.User.Identity.Name;
            MarkOld();
        }

        internal void Insert(SqlConnection cn)
        {
            if (!this.IsDirty) return;
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "[app_course].[course_member_insert]";
                cm.Parameters.AddWithValue("@courseid", _courseid);
                cm.Parameters.AddWithValue("@memberid", _info.MemberId);
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
