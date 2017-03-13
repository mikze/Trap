using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class AppController : Controller
    {
        private ITrapRepo _context;

        public AppController(ITrapRepo context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddTrap()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult ModifyTraps()
        {
            ViewData["Message"] = "Your application description page.";
            var traps = _context.GetAllTraps();

            return View(traps);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
