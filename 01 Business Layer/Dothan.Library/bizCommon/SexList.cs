using System;
using System.Data;
using System.Data.SqlClient;
using Dothan;
using Dothan.Data;
using Dothan.Library.Properties;

namespace Dothan.Library.bizCommon
{
    [Serializable()]
    public class SexList : NameValueListBase<int, string>
    {
        private static SexList _list;

        public static SexList Get(bool set)
        {

            _list = DataPortal.Fetch<SexList>(new FilterCriteria(set));
            return _list;
        }
        public static void InvalidateCache()
        {
            _list = null;
        }

        [Serializable()]
        public class FilterCriteria
        {
            private bool _set;
            public bool set
            {
                get { return _set; }
            }
            public FilterCriteria(bool set)
            {
                _set = set;
            }
        }
        private SexList() { }

        private void DataPortal_Fetch(FilterCriteria criteria)
        {
            this.RaiseListChangedEvents = false;
            this.IsReadOnly = false;
            if (criteria.set)
                this.Add(new NameValuePair(-1, "ALL"));

            this.Add(new NameValuePair(0, Resources.Female.ToString()));
            this.Add(new NameValuePair(1, Resources.Male.ToString()));
            this.IsReadOnly = true;

            this.RaiseListChangedEvents = true;
        }
    }
}
