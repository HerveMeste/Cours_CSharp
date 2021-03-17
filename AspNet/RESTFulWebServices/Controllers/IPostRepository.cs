using RESTFulWebServices.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RESTFulWebServices.Controllers
{
    public interface IPostRepository
    {
        public Task<List<Post>> GetPostByUserId(string userId);
    }
}