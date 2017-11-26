using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using Dothan;
using Dothan.Data;

namespace Dothan.Library.bizMember
{
    [Serializable()]
    public class MemberList : ReadOnlyListBase<MemberList,MemberInfo>
    {

        public static MemberList GetUnAssignedCellMember(int subDivision)
        {
            return DataPortal.Fetch<MemberList>(new UnAssignCriteria(subDivision));
        }
        [Serializable()]
        private class UnAssignCriteria
        {
            private int _subDivision;

            public int SubDivision { get { return _subDivision; } }

            public UnAssignCriteria(int subDivision)
            {
                _subDivision = subDivision;
            }
        }

        private void DataPortal_Fetch(UnAssignCriteria criteria)
        {
            using (SqlConnection cn = new SqlConnection(Database.ConnectionString))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {


                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "[app_member].[unassigned_cell_member_get]";
                    cm.Parameters.AddWithValue("@subDivision", criteria.SubDivision);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        IsReadOnly = false;
                        while (dr.Read())
                            this.Add(new MemberInfo(dr));
                        IsReadOnly = true;
                    }
                }
            }
        }

        /// <summary>
        /// Search Member list by commma delimited memberId like 10000, 1222,
        /// </summary>
        /// <param name="str">null</param>
        /// <returns>MemberList</returns>
        public static MemberList GetListByIdList(string str)
        {
            return DataPortal.Fetch<MemberList>(new CriteriaByList(str));
        }

        [Serializable()]
        private class CriteriaByList
        {
            private string _memberid;

            public string MemberList { get { return _memberid; } }

            public CriteriaByList(string memberid)
            {
                _memberid = memberid;
            }
        }

        private void DataPortal_Fetch(CriteriaByList criteria)
        {
            using (SqlConnection cn = new SqlConnection(Database.ConnectionString))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {


                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "[app_member].[member_list_by_memberid_list]";
                    cm.Parameters.AddWithValue("@memberlist", criteria.MemberList);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        IsReadOnly = false;
                        while (dr.Read())
                            this.Add(new MemberInfo(dr));
                        IsReadOnly = true;
                    }
                }
            }
        }


        /// <summary>
        /// search Member
        /// </summary>
        /// <param name="memberId">0</param>
        /// <param name="fullname">null</param>
        /// <param name="lastName">null</param>
        /// <param name="fristName">null</param>
        /// <param name="enLastName">null</param>
        /// <param name="enFirstName">null</param>
        /// <param name="fellowship">0</param>
        /// <param name="agefrom">0</param>
        /// <param name="ageto">0</param>
        /// <param name="state">null</param>
        /// <param name="city">null</param>
        /// <param name="sex">-1</param>
        /// <param name="regfrom">null</param>
        /// <param name="regto">null</param>
        /// <param name="status">-1</param>
        /// <param name="baptism">0</param>
        /// <param name="bapfrom">null</param>
        /// <param name="bapto">null</param>
        /// <param name="married">-1</param>
        /// <param name="subdiv">0</param>
        /// <param name="relationship">0</param>
        /// <param name="jobtype">0</param>
        /// <param name="birthtfrom">null</param>
        /// <param name="birthto">null</param>
        /// <param name="active">-1</param>
        /// <param name="cellphone">null</param>
        /// <param name="home">null</param>
        /// <returns>MemberList</returns>
        public static MemberList Get(string lastName, string fristName, string enLastName, string enFirstName, int fellowship,
            int agefrom, int ageto, string state, string city, int sex, string regfrom, string regto, int status, int baptism, string bapfrom, string bapto, int married, int subdiv,
            int relationship, int jobtype, string birthtfrom, string birthto, int active, string cellphone, string home)
        {
            return DataPortal.Fetch<MemberList>(
                new filterCriteria
                    ( lastName, fristName, enLastName, enFirstName, fellowship, agefrom, ageto, state, city, sex, regfrom, regto, status, baptism, bapfrom, bapto, married, subdiv, relationship, jobtype, birthtfrom, birthto, active, home, cellphone));
        }

        public static MemberList Get(string name, int fellowship, int baptism, int subDivision, string regFrom, string regto)
        {
            return DataPortal.Fetch<MemberList>(
               new filterCriteria(name, fellowship, baptism, subDivision, regFrom, regto));
        }

        public static MemberList Get(int memberid)
        {
            return DataPortal.Fetch<MemberList>(new filterCriteria(memberid));
        }
        public static MemberList Get(string fullname, int subDivision)
        {

            return DataPortal.Fetch<MemberList>(new filterCriteria(fullname, subDivision));
        }
        public static MemberList Get(string fromRegDate, string toRegDate)
        {

            return DataPortal.Fetch<MemberList>(new filterCriteria(fromRegDate, toRegDate));
        }

        [Serializable()]
        private class filterCriteria
        {

            private int _memberid = 0;
            private string _fullname = string.Empty;
            private string _enFirstName = string.Empty;
            private string _enLastName = string.Empty;
            private string _firstname = string.Empty;
            private string _lastname = string.Empty;
            private int _fellowship = 0;
            private int _agefrom = 0;
            private int _ageto = 0;
            private string _state = string.Empty;
            private string _city = string.Empty;
            private int _sex = -1;
            private SmartDate _regfrom = new SmartDate(false);
            private SmartDate _regto = new SmartDate(false);
            private int _status = 0;
            private SmartDate _bapfrom = new SmartDate(false);
            private SmartDate _bapto = new SmartDate(false);
            private int _baptism = 0;
            private int _married = -1;
            private int _subdiv = 0;
            private int _relationship = 0;
            private int _jobtype = 0;
            private SmartDate _brithfrom = new SmartDate(false);
            private SmartDate _brithto = new SmartDate(false);
            private int _active = -1;
            private string _cellphone = string.Empty;
            private string _home = string.Empty;

            public int MemberId { get {return _memberid;}}
            public string EnLastName { get { return _enLastName; } }
            public string EnFirstName { get { return _enFirstName; } }
            public string FullName { get { return _fullname; } }
            public int Fellowship { get { return _fellowship; } }
            public string Lastname { get { return _lastname; } }
            public string Firstname { get { return _firstname; } }
            public string State { get { return _state; } }
            public string City { get { return _city; } }
            public int AgeFrom { get { return _agefrom; } }
            public int AgeTo { get { return _ageto; } }
            public int Sex { get { return _sex; } }
            public int Married { get { return _married; } }
            public SmartDate RegDateFrom { get { return _regfrom; } }
            public SmartDate RegDateTo { get { return _regto; } }
            public SmartDate BirthdayFrom { get { return _brithfrom; } }
            public SmartDate BirthdayTo { get { return _brithto; } }
            public int Status { get { return _status; } }
            public SmartDate BaptismFrom { get { return _bapfrom; } }
            public SmartDate BaptismTo { get { return _bapto; } }
            public int BaptismId { get { return _baptism; } }
            public int SubDivision { get { return _subdiv; } }
            public int Relationship { get { return _relationship; } }
            public int JobType { get { return _jobtype; } }
            public int Active { get { return _active; } }
            public string CellPhone { get { return  _cellphone; } }
            public string Home { get { return _home; } }


            public filterCriteria(int memberid)
            {
                _memberid = memberid;
            }

            public filterCriteria(string fullname, int subDivision)
            {
                _fullname = fullname;
                _subdiv = subDivision;
            }

            public filterCriteria(string fromRegDate, string toRegDate)
            {

                _regfrom.Text = fromRegDate;
                _regto.Text = toRegDate;
            }
            public filterCriteria(string name ,int fellowship, int baptism, int subDivision, string regFrom, string regTo)
            {
                _fullname = name;
                _fellowship = fellowship;
                _baptism = baptism;
                _subdiv = subDivision;
                _regfrom.Text = regFrom;
                _regto.Text = regTo;
            }
            public filterCriteria
                (
                 string last, string first, string enlast, string enfirst, int fellowship, int agefrom, 
                int ageto, string state, string city, int sex, string regfrom, string regto, int status, int baptism, string bapfrom, string bapto, 
                int married, int subdiv, int relationship, int jobtype, string birthfrom, string birthto, int active, string home, string cellphone
                )
            {
                _enFirstName = enfirst;
                _enLastName = enlast;
                _firstname = first;
                _lastname = last;
                _fellowship = fellowship;
                _agefrom = agefrom;
                _ageto = ageto;
                _state = state;
                _city = city;
                _sex = sex;
                _regfrom.Text = regfrom;
                _regto.Text = regto;
                _status = status;
                _baptism = baptism;
                _bapfrom.Text = bapfrom;
                _bapto.Text = bapto;
                _married = married;
                _subdiv = subdiv;
                _jobtype = jobtype;
                _relationship = relationship;
                _brithfrom.Text = birthfrom;
                _brithto.Text = birthto;
                _active = active;
                _home = home;
                _cellphone = cellphone;
            }
        }

      
        private void DataPortal_Fetch(filterCriteria criteria)
        {
            using (SqlConnection cn = new SqlConnection(Database.ConnectionString))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "[app_member].[member_list]";
                    cm.Parameters.AddWithValue("@memberid", criteria.MemberId);
                    cm.Parameters.AddWithValue("@fullname", criteria.FullName);
                    cm.Parameters.AddWithValue("@lastName", criteria.Lastname);
                    cm.Parameters.AddWithValue("@enlastname", criteria.EnLastName);
                    cm.Parameters.AddWithValue("@firstname", criteria.Firstname);
                    cm.Parameters.AddWithValue("@enfirstname", criteria.EnFirstName);
                    cm.Parameters.AddWithValue("@married", criteria.Married);
                    cm.Parameters.AddWithValue("@agefrom", criteria.AgeFrom);
                    cm.Parameters.AddWithValue("@ageto", criteria.AgeTo);
                    cm.Parameters.AddWithValue("@city", criteria.City);
                    cm.Parameters.AddWithValue("@state", criteria.State);
                    cm.Parameters.AddWithValue("@status", criteria.Status);
                    cm.Parameters.AddWithValue("@regfrom", criteria.RegDateFrom.DBValue);
                    cm.Parameters.AddWithValue("@regto", criteria.RegDateTo.DBValue);
                    cm.Parameters.AddWithValue("@baptismfrom", criteria.BaptismFrom.DBValue);
                    cm.Parameters.AddWithValue("@baptismto", criteria.BaptismTo.DBValue);
                    cm.Parameters.AddWithValue("@birthfrom", criteria.BirthdayFrom.DBValue);
                    cm.Parameters.AddWithValue("@birthto", criteria.BirthdayTo.DBValue);
                    cm.Parameters.AddWithValue("@baptismId", criteria.BaptismId);
                    cm.Parameters.AddWithValue("@sex", criteria.Sex);
                    cm.Parameters.AddWithValue("@subdivision", criteria.SubDivision);
                    cm.Parameters.AddWithValue("@relationship", criteria.Relationship);
                    cm.Parameters.AddWithValue("@jobtype", criteria.JobType);
                    cm.Parameters.AddWithValue("@active", criteria.Active);
                    cm.Parameters.AddWithValue("@fellowship", criteria.Fellowship);
                    cm.Parameters.AddWithValue("@cellPhone", criteria.CellPhone);
                    cm.Parameters.AddWithValue("@home", criteria.Home);
                    
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        IsReadOnly = false;
                        while (dr.Read())
                            this.Add(new MemberInfo(dr));
                        IsReadOnly = true;
                    }
                }
            }
        }
    }
}
