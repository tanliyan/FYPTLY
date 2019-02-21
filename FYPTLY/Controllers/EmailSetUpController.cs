using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FYLProjectTLY.Models;
using System.Net;
using System.Net.Mail;

namespace FYLProjectTLY.Controllers
{
    public class EmailSetUpController : Controller
    {


        // GET: EmailSetUp
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Index(FYLProjectTLY.Models.gmail model)
        {

            MailMessage mm = new MailMessage("liyantanxtly@gmail.com", model.To);
            mm.Subject = model.Subject;
            mm.Body = model.Body;
            mm.IsBodyHtml = false;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;

            NetworkCredential nc = new NetworkCredential("liyantanxtly@gmail.com", "gmailpassword123");
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = nc;
            smtp.Send(mm);
            ViewBag.Message = "Mail Has Been Sent Successfully!";
            return View();

        }
    }
}
