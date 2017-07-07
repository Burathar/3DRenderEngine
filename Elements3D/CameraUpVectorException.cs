using System;
using System.Runtime.Serialization;

namespace Elements3D
{
    [Serializable]
    internal class CameraUpVectorException : Exception
    {
        public CameraUpVectorException()
        {
        }

        public CameraUpVectorException(string message) : base(message)
        {
        }

        public CameraUpVectorException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CameraUpVectorException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}