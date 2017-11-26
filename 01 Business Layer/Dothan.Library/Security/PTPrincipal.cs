using System;
using System.Collections.Generic;
using System.Security.Principal;

namespace Dothan.Library.Security
{
    [Serializable()]
    public class PTPrincipal : Dothan.Security.BusinessPrincipalBase
    {
        private PTPrincipal(IIdentity identity) : base(identity) { }

        public string UserName
        {
            get
            {
                PTIdentity identity = (PTIdentity)this.Identity;
                return identity.UserName;
            }
        }
        public int ID
        {
            get
            {
                PTIdentity identity = (PTIdentity)this.Identity;
                return identity.Id;
            }
        }
       
        public static bool Login(string username, string password)
        {
            PTIdentity identity = PTIdentity.GetIdentity(username, password);
            if (identity.IsAuthenticated)
            {
                PTPrincipal principal = new PTPrincipal(identity);
                Dothan.ApplicationContext.User = principal;
            }
            return identity.IsAuthenticated;
        }

        public static void Logout()
        {
            PTIdentity identity = PTIdentity.UnauthenticatedIdentity();
            PTPrincipal principal = new PTPrincipal(identity);
            Dothan.ApplicationContext.User = principal;
        }

        public override bool IsInRole(string role)
        {
            PTIdentity identity = (PTIdentity)this.Identity;
            return identity.IsInRole(role);
        }

 
     
    }
}
