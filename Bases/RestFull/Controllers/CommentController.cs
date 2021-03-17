using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestFull.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace RestFull.Controllers
{
    public class CommentController : Controller
    {
        private readonly IHttpClientFactory _client;
        private string _domain = "https://jsonplaceholder.typicode.com/";

        public CommentController(IHttpClientFactory client)
        {
            _client = client;
        }
        public async Task<IActionResult> PostId(string userId)
        {
            if (String.IsNullOrEmpty(userId))
            {
                return View();
            }
            else
            {
                HttpClient httpClient = _client.CreateClient();
                string userToString = await httpClient.GetStringAsync(_domain + "posts?" + "userId=" + userId);
                List<Post> listPosts = JsonConvert.DeserializeObject<List<Post>>(userToString);

                List<Comment> comments = new List<Comment>();
                foreach (Post post in listPosts)
                {
                    //string id = Convert.ToString(post.id);
                    string commentToString = await httpClient.GetStringAsync(_domain + "comments?" + "postId=" + post.id);
                    List<Comment> commentToJson = JsonConvert.DeserializeObject<List<Comment>>(commentToString);
                    foreach(Comment comment in commentToJson)
                    {
                        comments.Add(comment);
                    }
                }
                return View(comments);

            }
        }
    }
}
