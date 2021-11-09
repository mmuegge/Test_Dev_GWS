using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace GWS_MVC.Models
{
    public class Wasser_tarif
    {
        [Column("ID_Anbieter")]                     // so heisst Spalte in DB
        public int Id { get; set; }                 // im Programm wird die Spalte "Id" genannt
        public string Anbieter { get; set; }
    }
}
