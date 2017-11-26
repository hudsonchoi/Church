using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LandWin
{
    class FrmDonateWeeklyManger
    {
        //private string _start;
        //private string _end;


        //public void RunDonateSumByTypes(string start, string end)
        //{
        //    _start = start;
        //    _end = end;
        //    dsDonateSumByTypes ds = this.GetDonateSumByTypes();
        //    this.PreviewReportDonateSumByTypes(ds);
        //}
        //private void PreviewReportDonateSumByTypes(dsDonateSumByTypes ds)
        //{
        //    Rpt_DonateWeekly rpt = new Rpt_DonateWeekly();
        //    CrystalManager manager = new CrystalManager();
        //    manager.PushReportData(ds, rpt);
        //    manager.PreviewReport(rpt, "Donate Weekly");
        //}
        //private dsDonateSumByTypes GetDonateSumByTypes()
        //{
        //    ClientRemoteAccess oRemoteAccess = new ClientRemoteAccess();
        //    oRemoteAccess.tInterface =
        //                  typeof(LandWin.Shared.Interface.IDonateWeekly<>);
        //    oRemoteAccess.nConnectionType = Dothan.Report.RemoteAccess.ClientRemoteAccess.ConnectionTypeOptions.LocalAccess;
        //    oRemoteAccess.cServiceName = "LandWin.Business";
        //    oRemoteAccess.ReportName = "bzDonateSumByTypes";

        //    dsDonateSumByTypes odsDonateSheet = new dsDonateSumByTypes();



        //    object oReturnObject = oRemoteAccess.GetAccessObject();
        //    IDonateSumByTypes<dsDonateSumByTypes> oDonateSheet;
        //    oDonateSheet = (IDonateSumByTypes<dsDonateSumByTypes>)oReturnObject;
        //    odsDonateSheet = oDonateSheet.GetDonateSumByTypes(_start, _end);


        //    return odsDonateSheet;

        //}


        //private void PreviewReport(dsDonateWeekly ds)
        //{
        //     Rpt_DonateWeekly rpt = new Rpt_DonateWeekly();
        //     CrystalManager manager = new CrystalManager();
        //     manager.PushReportData(ds, rpt);
        //     manager.PreviewReport(rpt, "Donate Weekly");
        //}
        //public void RunDonateWeeklyDetail(string start, string end, int code)
        //{
        //    dsDonateWeekly ds = this.GetDonateWeekly(start , end , code );
        //    Rpt_DonateWeeklyDetail rpt = new Rpt_DonateWeeklyDetail();
        //    CrystalManager manager = new CrystalManager();
        //    manager.PushReportData(ds, rpt);
        //    manager.PreviewReport(rpt, "Donate Weekly");
        //}
        //private dsDonateWeekly GetDonateWeekly(string start, string end, int code)
        //{
        //    ClientRemoteAccess oRemoteAccess = new ClientRemoteAccess();
        //    oRemoteAccess.tInterface =
        //                  typeof(LandWin.Shared.Interface.IDonateWeekly<>);
        //    oRemoteAccess.nConnectionType = Dothan.Report.RemoteAccess.ClientRemoteAccess.ConnectionTypeOptions.LocalAccess;
        //    oRemoteAccess.cServiceName = "LandWin.Business";
        //     oRemoteAccess.ReportName="bzDonateWeekly";
          
        //    dsDonateWeekly odsDonateSheet = new dsDonateWeekly();
         


        //    object oReturnObject = oRemoteAccess.GetAccessObject();
        //    IDonateWeekly<dsDonateWeekly> oDonateSheet;
        //    oDonateSheet = (IDonateWeekly<dsDonateWeekly>)oReturnObject;
        //    odsDonateSheet = oDonateSheet.GetDonateWeekly(start,end,code);


        //    return odsDonateSheet;

        //}
    }
}