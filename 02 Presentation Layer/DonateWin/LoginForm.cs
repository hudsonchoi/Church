using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DonateWin.Properties;
using Dothan;
using Dothan.Library;
using Dothan.Library.Security;


namespace DonateWin
{
    public partial class LoginForm : Form
    {
        private bool _login = false;
 


        public bool Login { get { return _login; } }
        public LoginForm()
        {
            InitializeComponent();
  
        }

        private void OK_Click(object sender, EventArgs e)
        {
            try
            {
                PTPrincipal.Login(this.txtUserID.Text, this.txtPassword.Text);
                this.Close();

            }
            catch (Dothan.DataPortalException ex)
            {
                if (ex.BusinessException is SqlException)
                {
                    Util.ErrorLogging(Resources.SqlError, ex.BusinessException.ToString(), "Error");
                }
                else
                {
                    MessageBox.Show(Resources.LoginErrorMessage, Resources.LoginErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Question);
                }

            }
            finally
            {
                this.txtUserID.Text = "";
                this.txtPassword.Text = "";
                this.txtUserID.Focus();
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            this.txtUserID.Focus();
        }
 

        private void ShowConfiguration(object sedner, EventArgs e)
        {
            this.Visible = false;
            ConfigFrm frm = new ConfigFrm();
            frm.ShowDialog();
            frm.Dispose();
            this.Visible = true;
        }
    }
}
