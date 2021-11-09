using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GWS_MVC.Models
{
    public class Strom_zaehlerstand
    {
        [Key]
        public int ID_Tag { get; set; }

        public int ID_Anbieter { get; set; }

        [NotMapped]
        public string Anbieter { get; set; }

        public DateTime Ablesetag { get; set; }
        public Double? Zaehlerstand { get; set; }
        public DateTime Uhrzeit { get; set; }
        public Double? Temperatur_aussen { get; set; }
        public Double? Temperatur_innen { get; set; }
        public string Bemerkungen { get; set; }
    }
}
