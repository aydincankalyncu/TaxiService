using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TaxiServiceWebUI.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult List()
        {
            return View();
        }
    }
}
