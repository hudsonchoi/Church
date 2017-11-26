using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _report = LandWin.Report;
using LandWin.Report.DataSet;
using LandWin.Report.DataAccess;
using System.Data;
using System.IO;
using LandWin.Properties;

namespace LandWin.Shared
{
    public class ReprotManager
    {

        #region Print Member 
        public void PrintAddressLabel(string memberlist, bool isfamily)
        {
            if (string.IsNullOrEmpty(memberlist))
            {
                return;
            }
            _report.DataSet.dsAddressLabel ds = GetAddressLabel(memberlist, isfamily);
            _report.CrystalReport.Rpt_AddressLabel rpt = new LandWin.Report.CrystalReport.Rpt_AddressLabel();
            _report.CrystalReportTools.CrystalManager manager = new LandWin.Report.CrystalReportTools.CrystalManager();
            manager.PushReportData(ds, rpt);
            manager.PreviewReport(rpt, "Address Label");
          
        }

        private dsAddressLabel GetAddressLabel(string memberlist , bool isfamily)
        {
            Dothan.Report.RemoteAccess.ClientRemoteAccess oRemoteAccess = new Dothan.Report.RemoteAccess.ClientRemoteAccess();
            oRemoteAccess.tInterface = typeof(IAddressLabel<>);
            oRemoteAccess.nConnectionType = Dothan.Report.RemoteAccess.ClientRemoteAccess.ConnectionTypeOptions.LocalAccess;
            oRemoteAccess.cServiceName = "LandWin.Report";
            oRemoteAccess.ReportName = "bzAddressLabel";
            object oReturnObject = oRemoteAccess.GetAccessObject();
            dsAddressLabel odsSheet = new dsAddressLabel();
            IAddressLabel<dsAddressLabel> oSheet = (IAddressLabel<dsAddressLabel>)oReturnObject;
            
            if(isfamily)
                odsSheet = oSheet.GetAddressLabelFamily(memberlist.TrimEnd(','));
            else 
                odsSheet = oSheet.GetAddressLabelMember(memberlist.TrimEnd(','));
            return odsSheet;

        }

        


        public void PrintMemberAddressBook(string memberlist)
        {
            if (string.IsNullOrEmpty(memberlist))
            {
                return;
            }
            _report.DataSet.dsAddressBook ds = GetMemberAddressBook(memberlist);
            _report.CrystalReport.Rpt_AddressLabel rpt = new LandWin.Report.CrystalReport.Rpt_AddressLabel();
            _report.CrystalReportTools.CrystalManager manager = new LandWin.Report.CrystalReportTools.CrystalManager();
            manager.PushReportData(ds, rpt);
            manager.PreviewReport(rpt, "Address Label");

        }

        private dsAddressBook GetMemberAddressBook(string memberlist)
        {
            Dothan.Report.RemoteAccess.ClientRemoteAccess oRemoteAccess = new Dothan.Report.RemoteAccess.ClientRemoteAccess();
            oRemoteAccess.tInterface = typeof(IAddressBook<>);
            oRemoteAccess.nConnectionType = Dothan.Report.RemoteAccess.ClientRemoteAccess.ConnectionTypeOptions.LocalAccess;
            oRemoteAccess.cServiceName = "LandWin.Report";
            oRemoteAccess.ReportName = "bzAddressBook";
            object oReturnObject = oRemoteAccess.GetAccessObject();
            dsAddressBook odsSheet = new dsAddressBook();
            IAddressBook<dsAddressBook> oSheet = (IAddressBook<dsAddressBook>)oReturnObject;
            odsSheet = oSheet.GetMemberAddressBook(memberlist.TrimEnd(','));
            return odsSheet;

        }
        public void PrintFamilyAddressBook(string memberlist)
        {
            if (string.IsNullOrEmpty(memberlist))
            {
                return;
            }
            _report.DataSet.dsAddressBook ds = GetFamilyAddressBook(memberlist);
            _report.CrystalReport.Rpt_FamilyAddressBook rpt = new LandWin.Report.CrystalReport.Rpt_FamilyAddressBook();
            _report.CrystalReportTools.CrystalManager manager = new LandWin.Report.CrystalReportTools.CrystalManager();
            manager.PushReportData(ds, rpt);
            manager.PreviewReport(rpt, "Address Label");

        }

