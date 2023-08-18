using System.Net;

namespace QueHub.Service.Exceptions;

public class AlreadyExistsException : Exception
{
    public HttpStatusCode StatusCode { get; } = HttpStatusCode.Conflict;

    public string TitleMessage { get; protected set; } = String.Empty;
}