using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using _entity = Dothan.Library;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using LandWin.Properties;
using System.Linq;

using System.Threading;

namespace LandWin.Modules
{
    public partial class CellReportPart : WinPart
    {
        private const string _szName = "CellReportGrid";

        private delegate void DataLoadDelegate();
        private _entity.bizCell.CellReportList _list;
        private _entity.bizCell.CellReport _report;
        private _entity.bizCell.CellReportDetails _reportDetail;
        public override GridView ReportView
        {
            get
            {
                return gridView1;
            }
        }
        public override bool IsReadOnly
        {
            get
            {
                return true;
            }
        }
        
        public CellReportPart()
        {
            InitializeComponent();
            Shared.UtiltyDevExpress.InitGridView(this.gridView1, _szName);
            this.cellListBindingSource.DataSource = _entity.bizCell.CellList.Get(true);

            Reset();
            LoadCellReportList();
        }

        private void Reset()
        {
            this.txtCellList.EditValue = 0;
            this.txtFromDate.EditValue = DateTime.Today.AddMonths(-3);
            this.txtToDate.EditValue = DateTime.Today;
       
        }
        protected internal override object GetIdValue()
        {
            return Resources.CellReport_Manage.ToString();
        }

  
        
        protected string GetSelectedRowList()
        {
            object[] list = Shared.UtiltyDevExpress.SelectedRows(this.gridView1);
            StringBuilder str = new StringBuilder();
            foreach(object info in list)
            {
                str.Append((info as _entity.bizCell.CellReportInfo).ID).Append(",") ;
            }
            return str.ToString();
        }

    
        private void bt_Search_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Thread t = new Thread(new ThreadStart(new DataLoadDelegate(LoadCellReportList)));
            t.Start();
            t.Join();
            this.Cursor = Cursors.Default;
        }

        private void RefreshBinding()
        {
            ThreadPool.QueueUserWorkItem(FillData);
        }

        void FillData(object state)
        {
            while (!this.IsHandleCreated)
            {
                if (!this.IsDisposed) return;

                System.Threading.Thread.Sleep(2000);
            }
            this.Invoke((MethodInvoker)delegate
            {
                this.cellReportListBindingSource.DataSource = _list;
                this.gridView1.RefreshData();
                this.gridView1.BestFitColumns();
            });
        }


