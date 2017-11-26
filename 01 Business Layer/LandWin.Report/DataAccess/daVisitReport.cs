using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Dothan.Report;
using LandWin.Report.DataSet;

namespace LandWin.Report.DataAccess
{
    public class  daVisitReport: Dothan.Library.bizReport.ReportDataAccess
    {
        public dsVisitReport GetVisitReport(string list)
        {
            List<SqlParameter> oParams = new List<SqlParameter>();

            oParams.Add(new SqlParameter("@list", list));
            dsVisitReport ds = new dsVisitReport();
            ds = this.ReadIntoTypeDs(ds, "[app_report].[visit_list]", oParams);
            return ds;
        }

        public dsMemberVisit GetMemberVisitReport(string list)
        {
            List<SqlParameter> oParams = new List<SqlParameter>();

            oParams.Add(new SqlParameter("@list", list));
            dsMemberVisit ds = new dsMemberVisit();
            ds = this.ReadIntoTypeDs(ds, "[app_report].[member_visit]", oParams);
            return ds;
        }
    }
}
