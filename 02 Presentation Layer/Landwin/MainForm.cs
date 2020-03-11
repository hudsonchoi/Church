using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Collections;
using System.IO;
using System.Reflection;
using System.Configuration;
using DevExpress.XtraEditors;
using DevExpress.LookAndFeel;
using DevExpress.XtraExport;

using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Export;
using _entity = Dothan.Library;
using LandWin.Properties;
using LandWin.Modules;
using System.Xml;
using DevExpress.Utils;
using System.Threading;
using System.Text.RegularExpressions;

namespace LandWin
{
    public partial class MainForm : DevExpress.XtraEditors.XtraForm
    {
        private static MainForm _main;
        private WinPart _currentCtl;
        private ArrayList _memberfrmlist = new ArrayList();

        private XmlDocument oXmlDocument;

        private delegate void DelegateFileCheck();


        public MainForm()
        {
            InitializeComponent();
            txtVersion.Caption = Assembly.GetEntryAssembly().GetName().Version.ToString();
            _main = this;
            SetDefaultDirectory();
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Black";
            this.Text = Resources.Application_Name.ToString();
            if (Dothan.ApplicationContext.AuthenticationType == "Windows")
                AppDomain.CurrentDomain.SetPrincipalPolicy(System.Security.Principal.PrincipalPolicy.WindowsPrincipal);
            else
            {
               
                DoLogin();

                
            }
        }
        internal static MainForm Instance
        {
            get
            {
                return _main;
            }
        }




        private void CheckImageFile()
        {
            
            try
            {
                Thread t = new Thread(new ThreadStart(new DelegateFileCheck(DownLoadImageFile)));
                t.Start();
                t.Join();
            }
            catch (Exception ex)
            {
                Shared.Utility.ErrorLogging(Properties.Resources.ErrorMessage_General, ex.ToString(), "Error");
            }
        }



     

        #region MemberInfoForm

        public void ShowMemberInfo(int id)
        {
            if (_memberfrmlist.Count == 0 || !CheckDuplicated(id))
            {
                CreateMemberInfo(id);
            }
        }
        protected bool CheckDuplicated(int id)
        {
            bool result = false;
            foreach (Tools.MemberInfoFrm item in _memberfrmlist)
            {
                if (!item.IsDisposed)
                {
                    if (item.CheckMemberId(id))
                    {
                        item.Show();
                        item.BringToFront();
                        result = true;
                        break;
                    }
                }
            }
            return result;
        }
        protected void CreateMemberInfo(int id)
        {
           Tools.MemberInfoFrm frm = new Tools.MemberInfoFrm(id);

            frm.CheckParent += new EventHandler(Close_MemberInfoFrm);
            _memberfrmlist.Add(frm);
            frm.Show();
            frm.BringToFront();

        }

        protected void Close_MemberInfoFrm(object sender, EventArgs e)
        {
            Tools.MemberInfoFrm Parent = (Tools.MemberInfoFrm)sender;
            foreach (Tools.MemberInfoFrm item in _memberfrmlist)
            {
                _memberfrmlist.Remove(item);
                item.Close();
                break;
            }

        }


        #endregion

        private void DoLogin()
        {
            System.Security.Principal.IPrincipal user = Dothan.ApplicationContext.User;
            if (user.Identity.IsAuthenticated)
            {
                foreach (Control ctl in Panel1.Controls)
                    if (ctl is WinPart)
                        ((WinPart)ctl).OnCurrentPrincipalChanged(this, EventArgs.Empty);

            }
            else
            {
                using (LoginFrm loginForm = new LoginFrm())
                {
                    loginForm.ShowDialog(this);
                    user = Dothan.ApplicationContext.User;
                }
            }

            if (!user.Identity.IsAuthenticated)
            {
                this.Close();
            }
            else
            {
                CheckImageFile();
            }
        }