        private dsAddressBook GetFamilyAddressBook(string memberlist)
        {
            Dothan.Report.RemoteAccess.ClientRemoteAccess oRemoteAccess = new Dothan.Report.RemoteAccess.ClientRemoteAccess();
            oRemoteAccess.tInterface = typeof(IAddressBook<>);
            oRemoteAccess.nConnectionType = Dothan.Report.RemoteAccess.ClientRemoteAccess.ConnectionTypeOptions.LocalAccess;
            oRemoteAccess.cServiceName = "LandWin.Report";
            oRemoteAccess.ReportName = "bzAddressBook";
            object oReturnObject = oRemoteAccess.GetAccessObject();
            dsAddressBook odsSheet = new dsAddressBook();
            IAddressBook<dsAddressBook> oSheet = (IAddressBook<dsAddressBook>)oReturnObject;
            odsSheet = oSheet.GetFamilyAddressBook(memberlist.TrimEnd(','));
            return odsSheet;

        }


        public void PrintMemberWithPic(string memberlist)
        {
            if (string.IsNullOrEmpty(memberlist))
            {
                return;
            }
            _report.DataSet.dsMemberWithPic ds = GetMemberWithPic(memberlist);
            FetchPicture(ds);
            _report.CrystalReport.Rpt_MemberWithPic rpt = new LandWin.Report.CrystalReport.Rpt_MemberWithPic();
            _report.CrystalReportTools.CrystalManager manager = new LandWin.Report.CrystalReportTools.CrystalManager();
            manager.PushReportData(ds, rpt);
            manager.PreviewReport(rpt, "Member With Picture");

        }

        private dsMemberWithPic GetMemberWithPic(string memberlist)
        {
            Dothan.Report.RemoteAccess.ClientRemoteAccess oRemoteAccess = new Dothan.Report.RemoteAccess.ClientRemoteAccess();
            oRemoteAccess.tInterface = typeof(IMemberWithPic<>);
            oRemoteAccess.nConnectionType = Dothan.Report.RemoteAccess.ClientRemoteAccess.ConnectionTypeOptions.LocalAccess;
            oRemoteAccess.cServiceName = "LandWin.Report";
            oRemoteAccess.ReportName = "bzMemberWithPic";
            object oReturnObject = oRemoteAccess.GetAccessObject();
            dsMemberWithPic odsSheet = new dsMemberWithPic();
            IMemberWithPic<dsMemberWithPic> oSheet = (IMemberWithPic<dsMemberWithPic>)oReturnObject;
            odsSheet = oSheet.GetMemberWithPic(memberlist.TrimEnd(','));
            return odsSheet;

        }

        public void PrintMemberByFamily(string memberlist)
        {
            if (string.IsNullOrEmpty(memberlist))
            {
                return;
            }
            _report.DataSet.dsMemberByFamily ds = GetMemberByFamily(memberlist);
            FetchPicture(ds,1);
            _report.CrystalReport.Rpt_MemberByFamily rpt = new LandWin.Report.CrystalReport.Rpt_MemberByFamily();
            _report.CrystalReportTools.CrystalManager manager = new LandWin.Report.CrystalReportTools.CrystalManager();
            manager.PushReportData(ds, rpt);
            manager.PreviewReport(rpt, "Member With Family");

        }

        private dsMemberByFamily GetMemberByFamily(string memberlist)
        {
            Dothan.Report.RemoteAccess.ClientRemoteAccess oRemoteAccess = new Dothan.Report.RemoteAccess.ClientRemoteAccess();
            oRemoteAccess.tInterface = typeof(IMemberByFamily<>);
            oRemoteAccess.nConnectionType = Dothan.Report.RemoteAccess.ClientRemoteAccess.ConnectionTypeOptions.LocalAccess;
            oRemoteAccess.cServiceName = "LandWin.Report";
            oRemoteAccess.ReportName = "bzMemberByFamily";
            object oReturnObject = oRemoteAccess.GetAccessObject();
            dsMemberByFamily odsSheet = new dsMemberByFamily();
            IMemberByFamily<dsMemberByFamily> oSheet = (IMemberByFamily<dsMemberByFamily>)oReturnObject;
            odsSheet = oSheet.GetMemberByFamily(memberlist.TrimEnd(','));
            return odsSheet;

        }

