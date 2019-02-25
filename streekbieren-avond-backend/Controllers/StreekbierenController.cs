using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using streekbieren_avond_backend.Models;
using static streekbieren_avond_backend.Models.Streekbier;

namespace streekbieren_avond_backend.Controllers
{
    [Route("api/streekbieren")]
    public class StreekbierenController : Controller
    {
        private List<Streekbier> bieren = new List<Streekbier>()
        {
            new Streekbier() { Naam = "Tongerloo", Percentage = 7.5d
                , Brouwerij = brouwerijen[7] },
            new Streekbier() { Naam = "Westmalle", Percentage = 8.2d
                , Brouwerij = brouwerijen[6] },
            new Streekbier() { Naam = "Omer", Percentage = 6.8d
                , Brouwerij = brouwerijen[0] },
            new Streekbier() { Naam = "Duvel", Percentage = 6.2d
                , Brouwerij = brouwerijen[1] },
            new Streekbier() { Naam = "No Idea", Percentage = 12.2d
                , Brouwerij = brouwerijen[2] },
            new Streekbier() { Naam = "Brugse Zot", Percentage = 5.9d
                , Brouwerij = brouwerijen[4] },
            new Streekbier() { Naam = "Gentse Tripel", Percentage = 7.2d
                , Brouwerij = brouwerijen[5] },
        };

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

        [HttpGet("brouwerijen")]
        public IEnumerable<BrouwerijClass> GetBrouwerijen()
        {
            return brouwerijen;
        }

        [HttpGet("brouwerijen/{naam}")]
        public BrouwerijClass GetBrouwerij(string naam)
        {
            return brouwerijen.FirstOrDefault(b => b.Naam == naam);
        }
        
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
            var indexBier = bieren.FindIndex(bier => bier.Naam == naam);
            //var indexBrouwerij = brouwerijen.FindIndex(brouwer => brouwer.Naam == streekbier.Brouwerij.Naam);
            //streekbier.Brouwerij = brouwerijen[indexBrouwerij];
            if (indexBier != -1)
            {
                bieren[indexBier] = streekbier;
                return bieren.FirstOrDefault(bier => bier.Naam == streekbier.Naam);
            }
            return null;

        }

        [HttpDelete("{naam}")]
        public Streekbier Delete(string naam)
        {
            // DELETE-call om 1 streekbier te verwijderen (op basis van naam)
            var teVerwijderen = bieren.FirstOrDefault(bier => bier.Naam == naam);
            bieren.Remove(teVerwijderen);
            return teVerwijderen;
        }
    }
}