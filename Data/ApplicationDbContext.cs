using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WorldMapApi.Models;

namespace WorldMapApi.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public DbSet<Continent> Continent { get; set; }

        public DbSet<Country> Country { get; set; }

        public DbSet<SubRegion> SubRegion { get; set; }

        public DbSet<Stats> Stats { get; set; }
    }
}
