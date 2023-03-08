using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebhookTest.Models;
using System.Net;
using System.Net.Http;
using System.Web;
using Newtonsoft.Json;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebhookTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailController : ControllerBase
    {


        [HttpPost]
        public void Post(string root)
        {

             // Convert the string to a JSON object
            dynamic jsonObject = JsonConvert.DeserializeObject(root);

            // Access properties of the JSON object
            string property1 = jsonObject.email;

            
        }
    }
}
