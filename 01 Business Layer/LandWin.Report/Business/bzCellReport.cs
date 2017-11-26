using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Dothan.Report;
using LandWin.Report.DataSet;
using LandWin.Report.DataAccess;


namespace LandWin.Report.Business
{
    public class bzCellReport : BaseBusinessObject,ICellReport<dsCellReport>
    {
        public dsCellReport GetCellReportDetail(string cellreport)
        {
            dsCellReport ds = new dsCellReport();
            ds = new daCellReport().GetCellReportDetail(cellreport);
            return ds;
        }
    }
}
