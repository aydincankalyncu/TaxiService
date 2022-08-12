using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IBookingInfoService
    {
        void Add(BookingInfo bookingInfo);
        void Delete(int bookingInfoId);
        BookingInfo GetLastBookingInfo();
    }
}
