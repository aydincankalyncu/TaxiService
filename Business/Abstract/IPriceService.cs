using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IPriceService
    {
        void Add(Price price);
        void Delete(int priceId);
        void Update(Price price);
        Price GetPrice(int priceId);
        Price GetBookingPrice(int startId, int endId);
        List<Price> GetPrices(int fromId);
        List<Price> GetAllPrices();
    }
}
