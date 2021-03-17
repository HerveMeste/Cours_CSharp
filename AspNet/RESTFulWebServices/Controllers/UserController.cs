using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RESTFulWebServices.Models;

namespace RESTFulWebServices.Controllers
{
    public class UserController : Controller
    {
        private IUserRepository userRepository;
        public UserController(IUserRepository repo)
        {
            userRepository = repo;
        }
        public async Task<IActionResult> Index(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return View();
            }
            else
            {
                User users = await userRepository.GetUserById(id);
                return View(users);
            }
        }
    }
}

