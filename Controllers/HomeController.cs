using INTEX2.Models;
using INTEX2.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.ML.OnnxRuntime;
using Microsoft.ML.OnnxRuntime.Tensors;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace INTEX2.Controllers
{
    public class HomeController : Controller
    {
        public List<String> Counties { get; set; }
        private InferenceSession _session { get; set; }

        private ICrashesRepository _repo { get; set; }

        public List<string> GetCounties()
        {
            List<string> Counties = new List<String>();
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
            return Counties;
        }
        public HomeController(ICrashesRepository temp, InferenceSession session)
        {
            _repo = temp;
            _session = session;
            Counties = GetCounties();
        }

        public IActionResult Index()
        {
            return View();
        }

        //[HttpGet]
        //public IActionResult Test(int pageNum = 1)
        //{
        //    int pageSize = 50;

        //    var yeet = new CrashesViewModel
        //    {
        //        CrashTest = _repo.Crashes,

        //        Crashes = _repo.Crashes
        //        .Skip((pageNum - 1) * pageSize)
        //        .Take(pageSize),

        //        PageInfo = new PageInfo
        //        {
        //            TotalNumCrashes = _repo.Crashes.Count(),

        //            CrashesPerPage = pageSize,
        //            CurrentPage = pageNum
        //        }
        //    };
        //    return View(yeet);
        //}

        //[HttpPost]
        //public IActionResult Test(string city, string county, string why, int pageNum = 1)
        //{
        //    int pageSize = 50;

        //    var yeet = new CrashesViewModel
        //    {
        //        CrashTest = _repo.Crashes,

        //        Crashes = _repo.Crashes
        //        .Where(p => p.CITY == city)
        //        .Where(p => p.COUNTY_NAME == county)
        //        .Skip((pageNum - 1) * pageSize)
        //        .Take(pageSize),

        //        PageInfo = new PageInfo
        //        {
        //            TotalNumCrashes = (
        //                county == null & city == null
        //                    ? _repo.Crashes.Count()
        //                    : _repo.Crashes.Where(x => x.COUNTY_NAME == county || county == null)
        //                    .Where(x => x.CITY == city || city == null).Count()),

        //            CrashesPerPage = pageSize,
        //            CurrentPage = pageNum
        //        }
        //    };
        //    return View(yeet);
        //}

        public IActionResult DataSummary(string cRASH_SEVERITY_ID, string cOUNTY_NAME, int pageNum = 1)
        {

            int pageSize = 25;

            var yeet = new CrashesViewModel
            {

                Crashes = _repo.Crashes
                .Where(p => p.COUNTY_NAME != "")
                .Where(p => p.COUNTY_NAME == cOUNTY_NAME || cOUNTY_NAME == null)
                .Where(p => p.CRASH_SEVERITY_ID == cRASH_SEVERITY_ID || cRASH_SEVERITY_ID == null)
                
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PageInfo = new PageInfo
                {

                    TotalNumCrashes = 
                        (cOUNTY_NAME == null & cRASH_SEVERITY_ID == null
                            ? _repo.Crashes.Count() 
                            : _repo.Crashes.Where(x => x.COUNTY_NAME == cOUNTY_NAME || cOUNTY_NAME == null)
                            .Where(x => x.CRASH_SEVERITY_ID == cRASH_SEVERITY_ID || cRASH_SEVERITY_ID == null).Count()),

                    //TotalNumCrashes =
                    //    (cOUNTY_NAME == null & cRASH_SEVERITY_ID == null
                    //        ? _repo.Crashes.Count()
                    //        : _repo.Crashes.Where(x => x.COUNTY_NAME == cOUNTY_NAME || cOUNTY_NAME == null)
                    //        .Where(x => x.CRASH_SEVERITY_ID == cRASH_SEVERITY_ID || cRASH_SEVERITY_ID == null).Count()),


                    CrashesPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };

            return View(yeet);
        }

        public IActionResult DataSummaryGrid(string cRASH_SEVERITY_ID, string cOUNTY_NAME, int pageNum = 1)
        {

            int pageSize = 25;

            var yeet = new CrashesViewModel
            {

                Crashes = _repo.Crashes
                .Where(p => p.COUNTY_NAME != "")
                .Where(p => p.COUNTY_NAME == cOUNTY_NAME || cOUNTY_NAME == null)
                .Where(p => p.CRASH_SEVERITY_ID == cRASH_SEVERITY_ID || cRASH_SEVERITY_ID == null)

                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PageInfo = new PageInfo
                {

                    TotalNumCrashes =
                        (cOUNTY_NAME == null & cRASH_SEVERITY_ID == null
                            ? _repo.Crashes.Count()
                            : _repo.Crashes.Where(x => x.COUNTY_NAME == cOUNTY_NAME || cOUNTY_NAME == null)
                            .Where(x => x.CRASH_SEVERITY_ID == cRASH_SEVERITY_ID || cRASH_SEVERITY_ID == null).Count()),

                    //TotalNumCrashes =
                    //    (cOUNTY_NAME == null & cRASH_SEVERITY_ID == null
                    //        ? _repo.Crashes.Count()
                    //        : _repo.Crashes.Where(x => x.COUNTY_NAME == cOUNTY_NAME || cOUNTY_NAME == null)
                    //        .Where(x => x.CRASH_SEVERITY_ID == cRASH_SEVERITY_ID || cRASH_SEVERITY_ID == null).Count()),


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
        /*[HttpGet]
        public IActionResult Predict()
        {
            return View();
        }*/
        [HttpGet]
        public IActionResult Predict(int crashId, long dui, long teens, long restraint, long old, long distracted, long drowsy, long night, string myCounty)
        {
            long Beaver = 0;
            long BoxElder = 0;
            long Cache = 0;
            long Carbon = 0;
            long Daggett = 0;
            long Davis = 0;
            long Duchesne = 0;
            long Emery = 0;
            long Garfield = 0;
            long Grand = 0;
            long Iron = 0;
            long Juab = 0;
            long Kane = 0;
            long Millard = 0;
            long Morgan = 0;
            long Piute = 0;
            long Rich = 0;
            long SaltLake = 0;
            long SanJuan = 0;
            long Sanpete = 0;
            long Sevier = 0;
            long Summit = 0;
            long Tooele = 0;
            long Uintah = 0;
            long Utah = 0;
            long Wasatch = 0;
            long Washington = 0;
            long Wayne = 0;
            long Weber = 0;
            foreach (string county in Counties)
            {
                if (myCounty == "Beaver")
                {
                    Beaver = 1;
                }
                else if (myCounty == "BoxElder")
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

            CrashData data = new CrashData();
            data.Dui = dui;
            data.Teen = teens;
            data.Old = old;
            data.Drowsy = drowsy;
            data.Distracted = distracted;
            data.Restraint = restraint;
            data.Night = night;
            data.Beaver = Beaver;
            data.BoxElder = BoxElder;
            data.Cache = Cache;
            data.Daggett = Daggett;
            data.Davis = Davis;
            data.Duchesne = Duchesne;
            data.Emery = Emery;
            data.Garfield = Garfield;
            data.Grand = Grand;
            data.Iron = Iron;
            data.Juab = Juab;
            data.Kane = Kane;
            data.Millard = Millard;
            data.Morgan = Morgan;
            data.Piute = Piute;
            data.Rich = Rich;
            data.SaltLake = SaltLake;
            data.SanJuan = SanJuan;
            data.Sanpete = Sanpete;
            data.Sevier = Sevier;
            data.Summit = Summit;
            data.Tooele = Tooele;
            data.Uintah = Uintah;
            data.Utah = Utah;
            data.Wasatch = Wasatch;
            data.Washington = Washington;
            data.Wayne = Wayne;
            data.Weber = Weber;


            var result = _session.Run(new List<NamedOnnxValue>
            {
                NamedOnnxValue.CreateFromTensor("int_input", data.AsTensor())
            });

            Tensor<string> score = result.First().AsTensor<string>();
            var predictionResult = new PredictionResult { CrashSeverityId = score.First() };
            ViewBag.Result = predictionResult.CrashSeverityId;
            Crash Crash = _repo.Crashes.Single(p => p.CRASH_ID == crashId);

            return View(Crash);
        }

        [HttpGet]
        public IActionResult Add()
        {

            ViewBag.CITY = _repo.Crashes.Where(x => x.CITY != "***  ERROR  ***").Where(x => x.CITY != "").Select(x => x.CITY).Distinct().OrderBy(x => x);
            ViewBag.COUNTY_NAME = _repo.Crashes.Select(x => x.COUNTY_NAME).Distinct().OrderBy(x => x);
            return View();
        }

        [HttpPost]
        public IActionResult Add(Crash c)
        {
            if (ModelState.IsValid)
            {
                _repo.Add(c);

                int pageSize = 50;
                int page = 1;

                var yeet = new CrashesViewModel
                {
                    Crashes = _repo.Crashes
                    .Take(pageSize),

                    PageInfo = new PageInfo
                    {
                        TotalNumCrashes = _repo.Crashes.Count(),
                            

                        CrashesPerPage = pageSize,
                        CurrentPage = page
                    }
                };

                return View("DataSummary", yeet);

            }
            else
            {
                ViewBag.CITY = _repo.Crashes.Where(x => x.CITY != "***  ERROR  ***").Where(x => x.CITY != "").Select(x => x.CITY).Distinct().OrderBy(x => x);
                ViewBag.COUNTY_NAME = _repo.Crashes.Select(x => x.COUNTY_NAME).Distinct().OrderBy(x => x);
                return View("DataSummary");
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {

            ViewBag.CITY = _repo.Crashes.Where(x => x.CITY != "***  ERROR  ***").Where(x => x.CITY != "").Select(x => x.CITY).Distinct().OrderBy(x => x);
            ViewBag.COUNTY_NAME = _repo.Crashes.Select(x => x.COUNTY_NAME).Distinct().OrderBy(x => x);

            var crash = _repo.Crashes.Single(x => x.CRASH_ID == id);
            return View(crash);
        }

        [HttpPost]
        public IActionResult Edit(Crash c)
        {
            if (ModelState.IsValid)
            {
                _repo.Save(c);

                int pageSize = 50;
                int page = 1;

                var yeet = new CrashesViewModel
                {
                    Crashes = _repo.Crashes
                    .Take(pageSize),

                    PageInfo = new PageInfo
                    {
                        TotalNumCrashes = _repo.Crashes.Count(),


                        CrashesPerPage = pageSize,
                        CurrentPage = page
                    }
                };
                return View("Datasummary", yeet);

            }
            else
            {
                ViewBag.CITY = _repo.Crashes.Where(x => x.CITY != "***  ERROR  ***").Where(x => x.CITY != "").Select(x => x.CITY).Distinct().OrderBy(x => x);
                ViewBag.COUNTY_NAME = _repo.Crashes.Select(x => x.COUNTY_NAME).Distinct().OrderBy(x => x);
                return View(c);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var crash = _repo.Crashes.Single(x => x.CRASH_ID == id);
            return View(crash);
        }
        [HttpPost]
        public IActionResult Delete(Crash c)        {
            _repo.Delete(c);
            return RedirectToAction("Datasummary");
        }
    }
}
