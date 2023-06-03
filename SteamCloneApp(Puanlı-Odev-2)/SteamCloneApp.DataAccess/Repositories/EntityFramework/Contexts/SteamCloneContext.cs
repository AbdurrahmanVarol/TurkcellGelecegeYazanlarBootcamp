using Microsoft.EntityFrameworkCore;
using SteamCloneApp.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SteamCloneApp.DataAccess.Repositories.EntityFramework.Contexts
{
    public class SteamCloneContext : DbContext
    {
        public SteamCloneContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Game> Games { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Review> Publishers { get; set; }
        public DbSet<Developer> Developers { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
