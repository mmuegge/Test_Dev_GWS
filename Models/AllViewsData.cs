using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GWS_MVC.Models
{
    public static class AllViewsData
    {
        // Gas
        public static int GasAnbieterID { get; set; }
        public static DateTime GasLetztesDatum { get; set; }
        public static DateTime GasLetzteAbleseUhrzeit { get; set; }
        public static double GasZaehlerstand { get; set; }
        public static double GasInnentemperatur { get; set; }
        public static double GasAussentemperatur { get; set; }
        public static string GasBemerkung { get; set; }

        // Wasser
        public static int WasserAnbieterID { get; set; }
        public static DateTime WasserLetztesDatum { get; set; }
        public static DateTime WasserLetzteAbleseUhrzeit { get; set; }
        public static double WasserZaehlerstand { get; set; }
        public static double WasserInnentemperatur { get; set; }
        public static double WasserAussentemperatur { get; set; }
        public static string WasserBemerkung { get; set; }

        public static double WasserZaehlerstand_aussen { get; set; }

        // Strom
        public static int StromAnbieterID { get; set; }
        public static DateTime StromLetztesDatum { get; set; }
        public static DateTime StromLetzteAbleseUhrzeit { get; set; }
        public static double StromZaehlerstand { get; set; }
        public static double StromInnentemperatur { get; set; }
        public static double StromAussentemperatur { get; set; }
        public static string StromBemerkung { get; set; }
    }
}
