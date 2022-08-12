using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using TaxiServiceWebUI.Areas.Admin.Models;

namespace TaxiServiceWebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AddressController : Controller
    {
        private IAddressService _addressService;
        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }
        
        public IActionResult List()
        {
            var addressList = _addressService.GetAddressList();
            AddressListViewModel model = new AddressListViewModel
            {
                Addresses = addressList
            };
            return View(model);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Address address)
        {
            if (ModelState.IsValid)
            {
                _addressService.Add(address);
                return RedirectToAction("List");
            }
            return View();
            
        }

        public IActionResult Update(int addressId)
        {
            var address = _addressService.GetAddressById(addressId);
            AddressUpdateViewModel model = new AddressUpdateViewModel { Address = address.Data };

            return View(model);
        }

        [HttpPost]
        public IActionResult Update(Address address)
        {
            if (ModelState.IsValid)
            {
                _addressService.Update(address);
                return RedirectToAction("List");
            }
            return View();
        }

        public IActionResult Delete(int addressId)
        {
            var address = _addressService.GetAddressById(addressId);
            if (address.Success)
            {
                _addressService.Delete(addressId);
            }
            return RedirectToAction("List");
        }
    }
}
