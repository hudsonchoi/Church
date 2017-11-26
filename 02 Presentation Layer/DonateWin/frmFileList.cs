using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;

namespace DonateWin
{
    public partial class frmFileList : DevExpress.XtraEditors.XtraForm
    {
        private string _selectedFile;

        public string SelectedFile
        {
            get
            {
                return _selectedFile;
            }
        }

        public frmFileList()
        {
            InitializeComponent();
            DataBinding();
        }

        private void DataBinding()
        {
            lbUnSavedFile.DataSource = Util.GetUnSavedFile();
            
        }
        private void btnLoad_Click(object sender, EventArgs e)
        {
            _selectedFile =   string.Format("{0}//logs//{1}", Application.StartupPath , lbUnSavedFile.SelectedItem as string);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dlg = MessageBox.Show("Do you want to delete a selected file?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlg == DialogResult.Yes)
            {
                string filePath = string.Format("{0}//logs//{1}", Application.StartupPath , lbUnSavedFile.SelectedItem as string);
             
                File.Delete(filePath);
                DataBinding();
            }
        }

        


     

        
    }
}