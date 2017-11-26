using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Dothan.Library;

namespace LandWin.Tools
{
    public partial class ZipcodeListFrm : Form
    {

        private ZipcodeInfo _zipcodeid;
        private ZipcodeList _list;

        public ZipcodeInfo Zipcode_Info
        {
            get { return _zipcodeid; }
        }

        public ZipcodeListFrm(string Code)
        {
            InitializeComponent();

            _list = ZipcodeList.GetZipcodeList(Code);
            this.zipcodeListBindingSource.DataSource = _list;
            
        }

        private void Ok_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount != 0)
            {
                _zipcodeid = gridView1.GetRow(this.gridView1.GetSelectedRows()[0]) as ZipcodeInfo;
                this.DialogResult = DialogResult.OK;
            }
            this.Close();
        }
    }
}
