using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using INTEX2.Models;

namespace INTEX2.Components
{
    public class SeverityViewComponent : ViewComponent
    {
        private ICrashesRepository repo { get; set; }

        public SeverityViewComponent(ICrashesRepository temp)
        {
            repo = temp;
        }

        //Video 6 of mission 8 start here. I have made the view component but I have not made the view
        public IViewComponentResult Invoke()
        {

            ViewBag.SelectedSeverity = RouteData?.Values["CRASH_SEVERITY_ID"];

            var causes = repo.Crashes
                .Where(x => x.CRASH_SEVERITY_ID != "")
                .Select(x => x.CRASH_SEVERITY_ID)
                .Distinct()
                .OrderBy(x => x);

            return View(causes);
        }
    }
}
