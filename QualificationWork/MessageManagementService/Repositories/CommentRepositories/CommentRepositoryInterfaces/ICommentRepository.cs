using ModelLibrary;

namespace MessageManagementService.Repositories.CommentRepositories.CommentRepositoryInterfaces
{
    public interface ICommentRepository : IBaseRepository<Comment, string>
    {
        public List<Comment> GetCommentsByPostId(string postId);
    }
}
