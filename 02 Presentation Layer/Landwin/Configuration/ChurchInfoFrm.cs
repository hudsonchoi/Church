using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using _entity = Dothan.Library.bizAdmin;

namespace LandWin.Configuration
{
    public partial class ChurchInfoFrm : Form
    {
        private _entity.ChurchInfo _info;
        public ChurchInfoFrm()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                _info = _entity.ChurchInfo.Get();
                _info.BeginEdit();
                this.churchInfoBindingSource.DataSource = _info;
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
            this.churchInfoBindingSource.RaiseListChangedEvents = false;

            if (!_info.IsValid)
            {
                MessageBox.Show(Properties.Resources.ErrorMessage_Invalid);
                return;
            }

            _entity.ChurchInfo temp = _info.Clone();
            temp.ApplyEdit();
            try
            {

                _info = temp.Save();
                MessageBox.Show(Properties.Resources.Success_Save);
                this.churchInfoBindingSource.ResetBindings(false);
         
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
                this.churchInfoBindingSource.RaiseListChangedEvents = true;
            }
        }



        private void btnClose_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_info.IsDirty && _entity.JobTypes.CanEditObject())
            {
                if (Shared.Utility.ToConfirmUnSavedData())
                    this.Close();
            }
            else
            {
                this.Close();
            }
        }

        private void btnSave_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.churchInfoBindingSource.EndEdit();
            if (!_info.IsValid)
            {
                MessageBox.Show(Properties.Resources.ErrorMessage_Invalid);
                return;
            }
            if (!_entity.JobTypes.CanEditObject())
            {
                MessageBox.Show(Properties.Resources.ErrorMassage_UnAuthorized);
            }
            SaveData();
        }

        private void btnUploadSign_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

      
    }
}
