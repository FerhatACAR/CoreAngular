using System.Security.Cryptography;
using System.Text;
using CoreAngular.API.Data;
using CoreAngular.API.DTOs;
using CoreAngular.API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoreAngular.API.Controllers
{
    public class AccountsController : BaseApiController
    {
        public DataContext _context { get; }
        public AccountsController(DataContext context)
        {
            this._context = context;
        }       

        [HttpPost("register")]
        public async Task<ActionResult<AppUser>> Register(RegisterDto registerDto)
        {
            if (await UserExists(registerDto.UserName)) return BadRequest("Username is taken");
                
            
            using var hmac = new HMACSHA512();
            var user = new AppUser
            {
                UserName = registerDto.UserName.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                PasswordSalt = hmac.Key
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }

        private async Task<bool> UserExists(string username)
        {
            return await _context.Users.AnyAsync(x => x.UserName == username.ToLower());
        }
    }
}