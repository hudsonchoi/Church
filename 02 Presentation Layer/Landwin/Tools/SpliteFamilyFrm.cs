using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using _entity = Dothan.Library;

namespace LandWin.Tools
{
    public partial class SpliteFamilyFrm : Form
    {
        private _entity.bizCommon.Address _address;
        private _entity.bizMember.Member _member;
        public SpliteFamilyFrm(_entity.bizMember.Member member)
        {
            InitializeComponent();
            _member = member;
            this.textEdit1.Text = _member.MemberID.ToString();
            this.textEdit2.Text = _member.KoName;
            _address = _entity.bizCommon.Address.New();
            _address.BeginEdit();
            _address.PropertyChanged += new PropertyChangedEventHandler(AddressPropertyChanged);
            this.addressBindingSource.DataSource = _address;
        }

        private void AddressPropertyChanged(object sender, PropertyChangedEventArgs e)
        {

            if (e.PropertyName == "Zipcode")
            {
                GetAddressByzipCode(_address.Zipcode);
            }

        }

        private void GetAddressByzipCode(string str)
        {
            if (string.IsNullOrEmpty(str)) return;

            using (ZipcodeFrm frm = new ZipcodeFrm(str))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    _address.City = frm.ZipcodeInfo.City;
                    _address.State = frm.ZipcodeInfo.State;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("세대주로 등록하실 원하십니까?", "Important Message", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                this.addressBindingSource.EndEdit();
                this.addressBindingSource.RaiseListChangedEvents = false;
                try
                {
                   _entity.bizCommon.Address temp = _address.Clone();
                    temp.ApplyEdit();
                    _address = temp.Save();
                    if (_address.ID != 0)
                    {
                        _entity.bizMember.Member.ToSpliteMember(_member.MemberID, _address.ID, Dothan.ApplicationContext.User.Identity.Name);
                        this.DialogResult = DialogResult.OK;
                        MessageBox.Show(LandWin.Properties.Resources.Success_Save);
                        this.Close();
                    }
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
            }
        }

        private void tb_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
    }
}
