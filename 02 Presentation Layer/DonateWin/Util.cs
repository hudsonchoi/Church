using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Configuration;
using System.IO;
using System.Xml;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace DonateWin
{
    public class Util
    {

        public static void DeleteLog(string fileName)
        {
            string _fileName = string.Format("{0}\\logs\\{1}", Application.StartupPath, fileName);

            if (System.IO.File.Exists(_fileName))
                System.IO.File.Delete(_fileName);
        }

        public static void SerializableObject<T>(T serializableObject, string fileName)
        {
            if (serializableObject == null) { return; }

            try
            {
                if (!(System.IO.Directory.Exists(Application.StartupPath + "\\logs\\")))
                {
                    System.IO.Directory.CreateDirectory(Application.StartupPath + "\\logs\\");
                }
                string _fileName = string.Format("{0}\\logs\\{1}", Application.StartupPath, fileName);

                using (FileStream fs = new FileStream(_fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    binaryFormatter.Serialize(fs, serializableObject);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "error");
            }

        }
        public static T DeSerializeObject<T>(string fileName)
        {
            if (string.IsNullOrEmpty(fileName)) { return default(T); }

            T objectOut = default(T);

            try
            {

                using (Stream stream = File.Open(fileName, FileMode.Open))
                {
                    var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    objectOut = (T)binaryFormatter.Deserialize(stream);
                }

            }
            catch (Exception ex)
            {
                //Log exception here
            }

            return objectOut;
        }
        public static bool TestForServer(string address, int port)
        {
            int timeout = 500;
            if (ConfigurationManager.AppSettings["RemoteTestTimeout"] != null)
                timeout = int.Parse(ConfigurationManager.AppSettings["RemoteTestTimeout"]);
            var result = false;
            try
            {
                using (var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
                {
                    IAsyncResult asyncResult = socket.BeginConnect(address, port, null, null);
                    result = asyncResult.AsyncWaitHandle.WaitOne(timeout, true);
                    socket.Close();
                }
                return result;
            }
            catch { return false; }
        }

        public static string[] GetUnSavedFile()
        {
            string[] fileEntries = new DirectoryInfo(Application.StartupPath + "\\logs\\").GetFiles().Select(o => o.Name).ToArray();
            return fileEntries;
        }

        public static void ErrorLogging(string msg, string stkTrace, string title)
        {
            WriteToErrorLog(msg, stkTrace, title);

            if (ConfigurationManager.AppSettings["DevelopeMode"].Equals("true"))
            {

                MessageBox.Show(stkTrace, title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }


        public static void WriteToErrorLog(string msg, string stkTrace, string title)
        {
            if (!(System.IO.Directory.Exists(Application.StartupPath + "\\Errors\\")))
            {
                System.IO.Directory.CreateDirectory(Application.StartupPath + "\\Errors\\");
            }
            FileStream fs = new FileStream(Application.StartupPath + "\\Errors\\errlog.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamWriter s = new StreamWriter(fs);
            s.Close();
            fs.Close();
            FileStream fs1 = new FileStream(Application.StartupPath + "\\Errors\\errlog.txt", FileMode.Append, FileAccess.Write);
            StreamWriter s1 = new StreamWriter(fs1);
            s1.Write("Title: " + title + System.Environment.NewLine);
            s1.Write("Message: " + msg + System.Environment.NewLine);
            s1.Write("StackTrace: " + stkTrace + System.Environment.NewLine);
            s1.Write("Date/Time: " + DateTime.Now.ToString() + System.Environment.NewLine);
            s1.Write("============================================" + System.Environment.NewLine);
            s1.Close();
            fs1.Close();
        }
    }
}
