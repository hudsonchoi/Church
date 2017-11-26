using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using _entity = Dothan.Library;
using LandWin.Properties;

namespace LandWin.Tools
{
    public partial class SearchSameNameFrm : Form
    {
        private _entity.bizDonate.DonateMemberList _lists;
        private _entity.bizDonate.DonateMemberInfo _member;
        
        public _entity.bizDonate.DonateMemberInfo SelectedMember
        {
            get { return _member; }
        }

        public SearchSameNameFrm(_entity.bizDonate.DonateMemberList list)
        {
            InitializeComponent();
            _lists = list;
            this.donateMemberListBindingSource.DataSource = _lists;
        }

        private void tb_importmember_Click(object sender, EventArgs e)
        {
            if (this.gridView1.SelectedRowsCount == 0) return;

            _entity.bizDonate.DonateMemberInfo info = gridView1.GetRow((int)this.gridView1.GetSelectedRows()[0]) as _entity.bizDonate.DonateMemberInfo;

            if (info.MemberID != 0)
            {
                MessageBox.Show("이미 등록된 교인입니다.");
            }
            else
            {
                _member = info;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void tb_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
