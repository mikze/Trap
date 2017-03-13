using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication4.ViewModels
{
    public class TrapViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 4)]
        public string UserName { get; set; }
        public int TrapId { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;
        public double longitude { get; set; }
        public double latitude { get; set; }
    }
}
