using SimoshStore;

namespace SimoshStoreAPI;

public interface IAuthService
{
    Task<IServiceResult> ForgotPasswordAsync(string email);
    Task<IServiceResult> ResetPasswordAsync(ResetPasswordDTO dto);
}
