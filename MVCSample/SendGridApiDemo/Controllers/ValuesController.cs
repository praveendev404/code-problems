using SendGrid;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web.Http;

namespace SendGridApiDemo.Controllers
{
    //[Authorize]
    [RoutePrefix("values")]
    public class ValuesController : ApiController
    {
        [Route("testmail")]
        public HttpResponseMessage TestMail()
        {
            try
            {
				SendEmail("rambpraveen@gmail.com", "<div>Test body</div>", "Praveen", "Test").Wait();
                return Request.CreateResponse(HttpStatusCode.OK, "Mail sent successfully.");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Error");
            }
        }

        static async Task SendEmail(string userEmail, string body, string firstName, string subject)
        {
            string strFromMail = ConfigurationManager.AppSettings["SupportEmail"].ToString();
            string apiKey = "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";
            var msg = new SendGridMessage();
			//msg.From = new EmailAddress(strFromMail, "");
			//msg.AddTo(userEmail);
			//msg.Subject = subject;
			//msg.HtmlContent = body;
			//var client = new SendGridClient(apiKey);
			////var credentials = new NetworkCredential("rambpraveen@gmail.com", "techraq1234$");
			//var response = await client.SendEmailAsync(msg).ConfigureAwait(false);


			var myMessage = new SendGridMessage();
			myMessage.AddTo(userEmail);
			myMessage.From = new MailAddress("rambpraveen@gmail.com", "Praveen Kumar");
			myMessage.Subject = "Sending with SendGrid is Fun";
			myMessage.Text = "and easy to do anywhere, even with C#";
			var credentials = new NetworkCredential("rambpraveen@gmail.com", "techraq1234$");
			var transportWeb = new SendGrid.Web(credentials);
			await transportWeb.DeliverAsync(myMessage).ConfigureAwait(false);

			//var myMessage = new SendGrid.SendGridMessage();
			//myMessage.AddTo(strFromMail);
			//myMessage.From = new MailAddress(strFromMail, "First Last");
			//myMessage.Subject = "Sending with SendGrid is Fun";
			//myMessage.Text = "and easy to do anywhere, even with C#";

			//var transportWeb = new SendGrid.Web(apiKey);
			//await transportWeb.DeliverAsync(myMessage);

			//var client = new SendGridClient(apiKey);
			//var from = new EmailAddress(userEmail, "Example User");
			//var to = new EmailAddress(userEmail, "Example User");
			//var plainTextContent = "and easy to do anywhere, even with C#";
			//var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
			//var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
			//var response = await client.SendEmailAsync(msg);

		}
    }
}
