using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using INTEX2.Models;

namespace INTEX2.Components
{
    public class CountyViewComponent : ViewComponent
    {
        private ICrashesRepository repo { get; set; }

        public CountyViewComponent (ICrashesRepository temp)
        {
            repo = temp;
        }

        //Video 6 of mission 8 start here. I have made the view component but I have not made the view
        public IViewComponentResult Invoke()
        {

            ViewBag.SelectedCounty = RouteData?.Values["COUNTY_NAME"];

            var causes = repo.Crashes
                .Select(x => x.COUNTY_NAME)
                .Distinct()
                .OrderBy(x => x);

            return View(causes);
        }

    }
}
