using Microsoft.EntityFrameworkCore;

namespace FoxAdmTool.API.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Grunge Skater Jeans", Sku = "AWMGSJ", Price = 68 },
                new Product { Id = 2, Name = "Polo Shirt", Sku = "AWMPS", Price = 35},
                new Product { Id = 3, Name = "Skater Graphic T-Shirt", Sku = "AWMSGT", Price = 33},
                new Product { Id = 4, Name = "Slicker Jacket", Sku = "AWMSJ", Price = 125},
                new Product { Id = 5, Name = "Thermal Fleece Jacket", Sku = "AWMTFJ", Price = 60},
                new Product { Id = 6, Name = "Unisex Thermal Vest", Sku = "AWMUTV", Price = 95},
                new Product { Id = 7, Name = "V-Neck Pullover", Sku = "AWMVNP", Price = 65},
                new Product { Id = 8, Name = "V-Neck Sweater", Sku = "AWMVNS", Price = 65},
                new Product { Id = 9, Name = "V-Neck T-Shirt", Sku = "AWMVNT", Price = 17},
                new Product { Id = 10, Name = "Bamboo Thermal Ski Coat", Sku = "AWWBTSC", Price = 99},
                new Product { Id = 11, Name = "Cross-Back Training Tank", Sku = "AWWCTT", Price = 0},
                new Product { Id = 12, Name = "Grunge Skater Jeans", Sku = "AWWGSJ", Price = 68},
                new Product { Id = 13, Name = "Slicker Jacket", Sku = "AWWSJ", Price = 125},
                new Product { Id = 14, Name = "Stretchy Dance Pants", Sku = "AWWSDP", Price = 55},
                new Product { Id = 15, Name = "Ultra-Soft Tank Top", Sku = "AWWUTT", Price = 22},
                new Product { Id = 16, Name = "Unisex Thermal Vest", Sku = "AWWUTV", Price = 95},
                new Product { Id = 17, Name = "V-Next T-Shirt", Sku = "AWWVNT", Price = 17},
                new Product { Id = 18, Name = "Blueberry Mineral Water", Sku = "MWB", Price = 2.8M},
                new Product { Id = 19, Name = "Lemon-Lime Mineral Water", Sku = "MWLL", Price = 2.8M},
                new Product { Id = 20, Name = "Orange Mineral Water", Sku = "MWO", Price = 2.8M},
                new Product { Id = 21, Name = "Peach Mineral Water", Sku = "MWP", Price = 2.8M},
                new Product { Id = 22, Name = "Raspberry Mineral Water", Sku = "MWR", Price = 2.8M},
                new Product { Id = 23, Name = "Strawberry Mineral Water", Sku = "MWS", Price = 2.8M},
                new Product { Id = 24, Name = "In the Kitchen with H+ Sport", Sku = "PITK", Price = 24.99M},
                new Product { Id = 25, Name = "Calcium 400 IU (150 tablets)", Sku = "SC400", Price = 9.99M},
                new Product { Id = 26, Name = "Flaxseed Oil 100 mg (90 capsules)", Sku = "SFO100", Price = 12.49M},
                new Product { Id = 27, Name = "Iron 65 mg (150 caplets)", Sku = "SI65", Price = 13.99M},
                new Product { Id = 28, Name = "Magnesium 250 mg (100 tablets)", Sku = "SM250", Price = 12.49M},
                new Product { Id = 29, Name = "Multi-Vitamin (90 capsules)", Sku = "SMV", Price = 9.99M},
                new Product { Id = 30, Name = "Vitamin A 10,000 IU (125 caplets)", Sku = "SVA", Price = 11.99M},
                new Product { Id = 31, Name = "Vitamin B-Complex (100 caplets)", Sku = "SVB", Price = 12.99M},
                new Product { Id = 32, Name = "Vitamin C 1000 mg (100 tablets)", Sku = "SVC", Price = 9.99M},
                new Product { Id = 33, Name = "Vitamin D3 1000 IU (100 tablets)", Sku = "SVD3", Price = 12.49M});

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Email = "adam@example.com" },
                new User { Id = 2, Email = "barbara@example.com" });
        }
    }
}
