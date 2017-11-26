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
    public partial class SubDivisionFrm : Form
    {
        private _entity.bizAdmin.SubDivisions _list;

        public SubDivisionFrm()
        {
            InitializeComponent();
            this.Text = Properties.Resources.Subdivision;
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                this.subdivisionListBindingSource.DataSource = _entity.bizCommon.SubdivisionList.Get(false);
    
                _list = _entity.bizAdmin.SubDivisions.Get();
                _list.BeginEdit();
                this.subDivisionsBindingSource.DataSource = _list;
                this.gridView1.RefreshData();
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
       
            this.subDivisionsBindingSource.RaiseListChangedEvents = false;

            _entity.bizAdmin.SubDivisions temp = _list.Clone();
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
                this.subDivisionsBindingSource.RaiseListChangedEvents = true;
            }
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (!_entity.bizAdmin.SubDivisions.CanEditObject())
            {
                MessageBox.Show(Properties.Resources.ErrorMassage_UnAuthorized);
                return;
            }

            this.gridView1.CloseEditor();
            this.subDivisionsBindingSource.EndEdit();
            if (!_list.IsValid)
            {
                MessageBox.Show(Properties.Resources.ErrorMessage_Invalid);
                return;
            }

            SaveData();
        }


        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_list.IsDirty && _entity.bizAdmin.SubDivisions.CanEditObject())
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
                this.subDivisionsBindingSource.ResetBindings(false); 
            }
            else
            {
                MessageBox.Show(Properties.Resources.ErrorMessage_Invalid);
            }
        }

        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_entity.bizAdmin.SubDivisions.CanAddObject())
            {
                _list.AddNew();
                this.subDivisionsBindingSource.ResetBindings(false);
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
                _list.Remove(obj as _entity.bizAdmin.SubDivision);
            }
        }


    }
}
