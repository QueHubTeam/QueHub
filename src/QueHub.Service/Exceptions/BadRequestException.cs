using System.Net;

namespace QueHub.Service.Exceptions;

public class BadRequestException : Exception
{
    public HttpStatusCode StatusCode { get; } = HttpStatusCode.BadRequest;
    
    public string TitleMessage { get; protected set; } = string.Empty; 
}
