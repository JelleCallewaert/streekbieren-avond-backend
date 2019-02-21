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
        private List<Streekbier> lijst = new List<Streekbier>()
        {
            new Streekbier() { Naam = "Tongerloo", Percentage = 7.5d, Brouwerij = new Brouwerij() { Naam = "Abdij Tongerloo", Locatie = "Tongerloo", DatumOpgericht = new DateTime()} },
            new Streekbier() { Naam = "Westmalle", Percentage = 8.2d, Brouwerij = new Brouwerij() { Naam = "Abdij Westmalle", Locatie = "Westmalle", DatumOpgericht = new DateTime()} }
        };
        
        [HttpGet]
        public IEnumerable<Streekbier[]> GetAll()
        {
            return lijst;
        }

        [HttpGet("{naam}")]
        public Streekbier Get(string naam)
        {
            return lijst.FirstOrDefault(bier => bier.Naam == naam);
        }

        [HttpPost]
        public Streekbier Insert([FromBody]Streekbier streekbier)
        {
            lijst.Add(streekbier);
            return streekbier;
        }

        [HttpPut("{naam}")]
        public void Update(string naam, [FromBody]Streekbier streekbier)
        {
            var index = lijst.FindIndex(bier => bier.Naam == naam);
            lijst[index] = streekbier;
        }

        [HttpDelete("{naam}")]
        public void Delete(string naam)
        {
            lijst.Remove(lijst.FirstOrDefault(bier => bier.Naam == naam));
        }
    }
}