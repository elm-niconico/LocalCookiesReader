using System.Runtime.Serialization;

namespace ExtractLocalCookie.Exceptions;

[Serializable]
public class FailedExtractEncryptedKeyException : Exception
{
    public FailedExtractEncryptedKeyException(string message) : base(message)
    {
    }


    public FailedExtractEncryptedKeyException(SerializationInfo info, StreamingContext context
    ) : base(info, context)
    {
    }
}