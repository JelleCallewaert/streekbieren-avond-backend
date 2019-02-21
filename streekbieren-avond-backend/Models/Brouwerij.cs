using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace streekbieren_avond_backend.Models
{
    public class Brouwerij
    {
        public string Naam { get; set; }
        public string Locatie { get; set; }
        public DateTime datumOpgericht { get; set; }
    }
}
