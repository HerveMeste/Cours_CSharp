using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASPNET_Routage.Controllers
{
    /*[Route("api/[controller]")]*/
    [ApiController]
    public class HelloAttributesController
    {
        [Route("Say")] // The endpoint here is reached by calling `/Say` route
        public String SayHello()
        {
            return "Hello via attribute !";
        }

        [Route("Yell")] // The endpoint here is reached by calling `/Yell` route
        public String YellHello()
        {
            return "HELLO ATTRIBUTE !";
        }
    }
}
