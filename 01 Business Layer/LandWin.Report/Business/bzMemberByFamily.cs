using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Dothan.Report;
using LandWin.Report.DataSet;
using LandWin.Report.DataAccess;

namespace LandWin.Report.Business
{
    public class bzMemberByFamily : BaseBusinessObject, IMemberByFamily<dsMemberByFamily>
    {
        public dsMemberByFamily GetMemberByFamily(string memberlist)
        {
            dsMemberByFamily ds = new dsMemberByFamily();
            ds = new daMemberReport().GetMemberByFamily(memberlist);
            return ds;
        }
    }

}