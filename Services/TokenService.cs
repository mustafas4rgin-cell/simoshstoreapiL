namespace SimoshStoreAPI;

public class TokenService : ITokenService
{
    public string GenerateToken()
    {
        return Guid.NewGuid().ToString();
    }
}
