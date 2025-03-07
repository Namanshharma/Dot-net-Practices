using System.Runtime.Serialization;

namespace CRUD_DEMO.Middlewares;
public class CustomException : Exception
{
    public CustomException() { }
    public CustomException(string? message) : base(message)
    {
        // here we can log this specific message into our logger
    }
    public CustomException(string? message, Exception? innerException) : base(message, innerException) { }
    protected CustomException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}
