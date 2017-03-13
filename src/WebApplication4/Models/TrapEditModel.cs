using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication4.Models
{
    public class TrapEditModel
    {
        public double latitude { get; set; }
        public double longitude { get; set; }
        public string userName { get; set; }
        public int trapId { get; set; }
        public int sendTrapId { get; set; }
    }
}
