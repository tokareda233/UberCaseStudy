using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography.Xml;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using UberCaseStudy.Data;
using UberCaseStudy.DTO.AuthDto;
using UberCaseStudy.Models;
using UberCaseStudy.Repos.Interfaces;

namespace UberCaseStudy.Repos.Implementation
{
    public class AuthRepo : IAuthRepo
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _conf;
        public AuthRepo(AppDbContext context , IConfiguration conf)
        {
            _context = context;
            _conf = conf;
        }

        public async Task<string> Login(loginDTO login)
        {
           var u=await _context.users.FirstOrDefaultAsync(x=>x.Email==login.Email);
            if (u == null) { return null; }

            if (u.Password == login.Password)
            {
                return GenerateToken(u);
            }
            return null;
        }

        public async Task<bool> Register(RegisterDTO login)
        {
           var u =await _context.users.AnyAsync(x=>x.Email == login.Email); 
            if(u) { return false; }

            var user = new User
            {
                Email = login.Email,
                Password = login.Password,
                FullName = login.FullName,
                Role = login.Role,
                Phone = login.Phone,
            };

            _context.users.Add(user);
            _context.SaveChanges();
            return true;

        }

        private string GenerateToken(User user)
        {
            var claim = new List<Claim>
            {
                new Claim(ClaimTypes.Name,user.FullName),
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.MobilePhone,user.Phone),
                new Claim(ClaimTypes.Role,user.Role),
            };
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_conf["JWT:Key"]));

            var signing = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);


            var tokenobj = new JwtSecurityToken (

                issuer: _conf["JWT:Issuer"],
                audience: _conf["JWT:Audience"],
                expires: DateTime.UtcNow.AddHours(Convert.ToDouble(_conf["JWT:ExpirationInHours"])),
                claims:claim,
                signingCredentials:signing
                
                );
            
            var token=new JwtSecurityTokenHandler().WriteToken(tokenobj);
            return token;
        }
    }
}
