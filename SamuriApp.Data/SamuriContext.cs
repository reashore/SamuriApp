using Microsoft.EntityFrameworkCore;
using SamuriApp.Domain;

namespace SamuriApp.Data
{
    public class SamuriDbContext : DbContext
    {
        public DbSet<Samuri> Samuris { get; set; }
        public DbSet<Battle> Battles { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<SamuriBattle> SamuriBattles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SamuriBattle>()
                .HasKey(k => new {k.BattleId, k.SamuriId});

            //modelBuilder.Entity<Samuri>().Property(p => p.SecretIdentity).IsRequired();

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            const string connectionString = "Server=localhost; Database=SamuriDB; Trusted_Connection=true;";
            optionsBuilder.UseSqlServer(connectionString, options => options.MaxBatchSize(10));
            optionsBuilder.EnableSensitiveDataLogging();

            //base.OnConfiguring(optionsBuilder);
        }
    }
}
