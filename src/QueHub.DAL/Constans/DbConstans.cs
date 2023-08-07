namespace QueHub.DAL.Constans;

public static class DbConstans
{
    private const string pass = "13I10q06";
    public const string CONNECTION_STRING = "Host=localhost;Port=5432;User Id=postgres;Database=QueryHubDb;"
        + $"Password={pass}";
}
