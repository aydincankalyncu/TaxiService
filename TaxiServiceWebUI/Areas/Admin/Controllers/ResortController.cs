using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TaxiServiceWebUI.Areas.Admin.Models;

namespace TaxiServiceWebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ResortController : Controller
    {
        private readonly IResortService _resortService;
        private readonly IAddressService _addressService;
        public ResortController(IResortService resortService, IAddressService addressService)
        {
            _resortService = resortService;
            _addressService = addressService;
        }
        public IActionResult Index()
        {
            var resortList = _resortService.GetResorts();
            ResortListViewModel model = new ResortListViewModel
            {
                Resorts = resortList
            };
            return View(model);
        }

        public IActionResult Add()
        {
            ViewBag.Addresses = new SelectList(_addressService.GetAddressList(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult>Add(Resort resort, IFormFile file)
        {
            
            if (file != null)
            {
                var fromAddress = _addressService.GetAddressById(resort.FromId).Data.Name;
                var toAddress = _addressService.GetAddressById(resort.ToId).Data.Name;
                resort.OriginalImageName = file.FileName;
                resort.FromAddress = fromAddress;
                resort.ToAddress = toAddress;
                var extension = Path.GetExtension(file.FileName);
                var imagePath = string.Format($"{Guid.NewGuid()}{extension}");
                resort.ImagePath = imagePath;
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", imagePath);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                _resortService.Add(resort);
                return RedirectToAction("Index");
            }
            return View();
               
        }

        public IActionResult Delete(int resortId)
        {
            var resort = _resortService.GetResort(resortId);
            if (resort.Success)
            {
                _resortService.Delete(resortId);
            }
            return RedirectToAction("Index");
        }
    }
}
