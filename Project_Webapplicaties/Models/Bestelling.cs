using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Webapplicaties.Models
{
    public class Bestelling
    {
        public int BestellingID { get; set; }
        public decimal TotaalBedrag { get; set; }
        public int TicketID { get; set; }
        public int GebruikerID { get; set; }
        public Gebruiker Gebruiker { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
    }
}
