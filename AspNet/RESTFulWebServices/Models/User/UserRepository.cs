using Newtonsoft.Json;
using RESTFulWebServices.Controllers;
using System.Net.Http;
using System.Threading.Tasks;

namespace RESTFulWebServices.Models
{
    public class UserRepository : IUserRepository
    {
        private readonly IHttpClientFactory _client;
        private string _baseAddress = "https://jsonplaceholder.typicode.com/";
        public UserRepository(IHttpClientFactory client)
        {
            _client = client;
        }
        public async Task<User> GetUserById(string id)
        {
            HttpClient httpClient = _client.CreateClient();
            string result = await httpClient.GetStringAsync(_baseAddress + "users/" + id);
            User users = JsonConvert.DeserializeObject<User>(result);
            return users;
        }
    }
}
