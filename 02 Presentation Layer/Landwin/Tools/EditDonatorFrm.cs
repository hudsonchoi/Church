using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Dothan.Library;
using LandWin.Properties;

namespace LandWin
{
    public partial class EditDonatorFrm : Form
    {
        private DonateMember _member;

        public DonateMember DonateMember
        {
            get { return _member; }
        }

        public EditDonatorFrm(DonateMember member)
        {
            InitializeComponent();
            tb_Save.Enabled = true;
            _member = member;
            _member.BeginEdit();

            _member.PropertyChanged += new PropertyChangedEventHandler(mMember_PropertyChanged);
            this.donateMemberBindingSource.DataSource = _member;

        }


        private void mMember_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (_member.IsValid)
                tb_Save.Enabled = true;
            else
                tb_Save.Enabled = false;
        }
        private void zipcodeTextBox_Leave(object sender, EventArgs e)
        {
            TextBox str = (TextBox)sender;
            if (!String.IsNullOrEmpty(str.Text))
            {

                Tools.ZipcodeListFrm dlg = new Tools.ZipcodeListFrm(str.Text);
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    _member.Zipcode = str.Text;
                    _member.City = dlg.Zipcode_Info.City;
                    _member.State = dlg.Zipcode_Info.State;
                }
                else
                {
                    str.Text = "";
                }
                dlg.Dispose();
            }
            else
            {
                MessageBox.Show(Resources.Enter_your_zipcode.ToString());
            }
        }

        private void tb_Save_Click(object sender, EventArgs e)
        {
            using (StatusBusy busy = new StatusBusy("Saving..."))
            {
                this.donateMemberBindingSource.RaiseListChangedEvents = false;

                DonateMember temp = DonateMember.Clone();
                temp.ApplyEdit();
                try
                {
                    _member = temp.Save();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Dothan.DataPortalException ex)
                {
                    MessageBox.Show(ex.BusinessException.ToString(),
                      "Error saving", MessageBoxButtons.OK,
                      MessageBoxIcon.Exclamation);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(),
                      "Error Saving", MessageBoxButtons.OK,
                      MessageBoxIcon.Exclamation);
                }
                finally
                {
                    this.donateMemberBindingSource.RaiseListChangedEvents = true;
                }
            }
        }

        private void tb_Close_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            if (_member.IsDirty)
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
