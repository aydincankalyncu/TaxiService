using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using TaxiServiceWebUI.Models;

namespace TaxiServiceWebUI.Controllers
{
    public class ResortController : Controller
    {
        private IResortService _resortService;

        public ResortController(IResortService resortService)
        {
            _resortService = resortService;
        }
        public IActionResult List()
        {
            var resorts = _resortService.GetResorts();
            ResortListViewModel model = new ResortListViewModel()
            {
                Resorts = new List<Entities.Concrete.Resort>()
            };
            return View(model);
        }
    }
}
