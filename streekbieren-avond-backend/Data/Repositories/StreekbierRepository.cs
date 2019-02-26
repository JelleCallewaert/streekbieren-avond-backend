using Microsoft.EntityFrameworkCore;
using streekbieren_avond_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace streekbieren_avond_backend.Data.Repositories
{
    public class StreekbierRepository: IStreekbierRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Streekbier> _bieren;

        public StreekbierRepository(ApplicationDbContext context)
        {
            _context = context;
            _bieren = context.Streekbieren;
        }

        public Streekbier GetBy(string naam)
        {
            return _bieren.Include(b => b.Brouwerij).SingleOrDefault(bier => bier.Naam == naam);
        }

        public IEnumerable<Streekbier> GetAll()
        {
            return _bieren.Include(b => b.Brouwerij).ToList();
        }

        public void Add(Streekbier bier)
        {
            _bieren.Add(bier);
        }

        public void Update(string naam, Streekbier nieuwBier)
        {
            _bieren.Update(nieuwBier);
        }

        public void Delete(Streekbier bier)
        {
            _bieren.Remove(bier);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
