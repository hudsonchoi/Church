using System;
using System.Drawing;
using System.Windows.Forms;
using _entity = Dothan.Library.bizCourse;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors;

namespace LandWin.Configuration
{
    public partial class CourseList : Form
    {

        private _entity.Courses _list;

        public CourseList ()
        {
            InitializeComponent();
           
            this.courseListBindingSource.DataSource =_entity.CourseList.GetList();
            this.gridView1.CustomDrawRowIndicator += new RowIndicatorCustomDrawEventHandler(CustomDrawRowIndicator);
            this.barEditItem1.EditValue = 1;
            BindingData(1);
        }

        private void BindingData(int active)
        {
            try
            {
                _list = _entity.Courses.GetList(active);
                this.coursesBindingSource.DataSource = _list;
                this.gridView1.RefreshData();
            }
            catch (Dothan.DataPortalException ex)
            {
                MessageBox.Show(ex.BusinessException.ToString(),
                 LandWin.Properties.Resources.Error_Save.ToString(),
                 MessageBoxButtons.OK,
                  MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), LandWin.Properties.Resources.Error_Save.ToString(),
                  MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            GridView view = (GridView)sender;

            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                int i = e.RowHandle + 1;
                e.Info.DisplayText = i.ToString();
                e.Info.ImageIndex = -1;

            }
            Font stringfont = e.Info.Appearance.Font;
            SizeF stringSize = new SizeF();
            stringSize = e.Graphics.MeasureString(view.RowCount.ToString(), stringfont);
            view.IndicatorWidth = (int)stringSize.Width + 10;
        }

        private void bt_Close_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_list.IsDirty)
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

        private void bt_Save_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.courseListBindingSource.EndEdit();
            this.coursesBindingSource.EndEdit();
            this.coursesBindingSource.RaiseListChangedEvents = false;
            this.courseListBindingSource.RaiseListChangedEvents = false;
            _entity.Courses temp = _list.Clone();
            temp.ApplyEdit();
            try
            {
                _list = temp.Save();
                this.DialogResult = DialogResult.OK;
            }
            catch (Dothan.DataPortalException ex)
            {
                MessageBox.Show(ex.BusinessException.ToString(),
                 LandWin.Properties.Resources.Error_Save.ToString(),
                 MessageBoxButtons.OK,
                  MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), LandWin.Properties.Resources.Error_Save.ToString(),
                  MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                this.coursesBindingSource.RaiseListChangedEvents = false;
                this.courseListBindingSource.RaiseListChangedEvents = false;
            }
        }

        private void bt_AddCell_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.gridView1.AddNewRow();
        }

        private void bt_Remove_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.gridView1 == null || this.gridView1.SelectedRowsCount == 0) return;

             DialogResult result = MessageBox.Show("Please Select a cell", "Important Message", MessageBoxButtons.YesNo);
             if (result == DialogResult.No)
                 return;
            
            int[] rows = new int[this.gridView1.SelectedRowsCount];
            for (int i = 0; i < this.gridView1.SelectedRowsCount; i++)
                rows[i] = ((_entity.Course)this.gridView1.GetRow(this.gridView1.GetSelectedRows()[i])).Code;

            this.gridView1.BeginSort();
            try
            {
                foreach (int row in rows)
                    _list.Remove(row);
            }
            finally
            {
                this.gridView1.EndSort();

            }
        }

        private void repositoryItemRadioGroup1_EditValueChanged(object sender, EventArgs e)
        {
            if (_list.IsDirty)
            {
                DialogResult result = MessageBox.Show("Do you want to load  the data without saving data?", "Important Message", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                    return;
            }

            BindingData((int)((RadioGroup)sender).EditValue);
            
        }
    }
}
