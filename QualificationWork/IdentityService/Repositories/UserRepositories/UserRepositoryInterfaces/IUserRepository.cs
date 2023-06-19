using Microsoft.AspNetCore.Identity;
using ModelLibrary;

namespace IdentityService.Repositories.UserRepositories.UserRepositoryInterfaces
{
    public interface IUserRepository : IBaseRepository<IdentityUser, string>
    {

    }
}
