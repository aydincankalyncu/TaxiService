using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<ResortManager>().As<IResortService>();
            builder.RegisterType<ResortDal>().As<IResortDal>();

            builder.RegisterType<AddressManager>().As<IAddressService>();
            builder.RegisterType<AddressDal>().As<IAddressDal>();

            builder.RegisterType<PriceManager>().As<IPriceService>();
            builder.RegisterType<PriceDal>().As<IPriceDal>();

            builder.RegisterType<BookingInfoManager>().As<IBookingInfoService>();
            builder.RegisterType<BookingInfoDal>().As<IBookingInfoDal>();

            builder.RegisterType<ReservationManager>().As<IReservationService>();
            builder.RegisterType<ReservationDal>().As<IReservationDal>();

        }
    }
}
