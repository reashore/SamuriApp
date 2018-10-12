using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using SamuriApp.Domain;

namespace SamuriApp.Data
{
    public class SamuriDbContext : DbContext
    {
        public static readonly LoggerFactory MyConsoleLoggerFactory = new LoggerFactory(new[]
        {
            new ConsoleLoggerProvider(
                (category, level) => category == DbLoggerCategory.Database.Command.Name && level == LogLevel.Information, true)
        });

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
            optionsBuilder.UseLoggerFactory(MyConsoleLoggerFactory);

            //base.OnConfiguring(optionsBuilder);
        }
    }
}
