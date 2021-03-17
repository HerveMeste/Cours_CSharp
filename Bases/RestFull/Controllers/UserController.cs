using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestFull.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace RestFull.Controllers
{
    public class UserController : Controller
    {
        private readonly IHttpClientFactory _client;
        private string _domain = "https://jsonplaceholder.typicode.com/";

        public UserController(IHttpClientFactory client)
        {
            _client = client;
        }
        public async Task<IActionResult> Profil(string id)
        {
            if(String.IsNullOrEmpty(id))
            {
                return View();
            }
            else
            {
                HttpClient httpClient = _client.CreateClient();
                string userToString = await httpClient.GetStringAsync(_domain + "users/" + id);
                User user = JsonConvert.DeserializeObject<User>(userToString);
                return View(user);
            }
        }

    }
}
