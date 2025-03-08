using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimoshStoreAPI;

namespace MyApp.Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribeController : ControllerBase
    {
        private readonly ISubscriptionService _subscriptionService;
        public SubscribeController(ISubscriptionService subscriptionService)
        {
            _subscriptionService = subscriptionService;
        }
        [HttpPost("/api/newsletter/subscribe")]
        public async Task<IActionResult> NewsLetterSubscription([FromQuery]string email)
        {
            var result = await _subscriptionService.NewsLetterSubscriptionAsync(email);
            if(!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.Message);
        }
    }
}