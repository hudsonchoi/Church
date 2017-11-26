using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Dothan.Report;
using LandWin.Report.DataSet;
using LandWin.Report.DataAccess;

namespace LandWin.Report.Business
{
    public class bzAddressLabel : BaseBusinessObject, IAddressLabel<dsAddressLabel>
    {
        public dsAddressLabel GetAddressLabelFamily(string memberlist)
        {
            dsAddressLabel ds = new dsAddressLabel();
           
            ds = new daMemberReport().GetFamilyAddressLabel(memberlist);
            return ds;
        }

        public dsAddressLabel GetAddressLabelMember(string memberlist)
        {
            dsAddressLabel ds = new dsAddressLabel();
            ds = new daMemberReport().GetMemberAddressLabel(memberlist);
            return ds;
        }
    }
}
