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

        public void Save(Crash c)
        {
            _context.Update(c);
            _context.SaveChanges();
        }

        public void Add(Crash c)
        {
            _context.Add(c);
            _context.SaveChanges();
        }

        public void Delete(Crash c)
        {
            _context.Remove(c);
            _context.SaveChanges();
        }
    }
}
