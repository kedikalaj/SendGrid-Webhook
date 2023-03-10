using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebhookTest.Models
{

    public class Email
    {
        [JsonProperty("email")]
        public string Emaill { get; set; }


    }
}
