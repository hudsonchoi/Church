using System;
using System.Data;
using System.Data.SqlClient;
using Dothan;
using Dothan.Data;
using Dothan.Library.Properties;

namespace Dothan.Library.bizMember
{
    [Serializable()]
    public class  CommentInfo : ReadOnlyBase<CommentInfo>
    {
        private int _id;
        private string _username = string.Empty;
        private SmartDate _lastupdate = new SmartDate(false);
        private SmartDate _regdate = new SmartDate(false);
        private string _comment;

        public int ID { get { return _id; } }
        public string Username { get { return _username; } }
        public string Comment { get { return _comment; } }
        public string LastUpdate { get { return _lastupdate.Text; } }
        public string RegDate { get { return _regdate.Text; } }

        protected override object GetIdValue()
        {
            return _id;
        }
         private CommentInfo() { }

         internal CommentInfo(SafeDataReader dr)
         {
             _id = dr.GetInt32("id");
             _comment = dr.GetString("comment");
             _regdate = dr.GetSmartDate("regdate", _regdate.EmptyIsMin);
             _lastupdate = dr.GetSmartDate("update_date", _lastupdate.EmptyIsMin);
             _username = dr.GetString("update_by");
         }
    }
}
