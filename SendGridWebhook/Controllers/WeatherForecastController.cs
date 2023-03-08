using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
namespace SendGridWebhook.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
        [HttpPost]
        public async Task<HttpResponseMessage> Post()
        {
            var root = HttpContext.Current.Server.MapPath("~/App_Data");
            var provider = new MultipartFormDataStreamProvider(root);
            await Request.Content.ReadAsMultipartAsync(provider);

            var email = new Email
            {
                Dkim = provider.FormData.GetValues("dkim").FirstOrDefault(),
                To = provider.FormData.GetValues("to").FirstOrDefault(),
                Html = provider.FormData.GetValues("html").FirstOrDefault(),
                From = provider.FormData.GetValues("from").FirstOrDefault(),
                Text = provider.FormData.GetValues("text").FirstOrDefault(),
                SenderIp = provider.FormData.GetValues("sender_ip").FirstOrDefault(),
                Envelope = provider.FormData.GetValues("envelope").FirstOrDefault(),
                Attachments = int.Parse(provider.FormData.GetValues("attachments").FirstOrDefault()),
                Subject = provider.FormData.GetValues("subject").FirstOrDefault(),
                Charsets = provider.FormData.GetValues("charsets").FirstOrDefault(),
                Spf = provider.FormData.GetValues("spf").FirstOrDefault()
            };

            

            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
