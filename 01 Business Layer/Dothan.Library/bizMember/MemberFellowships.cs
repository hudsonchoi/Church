using System;
using System.Data;
using System.Data.SqlClient;
using Dothan;
using Dothan.Data;
using Dothan.Library.Properties;

namespace Dothan.Library.bizMember
{
    [Serializable()]
    public class MemberFellowships : BusinessListBase<MemberFellowships, MemberFellowship>
    {

        #region Criteria
        [Serializable()]
        public class Criteria
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
        #endregion

        private MemberFellowships() { this.AllowNew = true; }

        public static MemberFellowships Get(int memberid)
        {
            return DataPortal.Fetch<MemberFellowships>(new Criteria(memberid));
        }

        public override MemberFellowships Save()
        {
            MemberFellowships result;
            result = base.Save();
            return result;
        }
        private void DataPortal_Fetch(Criteria criteria)
        {
            using (SqlConnection cn = new SqlConnection(Database.ConnectionString))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "[app_fellowship].[member_get]";
                    cm.Parameters.AddWithValue("@memberid", criteria.Memberid);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        
                        while (dr.Read())
                            this.Add(new MemberFellowship(dr));
                        
                    }
                }
            }
        }


        [Transactional(TransactionalTypes.TransactionScope)]
        protected override void DataPortal_Update()
        {
            this.RaiseListChangedEvents = false;

            using (SqlConnection cn = new SqlConnection(Database.ConnectionString))
            {
                cn.Open();
                foreach (MemberFellowship item in DeletedList)
                {
                    item.DeleteSelf(cn);
                }
                DeletedList.Clear();

                foreach (MemberFellowship item in this)
                {
                        item.Update(cn);
                }
            }
            this.RaiseListChangedEvents = true;
        }
    }
}
