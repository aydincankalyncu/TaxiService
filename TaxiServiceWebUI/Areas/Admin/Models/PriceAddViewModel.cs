using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiServiceWebUI.Areas.Admin.Models
{
    public class PriceAddViewModel
    {
        public Price Price { get; set; }
        public Address Address { get; set; }
    }
}
