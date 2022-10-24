using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Assignment2.Utils
{
    public class BulkEmailSender
    {
        private const String API_KEY = "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";
        
        public void Send(List<String> toEmail, String subject, String contents, HttpPostedFileBase pathToFile)
        {
            var client = new SendGridClient(API_KEY);
            var from = new EmailAddress("annaalmeida126@gmail.com", "Medistock Team");
            var to = new List<EmailAddress>();
            foreach (string email in toEmail)
            {
                to.Add(new EmailAddress(email));
            }
            var plainTextContent = contents;
            var htmlContent = "<p>" + contents + "</p>";
            var msg = MailHelper.CreateSingleEmailToMultipleRecipients(from, to, subject, plainTextContent, htmlContent);
            if (pathToFile != null)
            {
                string fileName = Path.GetFileName(pathToFile.FileName);
                string filepath = Path.Combine(HttpContext.Current.Server.MapPath("~/Uploads"), fileName);
                var bytes = File.ReadAllBytes(filepath);
                var file = Convert.ToBase64String(bytes);
                msg.AddAttachment(fileName, file);
            }
            var response = client.SendEmailAsync(msg);
        }
    }
}