using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Dothan.Report;
using LandWin.Report.DataSet;
using LandWin.Report.DataAccess;

namespace LandWin.Report.Business
{
    public class bzVisitReport : BaseBusinessObject, IVisitReport<dsVisitReport>
    {
        public dsVisitReport GetVisitReport(string list)
        {
            dsVisitReport ds = new dsVisitReport();
            ds = new daVisitReport().GetVisitReport(list);
            return ds;
        }
    }

}