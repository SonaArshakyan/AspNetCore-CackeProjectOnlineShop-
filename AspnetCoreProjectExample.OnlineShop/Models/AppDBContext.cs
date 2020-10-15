using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetCoreProjectExample.OnlineShop.Models
{
    //DbContext=>IdentityDBContext.
    //It is  teh base class for the entityFrameCore context to use with identity. The identityUser is a built-in class that can be used to represent a user in identity.
    //It allows to use IdentityClass and capture extra properties. also for that we need another migration =>!.
    public class AppDBContext : IdentityDbContext<IdentityUser>
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }
        public DbSet<Pie> Pies { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 1, CategoryName = "Chees cacke" });
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 2, CategoryName = "White cacke" });
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 3, CategoryName = "Black cacke" });

            modelBuilder.Entity<Pie>().HasData(new Pie
            {
                PieId = 1,
                Name = "Apple Pie",
                Prices = 12,
                InStock = true,
                ShortDescription = "Our Famous apple pies",
                LongDescription = "Lorem jan",
                ImageUrl = "~/ images / cacke.jpg"
            });
            modelBuilder.Entity<Pie>().HasData(new Pie
            {
                PieId = 2,
                Name = "Apple Pie",
                Prices = 12,
                InStock = true,
                ShortDescription = "Our Famous apple pies",
                LongDescription = "Lorem jan",
                CategoryId = 1,
                ImageUrl = "~/ images / cacke.jpg"

            });
            modelBuilder.Entity<Pie>().HasData(new Pie
            {
                PieId = 3,
                Name = "Apple Pie",
                Prices = 12,
                InStock = true,
                ShortDescription = "Our Famous apple pies",
                LongDescription = "Lorem jan",
                CategoryId = 2,
                ImageUrl = "~/ images / cacke.jpg"
            });
            modelBuilder.Entity<Pie>().HasData(new Pie
            {
                PieId = 4,
                Name = "Apple Pie",
                Prices = 12,
                InStock = true,
                IsPieOfWeek = true,
                ShortDescription = "Our Famous apple pies",
                LongDescription = "Lorem jan",
                CategoryId = 3,
                ImageUrl = "~/ images / cacke.jpg"
            });

        }
    }
}
