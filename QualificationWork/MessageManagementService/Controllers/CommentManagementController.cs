using MessageManagementService.Models.Dto;
using MessageManagementService.Services.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PostManagementService.Models.Dto;
using PostManagementService.Services.PostServices.PostServiceInterfaces;

namespace MessageManagementService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class CommentManagementController : ControllerBase
    {
        private readonly ICommentManagerService commentManagerService;

        public CommentManagementController(ICommentManagerService commentManagerService)
        {
            this.commentManagerService = commentManagerService;
        }

        [HttpGet]
        [Route("GetComments")]
        public List<CommentResponseDto> GetComments()
        {
            var response = commentManagerService.GetComments();
            return response;
        }
    }
}
