using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Dothan.Library;

namespace LandWin.Tools
{
    public partial class NewFamilyFrm : DevExpress.XtraEditors.XtraForm
    {
        private Family _member;
        private int _code;
        public NewFamilyFrm(Family family)
        {
            InitializeComponent();
            _code = family.Code;
            bt_Save.Enabled = false;
            _member = family;
            _member.BeginEdit();
            _member.PropertyChanged += new PropertyChangedEventHandler(mMember_PropertyChanged);
            this.sexListBindingSource.DataSource = SexList.GetList(false);
            this.marriageListBindingSource.DataSource = MarriageList.GetList(false);
            this.relationshipListBindingSource.DataSource = RelationshipList.GetList();
            this.baptismListBindingSource.DataSource = BaptismList.GetList(_member.Divcode, false);
            this.fellowshipsListBindingSource.DataSource = FellowshipsList.GetList(_member.Divcode, false);
            this.statusListBindingSource.DataSource = StatusList.GetList(_member.Divcode, false,1);
            this.subdivisionListBindingSource.DataSource = SubdivisionList.GetList(_member.Divcode, false);
            this.entryTypeListBindingSource.DataSource = EntryTypeList.GetList(_member.Divcode, false);
            this.familyBindingSource.DataSource = _member;
        }

        private void mMember_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {

            if (_member.IsValid)
                bt_Save.Enabled = true;
        }

        private void CheckSameName()
        {
            string _name = string.Format("{0}{1}", this.Ko_LastnameTextEdit.Text, this.Ko_FirstnameTextEdit.Text);
            DonateMemberList memberlist = DonateMemberList.GetListByName(_name, false);
            if (memberlist.Count >= 1)
            {
                SearchSameNameFrm dlg = new SearchSameNameFrm(memberlist);
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    this.Ko_FirstnameTextEdit.Text =
                    this.En_FirstnameTextEdit.Text = dlg.Member.En_firstname;
                    this.En_LastnameTextEdit.Text = dlg.Member.En_lastname;
                    _member.DonateID = dlg.Member.ID;
                }

            }
        }

        private void KeyPress_Enter(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
        private void EditDateTime(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.TextEdit edit = (DevExpress.XtraEditors.TextEdit)sender;
            Point pt1 = this.PointToScreen(edit.Location);
            CalendarFrm dlg = new CalendarFrm(edit.Text, pt1.X, pt1.Y + edit.Height);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                edit.Text = dlg.SelectedDate.ToString("MM/dd/yyyy");
                SendKeys.Send("{TAB}");
            }
            else
            {
                edit.Text = "";
                edit.Focus();
            }
        }

        private void bt_Save_Click(object sender, EventArgs e)
        {
            if (!dxErrorProvider1.HasErrors)
            {
                this.familyBindingSource.EndEdit();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void Ko_LastnameTextEdit_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_member.Ko_Firstname))
            {
                this.Ko_FirstnameTextEdit.Focus();
            }
            else
            {
                CheckSameName();
            }
        }

        private void Ko_FirstnameTextEdit_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_member.Ko_Lastname))
            {
                this.Ko_LastnameTextEdit.Focus();
            }
            else
            {
                CheckSameName();
            }
        }


        private void pictureEdit1_Click(object sender, EventArgs e)
        {
            Common.SelectedCalendar(BirthDayTextEdit);
        }

        private void EditDatetimeText_Leave(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.TextEdit edit = (DevExpress.XtraEditors.TextEdit)sender;
            if (Common.ValidateDatetime(edit.Text))
                SendKeys.Send("{TAB}");
            else
            {
                XtraMessageBox.Show("It is invalid DataTime", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                edit.Text = "";
            }
        }

        

        private void pictureEdit3_Click(object sender, EventArgs e)
        {
            Common.SelectedCalendar(Baptism_YearTextEdit);
        }

        private void pictureEdit2_Click(object sender, EventArgs e)
        {
            Common.SelectedCalendar(RegDateTextEdit);
        }
    }
}