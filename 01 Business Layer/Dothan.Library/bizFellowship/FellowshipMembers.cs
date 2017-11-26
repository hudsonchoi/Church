using System;
using System.Data;
using System.Data.SqlClient;
using Dothan;
using Dothan.Data;

namespace Dothan.Library.bizFellowship
{
    [Serializable()]
    public class FellowshipMembers : BusinessListBase<FellowshipMembers, FellowshipMember>
    {
        #region Authorization Rules

        public static bool CanEditObject()
        {
            bool result = false;
            if (Dothan.ApplicationContext.User.IsInRole("Fellowship_RW")
                || Dothan.ApplicationContext.User.IsInRole("SysAdmin"))
                result = true;
            return result;
        }

        public static bool CanGetObject()
        {
            bool result = false;
            if (Dothan.ApplicationContext.User.IsInRole("Fellowship_R")
                || Dothan.ApplicationContext.User.IsInRole("Fellowship_RW")
                || Dothan.ApplicationContext.User.IsInRole("SysAdmin"))
                result = true;
            return result;
        }

        public static bool CanDeleteObject()
        {
            bool result = false;
            if (Dothan.ApplicationContext.User.IsInRole("Fellowship_RW")
                || Dothan.ApplicationContext.User.IsInRole("SysAdmin"))
                result = true;
            return result;
        }


        #endregion

        #region Criteria
        [Serializable()]
        public class Criteria
        {
            private int _code;
            private bool _withHistory = false;
            private SmartDate _fromEndDate = new SmartDate(false);
            private SmartDate _toEndDate = new SmartDate(false);

            public SmartDate FromEndDate { get { return _fromEndDate; } }
            public SmartDate ToEndDate { get { return _toEndDate; } }
            public int Code
            {
                get { return _code; }
            }
            public bool WithHistory { get { return _withHistory; } }

            public Criteria(int code)
            {
                _code = code;
            }
            public Criteria(int code, bool withHistory, string from, string to)
            {
                _code = code;
                _withHistory = withHistory;
                _fromEndDate.Text = from;
                _toEndDate.Text = to;
            }
        }
        #endregion


        private FellowshipMembers() { this.AllowNew = true; }

        public override FellowshipMembers Save()
        {
            if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to save roles");
            FellowshipMembers result;
            result = base.Save();
            return result;
        }

        public static FellowshipMembers Get(int code)
        {
            return DataPortal.Fetch<FellowshipMembers>(new Criteria(code));
        }

        public static FellowshipMembers Get(int code, bool withHistory, string fromEndDate, string toEndDate)
        {
            return DataPortal.Fetch<FellowshipMembers>(new Criteria(code, withHistory, fromEndDate, toEndDate));
        }

        public void Assign(Dothan.Library.bizMember.MemberInfo info, int fellowshipid, string startdate)
        {

            if (!Contains(info.MemberId))
            {
                FellowshipMember member = FellowshipMember.New(info, fellowshipid, startdate);
                this.Add(member);
            }
        }


        public void Remove(int id)
        {
            foreach (FellowshipMember item in this)
                if (item.ID.Equals(id))
                {
                    Remove(item);
                    break;
                }
        }

        public bool Contains(int memberid)
        {
            foreach (FellowshipMember res in this)
                if (res.MemberId.Equals(memberid))
                    return true;
            return false;
        }

        public bool ContainsDeleted(int memberid)
        {
            foreach (FellowshipMember res in DeletedList)
                if (res.MemberId == memberid)
                    return true;
            return false;
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
                    cm.CommandText = "[app_fellowship].[fellowship_member_get]";
                    cm.Parameters.AddWithValue("@code", criteria.Code);
                    cm.Parameters.AddWithValue("@withHistory", criteria.WithHistory);
                    cm.Parameters.AddWithValue("@from", criteria.FromEndDate.DBValue);
                    cm.Parameters.AddWithValue("@to", criteria.ToEndDate.DBValue);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        while (dr.Read())
                            this.Add(FellowshipMember.Get(dr));
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
                foreach (FellowshipMember item in DeletedList)
                {
                    item.DeleteSelf(cn);
                }
                DeletedList.Clear();

                foreach (FellowshipMember item in this)
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
