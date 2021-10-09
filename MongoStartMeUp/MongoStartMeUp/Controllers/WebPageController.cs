using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoStartMeUp.Controllers
{
    public class WebPageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
