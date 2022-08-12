using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IReservationService
    {
        void Add(Reservation reservation);
        void Delete(int id);
        void Update(Reservation reservation);
        Reservation GetReservation(int id);
        List<Reservation> GetReservations();
        Reservation GetLastReservation();
    }
}
