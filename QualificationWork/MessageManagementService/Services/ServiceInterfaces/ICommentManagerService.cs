using MessageManagementService.Models.Dto;
using ModelLibrary;

namespace MessageManagementService.Services.ServiceInterfaces
{
    public interface ICommentManagerService
    {
        public CommentResponseDto CreateComment(CommentRequestDto commentRequestDto, string token, string group);
        public List<CommentResponseDto> GetComments();
    }
}
