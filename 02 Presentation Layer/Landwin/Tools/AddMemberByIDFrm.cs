using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using LandWin;
using Dothan.Library;

namespace LandWin.Tools
{
    public partial class AddMemberbyIDFrm : DevExpress.XtraEditors.XtraForm
    {

        private MembersInfo _memberinfo;
        WinPart _part = null;
        public AddMemberbyIDFrm(WinPart part)
        {
            _part = part;

            InitializeComponent();
        }

        private void Frm_AddbyMemberID_Load(object sender, EventArgs e)
        {

        }


        private void textEdit1_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textEdit1.Text))
            {
                bt_AddMember.Enabled = true;
                int id;
                if (int.TryParse(textEdit1.Text,  out id))
                {
                    SearchMemberByID(id);
                }
                else
                {
                    LB_Message.Text = "Please Check a MemberID";
                    bt_AddMember.Enabled = false;
                }
            }
            else
            {
                LB_Message.Text = "Please Enter a MemberID";
                bt_AddMember.Enabled = false;
            }
        }

        private void SearchMemberByID(int id)
        {
            MemberList _list = MemberList.GetListById(id);
            if (_list.Count < 0)
                LB_Message.Text = LandWin.Properties.Resources.No_result;
            else
            {
                _memberinfo = _list[0];
                LB_Message.Text = string.Format("ID : {0} | Name : {1}", _list[0].MemberId, _list[0].Ko_Name);
                bt_AddMember.Enabled = true;
            }
        }

        private void bt_AddMember_Click(object sender, EventArgs e)
        {
            _part.OnCommonAddMemberByID(_memberinfo, e);
        }

        private void textEdit1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }


    }
}