        private static void SetDefaultDirectory()
        {
            if (!System.IO.File.Exists(ConfigurationManager.AppSettings["DirImage"].ToString()))
            {
                System.IO.Directory.CreateDirectory(ConfigurationManager.AppSettings["DirImage"].ToString());
            }
            if (!System.IO.File.Exists(ConfigurationManager.AppSettings["DirLayout"].ToString()))
            {
                System.IO.Directory.CreateDirectory(ConfigurationManager.AppSettings["DirLayout"].ToString());
            }
            if (!System.IO.File.Exists(ConfigurationManager.AppSettings["DirXmlData"].ToString()))
            {
                System.IO.Directory.CreateDirectory(ConfigurationManager.AppSettings["DirXmlData"].ToString());
            }
        }

        #region Winpart

        private void ShowWinPart(WinPart part)
        {

            part.Dock = DockStyle.Fill;
            part.Visible = true;
            part.BringToFront();
            //this.Text = Resources.Application_Name.ToString() + " - " + part.ToString();
            Assembly asm = Assembly.GetExecutingAssembly();
            string[] parts = asm.FullName.Split(',');
            string ver = parts[1].Replace("=", " ");
            ver = ver.Substring(0, ver.LastIndexOf("."));
            this.Text = Resources.Application_Name.ToString() + " " + ver;

            _currentCtl = part;
        }

        private void AddWinPart(WinPart part)
        {
            this.Cursor = Cursors.WaitCursor;
            part.CloseWinPart += new EventHandler(CloseWinPart);
            Panel1.Controls.Add(part);
            ShowWinPart(part);
            this.Cursor = Cursors.Default;
        }

        public int DocumentCount
        {
            get
            {
                int count = 0;
                foreach (Control ctl in Panel1.Controls)
                    if (ctl is WinPart)
                        count++;
                return count;
            }
        }

        private void CloseWinPart(object sender, EventArgs e)
        {
            WinPart part = (WinPart)sender;
            part.CloseWinPart -= new EventHandler(CloseWinPart);
            part.Visible = false;
            Panel1.Controls.Remove(part);
            part.Dispose();
            if (DocumentCount == 0)
            {
                this.Text = Resources.Application_Name.ToString();
            }
            else
            {
                foreach (Control ctl in Panel1.Controls)
                {
                    if (ctl is WinPart)
                    {
                        this.Text = Resources.Application_Name.ToString() + ((WinPart)ctl).ToString();
                        break;
                    }
                }

            }
        }


        private void CloseWinpart(Control ctl)
        {
            WinPart part = (WinPart)ctl;
            part.CloseWinPart -= new EventHandler(CloseWinPart);
            part.Visible = false;
            Panel1.Controls.Remove(part);
            part.Dispose();
        }

        private void AllCloseWinpart()
        {
            foreach (Control ctl in Panel1.Controls)
            {
                if (ctl is WinPart)
                {
                    WinPart part = (WinPart)ctl;
                    part.CloseWinPart -= new EventHandler(CloseWinPart);
                    part.Visible = false;
                    Panel1.Controls.Remove(part);
                    part.Dispose();
                }
            }
        }
        #endregion



        #region Configuration



