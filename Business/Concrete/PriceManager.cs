using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class PriceManager : IPriceService
    {
        private IPriceDal _priceDal;
        public PriceManager(IPriceDal priceDal)
        {
            _priceDal = priceDal;
        }
        public void Add(Price price)
        {
            _priceDal.Add(price);
        }

        public void Delete(int priceId)
        {
            _priceDal.Delete(new Price { Id = priceId });
        }

        public List<Price> GetAllPrices()
        {
            return _priceDal.GetList().ToList();
        }

        public Price GetBookingPrice(int startId, int endId)
        {
            return _priceDal.Get(p => p.StartAddress == startId && p.EndAddress == endId);
        }

        public Price GetPrice(int priceId)
        {
            return _priceDal.Get(p => p.Id == priceId);
        }

        public List<Price> GetPrices(int fromId)
        {
            return _priceDal.GetList(p => p.StartAddress == fromId).ToList();
        }

        public void Update(Price price)
        {
            _priceDal.Update(price);
        }
    }
}
