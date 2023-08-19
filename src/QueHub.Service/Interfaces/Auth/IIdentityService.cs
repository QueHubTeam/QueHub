namespace QueHub.Service.Interfaces.Auth;

public interface IIdentityService
{
    public long Id { get; }

    public string FirstName { get; }

    public string LastName { get; }

    public string UserName { get; }

    public string Email { get; }

}
