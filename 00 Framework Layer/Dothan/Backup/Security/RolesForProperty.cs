using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.ComponentModel;

namespace Dothan.Security
{
    [Serializable()]
    internal class RolesForProperty
    {
        private List<string> _readAllowed = new List<string>();
        private List<string> _readDenied = new List<string>();
        private List<string> _writeAllowed = new List<string>();
        private List<string> _writeDenied = new List<string>();

      
        public List<string> ReadAllowed
        {
            get { return _readAllowed; }
        }

        public List<string> ReadDenied
        {
            get { return _readDenied; }
        }

     
        public List<string> WriteAllowed
        {
            get { return _writeAllowed; }
        }

       
        public List<string> WriteDenied
        {
            get { return _writeDenied; }
        }

    
        public bool IsReadAllowed(IPrincipal principal)
        {
            foreach (string role in ReadAllowed)
                if (principal.IsInRole(role))
                    return true;
            return false;
        }

        public bool IsReadDenied(IPrincipal principal)
        {
            foreach (string role in ReadDenied)
                if (principal.IsInRole(role))
                    return true;
            return false;
        }

   
        public bool IsWriteAllowed(IPrincipal principal)
        {
            foreach (string role in WriteAllowed)
                if (principal.IsInRole(role))
                    return true;
            return false;
        }

    
        public bool IsWriteDenied(IPrincipal principal)
        {
            foreach (string role in WriteDenied)
                if (principal.IsInRole(role))
                    return true;
            return false;
        }
    }
}
