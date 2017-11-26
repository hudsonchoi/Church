using System;
using System.Data;
using System.Data.SqlClient;
using Dothan;
using Dothan.Data;

namespace Dothan.Library.bizCourse
{
    [Serializable()]
    public class CourseInfo : ReadOnlyBase<CourseInfo>
    {

        public int Key
        {
            get;
            private set;
        }
        public int ParentCode
        {
            get;
            private set;
        }

        public string Value
        {
            get;
            private set;
        }

        public string Sort
        {
            get;
            private set;
        }

        public int Assigned
        {
            get;
            private set;
        }

        protected override object GetIdValue()
        {
            return Key;
        }

        public override string ToString()
        {
            return Value;
        }

        private CourseInfo() { }


        internal CourseInfo(SafeDataReader dr)
        {
            Key = dr.GetInt32("code");
            Value = dr.GetString("name");
            ParentCode = dr.GetInt32("parentid");
            Sort = dr.GetString("sort");
            Assigned = dr.GetInt32("assigned");
        }
    }
}
