using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using _entity = Dothan.Library.bizFellowship;

namespace LandWin.Tools
{
    public partial class FellowshipLookupFrm : DevExpress.XtraEditors.XtraForm
    {
        public int SelectedFellowship
        {
            get;
            private set;
        }
        
        public FellowshipLookupFrm()
        {
            InitializeComponent();
            this.fellowshipsListBindingSource.DataSource = _entity.FellowshipsList.Get(false);
            this.simpleButton1.Enabled = false;
        }

        private void lookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            int value = (int)((sender as DevExpress.XtraEditors.LookUpEdit).EditValue);
            if (value != 0)
            {
                this.simpleButton1.Enabled = true;
                SelectedFellowship = value;
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (this.SelectedFellowship != 0)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}