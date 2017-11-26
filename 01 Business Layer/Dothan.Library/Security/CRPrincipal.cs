using System;
using System.Collections.Generic;
using System.Security.Principal;

namespace Dothan.Library.Security
{
    [Serializable()]
    public class CRPrincipal : Dothan.Security.BusinessPrincipalBase
    {
        private CRPrincipal(IIdentity identity) : base(identity) { }

        public static bool Login(string username, string password)
        {
            CRIdentity identity = CRIdentity.GetIdentity(username, password);
            if (identity.IsAuthenticated)
            {
                CRPrincipal principal = new CRPrincipal(identity);
                Dothan.ApplicationContext.User = principal;
            }
            return identity.IsAuthenticated;
        }

        public static void Logout()
        {
            CRIdentity identity = CRIdentity.UnauthenticatedIdentity();
            CRPrincipal principal = new CRPrincipal(identity);
            Dothan.ApplicationContext.User = principal;
        }

        public override bool IsInRole(string role)
        {
            CRIdentity identity = (CRIdentity)this.Identity;
            return identity.IsInRole(role);
        }

    }
}
