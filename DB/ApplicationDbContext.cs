using ICTStrypes.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ICTStrypes.DB
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Location> Locations { get; set; }
        public DbSet<ChargePoint> ChargePoints { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }

}