        public void PrintMemberCard(string memberlist)
        {
            if (string.IsNullOrEmpty(memberlist))
            {
                return;
            }
            _report.DataSet.dsMemberCard ds = GetMemberCard(memberlist);
            FetchPicture(ds);
            _report.CrystalReport.Rpt_MemberCards rpt = new LandWin.Report.CrystalReport.Rpt_MemberCards();
            _report.CrystalReportTools.CrystalManager manager = new LandWin.Report.CrystalReportTools.CrystalManager();
            manager.PushReportData(ds, rpt);
            manager.PreviewReport(rpt, "Member Card");

        }

        private dsMemberCard GetMemberCard(string memberlist)
        {
            Dothan.Report.RemoteAccess.ClientRemoteAccess oRemoteAccess = new Dothan.Report.RemoteAccess.ClientRemoteAccess();
            oRemoteAccess.tInterface = typeof(IMemberCard<>);
            oRemoteAccess.nConnectionType = Dothan.Report.RemoteAccess.ClientRemoteAccess.ConnectionTypeOptions.LocalAccess;
            oRemoteAccess.cServiceName = "LandWin.Report";
            oRemoteAccess.ReportName = "bzMemberCard";
            object oReturnObject = oRemoteAccess.GetAccessObject();
            dsMemberCard odsSheet = new dsMemberCard();
            IMemberCard<dsMemberCard> oSheet = (IMemberCard<dsMemberCard>)oReturnObject;
            odsSheet = oSheet.GetMemberCard(memberlist.TrimEnd(','));
            return odsSheet;

        }


        public void PrintMemberDetails(string memberlist)
        {
            if (string.IsNullOrEmpty(memberlist))
            {
                return;
            }
            _report.DataSet.dsMemberDetails ds = GetMemberDetails(memberlist);
            FetchPicture(ds);
            _report.CrystalReport.Rpt_MemberDetail rpt = new LandWin.Report.CrystalReport.Rpt_MemberDetail();
            _report.CrystalReportTools.CrystalManager manager = new LandWin.Report.CrystalReportTools.CrystalManager();
            manager.PushReportData(ds, rpt);
            manager.PreviewReport(rpt, "Member Details Report");

        }

        private dsMemberDetails GetMemberDetails(string memberlist)
        {
            Dothan.Report.RemoteAccess.ClientRemoteAccess oRemoteAccess = new Dothan.Report.RemoteAccess.ClientRemoteAccess();
            oRemoteAccess.tInterface = typeof(IMemberDetails<>);
            oRemoteAccess.nConnectionType = Dothan.Report.RemoteAccess.ClientRemoteAccess.ConnectionTypeOptions.LocalAccess;
            oRemoteAccess.cServiceName = "LandWin.Report";
            oRemoteAccess.ReportName = "bzMemberDetails";
            object oReturnObject = oRemoteAccess.GetAccessObject();
            dsMemberDetails odsSheet = new dsMemberDetails();
            IMemberDetails<dsMemberDetails> oSheet = (IMemberDetails<dsMemberDetails>)oReturnObject;
            odsSheet = oSheet.GetMemberDetails(memberlist.TrimEnd(','));
            return odsSheet;

        }

        public void PrintFamilyList(string memberlist)
        {
            if (string.IsNullOrEmpty(memberlist))
            {
                return;
            }
            _report.DataSet.dsFamilyList ds = GetFamilyList(memberlist);
            _report.CrystalReport.Rpt_FamilyList rpt = new LandWin.Report.CrystalReport.Rpt_FamilyList();
            _report.CrystalReportTools.CrystalManager manager = new LandWin.Report.CrystalReportTools.CrystalManager();
            manager.PushReportData(ds, rpt);
            manager.PreviewReport(rpt, "Family Report");

        }

