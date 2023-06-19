using MessageManagementService.Models.Dto;
using MessageManagementService.Repositories.CommentRepositories.CommentRepositoryInterfaces;
using MessageManagementService.Services.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using ModelLibrary;

namespace MessageManagementService.Services
{
    public class CommentManagerService : ICommentManagerService
    {
        private readonly IUserProviderService userProviderService;
        private readonly ICommentRepository commentRepository;
        private readonly IHttpContextAccessor httpContextAccessor;

        public CommentManagerService(IUserProviderService userProviderService,
                                        ICommentRepository commentRepository,
                                        IHttpContextAccessor httpContextAccessor)
        {
            this.userProviderService = userProviderService;
            this.commentRepository = commentRepository;
            this.httpContextAccessor = httpContextAccessor;
        }

        public CommentResponseDto CreateComment(CommentRequestDto commentRequestDto, string token, string group)
        {
            var user = userProviderService.GetUserAsync(token).Result;
            var comment = new Comment(commentRequestDto.Text, group, user.Id);
            
            commentRepository.Create(comment);

            CommentResponseDto result = new CommentResponseDto(user.UserName, comment.Text);

            return result;
        }

        public List<CommentResponseDto> GetComments()
        {
            HttpContext httpContext = httpContextAccessor.HttpContext;

            var postId = httpContext.Request.Headers["PostId"];

            var comments = commentRepository.GetCommentsByPostId(postId);

            List<CommentResponseDto> response = new List<CommentResponseDto>();
           

            foreach (var c in comments)
            {
                CommentResponseDto comment = new CommentResponseDto();
                comment.Author = c.User.UserName;
                comment.Text = c.Text;
                response.Add(comment);
            }

            return response;
        }
    }
}
