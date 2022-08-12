using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrete
{
    public class Address: IEntity
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Adres alanı boş bırakılamaz.")]
        public string Name { get; set; }
    }
}
