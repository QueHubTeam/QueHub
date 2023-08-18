using QueHub.Service.DTOs.Notifications;

namespace QueHub.Service.Interfaces.Notifications;

public interface ISmsSender
{
    public Task<bool> SendAsync(SmsMessage smsMessage);
}
