using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using DAL.Models;
namespace DAL.Data
{


    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<CarDetails> CarDetails { get; set; }
        public DbSet<RentalDetails> RentalDetails { get; set; }


    }

}
