using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Dothan.Report;
using LandWin.Report.DataSet;
using LandWin.Report.DataAccess;

namespace LandWin.Report.Business
{
    public class bzStatusList : BaseBusinessObject, IStatusReport<dsStatusReport>
    {
        public dsStatusReport GetStatusReport(string list)
        {
            dsStatusReport ds = new dsStatusReport();
            ds = new daMemberReport().GetStatusReport(list);
            return ds;
        }
    }

}