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

        private readonly IStreekbierRepository _streekbierRepo;

        public StreekbierenController(IStreekbierRepository streekbierRepo)
        {
            _streekbierRepo = streekbierRepo;
        }

        [HttpGet("brouwerijen")]
        public IEnumerable<BrouwerijClass> GetBrouwerijen()
        {
            IEnumerable<Streekbier> bieren = _streekbierRepo.GetAll();
            var brouwers = from b in bieren select b.Brouwerij;
            return brouwers;
        }

        [HttpGet("brouwerijen/{naam}")]
        public BrouwerijClass GetBrouwerij(string naam)
        {
            IEnumerable<Streekbier> bieren = _streekbierRepo.GetAll();
            var brouwers = from b in bieren select b.Brouwerij;
            return brouwers.First(brouwer => brouwer.Naam == naam);
        }
        
        [HttpGet]
        public IEnumerable<Streekbier> GetAll()
        {
            // GET-call voor alle streekbieren
            return _streekbierRepo.GetAll();
        }

        [HttpGet("{naam}")]
        public Streekbier Get(string naam)
        {
            // GET-call voor 1 streekbier (op basis van naam)
            return _streekbierRepo.GetBy(naam);
        }

        [HttpPost]
        public Streekbier Insert([FromBody]Streekbier streekbier)
        {
            // POST-call voor 1 streekbier toe te voegen
            _streekbierRepo.Add(streekbier);
            return streekbier;
        }

        [HttpPut("{naam}")]
        public Streekbier Update(string naam, [FromBody]Streekbier streekbier)
        {

            Streekbier bier = null;
            
                bier = _streekbierRepo.GetBy(naam);
                bier = streekbier;
                _streekbierRepo.SaveChanges();

            return _streekbierRepo.GetBy(streekbier.Naam);

        }

        [HttpDelete("{naam}")]
        public Streekbier Delete(string naam)
        {
            // DELETE-call om 1 streekbier te verwijderen (op basis van naam)
            Streekbier teVerwijderen = _streekbierRepo.GetBy(naam);
            _streekbierRepo.Delete(teVerwijderen);
            return teVerwijderen;
        }
    }
}