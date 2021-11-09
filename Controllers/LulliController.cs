using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GWS_MVC.Models;

namespace GWS_MVC.Controllers
{
    public class LulliController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SpeicherDaten(LulliModel model)
        {

            return View("Index", model);
        
        }
    }
}