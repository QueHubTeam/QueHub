using System.Net;

namespace QueHub.Domain.Exceptions;

public class BadRequestException : Exception
{
    public HttpStatusCode StatusCode { get; } = HttpStatusCode.BadRequest;
    
    public string TitleMessage { get; protected set; } = string.Empty; 
}
