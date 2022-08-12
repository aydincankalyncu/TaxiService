using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxiServiceWebUI.Dtos;

namespace TaxiServiceWebUI.Models
{
    public class ReservationHomeCalculateViewModel
    {
        public Booking Booking { get; set; }
        public List<Resort> Resorts { get; set; }
    }
}
