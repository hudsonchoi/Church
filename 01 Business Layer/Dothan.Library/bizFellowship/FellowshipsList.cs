using System;
using System.Data;
using System.Data.SqlClient;
using Dothan;
using Dothan.Data;

namespace Dothan.Library.bizFellowship
{
    [Serializable()]
    public class FellowshipsList: ReadOnlyListBase<FellowshipsList ,FellowshipInfo>
    {
        public static FellowshipsList  Get(bool set)
        {
            return DataPortal.Fetch<FellowshipsList>(new Criteria(set));
        }

        private FellowshipsList () 
        {   }

        [Serializable()]
        private class Criteria
        {
            private bool _set;

            public string set { get { return _set ? "All" : ""; } }
            public Criteria(bool set)
            {
                _set = set;
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
                    cm.CommandText = "[app_fellowship].[fellowship_list]";
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        IsReadOnly = false;
                        while (dr.Read())
                        {
                            Add(new FellowshipInfo(dr));
                           
                        }
                        IsReadOnly = true;
                    }
                }
            }

            this.RaiseListChangedEvents = true;
        }
        
    }
}
