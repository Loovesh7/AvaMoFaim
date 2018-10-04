using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MoFaimWebService.Entities;

namespace MoFaimWebService.Helpers
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Restaurants> Restaurants { get; set; }
        public DbSet<MenuItems> MenuItems { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<UserRating> UserRating { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRating>()
                .HasKey(c => new { c.UserId,c.RestaurantId });
        }
    }
}
