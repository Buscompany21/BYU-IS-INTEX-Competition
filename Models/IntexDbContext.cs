using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace INTEX2.Models
{
    public class IntexDbContext : DbContext
    {
        public IntexDbContext(DbContextOptions<IntexDbContext> options) : base(options)
        {
        }
        public DbSet<crash_data> crash_data { get; set; }
    }
}