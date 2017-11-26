using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace LandWin
{
    public partial class ProgressForm : DevExpress.XtraEditors.XtraForm
    {

        public ProgressForm()
        {
            InitializeComponent();
    
        }

        public void SetProgressValue(int position)
        {
            progressBarControl1.Position = position;
            this.Update();
        }
    }
}