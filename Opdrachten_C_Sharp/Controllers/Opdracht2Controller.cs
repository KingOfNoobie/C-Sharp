using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Opdrachten_C_Sharp.Controllers
{
    public class Opdracht2Controller : Controller
    {
        
        // POST: /<controller>/
        
        public IActionResult Opdracht2_1(Double lengte, Double gewicht)
        {
            Double bmi = gewicht / (lengte * lengte);
            ViewBag.Info = bmi;
            return View();
        }
        // POST: /<controller>/

        public IActionResult Opdracht2_2(DateTime geboorte, String naam)
        {

            String Naam = naam;

            DateTime now = DateTime.Now;
            int leeftijd = now.Year - geboorte.Year;
            if (now < geboorte.AddYears(leeftijd))
                leeftijd--;
            ViewBag.Info = Naam + " is "+ leeftijd + " jaar oud.";
            return View();
        }
    }
}
