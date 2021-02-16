using FoxAdmTool.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoxAdmTool.API.Service
{

    public interface IProductsService
    {
        Task<Product> GetAsync(int id);
        Task<List<Product>> GetAllAsync();
        //Task<bool> AddProductAsync(Product product);
        Task<bool> AddProduct(Product product);
        Task<bool> DeleteProductAsync(int id);
    }
    public class ProductsService : IProductsService
    {
        private readonly ShopContext _context;
        public ProductsService(ShopContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        public async Task<Product> GetAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if(product == null)
            {
                throw new Exception("product doesnt exist ");
            }
            return product;
        }
        public async Task<List<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<bool> AddProduct(Product product)
        {
            //var result = _context.Products.AddAsync(product);
            //await _context.SaveChangesAsync();
            //return product;
            var result = _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return result.IsCompleted;

        }


        public async Task<bool> DeleteProductAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if(product == null)
            {
                throw new Exception("product doesnt exist ");
            }
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
