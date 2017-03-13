using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication4.Models
{
    public class TrapRepo : ITrapRepo
    {
        private TrapContext _context;
        private ILogger<TrapRepo> _logger;

        public TrapRepo(TrapContext context,ILogger<TrapRepo> logger)
        {
            _logger = logger;
            _context = context;
        }

        public void AddTrap(Trap newTrap)
        {
            _context.Add(newTrap);
        }

        public IEnumerable<Trap> GetAllTraps()
        {
            try
            {
                return _context.Traps.OrderBy(t => t.Id).ToList();
            }
            catch(Exception ex)
            {
                _logger.LogError("Can't get list of traps from db",ex);
                return null;
            }
        }

        public void RemoveTrap(Trap toRemove)
        {
            //znajdz po id i wyslij do remove obiekt!
            _context.Remove(toRemove);
            this.SaveAll();
        }

        public bool SaveAll()
        {
            return _context.SaveChanges() > 0;
        }

        
    }
}
