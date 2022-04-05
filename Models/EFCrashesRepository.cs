using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INTEX2.Models
{
    public class EFCrashesRepository : ICrashesRepository
    {
        private IntexDbContext _context { get; set; }

        public EFCrashesRepository (IntexDbContext temp)
        {
            _context = temp;
        }
        public IQueryable<Crash> Crashes => _context.Crashes;
    }
}