        private dsFamilyList GetFamilyList(string memberlist)
        {
            Dothan.Report.RemoteAccess.ClientRemoteAccess oRemoteAccess = new Dothan.Report.RemoteAccess.ClientRemoteAccess();
            oRemoteAccess.tInterface = typeof(IFamilyList<>);
            oRemoteAccess.nConnectionType = Dothan.Report.RemoteAccess.ClientRemoteAccess.ConnectionTypeOptions.LocalAccess;
            oRemoteAccess.cServiceName = "LandWin.Report";
            oRemoteAccess.ReportName = "bzFamilyList";
            object oReturnObject = oRemoteAccess.GetAccessObject();
            dsFamilyList odsSheet = new dsFamilyList();
            IFamilyList<dsFamilyList> oSheet = (IFamilyList<dsFamilyList>)oReturnObject;
            odsSheet = oSheet.GetFamilyList(memberlist.TrimEnd(','));
            return odsSheet;

        }

        #endregion



        #region Status Report
        public void PrintStatusFamily(string memberlist)
        {
            if (string.IsNullOrEmpty(memberlist))
            {
                return;
            }
            _report.DataSet.dsStatusFamily ds = GetStatusFamily(memberlist);
            _report.CrystalReport.Rpt_StatusList rpt = new LandWin.Report.CrystalReport.Rpt_StatusList();
            _report.CrystalReportTools.CrystalManager manager = new LandWin.Report.CrystalReportTools.CrystalManager();
            manager.PushReportData(ds, rpt);
            manager.PreviewReport(rpt, "Status Family Report");

        }

        private dsStatusFamily GetStatusFamily(string memberlist)
        {
            Dothan.Report.RemoteAccess.ClientRemoteAccess oRemoteAccess = new Dothan.Report.RemoteAccess.ClientRemoteAccess();
            oRemoteAccess.tInterface = typeof(IStatusFamily<>);
            oRemoteAccess.nConnectionType = Dothan.Report.RemoteAccess.ClientRemoteAccess.ConnectionTypeOptions.LocalAccess;
            oRemoteAccess.cServiceName = "LandWin.Report";
            oRemoteAccess.ReportName = "bzStatusFamily";
            object oReturnObject = oRemoteAccess.GetAccessObject();
            dsStatusFamily odsSheet = new dsStatusFamily();
            IStatusFamily<dsStatusFamily> oSheet = (IStatusFamily<dsStatusFamily>)oReturnObject;
            odsSheet = oSheet.GetStatusFamily(memberlist.TrimEnd(','));
            return odsSheet;

        }


        public void PrintStatusReport(string memberlist)
        {
            if (string.IsNullOrEmpty(memberlist))
            {
                return;
            }
            _report.DataSet.dsStatusReport ds = GetStatusReport(memberlist);
            _report.CrystalReport.Rpt_StatusList rpt = new LandWin.Report.CrystalReport.Rpt_StatusList();
            _report.CrystalReportTools.CrystalManager manager = new LandWin.Report.CrystalReportTools.CrystalManager();
            manager.PushReportData(ds, rpt);
            manager.PreviewReport(rpt, "Status Report");

        }

        private dsStatusReport GetStatusReport(string memberlist)
        {
            Dothan.Report.RemoteAccess.ClientRemoteAccess oRemoteAccess = new Dothan.Report.RemoteAccess.ClientRemoteAccess();
            oRemoteAccess.tInterface = typeof(IStatusReport<>);
            oRemoteAccess.nConnectionType = Dothan.Report.RemoteAccess.ClientRemoteAccess.ConnectionTypeOptions.LocalAccess;
            oRemoteAccess.cServiceName = "LandWin.Report";
            oRemoteAccess.ReportName = "bzStatusList";
            object oReturnObject = oRemoteAccess.GetAccessObject();
            dsStatusReport odsSheet = new dsStatusReport();
            IStatusReport<dsStatusReport> oSheet = (IStatusReport<dsStatusReport>)oReturnObject;
            odsSheet = oSheet.GetStatusReport(memberlist.TrimEnd(','));
            return odsSheet;

        }

        #endregion

        #region Print Cell Report

