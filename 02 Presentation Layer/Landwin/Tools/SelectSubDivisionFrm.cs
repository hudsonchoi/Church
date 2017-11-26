using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Dothan.Library;

namespace LandWin
{
    public partial class SelectSubDivisionFrm : DevExpress.XtraEditors.XtraForm
    {
        private int _selected;

        public int SelectedValue
        {
            get
            {
                return _selected;
            }
        }
        public SelectSubDivisionFrm()
        {
            InitializeComponent();
            subdivisionListBindingSource.DataSource = SubdivisionList.GetList("1" , false);
            this.lookUpEdit1.EditValue = 0;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            _selected = (int)this.lookUpEdit1.EditValue;
            this.DialogResult = DialogResult.OK;
            this.Close();

        }
    }
}