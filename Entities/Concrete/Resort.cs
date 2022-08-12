using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Resort : IEntity
    {
        public int Id { get; set; }
        public int FromId { get; set; }
        public int ToId { get; set; }
        public string FromAddress { get; set; }
        public string ToAddress { get; set; }
        public string ImagePath { get; set; }
        public string OriginalImageName { get; set; }
        public int Price { get; set; }
    }
}
