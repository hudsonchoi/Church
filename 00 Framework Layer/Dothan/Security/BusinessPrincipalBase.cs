using System;
using System.Collections.Generic;
using System.Security.Principal;

namespace Dothan.Security
{
    [Serializable()]
    public class BusinessPrincipalBase : IPrincipal
    {
        private IIdentity _identity;
     
        public virtual IIdentity Identity
        {
            get { return _identity; }
        }
        /// <summary>
        /// Returns a value indicating whether the
        /// user is in a given role.
        /// </summary>
        /// <param name="role">Name of the role.</param>
        public virtual bool IsInRole(string role)
        {
            return false;
        }

        protected BusinessPrincipalBase(IIdentity identity)
        {
            _identity = identity;
        }
    }
}
