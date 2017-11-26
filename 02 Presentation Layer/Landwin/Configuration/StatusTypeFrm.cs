using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using _entity = Dothan.Library.bizAdmin;

namespace LandWin.Configuration
{
    public partial class StatusTypeFrm : DevExpress.XtraEditors.XtraForm
    {
        private _entity.StatusTypes _list;

        public StatusTypeFrm()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                _list = _entity.StatusTypes.Get();
                _list.BeginEdit();
                this.statusTypesBindingSource.DataSource = _list;
                this.gridView1.RefreshData();

            }
            catch (Dothan.DataPortalException ex)
            {
                if (ex.BusinessException is SqlException)
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
            this.statusTypesBindingSource.RaiseListChangedEvents = false;

            if (!_list.IsValid)
            {
                MessageBox.Show(Properties.Resources.ErrorMessage_Invalid);
                return;
            }

            _entity.StatusTypes temp = _list.Clone();
            temp.ApplyEdit();
            try
            {

                _list = temp.Save();
                MessageBox.Show(Properties.Resources.Success_Save);
                LoadData();
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
            finally
            {
                this.statusTypesBindingSource.RaiseListChangedEvents = true;
            }
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!_entity.StatusTypes.CanEditObject())
            {
                MessageBox.Show(Properties.Resources.ErrorMassage_UnAuthorized);
                return;
            }

            this.gridView1.CloseEditor();
            this.statusTypesBindingSource.EndEdit();
            if (!_list.IsValid)
            {
                MessageBox.Show(Properties.Resources.ErrorMessage_Invalid);
                return;
            }
           
            SaveData();
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_list.IsDirty && _entity.StatusTypes.CanEditObject())
            {
                if (Shared.Utility.ToConfirmUnSavedData())
                    this.Close();
            }
            else
            {
                this.Close();
            }
        }

        private void btnRemove_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.gridView1 == null || this.gridView1.SelectedRowsCount == 0) return;

            if (_entity.StatusTypes.CanDeleteObject())
            {
                Remove(Shared.UtiltyDevExpress.SelectedRows(this.gridView1));
                this.gridView1.RefreshData();
            }
            else
            {
                MessageBox.Show(Properties.Resources.ErrorMessage_Invalid);
            }
        }
        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_entity.EntryTypes.CanAddObject())
            {
                _list.AddNew();
                this.statusTypesBindingSource.ResetBindings(false);
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
                _list.Remove(obj as _entity.StatusType);
            }
        }

        private void repositoryItemCheckEdit1_CheckedChanged(object sender, EventArgs e)
        {
            gridView1.PostEditor();
        }
    }
}