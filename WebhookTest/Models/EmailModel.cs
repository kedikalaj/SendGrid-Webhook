using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebhookTest.Models
{
    
    public class Email
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string ID { get; set; }
        [JsonProperty("email")]
        public string Emaill { get; set; }

        [JsonProperty("sg_message_id")]
        public string MID { get; set; }

        [JsonProperty("event")]
        public string Event{ get; set; }

    }
}
