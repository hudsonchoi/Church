using System;

namespace Dothan.DataPortalClient
{
    public interface IDataPortalProxy : Server.IDataPortalServer
    {
        bool IsServerRemote { get; }
    }
}
