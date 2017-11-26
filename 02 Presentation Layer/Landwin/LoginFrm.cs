using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using LandWin.Properties;
using Dothan.Library;
using Dothan.Library.Security;


namespace LandWin.Modules
{
    public partial class LoginFrm : DevExpress.XtraEditors.XtraForm
    {

        
        public LoginFrm()
        {
            InitializeComponent();
        }

        private void Login()
        {
            this.Cursor = Cursors.WaitCursor;
            this.Enabled = false;
            try
            {
                PTPrincipal.Login(txtUserName.Text, this.txtPassword.Text);
                this.Close();

            }
            catch (Dothan.DataPortalException ex)
            {
                if (ex.BusinessException is SqlException)
                {
                    Shared.Utility.ErrorLogging(Properties.Resources.ErrorMessage_SqlException, ex.BusinessException.ToString(), "Error");

                }
                else
                {
                    MessageBox.Show(Resources.ErrorMessage_login, Resources.ErrorMessage_loginCaption, MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
            }
            catch (Exception ex)
            {
                Shared.Utility.ErrorLogging(Properties.Resources.ErrorMessage_General, ex.ToString(), "Error");

            }
            finally
            {
                this.Enabled = true;
                this.Cursor = Cursors.Default;
                this.txtPassword.Text = string.Empty;
                this.txtUserName.Text = string.Empty;
                
            }
        }
        

        private void LoginFrm_Load(object sender, EventArgs e)
        {
            this.txtUserName.Focus();
        }



        private void btCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void labelControl1_Click(object sender, EventArgs e)
        {
            this.Visible = false;        
            using(Configuration.ConfigFrm frm = new Configuration.ConfigFrm()) 
            {
                frm.ShowDialog();
            }
            this.Visible = true;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtPassword.Text) || string.IsNullOrEmpty(txtUserName.Text))
            {
                MessageBox.Show("Please Enter a UserName and Password");
                txtUserName.Focus();
                return;
            }
            Login();
        }
    }
}