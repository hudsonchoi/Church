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
    public partial class MemberVistViewFrm : Form
    {
        private MemberVisitList _lists;
        private int _memberid;

        public MemberVistViewFrm(int memberid)
        {
            InitializeComponent();
            this.Text = Resources.Visit_Manage;
      
            _memberid = memberid;
            Databind();
        }

        private void tb_new_Click(object sender, EventArgs e)
        {
            try
            {
                MemberVisit _item = MemberVisit.New(_memberid);
                Dothan.Library.Security.PTIdentity user = (Dothan.Library.Security.PTIdentity)Dothan.ApplicationContext.User.Identity;
                _item.Recorder = user.Name;
                _item.Pastor = user.UserName;
                MemberVisitDetailFrm frm = new MemberVisitDetailFrm(_item);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    Databind();
                }
            }
            catch (Dothan.DataPortalException ex)
            {
                MessageBox.Show(ex.BusinessException.ToString(),
                  "Error loading", MessageBoxButtons.OK,
                  MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(),
                  "Error loading", MessageBoxButtons.OK,
                  MessageBoxIcon.Exclamation);
            }
             
        }
        private void Databind()
        { 
            _lists = MemberVisitList.GetList(MainForm.Instance.Divcode.ToString(),_memberid);
            this.memberVisitListBindingSource.DataSource = _lists;  
         
            ApplyAuthorizationRules();
        }
        private void ApplyAuthorizationRules()
        {
            this.tb_addnew.Enabled = MemberVisit.CanAddObject();
            tb_detail.Enabled = MemberVisit.CanGetObject();
        }

        private void tb_detail_Click(object sender, EventArgs e)
        {
            if (this.gridView1.SelectedRowsCount == 0) return;

            MemberVisitInfo info = this.gridView1.GetRow(this.gridView1.GetSelectedRows()[0]) as MemberVisitInfo;
           

            try
            {
                MemberVisit _item = MemberVisit.Get(info.Id);
                MemberVisitDetailFrm frm = new MemberVisitDetailFrm(_item);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    Databind();
                }
            }
            catch (Dothan.DataPortalException ex)
            {
                MessageBox.Show(ex.BusinessException.ToString(),
                  "Error loading", MessageBoxButtons.OK,
                  MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(),
                  "Error loading", MessageBoxButtons.OK,
                  MessageBoxIcon.Exclamation);
            }

        }

        private void tb_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
