using System;
using System.Text;
using System.Windows.Forms;
using  _entity = Dothan.Library;
using LandWin.Properties;
using System.Linq;
using DevExpress.XtraTreeList;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraEditors;
using System.Threading;
using System.Collections;
using System.Data;

namespace LandWin.Modules
{
    public partial class CellPart : WinPart
    {

        private int _currentcode;
        private int _currentrole;
        private bool _withHistory = false;
        private string _from = string.Empty;
        private string _to = string.Empty;
        private _entity.bizCell.CellRoleList _roles;
        private _entity.bizCell.Cells _cells;
        private _entity.bizCell.CellMembers _memberlist;
        private  const string _layoutName = "CellGridView";

        private delegate void DataLoadDelegate();
        public override GridView ReportView { get { return gridView1; } }

        public CellPart()
        {
            InitializeComponent();
            Shared.UtiltyDevExpress.InitGridView(this.gridView1, _layoutName);
            LoadCells();
            LoadRoles();

            gridView1.DoubleClick += new System.EventHandler(GridViewRow_DoubleClick);
            gridView1.RowStyle += new RowStyleEventHandler(GridView_RowStyle);


            gridView1.ShowGridMenu += new DevExpress.XtraGrid.Views.Grid.GridMenuEventHandler(m_ShowGridMenu);

            clbcRole.ForceInitialize();
        }
     
        private void BindingRole()
        {
            for (int i = 0; i < _roles.Count; i++)
            {
                if (_roles[i].Key != 0)
                {
                    BarButtonItem BarItem = new BarButtonItem();
                    BarItem.Name = _roles[i].Key.ToString();
                    BarItem.Caption = _roles[i].Value;
                    BarItem.ItemClick += new ItemClickEventHandler(mRole_Click);
                    this.btnRoleList.ItemLinks.Add(BarItem);
                }
            }
        }
        private void LoadRoles()
        {
            try
            {
                _roles = _entity.bizCell.CellRoleList.Get(false);
                this.cellRoleListBindingSource.DataSource = _roles;
                BindingRole();
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


        private void LoadCells()
        {
            try
            {
                _cells = _entity.bizCell.Cells.Get();
                this.cellListBindingSource.DataSource = _entity.bizCell.CellList.Get(false);
                RefreshBindingCell();
           
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

        private void RefreshBindingCell()
        {
            this.cellsBindingSource.DataSource = from list in _cells
                                                 where list.Status != "D"
                                                 select list;
            this.treeList1.RefreshDataSource();
        }

        private void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        { 
            _currentrole = 0;
            _currentcode = ((_entity.bizCell.Cell)treeList1.GetDataRecordByNode(e.Node)).Code;
           

            StartThreadForLoad();
        }


        private void StartThreadForLoad()
        {
            Thread t = new Thread(new ThreadStart(new DataLoadDelegate(LoadCellMember)));
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
                if (this.IsDisposed) return;

                System.Threading.Thread.Sleep(2000);
            }

            this.Invoke((MethodInvoker)delegate
                       {
                           if (_withHistory)
                           {
                               this.cellMembersBindingSource.DataSource = _memberlist;
                           }
                           else
                           {
                               this.cellMembersBindingSource.DataSource = from list in _memberlist
                                                                          where list.EndDate == string.Empty
                                                                          select list;
                           }
                           this.gridView1.RefreshData();
                           this.gridView1.BestFitColumns();
                       });
        }

        private void LoadCellMember()
        {
            if (_memberlist != null && _memberlist.IsDirty)
            {
                DialogResult result = MessageBox.Show("Do you want to re-load without saving data?", "Important Message", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                    return;
            }
            try
            {
                _memberlist = _entity.bizCell.CellMembers.Get(_currentcode, _currentrole, _withHistory, _from, _to);

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


        protected void mRole_Click(object sender, ItemClickEventArgs e)
        {

            try
            {
                BarButtonItem item = (BarButtonItem)e.Item;
                _currentrole = Convert.ToInt32(e.Item.Name);
                _currentcode = 0;
                LoadCellMember();
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

  

        #region WinPart Code
        protected internal override object GetIdValue()
        {
            return Resources.Cell_Manage.ToString();
        }
        #endregion

 
        private void btnclose_Click(object sender, EventArgs e)
        {
            if (_memberlist.IsDirty)
            {
                DialogResult result = MessageBox.Show("Do you want to close without saving data?", "Important Message", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                    this.Close();
            }
            else
            {
                this.Close();
            }
        }

        private void btnCell_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!_entity.bizCell.CellMembers.CanEditObject())
            {
                MessageBox.Show(Resources.ErrorMassage_UnAuthorized);
                return;
            }

            Tools.CellListFrm frm = new LandWin.Tools.CellListFrm();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadCells();
            }
        }

        private void btnAssignMember_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (_currentcode == 0)
            {
                MessageBox.Show("Please Select a cell");
                return;
            }
            Tools.MemberSearchFrm frm = new LandWin.Tools.MemberSearchFrm(this);
            frm.ShowDialog();
            frm.Dispose();
        }

        private void btnSaveMemberlist_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!_entity.bizCell.CellMembers.CanEditObject())
            {
                MessageBox.Show(Resources.ErrorMassage_UnAuthorized);
                return;
            }

            SaveList();
           
        }

        public override void ImportMemberList(_entity.bizMember.MemberList list)
        {
            foreach (_entity.bizMember.MemberInfo item in list)
                AssignMember(item);



            RefreshBinding();
        }
        private void AssignMember(Dothan.Library.bizMember.MemberInfo info)
        {
            if (_memberlist.Contains(info.MemberId))
            {
                MessageBox.Show(Resources.Err_Duplicated);
                return;
            }
            _memberlist.Assign(info, _currentcode, DateTime.Today.ToString(), _roles[0].Key);
         
        }

        private void SaveList()
        {
            this.gridView1.PostEditor();
            this.cellMembersBindingSource.EndEdit();
            this.cellMembersBindingSource.RaiseListChangedEvents = false;

            this.Enabled = false;
            _entity.bizCell.CellMembers temp = _memberlist.Clone();
            temp.ApplyEdit();
            try
            {
                _memberlist = temp.Save();
                MessageBox.Show(Resources.Success_Save);
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
            finally
            {
                this.Enabled = true;
                this.Cursor = Cursors.Default;
                this.cellMembersBindingSource.RaiseListChangedEvents = true;
            }
        }

        private void Remove(object[] row)
        {
            foreach (object obj in row)
            {
                if ((obj as _entity.bizCell.CellMember).IsNew)
                {
                    _memberlist.Remove(obj as _entity.bizCell.CellMember);
                }
                else
                {
                    (obj as _entity.bizCell.CellMember).EndDate = DateTime.Today.ToString();

                }
            }
        }
        private void btApplyRole_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.gridView1 == null || this.gridView1.SelectedRowsCount == 0) return;

            if (txtSetRole.EditValue == null || (int)txtSetRole.EditValue == 0)
                return;


            object[] list = Shared.UtiltyDevExpress.SelectedRows(this.gridView1);
            foreach (object info in list)
            {
                (info as _entity.bizCell.CellMember).Role = (int)txtSetRole.EditValue;
            }

            this.gridView1.ClearSelection();
            RefreshBinding();
        }

        private void btnRemoveMember_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.gridView1 == null || this.gridView1.SelectedRowsCount == 0) return;

            if (_entity.bizCell.CellMembers.CanDeleteObject())
            {
                Remove(Shared.UtiltyDevExpress.SelectedRows(this.gridView1));
                RefreshBinding();
            }
            else
            {
                MessageBox.Show(Properties.Resources.ErrorMessage_Invalid);
            }
        }

