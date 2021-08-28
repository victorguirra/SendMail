using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace EnviarEmail.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [HttpPost]
        public ActionResult EnviaEmail()
        {
            string emailRecipient = Request.Form["txtEmail"];
            SendMail(emailRecipient);
            return RedirectToAction("Index");
        }

        public bool SendMail(string emailRecipient)
        {
            try
            {

                string emailSender = "nomedeusuariodeteste@outlook.com";
                string emailSenderPassword = "123456789oi";

                MailMessage emailMessage = new MailMessage(emailSender, emailRecipient);

                emailMessage.Subject = "Teste de Envio";
                emailMessage.IsBodyHtml = true;
                emailMessage.Body = "<h3>Título do Email</h3> <br /> <p>Parágrafo do Email</p>";

                SmtpClient smtpClient = new SmtpClient("smtp.office365.com", Convert.ToInt32("587"));

                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(emailSender, emailSenderPassword);
                smtpClient.EnableSsl = true;

                smtpClient.Send(emailMessage);

                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}