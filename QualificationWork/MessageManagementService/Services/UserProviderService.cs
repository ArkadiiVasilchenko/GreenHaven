using MessageManagementService.Services.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using ModelLibrary;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;

namespace MessageManagementService.Services
{
    public class UserProviderService : IUserProviderService
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        public UserProviderService(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }


        public async Task<IdentityUser> GetUserAsync(string token)
        {
            HttpClient httpClient = new HttpClient();

            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadToken(token) as JwtSecurityToken;
            var userId = jwtToken.Claims.FirstOrDefault(claim => claim.Type == "Id")?.Value;

            var response = await httpClient.GetAsync($"https://localhost:7166/api/User/GetUser/{userId}");

            string responseContent = await response.Content.ReadAsStringAsync();
            IdentityUser user = JsonConvert.DeserializeObject<IdentityUser>(responseContent);

            return user;
        }   
    }
}

