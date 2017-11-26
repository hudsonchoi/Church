using System;
using System.Data;
using System.Data.SqlClient;
using Dothan;
using Dothan.Data;
using Dothan.Library.Properties;

namespace Dothan.Library.bizCommon
{
    [Serializable()]
    public class StatusList : NameValueListBase<int, string>
    {
        private static StatusList _list;

        public static StatusList Get()
        {
            if (_list == null)
                _list = DataPortal.Fetch<StatusList>(new Criteria(typeof(StatusList)));
            return _list;
        }

        public static void InvalidateCache()
        {
            _list = null;
        }
        private StatusList() { }

        private void DataPortal_Fetch(Criteria criteria)
        {
            this.RaiseListChangedEvents = false;
            IsReadOnly = false;
            this.Add(new NameValuePair(-1, "All"));
            this.Add(new NameValuePair(1, Resources.Active.ToString()));
            this.Add(new NameValuePair(0, Resources.InActive.ToString()));
            this.IsReadOnly = true;

            this.RaiseListChangedEvents = true;
        }
    }
}