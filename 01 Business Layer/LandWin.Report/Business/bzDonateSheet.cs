using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Dothan.Report;
using LandWin.Report.DataSet;
using LandWin.Report.DataAccess;

namespace LandWin.Report.Business
{
    public class bzDonateSheet : BaseBusinessObject, IDonateSheet<dsDonateSheet>
    {
        public dsDonateSheet GetDonateSheet(string booklist)
        {
            dsDonateSheet ds = new dsDonateSheet();
            ds = new daDonateReport().GetDonateSheet(booklist);
            return ds;
        }
    }
}
