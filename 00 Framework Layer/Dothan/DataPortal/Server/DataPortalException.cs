using System;
using System.Collections.Generic;
using System.Text;

namespace Dothan.Server
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1032:ImplementStandardExceptionConstructors")]
    [Serializable()]
    public class DataPortalException : Exception
    {
        private DataPortalResult _result;
        private string _innerStackTrace;

     
        public DataPortalResult Result
        {
            get { return _result; }
        }

        
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1305:SpecifyIFormatProvider", MessageId = "System.String.Format(System.String,System.Object,System.Object,System.Object)")]
        public override string StackTrace
        {
            get
            {
                return String.Format("{0}{1}{2}",
                    _innerStackTrace, Environment.NewLine, base.StackTrace);
            }
        }

        public DataPortalException(
          string message, Exception ex, DataPortalResult result)
            : base(message, ex)
        {
            _innerStackTrace = ex.StackTrace;
            _result = result;
        }

        protected DataPortalException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {
            _result = (DataPortalResult)info.GetValue(
              "_result", typeof(DataPortalResult));
            _innerStackTrace = info.GetString("_innerStackTrace");
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")]
        [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.LinkDemand, Flags = System.Security.Permissions.SecurityPermissionFlag.SerializationFormatter)]
        [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Demand, Flags = System.Security.Permissions.SecurityPermissionFlag.SerializationFormatter)]
        public override void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("_result", _result);
            info.AddValue("_innerStackTrace", _innerStackTrace);
        }
    }
}
