using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;

namespace GWS_MVC
{
    public class HelperClass
    {
        public const double defaultTemp = 99.0f;
        
        #region Enum für Konfiguration Key/Value
        public enum KonfigurationsSchluessel:int
        {
            GasAnbieter=1,          // Key für ausgewählten Gas-Anbieter
            WasserAnbieter=2,       // Key für ausgewählten Wasser-Anbieter
            StromAnbieter = 3       // Key für ausgewählten Strom-Anbieter
        }
        #endregion

        #region Ausschneiden eines Teil-Strings ab/bis einer bestimmten Position in einem String
        public static string GetStringBetween(string strSource, string strStart, string strEnd)
        {
            int Start, End;
            if (strSource.Contains(strStart) && strSource.Contains(strEnd))
            {
                Start = strSource.IndexOf(strStart, 0) + strStart.Length;
                End = strSource.IndexOf(strEnd, Start);
                return strSource.Substring(Start, End - Start);
            }
            else
            {
                return "";
            }
        }
        #endregion

        public static void DebugOutput(string strDebugText)
        {
            try
            {
                System.Diagnostics.Debug.WriteLine(strDebugText + Environment.NewLine);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write(ex.Message + Environment.NewLine);
            }
        }
    }
}
