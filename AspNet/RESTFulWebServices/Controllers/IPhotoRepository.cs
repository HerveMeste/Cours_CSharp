using RESTFulWebServices.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RESTFulWebServices.Controllers
{
    public interface IPhotoRepository
    {
        public Task<List<Photo>> GetPhotoByAlbumIds(List<int> albumIds);
    }
}