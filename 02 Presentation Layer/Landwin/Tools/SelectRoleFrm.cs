using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Dothan.Library;

namespace LandWin
{
    public partial class SelectRoleFrm : Form
    {
        private int _selectkey;

        public int SelectKey
        {
            get { return _selectkey; }
        }
        public SelectRoleFrm(string parent)
        {
            InitializeComponent();
            switch (parent)
            {
                case "ministry":
                    this.comboBox1.DataSource = MinistryRoleList.GetList(MainForm.Instance.Divcode.ToString());
                    this.comboBox1.DisplayMember = "Value";
                    this.comboBox1.ValueMember = "Key";
                    break;

                case "cell":
                    this.comboBox1.DataSource = CellRoleList.GetList(MainForm.Instance.Divcode.ToString());
                    this.comboBox1.DisplayMember = "Value";
                    this.comboBox1.ValueMember = "Key";
                    break;
                case "celllist":
                    this.Text = "Select Cell";
                    this.comboBox1.DataSource = CellList.GetList(MainForm.Instance.Divcode.ToString());
                    this.comboBox1.DisplayMember = "Value";
                    this.comboBox1.ValueMember = "Key";
                    break;
            }
        }

        private void tb_Ok_Click(object sender, EventArgs e)
        {
            if (this.comboBox1.SelectedIndex == 0)
                MessageBox.Show("Please Select a Role");
            else
            {
                _selectkey = (int)this.comboBox1.SelectedValue;
                this.Close();
            }
        }
    }
}
