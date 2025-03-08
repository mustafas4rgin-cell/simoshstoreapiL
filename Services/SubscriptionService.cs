using SimoshStore;

namespace SimoshStoreAPI;

public class SubscriptionService : ISubscriptionService
{
    private readonly IEmailService _emailService;

    public SubscriptionService(IEmailService emailService)
    {
        _emailService = emailService;
    }
    public async Task<IServiceResult> NewsLetterSubscriptionAsync(string email)
    {
        await _emailService.SendEmailAsync(email, "Newsletter Subscription", "You have successfully subscribed to our newsletter");
        await _emailService.SendEmailAsync("simoshstoreco@gmail.com","New Subscriber", $"New subscriber with email: {email}");
        return new ServiceResult(true, "Subscription successful");
    }
}

public interface ISubscriptionService
{
    Task<IServiceResult> NewsLetterSubscriptionAsync(string email);
}