        private void btnApplyRole_ItemClick(object sender, EventArgs e)
        {
            //if (this.gridView1 == null || this.gridView1.SelectedRowsCount == 0) return;

            //if (this.lookUpEdit1.EditValue == null || (int)lookUpEdit1.EditValue == 0)
            //    return;


            //object[] list = Shared.UtiltyDevExpress.SelectedRows(this.gridView1);
            //foreach (object info in list)
            //{
            //    (info as _entity.bizCell.CellMember).Role = (int)lookUpEdit1.EditValue;
            //}
            if (clbcRole.CheckedItems.Count == 0)
            {
                MessageBox.Show("직책을 선택해 주십시요.");
            }
            else
            {
                object[] list = Shared.UtiltyDevExpress.SelectedRows(this.gridView1);
                StringBuilder sb = new StringBuilder();
                //Dothan.NameValueListBase<int, string>.NameValuePair
                foreach (Dothan.NameValueListBase<int, string>.NameValuePair item in clbcRole.CheckedItems)
                {
                    sb.Append(item.Value + "/");
                }
                string roles = sb.ToString();
                roles = roles.Remove(roles.Length - 1);
                foreach (object info in list)
                {
                    (info as _entity.bizCell.CellMember).Roles = roles;
                }
                this.popupControlContainer1.Hide();
                this.gridView1.ClearSelection();
                RefreshBinding();
            }


        }


