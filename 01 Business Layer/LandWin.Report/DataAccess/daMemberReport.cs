using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Dothan.Report;
using LandWin.Report.DataSet;

namespace LandWin.Report.DataAccess
{
    public class daMemberReport : Dothan.Library.bizReport.ReportDataAccess
    {

        public dsAddressLabel GetMemberAddressLabel(string memberlist)
        {
            List<SqlParameter> oParams = new List<SqlParameter>();

            oParams.Add(new SqlParameter("@memberlist", memberlist));
            dsAddressLabel ds = new dsAddressLabel();
            ds = this.ReadIntoTypeDs(ds, "[app_report].[addresslabel_member]", oParams);
            return ds;
        }

        public dsAddressLabel GetFamilyAddressLabel(string memberlist)
        {
            List<SqlParameter> oParams = new List<SqlParameter>();

            oParams.Add(new SqlParameter("@memberlist", memberlist));
            dsAddressLabel ds = new dsAddressLabel();
            ds = this.ReadIntoTypeDs(ds, "[app_report].[addresslabel_family]", oParams);
            return ds;
        }

        public dsAddressBook GetFamilyAddressBook(string memberlist)
        {
            List<SqlParameter> oParams = new List<SqlParameter>();

            oParams.Add(new SqlParameter("@memberlist", memberlist));
            dsAddressBook ds = new dsAddressBook();
            ds = this.ReadIntoTypeDs(ds, "[app_report].[addressbook_family]", oParams);
            return ds;
        }

        public dsAddressBook GetMemberAddressBook(string memberlist)
        {
            List<SqlParameter> oParams = new List<SqlParameter>();

            oParams.Add(new SqlParameter("@memberlist", memberlist));
            dsAddressBook ds = new dsAddressBook();
            ds = this.ReadIntoTypeDs(ds, "[app_report].[addressbook_member]", oParams);
            return ds;
        }

        public dsMemberWithPic GetMemberWithPic(string memberlist)
        {
            List<SqlParameter> oParams = new List<SqlParameter>();

            oParams.Add(new SqlParameter("@memberlist", memberlist));
            dsMemberWithPic ds = new dsMemberWithPic();
            ds = this.ReadIntoTypeDs(ds, "[app_report].[member_wPicture]", oParams);
            return ds;
        }
        public dsMemberByFamily GetMemberByFamily(string memberlist)
        {
            List<SqlParameter> oParams = new List<SqlParameter>();

            oParams.Add(new SqlParameter("@memberlist", memberlist));
            dsMemberByFamily ds = new dsMemberByFamily();
            ds = this.ReadIntoTypeDs(ds, "[app_report].[member_family]", oParams);
            return ds;
        }
     
        public dsStatusReport GetStatusReport(string list)
        {
            List<SqlParameter> oParams = new List<SqlParameter>();

            oParams.Add(new SqlParameter("@list", list));
            dsStatusReport ds = new dsStatusReport();
            ds = this.ReadIntoTypeDs(ds, "[app_report].[status]", oParams);
            return ds;
        }
        public dsStatusFamily GetStatusFamily(string list)
        {
            List<SqlParameter> oParams = new List<SqlParameter>();

            oParams.Add(new SqlParameter("@list", list));
            dsStatusFamily ds = new dsStatusFamily();
            ds = this.ReadIntoTypeDs(ds, "[app_report].[status_family]", oParams);
            return ds;
        }
        public dsMemberCard GetMemberCard(string list)
        {
            List<SqlParameter> oParams = new List<SqlParameter>();

            oParams.Add(new SqlParameter("@memberlist", list));
            dsMemberCard ds = new dsMemberCard();
            ds = this.ReadIntoTypeDs(ds, "[app_report].[member_card]", oParams);
            return ds;
        }

        public dsMemberDetails GetMemberDetails(string list)
        {
            List<SqlParameter> oParams = new List<SqlParameter>();

            oParams.Add(new SqlParameter("@memberlist", list));
            dsMemberDetails ds = new dsMemberDetails();
            ds = this.ReadIntoTypeDs(ds, "[app_report].[member_details]", oParams);
            return ds;
        }

        public dsFamilyList GetFamilyList(string list)
        {
            List<SqlParameter> oParams = new List<SqlParameter>();

            oParams.Add(new SqlParameter("@memberlist", list));
            dsFamilyList ds = new dsFamilyList();
            ds = this.ReadIntoTypeDs(ds, "[app_report].[family_list]", oParams);
            return ds;
        }
    }
}
