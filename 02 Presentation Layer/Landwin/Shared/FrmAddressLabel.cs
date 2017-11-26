using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LandWin.Report;
using Dothan.Report.RemoteAccess;
using System.Data;

namespace LandWin
{
    class FrmAddressLabel
    {
        //private string _memberlist;
        //public string Memberlist
        //{
        //    get { return _memberlist; }
        //    set { _memberlist = value; }
        //}

        //public void RunAddressLabel()
        //{
        //    dsAddressLabel ds = this.GetPrint();
        //    this.PreviewReport(ds);
        //}
        //private void PreviewReport(dsAddressLabel ds)
        //{
        //    Rpt_AddressLabel rpt = new Rpt_AddressLabel();
        //    CrystalManager manager = new CrystalManager();
        //    manager.PushReportData(ds, rpt);
        //    manager.PreviewReport(rpt, "Donate Sheet");
        //}

        //private dsAddressLabel GetPrint()
        //{
        //    ClientRemoteAccess oRemoteAccess = new ClientRemoteAccess();
        //    oRemoteAccess.tInterface =
        //                  typeof(LandWin.Shared.Interface.IAddressLabel<>);
        //    oRemoteAccess.nConnectionType = Dothan.Report.RemoteAccess.ClientRemoteAccess.ConnectionTypeOptions.LocalAccess;
        //    oRemoteAccess.cServiceName = "LandWin.Business";
        //    oRemoteAccess.ReportName = "bzAddressLabel";
        //    object oReturnObject = oRemoteAccess.GetAccessObject();
        //    dsAddressLabel odsDonateSheet = new dsAddressLabel();


        //    IAddressLabel<dsAddressLabel> oDonateSheet;
        //    oDonateSheet = (IAddressLabel<dsAddressLabel>)oReturnObject;
        //    odsDonateSheet = oDonateSheet.GetAddressLabel(_memberlist.TrimEnd(','));


        //    return odsDonateSheet;

        //}

        //public void RunMemberAddressLabel()
        //{
        //    dsAddressLabel ds = this.GetMemberPrint();
        //    this.PreviewReportMember(ds);
        //}
        //private void PreviewReportMember(dsAddressLabel ds)
        //{
        //    Rpt_AddressLabel rpt = new Rpt_AddressLabel();
        //    CrystalManager manager = new CrystalManager();
        //    manager.PushReportData(ds, rpt);
        //    manager.PreviewReport(rpt, "Address Label");
        //}

        //private dsAddressLabel GetMemberPrint()
        //{
        //    ClientRemoteAccess oRemoteAccess = new ClientRemoteAccess();
        //    oRemoteAccess.tInterface =
        //                  typeof(LandWin.Shared.Interface.IMemberAddrssLabel<>);
        //    oRemoteAccess.nConnectionType = Dothan.Report.RemoteAccess.ClientRemoteAccess.ConnectionTypeOptions.LocalAccess;
        //    oRemoteAccess.cServiceName = "LandWin.Business";
        //    oRemoteAccess.ReportName = "bzMemberAddrssLabel";
        //    object oReturnObject = oRemoteAccess.GetAccessObject();
        //    dsAddressLabel odsDonateSheet = new dsAddressLabel();


        //    IMemberAddrssLabel<dsAddressLabel> oDonateSheet;
        //    oDonateSheet = (IMemberAddrssLabel<dsAddressLabel>)oReturnObject;
        //    odsDonateSheet = oDonateSheet.GetMemberAddrssLabel(_memberlist.TrimEnd(','));


        //    return odsDonateSheet;

        //}

    }
}
