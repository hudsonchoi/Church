using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Dothan.Report;
using LandWin.Report.DataSet;
using LandWin.Report.DataAccess;

namespace LandWin.Report.Business
{
    public class bzMemberVisit : BaseBusinessObject, IMemberVisit<dsMemberVisit>
    {
        public dsMemberVisit GetMemberVisit(string list)
        {
            dsMemberVisit ds = new dsMemberVisit();
            ds = new daVisitReport().GetMemberVisitReport(list);
            return ds;
        }
    }

}