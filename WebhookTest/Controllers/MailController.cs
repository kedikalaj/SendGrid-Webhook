﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebhookTest.Models;
using System.Net;
using System.Net.Http;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebhookTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailController : ControllerBase
    {


        [HttpPost]
        public void Post([FromBody] object json)
        {

            var token = JToken.Parse(json.ToString());
            if (token is JArray)
            {
                var list = JsonConvert.DeserializeObject<List<Email>>(json.ToString());

                for (int i = list.Count - 1; i >= 0; i--)
                {
                    string e = list[0].Emaill;
                    string w = list[0].ToString();


                }

            }
            else if (token is JObject)
            {
                var list = JsonConvert.DeserializeObject<Email>(json.ToString());  

            }
            // Convert the string to a JSON object
          

        }
        [HttpGet]
        public string get()
        {
            return "test";
        }
    }
}