        public void RunCellReportPrint(string cellreport)
        {
            if (string.IsNullOrEmpty(cellreport))
            {
                return;
            }
            _report.DataSet.dsCellReport ds = GetCellReportPrint(cellreport);
            _report.CrystalReport.Rpt_Cellreport rpt = new LandWin.Report.CrystalReport.Rpt_Cellreport();
            _report.CrystalReportTools.CrystalManager manager = new LandWin.Report.CrystalReportTools.CrystalManager();
            manager.PushReportData(ds, rpt);
            manager.PreviewReport(rpt, "Cell report");

        }
        private dsCellReport GetCellReportPrint(string cellreport)
        {
           
            Dothan.Report.RemoteAccess.ClientRemoteAccess oRemoteAccess = new Dothan.Report.RemoteAccess.ClientRemoteAccess();
            oRemoteAccess.tInterface = typeof(ICellReport<>);
            oRemoteAccess.nConnectionType = Dothan.Report.RemoteAccess.ClientRemoteAccess.ConnectionTypeOptions.LocalAccess;
            oRemoteAccess.cServiceName = "LandWin.Report";
            oRemoteAccess.ReportName = "bzCellReport";
            object oReturnObject = oRemoteAccess.GetAccessObject();
            dsCellReport odsSheet = new dsCellReport();
            ICellReport<dsCellReport> oSheet = (ICellReport<dsCellReport>)oReturnObject;
            odsSheet = oSheet.GetCellReportDetail(cellreport.TrimEnd(','));
            return odsSheet;
        }
        public void RunCellFamilyPrint(string cellreport)
        {

            _report.DataSet.dsCellMemberByFamily ds = GetCellFamilyPrint(cellreport);
            _report.CrystalReport.Rpt_CellMemberInfoByFamily rpt = new LandWin.Report.CrystalReport.Rpt_CellMemberInfoByFamily();
            _report.CrystalReportTools.CrystalManager manager = new LandWin.Report.CrystalReportTools.CrystalManager();
            manager.PushReportData(ds, rpt);
            manager.PreviewReport(rpt, "Cell Family List");

        }
        private dsCellMemberByFamily GetCellFamilyPrint(string cellreport)
        {

            Dothan.Report.RemoteAccess.ClientRemoteAccess oRemoteAccess = new Dothan.Report.RemoteAccess.ClientRemoteAccess();
            oRemoteAccess.tInterface = typeof(ICellMemberByFamily<>);
            oRemoteAccess.nConnectionType = Dothan.Report.RemoteAccess.ClientRemoteAccess.ConnectionTypeOptions.LocalAccess;
            oRemoteAccess.cServiceName = "LandWin.Report";
            oRemoteAccess.ReportName = "bzCellMemberByFamily";
            object oReturnObject = oRemoteAccess.GetAccessObject();
            dsCellMemberByFamily odsSheet = new dsCellMemberByFamily();
            ICellMemberByFamily<dsCellMemberByFamily> oSheet = (ICellMemberByFamily<dsCellMemberByFamily>)oReturnObject;
            odsSheet = oSheet.GetCellMemberByFamily(cellreport.TrimEnd(','));
            return odsSheet;
        }



        #endregion


        #region Visit Report

        public void RunVisitReport(string list)
        {
            if (string.IsNullOrEmpty(list))
            {
                return;
            }
            _report.DataSet.dsVisitReport ds = GetVisitReport(list);
            _report.CrystalReport.Rpt_VisitReport rpt = new LandWin.Report.CrystalReport.Rpt_VisitReport();
            _report.CrystalReportTools.CrystalManager manager = new LandWin.Report.CrystalReportTools.CrystalManager();
            manager.PushReportData(ds, rpt);
            manager.PreviewReport(rpt, "Visit Report");
        }


        private dsVisitReport GetVisitReport(string list)
        {
            Dothan.Report.RemoteAccess.ClientRemoteAccess oRemoteAccess = new Dothan.Report.RemoteAccess.ClientRemoteAccess();
            oRemoteAccess.tInterface = typeof(IVisitReport<>);
            oRemoteAccess.nConnectionType = Dothan.Report.RemoteAccess.ClientRemoteAccess.ConnectionTypeOptions.LocalAccess;
            oRemoteAccess.cServiceName = "LandWin.Report";
            oRemoteAccess.ReportName = "bzVisitReport";
            object oReturnObject = oRemoteAccess.GetAccessObject();
            dsVisitReport odsSheet = new dsVisitReport();
            IVisitReport<dsVisitReport> oSheet = (IVisitReport<dsVisitReport>)oReturnObject;
            odsSheet = oSheet.GetVisitReport(list.TrimEnd(','));
            return odsSheet;

        }

