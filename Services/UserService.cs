using arq_backend.Entities;
using arq_backend.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace arq_backend.Services
{
    public class UserService(IMapper mapper, IConfiguration configuration, AppDbContext context )
    {
        private readonly IMapper _mapper = mapper;
        private readonly IConfiguration _configuration = configuration;
        private readonly AppDbContext _context = context;

        private string GenerateToken(int userId)
        {
            var key = _configuration.GetValue<string>("Jwt:Key");
            if (key == null) throw new Exception("Jwt:Key not found in configuration");
            var keyBytes = Encoding.ASCII.GetBytes(key);
            var claims = new ClaimsIdentity();
            claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, userId.ToString()));
            var credentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256);
            var details = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = credentials
            };
            var handler = new JwtSecurityTokenHandler();
            var token = handler.CreateToken(details);
            var tokenString = handler.WriteToken(token);
            return tokenString;
        }

        public User CreateUser(CreateUser user)
        {
             var userEntity = _mapper.Map<User>(user);
            return userEntity;
        }

        public UserDTO GetUserData(User user)
        {
            var userDTO = _mapper.Map<UserDTO>(user);
            userDTO.Token = GenerateToken(user.Id);
            return userDTO;
        }

        public async Task<ActionResult<FullUserDto>> GetAllUserData(User user)
        {
            var userDTO = _mapper.Map<FullUserDto>(user);
            var role = await _context.Roles.FirstOrDefaultAsync(r => r.Id == user.RoleId) ?? throw new Exception("Role not found");
            userDTO.Role = _mapper.Map<RoleDTO>(role);
            return userDTO;
        }
    }
}
