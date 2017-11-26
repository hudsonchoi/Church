using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Dothan.Report;
using LandWin.Report.DataSet;
using LandWin.Report.DataAccess;

namespace LandWin.Report.Business
{
    public class bzMemberDetails : BaseBusinessObject, IMemberDetails<dsMemberDetails>
    {
        public dsMemberDetails GetMemberDetails(string list)
        {
            dsMemberDetails ds = new dsMemberDetails();
            ds = new daMemberReport().GetMemberDetails(list);
            return ds;
        }
    }
}

