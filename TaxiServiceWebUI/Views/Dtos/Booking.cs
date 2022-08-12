using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiServiceWebUI.Dtos
{
    public class Booking
    {
        [Required(ErrorMessage ="Pick Up Address Required.")]
        public int? FromId { get; set; }
        [Required(ErrorMessage ="Drop Off Address Required.")]
        public int? ToId { get; set; }
        [Required]
        public int? VehicleType { get; set; }
        [Required]
        public int? Passenger { get; set; }
        public int TransferType { get; set; }

    }
}
