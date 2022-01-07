using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Webapplicaties.ViewModels
{
    public class DeleteTicketViewModel
    {
        public decimal Prijs { get; set; }
        public bool Vip { get; set; }
        public string Beschrijving { get; set; }
        public string Type { get; set; }
    }
}
