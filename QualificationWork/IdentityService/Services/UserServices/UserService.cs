using IdentityService.Repositories;
using IdentityService.Repositories.UserRepositories.UserRepositoryInterfaces;
using IdentityService.Services.UserServices.UserServiceInterfaces;
using Microsoft.AspNetCore.Identity;
using ModelLibrary;
using System.IdentityModel.Tokens.Jwt;

namespace IdentityService.Services.UserServices
{
    public class UserService : BaseService<IdentityUser, string>, IUserService
    {
        private readonly IBaseRepository<IdentityUser, string> repository;
        IUserRepository userRepository;

        public UserService(IBaseRepository<IdentityUser, string> repository,
                            IUserRepository userRepository) : base(repository)
        {
            this.repository = repository;
            this.userRepository = userRepository;
        }
    }
}
