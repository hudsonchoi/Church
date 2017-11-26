using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Xml;


namespace LandWin.Shared
{
    public class Utility
    {
        public static void AddXMLAttribute(XmlDocument oXmlDocument, XmlNode oXMLParentNode, string szAttributeName, string szValue)
        {
            XmlAttribute oXmlAttribute = oXmlDocument.CreateAttribute(szAttributeName);
            oXmlAttribute.Value = szValue;
            oXMLParentNode.Attributes.Append(oXmlAttribute);
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
      
        /// <summary>
        /// Load Member image from Loacl Storage
        /// </summary>
        /// <param name="memberid"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Read App.Config App Value
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string ReadAppSetting(string key)
        {
            if (ConfigurationManager.AppSettings[key] == null)
                return string.Empty;
            else
                return ConfigurationManager.AppSettings[key].ToString();
        }


        /// <summary>
        /// Write App.Config App value
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void WriteAppSetting(string key, string value)
        {
            System.Configuration.Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            configuration.AppSettings.Settings[key].Value = value;
            configuration.Save();
            ConfigurationManager.RefreshSection("appSettings");
        }

        public static bool ToConfirmUnSavedData()
        {
            bool result = false ;
            DialogResult dlg = MessageBox.Show("Do you want to close without saving data?", "Important Message", MessageBoxButtons.YesNo);

            if (dlg == DialogResult.Yes)
                result = true;
            return result;

        }

        /// <summary>
        /// Write a error log on local storage
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="stkTrace"></param>
        /// <param name="title"></param>
        public static void ErrorLogging(string msg, string stkTrace, string title)
        {
            WriteToErrorLog(msg, stkTrace, title);

            if (ReadAppSetting("RealMode").Equals("true"))
            {

                MessageBox.Show(stkTrace, title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        public static void UnAuthorizedMessage()
        {
            MessageBox.Show(Properties.Resources.ErrorMassage_UnAuthorized, "UnAuthorized User" , MessageBoxButtons.OK , MessageBoxIcon.Warning);
        }

        public static void WriteToErrorLog(string msg, string stkTrace, string title)
        {
            if (!(System.IO.Directory.Exists(ReadAppSetting("ErrorPath"))))
            {
                System.IO.Directory.CreateDirectory(ReadAppSetting("ErrorPath"));
            }
            FileStream fs = new FileStream(ReadAppSetting("ErrorPath") + "\\errlog.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamWriter s = new StreamWriter(fs);
            s.Close();
            fs.Close();
            FileStream fs1 = new FileStream(ReadAppSetting("ErrorPath") + "\\errlog.txt", FileMode.Append, FileAccess.Write);
            StreamWriter s1 = new StreamWriter(fs1);
            s1.Write("Title: " + title + System.Environment.NewLine);
            s1.Write("Message: " + msg + System.Environment.NewLine);
            s1.Write("StackTrace: " + stkTrace + System.Environment.NewLine);
            s1.Write("Date/Time: " + DateTime.Now.ToString() + System.Environment.NewLine);
            s1.Write("============================================" + System.Environment.NewLine);
            s1.Close();
            fs1.Close();
        }


        //#region DownLoad Images

        //private void DownLoadImageFile()
        //{
        //    try
        //    {
        //        StringBuilder str = GetFileList();
        //        if (str.Length > 0)
        //        {
        //            str.Remove(str.ToString().LastIndexOf("\n"), 1);
        //            string[] filelist = str.ToString().Split('\n');
        //            if (filelist.Length > 0)
        //            {

        //                BackgroundWorker _worker = new BackgroundWorker();
        //                _worker.WorkerReportsProgress = true;
        //                _worker.DoWork += new DoWorkEventHandler(DoWork);
        //                _worker.RunWorkerAsync(filelist);

        //            }
        //            else
        //            {
        //                Shared.Utility.WriteAppSetting("UpdatedDate", DateTime.Now.ToString());
        //                MessageBox.Show(Shared.Utility.ReadAppSetting("UpdatedDate"));
        //            }
        //        }
        //        else
        //        {
        //            Shared.Utility.WriteAppSetting("UpdatedDate", DateTime.Now.ToString());

        //        }
        //    }
        //    catch 
        //    {
        //        MessageBox.Show("Ftp server is not acessible");

        //    }
        //}
        //private void DoWork(object sender, DoWorkEventArgs e)
        //{
        //    string ftphost = ConfigurationManager.AppSettings["FtpSite"].ToString();
        //    string userid = ConfigurationManager.AppSettings["FtpUser"].ToString();
        //    string ftpdirectory = ConfigurationManager.AppSettings["FtpDirectory"].ToString();
        //    string password = ConfigurationManager.AppSettings["FtpPassword"].ToString();
        //    string[] filelist = (string[])e.Argument;
        //    try
        //    {
        //        for (int i = 0; i < filelist.Length; i++)
        //        {

        //            FileStream outputStream = new FileStream(ConfigurationManager.AppSettings["LocalFolder"].ToString() + "\\" + filelist[i], FileMode.Create);

        //            FtpWebRequest reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + ftphost + "/" + ftpdirectory + "/" + filelist[i]));
        //            reqFTP.Method = WebRequestMethods.Ftp.DownloadFile;
        //            reqFTP.UseBinary = true;
        //            reqFTP.Credentials = new NetworkCredential(userid, password);
        //            FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
        //            Stream ftpStream = response.GetResponseStream();
        //            long cl = response.ContentLength;
        //            int bufferSize = 2048;
        //            int readCount;
        //            byte[] buffer = new byte[bufferSize];
        //            readCount = ftpStream.Read(buffer, 0, bufferSize);
        //            while (readCount > 0)
        //            {

        //                outputStream.Write(buffer, 0, readCount);
        //                readCount = ftpStream.Read(buffer, 0, bufferSize);

        //            }
        //            ftpStream.Close();
        //            outputStream.Close();
        //            response.Close();

        //        }
        //        Shared.Utility.WriteAppSetting("UpdatedDate", DateTime.Today.ToString());

        //    }
        //    catch
        //    {
        //        MessageBox.Show("Ftp server is not acessible");

        //    }
        //}

        //private Match GetMatchingRegex(string line)
        //{
        //    string[] formats = { 
        //                @"(?<timestamp>\d{2}\-\d{2}\-\d{4}\s+\d{2}:\d{2}[Aa|Pp][mM])\s+(?<dir>\<\w+\>){0,1}(?<size>\d+){0,1}\s+(?<name>.+)",
        //                @"(?<dir>[\-d])(?<permission>([\-r][\-w][\-xs]){3})\s+\d+\s+\w+\s+\w+\s+(?<size>\d+)\s+(?<timestamp>\w+\s+\d+\s+\d{4})\s+(?<name>.+)" ,
        //                @"(?<dir>[\-d])(?<permission>([\-r][\-w][\-xs]){3})\s+\d+\s+\d+\s+(?<size>\d+)\s+(?<timestamp>\w+\s+\d+\s+\d{4})\s+(?<name>.+)" ,
        //                @"(?<dir>[\-d])(?<permission>([\-r][\-w][\-xs]){3})\s+\d+\s+\d+\s+(?<size>\d+)\s+(?<timestamp>\w+\s+\d+\s+\d{1,2}:\d{2})\s+(?<name>.+)" ,
        //                @"(?<dir>[\-d])(?<permission>([\-r][\-w][\-xs]){3})\s+\d+\s+\w+\s+\w+\s+(?<size>\d+)\s+(?<timestamp>\w+\s+\d+\s+\d{1,2}:\d{2})\s+(?<name>.+)" ,
        //                @"(?<dir>[\-d])(?<permission>([\-r][\-w][\-xs]){3})(\s+)(?<size>(\d+))(\s+)(?<ctbit>(\w+\s\w+))(\s+)(?<size2>(\d+))\s+(?<timestamp>\w+\s+\d+\s+\d{2}:\d{2})\s+(?<name>.+)" };

        //    Regex rx;
        //    Match m;
        //    for (int i = 0; i < formats.Length; i++)  //As Integer = 0 To formats.Length - 1
        //    {
        //        rx = new Regex(formats[i] ,RegexOptions.IgnorePatternWhitespace);
        //        m = rx.Match(line);
        //        if (m.Success)
        //        {
        //            return m;
        //        }
        //    }
        //    return null;
        //}

        //private StringBuilder GetFileList()
        //{
        //    StringBuilder result = new StringBuilder();
        //    if (string.IsNullOrEmpty(Shared.Utility.ReadAppSetting("UpdatedDate")))
        //    {

        //        string file;
        //        string ftphost = ConfigurationManager.AppSettings["FtpSite"].ToString();
        //        string userid = ConfigurationManager.AppSettings["FtpUser"].ToString();
        //        string ftpdirectory = ConfigurationManager.AppSettings["FtpDirectory"].ToString();
        //        string password = ConfigurationManager.AppSettings["FtpPassword"].ToString();


        //        FtpWebRequest ftp;
        //        ftp = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + ftphost + "/" + ftpdirectory + "/"));
        //        ftp.Credentials = new NetworkCredential(userid, password);
        //        ftp.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
        //        WebResponse response = ftp.GetResponse();
        //        StreamReader reader = new StreamReader(response.GetResponseStream());
        //        string line = reader.ReadLine();
        //        int total = 0;
        //        while (line != null)
        //        {
        //            Match m = GetMatchingRegex(line);
        //            total++;

        //            if (m.Groups["name"].Value.Trim('\r').IndexOf("jpg") != -1)
        //            {
        //                file = string.Format("{0}\\{1}", ConfigurationManager.AppSettings["LocalFolder"].ToString(), m.Groups["name"].Value.Trim('\r'));

        //                if (File.Exists(file))
        //                {
        //                    FileInfo info = new FileInfo(file);
        //                    if (Convert.ToInt64(m.Groups["size"].Value) != info.Length)
        //                    {
        //                        info.Delete();
        //                        result.Append(m.Groups["name"].Value.Trim('\r'));
        //                        result.Append("\n");
        //                    }
        //                }
        //                else
        //                {
        //                    result.Append(m.Groups["name"].Value.Trim('\r'));
        //                    result.Append("\n");

        //                }
        //            }
        //            line = reader.ReadLine();

        //        }
        //        reader.Close();
        //        response.Close();
        //    }
        //    else
        //    {

        //        FileLog list = FileLog.Get(Shared.Utility.ReadAppSetting("UpdatedDate"));
        //        for (int i = 0; i < list.Count; i++)
        //        {
        //            result.Append(list[i].Value.Trim('\r'));
        //            result.Append("\n");
        //        }
        //    }
        //    return result;
        //}


        //#endregion
    }
}
