using System;
using System.Data;
using System.Data.SqlClient;
using Dothan;
using Dothan.Data;

namespace Dothan.Library.bizDonate
{
    [Serializable()]
    public class DonateUsers : NameValueListBase<int, string>
    {
        public static DonateUsers GetList()
        {
            return  DataPortal.Fetch<DonateUsers>(new Criteria(typeof(DonateUsers)));
             
        }

        private DonateUsers(){ }


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
                    cm.CommandText = "[app_donate].[recorder_list]";
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        IsReadOnly = false;
                        this.Add(new NameValuePair(0, "ALL"));
                        while (dr.Read())
                            this.Add(new NameValuePair(dr.GetInt32("id"), dr.GetString("username")));
                        IsReadOnly = true;
                    }
                }
            }

            this.RaiseListChangedEvents = true;
        }



    }
}
