using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using TriESolutions.Models;

namespace TriESolutions.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ApplicationContext context)
        {
            _logger = logger;
            _context = context;
        }
        private void SendMail(string mailbody)
        {
            try
            {
                SmtpClient smtpClient = new SmtpClient();
                NetworkCredential networkCredential = new NetworkCredential("hr.triesolutions@gmail.com", "sardar3250241");
                smtpClient.Host = "smtp.gmail.com";
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = networkCredential;
                smtpClient.Port = 587;
                smtpClient.EnableSsl = true;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;

                MailMessage Mail = new MailMessage();
                Mail.From = new MailAddress("hr.triesolutions@gmail.com");
                Mail.To.Add("munirirfan0@gmail.com");
                //Mail.CC.Add("");
                //Mail.CC.Add("");
                //Mail.IsBodyHtml = true;
                Mail.Subject = "NEW EMAIL";
                Mail.Body = mailbody;
                

                smtpClient.Send(Mail);
                ViewBag.Message = "Email Send";
                ModelState.Clear();

            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message.ToString();
            }
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Aboutus()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Contactus()
        {

            return View();
        }

        [Httpost]
        public JsonResult AddContactUsData(SendEmail sendEmail)
        {
            
                string body = sendEmail.Name + "\n" + sendEmail.Email + "\n" + sendEmail.MobilePhone + "\n" + sendEmail.Message;
                SendMail(body);
                _context.sendEmails.Add(sendEmail);
                _context.SaveChanges();
            //return Ok();
            return Json(new { success = true });
           

        }
        public IActionResult CustomSoftwareDevelopment()
        {
            return View();
        }
        public IActionResult WebDevelopment()
        {
            return View();
        }
        public IActionResult MobileAppDevelopment()
        {
            return View();
        }
        public IActionResult DataBaseDevelopment()
        {
            return View();
        }
        public IActionResult ERPSolutions()
        {
            return View();
        }
        public IActionResult POSSolutions()
        {
            return View();
        }
        public IActionResult CRMSolutions()
        {
            return View();
        }
        public IActionResult SocialMediaMarkeeting()
        {
            return View();
        }
        public IActionResult Seo()
        {
            return View();
        }
        public IActionResult Products()
        {
            return View();
        }
        public IActionResult Careers()
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
    }

    internal class HttpostAttribute : Attribute
    {
    }
}

