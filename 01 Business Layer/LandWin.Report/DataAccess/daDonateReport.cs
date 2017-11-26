using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Dothan.Report;
using LandWin.Report.DataSet;

namespace LandWin.Report.DataAccess
{
    public class daDonateReport : Dothan.Library.bizReport.ReportDataAccess
    {
        public dsDonateSheet GetDonateSheet(string booklist)
        {
            List<SqlParameter> oParams = new List<SqlParameter>();

            oParams.Add(new SqlParameter("@list",booklist));

            dsDonateSheet ds = new dsDonateSheet();
            ds = this.ReadIntoTypeDs(ds, "[app_report].[donate_sheet]", oParams);
            return ds;
        }

        public dsDonateWeekly GetDonateWeekly(string start, string end)
        {
            List<SqlParameter> oParams = new List<SqlParameter>();
            oParams.Add(new SqlParameter("@startdate", start));
            oParams.Add(new SqlParameter("@enddate", end));
            dsDonateWeekly ds = new dsDonateWeekly();
            ds = this.ReadIntoTypeDs(ds, "[app_report].[donate_weekly]", oParams);
            return ds;
        }

        public dsDonateSumByTypes GetDonateSumByTypes(string start, string end)
        {
            List<SqlParameter> oParams = new List<SqlParameter>();

            oParams.Add(new SqlParameter("@startdate", start));
            oParams.Add(new SqlParameter("@enddate", end));
            dsDonateSumByTypes ds = new dsDonateSumByTypes();
            ds = this.ReadIntoTypeDs(ds, "[app_report].[donate_weekly_summary]", oParams);
            return ds;
        }


        public dsMemberDonate GetMemberDonate(int list, int year ,bool family)
        {
            List<SqlParameter> oParams = new List<SqlParameter>();

            oParams.Add(new SqlParameter("@donateid", list));
            oParams.Add(new SqlParameter("@year",  year));
            oParams.Add(new SqlParameter("@family", family));
            dsMemberDonate ds = new dsMemberDonate();
            ds = this.ReadIntoTypeDs(ds, "[app_report].[member_donate]", oParams);
            return ds;
        }
        
    }
}
