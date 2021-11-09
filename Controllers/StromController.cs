using GWS_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace GWS_MVC.Controllers
{
    public class StromController : Controller
    {
        #region lokale Variablen
        private readonly GWS_MVCContext ctx;                                // ETF Context
        private Konfiguration konfigKeyValue = new Konfiguration();         // Konfigurationsdaten
        public StromModel stromModel = new StromModel();                    // StromModel
        public Temperaturen temperaturen = new Temperaturen();              // Temperaturen
        #endregion

        #region Konstruktor StromController
        public StromController(GWS_MVCContext ctx)
        {
            this.ctx = ctx;
        }
        #endregion

        #region Holen der Viewdaten (Loxone Temperaturen)
        public Temperaturen LeseLoxoneTemp()
        {
            temperaturen = Loxone.LeseLoxoneDaten(out string fehlermeldung);  // Auslesen der Daten von Loxone
            ViewBag.Message = fehlermeldung;
            return temperaturen;
        }
        #endregion

        #region ActionResult Index Model mit Daten füllen
        public IActionResult Index()
        {
            DateTime jetzt = DateTime.Now;
            konfigKeyValue = ctx.Konfiguration.Where(id => id.Key == (int)HelperClass.KonfigurationsSchluessel.StromAnbieter).FirstOrDefault();       // auslesen der gespeicherten Anbieter-ID
            bool success = Int32.TryParse(konfigKeyValue.Value, out int number);               // prüfen ob ausgelesener Wert zu parsen ist

            stromModel.Id = success == true ? number : 0;                                     // wenn parsen erfolgreich gespeicherten Wert aus der Datenbank übernehmen sonst id=0
            stromModel.KonfigKey = (int)HelperClass.KonfigurationsSchluessel.StromAnbieter;

            stromModel.Ablesedatum = jetzt;
            stromModel.Ableseuhrzeit = jetzt;

            stromModel.AnbieterDaten = ctx.Strom_tarif; // Anbieterdaten aus der Datenbank lesen
            return View(stromModel);
        }
        #endregion

        #region SpeicherDaten in die Datenbank
        [HttpPost]
        public ActionResult SpeicherDaten(StromModel model)
        {
            Strom_zaehlerstand zaehlerstand = new Strom_zaehlerstand
            {
                ID_Anbieter = model.Id,
                Ablesetag = model.Ablesedatum,
                Zaehlerstand = model.Zaehlerstand,
                Uhrzeit = model.Ableseuhrzeit,
                Temperatur_aussen = model.Aussentemperatur,
                Temperatur_innen = model.Innentemperatur,
                Bemerkungen = model.Bemerkung
            };
           
            int count = ctx.Strom_zaehlerstand.Where(x => x.ID_Anbieter == model.Id && x.Ablesetag == model.Ablesedatum).Count();   // hier wird gefiltert

            if (count == 0)                         // der Datensatz ist noch nicht vorhanden
            {
                konfigKeyValue = SpeicherKonfigDaten(Convert.ToString((int)HelperClass.KonfigurationsSchluessel.StromAnbieter), model.Id);        // Auslesen der Konfigurationsdaten und speichern wenn nicht schon gespeichert 1=ausgewählter Strom-Anbieter
                ctx.Strom_zaehlerstand.Add(zaehlerstand);                     // Zufügen des neuen Datensatzes
                ctx.SaveChanges();
                //ViewBag.Message = "Zaehlerstand eingetragen " + model.Ablesedatum.ToShortDateString();
                TempData["Success"] = "Zaehlerstand eingetragen " + model.Ablesedatum.ToShortDateString();      // neu
            }
            else
            {
                //ViewBag.Message = "Datensatz schon vorhanden! " + model.Ablesedatum.ToShortDateString();
                TempData["Error"] = "Nicht gespeichert, Datensatz schon vorhanden! " + model.Ablesedatum.ToShortDateString();      // neu

                StromModel stromModel = new StromModel();
                stromModel = model;
                stromModel.AnbieterDaten = ctx.Strom_tarif; // Anbieterdaten aus der Datenbank lesen

                return View("Index", model);
            }
            stromModel = model;
            stromModel.AnbieterDaten = ctx.Strom_tarif; // Anbieterdaten aus der Datenbank lesen
            //return Redirect("~/Strom"); // auf dem View verbleiben
            return View("Index", model);
        }
        #endregion

        #region Speichern der Konfigurationsdaten
        private Konfiguration SpeicherKonfigDaten(string idConfig, int ausgewaehlterAnbieter)
        {
            bool success = Int32.TryParse(idConfig, out int number);
            if (success)
            {
                konfigKeyValue = ctx.Konfiguration.Where(id => id.Key == number).FirstOrDefault();
            }
            else
            {
                konfigKeyValue.Value = "0";
            }
            if ((konfigKeyValue != null) && (!String.IsNullOrEmpty(konfigKeyValue.Value)))
            {
                if (ausgewaehlterAnbieter != Convert.ToInt32(konfigKeyValue.Value))
                {
                    konfigKeyValue.Value = Convert.ToString(ausgewaehlterAnbieter);
                }
            }
            return konfigKeyValue;
        }
        #endregion






    }
}