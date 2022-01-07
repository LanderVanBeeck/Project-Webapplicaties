using Project_Webapplicaties.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Webapplicaties.ViewModels
{
    public class TicketListViewModel
    {
        public string TicketSearch { get; set; }
        public List<Ticket> Tickets { get; set; }
    }
}
