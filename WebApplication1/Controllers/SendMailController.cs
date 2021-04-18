using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Mail;
using Student.Models;

namespace WebApplication1.Controllers
{
    public class SendMailController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Email em)
        {
            string to = em.To;
            string subject = em.Subject;
            string body = em.Body;

            MailMessage mm = new MailMessage();
            
            mm.To.Add(to);
            mm.Subject = body;
            mm.Body = body;
            mm.From = new MailAddress("earnrupee.in@gmail.com");
            mm.IsBodyHtml = false;

            SmtpClient smtp = new SmtpClient("smtp.gmail.com");

            smtp.Port = 587;
            smtp.UseDefaultCredentials = true;
            smtp.EnableSsl = true;
            smtp.Credentials = new System.Net.NetworkCredential();
            smtp.Send(mm);

            ViewBag.message = "The Mail Been Sent To " + em.To + " Succesfully..!";
            return View();
        }
    }
}
