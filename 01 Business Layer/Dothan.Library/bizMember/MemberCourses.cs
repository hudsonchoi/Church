using System;
using System.Data;
using System.Data.SqlClient;
using Dothan;
using Dothan.Data;
using Dothan.Library.Properties;

namespace Dothan.Library.bizMember
{
    [Serializable()]
    public class MemberCourses : BusinessListBase<MemberCourses, MemberCourse>
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

        private MemberCourses() { this.AllowNew = true; }

        public override MemberCourses Save()
        {
            MemberCourses result;
            result = base.Save();
            return result;
        }

        public void Assign(int membeid)
        {
            MemberCourse member = MemberCourse.New(membeid);
            this.Add(member);

        }
        public static MemberCourses Get(int memberid)
        {
            return DataPortal.Fetch<MemberCourses>(new Criteria(memberid));
        }
        public void Remove(int id)
        {
            foreach (MemberCourse item in this)
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
                    cm.CommandText = "[app_course].[member_get]";
                    cm.Parameters.AddWithValue("@memberid", criteria.MmeberID);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        while (dr.Read())
                            this.Add(MemberCourse.Get(dr));
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
                foreach (MemberCourse item in DeletedList)
                {
                    item.DeleteSelf(cn);
                }
                DeletedList.Clear();

                foreach (MemberCourse item in this)
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
