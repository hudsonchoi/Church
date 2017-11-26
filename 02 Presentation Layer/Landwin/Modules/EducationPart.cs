using System;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using _entity = Dothan.Library;
using LandWin.Properties;
using DevExpress.XtraTreeList;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors;
using System.Collections;
using LandWin.Tools;
using System.Threading;
using System.Data.SqlClient;

namespace LandWin.Modules
{
    public partial class EducationPart : WinPart
    {

        private int _code;
        private string _coursename = string.Empty;
        private _entity.bizCourse.CourseList _course; 
        private _entity.bizCourse.CourseMembers _memberlist;

        public const string LayoutName = "EducationGridView"; 
        public override GridView ReportView { get { return gridView1; } }

        private delegate void DataLoadDelegate();

        public EducationPart()
        {
            InitializeComponent();
            Shared.UtiltyDevExpress.InitGridView(this.gridView1, LayoutName);
            gridView1.DoubleClick += new System.EventHandler(GridViewRow_DoubleClick);
            gridView1.RowStyle += new RowStyleEventHandler(GridView_RowStyle);

            gridView1.ShowGridMenu += new DevExpress.XtraGrid.Views.Grid.GridMenuEventHandler(m_ShowGridMenu);
            this.dockPanel2.Hide();
            LoadDefaultData();
            LoadCourseData();
            Reset();
        }

        private void LoadDefaultData()
        {
            this.fellowshipsListBindingSource.DataSource = _entity.bizFellowship.FellowshipsList.Get(true);
            this.cellRoleListBindingSource.DataSource = _entity.bizCell.CellRoleList.Get(true); 
           
        }

        protected void LoadCourseData()
        {
            try
            {
                _course = _entity.bizCourse.CourseList.GetList();

                this.courseListBindingSource.DataSource = _entity.bizCourse.CourseList.GetList();
                
                this.treeList1.ExpandAll();
            }
            catch (Dothan.DataPortalException ex)
            {
                if (ex.BusinessException is SqlException)
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


        protected void Reset()
        {
            this.bt_FellowshipLookUp.EditValue = 0;
            this.bt_CellRoleLookUp.EditValue = 0;
            this.rDateFrom.EditValue = "";
            this.rDateTo.EditValue = "";
            this.checkedListBoxControl1.UnCheckAll();
            
        }

        #region WinPart Code
        protected internal override object GetIdValue()
        {
            return Resources.Education_Manage;
        }

 
        #endregion

        #region Add Member

        public override void ImportMemberList(Dothan.Library.bizMember.MemberList info)
        {
            if (_memberlist == null)
                _memberlist = _entity.bizCourse.CourseMembers.NewList();

            foreach (_entity.bizMember.MemberInfo item in info)
            {
                AssignMember(item);
            }

            RefreshBinding();
        }
        
        private void repositoryItemTextEdit1_KeyDown(object sender, KeyEventArgs e)
        {
            if (_memberlist == null) return;

            TextEdit item = (TextEdit)sender;
            if (e.KeyCode == Keys.Enter)
            {
                int id = 0;
                if (int.TryParse(item.Text, out id))
                {
                    _entity.bizMember.MemberList list = _entity.bizMember.MemberList.Get(id);
                    if(list.Count > 0)
                        AssignMember(list[0]);
                }
                else
                    MessageBox.Show("Invalid MemberID", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                item.Text = "";
            }
        }
        private void btnAddMember_ItemClick(object sender, ItemClickEventArgs e)
        {
            if(_memberlist == null) return;

            using (LandWin.Tools.MemberSearchFrm frm = new LandWin.Tools.MemberSearchFrm(this))
            {
                frm.ShowDialog();
            }
        }

     
        private void AssignMember(Dothan.Library.bizMember.MemberInfo info)
        {
            if (_memberlist.Contains(info.MemberId))
            {
                MessageBox.Show(Resources.Err_Duplicated);
                return;
            }

            _memberlist.Assign(info, DateTime.Today.ToString(), _code);

            
            RefreshBinding();
        }
        #endregion

        private void btnChangeGraduate_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.gridView1 == null || this.gridView1.SelectedRowsCount == 0)
            {
                MessageBox.Show(Properties.Resources.No_SelectedRow);
                return;
            }
            CalendarFrm dlg = new CalendarFrm();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                ToChangedEndDate(Shared.UtiltyDevExpress.SelectedRows(this.gridView1),dlg.SelectedDate.ToString());
            }
        }


