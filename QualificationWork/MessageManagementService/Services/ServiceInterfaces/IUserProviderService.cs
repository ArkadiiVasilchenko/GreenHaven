using Microsoft.AspNetCore.Identity;

namespace MessageManagementService.Services.ServiceInterfaces
{
    public interface IUserProviderService
    {
        public Task<IdentityUser> GetUserAsync(string token);
    }
}
