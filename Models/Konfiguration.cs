using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GWS_MVC.Models
{
    public class Konfiguration
    {
        [Key]
        public int ID { get; set; }             // DB-ID
        public int Key { get; set; }            // Schlüssel des Parameters
        public string Value { get; set; }       // Wert des Parameters
    }
}
