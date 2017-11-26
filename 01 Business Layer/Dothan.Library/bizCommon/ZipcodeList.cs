using System;
using System.Data;
using System.Data.SqlClient;
using Dothan;
using Dothan.Data;

namespace Dothan.Library.bizCommon
{
    [Serializable()]
    public class ZipcodeList : ReadOnlyListBase<ZipcodeList, ZipcodeInfo>
    {
        public static ZipcodeList GetList(string zipcode)
        {
            return DataPortal.Fetch<ZipcodeList>(new Criteria(zipcode));
        }

        [Serializable()]
        private class Criteria
        {
            private string _zipcode = string.Empty;

            public string ZipCode { get {return _zipcode;}}
            public Criteria(string zipcode)
            {
                _zipcode = zipcode;
            }
        }
        private void DataPortal_Fetch(Criteria criteria)
        {

            using (SqlConnection cn = new SqlConnection(Database.ConnectionString))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "[app_common].[zipcode_get]";
                    cm.Parameters.AddWithValue("@zipcode", criteria.ZipCode);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        IsReadOnly = false;
                        while (dr.Read())
                            this.Add(new ZipcodeInfo(dr));
               
                        IsReadOnly = true;
                    }
                }
            }
        }

    }
}
