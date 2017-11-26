using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Dothan.Report;
using LandWin.Report.DataSet;
using LandWin.Report.DataAccess;
namespace LandWin.Report.Business
{
    public class bzMemberDonate : BaseBusinessObject, IMemberDonate<dsMemberDonate>
    {
        public dsMemberDonate GetMemberDonate(int list, int year,bool family)
        {
            dsMemberDonate ds = new dsMemberDonate();
            ds = new daDonateReport().GetMemberDonate(list, year,family);
            return ds;
        }
    }

}