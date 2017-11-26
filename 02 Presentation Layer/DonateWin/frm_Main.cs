using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Dothan.Library;
using DonateWin.Properties;
using System.Reflection;

namespace DonateWin
{
    public partial class frm_Main : Form
    {
     
        private static frm_Main _main;

        public frm_Main()
        {
            InitializeComponent();
            _main = this;
            SetUpDirectory();
        }

        internal static frm_Main Instance
        {
            get { return _main; }
        }

        private void frm_Main_Load(object sender, EventArgs e)
        {
            this.Text = Resources.Application_Name.ToString();
         
            if (Dothan.ApplicationContext.AuthenticationType == "Windows")
                AppDomain.CurrentDomain.SetPrincipalPolicy(System.Security.Principal.PrincipalPolicy.WindowsPrincipal);
            else
                DoLogin();
            ShowDonate();
        }

        private void SetUpDirectory()
        {
            if (!(System.IO.Directory.Exists(Application.StartupPath + "\\logs\\")))
            {
                System.IO.Directory.CreateDirectory(Application.StartupPath + "\\logs\\");
            }
        }
        private void DoLogin()
        {
              System.Security.Principal.IPrincipal user = Dothan.ApplicationContext.User;
            if (user.Identity.IsAuthenticated)
            {
                foreach (Control ctl in Panel1.Controls)
                    if (ctl is WinPart)
                        ((WinPart)ctl).OnCurrentPrincipalChanged(this, EventArgs.Empty);

            }
            else
            {
                    using (LoginForm loginForm = new LoginForm())
                    {
                        loginForm.ShowDialog(this);
                        user = Dothan.ApplicationContext.User;
                    }
            }
       
            if (!user.Identity.IsAuthenticated)
            {
                this.Close();
            } 
        }

        private void tb_logout_Click(object sender, EventArgs e)
        {
            Dothan.Library.Security.PTPrincipal.Logout();
            DoLogin();
        }


        #region Winpart

        private void ShowWinPart(WinPart part)
        {
            part.Dock = DockStyle.Fill;
            part.Visible = true;
            part.BringToFront();
            Assembly asm = Assembly.GetExecutingAssembly();
            string[] parts = asm.FullName.Split(',');
            string ver = parts[1].Replace("=", " ");
            this.Text = Resources.Application_Name.ToString() + " " + ver;

        }

        private void AddWinPart(WinPart part)
        {
            part.CloseWinPart += new EventHandler(CloseWinPart);
            Panel1.Controls.Add(part);
            ShowWinPart(part);
        }

        public int DocumentCount
        {
            get
            {
                int count = 0;
                foreach (Control ctl in Panel1.Controls)
                    if (ctl is WinPart)
                        count++;
                return count;
            }
        }

        private void CloseWinPart(object sender, EventArgs e)
        {
            WinPart part = (WinPart)sender;
            part.CloseWinPart -= new EventHandler(CloseWinPart);
            part.Visible = false;
            Panel1.Controls.Remove(part);
            part.Dispose();
            if (DocumentCount == 0)
            {
                this.Text = Resources.Application_Name.ToString();
            }
            else
            {
                foreach (Control ctl in Panel1.Controls)
                {
                    if (ctl is WinPart)
                    {
                        this.Text = Resources.Application_Name.ToString() + ((WinPart)ctl).ToString();
                        break;
                    }
                }

            }
        }



        private void AllCloseWinpart()
        {
            foreach (Control ctl in Panel1.Controls)
            {
                if (ctl is WinPart)
                {
                    WinPart part = (WinPart)ctl;
                    part.CloseWinPart -= new EventHandler(CloseWinPart);
                    part.Visible = false;
                    Panel1.Controls.Remove(part);
                    part.Dispose();
                }
            }
        }
        #endregion
        private void ShowDonate()
        {
            AddWinPart(new frm_newdonates());

        }

    }
}
