using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Assignment2.Utils
{
    public class EmailSender
    {
        private const String API_KEY = "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";

        public void Send(string email)
        {
            String toEmail = email;
            //String item = "Equipment";
            String subject = "Equipment Booking Confirmed!";
            String toName = " Doctor";
            String contents = "Hi" + toName + ",<br><br>Your booking has been confirmed and has been dispatched.<br><br> It will be delivered to you shortly.<br><br>Thanks and regards,<br>Medistock Team";
            var client = new SendGridClient(API_KEY);
            var from = new EmailAddress("annaalmeida126@gmail.com", "Medistock Team");
            var to = new EmailAddress(toEmail, "");
            var plainTextContent = contents;
            var htmlContent = "<p>" + contents + "</p>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = client.SendEmailAsync(msg);
        }
    }
}