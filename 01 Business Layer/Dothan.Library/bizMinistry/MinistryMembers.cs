using System;
using System.Data;
using System.Data.SqlClient;
using Dothan;
using Dothan.Data;


namespace Dothan.Library.bizMinistry
{
   
    [Serializable()]
    public class MinistryMembers : BusinessListBase<MinistryMembers,MinistryMember>
    {
        #region Authorization Rules


        public static bool CanEditObject()
        {
            bool result = false;
            if (Dothan.ApplicationContext.User.IsInRole("Ministry_RW")
                || Dothan.ApplicationContext.User.IsInRole("SysAdmin"))
                result = true;
            return result;
        }

        public static bool CanGetObject()
        {
            bool result = false;
            if (Dothan.ApplicationContext.User.IsInRole("Ministry_R")
                || Dothan.ApplicationContext.User.IsInRole("Ministry_RW")
                || Dothan.ApplicationContext.User.IsInRole("SysAdmin"))
                result = true;
            return result;
        }

        public static bool CanDeleteObject()
        {
            bool result = false;
            if (Dothan.ApplicationContext.User.IsInRole("Ministry_RW")
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
            private int _role;
            private bool _withHistory = false;
            private SmartDate _from = new SmartDate(false);
            private SmartDate _to = new SmartDate(false);

            public int Role { get { return _role; } }
            public SmartDate From
            {
                get
                {
                    return _from;
                }
            }
            public SmartDate To
            {
                get
                {
                    return _to;
                }
            }
            public bool WithHistory { get { return _withHistory; } }
            public int Code
            {
                get { return _code; }
            }
            public Criteria(int code, bool withHistory, string fromEndDate , string toEndDate )
            {
                _code = code;
                _withHistory = withHistory;
                _from.Text = fromEndDate;
                _to.Text = toEndDate;
            }
            public Criteria(int role)
            {
                _role = role;
            }
        }


        #endregion

        private MinistryMembers() { this.AllowNew = true; }

        public override MinistryMembers Save()
        {
            if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to save roles");
            MinistryMembers result;
            result = base.Save();
            return result;
        }

        public void Assign(Dothan.Library.bizMember.MemberInfo info, int ministryid, string startdate, int role)
        {
            if (!Contains(info.MemberId))
            {
                MinistryMember member = MinistryMember.New(info, ministryid, startdate, role);
                this.Add(member);
            }  
        }
        public static MinistryMembers Get(int code, bool withHistory , string fromEndDate , string toEndDate)
        {
            return DataPortal.Fetch<MinistryMembers>(new Criteria(code, withHistory , fromEndDate , toEndDate));
        }
        public static MinistryMembers GetListByRoles(int role)
        {
            return DataPortal.Fetch<MinistryMembers>(new Criteria(role));
        }
        public void Remove(int id)
        {
            foreach (MinistryMember item in this)
                if (item.ID.Equals(id))
                {
                    Remove(item);
                    break;
                }
        }
 

        public bool Contains(int memberid)
        {
            foreach (MinistryMember res in this)
               if (res.MemberId.Equals(memberid))
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
                    cm.CommandText = "[app_ministry].[ministry_member_get]";
                    cm.Parameters.AddWithValue("@code", criteria.Code);
                    cm.Parameters.AddWithValue("@role", criteria.Role);
                    cm.Parameters.AddWithValue("@from", criteria.From.DBValue);
                    cm.Parameters.AddWithValue("@to", criteria.To.DBValue);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        while (dr.Read())
                            this.Add(MinistryMember.Get(dr));
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
                foreach (MinistryMember item in DeletedList)
                {
                    item.DeleteSelf(cn);
                }
                DeletedList.Clear();

                foreach (MinistryMember item in this)
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
