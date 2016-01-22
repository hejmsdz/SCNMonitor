using System;
using System.Runtime.Serialization;

namespace SCNMonitor
{
    [Serializable]
    class TransferCheckException : Exception
    {
        public TransferCheckException()
        { }

        public TransferCheckException(string message) : base(message)
        { }

        public TransferCheckException(string message, Exception innerException) : base (message, innerException)
        { }

        protected TransferCheckException(SerializationInfo info, StreamingContext context) : base (info, context)
        { }
    }
}
