using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using Dothan;
using Dothan.Data;


namespace Dothan.Library.bizCell
{
   
    [Serializable()]
    public class CellMembers : BusinessListBase<CellMembers,CellMember>
    {
        #region Authorization Rules


        public static bool CanEditObject()
        {
            bool result = false;
            if (Dothan.ApplicationContext.User.IsInRole("Cell_RW")
                || Dothan.ApplicationContext.User.IsInRole("SysAdmin"))
                result = true;
            return result;
        }

        public static bool CanGetObject()
        {
            bool result = false;
            if (Dothan.ApplicationContext.User.IsInRole("Cell_R")
                || Dothan.ApplicationContext.User.IsInRole("Cell_RW")
                || Dothan.ApplicationContext.User.IsInRole("SysAdmin"))
                result = true;
            return result;
        }

        public static bool CanDeleteObject()
        {
            bool result = false;
            if (Dothan.ApplicationContext.User.IsInRole("Cell_RW")
                || Dothan.ApplicationContext.User.IsInRole("SysAdmin"))
                result = true;
            return result;
        }

        #endregion

        #region Criteria
        [Serializable()]
        public class NameCriteria
        {
            private string _name;
            public string Name { get { return _name; } }
            public NameCriteria(string name)
            {
                _name = name;
            }
        }

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
            public Criteria(int code, int role, bool withHistory, string fromEndDate , string toEndDate )
            {
                _code = code;
                _role = role;
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

        private CellMembers() { this.AllowNew = true; }

        public override CellMembers Save()
        {
            if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to save roles");
            CellMembers result;
            result = base.Save();
            return result;
        }

        public void Assign(Dothan.Library.bizMember.MemberInfo info, int Cellid, string startdate, int role)
        {
            if (!Contains(info.MemberId))
            {
                CellMember member = CellMember.New(info, Cellid, startdate, role);
                this.Add(member);
            }  
        }
        public static CellMembers Get(int code, int role, bool withHistory , string fromEndDate , string toEndDate)
        {
            return DataPortal.Fetch<CellMembers>(new Criteria(code, role , withHistory , fromEndDate , toEndDate));
        }
        public static CellMembers GetListByRoles(int role)
        {
            return DataPortal.Fetch<CellMembers>(new Criteria(role));
        }

        public static CellMembers GetListByName(string name)
        {
            return DataPortal.Fetch<CellMembers>(new NameCriteria(name));
        }

        public void Remove(int id)
        {
            foreach (CellMember item in this)
                if (item.ID.Equals(id))
                {
                    Remove(item);
                    break;
                }
        }
 

        public bool Contains(int memberid)
        {
            foreach (CellMember res in this)
               if (res.MemberId.Equals(memberid))
                    return true;
            return false;
        }


        private void DataPortal_Fetch(NameCriteria criteria)
        {
            RaiseListChangedEvents = false;
            using (SqlConnection cn = new SqlConnection(Database.ConnectionString))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "[app_cell].[cell_member_get_byname]";
                    cm.Parameters.AddWithValue("@name", criteria.Name);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        while (dr.Read())
                            this.Add(CellMember.Get(dr));
                }
            }
            RaiseListChangedEvents = true;
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
                    cm.CommandText = "[app_cell].[cell_member_get]";
                    cm.Parameters.AddWithValue("@code", criteria.Code);
                    cm.Parameters.AddWithValue("@withHistory", criteria.WithHistory);
                    cm.Parameters.AddWithValue("@role", criteria.Role);
                    cm.Parameters.AddWithValue("@from", criteria.From.DBValue);
                    cm.Parameters.AddWithValue("@to", criteria.To.DBValue);


                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        while (dr.Read())
                            this.Add(CellMember.Get(dr));
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
                foreach (CellMember item in DeletedList)
                {
                    item.DeleteSelf(cn);
                }
                DeletedList.Clear();

                foreach (CellMember item in this)
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


