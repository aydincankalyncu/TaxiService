using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TaxiServiceWebUI.Areas.Admin.Models;

namespace TaxiServiceWebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PriceController : Controller
    {
        private IPriceService _priceService;
        private IAddressService _addressService;
        public PriceController(IPriceService priceService, IAddressService addressService)
        {
            _priceService = priceService;
            _addressService = addressService;
        }
        public IActionResult Index()
        {
            var priceList = _priceService.GetAllPrices();
            PriceListViewModel model = new PriceListViewModel
            {
                Prices = priceList
            };

            return View(model);
        }

        public IActionResult Add()
        {
            ViewBag.Addresses = new SelectList(_addressService.GetAddressList(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Add(Price price)
        {
            try
            {
                Price oppositePrice = new Price();
                oppositePrice.StartAddress = price.EndAddress;
                oppositePrice.EndAddress = price.StartAddress;
                oppositePrice.TravelTime = price.TravelTime;
                oppositePrice.OneWayPrice = price.OneWayPrice;
                oppositePrice.TwoWayPrice = price.TwoWayPrice;
                oppositePrice.Distance = price.Distance;
                _priceService.Add(oppositePrice);
                _priceService.Add(price);
            }
            catch (Exception e)
            {

                ViewBag.Error = e.InnerException;
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int priceId)
        {
            _priceService.Delete(priceId);
            return RedirectToAction("Index");
        }

    }
}
