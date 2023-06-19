using IdentityService.Data;
using MessageManagementService.Repositories.CommentRepositories.CommentRepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using ModelLibrary;

namespace MessageManagementService.Repositories.CommentRepositories
{
    public class CommentRepository : BaseRepository<Comment, string>, ICommentRepository
    {
        public CommentRepository(AppDbContext repositoryContext) : base(repositoryContext)
        {
            
        }
        public List<Comment> GetCommentsByPostId(string postId)
        {
            if (postId != null)
            {
                return repositoryContext.Comment.Where(p => p.IdPost == postId).Include(c => c.User).ToList();
            }

            return null;
        }
    }
}
