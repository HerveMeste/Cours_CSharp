using Microsoft.AspNetCore.Mvc;
using RESTFulWebServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTFulWebServices.Controllers
{
    public class CommentController : Controller
    {
        private IPostRepository postRepository;
        private ICommentRepository commentRepository;
        public CommentController (IPostRepository postRepository, ICommentRepository commentRepository)
        {
            this.postRepository = postRepository;
            this.commentRepository = commentRepository;
        }
        public async Task<IActionResult> Index(string userId)
        {
            if (String.IsNullOrEmpty(userId))
            {
                return View(new List<Comment>());
            }
            else
            {
                List<Post> posts = await postRepository.GetPostByUserId(userId);
                List<int> postIds = posts.Select(x => x.id).ToList();
                List<Comment> comments = await commentRepository.GetCommentByPostIds(postIds);
                return View(comments);
            }
        }
    }
}
