using INTEX2.Models;
using INTEX2.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.ML.OnnxRuntime;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace INTEX2.Controllers
{
    public class HomeController : Controller
    {
        //private InferenceSession _session { get; set; }
        
        private ICrashesRepository _repo { get; set; }

        public HomeController(ICrashesRepository temp)
        {
            _repo = temp;
            //_session = session;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DataSummary(int pageNum = 1)
        {

            int pageSize = 50;

            var yeet = new CrashesViewModel
            {
                Crashes = _repo.Crashes
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalNumCrashes = _repo.Crashes.Count(),
                    CrashesPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };

            return View(yeet);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpGet]
        public IActionResult Predict()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Predict(int dui, int teens, int restraint, int old, int distracted, int drowsy, string myCounty)
        {
            
            int Beaver = 0;
            int BoxElder = 0;
            int Cache = 0;
            int Carbon = 0;
            int Daggett = 0;
            int Davis = 0;
            int Duchesne = 0;
            int Emery = 0;
            int Garfield = 0;
            int Grand = 0;
            int Iron = 0;
            int Juab = 0;
            int Kane = 0;
            int Millard = 0;
            int Morgan = 0;
            int Piute = 0;
            int Rich = 0;
            int SaltLake = 0;
            int SanJuan = 0;
            int Sanpete = 0;
            int Sevier = 0;
            int Summit = 0;
            int Tooele = 0;
            int Uintah = 0;
            int Utah = 0;
            int Wasatch = 0;
            int Washington = 0;
            int Wayne = 0;
            int Weber = 0;

            List<String> Counties = new List<String>();
            Counties.Add("Beaver");
            Counties.Add("BoxElder");
            Counties.Add("Cache");
            Counties.Add("Carbon");
            Counties.Add("Daggett");
            Counties.Add("Davis");
            Counties.Add("Duchesne");
            Counties.Add("Emery");
            Counties.Add("Garfield");
            Counties.Add("Grand");
            Counties.Add("Iron");
            Counties.Add("Juab");
            Counties.Add("Kane");
            Counties.Add("Millard");
            Counties.Add("Morgan");
            Counties.Add("Piute");
            Counties.Add("Rich");
            Counties.Add("SaltLake");
            Counties.Add("SanJuan");
            Counties.Add("Sanpete");
            Counties.Add("Sevier");
            Counties.Add("Summit");
            Counties.Add("Tooele");
            Counties.Add("Uintah");
            Counties.Add("Utah");
            Counties.Add("Wasatch");
            Counties.Add("Washington");
            Counties.Add("Wayne");
            Counties.Add("Weber");
            foreach (string county in Counties)
            {
                if(myCounty == "Beaver")
                {
                    Beaver = 1;
                }
                else if(myCounty == "BoxElder")
                {
                    BoxElder = 1;
                }
                else if (myCounty == "Cache")
                {
                    Cache = 1;
                }
                else if (myCounty == "Carbon")
                {
                    Carbon = 1;
                }
                else if (myCounty == "Daggett")
                {
                    Daggett = 1;
                }
                else if (myCounty == "Davis")
                {
                    Davis = 1;
                }
                else if (myCounty == "Duchesne")
                {
                    Duchesne = 1;
                }
                else if (myCounty == "Emery")
                {
                    Emery = 1;
                }
                else if (myCounty == "Garfield")
                {
                    Garfield = 1;
                }
                else if (myCounty == "Grand")
                {
                    Grand = 1;
                }
                else if (myCounty == "Iron")
                {
                    Iron = 1;
                }
                else if (myCounty == "Juab")
                {
                    Juab = 1;
                }
                else if (myCounty == "Kane")
                {
                    Kane = 1;
                }
                else if (myCounty == "Millard")
                {
                    Millard = 1;
                }
                else if (myCounty == "Morgan")
                {
                    Morgan = 1;
                }
                else if (myCounty == "Piute")
                {
                    Piute = 1;
                }
                else if (myCounty == "Rich")
                {
                    Rich = 1;
                }
                else if (myCounty == "SaltLake")
                {
                    SaltLake = 1;
                }
                else if (myCounty == "SanJuan")
                {
                    SanJuan = 1;
                }
                else if (myCounty == "Sanpete")
                {
                    Sanpete = 1;
                }
                else if (myCounty == "Sevier")
                {
                    Sevier = 1;
                }
                else if (myCounty == "Summit")
                {
                    Summit = 1;
                }
                else if (myCounty == "Tooele")
                {
                    Tooele = 1;
                }
                else if (myCounty == "Uintah")
                {
                    Uintah = 1;
                }
                else if (myCounty == "Utah")
                {
                    Utah = 1;
                }
                else if (myCounty == "Wasatch")
                {
                    Wasatch = 1;
                }
                else if (myCounty == "Washington")
                {
                    Washington = 1;
                }
                else if (myCounty == "Wayne")
                {
                    Wayne = 1;
                }
                else if (myCounty == "Weber")
                {
                    Weber = 1;
                }
            }

            
            return View();
        }
    }
}
