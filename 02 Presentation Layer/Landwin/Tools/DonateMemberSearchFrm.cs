using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Dothan.Library;
using Dothan.Library.bizDonate;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace LandWin.Tools
{
    public partial class DonateMemberSearchFrm : DevExpress.XtraEditors.XtraForm
    {
        private DonateMemberList _lists;
        private DonateMemberInfo _info;

        public DonateMemberInfo SelectedMember { get { return _info; } }

        public DonateMemberSearchFrm(DonateMemberList list)
        {
            InitializeComponent();
            _lists = list;
            BindingList();
            ApplyAuthorized();
        }

        private void ApplyAuthorized()
        {
            this.btnAddMember.Enabled = DonateMember.CanAddObject();
            this.btnEditMember.Enabled = DonateMember.CanEditObject();
            this.btnSelected.Enabled = DonateMember.CanDeleteObject();
        }
        private void BindingList()
        {
            this.donateMemberListBindingSource.DataSource = _lists;
            this.gridView1.RefreshData();
        }

        private void btnFindMember_Click(object sender, EventArgs e)
        {
            _lists = DonateMemberList.GetList(0, txtKoName.Text, string.Empty, txtEnLatName.Text, txtEnFirstName.Text, txtAddress.Text);
            if (_lists.Count == 0)
            {
                MessageBox.Show("No result Found.");
            }
            else
            {
                BindingList();
            }
        }

        private void EditMember(int id)
        {
            DonateMember member = DonateMember.Get(id);
            LoadDonateMemberInfo(member);
        }
        private void AddNewMember()
        {
            DonateMember member = DonateMember.New();
            LoadDonateMemberInfo(member);
        }

        private void LoadDonateMemberInfo(DonateMember member)
        {
            Tools.DonateMemberFrm frm = new Tools.DonateMemberFrm(member);
            if (frm.ShowDialog() == DialogResult.OK)
            {

                _lists = DonateMemberList.GetList(frm.DonateMember.Id);
                BindingList();
            }
        }

        private void btnAddMember_Click(object sender, EventArgs e)
        {
            AddNewMember();
        }

        private void btnEditMember_Click(object sender, EventArgs e)
        {
            if (this.gridView1.SelectedRowsCount != 0)
            {
                DonateMemberInfo info = this.gridView1.GetRow(this.gridView1.GetSelectedRows()[0]) as DonateMemberInfo;
                EditMember(info.ID);
            }
            else
                MessageBox.Show("Can not find a selected member");
        }

      

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            GridHitInfo info = view.CalcHitInfo(pt);
            if (info.InRow || info.InRowCell)
            {
                EditMember((int)view.GetRowCellValue(info.RowHandle, "ID"));
            }
        }

        private void SelectedMember_Click(object sender, EventArgs e)
        {

            if (this.gridView1.SelectedRowsCount == 0)
                return;

            try
            {
                _info = this.gridView1.GetRow(this.gridView1.GetSelectedRows()[0]) as DonateMemberInfo;
                this.DialogResult = DialogResult.OK;
                this.Close();

            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
    }
}