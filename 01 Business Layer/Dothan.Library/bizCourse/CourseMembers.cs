using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using Dothan;
using Dothan.Data;

namespace Dothan.Library.bizCourse
{
    [Serializable()]
    public class CourseMembers : BusinessListBase<CourseMembers,CourseMember>
    {

        #region Search Function

        public static CourseMembers GetList(string codelist, int fellowship, int cellrole, string from, string to)
        {
            return DataPortal.Fetch<CourseMembers>(new Criteria_Advanced(codelist,fellowship,cellrole,from,to));
        }

        public static CourseMembers GetList(int code)
        {
            return DataPortal.Fetch<CourseMembers>(new Criteria(code));
        }

        public static CourseMembers NewList()
        {
            return DataPortal.Create<CourseMembers>();
        }
        #endregion


        #region Authorization Rules

        public static bool CanGetObject()
        {
            bool result = false;
            if (Dothan.ApplicationContext.User.IsInRole("Course_R")
                || Dothan.ApplicationContext.User.IsInRole("Course_RW")
                || Dothan.ApplicationContext.User.IsInRole("SysAdmin"))
                result = true;
            return result;
        }

        public static bool CanDeleteObject()
        {
            bool result = false;
            if (Dothan.ApplicationContext.User.IsInRole("Course_RW")
                || Dothan.ApplicationContext.User.IsInRole("SysAdmin"))
                result = true;
            return result;
        }

        public static bool CanEditObject()
        {
            bool result = false;
            if (Dothan.ApplicationContext.User.IsInRole("Course_RW")
                || Dothan.ApplicationContext.User.IsInRole("SysAdmin"))
                result = true;
            return result;
        }

        #endregion
        [Serializable()]
        public class  Criteria
        {
            public int Code
            {
                get;
                private set;
            }

            public Criteria(int Key)
            {
                Code = Key;
            }

        }


        [Serializable()]
        public class  Criteria_Advanced
        {
            private string _codelist = string.Empty;
            private int _fellowship = 0;
            private int _cellrole = 0;
            private SmartDate _from = new SmartDate(false);
            private SmartDate _to = new SmartDate(false);

            public string CodeList { get { return _codelist; } }
            public int Fellowship { get { return _fellowship; } }
            public int Cellrole { get { return _cellrole; } }
            public SmartDate DateFrom { get { return _from; } }
            public SmartDate DateTo { get { return _to; } }
           
            
            public Criteria_Advanced(string codelist , int fellowship , int cellrole , string from , string to)
            {
                _codelist = codelist;
                _fellowship = fellowship;
                _cellrole = cellrole;
                _from.Text = from;
                _to.Text = to;
            }

      

        }
 
        [RunLocal()]
        private void DataPortal_Create(Criteria criteria)
        {
            
        }


        private CourseMembers() { this.AllowNew = true; }

        public override CourseMembers Save()
        {
            if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to save");
            
            CourseMembers result;
            result = base.Save();
            return result;
        }

        public void Remove(int id)
        {
            foreach (CourseMember item in this)
                if (item.ID.Equals(id))
                {
                    Remove(item);
                    break;
                }
        }

        public void Assign(Dothan.Library.bizMember.MemberInfo info, string regdate, int courseid)
        {

            if (!Contains(info.MemberId))
            {
                CourseMember item = CourseMember.New(info);
                item.Graduate = regdate;
                item.CourseId = courseid;
                this.Add(item);

            }

        }
        public bool Contains(int memberid)
        {
            foreach (CourseMember res in this)
                if (res.MemberId.Equals(memberid))
                    return true;
            return false;
        }
        private void DataPortal_Fetch(Criteria_Advanced criteria)
        {
            RaiseListChangedEvents = false;

            using (SqlConnection cn = new SqlConnection(Database.ConnectionString))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "[app_course].[course_member_getadvanced]";
                    cm.Parameters.AddWithValue("@codelist", criteria.CodeList);
                    cm.Parameters.AddWithValue("@fellowship", criteria.Fellowship);
                    cm.Parameters.AddWithValue("@cellrole", criteria.Cellrole);
                    cm.Parameters.AddWithValue("@from", criteria.DateFrom.DBValue);
                    cm.Parameters.AddWithValue("@to", criteria.DateTo.DBValue);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        while (dr.Read())
                            this.Add(CourseMember.Get(dr));
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
                    cm.CommandText = "[app_course].[course_member_get]";
                    cm.Parameters.AddWithValue("@code", criteria.Code);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        while (dr.Read())
                            this.Add(CourseMember.Get(dr));
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
                foreach (CourseMember item in DeletedList)
                {
                    item.DeleteSelf(cn);
                }
                DeletedList.Clear();

                foreach (CourseMember item in this)
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
