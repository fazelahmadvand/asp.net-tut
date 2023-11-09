using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Bulky.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Bulky.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action", DisplayIndex = 1 },
                new Category { Id = 2, Name = "SciFi", DisplayIndex = 2 },
                new Category { Id = 3, Name = "History", DisplayIndex = 3 }
                );

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Title = "First Book",
                    Author = "John Wick",
                    ISBN = "SWD132309",
                    Description = "How you doing?",
                    ListPrice = 99,
                    Price = 95,
                    Price50 = 90,
                    Price100 = 85,
                    CategoryId = 1,
                    ImageUrl = string.Empty,

                },
                new Product
                {
                    Id = 2,
                    Title = "Love Book",
                    Author = "IDK",
                    ISBN = "SJKCPE2309",
                    Description = "Some Day You Will Have It Too",
                    ListPrice = 97,
                    Price = 92,
                    Price50 = 87,
                    Price100 = 82,
                    CategoryId = 1,
                    ImageUrl = string.Empty,

                },
                new Product
                {
                    Id = 3,
                    Title = "Work",
                    Author = "A Man Life",
                    ISBN = "SWKVLR09",
                    Description = "A Man Will Do Everything For When Someone Enter His Life Be Good",
                    ListPrice = 79,
                    Price = 65,
                    Price50 = 60,
                    Price100 = 55,
                    CategoryId = 1,
                    ImageUrl = string.Empty,

                }


                );


        }


    }
}
