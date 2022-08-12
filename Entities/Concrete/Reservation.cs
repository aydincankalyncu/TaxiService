using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrete
{
    public class Reservation: IEntity
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Date cannot be empty.")]
        public DateTime TransferDate { get; set; }
        [Required(ErrorMessage ="Plase enter the arrival time.")]
        [Range(0.0,24.0)]
        public int ArrivalTime { get; set; }
        [Required(ErrorMessage = "Plase enter the arrival minute.")]
        [Range(0.0, 60.0)]
        public int ArrivalMinute { get; set; }
        [Required(ErrorMessage ="Enter address section.")]
        public string Address { get; set; }
        public string Hotel { get; set; }
        public int Bag { get; set; }
        public int Ski { get; set; }
        public int SnowBoard { get; set; }
        public string ExtraInformation { get; set; }
        [Required(ErrorMessage ="Name fields cannot be empty")]
        [StringLength(50, ErrorMessage ="Name cannot be longer than 50 characters.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Name fields cannot be empty")]
        [StringLength(50, ErrorMessage = "Name cannot be longer than 50 characters.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email field cannot be empty")]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage ="Please enter your phone number.")]
        public string PhoneNumber { get; set; }
        public int PaymentOption { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ReturnTransferDate { get; set; }
        public int? ReturnPickUpTime { get; set; }
        public int? ReturnPickUpMinute { get; set; }
        public string PickUpAddress { get; set; }
        public string DropOffAddress { get; set; }

    }
}
