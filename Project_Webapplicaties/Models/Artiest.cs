using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Webapplicaties.Models
{
    public class Artiest
    {
        public int ArtiestID { get; set; }
        [Required]
        public string Naam { get; set; }
        [Required]
        public string Genre { get; set; }

        public int? LineUpID { get; set; }

        public LineUp LineUp { get; set; }
    }
}
