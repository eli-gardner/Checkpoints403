using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;

namespace dbBlowOut.Controllers
{
    public class ContactController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Contact = "Please call Support at <strong><u>801-555-1212</u></strong>. Thank you!";

            return View();
        }

        public ActionResult Email(string name, string email)
        {
            ViewBag.Email = "Thank you " + name + ". We will send an email to " + email + ".";

            return View();
        }

        public ActionResult SendMail()
        {
            MailMessage mail = new MailMessage();
            mail.To.Add("gardner.aarone@gmail.com");
            mail.From = new MailAddress("aspnettestingis@gmail.com");
            mail.Subject = "Poor College Student Needs Help";
            mail.Body = "Send me all your money. I need it more than you!";

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential("aspnettestingis@gmail.com", "ISCore403");

            smtp.EnableSsl = true;
            smtp.Send(mail);

            return View("Email");
        }
    }
}