using System;
using System.Data;
using System.Data.SqlClient;
using Dothan;
using Dothan.Data;

namespace Dothan.Library.bizMemberVisit
{
    [Serializable()]
    public class VisitReportList : ReadOnlyListBase<VisitReportList,VisitReportInfo>
    {
        public static VisitReportList Get(int memberid, string visitor, string from, string to, int cellcode, int visittype)
        {
            return DataPortal.Fetch<VisitReportList>(new Criteria(memberid, visitor, from, to, cellcode, visittype));
        }

       

        public static VisitReportList Get(string list)
        {
            return DataPortal.Fetch<VisitReportList>(new ListCriteria(list));
        }
        [Serializable()]
        private class ListCriteria
        {
            private string _list;
            public string Lists { get { return _list; } }
            public ListCriteria(string list)
            {
                _list = list;
            }
        }

        [Serializable()]
        private class Criteria
        {
            private string _username;
            private SmartDate _from;
            private SmartDate _to;
            private int _cellcode;
            private int _visittype;
            private int _memberid;

            public string Username { get { return _username; } }
            public SmartDate DateFrom { get { return _from; } }
            public SmartDate DateTo { get { return _to; } }
            public int CellCode { get { return _cellcode; } }
            public int visittype { get { return _visittype; } }
            public int Memberid { get { return _memberid; } }

            public Criteria(int memberid, string username, string from, string to, int cellcode, int visittype)
            {
                _memberid = memberid;
                _from.Text = from;
                _to.Text = to;
                _username = username;
                _cellcode = cellcode;
                _visittype = visittype;
            }
        }



        private void DataPortal_Fetch(ListCriteria criteria)
        {

            using (SqlConnection cn = new SqlConnection(Database.ConnectionString))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "[app_member].[visit_list_by_stringlist]";
                    cm.Parameters.AddWithValue("@list", criteria.Lists);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        IsReadOnly = false;
                        while (dr.Read())
                            this.Add(new VisitReportInfo(dr));
                        IsReadOnly = true;
                    }
                }
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
                    cm.CommandText = "[app_member].[visit_list]";
                    cm.Parameters.AddWithValue("@username", criteria.Username);
                    cm.Parameters.AddWithValue("@memberid", criteria.Memberid);
                    cm.Parameters.AddWithValue("@to", criteria.DateTo.DBValue);
                    cm.Parameters.AddWithValue("@from", criteria.DateFrom.DBValue);
                    cm.Parameters.AddWithValue("@visittype", criteria.visittype);
                    cm.Parameters.AddWithValue("@cellcode", criteria.CellCode);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        IsReadOnly = false;
                        while (dr.Read())
                            this.Add(new VisitReportInfo(dr));
                        IsReadOnly = true;

                    }
                }
            }
        }

    }
}
