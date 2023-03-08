using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


using SendGrid.SmtpApi;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace SendGridWebhook
{
    public class Class
    {
        public async void method()
        {
            static string XsmtpapiHeaderAsJson()
            {
                var header = new Header();

                var uniqueArgs = new Dictionary<string, string>
        {
            {
                "mailId",
                "123456"
            },
            {
                "mailType",
                "marketing"
            }
        };
                header.AddUniqueArgs(uniqueArgs);

                return header.JsonString();
            }


            string xmstpapiJson = XsmtpapiHeaderAsJson();

            var client = new SmtpClient
            {
                Port = 587,
                Host = "smtp.sendgrid.net",
                Timeout = 10000,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false
            };
            string username = "apikey";

            string password = "SG.VFMDHtqsSJukID1fz3FJJA.ub6BtQxxxxxxxxxxx";

            client.Credentials = new NetworkCredential(username, password);

            var mail = new MailMessage
            {
                From = new MailAddress("please-reply@example.com"),
                Subject = "Hello there, this is a test email.",
                Body = "Hi, How are you??"
            };

            // add the custom header that we built above
            mail.Headers.Add("X-SMTPAPI", xmstpapiJson);
            mail.BodyEncoding = Encoding.UTF8;
            string email = "munshi.rayhan@x.com";

            if (email != null)
            {
                // Remember that MIME To's are different than SMTPAPI Header To's!
                mail.To.Add(new MailAddress(email));
                await client.SendMailAsync(mail);




            }

            mail.Dispose();

        }
    }
}
