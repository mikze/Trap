using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication4.Models
{
    public class Trap
    {
        public int Id { get; set; }
        public int TrapId { get; set; }
        public string UserName { get; set; }
        public int Battery { get; set; }
        public int Rats { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastMadified { get; set; }
        public DateTime FirstRat { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
