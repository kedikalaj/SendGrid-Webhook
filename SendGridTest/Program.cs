﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


using SendGrid.SmtpApi;
using System.Net;
using System.Net.Mail;
using System.Text;

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

string password = "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";

client.Credentials = new NetworkCredential(username, password);

var mail = new MailMessage
{
    From = new MailAddress("kedi.kalaj@pragmatic.al"),
    Subject = "Hello there, this is a test email.",
    Body = "Hi, How are you??"
};

// add the custom header that we built above
mail.Headers.Add("X-SMTPAPI", xmstpapiJson);
mail.BodyEncoding = Encoding.UTF8;
string email = "kedikalaj123@gmail.com";

if (email != null)
{
    // Remember that MIME To's are different than SMTPAPI Header To's!
    mail.To.Add(new MailAddress(email));
  await  client.SendMailAsync(mail);

    


}

mail.Dispose();

