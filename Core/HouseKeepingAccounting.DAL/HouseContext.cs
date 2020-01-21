using HouseKeepingAccounting.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace HouseKeepingAccounting.DAL
{
    public class HouseContext : DbContext
    {
        public HouseContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Counter> Counters { get; set; }

        public DbSet<House> Houses { get; set; }

        public DbSet<Indication> Indications { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<House>()
                .HasIndex(u => new { u.CityName, u.HomeNumber, u.StreetName})
                .IsUnique();
        }
    }
}