        private void ToChangedEndDate(object[] list,string enddate)
        {
            foreach (object item in list)
            {
                ((_entity.bizCourse.CourseMember)item).Graduate = enddate;
            }
            this.gridView1.RefreshData();
        }



        private void btnChangeCourseID_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!_entity.bizCourse.CourseMembers.CanEditObject())
            {
                MessageBox.Show(Resources.ErrorMassage_UnAuthorized);
                return;

            }

            if (this.gridView1 == null || this.gridView1.SelectedRowsCount == 0)
            {
                MessageBox.Show(Properties.Resources.No_SelectedRow);
                return;
            }

            if( (int)ddlCourse.EditValue == 0)
            {
                MessageBox.Show(Resources.ErrorMessage_Invalid);
                return;
            }

            ToChangeCourse(Shared.UtiltyDevExpress.SelectedRows(this.gridView1), (int)ddlCourse.EditValue);
        }

        private void ToChangeCourse(object[] list ,int courseid)
        {
            foreach (object item in list)
            {
                ((_entity.bizCourse.CourseMember)item).CourseId = courseid;
            }
            this.gridView1.RefreshData();

        }

        private void SaveList_ItemClick(object sender, ItemClickEventArgs e)
        {

            this.courseMembersBindingSource.EndEdit();
            if (!_entity.bizCourse.CourseMembers.CanEditObject())
            {
                MessageBox.Show(Properties.Resources.ErrorMessage_UnAuthorized);
                return;
            }

            
            if (_memberlist == null && !_memberlist.IsDirty)
                return;


            DialogResult result = XtraMessageBox.Show("Do you want to save thie list?", "Important Message", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
                return;

            SaveMemberData();
           
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

                this.courseMembersBindingSource.DataSource = _memberlist;

                this.gridView1.RefreshData();
                this.gridView1.BestFitColumns();

            });
        }


        private void SaveMemberData()
        {
            this.courseListBindingSource.EndEdit();
            this.courseMembersBindingSource.RaiseListChangedEvents = false;
          
            _entity.bizCourse.CourseMembers temp = _memberlist.Clone();
            temp.ApplyEdit();

            try
            {
                
                _memberlist = temp.Save();
                MessageBox.Show(Properties.Resources.Success_Save);
        
            }
            catch (Dothan.DataPortalException ex)
            {
                if (ex.BusinessException is SqlException)
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
                Shared.Utility.ErrorLogging("Failed to Save", ex.ToString(), "Error");

            }
            finally
            {
                this.courseMembersBindingSource.RaiseListChangedEvents = true;
            }
        }


        private void LoadCourseMember()
        {

            if (_memberlist != null && _memberlist.IsDirty)
            {
                DialogResult result = MessageBox.Show("Do you want to close without saving data?", "Important Message", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                    return;
            }
            try
            {
                _memberlist = _entity.bizCourse.CourseMembers.GetList(_code);
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


        private void StartThreadForLoad()
        {
            Thread t = new Thread(new ThreadStart(new DataLoadDelegate(LoadCourseMember)));
            t.Start();
            t.Join();
        }
 

        private void btnCourseSetup_ItemClick(object sender, ItemClickEventArgs e)
        {
            CourseListFrm frm = new CourseListFrm();
            frm.ShowDialog();
            frm.Dispose();
            LoadCourseData();
        }

        private void bt_AdvancedSearch_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.dockPanel2.Visibility == DevExpress.XtraBars.Docking.DockVisibility.Visible)
                this.dockPanel2.Hide();
            else
                this.dockPanel2.Show();
            
        }

        private void bt_find_Click(object sender, EventArgs e)
        {
                string fromDate = rDateFrom.Text;
                string toDate = rDateTo.Text;
                int fellowship = (int)bt_FellowshipLookUp.EditValue;
                int cellrole = (int)bt_CellRoleLookUp.EditValue;
                string courselist = GetCheckedCourse();
         
                Thread t = new Thread(()=> LoadData(courselist.TrimEnd(','),fellowship,cellrole,fromDate,toDate));
                t.Start();

 
        }

        private void LoadData(string codelist , int fellowship , int cellrole , string from , string to)
        {

            try
            {
                _memberlist = _entity.bizCourse.CourseMembers.GetList(codelist, fellowship, cellrole, from, to);
                RefreshBinding();

            }
            catch (Dothan.DataPortalException ex)
            {
                if (ex.BusinessException is SqlException)
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



        private string GetCheckedCourse()
        {
            StringBuilder str = new StringBuilder();
            foreach (object item in this.checkedListBoxControl1.CheckedItems)
            {
                str.Append(((Dothan.NameValueListBase<int, string>.NameValuePair)item).Key.ToString()).Append(",");

            }
            return str.ToString().Trim(',');
        }

        private void EditDateTime(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.TextEdit edit = (DevExpress.XtraEditors.TextEdit)sender;
            Point pt1 = edit.PointToClient(this.Location);
            CalendarFrm dlg = new CalendarFrm(edit.Text, -pt1.X, -pt1.Y + edit.Height);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                edit.Text = dlg.SelectedDate.ToString("MM/dd/yyyy");
            }
            else
                edit.Text = "";
        }


        private void pictureEdit1_Click(object sender, EventArgs e)
        {
           Shared.UtiltyDevExpress.Calendar(this.rDateFrom);
        }

        private void pictureEdit2_Click(object sender, EventArgs e)
        {
           Shared.UtiltyDevExpress.Calendar(rDateTo);
        }

        private void bt_reset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void bt_RemoveMember_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.gridView1 == null || this.gridView1.SelectedRowsCount == 0) return;

            _entity.bizCourse.CourseMember[] rows = new _entity.bizCourse.CourseMember[this.gridView1.SelectedRowsCount];
            for (int i = 0; i < this.gridView1.SelectedRowsCount; i++)
                rows[i] = this.gridView1.GetRow(this.gridView1.GetSelectedRows()[i]) as _entity.bizCourse.CourseMember;

            this.gridView1.BeginSort();
            try
            {
                foreach (_entity.bizCourse.CourseMember row in rows)
                    _memberlist.Remove(row.ID);
            }
            finally
            {

                this.gridView1.EndSort();
                this.courseMembersBindingSource.DataSource = _memberlist;
                this.gridView1.RefreshData();

            }
        }


        private void bt_ClearList_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (_memberlist != null && _memberlist.IsDirty)
            {
                DialogResult result = MessageBox.Show("Do you want to load a data without saving data?", "Important Message", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                    return;
            }

            _memberlist = _entity.bizCourse.CourseMembers.NewList();
            this.courseMembersBindingSource.DataSource = _memberlist;
        }

        private void treeList1_Click(object sender, EventArgs e)
        {
            TreeList tree = sender as TreeList;
            TreeListHitInfo hi = tree.CalcHitInfo(tree.PointToClient(Control.MousePosition));
            if (hi.Node != null)
            {
                this.Cursor = Cursors.WaitCursor;
                _code = ((_entity.bizCourse.CourseInfo)treeList1.GetDataRecordByNode(hi.Node)).Key;
                StartThreadForLoad();
                this.Cursor = Cursors.Default;
            }
        }


 

 
    }
}
