using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using _entity=Dothan.Library;

namespace LandWin.Tools
{
    public partial class MemberSearchFrm : DevExpress.XtraEditors.XtraForm
    {

        private Modules.WinPart _parent;
        private _entity.bizMember.MemberList _memberlist;
        public MemberSearchFrm(Modules.WinPart Parnet)
        {
            InitializeComponent();
            _parent = Parnet;

            if (_parent is Modules.CellPart)
            {
                this.btnSelectedCouple.Enabled = true;
                this.btnSelectedCouple.Visible = true;
            }
            this.typeListBindingSource.DataSource = _entity.bizCommon.TypeList.Get("baptism", true);
            this.subdivisionListBindingSource.DataSource = _entity.bizCommon.SubdivisionList.Get(true);
            this.fellowshipsListBindingSource.DataSource = _entity.bizFellowship.FellowshipsList.Get(true);
            ct_fellowship.EditValue = 0;
            ct_subdivision.EditValue = 0;
            ctBaptList.EditValue = 0;
        }

        private void btnAddMember_Click(object sender, EventArgs e)
        {
            if (this.gridView1 == null || this.gridView1.SelectedRowsCount == 0)
            {
                MessageBox.Show(Properties.Resources.No_SelectedRow);
                return;
            }

            _parent.ImportMemberList(_entity.bizMember.MemberList.GetListByIdList(Shared.UtiltyDevExpress.GetStringSelectedRow(this.gridView1,"MemberId")));

            this.gridView1.ClearSelection();
      
        }


        private void btnAddCouple_Click(object sender, EventArgs e)
        {

            if (this.gridView1 == null || this.gridView1.SelectedRowsCount == 0)
            {
                MessageBox.Show(Properties.Resources.No_SelectedRow);
                return;
            }

            _parent.ImportMemberList(_entity.bizMember.MemberList.GetListByIdList(GetMemberIDwCouple()));

        }

        private string GetMemberIDwCouple()
        {

            StringBuilder str = new StringBuilder();
            for (int i = 0; i < this.gridView1.SelectedRowsCount; i++)
            {
                int row = (this.gridView1.GetSelectedRows()[i]);
                _entity.bizMember.MemberInfo info = this.gridView1.GetRow(row) as _entity.bizMember.MemberInfo;
                str.Append(info.MemberId).Append(",");
                if(info.SpouseID != 0)
                    str.Append(info.SpouseID).Append(",");
            }
            return str.ToString().Trim(',');
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string fromRegdate = string.Empty;
            string toRegdate = string.Empty;

            if (dt_from.EditValue != null)
               fromRegdate = dt_from.EditValue.ToString();

            if (dt_to.EditValue != null)
                toRegdate = dt_to.EditValue.ToString();

            _memberlist = _entity.bizMember.MemberList.Get(txtName.Text, (int)ct_fellowship.EditValue, (int)ctBaptList.EditValue, (int)ct_subdivision.EditValue, fromRegdate, toRegdate);

            if (_memberlist.Count != 0)
            {
                btn_addmember.Enabled = true;
            }
            else
            {
                MessageBox.Show(Properties.Resources.No_result);
            }
             memberListBindingSource.DataSource = _memberlist;
             this.gridView1.RefreshData();
            
        }


       
        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                this.btnSearch.Focus();
            }
        }

  
    }
}