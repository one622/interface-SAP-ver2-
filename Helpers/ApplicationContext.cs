using BookListRazor.Model;
using Microsoft.EntityFrameworkCore;

namespace BookListRazor.Helpers
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options) { }

        public DbSet<Farmarea> Farmarea { get; set; }
    }
}
