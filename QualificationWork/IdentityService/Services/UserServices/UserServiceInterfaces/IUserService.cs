using Microsoft.AspNetCore.Identity;
using ModelLibrary;

namespace IdentityService.Services.UserServices.UserServiceInterfaces
{
    public interface IUserService : IBaseService<IdentityUser, string>
    {
       
    }
}
