using System.Threading.Tasks;
using RESTFulWebServices.Models;

namespace RESTFulWebServices.Controllers
{
    public interface IUserRepository
    {
        public Task<User> GetUserById(string id);
    }
}