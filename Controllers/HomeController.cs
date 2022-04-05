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
    }
}
