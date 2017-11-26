using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.ComponentModel;
using System.Reflection;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors;
using System.Configuration;
using Dothan.Library;

namespace LandWin
{
    public class Common
    {

        public static void UpdateFileLog(string filename, string user)
        {
            int updated = 0;// FileLog.UpdateFileLog(filename, user);
            WriteAppSetting("UpdatedID", updated.ToString());
        }

        public static string ReadAppSetting(string key)
        {
            if (ConfigurationManager.AppSettings[key] == null)
                return string.Empty;
            else
                return ConfigurationManager.AppSettings[key].ToString();
        }
        public static void WriteAppSetting(string key, string value)
        {
            System.Configuration.Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            configuration.AppSettings.Settings[key].Value = value;
            configuration.Save();
            ConfigurationManager.RefreshSection("appSettings");
        }
        public static void WriteLog(string logMessage)
        {
            string filename = Application.StartupPath + "\\" + string.Format("log{0}{1}{2}.txt", DateTime.Today.ToString("MMddyyyy"));
            if (!File.Exists(filename))
                File.Create(filename);

            using (StreamWriter w = File.AppendText(filename))
            {
                w.Write("\r\nLog Entry : ");
                w.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                    DateTime.Now.ToLongDateString());
                w.WriteLine("  :");
                w.WriteLine("  :{0}", logMessage);
                w.WriteLine("-------------------------------");
                // Update the underlying file.
                w.Flush();
            }
        }
        public static void SelectedCalendar(object sendor)
        {
            TextEdit edit = (TextEdit)sendor;
            string date = edit.Text;
            Point pt1 = edit.Parent.PointToScreen(edit.Location);
            CalendarFrm dlg = new CalendarFrm(date, pt1.X, pt1.Y + edit.Height);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                edit.Text = dlg.SelectedDate.ToString("M/dd/yyyy");
                edit.Focus();
                SendKeys.Send("{TAB}");
            }
            else
            {
                edit.Text = date;
                edit.Focus();
            }
        }
        public static bool ValidateDatetime(string str)
        {

            bool result = false;
            if (!string.IsNullOrEmpty(str))
            {
                DateTime value;
                if (DateTime.TryParse(str, out value))
                {
                    if (value < DateTime.Today.AddYears(100))
                        result = true;
        
                }
            }
            return result;
        }
      
     
       
        public static void AddXMLAttribute(XmlDocument oXmlDocument, XmlNode oXMLParentNode, string szAttributeName, string szValue)
        {
            XmlAttribute oXmlAttribute = oXmlDocument.CreateAttribute(szAttributeName);
            oXmlAttribute.Value = szValue;
            oXMLParentNode.Attributes.Append(oXmlAttribute);
        }
        public static Image LoadImage(int memberid)
        {
            string filename = " C:\\LandWin\\DATA\\MemberImage\\"
                       + memberid.ToString() + ".jpg";

            Image result;
            if (!File.Exists(filename))
                return LandWin.Properties.Resources.NoPhoto;
            else
            {

                #region Save file to byte array

                long size = (new FileInfo(filename)).Length;
                FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
                byte[] data = new byte[size];
                try
                {
                    fs.Read(data, 0, (int)size);
                }
                finally
                {
                    fs.Close();
                    fs.Dispose();
                }

                #endregion

                #region Convert bytes to image

                MemoryStream ms = new MemoryStream();
                ms.Write(data, 0, (int)size);
                result = new Bitmap(ms);
                ms.Close();

                #endregion

                return result;


            }
        }
    }
    public class StatusBusy : IDisposable
    {
        private string _oldStatus;
        private Cursor _oldCursor;

        public StatusBusy(string statusText)
        {
           // _oldStatus = MainForm.Instance.StatusLabel.Text;
            //MainForm.Instance.StatusLabel.Text = statusText;
            _oldCursor = MainForm.Instance.Cursor;
            MainForm.Instance.Cursor = Cursors.WaitCursor;
        }

        // IDisposable
        private bool _disposedValue = false; // To detect redundant calls

        protected void Dispose(bool disposing)
        {
            if (!_disposedValue)
                if (disposing)
                {
                  //  MainForm.Instance.StatusLabel.Text = _oldStatus;
                    MainForm.Instance.Cursor = _oldCursor;
                }
            _disposedValue = true;
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
