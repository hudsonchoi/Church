using System;
using System.Data;
using System.Data.SqlClient;
using Dothan;
using Dothan.Data;
using Dothan.Library.Properties;

namespace Dothan.Library.bizMember
{
     [Serializable()]
    public class MemberCells : BusinessListBase<MemberCells, MemberCell>
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

        private MemberCells() { this.AllowNew = true; }

        public static MemberCells Get(int memberid)
        {
            return DataPortal.Fetch<MemberCells>(new Criteria(memberid));
        }

        public override MemberCells Save()
        {
            MemberCells result;
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
                    cm.CommandText = "[app_cell].[member_get]";
                    cm.Parameters.AddWithValue("@memberid", criteria.Memberid);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(new MemberCell(dr));
                      
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
                foreach (MemberCell item in DeletedList)
                {
                    item.DeleteSelf(cn);
                }
                DeletedList.Clear();

                foreach (MemberCell item in this)
                {
                    item.Update(cn);
                }
            }
            this.RaiseListChangedEvents = true;
        }
    }
}

