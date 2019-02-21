using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using streekbieren_avond_backend.Models;

namespace streekbieren_avond_backend.Controllers
{
    [Route("api/streekbieren")]
    public class StreekbierenController : Controller
    {
        private List<Streekbier> bieren = new List<Streekbier>()
        {
            new Streekbier() { Naam = "Tongerloo", Percentage = 7.5d
                , Brouwerij = brouwerijen[0] },
            new Streekbier() { Naam = "Westmalle", Percentage = 8.2d
                , Brouwerij = brouwerijen[2] }
        };

        private static List<Brouwerij> brouwerijen = new List<Brouwerij>()
        {
            new Brouwerij() { Naam = "Brouwerij Van der ginste", Locatie = "Bellegem", DatumOpgericht = "0001-01-01T00:00:00" },
            new Brouwerij() { Naam = "Duvel Moortgat", Locatie = "Puurs", DatumOpgericht = "0001-01-01T00:00:00" },
            new Brouwerij() { Naam = "Brouwerij uuuuh", Locatie = "Het land van geen idee", DatumOpgericht = "0001-01-01T00:00:00" },
            new Brouwerij() { Naam = "Brouwerij van Orval", Locatie = "Villers-devant-orval", DatumOpgericht = "0001-01-01T00:00:00" },
            new Brouwerij() { Naam = "Brouwerij De Halve Maan", Locatie = "Brugge", DatumOpgericht = "0001-01-01T00:00:00" },
            new Brouwerij() { Naam = "Brouwerij Van Steenberghe", Locatie = "Ertvelde", DatumOpgericht = "0001-01-01T00:00:00" },

        };
        
        [HttpGet]
        public IEnumerable<Streekbier> GetAll()
        {
            // GET-call voor alle streekbieren
            return bieren;
        }

        [HttpGet("{naam}")]
        public Streekbier Get(string naam)
        {
            // GET-call voor 1 streekbier (op basis van naam)
            return bieren.FirstOrDefault(bier => bier.Naam == naam);
        }

        [HttpPost]
        public Streekbier Insert([FromBody]Streekbier streekbier)
        {
            // POST-call voor 1 streekbier toe te voegen
            bieren.Add(streekbier);
            return streekbier;
        }

        [HttpPut("{naam}")]
        public Streekbier Update(string naam, [FromBody]Streekbier streekbier)
        {
            // PUT-call voor 1 streekbier te wijzigen (op basis van naam)
            var index = bieren.FindIndex(bier => bier.Naam == naam);
            if (index != -1)
            {
                bieren[index] = streekbier;
                return bieren.FirstOrDefault(bier => bier == streekbier);
            }
            return null;

        }

        [HttpDelete("{naam}")]
        public void Delete(string naam)
        {
            // DELETE-call om 1 streekbier te verwijderen (op basis van naam)
            bieren.Remove(bieren.FirstOrDefault(bier => bier.Naam == naam));
        }
    }
}