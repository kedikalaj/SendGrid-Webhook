// using SendGrid's C# Library
// https://github.com/sendgrid/sendgrid-csharp
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Example
{
    internal class Example
    {
        private static void Main()
        {
            Execute().Wait();
        }

        static async Task Execute()
        {
            var apiKey = Environment.GetEnvironmentVariable("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");
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("kedi.kalaj@pragmatic.al", "Example User");
            var subject = "Sending with SendGrid is Fun";
            var to = new EmailAddress("kedikalaj123@gmail.com", "Example User");
            var plainTextContent = "and easy to do anywhere with C#.";
            var htmlContent = "<strong>and easy to do anywhere with C#.</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }
}
