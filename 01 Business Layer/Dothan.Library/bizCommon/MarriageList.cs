using System;
using System.Data;
using System.Data.SqlClient;
using Dothan;
using Dothan.Data;
using Dothan.Library.Properties;

namespace Dothan.Library.bizCommon
{
    [Serializable()]
    public class MarriageList : NameValueListBase<int, string>
    {
         private static MarriageList _list;

        public static MarriageList Get(bool set)
        {
                _list = DataPortal.Fetch<MarriageList>(new FilterCriteria(set));
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

        private MarriageList() { }

        private void DataPortal_Fetch(FilterCriteria criteria)
        {
            this.RaiseListChangedEvents = false;
            IsReadOnly = false;
            if (criteria.set)
                this.Add(new NameValuePair(-1, "ALL"));
            this.Add(new NameValuePair(0, Resources.Single));
            this.Add(new NameValuePair(1, Resources.Married));
            this.IsReadOnly = true;

            this.RaiseListChangedEvents = true;
        }
    }
}
