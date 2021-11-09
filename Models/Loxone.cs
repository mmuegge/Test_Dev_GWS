using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;

namespace GWS_MVC.Models
{
    public class Loxone
    {
        private  static readonly Temperaturen temperaturen = new Temperaturen();              // Temperaturen

        public static Temperaturen LeseLoxoneDaten(out string message)
        {
            string strResponce = string.Empty;
            message = string.Empty;
            CultureInfo culture;
            NumberStyles style;
            culture = CultureInfo.CreateSpecificCulture("en-GB");
            style = NumberStyles.Number;
            RestClient rClient = new RestClient()
            {
                EndPoint = RestClient.EndpointAussenTemp        // Endpoint=Aussentemperatur
            };

            strResponce = rClient.MakeRequest();
            //strResponce = "value=\"" + "22xx" + "°\"";   // test test
            if ((!String.IsNullOrEmpty(strResponce)) && !strResponce.Contains("error"))
            {
                string strValue= HelperClass.GetStringBetween(strResponce, "value=\"", "°\"");
                bool success= Double.TryParse(strValue,style, culture, out double number);
                temperaturen.Aussentemperatur = success == true ? number : 0;
            }
            else
            {
                temperaturen.Aussentemperatur = 99;
                message = "Keine Antwort von Loxone! " + "Fehlermeldung: " + strResponce;
            }

            rClient.EndPoint = RestClient.EndpointInnenTemp;

            strResponce = rClient.MakeRequest();
            if ((!String.IsNullOrEmpty(strResponce)) && !strResponce.Contains("error"))
            {
                string strValue = HelperClass.GetStringBetween(strResponce, "value=\"", "°\"");
                bool success = Double.TryParse(strValue, style, culture, out double number);
                temperaturen.Innentemperatur = success == true ? number : 0;
            }
            else
            {
                temperaturen.Innentemperatur = 99;
                message = "Keine Antwort von Loxone! " + "Fehlermeldung: " + strResponce;
            }

            return temperaturen;
        }
    }
}
