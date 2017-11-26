using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Dothan.Report;
using LandWin.Report.DataSet;
using LandWin.Report.DataAccess;


namespace LandWin.Report.Business
{
    public class bzCellMemberByFamily : BaseBusinessObject, ICellMemberByFamily<dsCellMemberByFamily>
    {
        public dsCellMemberByFamily GetCellMemberByFamily(string memberlist)
        {
            dsCellMemberByFamily ds = new dsCellMemberByFamily();
            ds = new daCellReport().GetCellMemberByFamily(memberlist);
            return ds;
        }
    }
}
