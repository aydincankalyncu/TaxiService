using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Banner: IEntity
    {
        public int BannerId { get; set; }
        public int PageId { get; set; }
        public string ImagePath { get; set; }
    }
}
