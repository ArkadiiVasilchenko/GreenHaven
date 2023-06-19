using IdentityService.Data;
using IdentityService.Repositories.UserRepositories.UserRepositoryInterfaces;
using Microsoft.AspNetCore.Identity;
using ModelLibrary;

namespace IdentityService.Repositories.UserRepositories
{
    public class UserRepository : BaseRepository<IdentityUser, string>, IUserRepository
    {
        public UserRepository(AppDbContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
