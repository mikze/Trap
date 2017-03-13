using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication4.Controllers.Api
{
    [Route("api/remove")]
    public class RemoveController : Controller
    {
        [HttpGet("")]
        public bool xD()
        {
            return false;
        }

        [HttpPost("")]
        public bool Remove(int id)
        {
            return true;
        }
    }
}
