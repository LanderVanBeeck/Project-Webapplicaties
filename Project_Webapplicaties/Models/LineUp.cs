using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Webapplicaties.Models
{
    public class LineUp
    {
        public int LineUpID { get; set; }

        public int ArtiestID { get; }

        [DataType(DataType.Date)]

        public DateTime Datum { get; set; }

        [DataType(DataType.Time)]

        public DateTime Tijd { get; set; }
    }
}
