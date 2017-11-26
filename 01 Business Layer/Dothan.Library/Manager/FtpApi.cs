using System;
using System.Net;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Reflection;

namespace Dothan.Library
{
    public class FTPApi
    {
        public event EventHandler<DownloadCompleteEventArgs> DownloadCompleted;
        public event EventHandler<UploadCompleteEventArgs> UploadCompleted;
        public event EventHandler<DownloadingProgressEventArgs> DownloadProgress;
        public event EventHandler<UploadingProgressEventArgs> UploadProgress;
        public event EventHandler<StatusChangeEventArgs> StatusChange;

        public SynchronizationContext context;

        internal bool IsConneted = false;

        private string _username = string.Empty;
        private string _password = string.Empty;


        #region Event

        void OnDownloadComplete(string filename)
        {
            EventHandler<DownloadCompleteEventArgs> temp = DownloadCompleted;

            if (temp != null)
            {
                DownloadCompleteEventArgs e = new DownloadCompleteEventArgs();
                e.filename = filename;

                context.Post(delegate(object data) { DownloadCompleted(this, e); }, null);

            }
        }

        void OnUploadComplete(string filename)
        {
            EventHandler<UploadCompleteEventArgs> temp = UploadCompleted;

            if (temp != null)
            {
                UploadCompleteEventArgs e = new UploadCompleteEventArgs();
                e.filename = filename;
                context.Post(delegate(object data) { UploadCompleted(this, e); }, null);
            }
        }

        void OnDownloadProgress(string filename, long bytesTransferred)
        {
            EventHandler<DownloadingProgressEventArgs> temp = DownloadProgress;

            if (temp != null)
            {
                DownloadingProgressEventArgs e = new DownloadingProgressEventArgs();
                e.filename = filename;
                e.bytesTransferred = bytesTransferred;

                context.Post(delegate(object data) { DownloadProgress(this, e); }, null);

            }
        }

        void OnUploadProgress(string filename, long bytesTransferred)
        {
            EventHandler<UploadingProgressEventArgs> temp = UploadProgress;
            if (temp != null)
            {
                UploadingProgressEventArgs e = new UploadingProgressEventArgs();
                e.filename = filename;
                e.bytesTransferred = bytesTransferred;
                //uploadProgress(this, e);
                context.Post(delegate(object state) { UploadProgress(this, e); }, null);
            }
        }

        internal void OnStatusChange(string message, long upload, long down)
        {
            EventHandler<StatusChangeEventArgs> temp = StatusChange;

            if (temp != null)
            {
                StatusChangeEventArgs e = new StatusChangeEventArgs();
                e.message = message;
                e.bytesUploaded = upload;
                e.bytesDownloaded = down;

                context.Post(delegate(object stat) { StatusChange(this, e); }, null);
            }
        }
        #endregion

        internal FTPApi()
        {
            context = SynchronizationContext.Current;
        }

        public List<ftpInfo> Connect(string host, string username, string password)
        {
            _username = username;
            _password = password;
            context = SynchronizationContext.Current;
            return browse(host);
        }

        public List<ftpInfo> browse(string path)
        {
            FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(path);
            request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
            List<ftpInfo> files = new List<ftpInfo>();
            request.Credentials = new NetworkCredential(_username, _password);
            Stream rs = (Stream)request.GetResponse().GetResponseStream();

            OnStatusChange("CONNECTED: " + path, 0, 0);

            StreamReader sr = new StreamReader(rs);
            string strList = sr.ReadToEnd();
            string[] lines = null;

            if (strList.Contains("\r\n"))
            {
                lines = strList.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            }
            else if (strList.Contains("\n"))
            {
                lines = strList.Split(new string[] { "\n" }, StringSplitOptions.None);
            }

            //now decode this string array

            if (lines == null || lines.Length == 0)
                return null;

            foreach (string line in lines)
            {
                if (line.Length == 0)
                    continue;
                //parse line
                Match m = GetMatchingRegex(line);
                if (m == null)
                {
                    //failed
                    throw new ApplicationException("Unable to parse line: " + line);
                }

                ftpInfo item = new ftpInfo();
                item.Filename = m.Groups["name"].Value.Trim('\r');
                item.Path = path;
                item.Size = Convert.ToInt64(m.Groups["size"].Value);
                item.Permission = m.Groups["permission"].Value;
                string _dir = m.Groups["dir"].Value;
                if (_dir.Length > 0 && _dir != "-")
                {
                    item.FileType = DirectoryEntryTypes.Directory;
                }
                else
                {
                    item.FileType = DirectoryEntryTypes.File;
                }

                try
                {
                    item.FileDateTime = DateTime.Parse(m.Groups["timestamp"].Value);
                }
                catch
                {
                    item.FileDateTime = DateTime.MinValue; //null;
                }

                files.Add(item);
            }

            return files;


        }
        public string CreateRemoteDirectory(FtpFileInfo file)
        {
            string filename = file.completeFileName;//.Substring(file.completeFileName.LastIndexOf(@"\") + 1);
            FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(file.destination);
            request.Credentials = new NetworkCredential(_username, _password);
            request.Method = WebRequestMethods.Ftp.MakeDirectory;
            request.UseBinary = true;
            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            return response.StatusDescription;

        }


