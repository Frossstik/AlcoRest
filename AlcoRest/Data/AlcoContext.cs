using AlcoRest.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace AlcoRest.Data
{
    public class AlcoContext : DbContext
    {
        public AlcoContext(DbContextOptions<AlcoContext> options) : base(options)
        {

        }

        public DbSet<Category> categories { get; set; }
        public DbSet<Product> products { get; set; }
    }
}
