using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using _entity = Dothan.Library;

namespace LandWin.Modules
{
    public partial class MemberStatusPart : WinPart
    {
        public MemberStatusPart()
        {
            InitializeComponent();
            this.txtFromDate.EditValueChanged += new EventHandler(ValidateDateTime);
            this.txtToDate.EditValueChanged += new EventHandler(ValidateDateTime);
            this.typeListBindingSource.DataSource = _entity.bizCommon.TypeList.Get("status", false);
            this.gridView1.DoubleClick += new EventHandler(GridViewRow_DoubleClick);

            gridView1.ShowGridMenu += new DevExpress.XtraGrid.Views.Grid.GridMenuEventHandler(m_ShowGridMenu);
            Reset();
        }


        #region WinPart Code
        protected internal override object GetIdValue()
        {
            return "Member Status Master";
        }

        private const string layoutName = "MemberStatusMaster";
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
        
        
        
        #endregion

        private void LoadStatusList()
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                string statuslist = string.Empty;
                string from  = string.Empty;
                string to = string.Empty;
                bool onlyfamily = false;

                if (txtOnlyFamily.EditValue != null)
                    onlyfamily = (bool)txtOnlyFamily.EditValue;

                if(txtFromDate.EditValue !=null)
                    from = txtFromDate.EditValue.ToString();
                
                if(txtToDate.EditValue != null)
                    to = txtToDate.EditValue.ToString();

                if (txtStatusList.EditValue != null)
                    statuslist = txtStatusList.EditValue.ToString();

                statusMemberListBindingSource.DataSource = _entity.bizMember.StatusMemberList.GetList( from,to,statuslist ,onlyfamily);

                this.gridView1.RefreshData();
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
                this.gridView1.BestFitColumns();
            }
        }

        private void btnFromDate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Shared.UtiltyDevExpress.Calendar(txtFromDate);
        }

        private void btnToDate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Shared.UtiltyDevExpress.Calendar(txtToDate);
        }

        private void btnSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadStatusList();
        }

        private void Reset()
        {
            this.txtFromDate.EditValue = DateTime.Today.AddMonths(-1).ToString("MM/dd/yyyy");
            this.txtToDate.EditValue = DateTime.Today.ToString("MM/dd/yyyy");

        }

        #region Print 


        protected void PrintStatusReportList_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.gridView1 == null || this.gridView1.SelectedRowsCount == 0) return;


            string str = Shared.UtiltyDevExpress.GetStringSelectedRow(this.gridView1,"ID");

            try
            {
                this.Cursor = Cursors.WaitCursor;
                Shared.ReprotManager manager = new Shared.ReprotManager();
                manager.PrintStatusReport(str);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error Printing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }


        protected void PrintStatusFamilyReportList_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.gridView1 == null || this.gridView1.SelectedRowsCount == 0) return;
            ;
            string memberlist = Shared.UtiltyDevExpress.GetStringSelectedRow(this.gridView1,"MemberId");

            try
            {
                Shared.ReprotManager manager = new Shared.ReprotManager();
                manager.PrintStatusFamily(memberlist);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error Printing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }




        #endregion
    }
}
