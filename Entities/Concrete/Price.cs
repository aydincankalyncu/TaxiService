using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Price: IEntity
    {
        public int Id { get; set; }
        public int StartAddress { get; set; }
        public int EndAddress { get; set; }
        public int Distance { get; set; }
        public int TravelTime { get; set; }
        public int OneWayPrice { get; set; }
        public int TwoWayPrice { get; set; }

    }
}
