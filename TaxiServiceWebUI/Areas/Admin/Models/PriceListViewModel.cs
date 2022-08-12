using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiServiceWebUI.Areas.Admin.Models
{
    public class PriceListViewModel
    {
        public List<Price> Prices { get;  set; }
    }
}
