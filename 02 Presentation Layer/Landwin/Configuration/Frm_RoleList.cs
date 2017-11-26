using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Dothan.Library.Admin;

namespace LandWin
{
    public partial class Frm_RoleList : Form
    {
        private RoleList _list;
        private string[] _customerroles;

        public string[] CustomRoleList
        {
            get { return _customerroles; }
            set { _customerroles = value; }
        }
 

        public Frm_RoleList()
        {
            InitializeComponent();
        }

        private void FrmRoleList_Load(object sender, EventArgs e)
        {
            _list = RoleList.GetList();
            foreach (var item in _list)
            {
                if (item.Value.ToString().IndexOf("Visit") < 0)
                {
                    if (_customerroles != null)
                        this.tb_rolelist.Items.Add(item.Value, _customerroles.Contains(item.Value));
                    else
                        this.tb_rolelist.Items.Add(item.Value);
                }
            }
        }

        private void tb_Ok_Click(object sender, EventArgs e)
        {
            int i = 0;
            _customerroles = new string[this.tb_rolelist.CheckedItems.Count];
            foreach (string value in this.tb_rolelist.CheckedItems)
            {
                _customerroles[i] = _list.Key(value).ToString();
                i++;
            }
          
        }

        private void tb_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
