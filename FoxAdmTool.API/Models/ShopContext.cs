using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace FoxAdmTool.API.Models
{
    //context class is used to query or save data to the database.
    public class ShopContext : DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options) : base(options)
        {

        }

        //entities: class that maps to a database table.
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserProduct> UserProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserProduct>()
                .HasKey(up => new { up.UserId, up.ProductId });
            modelBuilder.Entity<UserProduct>()
               .HasOne(up => up.User)
               .WithMany(u => u.UserProducts)
               .HasForeignKey(bc => bc.UserId);
            modelBuilder.Entity<UserProduct>()
               .HasOne(up => up.Product)
               .WithMany(p => p.UserProducts)
               .HasForeignKey(bc => bc.ProductId);

            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<UserProduct>().ToTable("UserProduct");
            //modelBuilder.Entity<User_Products>().HasKey(up => new { up.UserId, up.ProductId });
            modelBuilder.Seed();
        }
    }
}
