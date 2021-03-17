using Microsoft.AspNetCore.Mvc;
using RESTFulWebServices.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RESTFulWebServices.Controllers
{
    public class PostController : Controller
    {
        private IPostRepository postRepository;
        public PostController (IPostRepository repo)
        {
            postRepository = repo;
        }
        public async Task<IActionResult> Index(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                return View(new List<Post>());
            }
            else
            {
                List<Post> posts = await postRepository.GetPostByUserId(userId);
                return View(posts);
            }
        }
    }
}