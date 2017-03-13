using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication4.Models
{
    public class TrapContext : DbContext
    {
        public TrapContext()
        {
            Database.EnsureCreated();
        }

        public DbSet<Trap> Traps { get; set; }

        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server=tcp:trap.database.windows.net,1433;Initial Catalog=Traps;Persist Security Info=False;User ID=mikze;Password=Symfoniac++2;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            optionsBuilder.UseSqlServer(connectionString);

            base.OnConfiguring(optionsBuilder);
        }
    }
}
