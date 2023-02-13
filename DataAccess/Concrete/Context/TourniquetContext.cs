using EntitiesLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataAccessLayer.Concrete.Context
{
    public class TourniquetContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Tourniquet> Tourniquets { get; set; }
        protected IConfiguration Configuration { get; set; }
        public TourniquetContext(DbContextOptions<TourniquetContext> context, IConfiguration configuration) : base(context)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}