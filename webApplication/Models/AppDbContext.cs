using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
namespace webApplication.Models
{
    

    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<CarDetails> CarDetails { get; set; }

    }

}
