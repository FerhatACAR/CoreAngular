using CoreAngular.API.Data;
using CoreAngular.API.Entities;
using Microsoft.AspNetCore.Mvc;

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
        public ActionResult<IEnumerable<AppUser>> GetUsers ()
        {
            var users = _context.Users.ToList();

            return users;
        }

        [HttpGet("{id}")]
        public ActionResult<AppUser> GetUser(int id)
        {
            var user = _context.Users.Find(id);
            
            return user;
        }
    }
}