        private void btnTransferCell_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.gridView1 == null || this.gridView1.SelectedRowsCount == 0)
            {
                MessageBox.Show(Properties.Resources.No_SelectedRow);
                return;
            }
            this.popupControlContainer2.Show();
            this.popupControlContainer2.BringToFront();
        }

        private void btnApplyStartDate_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!_entity.bizCell.CellMembers.CanEditObject())
            {
                MessageBox.Show(Resources.ErrorMassage_UnAuthorized);
                return;
            }

            if (this.gridView1 == null || this.gridView1.SelectedRowsCount == 0)
            {
                MessageBox.Show(Properties.Resources.No_SelectedRow);
                return;
            }

            Tools.CalendarFrm dlg = new Tools.CalendarFrm();
            if (dlg.ShowDialog() == DialogResult.OK)
            {

                object[] list = Shared.UtiltyDevExpress.SelectedRows(this.gridView1);
                foreach (object info in list)
                {
                    (info as _entity.bizCell.CellMember).StartDate = dlg.SelectedDate.ToString();
                }
            }

            this.gridView1.ClearSelection();
            RefreshBinding();
        }

        private void repositoryItemTextEdit1_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                DevExpress.XtraEditors.TextEdit edit = (DevExpress.XtraEditors.TextEdit)sender;
                if (string.IsNullOrEmpty(edit.Text)) return;

                SearchByName(edit.Text);
            }
        }
        private void SearchByName(string name )
        {
           
            if (string.IsNullOrEmpty(name)) return;

            _entity.bizCell.CellMembers list = _entity.bizCell.CellMembers.GetListByName(name);

            if (list.Count == 0)
                XtraMessageBox.Show(Properties.Resources.No_result, "Import Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
            _memberlist = list;
              RefreshBinding();
            }
        }

 

        private void btnMemberSearch_ItemClick(object sender, ItemClickEventArgs e)
        {
            Tools.MemberSearchFrm frm = new LandWin.Tools.MemberSearchFrm(this);
            frm.ShowDialog();
            frm.Dispose();
        }


        private void ShowEndate(bool set)
        {
            this.colEnddate.Visible = set;
            this.bar2.Visible = set;
            _withHistory = set;
            if (set)
            {
                this.txtFromEndDate.EditValue = new DateTime(DateTime.Today.Year, 1, 1);
                this.txtToEndDate.EditValue = DateTime.Today;
            }
            else 
            {
                this.txtFromEndDate.EditValue = null;
                this.txtToEndDate.EditValue = null;
                _from = string.Empty;
                _to = string.Empty;
            }
        }

        private void btnApplyEndDate_ItemClick(object sender, ItemClickEventArgs e)
        {
            _from = this.txtFromEndDate.EditValue.ToString();
            _to = this.txtToEndDate.EditValue.ToString();
            LoadCellMember();
        }

        

        private void repositoryItemCheckEdit1_EditValueChanged(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.CheckEdit obj = sender as DevExpress.XtraEditors.CheckEdit;

            ShowEndate( obj.Checked);
            RefreshBinding();
            
        }

        private void printCellFamily_ItemClick(object sender, ItemClickEventArgs e)
        {
            PrintCellFamily();
        }

        private void PrintCellFamily()
        {
            if (_memberlist == null)
            {
                MessageBox.Show("Please Selecte a Cell");
                return;
            }
            var celllist = from list in _memberlist
                           group list by list.CellCode into a
                           select new { key = a.Key };

           var   codelist =  string.Join(", ", celllist.Select(i => i.key.ToString()).ToArray());  
       
            try
            {
                Shared.ReprotManager manager = new Shared.ReprotManager();
                manager.RunCellFamilyPrint(codelist.ToString());
            }
            catch (Exception ex)
            {
                Shared.Utility.ErrorLogging(Properties.Resources.ErrorMessage_General, ex.ToString(), "Error");
            }
        }

        private void treeList1_Click(object sender, EventArgs e)
        {
            TreeList tree = sender as TreeList;
            TreeListHitInfo hi = tree.CalcHitInfo(tree.PointToClient(Control.MousePosition));
            if (hi.Node != null)
            {
                _currentrole = 0;

                _currentcode = ((_entity.bizCell.Cell)treeList1.GetDataRecordByNode(hi.Node)).Code;
                StartThreadForLoad();
            }
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.gridView1.SelectedRowsCount == 0) return;

            string[] roles = gridView1.GetFocusedRowCellValue("Roles").ToString().Split('/');

            for (int i = 0; i < clbcRole.ItemCount; i++)
            {
                DataRowView row = clbcRole.GetItem(i) as DataRowView;
                clbcRole.SetItemChecked(i, false);
            }

            foreach (var r in roles)
            {
                for (int i = 0; i < (clbcRole.DataSource as IList).Count; i++)
                {
                    Dothan.NameValueListBase<int, string>.NameValuePair item = (Dothan.NameValueListBase<int, string>.NameValuePair)(clbcRole.DataSource as IList)[i];
                    if (item.Value == r)
                        clbcRole.SetItemChecked(i, true);
                }
            }

            this.popupControlContainer1.Show();

            this.popupControlContainer1.BringToFront();


        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.popupControlContainer1.Hide();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            this.popupControlContainer2.Hide();
        }

        private void btnApplyToChangeCell_Click(object sender, EventArgs e)
        {
            object[] list = Shared.UtiltyDevExpress.SelectedRows(this.gridView1);
            foreach (object info in list)
            {
                _entity.bizCell.CellMember member = (_entity.bizCell.CellMember)info;
                System.Security.Principal.IPrincipal user = Dothan.ApplicationContext.User;
                _entity.bizMember.Member.ToTransferCell(member.MemberId.ToString(), DateTime.Today.ToString(), (int)lookUpEdit2.EditValue, user.Identity.Name);
            }
            this.popupControlContainer2.Hide();
            StartThreadForLoad();
        }

        private void lookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

       

    }
}
