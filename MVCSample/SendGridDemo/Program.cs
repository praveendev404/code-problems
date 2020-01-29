using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;
using SendGrid;
using System.Net.Mail;
using System.Web;
using System.IO;
using System.Threading.Tasks;
using SendGrid.Helpers.Mail;

namespace SendGridDemo
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        bool SendEmail(string userEmail, string body, string firstName, string lastName, string subject)
        {
            string strFromMail = ConfigurationManager.AppSettings["SupportEmail"].ToString();
            try
            {
                //MailAddress mailAddr = new MailAddress(strFromMail,"");
                var msg = new SendGridMessage();
                msg.From = new EmailAddress(strFromMail,"");
                msg.AddTo(userEmail);
                msg.Subject = subject;
                msg.Html = body;
                var credentials = new NetworkCredential("azure_7a7f99deae960d6b2770977a80e3ddd8@azure.com", "2IvC#^kHkCJj");
                var transportWeb = new SendGrid.Web(credentials);
                transportWeb.DeliverAsync(msg);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }

        //private static void Main()
        //{
        //    Execute().Wait();
        //}

        static async Task Execute()
        {
            var apiKey = Environment.GetEnvironmentVariable("NAME_OF_THE_ENVIRONMENT_VARIABLE_FOR_YOUR_SENDGRID_KEY");
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("rambpraveen@gmail.com", "Example User");
            var subject = "Sending with SendGrid is Fun";
            var to = new EmailAddress("test@example.com", "Example User");
            var plainTextContent = "and easy to do anywhere, even with C#";
            var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }
}
