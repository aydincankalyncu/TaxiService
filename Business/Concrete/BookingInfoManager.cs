using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class BookingInfoManager : IBookingInfoService
    {
        private IBookingInfoDal _ınfoDal;
        public BookingInfoManager(IBookingInfoDal infoDal)
        {
            _ınfoDal = infoDal;
        }
        public void Add(BookingInfo bookingInfo)
        {
            _ınfoDal.Add(bookingInfo);
        }

        public void Delete(int bookingInfoId)
        {
            _ınfoDal.Delete(new BookingInfo { Id = bookingInfoId });
        }

        public BookingInfo GetLastBookingInfo()
        {
            var data = _ınfoDal.GetList();
            return data.Count > 0 ? data.Last() : null;
        }
    }
}
