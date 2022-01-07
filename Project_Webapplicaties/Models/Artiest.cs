using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Webapplicaties.Models
{
    public class Artiest
    {
        public int ArtiestID { get; set; }

        public string Naam { get; set; }

        public string Genre { get; set; }

        public int LineUpID { get; set; }

        public LineUp LineUp { get; set; }
    }
}
