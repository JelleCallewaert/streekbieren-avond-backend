using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace streekbieren_avond_backend.Models
{
    public class Streekbier
    {
        public string Naam { get; set; }
        public double Percentage { get; set; }

        public BrouwerijClass Brouwerij { get; set; }
        
        public class BrouwerijClass
        {
            public string Naam { get; set; }
            public string Locatie { get; set; }
            public string DatumOpgericht { get; set; }
        }
    }
}
