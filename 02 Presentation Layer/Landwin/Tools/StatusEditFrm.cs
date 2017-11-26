using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using _entity = Dothan.Library;

namespace LandWin.Tools
{
    public partial class StatusEditFrm : DevExpress.XtraEditors.XtraForm
    {

        private string _memberlist;
        private string _membername;
        private string _commandtype;
        private string _memberstatus;
        private int _oldstatus;

        public string MemberList
        {
            get { return _memberlist; }
            set { _memberlist = value; }
        }
        public string MemberName
        {
            get { return _membername; }
            set { _membername = value; }
        }
        public string MemberStatus
        {
            get { return _memberstatus; }
            set { _memberstatus = value; }
        }
        public int OldStatus
        {
            set { _oldstatus = value; }
        }
        public string CommandType
        {
            get { return _commandtype; }
            set { _commandtype = value; }
        }

        public StatusEditFrm()
        {
            InitializeComponent();
            this.typeListBindingSource.DataSource = _entity.bizCommon.TypeList.Get("status", false);
        }

        private void StatusEditFrm_Load(object sender, EventArgs e)
        {
            this.txt_Recorder.Text = Dothan.ApplicationContext.User.Identity.Name;
            this.txt_MemberID.Text= _membername;
            this.txt_CurrentStatus.Text = _memberstatus;

   
        }

        private void bt_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.lookUpEdit1.EditValue == null)
                    return;

                StringBuilder str = new StringBuilder();
                str.Append("Command Type : ").Append(_commandtype).Append(",").Append("Change Status : From");
                str.Append(_memberstatus).Append("  To ").Append(this.lookUpEdit1.Text);
                str.Append("   Recorder  : ").Append(this.txt_Recorder.Text);
                _entity.bizMember.Member.ToUpdateStatus((int)this.lookUpEdit1.EditValue, _memberlist.TrimEnd(','), str.ToString(), this.memoEdit1.Text);

                this.DialogResult = DialogResult.OK;
                this.Close();
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



        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}