using System;
using System.Data;
using System.Data.SqlClient;
using Dothan;
using Dothan.Data;

namespace Dothan.Library.bizDonate
{
    [Serializable()]
    public class YearList : NameValueListBase<int, string>
    {

        public static YearList Get()
        {
            return DataPortal.Fetch<YearList>(new Criteria(typeof(YearList)));
        }

        private YearList() {}
 
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
                    cm.CommandText = "[app_donate].[yearlist_get]";
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        IsReadOnly = false;
                        Add(new NameValuePair(0, ""));
                        while (dr.Read())
                            Add(new NameValuePair(dr.GetInt32("donate_year"), dr.GetInt32("donate_year").ToString()));
                        IsReadOnly = true;
                    }
                }
            }

            this.RaiseListChangedEvents = true;
        }
    }
}

