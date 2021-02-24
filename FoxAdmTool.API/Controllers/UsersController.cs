using System;
using System.Threading.Tasks;
using FoxAdmTool.API.Models;
using FoxAdmTool.API.Service;
using Microsoft.AspNetCore.Mvc;

namespace FoxAdmTool.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _usersService.GetAllAsync();
            return Ok(users);
        }
        [HttpGet("{UserId}")]
        public async Task<ActionResult<User>> GetUserById(int UserId)
        {
            var user = await _usersService.GetAsync(UserId);
            return Ok(user);
        }
        [HttpPost("user")]
        public async Task<IActionResult> PostUser([FromBody] User user)
        {
            try
            {
                var us = await _usersService.UserInfo(user.Cpf);
                return Ok(us);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("userproducts/{id}")]
        public async Task<ActionResult> GetShoppingListById(int id)
        {
            var allUserInfo = await _usersService.GetAllUserInfo(id);
            return Ok(allUserInfo);
        }

        [HttpPost("userproducts/allinfo")]
        public async Task<ActionResult> PostShoppingListByCpf([FromBody] User user)
        {
            try
            {
                string cpf = user.Cpf;
                var allUserInfo = await _usersService.GetAllUserInfoCpf(cpf);
                return Ok(allUserInfo);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
        
        }
}
