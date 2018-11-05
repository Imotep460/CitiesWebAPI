using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CitiesWebAPI.Models;

namespace CitiesWebAPI.Models
{
    public class CitiesWebAPIContext : DbContext
    {
        public CitiesWebAPIContext (DbContextOptions<CitiesWebAPIContext> options)
            : base(options)
        {
        }

        public DbSet<Cities> Cities { get; set; }

        public DbSet<PointsOfInterest> PointsOfInterest { get; set; }
    }
}
