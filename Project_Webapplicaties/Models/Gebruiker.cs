using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Webapplicaties.Models
{
    public class Gebruiker
    {   [Required]
        public int GebruikerID { get; set; }

        public string Naam { get; set; }

        public string Voornaam { get; set; }

        public string Straat { get; set; }

        public int Huisnr { get; set; }

        public string Woonplaats { get; set; }
        [Required]
        public string Mail { get; set; }
        [Required]
        public string Wachtwoord { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime GeboorteDatum { get; set; }

        public ICollection<Bestelling> Bestellingen { get; set; }
    }
}
