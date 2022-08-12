using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiServiceWebUI.Models
{
    public class ResortInfoViewModel
    {
        public Resort Resort { get; set; }
        public Price Price { get; set; }
        public BookingInfo BookingInfo { get; set; }
        public Reservation Reservation { get; set; }
    }
}
