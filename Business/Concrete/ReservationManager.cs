using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class ReservationManager : IReservationService
    {
        private IReservationDal _reservationDal;
        public ReservationManager(IReservationDal reservationDal)
        {
            _reservationDal = reservationDal;
        }
        public void Add(Reservation reservation)
        {
            _reservationDal.Add(reservation);
        }

        public void Delete(int id)
        {
            _reservationDal.Delete(new Reservation { Id = id });
        }

        public Reservation GetLastReservation()
        {
            var lastReservation = _reservationDal.GetList();
            return lastReservation.Count > 0 ? lastReservation.Last() : null;
        }

        public Reservation GetReservation(int id)
        {
            return _reservationDal.Get(p => p.Id == id);
        }

        public List<Reservation> GetReservations()
        {
            return _reservationDal.GetList().ToList();
        }

        public void Update(Reservation reservation)
        {
            _reservationDal.Update(reservation);
        }
    }
}
