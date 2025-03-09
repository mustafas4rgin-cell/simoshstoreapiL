using App.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SimoshStore;

namespace SimoshStoreAPI;

public class AuthService : IAuthService
{
    private readonly IDataRepository dataRepository;
    private readonly IUserService userService;
    private readonly IEmailService emailService;
    private readonly ITokenService tokenService;
    public AuthService(IEmailService emailService, ITokenService tokenService, IUserService userService, IDataRepository dataRepository)
    {
        this.emailService = emailService;
        this.tokenService = tokenService;
        this.userService = userService;
        this.dataRepository = dataRepository;
    }
    public async Task<IServiceResult> ResetPasswordAsync(ResetPasswordDTO dto)
    {
        var user = await dataRepository.GetAll<UserEntity>().Where(x => x.ResetToken == dto.Token && x.ResetTokenExpires > DateTime.UtcNow).FirstOrDefaultAsync();

        if (user == null)
        {
            return new ServiceResult(false, "User not found.");
        }

        HashingHelper.CreatePasswordHash(dto.Password, out byte[] passwordHash, out byte[] passwordSalt);
        user.PasswordHash = passwordHash;
        user.PasswordSalt = passwordSalt;
        user.ResetToken = string.Empty;
        user.ResetTokenExpires = DateTime.UtcNow;

        await dataRepository.UpdateAsync(user);
        return new ServiceResult(true,"Password reset successfully.");
    }
    public async Task<IServiceResult> ForgotPasswordAsync(string email)
    {
        UserEntity user;
        try{
            user = await userService.GetUserByEmailAsync(email);
        }
        catch(Exception ex)
        {
            return new ServiceResult(false,ex.Message);
        }        

        string token = tokenService.GenerateToken();

        user.ResetToken = token;
        user.ResetTokenExpires = DateTime.UtcNow.AddMinutes(30);
        await dataRepository.UpdateAsync(user);

        var resetLink = $"https://www.simosh.shop/Auth/ResetPassword?token={token}";

        await emailService.SendEmailAsync(user.Email, "Reset Password", resetLink);

        return new ServiceResult(true, "Confirm email sent.");

    }

}
