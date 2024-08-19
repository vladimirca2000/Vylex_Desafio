using System.Net;

namespace Vylex.Domain.DTOs.Base;

public class HttpException : Exception
{
    public HttpStatusCode StatusCode { get; set; }

    public HttpException(HttpStatusCode statusCode, string message) : base(message)
    {
        StatusCode = statusCode;
    }
}
