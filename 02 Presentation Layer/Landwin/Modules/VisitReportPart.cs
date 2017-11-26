using System;
using System.Drawing;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;
using _entity = Dothan.Library;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraEditors;
using System.Collections;
using System.Threading;
using System.Data.SqlClient;

namespace LandWin.Modules
{
    public partial class VisitReportPart :WinPart
    {
        private _entity.bizMemberVisit.VisitReportList _list;
        private _entity.bizMemberVisit.MemberVisit _report;

        public const string LayoutName = "VisitReportGridView";
        public override bool IsReadOnly
        {
            get
            {
                return true;
            }
        }
        public override GridView ReportView
        {
            get
            {
                return gridView1;
            }
        }


        private delegate void DataLoadDelegate();

        public VisitReportPart()
        {
            InitializeComponent();
            Shared.UtiltyDevExpress.InitGridView(this.gridView1, LayoutName);
            gridView1.DoubleClick += new System.EventHandler(ShowVisitReport_DoubleClick);

            gridView1.ShowGridMenu += new DevExpress.XtraGrid.Views.Grid.GridMenuEventHandler(m_ShowGridMenu);
            this.dockPanel1.Hide();

            LoadDefaultData();

            Reset();
            SetRecorderList();

        }


        #region Load / Save Business Data


