using ModelLibrary;
using PostManagementService.Models.Dto;

namespace PostManagementService.Services.PostServices.PostServiceInterfaces
{
    public interface IPostService : IBaseService<Post, string>
    {
        public Task Create(PostRequestDto post);
        public void Update(Post post);
        public List<Post> GetPosts();
        public List<Post> GetPostsByUserId();
    }
}
