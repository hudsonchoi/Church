using System;
using System.Data;
using System.Data.SqlClient;
using Dothan;
using Dothan.Data;

namespace Dothan.Library.bizDonate
{
    [Serializable()]
    public class DonateTypeList : NameValueListBase<int, string>
    {
        private static DonateTypeList _list;
        public static DonateTypeList GetList(int root)
        {
            if (_list == null)
                _list = DataPortal.Fetch<DonateTypeList>(new Criteria(root));
            return _list;
        }

        public static void InvalidateCache()
        {
            _list = null;
        }
        private DonateTypeList()
        {

        }

        [Serializable()]
        private class Criteria
        {
            private  int _root;
            public int Root { get{ return _root;}}

            public Criteria(int root)
            {
                _root = root;
            }
        }

        private void DataPortal_Fetch(Criteria criteria)
        {
            this.RaiseListChangedEvents = false;
            IsReadOnly = false;
            using (SqlConnection cn = new SqlConnection(Database.ConnectionString))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "app_donate.donatetype_list";
                    cm.Parameters.AddWithValue("@root", criteria.Root);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        IsReadOnly = false;
                        while (dr.Read())
                            this.Add(new NameValuePair(dr.GetInt32("code"), dr.GetString("typename")));
                        IsReadOnly = true;
                    }
                }
            }

            this.RaiseListChangedEvents = true;
        }

    }
}