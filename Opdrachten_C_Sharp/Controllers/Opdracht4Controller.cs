using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Opdrachten_C_Sharp.Controllers
{
    public class Opdracht4Controller : Controller
    {
        // POST: /<controller>/

        public IActionResult Opdracht4_1(int invoer1, int invoer2)
        {
            if(invoer1 == invoer2)
            {
                string antwoord = invoer1 + " is evengroot als " + invoer2;
                ViewBag.Info = antwoord;
            }
            else if (invoer1 > invoer2)
            {
                string antwoord = invoer1 + " is groter dan " + invoer2;
                ViewBag.Info = antwoord;
            }
            else if (invoer1 < invoer2)
            {
                string antwoord = invoer1 + " is kleiner dan " + invoer2;
                ViewBag.Info = antwoord;
            }
            else
            {
                string antwoord = "Foutive invoer";
                ViewBag.Info = antwoord;
            }

            return View();
        }

        // POST: /<controller>/

        public IActionResult Opdracht4_2(int invoer1, int invoer2, int invoer3)
        {
            if (invoer1 > invoer3)
            {
                if (invoer2 > invoer3)
                {
                    string antwoord = " Getal 3 is het kleinst";
                    ViewBag.Info = antwoord;
                }
            }
            else if (invoer2 > invoer3)
            {
                if (invoer1 > invoer3)
                {
                    string antwoord = "Getal 3 is het kleinst";
                    ViewBag.Info = antwoord;
                }
            }
            else if (invoer3 > invoer1)
            {
                if (invoer3 > invoer2)
                {
                    string antwoord = " Getal 3 is het grootst";
                    ViewBag.Info = antwoord;
                }
            }
            else if (invoer3 > invoer2)
            {
                if (invoer3 > invoer1)
                {
                    string antwoord = "Getal 3 is het grootst";
                    ViewBag.Info = antwoord;
                }
            }
            else if (invoer3 != invoer1)
            {
                if (invoer3 != invoer2)
                {
                    string antwoord = " Getal 3 is gelijk aan de andere getallen";
                    ViewBag.Info = antwoord;
                }
            }
            else if (invoer3 != invoer2)
            {
                if (invoer3 != invoer1)
                {
                    string antwoord = "Getal 3 is gelijk aan de andere getallen";
                    ViewBag.Info = antwoord;
                }
            }
            else
            {
                string antwoord = "Foutive antwoord";
                ViewBag.Info = antwoord;
            }


            return View();
        }
        // POST: /<controller>/

        public IActionResult Opdracht4_5(string vak, string cijfer)
        {


            if (cijfer == "A")
            {
                string antwoord = "Je hebt een voldoende voor " + vak;
                ViewBag.Info = antwoord;
            }
            else if (cijfer == "B")
            {
                string antwoord = "Je hebt een voldoende voor " + vak;
                ViewBag.Info = antwoord;
            }
            else if (cijfer == "C")
            {
                string antwoord = "Je hebt een voldoende voor " + vak;
                ViewBag.Info = antwoord;
            }
            else if (cijfer == "D")
            {
                string antwoord = "Je hebt een onvoldoende voor " + vak;
                ViewBag.Info = antwoord;
            }
            else if (cijfer == "E")
            {
                string antwoord = "Je hebt een onvoldoende voor " + vak;
                ViewBag.Info = antwoord;
            }
            else if (cijfer == "F")
            {
                string antwoord = "Je hebt een onvoldoende voor " + vak;
                ViewBag.Info = antwoord;
            }
            else
            {
                string antwoord = "Foutive invoer";
                ViewBag.Info = antwoord;
            }

            return View();
        }
        // POST: /<controller>/

        public IActionResult Opdracht4_13 (double automorf)
        {

            double kwadraat = automorf * automorf;
            double lastdigit = (kwadraat % 10);

            if (lastdigit == automorf)
            {
                string antwoord = automorf + " is een automorf getal want " + automorf + " in het kwadraat = " + kwadraat + " het laatste getal hiervan is " + lastdigit;
                ViewBag.Info = antwoord;
            }
            else
            {
                string antwoord = automorf + " is geen automorf getal want " + automorf + " in het kwadraat = " + kwadraat + " het laatste getal hier van is " + lastdigit;
                ViewBag.Info = antwoord;
            }

            return View();
        }

        // POST: /<controller>/

        public IActionResult Opdracht4_16(string informatie)
        {
            DateTime now = DateTime.Now;



            int JaarNu = DateTime.Now.Year;
            string Maand = now.Month.ToString();
            string dag = now.DayOfWeek.ToString();
            int DagMaand = now.Day;
            int WeekNummer = GetIso8601WeekOfYear(now);
            int DagJaar = now.DayOfYear;
            int DagWeek = (int)now.DayOfWeek;

            if (now.DayOfWeek == DayOfWeek.Sunday || now.DayOfWeek == DayOfWeek.Saturday)
            {
                string antwoord = "Het is weekend";
                ViewBag.Weekend = antwoord;
            }
            else
            {
                string antwoord = "Het is geen weekend";
                ViewBag.Weekend = antwoord;
            }

          
            ViewBag.Info = "Het jaartal nu is : " + JaarNu + "</br>" + "Het is nu de maand : " + Maand + "</br>" + "De dag vandaag is : " + dag + "</br>" + "De dag van de maand is : " + DagMaand + "</br>" + "De weeknummer is : " + WeekNummer + "</br>" + "Dag van het jaar :" + DagJaar;
            return View();

        }

        // This presumes that weeks start with Monday.// Week 1 is the 1st week of the year with a Thursday in it.
        public int GetIso8601WeekOfYear(DateTime time)
        {
            // Seriously cheat. If its Monday, Tuesday or Wednesday, then it'll // be the same week# as whatever Thursday, Friday or Saturday are,// and we always get those right
            DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(time);
            if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
            {
                time = time.AddDays(3);
            }



            // Return the week of our adjusted day
            return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(time, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }

    }
}
