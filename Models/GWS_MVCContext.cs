using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;

namespace GWS_MVC.Models
{
    public class GWS_MVCContext : DbContext
    {
        public DbSet<Gas_tarif> Gas_tarif { get; set; }                 // Gas_tarif --> Name der Tabelle  
        public DbSet<Strom_tarif> Strom_tarif { get; set; }             // Strom_tarif --> Name der Tabelle  
        public DbSet<Wasser_tarif> Wasser_tarif { get; set; }             // Wasser_tarif --> Name der Tabelle  
        public DbSet<Gas_zaehlerstand> Gas_zaehlerstand { get; set; }   // Gas_zaehlerstand --> Name der Tabelle
        public DbSet<Strom_zaehlerstand> Strom_zaehlerstand { get; set; }   // Strom_zaehlerstand --> Name der Tabelle
        public DbSet<Wasser_zaehlerstand> Wasser_zaehlerstand { get; set; }   // Wasser_zaehlerstand --> Name der Tabelle

        public DbSet<Konfiguration> Konfiguration { get; set; }         // Konfiguration --> Name der Tabelle

        public GWS_MVCContext(DbContextOptions<GWS_MVCContext> options)
            : base(options)
        {

        }

        
    }
}
