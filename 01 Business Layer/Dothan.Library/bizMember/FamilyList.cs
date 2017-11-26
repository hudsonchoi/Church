using System;
using System.Data;
using System.Data.SqlClient;
using Dothan;
using Dothan.Data;

namespace Dothan.Library.bizMember
{
    [Serializable()]
    public class FamilyList : ReadOnlyListBase<FamilyList, FamilyInfo>
    {
        public static FamilyList GetList(int memberid)
        {
            return DataPortal.Fetch<FamilyList>(new Criteria(memberid));
        }

        private FamilyList()
        { }

        [Serializable()]
        private class Criteria
        {

            private int _memberid;

            public int Memberid
            {
                get { return _memberid; }
            }

            public Criteria(int memberid)
            {

                _memberid = memberid;
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
                    cm.CommandText = "app_member.family_get";
                    cm.Parameters.AddWithValue("@memberid", criteria.Memberid);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        IsReadOnly = false;
                        while (dr.Read())
                        {
                            this.Add(new FamilyInfo(dr));
                        }
                        IsReadOnly = true;
                    }
                }
            }
        }
    }
}