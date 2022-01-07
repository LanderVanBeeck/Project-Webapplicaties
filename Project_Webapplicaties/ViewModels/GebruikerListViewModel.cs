using Project_Webapplicaties.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Webapplicaties.ViewModels
{
    public class GebruikerListViewModel
    {
        public List<CustomUser> Gebruikers { get; set; }
    }
}
