using System;
using System.Windows.Forms;
using System.Linq;
using _entity =Dothan.Library;
using LandWin.Properties;
using DevExpress.XtraTreeList;
using System.Text;
using System.Collections;
using System.Threading;
using System.Drawing;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;

namespace LandWin.Modules
{
    public partial class FellowshipPart : WinPart
    {
        private _entity.bizFellowship.FellowshipsList _fellowships;
        private _entity.bizFellowship.FellowshipMembers _memberlist;
        private int _selectedFellowship;
        private const string _layoutName = "FellowshipGridview";
        private delegate void DataLoadDelegate();
        
        public override GridView ReportView { get { return gridView1; } }

        public FellowshipPart()
        {
            InitializeComponent();
            Shared.UtiltyDevExpress.InitGridView(this.gridView1, "FellowshipGridview");
            this.txtStartDate.EditValue = DateTime.Today;
            gridView1.DoubleClick +=new EventHandler(this.GridViewRow_DoubleClick);
            gridView1.RowStyle += new RowStyleEventHandler(GridView_RowStyle);
            LoadFellowship();
            gridView1.ShowGridMenu += new DevExpress.XtraGrid.Views.Grid.GridMenuEventHandler(m_ShowGridMenu);
        }

        #region WinPart Code

        protected internal override object GetIdValue()
        {
            return Resources.Fellowship_Manage;
        }

        
        #endregion

      

        private void treeList1_Click(object sender, EventArgs e)
        {
            TreeList tree = sender as TreeList;
            TreeListHitInfo hi = tree.CalcHitInfo(tree.PointToClient(Control.MousePosition));
            if (hi.Node != null)
            {

                _selectedFellowship = ((_entity.bizFellowship.FellowshipInfo)treeList1.GetDataRecordByNode(hi.Node)).Key;
                StartThreadForLoad();
            }
        }


        private void StartThreadForLoad()
        {
            this.Cursor = Cursors.WaitCursor;
            Thread t = new Thread(new ThreadStart(new DataLoadDelegate(LoadFellowshipMember)));
            t.Start();
            t.Join();
            this.Cursor = Cursors.Default;
       
        }
 


        public void LoadFellowship()
        {
            try
            {
                _fellowships = _entity.bizFellowship.FellowshipsList.Get(false);
                BindingFellowship();
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

        public void BindingFellowship()
        {
            this.fellowshipsListBindingSource.DataSource = from fellow in _fellowships
                                                           orderby fellow.Sort ascending
                                                            select fellow;
            treeList1.ExpandAll();
            treeList1.Refresh();

            this.fellowshipsListBindingSource.DataSource = _entity.bizFellowship.FellowshipsList.Get(true);
        }


        private void LoadFellowshipMember()
        {

            if (_memberlist != null && _memberlist.IsDirty)
            {
                DialogResult result = MessageBox.Show("Do you want to re-load without saving data?", "Important Message", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                    return;
            }

            try
            {
                 _memberlist = _entity.bizFellowship.FellowshipMembers.Get(_selectedFellowship);
                 _memberlist.BeginEdit();
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
     
    
    
        private void btnEditFellowship_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!_entity.bizFellowship.Fellowships.CanEditObject())
            {
                MessageBox.Show(Resources.ErrorMassage_UnAuthorized);
                return;
            }

            Tools.FellowshipListFrm frm = new LandWin.Tools.FellowshipListFrm();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadFellowship();
            }
        }



        #region Add Edit  Revmoe  Data

        public override void ImportMemberList(_entity.bizMember.MemberList list)
        {
            foreach (_entity.bizMember.MemberInfo item in list)
                AssignMember(item);



            RefreshBinding();
        }

        private void AssignMember(_entity.bizMember.MemberInfo info)
        {
            if (_memberlist.Contains(info.MemberId))
            {
                MessageBox.Show(Resources.Err_Duplicated);
                return;
            }


            _memberlist.Assign(info, _selectedFellowship, txtStartDate.EditValue.ToString());
            RefreshBinding();
        }

       

        private void SaveList()
        {
            this.gridView1.PostEditor();
            this.fellowshipMembersBindingSource.EndEdit();
            this.fellowshipMembersBindingSource.RaiseListChangedEvents = false;
            
            this.Enabled = false;
            _entity.bizFellowship.FellowshipMembers temp = _memberlist.Clone();
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
                this.fellowshipMembersBindingSource.RaiseListChangedEvents = true;
            }
        }

        private void Remove(object[] row)
        {
            foreach (object obj in row)
            {
                if ((obj as _entity.bizFellowship.FellowshipMember).IsNew)
                {
                    _memberlist.Remove(obj as _entity.bizFellowship.FellowshipMember);
                }
                else
                {
                    (obj as _entity.bizFellowship.FellowshipMember).Enddate = DateTime.Today.ToString();

                }
            }
            RefreshBinding();
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
            };
            this.Invoke((MethodInvoker)delegate
            {
                this.fellowshipMembersBindingSource.DataSource = from list in _memberlist
                                                                 where list.Enddate == string.Empty
                                                                 select list;

                this.gridView1.RefreshData();
                this.gridView1.BestFitColumns();

            });
        }


        #endregion

        private void btnRemoveMember_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.gridView1 == null || this.gridView1.SelectedRowsCount == 0) return;

            if (_entity.bizFellowship.FellowshipMembers.CanDeleteObject())
            {
                Remove(Shared.UtiltyDevExpress.SelectedRows(this.gridView1));
                RefreshBinding();
            }
            else
            {
                MessageBox.Show(Properties.Resources.ErrorMessage_Invalid);
            }
           
        }

        private void btnSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!_entity.bizFellowship.FellowshipMembers.CanEditObject())
            {
                MessageBox.Show(Resources.ErrorMassage_UnAuthorized);
                return;
            }
            SaveList();
        }

        private void btnChangeStartDate_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!_entity.bizFellowship.FellowshipMembers.CanEditObject())
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
                    (info as _entity.bizFellowship.FellowshipMember).Startdate = dlg.SelectedDate.ToString();
                }
            }
            this.gridView1.ClearSelection();
        }


        
        private void repositoryItemTextEdit1_KeyDown(object sender, KeyEventArgs e)
        {
           
             if(!_entity.bizFellowship.FellowshipMembers.CanEditObject())
             {
                 MessageBox.Show(Resources.ErrorMassage_UnAuthorized);
                 return;
             }

             if (_memberlist == null) return;

             DevExpress.XtraEditors.TextEdit item = (DevExpress.XtraEditors.TextEdit)sender;
             if (e.KeyCode == Keys.Enter)
             {
                 int id = 0;
                 if (int.TryParse(item.Text, out id))
                 {
                     _entity.bizMember.MemberList list = _entity.bizMember.MemberList.Get(id);

                     foreach (_entity.bizMember.MemberInfo info in list)
                         AssignMember(info);
                         
                 }
                 else
                     MessageBox.Show("Invalid MemberID", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                 item.Text = null;
             }
        }

        private void btnMemberSearch_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (_memberlist == null) return;

            Tools.MemberSearchFrm frm = new LandWin.Tools.MemberSearchFrm(this);
            frm.ShowDialog();
            frm.Dispose();
        }


 
    }
}
