using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASPNET_Routage.Controllers
{
    public class HelloController
    {
        public String SayHello()
        {
            return "Hello !";
        }

        public String YellHello()
        {
            return "HELLO !";
        }
    }


}
