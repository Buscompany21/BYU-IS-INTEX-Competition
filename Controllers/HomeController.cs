using INTEX2.Models;
using INTEX2.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace INTEX2.Controllers
{
    public class HomeController : Controller
    {
        private ICrashesRepository _repo { get; set; }

        public HomeController(ICrashesRepository temp)
        {
            _repo = temp;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DataSummary(string CRASH_SEVERITY_ID, string COUNTY_NAME, int pageNum = 1)
        {

            int pageSize = 50;

            var yeet = new CrashesViewModel
            {
                Crashes = _repo.Crashes
                .Where(p => p.CRASH_SEVERITY_ID == CRASH_SEVERITY_ID || CRASH_SEVERITY_ID == null)
                .Where(p => p.COUNTY_NAME == COUNTY_NAME || COUNTY_NAME == null)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalNumCrashes = 
                        (COUNTY_NAME == null & CRASH_SEVERITY_ID == null
                            ? _repo.Crashes.Count() 
                            : _repo.Crashes.Where(x => x.COUNTY_NAME == COUNTY_NAME || COUNTY_NAME == null)
                            .Where(x => x.CRASH_SEVERITY_ID == CRASH_SEVERITY_ID || CRASH_SEVERITY_ID == null).Count()),

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
    }
}
