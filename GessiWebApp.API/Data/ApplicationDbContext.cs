using GessiWebApp.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Shared.Models;
using System.Collections.Generic;
using System.Reflection;

namespace GessiWebApp.API.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Movement> Movements { get; set; }
        public DbSet<Mission> Missions { get; set; }
        public DbSet<Classification> Classifications { get; set; }
        public DbSet<User> Users { get; set; }
    }
}