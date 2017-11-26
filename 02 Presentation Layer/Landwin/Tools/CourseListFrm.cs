using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using _entity = Dothan.Library.bizCourse;
using LandWin.Properties;

namespace LandWin.Tools
{
    public partial class CourseListFrm : Form
    {
        private _entity.Courses _list;
        private int _active = 1;
        public CourseListFrm()
        {
            InitializeComponent();
            barEditItem1.EditValue = _active;
            LoadData();
        }

        private void LoadData()
        {
           try
            {
                _list = _entity.Courses.Get();
                RefreshBinding();
                this.courseListBindingSource.DataSource = from list in _list
                                                          where list.Active == true 
                                                          select new { Key = list.Code, Value = list.Name };
            }
            catch (Dothan.DataPortalException ex)
            {
                if (ex.BusinessException is System.Data.SqlClient.SqlException)
                {
                    Shared.Utility.ErrorLogging(Properties.Resources.ErrorMessage_SqlException, ex.BusinessException.ToString(), "Error");
                    this.Close();
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
        private void SaveData()
        {

            this.coursesBindingSource.RaiseListChangedEvents = false;


            _entity.Courses temp = _list.Clone();
            temp.ApplyEdit();
            try
            {
                _list = temp.Save();
                MessageBox.Show(Properties.Resources.Success_Save);
                LoadData();
            }
            catch (Dothan.DataPortalException ex)
            {
                if (ex.BusinessException is System.Data.SqlClient.SqlException)
                {
                    Shared.Utility.ErrorLogging(Properties.Resources.ErrorMessage_SqlException, ex.BusinessException.ToString(), "Error");
                    this.Close();
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
            finally
            {
                this.coursesBindingSource.RaiseListChangedEvents = true;
            }
        }

        private void btnSave_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (!_entity.Courses.CanEditObject())
            {
                MessageBox.Show(Properties.Resources.ErrorMassage_UnAuthorized);
                return;
            }
            this.gridView1.PostEditor();
            this.coursesBindingSource.EndEdit();
            if (!_list.IsValid)
            {
                MessageBox.Show(Properties.Resources.ErrorMessage_Invalid);
                return;
            }


            SaveData();


        }
        private void btnClose_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_list.IsDirty)
            {
                if (Shared.Utility.ToConfirmUnSavedData())
                    this.Close();
            }
            else
            {
                this.Close();
            }
        }



        private void btnAddFellowship_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (!_entity.Courses.CanEditObject())
            {
                MessageBox.Show(Properties.Resources.ErrorMassage_UnAuthorized);
                return;
            }
            try
            {
                _list.AddNew();
                RefreshBinding();
            }
            catch (Exception ex)
            {
                Shared.Utility.ErrorLogging(Properties.Resources.ErrorMessage_General, ex.ToString(), "Error");
                this.Close();

            }
        }
        private void RefreshBinding()
        {
            var query = from list in _list
                        orderby list.ParentCode ascending
                        select list;

            if (_active == -1)
            {
                this.coursesBindingSource.DataSource = query.OrderBy(list => list.ParentCode) ;
            }
            else
            {
                bool condition = _active == 0 ? false : true;

                this.coursesBindingSource.DataSource = query.Where(list => list.Active == condition).OrderBy(list => list.Sort);
            }
            this.gridView1.Columns["ParentCode"].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
            this.gridView1.RefreshData();
        }
        private void btnRemove_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.gridView1 == null || this.gridView1.SelectedRowsCount == 0) return;

            if (_entity.Courses.CanDeleteObject())
            {
                Remove(Shared.UtiltyDevExpress.SelectedRows(this.gridView1));

                RefreshBinding();
            }
            else
            {
                MessageBox.Show(Properties.Resources.ErrorMessage_Invalid);
            }

        }

        private void Remove(object[] row)
        {
            foreach (object obj in row)
            {
                _list.Remove((obj as _entity.Course).Code);
            }
        }

        private void repositoryItemRadioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
               DevExpress.XtraEditors.RadioGroup edit = sender as DevExpress.XtraEditors.RadioGroup;
               _active = (int)repositoryItemRadioGroup1.Items[edit.SelectedIndex].Value;

               RefreshBinding();
            
        }

    
    }
}
