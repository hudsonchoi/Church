using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Dothan.Report;
using LandWin.Report.DataSet;
using LandWin.Report.DataAccess;

namespace LandWin.Report.Business
{
    public class bzFamilyList : BaseBusinessObject, IFamilyList<dsFamilyList>
    {
        public dsFamilyList GetFamilyList(string memberlist)
        {
            dsFamilyList ds = new dsFamilyList();
            ds = new daMemberReport().GetFamilyList(memberlist);
            return ds;
        }
    }
}