        private void LoadDefaultData()
        {
            try
            {
                this.cellListBindingSource.DataSource = _entity.bizCell.CellList.Get(true);
                this.visitTypeListBindingSource.DataSource = _entity.bizCommon.TypeList.Get("visit", true);
                this.visitRecordersBindingSource.DataSource = _entity.bizMember.VisitRecorders.Get();
                this.ddlVisitType.EditValue = 0;
              
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
        
        }

        private void LoadVisitReport(int id)
        {
            try
            {
                    btnSaveReport.Enabled = _entity.bizMemberVisit.MemberVisit.CanEditObject();
                    if (id == 0)
                    {
                        _report = _entity.bizMemberVisit.MemberVisit.New();
                    }
                    else
                    {
                        _report = _entity.bizMemberVisit.MemberVisit.Get(id);

                        if (_report.Recorder != ((Dothan.Library.Security.PTPrincipal)Dothan.ApplicationContext.User).UserName)
                        {
                            btnSaveReport.Enabled = false;
                        }

                    }
                    _report.BeginEdit();

                    _report.PropertyChanged += new PropertyChangedEventHandler(ReportPropertyChanged);
                    this.memberVisitBindingSource.DataSource = _report;
                    this.memberVisitBindingSource.ResetBindings(false);
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
        
        }
        private void LoadVisitReportList()
        {
            try
            {

                _list = _entity.bizMemberVisit.VisitReportList.Get(0,(string)ddlUsers.EditValue, txtStartDate.EditValue.ToString(), txtEndDate.EditValue.ToString(), (int)ddlCell.EditValue, (int)ddlVisitType.EditValue);
                RefreshBinding();
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
        }

        private void SaveReport()
        {
            this.memberVisitBindingSource.EndEdit();
            this.memberVisitBindingSource.RaiseListChangedEvents = false;

            _entity.bizMemberVisit.MemberVisit temp = _report.Clone();
            temp.ApplyEdit();
            try
            {
                _report = temp.Save();
                MessageBox.Show(Properties.Resources.Success_Save);

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
                this.memberVisitBindingSource.RaiseListChangedEvents = true;
            }
      
        }


        private void StartThreadForLoad()
        {
            Thread t = new Thread(new ThreadStart(new DataLoadDelegate(LoadVisitReportList)));
            t.Start();
            t.Join();
        }
 

        private void RefreshBinding()
        {
            ThreadPool.QueueUserWorkItem(FillData);
        }

        private void FillData(object state)
        {
            while (!this.IsHandleCreated)
            {
                if (!this.IsDisposed) return;

                System.Threading.Thread.Sleep(2000);
            }

            this.Invoke((MethodInvoker)delegate
            {

                this.visitReportListBindingSource.DataSource = _list;
             
                this.gridView1.RefreshData();
                this.gridView1.BestFitColumns();

            });
        }
    
        #endregion

        private void ToPrintVisitReportList_Click(object sender, ItemClickEventArgs e)
        {
            GridView view = this.gridView1;
            if (view == null || view.SelectedRowsCount == 0) return;
            string str = Shared.UtiltyDevExpress.GetStringSelectedRow(this.gridView1,"ID");
            try
            {
                Shared.ReprotManager manager = new Shared.ReprotManager();
                manager.RunVisitReport(str);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error Printing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void ToPrintMemberVistiReport_Click(object sender, ItemClickEventArgs e)
        {
            if (this.gridView1 == null || this.gridView1.SelectedRowsCount == 0) return;
            string str = Shared.UtiltyDevExpress.GetStringSelectedRow(this.gridView1, "MemberId");
            try
            {
                Shared.ReprotManager manager = new Shared.ReprotManager(); ;
                manager.RunMemberVisitReport(str);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error Printing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


        }



        protected void SetRecorderList()
        {
            if (!_entity.bizMemberVisit.MemberVisit.CanGetAllObject())
            {
                ddlUsers.EditValue = ((Dothan.Library.Security.PTPrincipal)Dothan.ApplicationContext.User).UserName;
                ddlUsers.Enabled = false;
            }
            
        }
        protected internal override object GetIdValue()
        {
            return Properties.Resources.Visit_Manage;
        }

        protected void Reset()
        {
            ddlCell.EditValue = 0;
            ddlVisitType.EditValue = 0;
            txtStartDate.EditValue = DateTime.Today.AddMonths(-2).ToString("MM/dd/yyyy");
            txtEndDate.EditValue = DateTime.Today;
        }



        private void btnSearch_ItemClick(object sender, ItemClickEventArgs e)
        {
           StartThreadForLoad();
        }

     

        private void ShowVisitReport_DoubleClick(object sender, EventArgs e)
        {
            this.dockPanel1.Show();

            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            GridHitInfo info = view.CalcHitInfo(pt);
            if (info.InRow || info.InRowCell)
            {
                _entity.bizMemberVisit.VisitReportInfo item = this.gridView1.GetRow(info.RowHandle) as _entity.bizMemberVisit.VisitReportInfo;
                LoadVisitReport(item.ID);

            }
        }


        private void bt_Reset_ItemClick(object sender, ItemClickEventArgs e)
        {
            Reset();
        }

        


        protected void ClearMemberVisit()
        {
            PastorTextEdit.Text = "";
            VisitdateTextEdit.Text = "";
            ContentMemoEdit.Text = "";
            SongTextEdit.Text = "";
            RecorderTextEdit.Text = "";
            BibleTextEdit.Text = "";
            VisitTypeLookUpEdit.EditValue = 0;
            AttendentTextEdit.Text = "";
            IDSpinEdit.Value = 0;
            MemberIdTextEdit.Text = "";
            FullNameTextEdit.Text = "";
        }
        private void btnAddreport_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.dockPanel1.Show();
            LoadVisitReport(0);
        }

        private void ReportPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "MemberId")
            {
                CheckMemberID(_report.MemberId);
            }
        }

        private void CheckMemberID(int code)
        {
            try
            {
                if (code == 0)
                    throw new Exception();

                _entity.bizMember.MemberList list = _entity.bizMember.MemberList.Get(code);

                if (list.Count == 0)
                    throw new Exception();

                _report.FullName = list[0].Ko_Name;

                VisitdateTextEdit.Focus();
            }
            catch
            {
                MessageBox.Show("교인번호가 맞지 않습니다.", "Error loading", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.MemberIdTextEdit.Focus();
            }
        }


        private void btnSaveReport_Click(object sender, EventArgs e)
        {
            SaveReport();
        }

  

        
     
    }
}
