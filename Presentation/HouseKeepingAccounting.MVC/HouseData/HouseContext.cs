using HouseKeepingAccounting.MVC.HouseData.Models;
using Microsoft.EntityFrameworkCore;

namespace HouseKeepingAccounting.MVC.HouseData
{
    public class HouseContext : DbContext
    {
        public HouseContext (DbContextOptions options) :base(options) { }

        public DbSet<Counter> Counters { get; set; }

        public DbSet<House> Houses { get; set; }

        public DbSet<Indication> Indications { get; set; }
    }
}
