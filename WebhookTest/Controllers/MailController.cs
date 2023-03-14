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
using Newtonsoft.Json.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Xml.Linq;
using Microsoft.Extensions.Options;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebhookTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailController : ControllerBase
    {


        private EmailContext _emailContext;
        public MailController(EmailContext emailContext)
        {
            _emailContext = emailContext;
        }

        [HttpPost]
        public async Task<ActionResult<Email>> Post([FromBody] object json)
        {

            var token = JToken.Parse(json.ToString());
            if (token is JArray)
            {
                var list = JsonConvert.DeserializeObject<List<Email>>(json.ToString());

                for (int i = list.Count - 1; i >= 0; i--)
                {
                    if (!MessageExists(list[i].MID))
                    {

                   

                    Email mail = new Email
                    {
                    
                        MID = list[i].MID.ToString(),
                        Event = list[i].Event.ToString(),
                        Emaill = list[i].Emaill.ToString()
                    };

                    string conn = "Server=(localdb)\\mssqllocaldb;Database=MailEvents; Trusted_Connection=true";

                    var options = new DbContextOptionsBuilder<EmailContext>()
                  .UseSqlServer(new SqlConnection(conn));
                  

                    using (var mailContext = new EmailContext( _emailContext.Options ))
                    {

                   
                        try
                        {
                            mailContext.Emails.Add(mail);
                            await mailContext.SaveChangesAsync();
                        }
                    catch(Exception e)
                        {
                                return BadRequest();
                        }
                        
                    }
                    }
                    else
                    {

                        var result = _emailContext.Emails.SingleOrDefault(b => b.MID == list[i].MID);
                        if (result != null)
                        {
                            try
                            {
                                result.Event = list[i].Event;
                                await _emailContext.SaveChangesAsync();
                            }
                            catch (Exception e)
                            {
                                return BadRequest();

                            }

                        }


                    }


                }
                return Ok();
            }
            else if (token is JObject)
            {
                var list = JsonConvert.DeserializeObject<Email>(json.ToString());



                if (!MessageExists(list.MID))
                {



                    Email mail = new Email
                    {

                        MID = list.MID.ToString(),
                        Event = list.Event.ToString(),
                        Emaill = list.Emaill.ToString()
                    };

                    string conn = "Server=(localdb)\\mssqllocaldb;Database=MailEvents; Trusted_Connection=true";

                    var options = new DbContextOptionsBuilder<EmailContext>()
                  .UseSqlServer(new SqlConnection(conn));


                    using (var mailContext = new EmailContext(_emailContext.Options))
                    {


                        try
                        {
                            mailContext.Emails.Add(mail);
                            await mailContext.SaveChangesAsync();
                        }
                        catch (Exception e)
                        {
                            return BadRequest();
                        }

                    }
                }
                else
                {

                    var result = _emailContext.Emails.SingleOrDefault(b => b.MID == list.MID);
                    if (result != null)
                    {
                        try
                        {
                            result.Event = list.Event;
                            await _emailContext.SaveChangesAsync();
                        }
                        catch (Exception e)
                        {
                            return BadRequest();

                        }

                    }


                }



                return await Task.FromResult(list);
                
            }
            else return BadRequest();
            // Convert the string to a JSON object
          

        }

        private bool MessageExists(string id)
        {
            return _emailContext.Emails.Any(e => e.MID == id);
        }

    }
}
