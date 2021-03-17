using Newtonsoft.Json;
using RESTFulWebServices.Controllers;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace RESTFulWebServices.Models
{
    public class AlbumRepository : IAlbumRepository
    {
        private readonly IHttpClientFactory _client;
        private string _baseAddress = "https://jsonplaceholder.typicode.com/";

        public AlbumRepository(IHttpClientFactory client)
        {
            _client = client;
        }
        public async Task<List<Album>> GetAlbumByUserId(string userId)
        {
            HttpClient httpClient = _client.CreateClient();
            string result = await httpClient.GetStringAsync(_baseAddress + "albums?" + "userId=" + userId);
            List<Album> albums = JsonConvert.DeserializeObject<List<Album>>(result);
            return albums;
        }
    }
}
