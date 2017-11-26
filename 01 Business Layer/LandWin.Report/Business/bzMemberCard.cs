using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Dothan.Report;
using LandWin.Report.DataSet;
using LandWin.Report.DataAccess;

namespace LandWin.Report.Business
{
    public class bzMemberCard : BaseBusinessObject, IMemberCard<dsMemberCard>
    {
        public dsMemberCard GetMemberCard(string list)
        {
            dsMemberCard ds = new dsMemberCard();
            ds = new daMemberReport().GetMemberCard(list);
            return ds;
        }
    }

}