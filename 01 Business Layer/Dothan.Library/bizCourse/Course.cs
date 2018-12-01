using System;
using System.Data;
using System.Data.SqlClient;
using Dothan;
using Dothan.Data;


namespace Dothan.Library.bizCourse
{
    [Serializable()]
    public class Course : BusinessBase<Course>
    {
        private int _code;
        private bool _idSet;
        private int _parentcode;
        private string _name = string.Empty;
        private int _total;
        private string _active;
        private SmartDate _regdate = new SmartDate();
        private DateTime _startdate = new DateTime();
        private DateTime _enddate = new DateTime();
        private string _teacher = string.Empty;
        private int _lecturePeriodWeek;
        private string _username = string.Empty;
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
                    Courses parent = (Courses)this.Parent;
                    int max = 0;
                    foreach (Course item in parent)
                    {
                        if (item.Code > max)
                            max = item.Code;
                    }
                    _code = max + 1;
                }
                return _code;
            }
        }
        public string Name
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
        public int Total
        {
            get
            {
                return _total;
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
                if (_regdate.Text != value)
                {
                    _regdate.Text = value;
                    PropertyHasChanged();
                }
            }
        }

        public bool Active
        {
            get
            {
                return _active.Equals("D") ? false : true;

            }
        }
        public int ParentCode
        {
            get
            {

                return _parentcode;
            }
            set
            {
                CanWriteProperty(true);
                if (!_parentcode.Equals(value))
                {
                    _parentcode = value;
                    PropertyHasChanged();
                }
            }
        }

        public DateTime StartDate
        {
            get
            {
                return _startdate;
            }
            set
            {
                CanWriteProperty(true);
                if (_startdate != value)
                {
                    _startdate = value;
                    PropertyHasChanged();
                }
            }
        }

        public DateTime EndDate
        {
            get
            {
                return _enddate;
            }
            set
            {
                CanWriteProperty(true);
                if (_enddate != value)
                {
                    _enddate = value;
                    PropertyHasChanged();
                }
            }
        }

        public string Teacher
        {
            get
            {
                return _teacher;
            }
            set
            {
                CanWriteProperty(true);
                if (value == null) value = string.Empty;
                if (_teacher != value)
                {
                    _teacher = value;
                    PropertyHasChanged();
                }
            }
        }

        public int LecturePeriodWeek
        {
            get
            {

                return _lecturePeriodWeek;
            }
            set
            {
                CanWriteProperty(true);
                if (!_lecturePeriodWeek.Equals(value))
                {
                    _lecturePeriodWeek = value;
                    PropertyHasChanged();
                }
            }
        }


        public string Sort
        {
            get;
            private set;
        }
        protected override object GetIdValue()
        {
            return _code;
        }
        public override string ToString()
        {
            return _name;
        }

        protected override void AddBusinessRules()
        {
               ValidationRules.AddRule(Validation.CommonRules.StringRequired, "Name");
               ValidationRules.AddRule(Validation.CommonRules.StringRequired, "Teacher");
        }
        internal static Course Get(SafeDataReader dr)
        {
            return new Course(dr);
        }
        internal static Course New()
        {
            return new Course();
        }

        private Course()
        {
            MarkAsChild();
            _regdate.Date = DateTime.Today;
            _active = "C";
            _username = Dothan.ApplicationContext.User.Identity.Name;
            ValidationRules.CheckRules();
        }

        public Course(SafeDataReader dr)
        {
            MarkAsChild();
            _idSet = true;
            _code = dr.GetInt32("code");
            _parentcode = dr.GetInt32("parent_code");
            _name = dr.GetString("name");
            _active = dr.GetString("row_status");
            _total = dr.GetInt32("total");
            Sort = dr.GetString("sort");
            _regdate = dr.GetSmartDate("regdate", _regdate.EmptyIsMin);
            _regdate.FormatString = Configurations.DateFomating;
            dr.GetBytes("lastchanged", 0, _lastchanged, 0, 8);

            _username = Dothan.ApplicationContext.User.Identity.Name;
            MarkOld();
        }

        internal void Insert(SqlCommand cm)
        {
            if (!this.IsDirty) return;

            cm.Parameters.Clear();
            cm.CommandType = CommandType.StoredProcedure;
            cm.CommandText = "[app_course].[course_insert]";
            cm.Parameters.AddWithValue("@name", _name);
            cm.Parameters.AddWithValue("@parent_code", _parentcode);
            cm.Parameters.AddWithValue("@regdate", _regdate.DBValue);
            cm.Parameters.AddWithValue("@username", _username);
            cm.Parameters.Add("@newid", SqlDbType.Int).Direction = ParameterDirection.Output;
            cm.Parameters.Add("@newlastchanged", SqlDbType.Timestamp).Direction = ParameterDirection.Output;
            cm.ExecuteNonQuery();
            _code = (int)cm.Parameters["@newid"].Value;
            _lastchanged = (byte[])cm.Parameters["@newlastchanged"].Value;
            MarkOld();

        }
        internal void Update(SqlCommand cm)
        {
            if (!this.IsDirty) return;

            cm.Parameters.Clear();
            cm.CommandType = CommandType.StoredProcedure;
            cm.CommandText = "[app_course].[course_update]";
            cm.Parameters.AddWithValue("@code", _code);
            cm.Parameters.AddWithValue("@name", _name);
            cm.Parameters.AddWithValue("@parent_code", _parentcode);
            cm.Parameters.AddWithValue("@regdate", _regdate.DBValue);
            cm.Parameters.AddWithValue("@username", _username);
            cm.Parameters.AddWithValue("@lastchanged", _lastchanged);
            cm.Parameters.Add("@newlastchanged", SqlDbType.Timestamp).Direction = ParameterDirection.Output;
            cm.ExecuteNonQuery();
            _lastchanged = (byte[])cm.Parameters["@newlastchanged"].Value;
            MarkOld();
        }

        internal void DeleteSelf(SqlConnection cn)
        {
            if (!this.IsDirty) return;
            if (this.IsNew) return;
            Delete(cn, _code, _username);
            MarkNew();
        }


        internal static void Delete(SqlConnection cn, int code, string username)
        {
            using (SqlCommand cm = cn.CreateCommand())
            {

                cm.Parameters.Clear();
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "[app_course].[course_delete]";
                cm.Parameters.AddWithValue("@code", code);
                cm.Parameters.AddWithValue("@username", username);
                cm.ExecuteNonQuery();
            }
        }

    }
}
