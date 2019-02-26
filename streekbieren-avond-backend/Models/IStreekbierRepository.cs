using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace streekbieren_avond_backend.Models
{
    public interface IStreekbierRepository
    {
        Streekbier GetBy(string naam);
        IEnumerable<Streekbier> GetAll();
        void Add(Streekbier bier);
        void Delete(Streekbier bier);
        void SaveChanges();
    }
}
