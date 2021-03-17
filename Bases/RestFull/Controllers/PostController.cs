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

    public class PostController : Controller
    {
        private readonly IHttpClientFactory _client;
        private string _domain = "https://jsonplaceholder.typicode.com/";

        public PostController(IHttpClientFactory client)
        {
            _client = client;
        }

        public async Task<IActionResult> GetPostbyID(string userId)
        {
            if (String.IsNullOrEmpty(userId))
            {
                return View();
            }
            else
            {
                List<Post> postByID = new List<Post>();
                HttpClient httpClient = _client.CreateClient();
                string userToString = await httpClient.GetStringAsync(_domain + "posts?" + "userId" + userId);
                List<Post> listPosts = JsonConvert.DeserializeObject<List<Post>>(userToString);
                foreach(Post post in listPosts)
                {
                    if (post.userId == Convert.ToInt32(userId))
                    {
                        postByID.Add(post);
                    }
                }
                return View(postByID);

            }
        }
    }
}
