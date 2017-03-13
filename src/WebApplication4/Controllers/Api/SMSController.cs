using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication4.ViewModels;
using Microsoft.Extensions.Logging;
using WebApplication4.Models;
using Newtonsoft.Json.Linq;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication4.Controllers.Api
{
    [Route("api/sms")]
    public class SMSController : Controller
    {
        private ILogger<TrapController> _logger;
        private ITrapRepo _repo;
        private SmsJson smsjson;

        public SMSController(ITrapRepo repo, ILogger<TrapController> logger)
        {
            _logger = logger;
            _repo = repo;
            smsjson = new SmsJson();
        }
        [HttpGet("")]
        public string GetSMS()
        {
            return "OK";
        }
        [HttpPost("")]
        public string GetSMS(SmsViewModel sms)
        {
             string str = sms.sms_text;
          
            try
            {
                smsjson.StringToJson(str);

                var Traps = _repo.GetAllTraps().Where(x => x.TrapId == smsjson.Id).OrderBy(x => x.UserName);

                if(Traps.Count() == 1)
                {
                    var _trap = Traps.Last();
                    _trap.Rats = smsjson.Rats;
                    _trap.Battery = smsjson.Battery;

                    _repo.SaveAll();
                    return "OK";
                }
                else
                {
                    return "nie OK";
                }

            }
            catch(Exception ex)
            {
                _logger.LogError("Failed to edit trap", ex);
                return "OK" + ex;//"Cannot to modify object cuz: " + ex;
            }
        }
    }
}
