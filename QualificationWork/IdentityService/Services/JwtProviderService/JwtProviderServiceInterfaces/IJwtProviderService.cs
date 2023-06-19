using Microsoft.AspNetCore.Identity;

namespace IdentityService.Services.JwtProviderService.JwtProviderServiceInterfaces
{
    public interface IJwtProviderService
    {
        public string GenerateJwtToken(IdentityUser user);
    }
}
