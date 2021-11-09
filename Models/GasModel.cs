using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GWS_MVC.Models
{
    public class GasModel
    {
        public IEnumerable<Gas_tarif>  AnbieterDaten { get; set; }
        public IEnumerable<Gas_zaehlerstand> ZaehlerDaten { get; set; }

        public int Id { get; set; }
        public string Anbieter { get; set; }

        public DateTime Ablesedatum { get; set; }
        public DateTime Ableseuhrzeit { get; set; }

        public Double Zaehlerstand { get; set; }
                
        public Double Aussentemperatur { get; set; }
        public Double Innentemperatur { get; set; }

        public String Bemerkung { get; set; }

        public int KonfigKey { get; set; }        // Konfigurationskey

    }
}
