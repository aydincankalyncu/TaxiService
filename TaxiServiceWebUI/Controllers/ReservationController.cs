using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TaxiServiceWebUI.Dtos;
using TaxiServiceWebUI.Models;

namespace TaxiServiceWebUI.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IBookingInfoService _infoService;
        private readonly IAddressService _addressService;
        private readonly IPriceService _priceService;
        private readonly IReservationService _reservationService;
        private readonly IResortService _resortService;
        public ReservationController(IBookingInfoService infoService, IAddressService addressService,
            IPriceService priceService, IReservationService reservationService, IResortService resortService)
        {
            _infoService = infoService;
            _addressService = addressService;
            _priceService = priceService;
            _reservationService = reservationService;
            _resortService = resortService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(ReservationHomeCalculateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var resorts = _resortService.GetResorts();
                ReservationHomeCalculateViewModel returnModel = new ReservationHomeCalculateViewModel()
                {
                    Resorts = resorts,
                    Booking = null

                };
                ViewBag.Addresses = new SelectList(_addressService.GetAddressList(), "Id", "Name");
                return View("../Home/Index", returnModel);
            }
            BookingInfo bookingInfo = new BookingInfo();
            var priceInfo = _priceService.GetBookingPrice((int)model.Booking.FromId, (int)model.Booking.ToId);
            var fromAddress = _addressService.GetAddressById((int)model.Booking.FromId);
            var toAddress = _addressService.GetAddressById((int)model.Booking.ToId);
            if (model.Booking.TransferType == 1)
            {
                bookingInfo.Price = priceInfo.OneWayPrice;
            }
            else
            {
                bookingInfo.Price = priceInfo.TwoWayPrice;
            }
            bookingInfo.Distance = priceInfo.Distance;
            bookingInfo.TravelTime = priceInfo.TravelTime;
            bookingInfo.FromId = (int)model.Booking.FromId;
            bookingInfo.ToId = (int)model.Booking.ToId;
            bookingInfo.Passenger = (int)model.Booking.Passenger;
            bookingInfo.VehicleType = (int)model.Booking.VehicleType;
            bookingInfo.TransferType = model.Booking.TransferType;
            bookingInfo.FromAddress = fromAddress.Data.Name;
            bookingInfo.ToAddress = toAddress.Data.Name;
            _infoService.Add(bookingInfo);
            return RedirectToAction("BookingService");
        }

        public IActionResult BookingService()
        {
            ViewBag.Addresses = new SelectList(_addressService.GetAddressList(), "Id", "Name");
            var info = _infoService.GetLastBookingInfo();
            if(!(info == null))
            {
                BookingInfoViewModel model = new BookingInfoViewModel
                {
                    BookingInfo = info
                };
                _infoService.Delete(info.Id);

                return View(model);
            }
            return View();
        }

        [HttpPost]
        public IActionResult Save(BookingInfoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Addresses = new SelectList(_addressService.GetAddressList(), "Id", "Name");
                return View("BookingService");
            }
            Reservation reservation = new Reservation();
            var fromAddress = _addressService.GetAddressById(model.BookingInfo.FromId);
            var toAddress = _addressService.GetAddressById(model.BookingInfo.ToId);
            reservation.TransferDate = model.Reservation.TransferDate.Date;
            reservation.Address = model.Reservation.Address;
            reservation.ArrivalMinute = model.Reservation.ArrivalMinute;
            reservation.ArrivalTime = model.Reservation.ArrivalTime;
            reservation.Bag = model.Reservation.Bag;
            reservation.Ski = model.Reservation.Ski;
            reservation.Hotel = model.Reservation.Hotel;
            reservation.SnowBoard = model.Reservation.SnowBoard;
            reservation.FirstName = model.Reservation.FirstName;
            reservation.LastName = model.Reservation.LastName;
            reservation.Email = model.Reservation.Email;
            reservation.ExtraInformation = model.Reservation.ExtraInformation;
            reservation.PickUpAddress = fromAddress.Data.Name;
            reservation.DropOffAddress = toAddress.Data.Name;
            reservation.PhoneNumber = model.Reservation.PhoneNumber;
            reservation.PaymentOption = model.Reservation.PaymentOption;
            reservation.ReturnTransferDate = model.Reservation.ReturnTransferDate;
            reservation.ReturnPickUpTime = model.Reservation.ReturnPickUpTime;
            reservation.ReturnPickUpMinute = model.Reservation.ReturnPickUpMinute;

            _reservationService.Add(reservation);


            SendInformationMail(reservation.Email, reservation);

        
            var info = _reservationService.GetLastReservation();
            if (!(info == null))
            {
                var priceInfo = _priceService.GetBookingPrice(model.BookingInfo.FromId, model.BookingInfo.ToId);
                ViewBag.TransferType = model.BookingInfo.TransferType == 0 ? "One Way" : "Return";
                ViewBag.Price = model.BookingInfo.TransferType == 0 ? priceInfo.OneWayPrice : priceInfo.TwoWayPrice;
                ViewBag.Distance = priceInfo.Distance;
                ViewBag.TravelTime = priceInfo.TravelTime;
                ViewBag.Vehicle = "Taxi Max. 3 Pax";

                ReservationAddViewModel viewModel = new ReservationAddViewModel
                {
                    Reservation = info
                };
                return View(viewModel);
            }
            return RedirectToAction("BookingService");
        }

        private void SendInformationMail(string email, Reservation reservation)
        {
            string template = GetMailTemplate(reservation);
            var credentials = new NetworkCredential("infoinnsbrucktaxi@gmail.com", "info123456+");
            var mail = new MailMessage()
            {
                From = new MailAddress("infoinnsbrucktaxi@gmail.com"),
                Subject = "Reservation Summary",
                Body = template
                };
            mail.IsBodyHtml = true;
            mail.To.Add(new MailAddress("infoinnsbrucktaxi@gmail.com"));
            mail.To.Add(new MailAddress(email));

            var client = new SmtpClient()
            {
                Port = 587,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Host = "smtp.gmail.com",
                EnableSsl = true,
                Credentials = credentials
            };
            client.Send(mail);
        }

        private string GetMailTemplate(Reservation reservation)
        {
            string returnTimeInfo = reservation.ReturnTransferDate != null ? "<tr>" +
                "<td>Return Transfer Date</td>" +
                "<td>" + reservation.ReturnTransferDate + "</td>" +
                "</tr>" +
                 "<tr>" +
                "<td>Return Transfer Time</td>" +
                "<td>" + reservation.ReturnPickUpTime + ": "+reservation.ReturnPickUpMinute + "</td>" +
                "</tr>" +
                 "<tr>" : "";
           
            string htmlTemplate = "<!DOCTYPE html><html><head><style>table{font-family:arial,sans-serif;border-collapse:collapse;width:100%;}td, th {border: 1px solid #dddddd;  text-align: left;padding: 8px;}tr:nth-child(even) {background-color: #dddddd;}</style></head><body><h2>Reservation Summary</h2><h3>Hello "+ reservation.FirstName+"<br>We are so greatful for choosing us. Thanks a lot.<br>Your reservation information listed at below on the table which name is Reservation Summary.</h3><table><tr><th>Summary</th><th>Info</th></tr>" +
                "<tr>" +
                "<td>Pick Up Address</td>" +
                "<td>"+ reservation.PickUpAddress+"</td>" +
                "</tr>" +
                "<tr>" +
                "<td>Drop Off Address</td>" +
                "<td>" + reservation.DropOffAddress + "</td>" +
                "</tr>" +
                 "<tr>" +
                "<td>Transfer Date</td>" +
                "<td>" + reservation.TransferDate.Date.ToShortDateString() + "</td>" +
                "</tr>" + returnTimeInfo+
                "<td>Transfer Time</td>" +
                "<td>" + reservation.ArrivalTime + ":" + reservation.ArrivalMinute + "</td>" +
                "</tr>" +
                 "<tr>" +
                "<td>Address</td>" +
                "<td>" + reservation.Address+ "</td>" +
                "</tr>" +
                 "<tr>" +
                "<td>Hotel / Pension</td>" +
                "<td>" + reservation.Hotel+ "</td>" +
                "</tr>" +
                 "<tr>" +
                "<td>Name</td>" +
                "<td>" + reservation.FirstName +" " + reservation.LastName + "</td>" +
                "</tr>" +
                 "<tr>" +
                "<td>Bag</td>" +
                "<td>" + reservation.Bag+ "</td>" +
                "</tr>" +
                 "<tr>" +
                "<td>Ski</td>" +
                "<td>" + reservation.Ski+ "</td>" +
                "</tr>" +
                 "<tr>" +
                "<td>Snowboard</td>" +
                "<td>" + reservation.SnowBoard+ "</td>" +
                "</tr>" +
                 "<tr>" +
                "<td>Extra Information</td>" +
                "<td>" + reservation.ExtraInformation+ "</td>" +
                "</tr>" +
                 "<tr>" +
                "<td>Phone Number</td>" +
                "<td>" + reservation.PhoneNumber+ "</td>" +
                "</tr>" +
                "</table><br><br><div style='border: 3px solid black; text-align: center;'>" +
                "<h2 style='font-weight:bold;'>Innsbruck Taxi Airport, Have a Good Day!</h2>" +
                "<h2>Do you have a question? Call Us! <p>004366499398308</p></h2></div></body></html>";
            return htmlTemplate;
        }

        public IActionResult ResortInfo(int id)
        {
            var resortInfo = _resortService.GetResort(id).Data;
            var priceInfo = _priceService.GetBookingPrice(resortInfo.FromId, resortInfo.ToId);
            ResortInfoViewModel model = new ResortInfoViewModel
            {
                Resort = resortInfo,
                Price = priceInfo
            };
            return View(model);
        }
    }
}
