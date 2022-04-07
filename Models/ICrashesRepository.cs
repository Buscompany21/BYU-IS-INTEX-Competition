using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INTEX2.Models
{
    public interface ICrashesRepository
    {
        IQueryable<Crash> Crashes { get; }
        public void Save(Crash c);
        public void Add(Crash c);
        public void Delete(Crash c);
    }
}
