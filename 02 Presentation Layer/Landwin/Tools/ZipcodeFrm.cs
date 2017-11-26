using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using _entity = Dothan.Library;

namespace LandWin.Tools
{
    public partial class ZipcodeFrm : Form
    { 
        private _entity.bizCommon.ZipcodeInfo _info;
        private _entity.bizCommon.ZipcodeList _list;

        public _entity.bizCommon.ZipcodeInfo ZipcodeInfo
        {
            get { return _info; }
        }

        public ZipcodeFrm(string Code)
        {
            InitializeComponent();

            _list = _entity.bizCommon.ZipcodeList.GetList(Code);
            this.zipcodeListBindingSource.DataSource = _list;
            
            this.gridView1.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(gridView1_SelectionChanged);
        }

        private void gridView1_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            _info = this.gridView1.GetRow(e.ControllerRow) as _entity.bizCommon.ZipcodeInfo; 
        }
        private void Ok_Click(object sender, EventArgs e)
        {

            if (this.gridView1.SelectedRowsCount != 0)
            {
                _info = this.gridView1.GetRow(this.gridView1.GetSelectedRows()[0]) as _entity.bizCommon.ZipcodeInfo;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }

            if (_info == null)
            {
                MessageBox.Show("Cannot find Zipcode Information selection in list");
            }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gridControl1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                this.btnOk.Focus();
            }
        }
    }
}
