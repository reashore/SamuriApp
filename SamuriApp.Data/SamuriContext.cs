﻿using Microsoft.EntityFrameworkCore;
using SamuriApp.Domain;

namespace SamuriApp.Data
{
    public class SamuriDbContext : DbContext
    {
        public DbSet<Samuri> Samuris { get; set; }
        public DbSet<Battle> Battles { get; set; }
        public DbSet<Quote> Quotes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SamuriBattle>()
                .HasKey(k => new {k.BattleId, k.SamuriId});

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            const string connectionString = "Server=localhost; Database=SamuriDB; Trusted_Connection=true;";
            optionsBuilder.UseSqlServer(connectionString);

            //base.OnConfiguring(optionsBuilder);
        }
    }
}
