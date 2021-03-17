using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QuestApiRest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace QuestApiRest.Controllers
{
    
    
    public class PlanetsController : Controller
    {
        [Route("Planets/{id}")]
        public IActionResult Index(Int32 id)
        {
            WebClient client = new WebClient();

            String response = client.DownloadString("https://swapi.dev/api/planets/" + id +"/");
            Planets planets = JsonConvert.DeserializeObject<Planets>(response);

            return View(planets);
        }


        
    }
}
