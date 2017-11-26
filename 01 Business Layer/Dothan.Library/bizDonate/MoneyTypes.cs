using System;
using System.Data;
using System.Data.SqlClient;
using Dothan;
using Dothan.Data;
using Dothan.Library.Properties;

namespace Dothan.Library.bizDonate
{
    [Serializable()]
    public class MoneyTypes : NameValueListBase<int, string>
    {
        private static MoneyTypes _list;

        public static MoneyTypes GetList(bool set)
        {

            _list = DataPortal.Fetch<MoneyTypes>(new FilterCriteria(set));
            return _list;
        }
        public static string GetName(int key)
        {
            if (_list == null)
                _list = DataPortal.Fetch<MoneyTypes>(new FilterCriteria(false));
            return _list.Value(key);
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
        private MoneyTypes() { }

        private void DataPortal_Fetch(FilterCriteria criteria)
        {
            this.RaiseListChangedEvents = false;
            this.IsReadOnly = false;
            if (criteria.set)
                this.Add(new NameValuePair(-1, "ALL"));
            this.Add(new NameValuePair(0, Resources.Check.ToString()));
            this.Add(new NameValuePair(1, Resources.Cash.ToString()));

            this.IsReadOnly = true;

            this.RaiseListChangedEvents = true;
        }
    }
}