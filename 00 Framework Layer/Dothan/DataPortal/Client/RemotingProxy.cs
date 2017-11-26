using System;
using System.Configuration;
using System.Collections;
using System.Threading;
using System.Reflection;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;

namespace Dothan.DataPortalClient
{
    public class RemotingProxy : DataPortalClient.IDataPortalProxy
    {
        #region Configure Remoting

      
        static RemotingProxy()
        {
            
            Hashtable properties = new Hashtable();
            properties["name"] = "HttpBinary";

            if (ApplicationContext.AuthenticationType == "Windows")
            {
                
                properties["useDefaultCredentials"] = true;
            }

            BinaryClientFormatterSinkProvider
              formatter = new BinaryClientFormatterSinkProvider();
            HttpChannel channel = new HttpChannel(properties, formatter, null);
            ChannelServices.RegisterChannel(channel, EncryptChannel);
        }

        private static bool EncryptChannel
        {
            get
            {
                bool encrypt =
                  (ConfigurationManager.AppSettings["DothanEncryptRemoting"] == "true");
                return encrypt;
            }
        }

        #endregion

        private Server.IDataPortalServer _portal;

        private Server.IDataPortalServer Portal
        {
            get
            {
                if (_portal == null)
                    _portal = (Server.IDataPortalServer)Activator.GetObject(
                      typeof(Server.Hosts.RemotingPortal),
                        ApplicationContext.DataPortalUrl.ToString());
                return _portal;
            }
        }

       
        public Server.DataPortalResult Create(
          Type objectType, object criteria, Server.DataPortalContext context)
        {
            return Portal.Create(objectType, criteria, context);
        }

   
        public Server.DataPortalResult Fetch(object criteria, Server.DataPortalContext context)
        {
            return Portal.Fetch(criteria, context);
        }

      
        public Server.DataPortalResult Update(object obj, Server.DataPortalContext context)
        {
            return Portal.Update(obj, context);
        }

 
        public Server.DataPortalResult Delete(object criteria, Server.DataPortalContext context)
        {
            return Portal.Delete(criteria, context);
        }

       
        public bool IsServerRemote
        {
            get { return true; }
        }
    }


}
