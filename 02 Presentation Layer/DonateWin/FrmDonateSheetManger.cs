using System;
using System.Collections.Generic;
using System.Linq;
using _report = LandWin.Report;
using LandWin.Report.DataSet;
using LandWin.Report.DataAccess;
using System.Data;

namespace DonateWin
{
    public class FrmDonateSheetManger
    {
        public void RunDonateSheet(string list)
        {
            _report.DataSet.dsDonateSheet ds = GetDonateSheet(list);
            _report.CrystalReport.Rpt_DonateSheet rpt = new LandWin.Report.CrystalReport.Rpt_DonateSheet();
            _report.CrystalReportTools.CrystalManager manager = new LandWin.Report.CrystalReportTools.CrystalManager();
            manager.PushReportData(ds, rpt);
            manager.PreviewReport(rpt, "Donate Sheet");

        }

        private dsDonateSheet GetDonateSheet(string list)
        {
            Dothan.Report.RemoteAccess.ClientRemoteAccess oRemoteAccess = new Dothan.Report.RemoteAccess.ClientRemoteAccess();
            oRemoteAccess.tInterface = typeof(IDonateSheet<>);
            oRemoteAccess.nConnectionType = Dothan.Report.RemoteAccess.ClientRemoteAccess.ConnectionTypeOptions.LocalAccess;
            oRemoteAccess.cServiceName = "LandWin.Report";
            oRemoteAccess.ReportName = "bzDonateSheet";
            object oReturnObject = oRemoteAccess.GetAccessObject();
            dsDonateSheet odsSheet = new dsDonateSheet();
            IDonateSheet<dsDonateSheet> oSheet = (IDonateSheet<dsDonateSheet>)oReturnObject;
            odsSheet = oSheet.GetDonateSheet(list.TrimEnd(','));
            return odsSheet;

        }
    }
}
