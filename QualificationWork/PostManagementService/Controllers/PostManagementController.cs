using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using ModelLibrary;
using PostManagementService.Models.Dto;
using PostManagementService.Services.PostServices.PostServiceInterfaces;

namespace PostManagementService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PostManagementController : ControllerBase
    {
        private readonly IPostService postService;

        public PostManagementController(IPostService postService)
        {
            this.postService = postService;
        }

        [HttpPost]
        [Route("CreatePost")]
        public async Task<IActionResult> CreatePost([FromBody] PostRequestDto postDto)
        {
            await postService.Create(postDto);
            return Ok();
        }

        [HttpGet]
        [Route("GetPosts")]
        public List<Post> GetPosts()
        {
            return postService.GetPosts();
        }

        [HttpGet]
        [Route("GetPostsByUser")]
        public List<Post> GetPostsByUserId()
        {
            return postService.GetPostsByUserId();
        }
    }
}