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
    public class Opdracht3Controller : Controller
    {
        private const string V = "Januari";

        public string GetAbbreviatedMonthName { get; private set; }

        // POST: /<controller>/

        public IActionResult Opdracht3_3(int lengte, int breedte, int hoogte)
        {
            Double inhoud = lengte * breedte * hoogte;
            ViewBag.Info = inhoud;
            return View();
        }

        // POST: /<controller>/

        public IActionResult Opdracht3_7(string Ingevuld)
        {

            if (Ingevuld == null)
            {
                Ingevuld = "Dit werk!";
            }

            Ingevuld = Regex.Replace(Ingevuld, "[aeiou]", "*", RegexOptions.IgnoreCase);

            ViewBag.Info = Ingevuld;
            return View();
        }

        //POST: /<controller>/
        public IActionResult Opdracht3_11(string informatie)
        {
            DateTime now = DateTime.Now;



            int JaarNu = DateTime.Now.Year;
            string Maand = now.Month.ToString();
            string dag = now.DayOfWeek.ToString();
            int DagMaand = now.Day;
            int WeekNummer = GetIso8601WeekOfYear(now);
            int DagJaar = now.DayOfYear;



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