        public void RunMemberVisitReport(string list)
        {
            if (string.IsNullOrEmpty(list))
            {
                return;
            }
            _report.DataSet.dsMemberVisit ds = GetMemberVisitReport(list);
            _report.CrystalReport.Rpt_VisitMember rpt = new LandWin.Report.CrystalReport.Rpt_VisitMember();
            _report.CrystalReportTools.CrystalManager manager = new LandWin.Report.CrystalReportTools.CrystalManager();
            manager.PushReportData(ds, rpt);
            manager.PreviewReport(rpt, "Member Visit Report");
        }


        private dsMemberVisit GetMemberVisitReport(string list)
        {
            Dothan.Report.RemoteAccess.ClientRemoteAccess oRemoteAccess = new Dothan.Report.RemoteAccess.ClientRemoteAccess();
            oRemoteAccess.tInterface = typeof(IMemberVisit<>);
            oRemoteAccess.nConnectionType = Dothan.Report.RemoteAccess.ClientRemoteAccess.ConnectionTypeOptions.LocalAccess;
            oRemoteAccess.cServiceName = "LandWin.Report";
            oRemoteAccess.ReportName = "bzMemberVisit";
            object oReturnObject = oRemoteAccess.GetAccessObject();
            dsMemberVisit odsSheet = new dsMemberVisit();
            IMemberVisit<dsMemberVisit> oSheet = (IMemberVisit<dsMemberVisit>)oReturnObject;
            odsSheet = oSheet.GetMemberVisit(list.TrimEnd(','));
            return odsSheet;

        }
       


        #endregion


        #region Donate report

