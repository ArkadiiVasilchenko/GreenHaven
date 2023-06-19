using IdentityService.Data;
using Microsoft.EntityFrameworkCore;
using ModelLibrary;
using PostManagementService.Repositories.PostRepositories.PostRepositoryInterfaces;

namespace PostManagementService.Repositories.PostRepositories
{
    public class PostRepository : BaseRepository<Post, string>, IPostRepository
    {
        public PostRepository(AppDbContext repositoryContext) : base(repositoryContext)
        {
            
        }

        public List<Post> GetPostsByUserId(string userId)
        {
            if(userId != null)
            {
                return repositoryContext.Post.Where(p => p.IdUser == userId).ToList();
            }
            return null;
        }
    }
}
