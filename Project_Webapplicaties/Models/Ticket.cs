using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Webapplicaties.Models
{
    public class Ticket
    {
        public int TicketID { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public decimal Prijs { get; set; }
        [Required]
        public bool Vip { get; set; }
        public string Beschrijving { get; set; }

        public int? BestellingID { get; set; }

        public Bestelling? Bestelling { get; set; }
    }
}
