using streekbieren_avond_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static streekbieren_avond_backend.Models.Streekbier;

namespace streekbieren_avond_backend.Data
{
    public class DataInitializer
    {
        private readonly ApplicationDbContext _context;

        public DataInitializer(ApplicationDbContext context)
        {
            _context = context;
        }

        public void InitializeData()
        {
            _context.Database.EnsureDeleted();
            if (_context.Database.EnsureCreated())
            {
                Streekbier tongerloo = new Streekbier()
                { Naam = "Tongerloo", Percentage = 50.5d, Brouwerij = brouwerijen[7] };
                Streekbier westmalle = new Streekbier()
                { Naam = "Westmalle", Percentage = 8.2d, Brouwerij = brouwerijen[6] };
                Streekbier omer = new Streekbier()
                { Naam = "Omer", Percentage = 6.8d, Brouwerij = brouwerijen[0] };
                Streekbier duvel = new Streekbier()
                { Naam = "Duvel", Percentage = 6.2d, Brouwerij = brouwerijen[1] };
                Streekbier noidea = new Streekbier()
                { Naam = "No Idea", Percentage = 12.2d, Brouwerij = brouwerijen[2] };
                Streekbier brugsezot = new Streekbier()
                { Naam = "Brugse Zot", Percentage = 5.9d, Brouwerij = brouwerijen[4] };
                Streekbier gentsetripel = new Streekbier()
                { Naam = "Gentse Tripel", Percentage = 7.2d, Brouwerij = brouwerijen[5] };

                Streekbier[] bieren = new Streekbier[]
                { tongerloo, westmalle, omer, noidea, duvel, brugsezot, gentsetripel };

                _context.Streekbieren.AddRange(bieren);
                _context.SaveChanges();
            }
        }

        private static List<BrouwerijClass> brouwerijen = new List<BrouwerijClass>()
        {
            new BrouwerijClass() { Naam = "Brouwerij Van der ginste", Locatie = "Bellegem", DatumOpgericht = "0001-01-01T00:00:00" },
            new BrouwerijClass() { Naam = "Duvel Moortgat", Locatie = "Puurs", DatumOpgericht = "0002-01-01T00:00:00" },
            new BrouwerijClass() { Naam = "Brouwerij uuuuh", Locatie = "Het land van geen idee", DatumOpgericht = "0003-01-01T00:00:00" },
            new BrouwerijClass() { Naam = "Brouwerij van Orval", Locatie = "Villers-devant-orval", DatumOpgericht = "0004-01-01T00:00:00" },
            new BrouwerijClass() { Naam = "Brouwerij De Halve Maan", Locatie = "Brugge", DatumOpgericht = "0005-01-01T00:00:00" },
            new BrouwerijClass() { Naam = "Brouwerij Van Steenberghe", Locatie = "Ertvelde", DatumOpgericht = "0006-01-01T00:00:00" },
            new BrouwerijClass() { Naam = "Abdij Van Westmalle", Locatie = "Westmalle", DatumOpgericht = "1906-01-01T00:00:00" },
            new BrouwerijClass() { Naam = "Abdij Van Tongerloo", Locatie = "Tongerloo", DatumOpgericht = "1922-01-01T00:00:00" },
        };
    }
}
