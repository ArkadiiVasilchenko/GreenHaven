using IdentityService.Models;
using IdentityService.Models.Dto;
using IdentityService.Services.AuthenticationService.AuthenticationServiceInterfaces;
using IdentityService.Services.JwtProviderService.JwtProviderServiceInterfaces;
using Microsoft.AspNetCore.Identity;

namespace IdentityService.Services.AuthenticationService
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly IJwtProviderService jwtProviderService;

        public AuthenticationService(UserManager<IdentityUser> userManager, IJwtProviderService jwtProviderService)
        {
            this.userManager = userManager;
            this.jwtProviderService = jwtProviderService;
        }

        public async Task<AuthenticationResult> RegisterAsync(UserRegistrationRequestDto requestDto)
        {
            var user_exist = await userManager.FindByEmailAsync(requestDto.Email);

            if (user_exist != null)
            {
                return null;
            }

            var new_user = new IdentityUser()
            {
                Email = requestDto.Email,
                UserName = requestDto.Email
            };

            var is_created = await userManager.CreateAsync(new_user, requestDto.Password);

            if (is_created.Succeeded)
            {
                var token =  jwtProviderService.GenerateJwtToken(new_user);

                return new AuthenticationResult()
                {
                    Result = true,
                    Token = token
                };
            }

            return null;
            
        }

        public async Task<AuthenticationResult> Login(UserLoginRequestDto loginRequest)
        {
            var existing_user = await userManager.FindByEmailAsync(loginRequest.Email);

            if (existing_user == null)
            {
                return null;
            }

            var isCorrect = await userManager.CheckPasswordAsync(existing_user, loginRequest.Password);

            if (!isCorrect)
            {
                return null;
            }

            var token = jwtProviderService.GenerateJwtToken(existing_user);

            return new AuthenticationResult()
            {
                Result = true,
                Token = token
            };

            return null;
        }
    }
}
