namespace Test_WebApi.Repository
{
    public interface IJwtAuth
    {
        string Authentication(string username, string password);
    }
}
