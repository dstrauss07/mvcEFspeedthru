using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace SpeedThruLibrary
{
    public class SpeedDbContext:DbContext
    {
        public SpeedDbContext(DbContextOptions<SpeedDbContext> options) : base(options)
        {

        }

        public DbSet<Truck> Truck { get; set; }
        public DbSet<Sedan> Sedan { get; set; }
    }
}
