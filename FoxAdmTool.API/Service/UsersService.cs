using FoxAdmTool.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoxAdmTool.API.Service
{


    public interface IUsersService
    {
        Task<List<User>> GetAllAsync();
        Task<User> GetAsync(int id);
        Task<User> UserInfo(string cpf);
        Task<Object> GetAllUserInfo(int id);
        Task<Object> GetAllUserInfoCpf(string cpf);
    }
    public class UsersService : IUsersService
    {
        private readonly ShopContext _context;
        public UsersService(ShopContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }
        public async Task<List<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }
        public async Task<User> GetAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                throw new Exception("user doesnt exist");
            }
            return user;
        }
        public async Task<User> UserInfo(string cpf)
        {
            var us = await _context.Users.FirstOrDefaultAsync(x => x.Cpf == cpf);
            if (us == null)
                throw new Exception("user doesnt exist");
            return us;
        }


        public async Task<Object> GetAllUserInfo(int id)
        {
            var user = await GetAsync(id);
            if (user == null)
                throw new Exception("user doesnt exist");


            var query = await (from up in _context.UserProducts
                               join p in _context.Products on up.ProductId equals p.ProductId
                               where up.UserId == id
                               select new
                               {
                                   price = p.Price,
                                   sku = p.Sku,
                                   name = p.Name,
                                   prodid = up.ProductId,

                               }).ToListAsync();

            var respObj = new
            {
                query,
                uid = user.UserId,
                nameuser = user.Name,
                emailuser = user.Email,
                cpfuser = user.Cpf
            };
            return respObj;

        }

        public async Task<Object> GetAllUserInfoCpf(string cpf)
        {
            User user = await UserInfo(cpf);
            if (user == null)
                throw new Exception("user doesnt exist");

            var query = await ( from up in _context.UserProducts
                               join p in _context.Products on up.ProductId equals p.ProductId
                               where up.UserId == user.UserId
                               select new
                               {
                                   price = p.Price,
                                   sku = p.Sku,
                                   name = p.Name,
                                   prodid = up.ProductId
                               }).ToListAsync();

            var respObj = new
            {
                query,
                uid = user.UserId,
                nameuser = user.Name,
                emailuser = user.Email,
                cpfuser = user.Cpf
            };
            return respObj;
        }
    }
}
