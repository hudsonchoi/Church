using System;
using System.Data;
using System.Data.SqlClient;
using Dothan;
using Dothan.Data;
using Dothan.Library.Properties;

namespace Dothan.Library.bizMember
{

    [Serializable()]
    public class MemberMinistrys : BusinessListBase<MemberMinistrys, MemberMinistry>
    {
 
        #region Criteria
        [Serializable()]
        public class Criteria
        {
            private int _memberid;

            public int MmeberID { get { return _memberid; } }
  
            public Criteria(int memberid)
            {
                _memberid = memberid;
            }
        }


        #endregion

        private MemberMinistrys() { this.AllowNew = true; }

        public override MemberMinistrys Save()
        {
              MemberMinistrys result;
            result = base.Save();
            return result;
        }

        public void Assign(int membeid )
        {
                MemberMinistry member = MemberMinistry.New(membeid);
                this.Add(member);
            
        }
        public static MemberMinistrys Get(int memberid)
        {
            return DataPortal.Fetch<MemberMinistrys>(new Criteria(memberid));
        }
        public void Remove(int id)
        {
            foreach (MemberMinistry item in this)
                if (item.ID.Equals(id))
                {
                    Remove(item);
                    break;
                }
        }




        private void DataPortal_Fetch(Criteria criteria)
        {
            RaiseListChangedEvents = false;
            using (SqlConnection cn = new SqlConnection(Database.ConnectionString))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "[app_ministry].[member_get]";
                    cm.Parameters.AddWithValue("@memberid", criteria.MmeberID);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        while (dr.Read())
                            this.Add(MemberMinistry.Get(dr));
                }
            }
            RaiseListChangedEvents = true;
        }


        [Transactional(TransactionalTypes.TransactionScope)]
        protected override void DataPortal_Update()
        {
            this.RaiseListChangedEvents = false;

            using (SqlConnection cn = new SqlConnection(Database.ConnectionString))
            {
                cn.Open();
                foreach (MemberMinistry item in DeletedList)
                {
                    item.DeleteSelf(cn);
                }
                DeletedList.Clear();

                foreach (MemberMinistry item in this)
                {
                    if (item.IsNew)
                        item.Insert(cn);
                    else
                        item.Update(cn);
                }
            }
            this.RaiseListChangedEvents = true;
        }

    }
}
