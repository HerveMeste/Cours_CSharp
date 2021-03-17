using Newtonsoft.Json;
using RESTFulWebServices.Controllers;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace RESTFulWebServices.Models
{
    public class PostRepository : IPostRepository
    {
        private readonly IHttpClientFactory _client;
        private string _baseAddress = "https://jsonplaceholder.typicode.com/";
        public PostRepository(IHttpClientFactory client)
        {
            _client = client;
        }
        public async Task<List<Post>> GetPostByUserId(string userId)
        {
            HttpClient httpClient = _client.CreateClient();
            string result = await httpClient.GetStringAsync(_baseAddress + "posts?" + "userId=" + userId);
            List<Post> posts = JsonConvert.DeserializeObject<List<Post>>(result);
            return posts;
        }
    }
}
