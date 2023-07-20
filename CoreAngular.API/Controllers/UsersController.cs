using CoreAngular.API.Data;
using CoreAngular.API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoreAngular.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")] //localhost/api/Users
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;
        public UsersController(DataContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers ()
        {
            var users = await _context.Users.ToListAsync();

            return users;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            
            return user;
        }
    }
}