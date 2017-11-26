using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using _entity = Dothan.Library;
using DonateWin.Properties;

namespace DonateWin
{
    public partial class dlgDonateMember : Form
    {
        private _entity.bizDonate.DonateMember _member;
        private _entity.bizCommon.Address _address;


        public _entity.bizDonate.DonateMember DonateMember
        {
            get { return _member; }
        }

        public dlgDonateMember(_entity.bizDonate.DonateMember member)
        {
            InitializeComponent();
            _member = member;

            btnClose.Click += new EventHandler(btnClose_Click);
            txtZipCode.Leave +=new EventHandler(txtZipCode_Leave);
            LoadingData();
        }

        private void LoadingData()
        {
            if (_member != null)
            {
                _member.BeginEdit();
                
                if (_member.IsNew)
                {
                    this.Text = "New Member";
                    _address = _entity.bizCommon.Address.New();
                }
                else
                {
                    _address = _entity.bizCommon.Address.Get(_member.AddressId);
                    this.Text = string.Format("{0} ( {1} {2} )", _member.Name, _member.EnFisrtName, _member.EnLastName);
                }
                _address.BeginEdit();
                this.addressBindingSource.DataSource = _address; 
               this.donateMemberBindingSource.DataSource = _member;
           }
            
        }
     

  

        private void txtZipCode_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtZipCode.Text))
            {

                dlg_zipcode dlg = new dlg_zipcode(txtZipCode.Text);
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    _address.Zipcode = txtZipCode.Text;
                    _address.City = dlg.ZipcodeInfo.City;
                    _address.State = dlg.ZipcodeInfo.State;
                }
                else
                {
                    txtZipCode.Text = "";
                }
                dlg.Dispose();
            }
            else
            {
                MessageBox.Show(Resources.Enter_your_zipcode.ToString());
            }
        }

        private void btnSave_Click(object sener, EventArgs e)
        {
            if (SaveAddress())
            {
                if(_member.IsNew)
                    _member.AddressId = _address.ID;
                
                
                SaveDonateMember();
            }
        }

        private bool SaveAddress()
        {
            bool result = false;
            this.addressBindingSource.RaiseListChangedEvents = false;
            this.addressBindingSource.EndEdit();
            _entity.bizCommon.Address temp = _address.Clone();
            temp.ApplyEdit();
            try
            {
                _address = temp.Save();
                result = true;
            }
            catch (Dothan.DataPortalException ex)
            {
                Util.ErrorLogging("Error Saving", ex.BusinessException.ToString(), "Error"); ;
            }
            catch (Exception ex)
            {
                Util.ErrorLogging("Error Saving", ex.ToString(), "Error");
            }
            finally
            {
                this.donateMemberBindingSource.RaiseListChangedEvents = true;
            }

            return result;
        }



        private void SaveDonateMember()
        {
           
                this.donateMemberBindingSource.RaiseListChangedEvents = false;
                this.donateMemberBindingSource.EndEdit();

                _entity.bizDonate.DonateMember temp = _member.Clone();
                temp.ApplyEdit();
                try
                {
                    _member = temp.Save();
                    MessageBox.Show("Successfully Saved.");
                    this.DialogResult = DialogResult.OK;
                    
                }
                catch (Dothan.DataPortalException ex)
                {
                    Util.ErrorLogging("Error Saving", ex.BusinessException.ToString(), "Error");
                }
                catch (Exception ex)
                {
                    Util.ErrorLogging("Error Saving", ex.ToString(), "Error");
                }
                finally
                {
                    this.donateMemberBindingSource.RaiseListChangedEvents = true;
                }
           
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            if (_member.IsDirty || _address.IsDirty)
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

        
    }
}
