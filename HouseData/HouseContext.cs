using Microsoft.EntityFrameworkCore;
using HouseData.Models;

namespace HouseData
{
    public class HouseContext :DbContext
    {
        public HouseContext (DbContextOptions options) :base(options) { }

        public DbSet<Counter> Counters { get; set; }

        public DbSet<House> Houses { get; set; }

        public DbSet<Indication> Indications { get; set; }
    }
}
