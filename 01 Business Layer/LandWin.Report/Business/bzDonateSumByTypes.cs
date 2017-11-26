using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Dothan.Report;
using LandWin.Report.DataSet;
using LandWin.Report.DataAccess;

namespace LandWin.Report.Business
{
    public class bzDonateSumByTypes : BaseBusinessObject, IDonateSumByTypes<dsDonateSumByTypes>
    {
        public dsDonateSumByTypes GetDonateSumByTypes(string start, string end)
        {
            dsDonateSumByTypes ds = new dsDonateSumByTypes();
            ds = new daDonateReport().GetDonateSumByTypes(start, end);
            return ds;
        }
    }
}