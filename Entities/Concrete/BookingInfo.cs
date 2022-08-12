using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrete
{
    public class BookingInfo:IEntity
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Please enter pick up address.")]
        public int FromId { get; set; }
        [Required(ErrorMessage ="Please enter drop off address.")]
        public int ToId { get; set; }
        public int VehicleType { get; set; }
        [Required(ErrorMessage ="Please enter exact number of passengers.")]
        public int Passenger { get; set; }
        public int TransferType { get; set; }
        public string FromAddress { get; set; }
        public string ToAddress { get; set; }
        public int Price { get; set; }
        public int Distance { get; set; }
        public int TravelTime { get; set; }
    }
}
