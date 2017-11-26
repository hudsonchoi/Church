using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using _entity = Dothan.Library.bizMinistry;
using LandWin.Properties;

namespace LandWin.Tools
{
    public partial class MinistryListFrm : Form
    {
        private _entity.Ministrys _list;

        public MinistryListFrm()
        {
            InitializeComponent();
            this.ministryListBindingSource.DataSource = _entity.MinistryList.Get(false);
            LoadData();
        }

        private void LoadData()
        {
           try
            {
                _list = _entity.Ministrys.Get();
                RefreshBinding();
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

        private void RefreshBinding()
        {
            this.ministrysBindingSource.DataSource = from list in _list
                                                     where list.Status != "D"
                                                     orderby  list.ParentCode ascending , list.Name ascending
                                                     select list;
            this.gridView1.RefreshData();
        }
        private void SaveData()
        {

            this.ministrysBindingSource.RaiseListChangedEvents = false;


            _entity.Ministrys temp = _list.Clone();
            temp.ApplyEdit();
            try
            {
                _list = temp.Save();
                MessageBox.Show(Properties.Resources.Success_Save);
                this.ministrysBindingSource.DataSource = _list;
                this.ministrysBindingSource.ResetBindings(true);
                this.DialogResult = DialogResult.OK;
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
                this.ministrysBindingSource.RaiseListChangedEvents = true;
            }
        }

        private void btnSave_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (!_entity.Ministrys.CanEditObject())
            {
                MessageBox.Show(Properties.Resources.ErrorMassage_UnAuthorized);
                return;
            }
            this.gridView1.PostEditor();
            this.ministrysBindingSource.EndEdit();
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

            if (!_entity.Ministrys.CanEditObject())
            {
                MessageBox.Show(Properties.Resources.ErrorMassage_UnAuthorized);
                return;
            }

            _list.AddNew();
            RefreshBinding();
        }

        private void btnRemove_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.gridView1 == null || this.gridView1.SelectedRowsCount == 0) return;

            if (_entity.Ministrys.CanDeleteObject())
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
                _list.Remove(obj as _entity.Ministry);
            }
        }
    }
}
