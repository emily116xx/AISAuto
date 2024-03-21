using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;

namespace MVCTestEmailSending.Controllers
{
    public class EmailController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        // SendEmail: for GET request
        public ActionResult SendEmail(string subject1, string body1, string subject2, string body2, string subject3, string body3)
        {
            ViewBag.Subject1 = subject1;
            ViewBag.Body1 = body1;
            ViewBag.Subject2 = subject2;
            ViewBag.Body2 = body2;
            ViewBag.Subject3 = subject3;
            ViewBag.Body3 = body3;

            return View();
        }

        // SendEmail: for POST request 
        [HttpPost]
        public ActionResult SendEmail(string smtpServer, string fromEmail,
            string toEmail1, string subject1, string body1,
            string toEmail2, string subject2, string body2,
            string toEmail3, string subject3, string body3,
            int port, string password, bool enableSsl, bool? firstEmailToggle, bool? secondEmailToggle, bool? thirdEmailToggle, bool enableSslChecked = false)
        {
            try
            {
                SmtpClient smtpClient = new SmtpClient(smtpServer)
                {
                    Port = port,
                    Credentials = new System.Net.NetworkCredential(fromEmail, password),
                    EnableSsl = enableSsl || enableSslChecked
            };

                bool sendFirstEmail = firstEmailToggle ?? false;
                bool sendSecondEmail = secondEmailToggle ?? false;
                bool sendThirdEmail = thirdEmailToggle ?? false;

                if (sendFirstEmail)
                {
                    // first email (for lecturer) - option
                    MailMessage mail1 = new MailMessage(fromEmail, toEmail1, subject1, body1);
                    smtpClient.Send(mail1);
                }

                if (sendSecondEmail)
                {
                    // second email (for Admin) - option
                    MailMessage mail2 = new MailMessage(fromEmail, toEmail2, subject2, body2);
                    smtpClient.Send(mail2);
                }

                if (sendThirdEmail)
                {
                    // third email (for Admin) - option
                    MailMessage mail3 = new MailMessage(fromEmail, toEmail3, subject3, body3);
                    smtpClient.Send(mail3);
                }

                ViewBag.Message = "Emails sent successfully";
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Error in sending emails: " + ex.Message;
            }

            return View();
        }
    }


}
