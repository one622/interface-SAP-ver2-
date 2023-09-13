using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookListRazor.Model
{
    public class ApplicationDbContext:DbContext
    {
        public class ApplicationContext : DbContext
        {
            public ApplicationContext(DbContextOptions options) : base(options) { }

            public DbSet<Farmarea> Farmarea { get; set; }
        }

    }
}
