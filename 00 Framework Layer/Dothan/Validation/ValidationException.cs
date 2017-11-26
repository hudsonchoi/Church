using System;


namespace Dothan.Validation
{
    [Serializable()]
    public class ValidationException : Exception
    {

        public ValidationException()
        {

        }

        public ValidationException(string message)
            : base(message)
        {

        }

  
        public ValidationException(string message, Exception innerException)
            : base(message, innerException)
        {

        }

        protected ValidationException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {

        }
    }
}
