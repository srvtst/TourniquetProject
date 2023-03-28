using Microsoft.EntityFrameworkCore;
using Tourniquet.Domain.Entities;

namespace Tourniquet.Persistence.Context
{
    public class TurnstileDbContext : DbContext
    {
        public DbSet<Turnstile> Turnstiles { get; set; }
        public DbSet<Person> Persons { get; set; }

        public TurnstileDbContext(DbContextOptions<TurnstileDbContext> options) : base(options)
        {
        }
    }
}