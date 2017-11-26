using System;
using System.Security.Permissions;

namespace Dothan
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1032:ImplementStandardExceptionConstructors")]
    [Serializable()]
    public class DataPortalException : Exception
    {
        private object _businessObject;
        private string _innerStackTrace;

    
        public object BusinessObject
        {
            get { return _businessObject; }
        }

        public Exception BusinessException
        {
            get
            {
                return this.InnerException.InnerException;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1305:SpecifyIFormatProvider", MessageId = "System.String.Format(System.String,System.Object,System.Object,System.Object)")]
        public override string StackTrace
        {
            get { return String.Format("{0}{1}{2}", _innerStackTrace, Environment.NewLine, base.StackTrace); }
        }

        public DataPortalException(string message, object businessObject)
            : base(message)
        {
            _innerStackTrace = String.Empty;
            _businessObject = businessObject;
        }

        public DataPortalException(string message, Exception ex, object businessObject)
            : base(message, ex)
        {
            _innerStackTrace = ex.StackTrace;
            _businessObject = businessObject;
        }

        protected DataPortalException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {
            _businessObject = info.GetValue("_businessObject", typeof(object));
            _innerStackTrace = info.GetString("_innerStackTrace");
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")]
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
        [SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.SerializationFormatter)]
        public override void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("_businessObject", _businessObject);
            info.AddValue("_innerStackTrace", _innerStackTrace);
        }
    }
}
