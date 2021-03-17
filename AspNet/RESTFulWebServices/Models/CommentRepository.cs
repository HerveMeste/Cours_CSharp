using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace RESTFulWebServices.Models
{
    public class CommentRepository : ICommentRepository
    {
        private readonly IHttpClientFactory _client;
        private string _baseAddress = "https://jsonplaceholder.typicode.com/";
        public CommentRepository(IHttpClientFactory client)
        {
            _client = client;
        }
        public async Task<List<Comment>> GetCommentByPostIds(List<int> postIds)
        {
            HttpClient httpClient = _client.CreateClient();
            // [1, 2, 3]
            // [postId=1, postId=2, postId=3]
            List<string> listQueryParam = postIds.Select(id => "postId="+ id).ToList();
            // postId=1&postId=2&postId=3
            string uniqueQueryParam = string.Join("&", listQueryParam);
            // comments?postId=1&postId=2&postId=3
            string result = await httpClient.GetStringAsync(_baseAddress + "comments?" + uniqueQueryParam);
            List<Comment> commentToJson = JsonConvert.DeserializeObject<List<Comment>>(result);
            return commentToJson;
        }
    }
}
