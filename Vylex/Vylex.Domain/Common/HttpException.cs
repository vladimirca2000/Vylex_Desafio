using System.Net;

namespace Vylex.Domain.Common;

public class HttpException : Exception
{
    public HttpStatusCode StatusCode { get; set; }

    public HttpException(HttpStatusCode statusCode, string message) : base(message)
    {
        StatusCode = statusCode;
    }
}
