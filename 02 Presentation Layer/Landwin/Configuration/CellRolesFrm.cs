using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using _entity = Dothan.Library.bizCell;
using LandWin.Properties;
using System.Data.SqlClient;
using DevExpress.XtraGrid.Views.Grid;

namespace LandWin.Configuration
{
    public partial class CellRolesFrm : Form
    {
        private _entity.CellRoles _list;
        public CellRolesFrm()
        {
            InitializeComponent();
            LoadData();
        }


        private void LoadData()
        {
            try
            {
                _list = _entity.CellRoles.GetList();
                this.cellRolesBindingSource.DataSource = _list;
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
           
            this.cellRolesBindingSource.RaiseListChangedEvents = false;


            _entity.CellRoles temp = _list.Clone();
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
                this.cellRolesBindingSource.RaiseListChangedEvents = true;
            }
        }


        private void btnSave_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (!_entity.CellRoles.CanEditObject())
            {
                MessageBox.Show(Properties.Resources.ErrorMassage_UnAuthorized);
                return;
            }
            
            this.cellRolesBindingSource.EndEdit();
            if (!_list.IsValid)
            {
                MessageBox.Show(Properties.Resources.ErrorMessage_Invalid);
                return;
            }

            gridView1.CloseEditor();
            gridView1.UpdateCurrentRow();
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



        private void btnAddRole_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (!_entity.CellRoles.CanAddObject())
            {
                MessageBox.Show(Properties.Resources.ErrorMassage_UnAuthorized);
                return;
            }

            _list.AddNew();
        }

        private void btnRemove_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.gridView1 == null || this.gridView1.SelectedRowsCount == 0) return;

            if (_entity.CellRoles.CanDeleteObject())
            {
                Remove(Shared.UtiltyDevExpress.SelectedRows(this.gridView1));
                this.gridView1.RefreshData();
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
                _list.Remove(obj as _entity.CellRole);
            }
        }
    
        #region GridView Handling 

        private void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {
                bool defaultLevel = (bool)View.GetRowCellValue(e.RowHandle, View.Columns["Default"]);
                if (defaultLevel)
                {
                    e.Appearance.BackColor = Color.Salmon;
                    e.Appearance.BackColor2 = Color.SeaShell;
                }
            }
        }
     
        private void repositoryItemCheckEdit1_EditValueChanged(object sender, EventArgs e)
        {
            gridView1.PostEditor();
        }




        #endregion 






    }
}
