using IdentityService.Models;
using IdentityService.Models.Dto;

namespace IdentityService.Services.AuthenticationService.AuthenticationServiceInterfaces
{
    public interface IAuthenticationService
    {
        public Task<AuthenticationResult> RegisterAsync(UserRegistrationRequestDto requestDto);
        public Task<AuthenticationResult> Login(UserLoginRequestDto loginRequest);
    }
}
