using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using _entity = Dothan.Library;

namespace LandWin.Configuration 
{
    public partial class DonateTypeFrm : Form
    {
        private _entity.bizDonate.DonateTypes _list;

        public DonateTypeFrm()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                _list = _entity.bizDonate.DonateTypes.GetList();
                _list.BeginEdit();
                this.donateTypesBindingSource.DataSource = _list;
                this.donateTypeListBindingSource.DataSource = from data in _list
                                                              select new { Key = data.Code, Value = data.Name };
                this.gridView1.RefreshData(); ;
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
            this.donateTypesBindingSource.RaiseListChangedEvents = false;

            _entity.bizDonate.DonateTypes temp = _list.Clone();
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
                this.donateTypesBindingSource.RaiseListChangedEvents = true;
            }
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (!_entity.bizDonate.DonateTypes.CanEditObject())
            {
                MessageBox.Show(Properties.Resources.ErrorMassage_UnAuthorized);
                return;
            }

            this.gridView1.CloseEditor();
            this.donateTypesBindingSource.EndEdit();
            if (!_list.IsValid)
            {
                MessageBox.Show(Properties.Resources.ErrorMessage_Invalid);
                return;
            }

            SaveData();
        }


        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_list.IsDirty && _entity.bizDonate.DonateTypes.CanEditObject())
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

            if (_entity.bizAdmin.SubDivisions.CanDeleteObject())
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
            if (_entity.bizDonate.DonateTypes.CanAddObject())
            {
                _list.AddNew();
                this.donateTypesBindingSource.ResetBindings(false);
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
                _list.Remove(obj as _entity.bizDonate.DonateType);
            }
        }


    }
}
