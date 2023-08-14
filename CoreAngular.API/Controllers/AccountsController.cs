using System.Security.Cryptography;
using System.Text;
using CoreAngular.API.Data;
using CoreAngular.API.Entities;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<ActionResult<AppUser>> Register(string username, string password)
        {
            using var hmac = new HMACSHA512();
            var user = new AppUser
            {
                UserName = username,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)),
                PasswordSalt = hmac.Key
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }
    }
}