        public void Download(FtpFileInfo file)
        {
            System.IO.FileInfo info = new FileInfo(file.destination);
            if (info.Exists)
                info.Delete();
            FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(file.completeFileName);
            request.Method = WebRequestMethods.Ftp.DownloadFile;
            request.UseBinary = true;
            request.Credentials = new NetworkCredential(_username, _password);
            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            Stream rs = response.GetResponseStream();
            FileStream fs = info.OpenWrite();
            try
            {
                int bufferSize = 2048;
                byte[] bytes = new byte[bufferSize];
                int totalBytes = 0;
                int read = 0;
                do
                {
                    read = rs.Read(bytes, 0, bufferSize);
                    fs.Write(bytes, 0, read);
                    totalBytes += read;
                    OnDownloadProgress(file.completeFileName, totalBytes);
                } while (read > 0);
                OnDownloadComplete(file.completeFileName);
            }
            catch (Exception ex)
            {
                OnStatusChange("Error occured: " + ex.Message, 0, 0);
            }
            finally
            {
                fs.Close();
                rs.Close();
            }
        }
        public void Upload(FtpFileInfo file)
        {
            System.IO.FileInfo info = new FileInfo(file.completeFileName);
            string filename = file.completeFileName.Substring(file.completeFileName.LastIndexOf(@"\") + 1);
            FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(file.destination + "/" + filename);
            request.Credentials = new NetworkCredential(_username, _password);
            request.Method = WebRequestMethods.Ftp.UploadFile;
            request.UseBinary = true;
            request.ContentLength = info.Length;

            int bufferSize = 2048;
            byte[] bytes = new byte[bufferSize];
            int read = 0;
            long totBytes = 0;
            Stream rs = request.GetRequestStream();
            using (FileStream fs = info.OpenRead())
            {
                try
                {
                    do
                    {
                        read = fs.Read(bytes, 0, bufferSize);
                        rs.Write(bytes, 0, read);
                        totBytes += read;
                        OnUploadProgress(file.completeFileName, totBytes);
                    } while (read > 0);
                    OnUploadComplete(file.completeFileName);
                }
                catch { }
                finally
                {
                    fs.Close();
                }
            }
            rs.Close();
            request = null;
            return;
        }

        private Match GetMatchingRegex(string line)
        {
            string[] formats = { 
	                    @"(?<dir>[\-d])(?<permission>([\-r][\-w][\-xs]){3})\s+\d+\s+\w+\s+\w+\s+(?<size>\d+)\s+(?<timestamp>\w+\s+\d+\s+\d{4})\s+(?<name>.+)" ,
	                    @"(?<dir>[\-d])(?<permission>([\-r][\-w][\-xs]){3})\s+\d+\s+\d+\s+(?<size>\d+)\s+(?<timestamp>\w+\s+\d+\s+\d{4})\s+(?<name>.+)" ,
	                    @"(?<dir>[\-d])(?<permission>([\-r][\-w][\-xs]){3})\s+\d+\s+\d+\s+(?<size>\d+)\s+(?<timestamp>\w+\s+\d+\s+\d{1,2}:\d{2})\s+(?<name>.+)" ,
	                    @"(?<dir>[\-d])(?<permission>([\-r][\-w][\-xs]){3})\s+\d+\s+\w+\s+\w+\s+(?<size>\d+)\s+(?<timestamp>\w+\s+\d+\s+\d{1,2}:\d{2})\s+(?<name>.+)" ,
	                    @"(?<dir>[\-d])(?<permission>([\-r][\-w][\-xs]){3})(\s+)(?<size>(\d+))(\s+)(?<ctbit>(\w+\s\w+))(\s+)(?<size2>(\d+))\s+(?<timestamp>\w+\s+\d+\s+\d{2}:\d{2})\s+(?<name>.+)" ,
	                    @"(?<timestamp>\d{2}\-\d{2}\-\d{2}\s+\d{2}:\d{2}[Aa|Pp][mM])\s+(?<dir>\<\w+\>){0,1}(?<size>\d+){0,1}\s+(?<name>.+)"};
            Regex rx;
            Match m;
            for (int i = 0; i < formats.Length; i++)  //As Integer = 0 To formats.Length - 1
            {
                rx = new Regex(formats[i]);
                m = rx.Match(line);
                if (m.Success)
                {
                    return m;
                }
            }
            return null;
        }


    }


    public class DownloadCompleteEventArgs : EventArgs { public string filename;}
    public class UploadCompleteEventArgs : EventArgs { public string filename;}
    public class DownloadingProgressEventArgs : EventArgs
    {
        public string filename;
        public long bytesTransferred;
    }
    public class UploadingProgressEventArgs : EventArgs
    {
        public string filename;
        public long bytesTransferred;
    }
    public class StatusChangeEventArgs : EventArgs
    {
        public string message;
        public long bytesUploaded = 0;
        public long bytesDownloaded = 0;
    }
    public enum DirectionTypes
    {
        Up,
        Down
    }

    public sealed class StringUtils
    {
        public static string ExtractFileFromPath(string fileName, string pathSeperator)
        {
            int pos = fileName.LastIndexOf(pathSeperator);
            return fileName.Substring(pos + 1);
        }

        public static string ExtractFolderFromPath(string fileName, string pathSeparator, bool includeSeparatorAtEnd)
        {
            int pos = fileName.LastIndexOf(pathSeparator);
            return fileName.Substring(0, (includeSeparatorAtEnd ? pos + 1 : pos));
        }
    }

    public sealed class ReflectionUtils
    {
        public static string GetVersion()
        {
            AssemblyName nm = Assembly.GetExecutingAssembly().GetName();
            return nm.Version.Major.ToString() + "." + nm.Version.Minor.ToString() + "." +
                nm.Version.Revision.ToString() + "." + nm.Version.Build.ToString();
        }
    }
    public class ftpInfo
    {
        public string Filename;
        public string Path;
        public DirectoryEntryTypes FileType;
        public long Size;
        public string Permission;
        public DateTime FileDateTime;
    }

    public class FtpFileInfo
    {
        public DirectionTypes direction = DirectionTypes.Down;
        public string completeFileName = "";
        public string destination = "";
        public bool mkdirFlag = false;


        //to upload
        public FtpFileInfo(string fileName, string destination, DirectionTypes direction, bool mkdirFlag)
        {
            this.completeFileName = fileName;
            this.destination = destination;
            this.direction = direction;
            this.mkdirFlag = mkdirFlag;

        }

        public FtpFileInfo(string fileName, string destination, DirectionTypes direction, long filesize)
            : this(fileName, destination, direction, false)
        {
        }
    }
    public enum DirectoryEntryTypes
    {
        File = 0,
        Directory = 1
    }

    public class ftper
    {
        public bool LogginEnabled = false;
        public FTPApi ftp = new FTPApi();
        private System.Collections.Hashtable queue = new Hashtable();
        private bool _threadRunning = false;

        ~ftper()
        {
            ftp = null;
            queue = null;
        }

        public bool IsProcessing()
        {
            return _threadRunning;
        }
        public List<ftpInfo> Connect(string host, string username, string password)
        {
            return ftp.Connect(host, username, password);
        }

        public void Disconnect()
        {
            if (_threadRunning)
                _threadRunning = false;

            int Timeout = 80;
            DateTime Start = DateTime.Now;
            while (queue.Count == 0)
            {
                if (DateTime.Now.Subtract(Start).Seconds > Timeout)
                    break;
            }
        }

        public List<ftpInfo> browse(string path)
        {
            return ftp.browse(path);
        }

        public void AddFolderToUploadQueue(string path, string remoteDestination)
        {
            string[] contents = Directory.GetFiles(path);
            for (int i = 0; i < contents.Length; i++)
            {
                AddFileToUploadQueue(contents[i], remoteDestination);

            }
            contents = Directory.GetDirectories(path);
            for (int i = 0; i < contents.Length; i++)
            {
                string filePart = StringUtils.ExtractFileFromPath(contents[i], @"\");
                AddFolderToUploadQueue(contents[i], remoteDestination + "/" + filePart);
            }
        }

        public void AddFileToUploadQueue(string localFilename, string remoteDestination)
        {
            if (File.Exists(localFilename))
            {
                queue.Add(remoteDestination, new FtpFileInfo(localFilename, remoteDestination, DirectionTypes.Up, true));
                queue.Add(localFilename, new FtpFileInfo(localFilename, remoteDestination, DirectionTypes.Up, true));
            }
            else
            {
                throw new Exception("Incorrect file path" + localFilename);
            }
        }


        public void RemoveFilesFromUploadQueue(string[] localFileName)
        {
            foreach (string s in localFileName)
            {
                if (queue.ContainsKey(s))
                {
                    queue.Remove(s);
                }
            }
        }

        public void AddFolderToDownloadQueue(string path, string localDestination)
        {
            if (Directory.Exists(localDestination) == false)
            {
                Directory.CreateDirectory(localDestination);
            }

            List<ftpInfo> contents = ftp.browse(path);
            if (contents == null)
                return;
            for (int i = 0; i < contents.Count; i++)
            {
                if (contents[i].FileType == DirectoryEntryTypes.File)
                {
                    AddFileToDownloadQueue(contents[i].Path + "/" + contents[i].Filename, localDestination + @"\" + contents[i].Filename, contents[i].Size);
                }
                else
                {
                    // AddFolderToDownloadQueue(path + "/" + contents[i].Filename, localDestination + @"\" + contents[i].Filename);
                }
            }
        }

        public void AddFileToDownloadQueue(string remotefilename, string localDestination, long Size)
        {
            queue.Add(remotefilename, new FtpFileInfo(remotefilename, localDestination, DirectionTypes.Down, Size));
        }

        public void RemoveFilesFromDownloadQueue(string[] remotefilename)
        {
            foreach (string s in remotefilename)
            {
                if (queue.Contains(s))
                {
                    queue.Remove(s);
                }
                else
                {
                    throw new Exception("File does not exist: " + s);
                }
            }
        }

        //start the processing thread
        public void StartProcessing()
        {
            _threadRunning = true;
            ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadForProcessQueue));
        }

        //stop the processing thread
        public void StopProcessing()
        {
            _threadRunning = false;
        }

        private void ThreadForProcessQueue(object stateInfo)
        {

            try
            {
                while (_threadRunning && queue.Count > 0)
                {
                    //process next queue item
                    object[] keys = new object[queue.Keys.Count];
                    queue.Keys.CopyTo(keys, 0);
                    FtpFileInfo nextitem = (FtpFileInfo)queue[keys[0]]; //process first item in the queue
                    if (nextitem.mkdirFlag)
                    {
                        ftp.CreateRemoteDirectory(nextitem);
                    }
                    else
                    {
                        if (nextitem.direction == DirectionTypes.Down)
                        {
                            ftp.Download(nextitem);
                        }
                        else
                        {
                            ftp.Upload(nextitem);
                        }
                    }
                    //remove item from queue after processing it
                    queue.Remove(nextitem.completeFileName);
                }
            }
            catch (Exception ex)
            {
                ftp.OnStatusChange("Error occured: " + ex.Message, 0, 0);
            }
            finally
            {
                _threadRunning = false;
            }
        }

    }
}
