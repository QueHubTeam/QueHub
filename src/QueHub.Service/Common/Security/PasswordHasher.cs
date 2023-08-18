namespace QueHub.Service.Common.Security;

public class PasswordHasher
{
    public static (string Hash, string Salt) Hash(string password)
    {
        string salt = Guid.NewGuid().ToString();
        string hash = BCrypt.Net.BCrypt.HashPassword(password + salt);
        return (hash, salt);
    }

    public static bool Verify(string password, string hash, string salt)
    {
        return BCrypt.Net.BCrypt.Verify(password + salt, hash);
    }
}
