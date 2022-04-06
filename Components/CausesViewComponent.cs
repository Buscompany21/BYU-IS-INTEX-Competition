using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using INTEX2.Models;

namespace INTEX2.Components
{
    public class CausesViewComponent : ViewComponent
    {
        private ICrashesRepository repo { get; set; }

        public CausesViewComponent (ICrashesRepository temp)
        {
            repo = temp;
        }

        //Video 6 of mission 8 start here. I have made the view component but I have not made the view
        public IViewComponentResult Invoke()
        {
            var causes = repo.Crashes
                .Select(x => x.COUNTY_NAME)
                .Distinct()
                .OrderBy(x => x);

            return View(causes);
        }

    }
}
