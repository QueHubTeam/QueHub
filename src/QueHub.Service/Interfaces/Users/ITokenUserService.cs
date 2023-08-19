using QueHub.Domain.Entity.User;

namespace QueHub.Service.Interfaces.Persons;

public interface ITokenUserService
{
    public string GenerateToken(UserEntity user);
}
