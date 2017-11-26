using System;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using _entity = Dothan.Library;
using LandWin.Properties;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraEditors;
using System.Collections;
using LandWin.Tools;
using System.Threading;
using System.Data.SqlClient;

namespace LandWin.Modules
{
    public partial class DonateManagePart : WinPart
    {
        //private MemberDonates _list;
        private _entity.bizDonate.MemberDonateInfo _original;
        private ArrayList _arraylist = new ArrayList();

        public const string LayoutName = "DonateManager";

        public override GridView ReportView { get { return gridView1; } }


        private Dictionary<string, string> _donatetype = new Dictionary<string, string>();
        private _entity.bizDonate.MemberDonateList _list;

        private delegate void DataLoadDelegate();

        public DonateManagePart()
        {
            InitializeComponent();
            Shared.UtiltyDevExpress.InitGridView(this.gridView1, LayoutName);

            this.gridView1.DoubleClick += new EventHandler(gridView1_DoubleClick);

            LoadDefaultData();

            Reset();
            InitialColumn();
        }

        #region Business Data Handle
        private void LoadDefaultData()
        {
            try
            {
                this.fellowshipsListBindingSource.DataSource = _entity.bizFellowship.FellowshipsList.Get(true);
                this.yearListBindingSource.DataSource = _entity.bizDonate.YearList.Get();

                _entity.bizDonate.DonateTypes list = _entity.bizDonate.DonateTypes.GetList();

                var query = from info in list
                            where info.ParentCode == 0
                            select new { Key = info.Code, Value = info.Name };

                _donatetype = query.ToDictionary(entry => entry.Key.ToString(), entry => entry.Value);


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



        private void LoadMemberDonate()
        {
            int membertype = txtMemberType.SelectedIndex;
            string startdate = string.Empty;
            string enddate = string.Empty;
            
            
            int memberid = 0;
            int fellowship = (int)txtFellowship.EditValue;

            if (!int.TryParse(txtMemberId.Text, out memberid))
            {
                txtMemberId.Text = "";

            }

            
            if (txtStartDate.EditValue != null)
                startdate = txtStartDate.EditValue.ToString();
            if (txtEndDate.EditValue != null)
                enddate = txtEndDate.EditValue.ToString();



            try
            {
                _list = _entity.bizDonate.MemberDonateList.GetList(txtKoName.Text, txtEnFirstName.Text, txtEnLastName.Text, membertype, startdate, enddate,fellowship, memberid,  (int)txtYear.EditValue);
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

        private void StartThreadForLoad()
        {

            Thread t = new Thread(new ThreadStart(new DataLoadDelegate(LoadMemberDonate)));
            t.Start();
            t.Join();
        }

        private void PrintMemberDonate_Click(object sender, EventArgs e)
        {
            this.popupContainerControl1.Hide();

            _entity.bizDonate.MemberDonateInfo info = gridView1.GetRow(gridView1.FocusedRowHandle) as _entity.bizDonate.MemberDonateInfo;
            
            PrintMemberDonate(info.ID, (int)lookUpEdit1.EditValue , this.checkEdit1.Checked);
        }

        private void PrintMemberDonate(int donateid , int year , bool family)
        {
            try
            {
                Shared.ReprotManager manager = new Shared.ReprotManager();
                manager.RunMemberDonate(donateid, year, family);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error Printing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void MergeDonate(int originalID , string targetID)
        {
            try
            {
                int affected = _entity.bizDonate.DonateMember.MergeDonateMember(originalID, targetID , Dothan.ApplicationContext.User.Identity.Name);
                MessageBox.Show(string.Format("{0}. {1} number of donate has been merged.", Resources.Success_Save , affected));
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
                _original = null;
                _arraylist.Clear();
                listView2.Items.Clear();
                textEdit1.Text = "";
                textEdit2.Text = "";
            }
        }


        private void EditMember(_entity.bizDonate.DonateMember member)
        {
            using (DonateMemberFrm frm = new DonateMemberFrm(member))
            {
                frm.ShowDialog();
                frm.Dispose();
            }
        }

        #endregion


        private void Reset()
        {
            txtMemberId.Text = "";
            txtKoName.Text = "";
            txtEnLastName.Text = "";
            txtEnFirstName.Text = "";
            txtFellowship.EditValue = 0;
            txtYear.EditValue = DateTime.Today.Year;
            txtMemberType.SelectedIndex = 0;
        }


        #region   Gridiview Functions
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

                this.memberDonateListBindingSource.DataSource = _list;

                this.gridView1.RefreshData();
                this.gridView1.BestFitColumns();

            });
        }

        private void AddColumn(string name, string key)
        {
            DevExpress.XtraGrid.Columns.GridColumn column = new DevExpress.XtraGrid.Columns.GridColumn();
            column.Caption = name;
            column.FieldName = key;
            column.VisibleIndex = this.gridView1.Columns.Count;
            column.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            column.DisplayFormat.FormatString = "c2";
            column.SummaryItem.DisplayFormat = "Total : {0:c}";
            column.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.gridView1.Columns.Add(column);
        }

        private void InitialColumn()
        {
            foreach (var item in _donatetype)
            {
                AddColumn(item.Value, item.Key.ToString());
            }
            this.gridView1.CustomUnboundColumnData += new CustomColumnDataEventHandler(Gridview_CustomUnboundColumnData);
            this.gridView1.DoubleClick += new EventHandler(gridView1_DoubleClick);
        }

        protected void Gridview_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e)
        {

            if (_list == null) return;
            if (e.IsGetData)
            {
                if (_donatetype.ContainsKey(e.Column.FieldName))
                {
                    _entity.bizDonate.MemberDonateInfo info = this.gridView1.GetRow(e.RowHandle) as _entity.bizDonate.MemberDonateInfo;

                    e.Value = info.GetDonate(Convert.ToInt32(e.Column.FieldName));
                }
            }
        }

        private void layoutControl1_GroupExpandChanged(object sender, DevExpress.XtraLayout.Utils.LayoutGroupEventArgs e)
        {
            if (this.groupSpecificDate.Expanded)
            {
                this.txtYear.Enabled = false;
                this.txtYear.EditValue = 0;
                this.txtEndDate.EditValue = DateTime.Today;
            }
            else
            {
                this.txtYear.Enabled = true;
                this.txtYear.EditValue = DateTime.Today.Year;
                this.txtStartDate.EditValue = null;
                this.txtEndDate.EditValue = null;

            }
        }

        private void EditMember_Click(object sender, ItemClickEventArgs e)
        {
            _entity.bizDonate.DonateMember member = _entity.bizDonate.DonateMember.Get((int)this.gridView1.GetRowCellValue(this.gridView1.GetSelectedRows()[0], "ID"));
            EditMember(member);
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            GridHitInfo info = view.CalcHitInfo(pt);
            if (info.InRow || info.InRowCell)
            {
                try
                {
                    _entity.bizDonate.DonateMember member = _entity.bizDonate.DonateMember.Get((int)view.GetRowCellValue(info.RowHandle, "ID"));
                    EditMember(member);
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
        }


        #endregion

        #region WinPart Code



        protected internal override object GetIdValue()
        {
            return Resources.Donate_Manage.ToString();
        }


        #endregion

        private void btnFind_Click(object sender, EventArgs e)
        {
            StartThreadForLoad();
        }



        private void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (this.gridView1.SelectedRowsCount == 0) return;

            this.popupContainerControl1.Show();
           
 
        }

        private void tb_setMember_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount == 1)
            {
               _original = gridView1.GetRow(gridView1.FocusedRowHandle) as _entity.bizDonate.MemberDonateInfo;
                textEdit1.Text = _original.MemberID.ToString();
                textEdit2.Text = _original.KoName;

            }
        }



        private void tb_addmember_Click(object sender, EventArgs e)
        {
            if (_original == null) return;
            if (gridView1.SelectedRowsCount == 0) return;

            for (int i = 0; i < ReportView.SelectedRowsCount; i++)
            {
                int row = (ReportView.GetSelectedRows()[i]);
                int id = (int)ReportView.GetRowCellValue(row, "MemberID");
                if (id == 0)
                {
                    int donateid = (int)ReportView.GetRowCellValue(row, "ID");

                    if (_arraylist.Contains(donateid))
                        MessageBox.Show(Resources.Duplicated_assign);
                    else
                    {
                        ListViewItem item = new ListViewItem();
                        item.Name = ReportView.GetRowCellValue(row, "ID").ToString();
                        item.Text = ReportView.GetRowCellValue(row, "KoName").ToString();
                        _arraylist.Add(donateid);
                        listView2.Items.Add(item);
                    }
                }
            }

        }
        private string GetListTostring()
        {
            StringBuilder str = new StringBuilder();
            foreach (int item in _arraylist)
            {
                str.Append(item.ToString()).Append(",");
            }
            return str.ToString();
        }


        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (this.listView2.SelectedItems.Count > 0)
            {
                foreach (ListViewItem item in this.listView2.SelectedItems)
                {
                    int id = int.Parse(item.Name);
                    _arraylist.Remove(id);
                    listView2.Items.Remove(item);

                }
            }
        }

        private void btnMergeData_Click(object sender, EventArgs e)
        {
            if (_original == null) 
                return;

            if (_arraylist.Count == 0) 
                return;
            
            DialogResult result = MessageBox.Show("헌금 내역을 병합하시길 원하십니까?", "Important Message", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                MergeDonate(_original.ID, GetListTostring());
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            this.popupContainerControl1.Hide();
        }

  


    }

}