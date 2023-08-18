using System.Net;

namespace QueHub.WebApi.Models;

public class Response
{
    public HttpStatusCode Code { get; set; }

    public string Message { get; set; }
    
    public object Data { get; set; }
}
