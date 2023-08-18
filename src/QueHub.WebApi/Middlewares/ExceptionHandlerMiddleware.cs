using QueHub.Service.Exceptions.Answers;
using QueHub.Service.Exceptions.Questions;
using QueHub.Service.Exceptions.Users;
using QueHub.WebApi.Models;
using System.Net;

namespace QueHub.WebApi.Middlewares;

public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate next;
    private readonly ILogger<ExceptionHandlerMiddleware> logger;

    public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
    {
        this.next = next;
        this.logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (UserAlreadyExistsException exception)
        {
            context.Response.StatusCode = (int)exception.StatusCode;
            await context.Response.WriteAsJsonAsync(new Response
            {
                Code = exception.StatusCode,
                Message = exception.TitleMessage
            });
        }
        catch (UserNotFoundException exception)
        {
            context.Response.StatusCode = (int)exception.StatusCode;
            await context.Response.WriteAsJsonAsync(new Response
            {
                Code = exception.StatusCode,
                Message = exception.TitleMessage
            });
        }
        catch (QuestionNotFoundException exception)
        {
            context.Response.StatusCode = (int)exception.StatusCode;
            await context.Response.WriteAsJsonAsync(new Response
            {
                Code = exception.StatusCode,
                Message = exception.TitleMessage
            });
        }
        catch (Exception exception)
        {
            this.logger.LogError($"{exception}\n\n");
            context.Response.StatusCode = 500;
            await context.Response.WriteAsJsonAsync(new Response
            {
                Code = HttpStatusCode.InternalServerError,
                Message = exception.Message
            });
        }
    }
}