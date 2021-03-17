using Newtonsoft.Json;
using RESTFulWebServices.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace RESTFulWebServices.Controllers
{
    internal class PhotoRepository : IPhotoRepository
    {
        private readonly IHttpClientFactory _client;
        private string _baseAddress = "https://jsonplaceholder.typicode.com/";
        public PhotoRepository(IHttpClientFactory client)
        {
            _client = client;
        }
        public async Task<List<Photo>> GetPhotoByAlbumIds(List<int> albumIds)
        {
            HttpClient httpClient = _client.CreateClient();
            List<string> listQueryParam = albumIds.Select(id => "albumId=" + id).ToList();
            string uniqueQueryParam = string.Join("&", listQueryParam);
            string result = await httpClient.GetStringAsync(_baseAddress + "photos?" + uniqueQueryParam);
            List<Photo> photoToJson = JsonConvert.DeserializeObject<List<Photo>>(result);
            return photoToJson;
        }
    }
}