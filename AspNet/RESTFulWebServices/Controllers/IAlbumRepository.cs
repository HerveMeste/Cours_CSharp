using RESTFulWebServices.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RESTFulWebServices.Controllers
{
    public interface IAlbumRepository
    {
        public Task<List<Album>> GetAlbumByUserId(string userId);
    }
}
