using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dothan.Report.RemoteAccess;
using _entity = LandWin.Report;
using System.Data;
using System.IO;
using LandWin.Properties;


namespace LandWin
{
    public class ReportManager
    {

//        #region Get Address Sheet Group By Family

//        public void RunFamilyAddressBook(string memberlist)
//        {
//           _entity.DataSet.dsFyAddressBook ds = this.GetdsFyAddressBook(memberlist);
//            this.PreviewReportFamilyAddressBook(ds);
//        }
//        public void PreviewReportFamilyAddressBook(_entity.DataSet.dsFyAddressBook ds)
//        {
//            _entity.CrystalReport.Rpt_FamilyAddressBook rpt = new _entity.CrystalReport.Rpt_FamilyAddressBook();
//            CrystalManager manager = new CrystalManager();
//            manager.PushReportData(ds, rpt);
//            manager.PreviewReport(rpt, Resources.FamilyAddrssBook);
//        }

//        private _entity.DataSet.dsFyAddressBook GetdsFyAddressBook(string memberlist)
//        {
//            ClientRemoteAccess oRemoteAccess = new ClientRemoteAccess();
//            oRemoteAccess.tInterface = typeof(_entity.DataAccess.IFamilyAddressBook<>);
//            oRemoteAccess.nConnectionType = Dothan.Report.RemoteAccess.ClientRemoteAccess.ConnectionTypeOptions.LocalAccess;
//            oRemoteAccess.cServiceName = "LandWin.Report.Business";
//            oRemoteAccess.ReportName = "bzFamilyAddressBook";
//            object oReturnObject = oRemoteAccess.GetAccessObject();
//            _entity.DataSet.dsFyAddressBook odsSheet = new _entity.DataSet.dsFyAddressBook();
//            _entity.DataAccess.IFamilyAddressBook<_entity.DataSet.dsFyAddressBook> oSheet;
//            oSheet = (_entity.DataAccess.IFamilyAddressBook<_entity.DataSet.dsFyAddressBook>)oReturnObject;
//            odsSheet = oSheet.GetFamilyAddressBook(memberlist.TrimEnd(','));
//            return odsSheet;
//        }

//        #endregion

//        public void RunCellReportPrint(string cellreport)
//        {
//            dsCellReport ds = this.GetCellReportPrint(cellreport);
//            this.PreviewCellReportPrint(ds);
//        }
        
//        private void PreviewCellReportPrint(dsCellReport ds)
//        {
//            Rpt_Cellreport rpt = new Rpt_Cellreport();
//            CrystalManager manager = new CrystalManager();
//            manager.PushReportData(ds, rpt);
//            manager.PreviewReport(rpt, "Cell Report");
//        }
        
//        private dsCellReport GetCellReportPrint(string cellreport)
//        {
//            ClientRemoteAccess oRemoteAccess = new ClientRemoteAccess();
//            oRemoteAccess.tInterface = typeof(LandWin.Shared.Interface.ICellReport<>);
//            oRemoteAccess.nConnectionType = Dothan.Report.RemoteAccess.ClientRemoteAccess.ConnectionTypeOptions.LocalAccess;
//            oRemoteAccess.cServiceName = "LandWin.Business";
//            oRemoteAccess.ReportName = "bzCellReport";
//            object oReturnObject = oRemoteAccess.GetAccessObject();
//            dsCellReport odsDonateSheet = new dsCellReport();
//            ICellReport<dsCellReport> oDonateSheet;
//            oDonateSheet = (ICellReport<dsCellReport>)oReturnObject;
//            odsDonateSheet = oDonateSheet.GetCellReportDetail(cellreport.TrimEnd(','));
//            return odsDonateSheet;
//        }

//        public void RunCellMemberByFamilyPrint(string memberlist)
//        {
//            dsCellMemberByFamily ds = this.GetCellMemberByFamily(memberlist);
//            this.PreviewCellReportPrint(ds);
//        }

//        private void PreviewCellReportPrint(dsCellMemberByFamily ds)
//        {
//            Rpt_CellMemberInfoByFamily rpt = new Rpt_CellMemberInfoByFamily();
//            CrystalManager manager = new CrystalManager();
//            manager.PushReportData(ds, rpt);
//            manager.PreviewReport(rpt, "Cell Report");
//        }

//        private dsCellMemberByFamily GetCellMemberByFamily(string memberlist)
//        {
//            ClientRemoteAccess oRemoteAccess = new ClientRemoteAccess();
//            oRemoteAccess.tInterface =
//                          typeof(LandWin.Shared.Interface.ICellMemberByFamily<>);
//            oRemoteAccess.nConnectionType = Dothan.Report.RemoteAccess.ClientRemoteAccess.ConnectionTypeOptions.LocalAccess;
//            oRemoteAccess.cServiceName = "LandWin.Business";
//            oRemoteAccess.ReportName = "bzCellMemberByFamily";
//            object oReturnObject = oRemoteAccess.GetAccessObject();
//            dsCellMemberByFamily odsDonateSheet = new dsCellMemberByFamily();


//            ICellMemberByFamily<dsCellMemberByFamily> oDonateSheet;
//            oDonateSheet = (ICellMemberByFamily<dsCellMemberByFamily>)oReturnObject;
//            odsDonateSheet = oDonateSheet.GetCellMemberByFamily(memberlist.TrimEnd(','));
//            return odsDonateSheet;

//        }
//        public void RunMemberWIthPic(string memberlist)
//        {
//            dsMemberWithPic ds = this.GetMemberWIthPic(memberlist);
//            for (int index = 0; index < ds.Tables[0].Rows.Count; index++)
//            {
//                string s = "C:\\LandWin\\DATA\\MemberImage\\"
//                    + ds.Tables[0].Rows[index]["MemberId"].ToString() + ".jpg";
//                if (File.Exists(s))
//                {
//                    LoadImage(ds.Tables[0].Rows[index], "Image", s);
//                }
//                else
//                {
                    
//                    LoadImage(ds.Tables[0].Rows[index], "image", string.Empty);
//                }

//            }
//              this.PreviewMemberWIthPic(ds);
//        }

//        private void PreviewMemberWIthPic(dsMemberWithPic ds)
//        {
//           Rpt_MemberWithPic rpt = new Rpt_MemberWithPic();
//            CrystalManager manager = new CrystalManager();
//            manager.PushReportData(ds, rpt);
//            manager.PreviewReport(rpt, "Cell Report");
//        }

//        private void LoadImage(DataRow row, string strImageField, string FilePath)
//        {

//            if (!string.IsNullOrEmpty(FilePath))
//            {
//                FileStream fs = new FileStream(FilePath,
//                       System.IO.FileMode.Open, System.IO.FileAccess.Read);
//                byte[] Image = new byte[fs.Length];
//                fs.Read(Image, 0, Convert.ToInt32(fs.Length));
//                fs.Close();
//                row[strImageField] = Image;
//            }
//            else
//            {
//                row[strImageField] = convertImageToByteArray(LandWin.Properties.Resources.NoPhoto);
//            }
//        }

//        private dsMemberWithPic GetMemberWIthPic(string memberlist)
//        {
//           ClientRemoteAccess oRemoteAccess = new ClientRemoteAccess();
//            oRemoteAccess.tInterface = typeof(LandWin.Shared.Interface.IMemberWithPic<>);
//            oRemoteAccess.nConnectionType = Dothan.Report.RemoteAccess.ClientRemoteAccess.ConnectionTypeOptions.LocalAccess;
//            oRemoteAccess.cServiceName = "LandWin.Business";
//            oRemoteAccess.ReportName = "bzMemberWithPic";
//            object oReturnObject = oRemoteAccess.GetAccessObject();
//            dsMemberWithPic odsDonateSheet = new dsMemberWithPic();
//            IMemberWithPic<dsMemberWithPic> oDonateSheet;
//            oDonateSheet = (IMemberWithPic<dsMemberWithPic>)oReturnObject;
//            odsDonateSheet = oDonateSheet.GetMemberWithPic(memberlist.TrimEnd(','));
//            return odsDonateSheet; 

//        }
//        public byte[] convertImageToByteArray(System.Drawing.Image image)
//        {
//            using (MemoryStream ms = new MemoryStream())
//            {
//                image.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
//                // or whatever output format you like
//                return ms.ToArray();
//            }
//        }
//        public void RunMemberByFamily(string memberlist)
//        {
//            dsMemberByFamily ds = this.GetMemberByFamily(memberlist);

//            for (int index = 0; index < ds.Tables["dsmemberdetail"].Rows.Count; index++)
//            {
//                string s = "C:\\LandWin\\DATA\\MemberImage\\"
//                    + ds.Tables["dsmemberdetail"].Rows[index]["MemberId"].ToString() + ".jpg";
//                if (File.Exists(s))
//                {
//                    LoadImage(ds.Tables["dsmemberdetail"].Rows[index], "Image", s);
//                }
//                else
//                {
//                    LoadImage(ds.Tables["dsmemberdetail"].Rows[index], "image", string.Empty);
//                }

//            }
//            this.PreviewMemberWIthPic(ds);
//        }

//        private void PreviewMemberWIthPic(dsMemberByFamily ds)
//        {
//            Rpt_MemberByFamily rpt = new Rpt_MemberByFamily();
//            CrystalManager manager = new CrystalManager();
//            manager.PushReportData(ds, rpt);
//            manager.PreviewReport(rpt, "Cell Report");
//        }


//        private dsMemberByFamily GetMemberByFamily(string memberlist)
//        {
//            ClientRemoteAccess oRemoteAccess = new ClientRemoteAccess();
//            oRemoteAccess.tInterface = typeof(LandWin.Shared.Interface.IMemberByFamily<>);
//            oRemoteAccess.nConnectionType = Dothan.Report.RemoteAccess.ClientRemoteAccess.ConnectionTypeOptions.LocalAccess;
//            oRemoteAccess.cServiceName = "LandWin.Business";
//            oRemoteAccess.ReportName = "bzMemberByFamily";
//            object oReturnObject = oRemoteAccess.GetAccessObject();
//            dsMemberByFamily odsDonateSheet = new dsMemberByFamily();
//            IMemberByFamily<dsMemberByFamily> oDonateSheet;
//            oDonateSheet = (IMemberByFamily<dsMemberByFamily>)oReturnObject;
//            odsDonateSheet = oDonateSheet.GetMemberByFamily(memberlist.TrimEnd(','));
//            return odsDonateSheet;

//        }


//        public void RunVisitReport(string list)
//        {
//            dsVisitReport ds = this.GetVisitReport(list);
//            this.PreviewVisitReport(ds);
//        }

//        private void PreviewVisitReport(dsVisitReport ds)
//        {
//            Rpt_VisitReport rpt = new Rpt_VisitReport();
//            CrystalManager manager = new CrystalManager();
//            manager.PushReportData(ds, rpt);
//            manager.PreviewReport(rpt, "Visit Report");
//        }



//        private dsVisitReport GetVisitReport(string list)
//        {
//            ClientRemoteAccess oRemoteAccess = new ClientRemoteAccess();
//            oRemoteAccess.tInterface =
//                          typeof(LandWin.Shared.Interface.IMemberByFamily<>);
//            oRemoteAccess.nConnectionType = Dothan.Report.RemoteAccess.ClientRemoteAccess.ConnectionTypeOptions.LocalAccess;
//            oRemoteAccess.cServiceName = "LandWin.Business";
//            oRemoteAccess.ReportName = "bzVisitReport";
//            object oReturnObject = oRemoteAccess.GetAccessObject();
//            dsVisitReport odsDonateSheet = new dsVisitReport();
//            IVisitReport<dsVisitReport> oDonateSheet;
//            oDonateSheet = (IVisitReport<dsVisitReport>)oReturnObject;
//            odsDonateSheet = oDonateSheet.GetVisitReport(list.TrimEnd(','));
//            return odsDonateSheet;
//        } 

//        public void PersonAddressBook(string memberlist)
//        {
//            dsFyAddressBook ds = this.GetPersonAddressBook(memberlist);
//            this.PreviewReportPersonAddressBook(ds);
//        }
        
//        public void PreviewReportPersonAddressBook(dsFyAddressBook ds)
//        {
//            Rpt_FamilyAddressBook rpt = new Rpt_FamilyAddressBook();
//            CrystalManager manager = new CrystalManager();
//            manager.PushReportData(ds, rpt);
//            manager.PreviewReport(rpt, Resources.FamilyAddrssBook);
//        }
        
//        private dsFyAddressBook GetPersonAddressBook(string memberlist)
//        {
//            ClientRemoteAccess oRemoteAccess = new ClientRemoteAccess();
//            oRemoteAccess.tInterface = typeof(LandWin.Shared.Interface.IPersonAddressBook<>);
//            oRemoteAccess.nConnectionType = Dothan.Report.RemoteAccess.ClientRemoteAccess.ConnectionTypeOptions.LocalAccess;
//            oRemoteAccess.cServiceName = "LandWin.Business";
//            oRemoteAccess.ReportName = "bzPersonAddressBook";
//            object oReturnObject = oRemoteAccess.GetAccessObject();
//            dsFyAddressBook odsDonateSheet = new dsFyAddressBook();
//            IPersonAddressBook<dsFyAddressBook> oDonateSheet;
//            oDonateSheet = (IPersonAddressBook<dsFyAddressBook>)oReturnObject;
//            odsDonateSheet = oDonateSheet.GetPersonAddressBook(memberlist.TrimEnd(','));
//            return odsDonateSheet;
//        }

//        //제적세대 명부
//        public void StatusListReport(string list)
//        {
//            dsStatusReport ds = this.GetStatusReport(list);
//            this.PreviewReportStatusList(ds);
//        }

//        public void PreviewReportStatusList(dsStatusReport ds)
//        {
//            Rpt_StatusList rpt = new Rpt_StatusList();
//            CrystalManager manager = new CrystalManager();
//            manager.PushReportData(ds, rpt);
//            manager.PreviewReport(rpt, Resources.FamilyAddrssBook);
//        }
        
//        private dsStatusReport GetStatusReport(string memberlist)
//        {
//            ClientRemoteAccess oRemoteAccess = new ClientRemoteAccess();
//            oRemoteAccess.tInterface = typeof(LandWin.Shared.Interface.IStatusReport<>);
//            oRemoteAccess.nConnectionType = Dothan.Report.RemoteAccess.ClientRemoteAccess.ConnectionTypeOptions.LocalAccess;
//            oRemoteAccess.cServiceName = "LandWin.Business";
//            oRemoteAccess.ReportName = "bzStatusList";
//            object oReturnObject = oRemoteAccess.GetAccessObject();
//            dsStatusReport odsDonateSheet = new dsStatusReport();
//            IStatusReport<dsStatusReport> oDonateSheet;
//            oDonateSheet = (IStatusReport<dsStatusReport>)oReturnObject;
//            odsDonateSheet = oDonateSheet.GetStatusReport(memberlist.TrimEnd(','));


//            return odsDonateSheet;
//        }
//        //제적가족세대 명부
//        public void StatusFamilyReport(string list,string memberlist)
//        {
//            dsStatusFamily ds = this.GetStatusFamilyReport(list, memberlist);
//            this.PreviewReportStatusFamily(ds);
//        }
//        public void PreviewReportStatusFamily(dsStatusFamily ds)
//        {
//            Rpt_StatusByFamily rpt = new Rpt_StatusByFamily();
//            CrystalManager manager = new CrystalManager();
//            manager.PushReportData(ds, rpt);
//            manager.PreviewReport(rpt,  "");
//        }
//        private dsStatusFamily GetStatusFamilyReport(string list,string memberlist)
//        {
//            ClientRemoteAccess oRemoteAccess = new ClientRemoteAccess();
//            oRemoteAccess.tInterface =
//                          typeof(LandWin.Shared.Interface.IStatusReport<>);
//            oRemoteAccess.nConnectionType = Dothan.Report.RemoteAccess.ClientRemoteAccess.ConnectionTypeOptions.LocalAccess;
//            oRemoteAccess.cServiceName = "LandWin.Business";
//            oRemoteAccess.ReportName = "bzStatusFamily";
//            object oReturnObject = oRemoteAccess.GetAccessObject();
//            dsStatusFamily odsDonateSheet = new dsStatusFamily();
//            IStatusFamily<dsStatusFamily> oDonateSheet;
//            oDonateSheet = (IStatusFamily<dsStatusFamily>)oReturnObject;
//            odsDonateSheet = oDonateSheet.GetStatusFamily(list.TrimEnd(','), memberlist.TrimEnd(','));
//            return odsDonateSheet;
//        }
////  교인 상세 카드
//        public void ReportMemberCard(string list)
//        {
//            dsMemberCard ds = this.GetMemberCard(list);
//            for (int index = 0; index < ds.Tables[0].Rows.Count; index++)
//            {
//                string s = " C:\\LandWin\\DATA\\MemberImage\\"
//                    + ds.Tables[0].Rows[index]["MemberId"].ToString() + ".jpg";
//                if (File.Exists(s))
//                {
//                    LoadImage(ds.Tables[0].Rows[index], "Image", s);
//                }
//                else
//                {
//                    LoadImage(ds.Tables[0].Rows[index], "Image", string.Empty);
//                }

//            }
//            this.PreviewReportMemberCard(ds);
//        }
//        public void PreviewReportMemberCard(dsMemberCard ds)
//        {
//            Rpt_MemberCards rpt = new  Rpt_MemberCards();
//            CrystalManager manager = new CrystalManager();
//            manager.PushReportData(ds, rpt);
//            manager.PreviewReport(rpt, "교인 상세 카드");
//        }
//        private dsMemberCard GetMemberCard(string memberlist)
//        {
//            ClientRemoteAccess oRemoteAccess = new ClientRemoteAccess();
//            oRemoteAccess.tInterface =
//                          typeof(LandWin.Shared.Interface.IMemberCard<>);
//            oRemoteAccess.nConnectionType = Dothan.Report.RemoteAccess.ClientRemoteAccess.ConnectionTypeOptions.LocalAccess;
//            oRemoteAccess.cServiceName = "LandWin.Business";
//            oRemoteAccess.ReportName = "bzMemberCard";
//            object oReturnObject = oRemoteAccess.GetAccessObject();
//            dsMemberCard odsDonateSheet = new dsMemberCard();
//            IMemberCard<dsMemberCard> oDonateSheet;
//            oDonateSheet = (IMemberCard<dsMemberCard>)oReturnObject;
//            odsDonateSheet = oDonateSheet.GetMemberCard(memberlist.TrimEnd(','));


//            return odsDonateSheet;
//        }


//        //  심방 카드 
//        public void ReportMemberVisit(string list)
//        {
//            dsMemberVisit ds = this.GetMemberVisit(list);
//            this.PreviewReportMemberVisit(ds);
//        }
//        public void PreviewReportMemberVisit(dsMemberVisit ds)
//        {
//            Rpt_VisitMember rpt = new Rpt_VisitMember();
//            CrystalManager manager = new CrystalManager();
//            manager.PushReportData(ds, rpt);
//            manager.PreviewReport(rpt, "교인 심방 상세 카드");
//        }
//        private dsMemberVisit GetMemberVisit(string memberlist)
//        {
//            ClientRemoteAccess oRemoteAccess = new ClientRemoteAccess();
//            oRemoteAccess.tInterface =
//                          typeof(LandWin.Shared.Interface.IMemberCard<>);
//            oRemoteAccess.nConnectionType = Dothan.Report.RemoteAccess.ClientRemoteAccess.ConnectionTypeOptions.LocalAccess;
//            oRemoteAccess.cServiceName = "LandWin.Business";
//            oRemoteAccess.ReportName = "bzMemberVisit";
//            object oReturnObject = oRemoteAccess.GetAccessObject();
//            dsMemberVisit odsDonateSheet = new dsMemberVisit();
//            IMemberVisit<dsMemberVisit> oDonateSheet;
//            oDonateSheet = (IMemberVisit<dsMemberVisit>)oReturnObject;
//            odsDonateSheet = oDonateSheet.GetMemberVisit(memberlist.TrimEnd(','));


//            return odsDonateSheet;
//        }


//        // 개인 교적 상세 카드 
//        public void ReportMemberDetails(string list)
//        {
//            dsMemberDetails ds = this.GetMemberDetails(list);
//            for (int index = 0; index < ds.Tables[0].Rows.Count; index++)
//            {

//                string s = " C:\\LandWin\\DATA\\MemberImage\\"
//                    + ds.Tables[0].Rows[index]["MemberId"].ToString() + ".jpg";
//                if (File.Exists(s))
//                {
//                    LoadImage(ds.Tables[0].Rows[index], "Image", s);
//                }
//                else
//                {
//                    LoadImage(ds.Tables[0].Rows[index], "Image", string.Empty);
//                }

//            }
//            this.PreviewReportMemberDetails(ds);
//        }
//        public void PreviewReportMemberDetails(dsMemberDetails ds)
//        {
//            Rpt_MemberDetail rpt = new Rpt_MemberDetail();
//            CrystalManager manager = new CrystalManager();
//            manager.PushReportData(ds, rpt);
//            manager.PreviewReport(rpt, "교인 교적 상세 카드");
//        }
//        private dsMemberDetails GetMemberDetails(string memberlist)
//        {
//            ClientRemoteAccess oRemoteAccess = new ClientRemoteAccess();
//            oRemoteAccess.tInterface =
//                          typeof(LandWin.Shared.Interface.IMemberCard<>);
//            oRemoteAccess.nConnectionType = Dothan.Report.RemoteAccess.ClientRemoteAccess.ConnectionTypeOptions.LocalAccess;
//            oRemoteAccess.cServiceName = "LandWin.Business";
//            oRemoteAccess.ReportName = "bzMemberDetails";
//            object oReturnObject = oRemoteAccess.GetAccessObject();
//            dsMemberDetails odsDonateSheet = new dsMemberDetails();
//            IMemberDetails<dsMemberDetails> oDonateSheet;
//            oDonateSheet = (IMemberDetails<dsMemberDetails>)oReturnObject;
//            odsDonateSheet = oDonateSheet.GetMemberDetails(memberlist.TrimEnd(','));


//            return odsDonateSheet;
//        }


//        public void ReportMemberDonate(string list,string startdate , string enddate,bool family)
//        {
//            dsMemberDonate ds = this.GetMemberDonate(list,startdate , enddate, family);
//            string s = " C:\\LandWin\\DATA\\MemberImage\\Signature.bmp ";
//            if (File.Exists(s))
//            {
//                LoadImage(ds.Tables[2].Rows[0], "Signature", s);
//            }
//            this.PreviewReportMemberDonate(ds);
//        }
//        public void PreviewReportMemberDonate(dsMemberDonate ds)
//        {
//            Rpt_DonateRecipt rpt = new Rpt_DonateRecipt();
//            CrystalManager manager = new CrystalManager();
//            manager.PushReportData(ds, rpt);
//            manager.PreviewReport(rpt, "교인 헌금 증명서");
//        }
//        private dsMemberDonate GetMemberDonate(string memberlist,string startdate , string enddate , bool family)
//        {
//            ClientRemoteAccess oRemoteAccess = new ClientRemoteAccess();
//            oRemoteAccess.tInterface =
//                          typeof(LandWin.Shared.Interface.IMemberCard<>);
//            oRemoteAccess.nConnectionType = Dothan.Report.RemoteAccess.ClientRemoteAccess.ConnectionTypeOptions.LocalAccess;
//            oRemoteAccess.cServiceName = "LandWin.Business";
//            oRemoteAccess.ReportName = "bzMemberDonate";
//            object oReturnObject = oRemoteAccess.GetAccessObject();
//            dsMemberDonate odsDonateSheet = new dsMemberDonate();
//            IMemberDonate<dsMemberDonate> oDonateSheet;
//            oDonateSheet = (IMemberDonate<dsMemberDonate>)oReturnObject;
//            odsDonateSheet = oDonateSheet.GetMemberDonate(memberlist.TrimEnd(','),startdate ,enddate,family);


//            return odsDonateSheet;
//        }
//        public void PreviewReportFamilyList(dsFamilyList ds)
//        {
//            Rpt_FamilyList rpt = new Rpt_FamilyList();
//            CrystalManager manager = new CrystalManager();
//            manager.SetReportInfo(rpt, GetReportInfo("교인 세대명부"));
//            manager.PushReportData(ds, rpt);
//            manager.PreviewReport(rpt, "교인 세대명부");
//        }
//        public void ReportFamilyList(string memberlist)
//        {
//            dsFamilyList ds=this.GetFamilyList(memberlist);
//            this.PreviewReportFamilyList(ds);
//        }
//        private dsFamilyList GetFamilyList(string memberlist)
//        {
//            ClientRemoteAccess oRemoteAccess = new ClientRemoteAccess();
//            oRemoteAccess.tInterface =
//                          typeof(LandWin.Shared.Interface.IFamilyList<>);
//            oRemoteAccess.nConnectionType = Dothan.Report.RemoteAccess.ClientRemoteAccess.ConnectionTypeOptions.LocalAccess;
//            oRemoteAccess.cServiceName = "LandWin.Business";
//            oRemoteAccess.ReportName = "bzFamilyList";
//            object oReturnObject = oRemoteAccess.GetAccessObject();
//            dsFamilyList odsDonateSheet = new dsFamilyList();
//            IFamilyList<dsFamilyList> oDonateSheet;
//            oDonateSheet = (IFamilyList<dsFamilyList>)oReturnObject;
//            odsDonateSheet = oDonateSheet.GetFamilyList(memberlist.TrimEnd(','));


//            return odsDonateSheet;
//        } 
//        public ReportInfo GetReportInfo(string reporttitle)
//        {
//          // Frm_ReportInfo info = new Frm_ReportInfo();
//           // info.radTextBox1.Text = reporttitle;
//           // info.ShowDialog();
//            ReportInfo oReportInfo = new ReportInfo();
//            oReportInfo.FtrFootNotes = "";
//            oReportInfo.FtrRunBy = "";
//            oReportInfo.HdrCompany = "";
//            oReportInfo.HdrReportTitle = "";
//            oReportInfo.HdrSubTitle1 = "";
//            oReportInfo.HdrSubTitle2 = "";
//            oReportInfo.UserID = "";

//            return oReportInfo;
//        }
   }


    
}