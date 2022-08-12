using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaxiServiceWebUI.Models;

namespace TaxiServiceWebUI.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Info()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SendMail(ContactSendMailViewModel model)
        {
            if (ModelState.IsValid)
            {
                SendContactMail(model);
                return RedirectToAction(nameof(Info));
            }
            return View("Info");
            
        }

        private void SendContactMail(ContactSendMailViewModel model)
        {
            var credentials = new NetworkCredential("infoinnsbrucktaxi@gmail.com", "info123456+");
            var mail = new MailMessage()
            {
                From = new MailAddress("infoinnsbrucktaxi@gmail.com"),
                Subject = model.ContactDTO.Subject,
                Body = "Hello " + model.ContactDTO.Name + "<br> We will return your message very soon, keep in touch.<br><br>" +
                "<h3 style:'color:green;'>Innsbruck Taxi<p>Call Us. 004366499398308 </p></h3>"
            };
            mail.IsBodyHtml = true;
            mail.To.Add(new MailAddress("infoinnsbrucktaxi@gmail.com"));
            mail.To.Add(new MailAddress(model.ContactDTO.Email));

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
    }
}
