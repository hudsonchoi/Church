using System;
using System.Data;
using System.Runtime;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Web.Services.Protocols;
using System.Reflection;

namespace Dothan.Report.RemoteAccess
{
    public class ClientRemoteAccess
    {
        public enum ConnectionTypeOptions { WebServices = 1, TcpRemoting, LocalAccess };
          private static ConnectionTypeOptions _nConnectionType;	// Set at startup when user logs in and selects the connection profile
        public ConnectionTypeOptions nConnectionType
        {
            get { return _nConnectionType; }
            set { _nConnectionType = value; }
        }

        private static string _reportName;
        public string ReportName
        {
            get { return _reportName; }
            set { _reportName = value; }
        }


        private static int _nTCPPort;			// set at startup when user logs in, comes from connection profile, default is 8228
        public int nTCPPort
        {
            get { return _nTCPPort; }
            set { _nTCPPort = value; }
        }

        private static string _cTcpServer;
        public string cTcpServer
        {
            get { return _cTcpServer; }     // this is concatenated with the port...it could be: "tcp://localhost:"
            set { _cTcpServer = value; }   // by the time they're all concatened, it could be "tcp://localhost:8228/CUSTOMERLOADER");
        }

        private static string _cWebServiceURL;	// 
        public string cWebServiceURL
        {
            get { return _cWebServiceURL; }
            set { _cWebServiceURL = value; }
        }


        private static string _cDescription;	// 
        public string cDescription
        {
            get { return _cDescription; }
            set { _cDescription = value; }
        }



        private Type _tInterface;			// set at startup when user logs in, comes from connection profile, default is 8228
        public Type tInterface
        {
            get { return _tInterface; }
            set { _tInterface = value; }
        }



        private string _cServiceName;			// set at startup when user logs in, comes from connection profile, default is 8228
        public string cServiceName
        {
            get { return _cServiceName; }
            set { _cServiceName = value; }
        }



        private SoapHttpClientProtocol _wService;			// set at startup when user logs in, comes from connection profile, default is 8228
        public SoapHttpClientProtocol wService
        {
            get { return _wService; }
            set { _wService = value; }
        }




        public ClientRemoteAccess()
        {
            this.nTCPPort = 8228;

        }

        public bool UsingWebServices()
        {
            if (this.nConnectionType == ConnectionTypeOptions.WebServices)
                return true;
            else
                return false;

        }
        private string cWSPrefix = "w";
        private string cBzPrefix = "bz";

        public object GetAccessObject()
        {

            // Type reference to back-end interface
            Type oInterface = this.tInterface;
            string cServiceName = this.cServiceName;

            // object reference to web service (if used)
            SoapHttpClientProtocol ows = this.wService;

            // Generic back-end object (will be cast to interface)
            object oAccessObject = new object();

            switch (this.nConnectionType)
            {
                case ConnectionTypeOptions.TcpRemoting:

                    // TCP remoting....must create new TCP channel, and then activate
                    // remote object proxy through the channel
                    IChannel[] myIChannelArray = ChannelServices.RegisteredChannels;
                    if (myIChannelArray.Length == 0)
                        ChannelServices.RegisterChannel(new TcpClientChannel());

                    // activate back-end object
                    oAccessObject =
                        Activator.GetObject(oInterface,
                            this.cTcpServer.ToString().Trim() + ":" +
                            this.nTCPPort.ToString().Trim() + "/" + cBzPrefix +  cServiceName);
                    break;

                case ConnectionTypeOptions.WebServices:
                    // set URL of instantiated web service object
                    ows.Url = this.cWebServiceURL.ToString() + "/" + cWSPrefix + cServiceName + ".asmx";

                    ows.Credentials = System.Net.CredentialCache.DefaultCredentials;
                    oAccessObject = ows;
                    break;

                case ConnectionTypeOptions.LocalAccess:
                    // Local access - use Reflection to load DLL
                    System.Reflection.Assembly oDLL = System.Reflection.Assembly.LoadFrom(cServiceName + ".DLL");

                    // Get type reference to class/namespace, create instance
                   
                     Type[] tType = oDLL.GetTypes();

                     foreach (Type info in tType)
                     {
                         if (info.Name == _reportName)
                         {
                             oAccessObject = Activator.CreateInstance(info);
                             break;
                         }
                     }

                    break;


            }

            return oAccessObject;

        }
    }
}
