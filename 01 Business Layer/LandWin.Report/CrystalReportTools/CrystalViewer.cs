using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LandWin.Report.CrystalReportTools
{
    public partial class CrystalViewer : Form
    {
        public CrystalViewer()
        {
            InitializeComponent();

            CrystalManager manager = new CrystalManager();
        }
    }
}
