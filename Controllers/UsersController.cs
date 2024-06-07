using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using arq_backend;
using arq_backend.Entities;
using arq_backend.Models;
using AutoMapper;
using arq_backend.Services;
using Microsoft.AspNetCore.Authorization;

namespace arq_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(AppDbContext context, IMapper mapper, IConfiguration configuration) : ControllerBase
    {
        private readonly AppDbContext _context = context;
        private readonly UserService _service = new(mapper, configuration, context);

        //GET: api/Users
        [HttpGet]
        public async Task<ActionResult<ICollection<UserDTO>>> GetAllUser()
        {
            var users = await _context.Users.ToListAsync();
            var response = new List<UserDTO>();
            foreach (var user in users)
            {
                response.Add(_service.GetUserData(user));
            }
            return response;

        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FullUserDto>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return await _service.GetAllUserData(user);
        }

        //POST: api/Users/Login
        [HttpPost("Login")]
        public async Task<ActionResult<UserDTO>> Login(UserLoginDTO login)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == login.Email);
            if (user == null) return NotFound("User not found");
            if (user.Password != login.Password) return BadRequest("Invalid password");
            var response = _service.GetUserData(user);
            return response;
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(CreateUser user)
        {
            var role = await _context.Roles.FindAsync(user.RoleId);
            if (role == null)
            {
                return BadRequest("Role not found");
            }
            if(await _context.Users.AnyAsync(u => u.Email == user.Email)) return BadRequest("Email already in use");
            var newUser = _service.CreateUser(user);
            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();
            var result = await _context.Users.FirstOrDefaultAsync(u => u.Email == user.Email);
            if(result == null) return BadRequest("User not created");
            return CreatedAtAction("GetUser", new { id = result.Id }, result);
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