        private void btnAddReport_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.popupControlContainer1.Show();
            this.popupControlContainer1.BringToFront();
        }

        private void btnSelected_ItemClick(object sender, EventArgs e)
        {
           
            int code = (int)this.txtCellCode.EditValue;

            if (code.Equals(0))
            {
                MessageBox.Show("Please Select a Cell");
                return;
            }

            LoadCellReport(code, true);

            this.popupControlContainer1.Hide();
            
        }
        private void bt_Reset_ItemClick(object sender, ItemClickEventArgs e)
        {
            Reset();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            GridHitInfo info = view.CalcHitInfo(pt);
            if (info.InRow || info.InRowCell)
            {
                _entity.bizCell.CellReportInfo item = this.gridView1.GetRow(info.RowHandle) as _entity.bizCell.CellReportInfo;
                LoadCellReport(item.ID, false);
            }
        }



        private void LoadCellReportList()
        {
            try
            {
                _list = _entity.bizCell.CellReportList.GetList((int)this.txtCellList.EditValue , this.txtFromDate.EditValue.ToString(),this.txtToDate.EditValue.ToString(),string.Empty);

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

        private void RebindingCellReport(bool isNew)
        {
            _report.BeginEdit();
            _reportDetail.BeginEdit();
            if (isNew)
            {
                var members = (from list in _reportDetail
                               where list.RoleLevel == 1
                               select new { list.MemberName }).FirstOrDefault();

                if (members != null)
                    _report.Level1 = members.MemberName;

                var members2 = (from list in _reportDetail
                                where list.RoleLevel == 2
                                select new { list.MemberName }).FirstOrDefault();

                if (members2 != null)
                    _report.Level2 = members2.MemberName;
                _report.CellName = ((_entity.bizCell.CellList)this.cellListBindingSource.DataSource).Value(_report.CellCode);
            }
           
            this.cellReportBindingSource.DataSource = _report;
            this.cellReportDetailsBindingSource.DataSource = _reportDetail;
            this.gridView2.RefreshData();
            this.advBandedGridView1.Bands[0].Caption = "ID:" + _report.Id + "       순명:" + _report.CellName + "       인도자:" + _report.Leader + "\n" +
                                                       "작성일:" + _report.RegDate + "       모임일:" + _report.CellDate + "       Prayer:" + _report.Prayer + "\n" +
                                                       "모임장소:" + _report.CellPlace + "       참석수:" + _report.Attendence + "       참석가정수:" + _report.AttendFamily + "\n" +
                                                       "새교인:" + _report.NewMember + "\n" +
                                                       "Memo:" + _report.Memo + "\n" +
                                                       "요청사항:" + _report.Request;
            this.advBandedGridView1.RefreshData();
        }


        private void LoadCellReport(int id , bool isNew)
        {
            try
            {
                if(isNew)
                {
                    _report = _entity.bizCell.CellReport.New(id);
                }
                else
                {
                    _report = _entity.bizCell.CellReport.Get(id);
                   
                } 
                _reportDetail = _entity.bizCell.CellReportDetails.Get(id , isNew);
                RebindingCellReport(isNew);

                this.dockPanel1.Show();
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
  


        private void KeyPress_Enter(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void DateTextEdit_Leave(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.TextEdit edit = (DevExpress.XtraEditors.TextEdit)sender;
            if (Shared.Utility.ValidateDatetime(edit.Text))
                SendKeys.Send("{TAB}");
            else
            {
                XtraMessageBox.Show("Invalid DataType: It is invalid. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                edit.Text = _report.RegDate;
            }
        }

        private void barPrint_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.gridView1 == null || this.gridView1.SelectedRowsCount == 0) return;
            string str = GetSelectedRowList();
            try
            {
                Shared.ReprotManager manager = new Shared.ReprotManager();
                manager.RunCellReportPrint(str);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error Printing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void pictureEdit1_Click(object sender, EventArgs e)
        {
            Shared.UtiltyDevExpress.Calendar(RegDateTextEdit);
        }

        private void pictureEdit2_Click(object sender, EventArgs e)
        {
            Shared.UtiltyDevExpress.Calendar(CellDateTextEdit);
        }


        private void SaveCellReport()
        {
            this.cellReportBindingSource.EndEdit();
            this.cellReportDetailsBindingSource.EndEdit();
            this.cellReportBindingSource.RaiseListChangedEvents = false;
            this.cellReportDetailsBindingSource.RaiseListChangedEvents = false;
            try
            {
                _entity.bizCell.CellReport temp = _report.Clone();
                temp.ApplyEdit();
                _report = temp.Save();
                
                this.cellReportBindingSource.DataSource = _report;
                _reportDetail.ParentCode = _report.Id;

                _entity.bizCell.CellReportDetails tempDetail = _reportDetail.Clone();
                tempDetail.ApplyEdit();

                _reportDetail = tempDetail.Save();

                MessageBox.Show(Properties.Resources.Success_Save);
                _report.BeginEdit();
                this.cellReportBindingSource.DataSource = null;
                this.cellReportBindingSource.DataSource = _report;

                this.dockPanel1.Hide();
                LoadCellReportList();
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

                this.cellReportBindingSource.RaiseListChangedEvents = true;
                this.cellReportDetailsBindingSource.RaiseListChangedEvents = true;
               
            }
        }

        private void bt_RemoveReport_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (_report == null) return;

            if (_reportDetail == null) return;

            if (!_entity.bizCell.CellReport.CanDeleteObject())
            {
                MessageBox.Show(Resources.ErrorMassage_UnAuthorized);
                return;
            }

            DialogResult result2 = MessageBox.Show(Properties.Resources.Questions_Delete, "Warnning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result2 == DialogResult.Yes)
            {
                DeleteReport();
            }
        }

        private void DeleteReport()
        {
            try
            {
                this.cellReportDetailsBindingSource.RaiseListChangedEvents = false;
                this.cellReportBindingSource.RaiseListChangedEvents = false;
                _entity.bizCell.CellReport.Delete(_report.Id, Dothan.ApplicationContext.User.Identity.Name);

                _report = null;
                _reportDetail = null;
 
                this.dockPanel1.Hide();
                LoadCellReportList();
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
                this.cellReportDetailsBindingSource.RaiseListChangedEvents = true;
                this.cellReportBindingSource.RaiseListChangedEvents = true;
                
            }
        }
        private void btnSaveReport_Click(object sender, EventArgs e)
        {
            if (_report == null) return;

            if (_reportDetail == null) return;

            if (!_entity.bizCell.CellReport.CanEditObject())
            {
                MessageBox.Show(Resources.ErrorMassage_UnAuthorized);
                return;
            }
            SaveCellReport();
        }

 

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.popupControlContainer1.Hide();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (_report == null)
            {

                MessageBox.Show("순을 선택해 주세요.");

            }
            else
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string fileName = path + "\\" + _report.CellName + "cell_" + _report.CellDate.Replace("-", "") + ".xlsx";
                gridControl3.ExportToXlsx(fileName);
                MessageBox.Show("'" + _report.CellName + "cell_" + _report.CellDate.Replace("-", "") + ".xlsx' has been exported to your desktop!");

            }
        }


    }
}
