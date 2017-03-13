using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WebApplication4.Models;
using WebApplication4.ViewModels;

namespace WebApplication4.Controllers.Api
{
    [Route("api/traps")]
    public class TrapController : Controller
    {
        private ILogger<TrapController> _logger;
        private ITrapRepo _repo;

        public TrapController(ITrapRepo repo,ILogger<TrapController> logger)
        {
            _logger = logger;
            _repo = repo;
        }
        [HttpGet("")]
        public JsonResult Get()
        {
            var results = _repo.GetAllTraps();

            return Json(results);
        }

        [HttpPost("")]
        public JsonResult Post([FromBody]TrapViewModel vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //dodawanie do bazy
                    var newTrap = Mapper.Map<Trap>(vm);
                    _logger.LogInformation("Trying to save new trap");
                    _repo.AddTrap(newTrap);

                    if (_repo.SaveAll())
                    { 
                    Response.StatusCode = (int)HttpStatusCode.Created;
                    return Json(Mapper.Map<TrapViewModel>(newTrap));
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to sve new trap",ex);

                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { Message = ex.Message, ModelState = ModelState });
            }

            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return Json(new { Message = "Fail xD", ModelState = ModelState });
        }


        [HttpPut("")]
        public string Remove([FromBody]int id) //usuwanie z bazy
        {
            try
            {
                var Traps = _repo.GetAllTraps().Where(x => x.TrapId == id).OrderBy(x=>x.UserName);

                if(Traps.Count() == 1) 
                {
                    _repo.RemoveTrap(Traps.Last());
                    var toReturn = Traps.Last().UserName;

                    return toReturn;
                }
                else
                {
                    //if more than one result what to do ?
                    var toReturn = "More or less than one result. Trap names:\n";

                    foreach(Trap trap in Traps)
                    {
                         toReturn += trap.UserName += "\n";
                    }

                    return toReturn;
                }
            }
            catch(Exception ex)
            {
                _logger.LogError("Failed to remove trap", ex);
                return "Cannot to remove object cuz: "+ ex;
            }
            
        }

        [HttpPatch("")]
        public string Edit([FromBody]TrapEditModel vm)  //todo: edit trap
        {
            try
            {
                var Traps = _repo.GetAllTraps().Where(x => x.TrapId == vm.sendTrapId);

                if (Traps.Count() == 1)
                {
                    var trap = Traps.Last();

                    trap.Latitude = vm.latitude;
                    trap.Longitude = vm.longitude;


                    trap.UserName = vm.userName;

                    if (vm.trapId != 0)
                        trap.TrapId = vm.trapId;

                    _repo.SaveAll();
                    return Traps.Last().TrapId + "";
                }
                else
                {
                    //if more than one result what to do ?
                    var toReturn = "More or less than one result. Trap names:\n";

                    foreach (Trap trap in Traps)
                    {
                        toReturn += trap.UserName += "\n";
                    }

                    return toReturn;
                }
            }
            catch(Exception ex)
            {
                _logger.LogError("Failed to edit trap", ex);
                return "Cannot to edit object cuz: " + ex;
            }
        }



    }
}
