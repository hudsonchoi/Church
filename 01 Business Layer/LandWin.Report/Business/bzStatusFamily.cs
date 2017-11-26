using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Dothan.Report;
using LandWin.Report.DataSet;
using LandWin.Report.DataAccess;
namespace LandWin.Report.Business
{
    public class bzStatusFamily : BaseBusinessObject, IStatusFamily<dsStatusFamily>
    {
        public dsStatusFamily GetStatusFamily(string list)
        {
            dsStatusFamily ds = new dsStatusFamily();
            ds = new daMemberReport().GetStatusFamily(list);
            return ds;
        }
    }
}