        private void btnBaptism_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_entity.bizAdmin.Baptisms.CanGetObject())
            {
                ShowDialog(new LandWin.Configuration.BaptismsFrm());
            }
            else
            {
                Shared.Utility.UnAuthorizedMessage();
            }
        }
        private void btnEntryType_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_entity.bizAdmin.EntryTypes.CanGetObject())
            {
                ShowDialog(new LandWin.Configuration.EntryTypeFrm());
            }
            else
            {
                Shared.Utility.UnAuthorizedMessage();
            }
        }
        private void btnCellRole_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_entity.bizCell.CellRoles.CanGetObject())
            {
                ShowDialog(new LandWin.Configuration.CellRolesFrm());
            }
            else
            {
                Shared.Utility.UnAuthorizedMessage();
            }
        }
        private void btnMinistryRole_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_entity.bizMinistry.MinistryRoles.CanGetObject())
            {
                ShowDialog(new LandWin.Configuration.MinistryRoleFrm());
            }
            else
            {
                Shared.Utility.UnAuthorizedMessage();
            }
        }
        private void btnJobType_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_entity.bizAdmin.JobTypes.CanGetObject())
            {
                ShowDialog(new LandWin.Configuration.JobTypeFrm());
            }
            else
            {
                Shared.Utility.UnAuthorizedMessage();
            }
        }
        private void btnVisitType_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_entity.bizAdmin.VisitTypes.CanGetObject())
            {
                ShowDialog(new LandWin.Configuration.VisitTypesFrm());
            }
            else
            {
                Shared.Utility.UnAuthorizedMessage();
            }
        }
        private void btnSubDivision_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_entity.bizAdmin.SubDivisions.CanGetObject())
            {
                ShowDialog(new LandWin.Configuration.SubDivisionFrm());
            }
            else
            {
                Shared.Utility.UnAuthorizedMessage();
            }
        }
        

        private void btnStatusType_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_entity.bizAdmin.StatusTypes.CanGetObject())
            {
                ShowDialog(new LandWin.Configuration.StatusTypeFrm());
            }
            else
            {
                Shared.Utility.UnAuthorizedMessage();
            }
        }


        private void ShowDialog(Form frm)
        {
            frm.ShowDialog();
            frm.Dispose();
        }
      




        #endregion


        #region Modules 

        private void ShowMemberStatus_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Dothan.Library.Security.PTPrincipal user = (Dothan.Library.Security.PTPrincipal)Dothan.ApplicationContext.User;
            Dothan.Library.Security.PTIdentity identity = (Dothan.Library.Security.PTIdentity)user.Identity;
            if (identity.NumberOfRoles > 0)
            {
                ShowStatusPart();
            }
            else
            {
                Shared.Utility.UnAuthorizedMessage();
            }
        }
        
        private void ShowMemberList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowMemberPart();
        }
        private void ShowFelloswship_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_entity.bizFellowship.FellowshipMembers.CanGetObject())
            {
                ShowFellowshipPart();
            }
            else
            {
                Shared.Utility.UnAuthorizedMessage();
            }
        }
        private void ShowMinistry_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(_entity.bizMinistry.MinistryMembers.CanGetObject())
            {
                ShowMinistryPart();
            }
            else
            {
                Shared.Utility.UnAuthorizedMessage();
            }
        }
        private void ShowDashBoard_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowHomePart();
        }
        private void ShowMemberVisit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_entity.bizMemberVisit.MemberVisit.CanGetObject())
            {
                ShowVisitPart();
            }
            else
            {
                Shared.Utility.UnAuthorizedMessage();
            }
        }
        private void ShowCell_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(_entity.bizCell.CellMembers.CanGetObject())
            {
                ShowCellPart();
             }
            else
            {
                Shared.Utility.UnAuthorizedMessage();
            }
        }
        private void ShowCellReport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Dothan.Library.Security.PTPrincipal user = (Dothan.Library.Security.PTPrincipal)Dothan.ApplicationContext.User;
            Dothan.Library.Security.PTIdentity identity = (Dothan.Library.Security.PTIdentity)user.Identity;
            if (identity.NumberOfRoles > 0)
            {
                ShowCellReportPart();
            }
            else
            {
                Shared.Utility.UnAuthorizedMessage();
            }

        }
        private void ShowDonate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(_entity.bizDonate.DonateBook.CanEditObject())
            {
                ShowDoantePart();
            }
            else
            {
                Shared.Utility.UnAuthorizedMessage();
            }
        }
        private void ShowDonateMange_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_entity.bizDonate.DonateBook.CanEditObject())
            {
                ShowDonateManage();
            }
            else
            {
                Shared.Utility.UnAuthorizedMessage();
            }
        }
        private void ShowEducation_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_entity.bizCourse.CourseMembers.CanEditObject())
            {
                ShowEducationPart();
            }
            else
            {
                Shared.Utility.UnAuthorizedMessage();
            }
        }

        private void ShowStatusPart()
        {
            AllCloseWinpart();
            AddWinPart(new MemberStatusPart());
        }
        private void ShowDoantePart()
        {
            AllCloseWinpart();
            AddWinPart(new DonateReports());
        }

        private void ShowCellPart()
        {

            AllCloseWinpart();
            AddWinPart(new CellPart());
        }
        private void ShowFellowshipPart()
        {
            AllCloseWinpart();
            AddWinPart(new FellowshipPart());
        }
        private void ShowMemberPart()
        {
            AllCloseWinpart();
            AddWinPart(new MemberListPart());
        }

        private void ShowMinistryPart()
        {
            AllCloseWinpart();
            AddWinPart(new MinistryPart());
        }
        public void ShowHomePart()
        {
            AllCloseWinpart();

            AddWinPart(new HomePart());

        }
        public void ShowCellReportPart()
        {
            AllCloseWinpart();

            AddWinPart(new CellReportPart());
        }
        public void ShowVisitPart()
        {
            AllCloseWinpart();
            AddWinPart(new VisitReportPart());
        }
        public void ShowDonateManage()
        {
            AllCloseWinpart();
            AddWinPart(new DonateManagePart());
        }
        public void ShowEducationPart()
        {
            AllCloseWinpart();
            AddWinPart(new EducationPart());
        }
        #endregion

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_memberfrmlist != null)
            {
                foreach (Tools.MemberInfoFrm item in _memberfrmlist)
                {
                    item.Close();
                }
            }
            Application.Exit();
        }


        #region Profile
       
        /// <summary>
        /// About Church : General Church Information
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChurch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_entity.bizAdmin.ChurchInfo.CanGetObject())
            {
                ShowDialog(new LandWin.Configuration.ChurchInfoFrm());
            }
            else
            {
                Shared.Utility.UnAuthorizedMessage();
            }
        }

        private void btnUser_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Dothan.ApplicationContext.User.IsInRole("SysAdmin"))
            {
                ShowUserPart();
            }
            else
            {
                LoadUserInformation();
            }
        }

        private void LoadUserInformation()
        {
            try
            {
                int id = (Dothan.ApplicationContext.User as _entity.Security.PTPrincipal).ID;
                _entity.bizAdmin.User _user = _entity.bizAdmin.User.Get(id);

                ShowDialog(new Configuration.UserFrm(_user));
            }
            catch (Dothan.DataPortalException ex)
            {
                if (ex.BusinessException is System.Data.SqlClient.SqlException)
                {
                    Shared.Utility.ErrorLogging(Properties.Resources.ErrorMessage_SqlException, ex.BusinessException.ToString(), "Error");
                    this.Close();
                }
                else if (ex.BusinessException is System.Security.SecurityException)
                {
                    MessageBox.Show(Properties.Resources.ErrorMassage_UnAuthorized);
                }
                else
                {
                    Shared.Utility.ErrorLogging(Properties.Resources.ErrorMessage_General, ex.BusinessException.ToString(), "Error");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Shared.Utility.ErrorLogging(Properties.Resources.ErrorMessage_General, ex.ToString(), "Error");
                this.Close();

            }

        }


        private void ShowUserPart()
        {
            
            foreach (Control ctl in Panel1.Controls)
            {
                if (ctl is Modules.UserPart)
                {
                    Modules.UserPart part = (Modules.UserPart)ctl;
                    ShowWinPart(part);
                    return;
                }
            }
            AddWinPart(new Modules.UserPart());

        }
        #endregion

        #region Report Tools
        
        private void btnPersonalAddressLabel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ReportPrint(1);
        }
        /// <summary>
        /// 교인 교적부
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMemberDetail_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            ReportPrint(2);
        }
        /// <summary>
        /// 교인 교적 카드
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMemberCard_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ReportPrint(3);
        }

        /// <summary>
        /// 교인 사진 명부
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMamberDetailwPic_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ReportPrint(4);
        }
        private void btnFamilyAddressLabel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ReportPrint(8);
        }

        
        
        /// <summary>
        ///세대별 가족현황 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ReportPrint(7);
        }
        /// <summary>
        /// 세대별 주소록
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ReportPrint(6);
        }
        /// <summary>
        /// 세대 명부
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ReportPrint(5);
        }



        private void ReportPrint(int reportName)
        {
            if (_currentCtl == null)
                return;

            if (_currentCtl.ReportView == null)
                return;

            string memberlist = _currentCtl.GetSelectedList();

            if (string.IsNullOrEmpty(memberlist))
                return;

            try
            {
                this.Cursor = Cursors.WaitCursor;
                Shared.ReprotManager manager = new LandWin.Shared.ReprotManager();
                switch (reportName)
                {
                    case 1:
                        manager.PrintAddressLabel(memberlist, false);
                        break;
                    case 2:
                        manager.PrintMemberDetails(memberlist);
                        break;
                    case 3:
                        manager.PrintMemberCard(memberlist);
                        break;
                    case 4:
                        manager.PrintMemberWithPic(memberlist);
                        break;
                    case 5:
                        manager.PrintFamilyList(memberlist);
                        break;
                    case 6:
                        manager.PrintFamilyAddressBook(memberlist);
                        break;
                    case 7:
                        manager.PrintMemberByFamily(memberlist);
                        break;
                    case 8:
                        manager.PrintAddressLabel(memberlist, true);
                        break;
                }
            }
            catch (Exception ex)
            {
                Shared.Utility.ErrorLogging(Properties.Resources.ErrorMessage_General, ex.ToString(), "Error");
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

        }
        
        #endregion

        #region DownLoad Images

        private void DownLoadImageFile()
        {
            try
            {
                StringBuilder str = GetFileList();


                if (str.Length > 0)
                {
                    str.Remove(str.ToString().LastIndexOf("\n"), 1);
                    string[] filelist = str.ToString().Split('\n');
                    if (filelist.Length > 0)
                    {

                        BackgroundWorker _worker = new BackgroundWorker();
                        _worker.WorkerReportsProgress = true;
                        _worker.DoWork += new DoWorkEventHandler(FTPDoWork);
                        _worker.RunWorkerAsync(filelist);

                    }
                    else
                    {
                        Shared.Utility.WriteAppSetting("UpdatedDate", DateTime.Now.ToString());
                        MessageBox.Show(Shared.Utility.ReadAppSetting("UpdatedDate"));
                    }
                }
                else
                {
                    Shared.Utility.WriteAppSetting("UpdatedDate", DateTime.Now.ToString());

                }
            }
            catch
            {
                MessageBox.Show("Ftp server is not acessible");

            }
        }
        private void FTPDoWork(object sender, DoWorkEventArgs e)
        {
            string ftphost = ConfigurationManager.AppSettings["FtpSite"].ToString();
            string userid = ConfigurationManager.AppSettings["FtpUser"].ToString();
            string ftpdirectory = ConfigurationManager.AppSettings["FtpDirectory"].ToString();
            string password = ConfigurationManager.AppSettings["FtpPassword"].ToString();
            string[] filelist = (string[])e.Argument;
            try
            {
                for (int i = 0; i < filelist.Length; i++)
                {

                   

                    FtpWebRequest reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + ftphost + "/" + ftpdirectory + "/" + filelist[i]));
                    reqFTP.Method = WebRequestMethods.Ftp.DownloadFile;
                    reqFTP.UseBinary = true;
                    reqFTP.UsePassive = false;
                    reqFTP.Credentials = new NetworkCredential(userid, password);
                    FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                    Stream ftpStream = response.GetResponseStream();
                    long cl = response.ContentLength;
                    int bufferSize = 2048;
                    int readCount;
                    byte[] buffer = new byte[bufferSize];
                    readCount = ftpStream.Read(buffer, 0, bufferSize); 
                    FileStream outputStream = new FileStream(ConfigurationManager.AppSettings["LocalFolder"].ToString() + "\\" + filelist[i], FileMode.Create);
                    while (readCount > 0)
                    {

                        outputStream.Write(buffer, 0, readCount);
                        readCount = ftpStream.Read(buffer, 0, bufferSize);

                    }
                    ftpStream.Close();
                    outputStream.Close();
                    response.Close();

                }
                Shared.Utility.WriteAppSetting("UpdatedDate", DateTime.Today.ToString());

            }
            catch
            {
                MessageBox.Show("Ftp server is not acessible");

            }
        }

        private Match GetMatchingRegex(string line)
        {
            string[] formats = { 
                        @"(?<timestamp>\d{2}\-\d{2}\-\d{2}\s+\d{2}:\d{2}[Aa|Pp][mM])\s+(?<dir>\<\w+\>){0,1}(?<size>\d+){0,1}\s+(?<name>.+)",
                        @"(?<timestamp>\d{2}\-\d{2}\-\d{4}\s+\d{2}:\d{2}[Aa|Pp][mM])\s+(?<dir>\<\w+\>){0,1}(?<size>\d+){0,1}\s+(?<name>.+)",
	                    @"(?<dir>[\-d])(?<permission>([\-r][\-w][\-xs]){3})\s+\d+\s+\w+\s+\w+\s+(?<size>\d+)\s+(?<timestamp>\w+\s+\d+\s+\d{4})\s+(?<name>.+)" ,
	                    @"(?<dir>[\-d])(?<permission>([\-r][\-w][\-xs]){3})\s+\d+\s+\d+\s+(?<size>\d+)\s+(?<timestamp>\w+\s+\d+\s+\d{4})\s+(?<name>.+)" ,
	                    @"(?<dir>[\-d])(?<permission>([\-r][\-w][\-xs]){3})\s+\d+\s+\d+\s+(?<size>\d+)\s+(?<timestamp>\w+\s+\d+\s+\d{1,2}:\d{2})\s+(?<name>.+)" ,
	                    @"(?<dir>[\-d])(?<permission>([\-r][\-w][\-xs]){3})\s+\d+\s+\w+\s+\w+\s+(?<size>\d+)\s+(?<timestamp>\w+\s+\d+\s+\d{1,2}:\d{2})\s+(?<name>.+)" ,
	                    @"(?<dir>[\-d])(?<permission>([\-r][\-w][\-xs]){3})(\s+)(?<size>(\d+))(\s+)(?<ctbit>(\w+\s\w+))(\s+)(?<size2>(\d+))\s+(?<timestamp>\w+\s+\d+\s+\d{2}:\d{2})\s+(?<name>.+)" };

            Regex rx;
            Match m;
            for (int i = 0; i < formats.Length; i++)  //As Integer = 0 To formats.Length - 1
            {
                rx = new Regex(formats[i], RegexOptions.IgnorePatternWhitespace);
                m = rx.Match(line);
                if (m.Success)
                {
                    return m;
                }
            }
            return null;
        }

        private StringBuilder GetFileList()
        {
            StringBuilder result = new StringBuilder();
            if (string.IsNullOrEmpty(Shared.Utility.ReadAppSetting("UpdatedDate")))
            {

                string file;
                string ftphost = ConfigurationManager.AppSettings["FtpSite"].ToString();
                string userid = ConfigurationManager.AppSettings["FtpUser"].ToString();
                string ftpdirectory = ConfigurationManager.AppSettings["FtpDirectory"].ToString();
                string password = ConfigurationManager.AppSettings["FtpPassword"].ToString();


                FtpWebRequest ftp;
                ftp = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + ftphost + "/" + ftpdirectory + "/"));
                ftp.Credentials = new NetworkCredential(userid, password);
                ftp.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                WebResponse response = ftp.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string line = reader.ReadLine();
                int total = 0;
                while (line != null)
                {
                    Match m = GetMatchingRegex(line);
                    total++;

                    if (m.Groups["name"].Value.Trim('\r').IndexOf("jpg") != -1)
                    {
                        file = string.Format("{0}\\{1}", ConfigurationManager.AppSettings["LocalFolder"].ToString(), m.Groups["name"].Value.Trim('\r'));

                        if (File.Exists(file))
                        {
                            FileInfo info = new FileInfo(file);
                            if (Convert.ToInt64(m.Groups["size"].Value) != info.Length)
                            {
                                info.Delete();
                                result.Append(m.Groups["name"].Value.Trim('\r'));
                                result.Append("\n");
                            }
                        }
                        else
                        {
                            result.Append(m.Groups["name"].Value.Trim('\r'));
                            result.Append("\n");

                        }
                    }
                    line = reader.ReadLine();

                }
                reader.Close();
                response.Close();
            }
            else
            {

                _entity.FileLog list = _entity.FileLog.Get(Shared.Utility.ReadAppSetting("UpdatedDate"));
                for (int i = 0; i < list.Count; i++)
                {
                    result.Append(list[i].Value.Trim('\r'));
                    result.Append("\n");
                }
            }
            return result;
        }


        #endregion

        #region Export Excel

        private void btnExportData_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_currentCtl.ReportView == null)
                return;

            string fileName = ShowSaveFileDialog("Microsoft Excel Document", "Microsoft Excel|*.xls");
            if(fileName != "") 
            {
                try
                {
                    this.progressBarControl1.Show();
                    ExportTo(new ExportXlsProvider(fileName));
                    OpenFile(fileName);

                }
                finally
                {
                     this.progressBarControl1.Visible = false;
                }
            }


        }
        private void OpenFile(string fileName)
        {
            this.progressBarControl1.Visible = false;
            if (XtraMessageBox.Show("Do you want to open this file?", "Export To...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    process.StartInfo.FileName = fileName;
                    process.StartInfo.Verb = "Open";
                    process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
                    process.Start();
                }
                catch
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(this, "Cannot find an application on your system suitable for openning the file with exported data.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            progressBarControl1.Position = 0;
        }

        private void ExportTo(IExportProvider provider)
        {
            Cursor currentCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;

            this.FindForm().Refresh();
            BaseExportLink link = _currentCtl.ReportView.CreateExportLink(provider);
            (link as GridViewExportLink).ExpandAll = false;
            link.Progress += new DevExpress.XtraGrid.Export.ProgressEventHandler(Export_Progress);
            link.ExportTo(true);
            provider.Dispose();
            link.Progress -= new DevExpress.XtraGrid.Export.ProgressEventHandler(Export_Progress);

            Cursor.Current = currentCursor;
        }
       
        private void Export_Progress(object sender, DevExpress.XtraGrid.Export.ProgressEventArgs e)
        {
            if (e.Phase == DevExpress.XtraGrid.Export.ExportPhase.Link)
            {
                 progressBarControl1.Position = e.Position;
                this.Update();
            }
        }


        private string ShowSaveFileDialog(string title, string filter)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            string name = Application.ProductName;
            int n = name.LastIndexOf(".") + 1;
            if (n > 0) name = name.Substring(n, name.Length - n);
            dlg.Title = "Export To " + title;
            dlg.FileName = name;
            dlg.Filter = filter;
            if (dlg.ShowDialog() == DialogResult.OK) return dlg.FileName;
            return "";
        }

        #endregion

        #region Import Data

        private void btnImportData_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_currentCtl == null)
                return;

            if (_currentCtl.ReportView == null)
                return;

            if (_currentCtl.IsReadOnly == true)
                return;


            ImportData();
        }

        private void ImportData()
        {
            using (LandWin.Tools.ImportFromExcelFrm frm = new LandWin.Tools.ImportFromExcelFrm())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {

                    this.Enabled = false;
                    this.Cursor = Cursors.WaitCursor;
                    try
                    {
                        _entity.bizMember.MemberList list = _entity.bizMember.MemberList.GetListByIdList(frm.MemberList.ToString().TrimEnd(','));

                        _currentCtl.ImportMemberList(list);

                    }
                    catch (Dothan.DataPortalException ex)
                    {
                        if (ex.BusinessException is System.Data.SqlClient.SqlException)
                        {
                            Shared.Utility.ErrorLogging(Properties.Resources.ErrorMessage_SqlException, ex.BusinessException.ToString(), "Error");

                        }
                        else
                        {
                            Shared.Utility.ErrorLogging(Properties.Resources.ErrorMessage_General, ex.BusinessException.ToString(), "Error");

                        }
                    }
                    catch (Exception ex)
                    {
                        Shared.Utility.ErrorLogging(Properties.Resources.ErrorMessage_General, ex.ToString(), "Error");
                    }
                    finally
                    {
                        this.Cursor = Cursors.Default;
                        this.Enabled = true;

                    }
                }
            }
        }
            
        #endregion


        #region Export File

        private void SaveXMLFile()
        {
            if (_currentCtl.ReportView == null)
                return;

            this.Enabled = false;
            BackgroundWorker _worker = new BackgroundWorker();
            _worker.WorkerReportsProgress = true;
            _worker.DoWork += new DoWorkEventHandler(DoWork);

            _worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bg_RunWorkerCompleted);
            _worker.RunWorkerAsync(_currentCtl.ReportView);

        }
        private void bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Enabled = true;
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.InitialDirectory = ConfigurationManager.AppSettings["DirXmlData"].ToString();
            dlg.Filter = "xml files (*.xml)|*.xml";
            dlg.FilterIndex = 2;
            dlg.RestoreDirectory = true;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string filename = dlg.FileName;
                if (File.Exists(filename))
                {
                    DialogResult result = XtraMessageBox.Show(string.Format("{0} file is existed. Do you want to overwrite it?", filename), "Important Message", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        File.Delete(filename);
                        oXmlDocument.Save(filename);
                        XtraMessageBox.Show(LandWin.Properties.Resources.Success_Save, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    oXmlDocument.Save(filename);
                    XtraMessageBox.Show(LandWin.Properties.Resources.Success_Save, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }

        }
        private void DoWork(object sender, DoWorkEventArgs e)
        {

            GridView ReportView = (GridView)e.Argument;

            oXmlDocument = new XmlDocument();
            XmlNode oXMLMainNode;
            XmlNode oXMLNode;
            oXmlDocument.CreateXmlDeclaration("1.0", "UTF-8", null);

            oXMLMainNode = oXmlDocument.CreateNode(XmlNodeType.Element, "MemberList", string.Empty);
            XmlAttribute oXmlAttribute = oXmlDocument.CreateAttribute("FileName");
            oXmlAttribute.Value = "DataList";
            oXMLMainNode.Attributes.Append(oXmlAttribute);
            oXmlDocument.AppendChild(oXMLMainNode);
            for (int i = 0; i < ReportView.SelectedRowsCount; i++)
            {
                this.progressBarControl1.Position = i;

                int row = (ReportView.GetSelectedRows()[i]);
                oXMLNode = oXmlDocument.CreateNode(XmlNodeType.Element, "List", string.Empty);
                oXMLMainNode.AppendChild(oXMLNode);
                Shared.Utility.AddXMLAttribute(oXmlDocument, oXMLNode, "ID", ReportView.GetRowCellValue(row, "MemberId").ToString());
                Shared.Utility.AddXMLAttribute(oXmlDocument, oXMLNode, "MemberName", ReportView.GetRowCellValue(row, "FullName").ToString());

            }


        }
        #endregion

        private void MainForm_Load(object sender, EventArgs e)
        {

            ShowDashBoard_ItemClick(null, null);
        }

        private void btnShowGroupHeader_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _currentCtl.ShowGroupPanel();
        }

        private void btnShowFiltering_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _currentCtl.ShowFilterRow();
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _currentCtl.HideGroupPanel();
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _currentCtl.HideFilterRow();
        }










    }
}