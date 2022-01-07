using Project_Webapplicaties.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Webapplicaties.ViewModels
{
    public class TimeTableListViewModel
    {
       public List<Artiest> Artiest { get; set; }
        public List<LineUp> LineUp { get; set; }
    }
}
