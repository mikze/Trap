using System.Collections.Generic;

namespace WebApplication4.Models
{
    public interface ITrapRepo
    {
        IEnumerable<Trap> GetAllTraps();
        bool SaveAll();
        void AddTrap(Trap newTrap);
        void RemoveTrap(Trap id);
    }
}