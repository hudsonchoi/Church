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
    public partial class StatusLogViewFrm : Form
    {
        public StatusLogViewFrm(int memberid)
        {
            InitializeComponent();

            this.statusLogListBindingSource.DataSource = _entity.bizMember.StatusLogList.Get(memberid);
            this.gridView1.BestFitColumns();
        }
    }
}
