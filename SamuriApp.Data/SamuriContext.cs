using Microsoft.EntityFrameworkCore;
using SamuriApp.Domain;

namespace SamuriApp.Data
{
    public class SamuriDbContext : DbContext
    {
        public DbSet<Samuri> Samuris { get; set; }
        public DbSet<Battle> Battles { get; set; }
        public DbSet<Quote> Quotes { get; set; }
    }
}
