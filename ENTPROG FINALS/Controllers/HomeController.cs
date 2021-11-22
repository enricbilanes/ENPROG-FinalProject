using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ENTPROG_FINALS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using System.Net;
using System.Net.Mail;

namespace ENTPROG_FINALS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(Contact contact)
        {
            MailMessage mail = new MailMessage()
            {
                From = new MailAddress("testtrial239@gmail.com", "Administrator")
            };
            mail.To.Add(new MailAddress(contact.Email));

            mail.Subject = "Inquiry from " + contact.Sender + " (" + contact.Subject + ")";
            string message = "Hello, " + contact.Sender + "<br/><br/>" + "We have received your inquiry. Here are the details: <br/><br/>"
                + "Contact Number: " + contact.ContactNo + "<br/>" + "Message:<br>" + contact.Message + "<br/><br/>"
                + "Please wait for our reply. Thank you.";
            mail.Body = message;
            mail.IsBodyHtml = true;
            //mail.Priority = MailPriority.High;


            using SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential("testtrial239@gmail.com", "Minecraft158"),
                EnableSsl = true
            };

            smtp.Send(mail);
            ViewBag.Message = "Inquiry Sent.";
            return View();
        }
    }
}