        public void RunDonateSheet(string list)
        {
            if (string.IsNullOrEmpty(list))
            {
                return;
            }
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


        public void RunDonateWeekly( string startdate , string enddate)
        {

            _report.DataSet.dsDonateSumByTypes ds = GetDonateWeekly(startdate, enddate);
            _report.CrystalReport.Rpt_DonateWeekly rpt = new LandWin.Report.CrystalReport.Rpt_DonateWeekly();
            _report.CrystalReportTools.CrystalManager manager = new LandWin.Report.CrystalReportTools.CrystalManager();
            manager.PushReportData(ds, rpt);
            manager.PreviewReport(rpt, "Donate Weekly");

        }

        private dsDonateWeekly GetDonateWeeklyDetail( string startdate , string enddate)
        {
            Dothan.Report.RemoteAccess.ClientRemoteAccess oRemoteAccess = new Dothan.Report.RemoteAccess.ClientRemoteAccess();
            oRemoteAccess.tInterface = typeof(IDonateWeekly<>);
            oRemoteAccess.nConnectionType = Dothan.Report.RemoteAccess.ClientRemoteAccess.ConnectionTypeOptions.LocalAccess;
            oRemoteAccess.cServiceName = "LandWin.Report";
            oRemoteAccess.ReportName = "bzDonateWeekly";
            object oReturnObject = oRemoteAccess.GetAccessObject();
            dsDonateWeekly odsSheet = new dsDonateWeekly();
            IDonateWeekly<dsDonateWeekly> oSheet = (IDonateWeekly<dsDonateWeekly>)oReturnObject;
            odsSheet = oSheet.GetDonateWeekly(startdate,enddate ,0);
            return odsSheet;

        }

        public void RunDonateWeeklyDetail(string startdate, string enddate)
        {
            _report.DataSet.dsDonateWeekly ds = GetDonateWeeklyDetail(startdate, enddate);
            _report.CrystalReport.Rpt_DonateWeeklyDetail rpt = new LandWin.Report.CrystalReport.Rpt_DonateWeeklyDetail();
            _report.CrystalReportTools.CrystalManager manager = new LandWin.Report.CrystalReportTools.CrystalManager();
            manager.PushReportData(ds, rpt);
            manager.PreviewReport(rpt, "Donate Weekly Detail");

        }

        private dsDonateSumByTypes GetDonateWeekly(string startdate, string enddate)
        {
            Dothan.Report.RemoteAccess.ClientRemoteAccess oRemoteAccess = new Dothan.Report.RemoteAccess.ClientRemoteAccess();
            oRemoteAccess.tInterface = typeof(IDonateSumByTypes<>);
            oRemoteAccess.nConnectionType = Dothan.Report.RemoteAccess.ClientRemoteAccess.ConnectionTypeOptions.LocalAccess;
            oRemoteAccess.cServiceName = "LandWin.Report";
            oRemoteAccess.ReportName = "bzDonateSumByTypes";
            object oReturnObject = oRemoteAccess.GetAccessObject();
            dsDonateSumByTypes odsSheet = new dsDonateSumByTypes();
            IDonateSumByTypes<dsDonateSumByTypes> oSheet = (IDonateSumByTypes<dsDonateSumByTypes>)oReturnObject;
            odsSheet = oSheet.GetDonateSumByTypes(startdate, enddate);
            return odsSheet;

        }
        public void RunMemberDonate(int list, int year, bool family)
        {
            _report.DataSet.dsMemberDonate ds = GetMemberDonate(list, year,family);
               string s = " C:\\LandWin\\DATA\\MemberImage\\Signature.bmp ";
            if (File.Exists(s))
            {
                LoadImage(ds.Tables[2].Rows[0], "Signature", s);
            }
            _report.CrystalReport.Rpt_DonateRecipt rpt = new LandWin.Report.CrystalReport.Rpt_DonateRecipt();
            _report.CrystalReportTools.CrystalManager manager = new LandWin.Report.CrystalReportTools.CrystalManager();
            manager.PushReportData(ds, rpt);
            manager.PreviewReport(rpt, "Donate Receipt");

        }

        private dsMemberDonate GetMemberDonate(int list, int year, bool family)
        {
            Dothan.Report.RemoteAccess.ClientRemoteAccess oRemoteAccess = new Dothan.Report.RemoteAccess.ClientRemoteAccess();
            oRemoteAccess.tInterface = typeof(IMemberDonate<>);
            oRemoteAccess.nConnectionType = Dothan.Report.RemoteAccess.ClientRemoteAccess.ConnectionTypeOptions.LocalAccess;
            oRemoteAccess.cServiceName = "LandWin.Report";
            oRemoteAccess.ReportName = "bzMemberDonate";
            object oReturnObject = oRemoteAccess.GetAccessObject();
            dsMemberDonate odsSheet = new dsMemberDonate();
            IMemberDonate<dsMemberDonate> oSheet = (IMemberDonate<dsMemberDonate>)oReturnObject;
            odsSheet = oSheet.GetMemberDonate(list,year,family);
            return odsSheet;

        }

        #endregion

        #region Fetch Picture
        private void FetchPicture(DataSet ds)
        {
            FetchPicture(ds, 0);
        }
        private void FetchPicture(DataSet ds , int column)
        {
            for (int index = 0; index < ds.Tables[column].Rows.Count; index++)
            {
                string s = "C:\\LandWin\\DATA\\MemberImage\\"
                    + ds.Tables[column].Rows[index]["MemberId"].ToString() + ".jpg";
                if (File.Exists(s))
                {
                    LoadImage(ds.Tables[column].Rows[index], "Image", s);
                }
                else
                {

                    LoadImage(ds.Tables[column].Rows[index], "Image", string.Empty);
                }

            }
        }
        private void LoadImage(DataRow row, string strImageField, string FilePath)
        {

            if (!string.IsNullOrEmpty(FilePath))
            {
                FileStream fs = new FileStream(FilePath,
                       System.IO.FileMode.Open, System.IO.FileAccess.Read);
                byte[] Image = new byte[fs.Length];
                fs.Read(Image, 0, Convert.ToInt32(fs.Length));
                fs.Close();
                row[strImageField] = Image;
            }
            else
            {
                row[strImageField] = convertImageToByteArray(LandWin.Properties.Resources.NoPhoto);
            }
        }

        public byte[] convertImageToByteArray(System.Drawing.Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                // or whatever output format you like
                return ms.ToArray();
            }
        }
        #endregion
    }
}
