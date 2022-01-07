﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Webapplicaties.Models
{
    public class Gebruiker
    {
        public int GebruikerID { get; set; }

        public string Naam { get; set; }

        public string Voornaam { get; set; }

        public string Straat { get; set; }

        public int Huisnr { get; set; }

        public string Woonplaats { get; set; }

        public string Mail { get; set; }

        public string Wachtwoord { get; set; }

        [DataType(DataType.Date)]

        public DateTime GeboorteDatum { get; set; }

        public ICollection<Ticket> Tickets { get; set; }
    }
}
