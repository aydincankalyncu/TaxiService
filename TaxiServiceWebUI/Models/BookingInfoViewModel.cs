using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiServiceWebUI.Models
{
    public class BookingInfoViewModel
    {
        public Reservation Reservation { get; set; }
        public BookingInfo BookingInfo { get; set; }
    }
}
