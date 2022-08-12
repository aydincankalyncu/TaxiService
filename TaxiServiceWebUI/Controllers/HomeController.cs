using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TaxiServiceWebUI.Areas.Admin.Models;
using TaxiServiceWebUI.Models;

namespace TaxiServiceWebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAddressService _addressService;
        private readonly IPriceService _priceService;
        private readonly IResortService _resortService;
        public HomeController(IAddressService addressService, IPriceService priceService, IResortService resortService)
        {
            _addressService = addressService;
            _priceService = priceService;
            _resortService = resortService;
        }
        public IActionResult Index()
        {
            ViewBag.Addresses = new SelectList(_addressService.GetAddressList(), "Id", "Name");
            var resorts = _resortService.GetResorts();
            ReservationHomeCalculateViewModel model = new ReservationHomeCalculateViewModel()
            {
                Resorts = resorts,
                Booking = null
                
            };
            return View(model);
        }

        [HttpPost]
        public JsonResult DestinationAddress(int fromId)
        {
            List<Address> addresses = null;
            var priceList = _priceService.GetPrices(fromId);
            if(priceList.Count > 0)
            {
                addresses = new List<Address>();
            }
            for (int index = 0; index < priceList.Count; index++)
            {
                var addressInfo = _addressService.GetAddressById(priceList[index].EndAddress);
                if(!(addressInfo.Data == null)) {
                    addresses.Add(addressInfo.Data);
                }
            }
            var uniqueList = addresses.Distinct(new Comparer()).ToList();
            return Json(uniqueList);
        }

        [HttpPost]
        public JsonResult GetCardInfo(int fromId, int toId)
        {
            var priceInfo = _priceService.GetBookingPrice(fromId, toId);
                return Json(priceInfo);
        }
        #region Comparer Class for Adresses
        private class Comparer : IEqualityComparer<Address>
        {
            public bool Equals([AllowNull] Address x, [AllowNull] Address y)
            {
                return x.Id == y.Id && x.Name == y.Name;
            }

            public int GetHashCode([DisallowNull] Address obj)
            {
                return (obj.Id + obj.Name).GetHashCode();
            }
        }
        #endregion

        [HttpPost]
        public IActionResult CultureManagement(string culture, string returnUrl)
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName, CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.Now.AddDays(30) });
            return LocalRedirect(returnUrl);
        }
    }
}
