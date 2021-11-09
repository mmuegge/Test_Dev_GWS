using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace GWS_MVC.Models
{
    public class Temperaturen
    {
        private Double aussentemp;
        private Double innentemp;

        // auf null Nachkommastellen runden
        public Double Aussentemperatur {
            get { return (Math.Round(aussentemp, 0)); }
            set { aussentemp = value; }
        }

        // auf null Nachkommastellen runden
        public Double Innentemperatur {
            get { return (Math.Round(innentemp, 0)); }
            set { innentemp = value; }
        }
        
    }
}
