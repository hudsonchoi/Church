using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.Net;
using System.Xml;


namespace LandWin.Configuration
{
    public partial class ConfigFrm : Form
    {
        public ConfigFrm()
        {
            InitializeComponent();
        }
        private void ConfigFrm_Load(object sender, EventArgs e)
        {
            DataLoad();
        }
        private void DataLoad()
        {
            txt_dbname.Text = ConfigurationManager.AppSettings["DBName"].ToString();
            txt_dbserver.Text = ConfigurationManager.AppSettings["DBServer"].ToString();
            txt_DBUserID.Text = ConfigurationManager.AppSettings["DBUserID"].ToString();
            txt_DBPassword.Text = ConfigurationManager.AppSettings["DBPassword"].ToString();
           
            txt_FtpURL.Text = ConfigurationManager.AppSettings["FtpSite"].ToString();
            txt_FtpUserID.Text = ConfigurationManager.AppSettings["FtpUser"].ToString();
            txt_FtpPassword.Text = ConfigurationManager.AppSettings["FtpPassword"].ToString();
            txt_FtpDirectory.Text = ConfigurationManager.AppSettings["FtpDirectory"].ToString();
        }

        private void UpdateSetting(string key, string value)
        {
            System.Configuration.Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            configuration.AppSettings.Settings[key].Value = value;
            configuration.Save();
            ConfigurationManager.RefreshSection("appSettings");
        }
        private void btn_Save_Click(object sender, EventArgs e)
        {
            
            this.Cursor = Cursors.WaitCursor;
            try
            {
                UpdateSetting("DBName", txt_dbname.Text);
                UpdateSetting("DBServer", txt_dbserver.Text);
                UpdateSetting("DBUserID", txt_DBUserID.Text);
                UpdateSetting("DBPassword", txt_DBPassword.Text);
                UpdateSetting("FtpSite", txt_FtpURL.Text);
                UpdateSetting("FtpUser", txt_FtpUserID.Text);
                UpdateSetting("FtpPassword", txt_FtpPassword.Text);
                UpdateSetting("FtpDirectory", txt_FtpDirectory.Text);
                MessageBox.Show("Data has been saved successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void btn_reload_Click(object sender, EventArgs e)
        {
            DataLoad();
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_TestConnDB_Click(object sender, EventArgs e)
        {
            string connstr = string.Format("Server={0}; Database={1};User ID={2};Password={3};",
                            txt_dbserver.Text,
                            txt_dbname.Text,
                             txt_DBUserID.Text,
                            txt_DBPassword.Text
                            );
            SqlConnection conn = new SqlConnection(connstr);
            try
            {
                
                conn.Open();
                MessageBox.Show("DB connection test is successful");
            }
            catch (SqlException ex)
            {
                // output the error to see what's going on
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                conn.Dispose();
            }
        }

        private void btn_TestFtp_Click(object sender, EventArgs e)
        {
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(new Uri("ftp://" + txt_FtpURL.Text + "/" + txt_FtpDirectory.Text + "/"));
                request.UsePassive = false;
                request.Method = WebRequestMethods.Ftp.ListDirectory;
                request.Credentials = new NetworkCredential(txt_FtpUserID.Text, txt_FtpPassword.Text);
                request.GetResponse();
                MessageBox.Show("FTP connection test is successful");
            }
            catch (WebException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {

            }
        }
    }
}
