using ModelLibrary;

namespace PostManagementService.Repositories.PostRepositories.PostRepositoryInterfaces
{
    public interface IPostRepository : IBaseRepository<Post, string>
    {
        public List<Post> GetPostsByUserId(string userId);
    }
}
