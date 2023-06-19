using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using ModelLibrary;
using Newtonsoft.Json;
using PostManagementService.Models.Dto;
using PostManagementService.Repositories;
using PostManagementService.Repositories.PostRepositories.PostRepositoryInterfaces;
using PostManagementService.Services.PostServices.PostServiceInterfaces;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;

namespace PostManagementService.Services.PostServices
{
    public class PostService : BaseService<Post, string>, IPostService
    {
        private readonly IBaseRepository<Post, string> repository;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IPostRepository postRepository;

        public PostService(IBaseRepository<Post, string> repository,
                            IPostRepository postRepository,
                            IHttpContextAccessor httpContextAccessor) : base(repository)
        {
            this.repository = repository;
            this.postRepository = postRepository;
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task Create(PostRequestDto postDto)
        {
            Post post = null;
            post = await PostCreation(postDto);
            repository.Create(post);
        }

        public void Update(Post post)
        {
            repository.Update(post);
        }

        public List<Post> GetPosts()
        {
            var posts = postRepository.Read();
            var sortedPosts = posts.OrderByDescending(p => p.CreatingDate).ToList();

            return sortedPosts;
        }

        public List<Post> GetPostsByUserId()
        {
            var posts = postRepository.GetPostsByUserId(GetUser().Result.Id);
            var sortedPosts = posts.OrderByDescending(p => p.CreatingDate).ToList();

            return sortedPosts;
        }

        private async Task<Post> PostCreation(PostRequestDto postDto)
        {
            IdentityUser user = await GetUser();
            Post post = new Post(postDto.Title, postDto.Text, user.Id);
            
            return post;
        }

        private async Task<IdentityUser> GetUser()
        {
            IdentityUser user = null;
            HttpClient httpClient = new HttpClient();
            HttpContext httpContext = httpContextAccessor.HttpContext;

            var token = httpContext.Request.Headers["Token"];
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadToken(token) as JwtSecurityToken;

            var userId = jwtToken.Claims.FirstOrDefault(claim => claim.Type == "Id")?.Value;

            if (userId != null)
            {
                var response = await httpClient.GetAsync($"https://localhost:7166/api/User/GetUser/{userId}");
                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    user = JsonConvert.DeserializeObject<IdentityUser>(responseContent);
                }
            }
            return user;
        }
    }
}