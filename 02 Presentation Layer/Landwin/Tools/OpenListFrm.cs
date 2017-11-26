using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace LandWin.Tools
{
    public partial class OpenListFrm : Form
    {

        public OpenListFrm()
        {
            InitializeComponent();
        }

        private void OpenListFrm_Load(object sender, EventArgs e)
        {
            LoadingList();
        }

        private void LoadingList()
        {
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(Application.StartupPath);

            DirectoryInfo[] dirs = dir.GetDirectories();
            FileInfo[] files = dir.GetFiles();
            foreach (System.IO.FileInfo fi in files)
            {
                if (fi.Extension == ".xml" && fi.Name.Contains("850"))
                {

                    string str = fi.Name;
                    str = str.Replace(".xml","");
                    str = str.Replace("850_", "");
                    listBox1.Items.Add(str);
                }
            }
        }

        private void Tb_OK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

  

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listBox1.SelectedIndex > -1)
            {
                this.Tb_filename.Text = this.listBox1.SelectedItem.ToString();
            }

        }

    }
}
