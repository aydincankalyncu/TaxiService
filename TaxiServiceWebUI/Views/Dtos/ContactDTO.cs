using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiServiceWebUI.Dtos
{
    public class ContactDTO
    {
        [Required(ErrorMessage ="Please enter your name")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Please enter your e-mail address")]
        public string Email { get; set; }
        public string Subject { get; set; }
        [Required(ErrorMessage ="Please enter the message.")]
        public string Message { get; set; }
    }
}
