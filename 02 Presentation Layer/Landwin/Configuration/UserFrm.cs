using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using _entity = Dothan.Library.bizAdmin;

namespace LandWin.Configuration
{
    public partial class UserFrm : DevExpress.XtraEditors.XtraForm
    {
        private _entity.User _user;
        public UserFrm( _entity.User user)
        {
            InitializeComponent();
            _user = user;
            _user.BeginEdit();
            this.userBindingSource.DataSource = _user;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void SaveData()
        {
            this.userBindingSource.EndEdit();
          
            this.userBindingSource.RaiseListChangedEvents = false;

            _entity.User temp = _user.Clone();
            temp.ApplyEdit();
            try
            {

                _user = temp.Save();
                MessageBox.Show(Properties.Resources.Success_Save);
                this.userBindingSource.ResetBindings(false);
               
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
                this.userBindingSource.RaiseListChangedEvents = true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (_user.IsDirty)
            {
                if (Shared.Utility.ToConfirmUnSavedData())
                    this.Close();
            }
            else
            {
                this.Close();
            }
        }
    }
}