using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Dothan.Report;
using LandWin.Report.DataSet;
using LandWin.Report.DataAccess;
namespace LandWin.Report.Business
{
    public class bzMemberWithPic : BaseBusinessObject, IMemberWithPic<dsMemberWithPic>
    {
        public dsMemberWithPic GetMemberWithPic(string memberlist)
        {
            dsMemberWithPic ds = new dsMemberWithPic();
            ds = new daMemberReport().GetMemberWithPic(memberlist);
            return ds;
        }
    }
}
