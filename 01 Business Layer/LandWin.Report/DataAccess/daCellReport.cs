using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Dothan.Report;
using LandWin.Report.DataSet;

namespace LandWin.Report.DataAccess
{
    public class daCellReport: Dothan.Library.bizReport.ReportDataAccess
    {

        public dsCellMemberByFamily GetCellMemberByFamily(string memberlist)
        {
            List<SqlParameter> oParams = new List<SqlParameter>();

            oParams.Add(new SqlParameter("@list", memberlist));
            dsCellMemberByFamily ds = new dsCellMemberByFamily();
            ds = this.ReadIntoTypeDs(ds, "[app_report].[cell_family]", oParams);
            return ds;


        }
        public dsCellReport GetCellReportDetail(string cellreport)
        {
            List<SqlParameter> oParams = new List<SqlParameter>();

            oParams.Add(new SqlParameter("@list", cellreport));
            dsCellReport ds = new dsCellReport();
            ds = this.ReadIntoTypeDs(ds, "[app_report].[cell_report_print]", oParams);
            return ds;
        }
    }
}
