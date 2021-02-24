using FoxAdmTool.API.Controllers;
using FoxAdmTool.API.Models;
using FoxAdmTool.API.Service;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Xunit;

namespace FoxAdmTool.Tests
{
    public class UsersControllerTest
    {
        UsersController _controller;
        IUsersService _service;
        ShopContext sc;
        
        public UsersControllerTest()
        {
            
        }
       
        [Fact]
        public async Task GetUsers_Success()
        {
            var options = new DbContextOptionsBuilder<ShopContext>()
             .UseInMemoryDatabase(databaseName: "Shop").Options;

            using (var context = new ShopContext(options))
            {
                context.Users.Add(new User
                {
                    UserId = 4,
                    Name = "USA",
                    Email = "NY",
                    Cpf = "Test1"
                });
                context.Users.Add(new User
                {
                    UserId = 3,
                    Name = "BR",
                    Email = "RS",
                    Cpf = "Test2"
                });
                context.SaveChanges();
            }
                UsersController c = new UsersController(_service);
                //var result = await c.GetAllUsers();
        }
    }
}