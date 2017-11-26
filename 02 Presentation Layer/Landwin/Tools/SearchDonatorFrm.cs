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
    public partial class dlg_searchdoner : Form
    {
        private string _searchname;
        private DonateMemberList _lists;
        private DonateMemberInfo _member;
        public DonateMemberInfo Member
        {
            get { return _member; }
        }
        public string SearchName
        {
            set
            {
                _searchname = value;
            }
        }
        public dlg_searchdoner(DonateMemberList list)
        {
            InitializeComponent();
            _lists = list;
            this.donateMemberListBindingSource.DataSource = _lists;

        }

    

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {

            if (this.dataGridView1.SelectedRows.Count > 0)
                _member = _lists.GetFind(int.Parse(this.dataGridView1.SelectedRows[0].Cells[0].Value.ToString()));

        }



        private void button4_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count > 0)
            {
                EditDonatorFrm dlg = new EditDonatorFrm(DonateMember.Get(int.Parse(this.dataGridView1.SelectedRows[0].Cells[0].Value.ToString())));
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    if (dlg.DonateMember.Id > 0)
                    {
                        _lists = DonateMemberList.GetListByName(dlg.DonateMember.Name, false);
                        this.donateMemberListBindingSource.DataSource = _lists;
                    }
                }
            }

        }

  
  

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int id = int.Parse(this.dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            if (DonateMember.CheckDonateHistory(id))
            {
                DialogResult result = MessageBox.Show("선택하신 교인을 삭제하시겠습니까?", "Important Message", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    DonateMember.DeleteMember(id);
                    _lists = DonateMemberList.GetListByName(_searchname, false);
                    this.donateMemberListBindingSource.DataSource = _lists;
                }
            }
            else
            {
                MessageBox.Show("선택하신 교인은 헌금내역이 있습니다.");
            }
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (this.dataGridView1.SelectedRows.Count > 0)
            {
                using (EditDonatorFrm dlg = new EditDonatorFrm(DonateMember.Get(int.Parse(this.dataGridView1.SelectedRows[0].Cells[0].Value.ToString()))))
                {
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        if (dlg.DonateMember.Id > 0)
                        {
                            _lists = DonateMemberList.GetListByName(dlg.DonateMember.Name, false);
                            this.donateMemberListBindingSource.DataSource = _lists;
                        }
                    }
                }
            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                DonateMember member = DonateMember.New();
                member.Name = _searchname;
                EditDonatorFrm dlg = new EditDonatorFrm(member);
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    if (dlg.DonateMember.Id > 0)
                    {
                        _lists = DonateMemberList.GetListByName(dlg.DonateMember.Name, false);
                        this.donateMemberListBindingSource.DataSource = _lists;
                    }

                }

            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error Inserting", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error Inserting", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }


    }
}
