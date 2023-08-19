using QueHub.Service.DTOs.Notifications;
namespace QueHub.Service.Interfaces.Notifications;

public interface IMailSender
{
    public Task<bool> SendAsync(EmailMessage message);
}
