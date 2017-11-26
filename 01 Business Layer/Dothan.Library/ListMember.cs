using System;
using System.Data;
using System.Data.SqlClient;
using Dothan;
using Dothan.Data;
using Dothan.Library.Properties;

namespace Dothan.Library
{
    [Serializable()]
    public class ListMember : BusinessBase<ListMember>
    {
        private int _memberid;
        private string _fullname;

        [System.ComponentModel.DataObjectField(true, true)]
        public int ID
        {

            get
            {
                CanReadProperty(true);
                return _memberid;
            }
        }
        public string FullName
        {
            get
            {
                CanReadProperty(true);
                return _fullname;
            }
        }

        protected override object GetIdValue()
        {
            return _memberid;
        }
        internal static ListMember Get(int memberid, string fullname)
        {
            return new ListMember(memberid, fullname);
        }
        private ListMember() { MarkAsChild(); }

        private ListMember(int memberid , string fullname)
        {
            MarkAsChild();
            _memberid =memberid;
            _fullname = fullname;
             MarkOld();
    }
}
