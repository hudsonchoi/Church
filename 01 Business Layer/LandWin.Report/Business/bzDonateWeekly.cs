using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Dothan.Report;
using LandWin.Report.DataSet;
using LandWin.Report.DataAccess;

namespace LandWin.Report.Business
{
    public class bzDonateWeekly : BaseBusinessObject, IDonateWeekly<dsDonateWeekly>
    {
        public dsDonateWeekly GetDonateWeekly(string start, string end,int code)
        {
            dsDonateWeekly ds = new dsDonateWeekly();
            ds = new daDonateReport().GetDonateWeekly(start, end);
            return ds;
        }
    }
}
